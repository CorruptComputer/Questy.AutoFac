﻿using System;

namespace Questy.Autofac.Shared.Commands;

public class CustomerAddCommand : IRequest
{
    public Guid Id { get; }

    public string Name { get; }

    public CustomerAddCommand(Guid id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}