﻿using Autofac;
using Questy.Autofac.Builder;
using Questy.Autofac.Shared.Queries;
using Questy.Autofac.Shared.Repositories;
using Questy.Autofac.WebApi.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Questy.Autofac.WebApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options => options.Filters.Add(typeof(CustomerNotFoundExceptionFilter)))
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(builder => builder.MapControllers());
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<CustomersRepository>()
            .As<ICustomersRepository>()
            .SingleInstance();

        QuestyConfiguration configuration = QuestyConfigurationBuilder.Create(typeof(CustomerLoadQuery).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();
        
        builder.RegisterQuesty(configuration);
    }
}