﻿namespace Questy.Autofac.Shared.Notifications;

public class CustomerAddedNotification : INotification
{
    public string Name { get; }

    public CustomerAddedNotification(string name)
    {
        this.Name = name;
    }
}