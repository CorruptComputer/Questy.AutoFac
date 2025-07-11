﻿using System;

namespace Questy.Autofac.Shared.Entities;

public class Customer
{
    public Guid Id { get; }

    public string Name { get; }

    public Customer(Guid id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}