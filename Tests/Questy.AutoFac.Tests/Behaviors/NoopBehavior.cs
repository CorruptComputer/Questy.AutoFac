﻿using System.Threading;
using System.Threading.Tasks;

namespace Questy.AutoFac.Tests.Behaviors;

public class NoopBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, INoopRequest<TResponse>
{
    public static int HitCount = 0;

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Interlocked.Increment(ref HitCount);
        return next();
    }
}