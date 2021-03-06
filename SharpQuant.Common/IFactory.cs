﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpQuant.Common
{
    /// <summary>
    /// Lifetime is managed within the client
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactory<T>
    {
        T CreateInstance();
    }

    interface IFactoryT<T> where T : class
    {
        T Create(string qualifiedName);
        T Create(string qualifiedName, string settings);
        T Create(Type t, SettingsDictionary settings);
    }

    public class DefaultFactory<T> : IFactory<T>
    {
        public DefaultFactory()
        {
        }

        public T CreateInstance()
        {
            return Activator.CreateInstance<T>();
        }
    }

    public class ResolverFactory<T> : IFactory<T>
    {
        IResolver _resolver;

        public ResolverFactory(IResolver resolver)
        {
            _resolver = resolver;
        }

        public T CreateInstance()
        {
            return _resolver.Resolve<T>();
        }
    }
}
