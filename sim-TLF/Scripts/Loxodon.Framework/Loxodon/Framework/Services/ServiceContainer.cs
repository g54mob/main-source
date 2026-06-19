using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Loxodon.Framework.Services
{
	public class ServiceContainer : IServiceContainer, IServiceLocator, IServiceRegistry, IDisposable
	{
		internal class Entry : IDisposable
		{
			public string Name { get; }

			public Type Type { get; }

			public IFactory Factory { get; }

			public Entry(string name, Type type, IFactory factory)
			{
				Name = name;
				Type = type;
				Factory = factory;
			}

			public void Dispose()
			{
				Factory.Dispose();
			}
		}

		internal interface IFactory : IDisposable
		{
			object Create();
		}

		internal class GenericFactory<T> : IFactory, IDisposable
		{
			private Func<T> func;

			public GenericFactory(Func<T> func)
			{
				this.func = func;
			}

			public virtual object Create()
			{
				return func();
			}

			public void Dispose()
			{
			}
		}

		internal class SingleInstanceFactory : IFactory, IDisposable
		{
			private object target;

			private bool disposed;

			public SingleInstanceFactory(object target)
			{
				this.target = target;
			}

			public virtual object Create()
			{
				return target;
			}

			protected virtual void Dispose(bool disposing)
			{
				if (disposed)
				{
					return;
				}
				if (disposing)
				{
					if (target is IDisposable disposable)
					{
						disposable.Dispose();
					}
					target = null;
				}
				disposed = true;
			}

			~SingleInstanceFactory()
			{
				Dispose(disposing: false);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}

		private readonly object _lock = new object();

		private ConcurrentDictionary<string, Entry> nameServiceMappings = new ConcurrentDictionary<string, Entry>();

		private ConcurrentDictionary<Type, Entry> typeServiceMappings = new ConcurrentDictionary<Type, Entry>();

		private bool disposed;

		public virtual object Resolve(Type type)
		{
			if (typeServiceMappings.TryGetValue(type, out var value))
			{
				return value.Factory.Create();
			}
			return null;
		}

		public virtual T Resolve<T>()
		{
			if (typeServiceMappings.TryGetValue(typeof(T), out var value))
			{
				return (T)value.Factory.Create();
			}
			return default(T);
		}

		public virtual object Resolve(string name)
		{
			if (nameServiceMappings.TryGetValue(name, out var value))
			{
				return value.Factory.Create();
			}
			return null;
		}

		public virtual T Resolve<T>(string name)
		{
			if (nameServiceMappings.TryGetValue(name, out var value))
			{
				return (T)value.Factory.Create();
			}
			return default(T);
		}

		public virtual void Register<T>(Func<T> factory)
		{
			Register0(typeof(T), new GenericFactory<T>(factory));
		}

		public virtual void Register(Type type, object target)
		{
			Register0(type, new SingleInstanceFactory(target));
		}

		public virtual void Register(string name, object target)
		{
			Register0(name, new SingleInstanceFactory(target));
		}

		public virtual void Register<T>(T target)
		{
			Register0(typeof(T), new SingleInstanceFactory(target));
		}

		public virtual void Register<T>(string name, Func<T> factory)
		{
			Register0(name, new GenericFactory<T>(factory));
		}

		public virtual void Register<T>(string name, T target)
		{
			Register0(name, new SingleInstanceFactory(target));
		}

		public virtual void Unregister(Type type)
		{
			Unregister0(type);
		}

		public virtual void Unregister<T>()
		{
			Unregister0(typeof(T));
		}

		public virtual void Unregister(string name)
		{
			Unregister0(name);
		}

		internal void Register0(Type type, IFactory factory)
		{
			lock (_lock)
			{
				string text = (type.IsGenericType ? null : type.Name);
				Entry value = new Entry(text, type, factory);
				if (!typeServiceMappings.TryAdd(type, value))
				{
					throw new DuplicateRegisterServiceException($"Duplicate key {type}");
				}
				if (!string.IsNullOrEmpty(text))
				{
					nameServiceMappings.TryAdd(text, value);
				}
			}
		}

		internal void Register0(string name, IFactory factory)
		{
			lock (_lock)
			{
				if (!nameServiceMappings.TryAdd(name, new Entry(name, null, factory)))
				{
					throw new DuplicateRegisterServiceException($"Duplicate key {name}");
				}
			}
		}

		internal void Unregister0(string name)
		{
			lock (_lock)
			{
				if (nameServiceMappings.TryRemove(name, out var value) && value != null && !(value.Type == null) && typeServiceMappings.TryGetValue(value.Type, out var value2) && value == value2)
				{
					typeServiceMappings.TryRemove(value.Type, out var _);
				}
			}
		}

		internal void Unregister0(Type type)
		{
			lock (_lock)
			{
				if (typeServiceMappings.TryRemove(type, out var value) && value != null && !string.IsNullOrEmpty(value.Name) && nameServiceMappings.TryGetValue(value.Name, out var value2) && value == value2)
				{
					nameServiceMappings.TryRemove(value.Name, out var _);
				}
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
			{
				return;
			}
			if (disposing)
			{
				foreach (KeyValuePair<string, Entry> nameServiceMapping in nameServiceMappings)
				{
					nameServiceMapping.Value.Dispose();
				}
				nameServiceMappings.Clear();
				nameServiceMappings = null;
				foreach (KeyValuePair<Type, Entry> typeServiceMapping in typeServiceMappings)
				{
					typeServiceMapping.Value.Dispose();
				}
				typeServiceMappings.Clear();
				typeServiceMappings = null;
			}
			disposed = true;
		}

		~ServiceContainer()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
