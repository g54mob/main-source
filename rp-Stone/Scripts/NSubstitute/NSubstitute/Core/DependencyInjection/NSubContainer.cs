using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace NSubstitute.Core.DependencyInjection
{
	public class NSubContainer : IConfigurableNSubContainer, INSubContainer, INSubResolver
	{
		private class Registration
		{
			private readonly Func<Scope, object> _factory;

			private object? _singletonValue;

			public NSubLifetime Lifetime { get; }

			public Registration(Func<Scope, object> factory, NSubLifetime lifetime)
			{
				_factory = factory;
				Lifetime = lifetime;
			}

			public object Resolve(Scope scope)
			{
				switch (Lifetime)
				{
				case NSubLifetime.Transient:
					return _factory(scope);
				case NSubLifetime.Singleton:
					return _singletonValue ?? (_singletonValue = _factory(scope));
				case NSubLifetime.PerScope:
				{
					if (scope.TryGetCached(this, out var result))
					{
						return result;
					}
					result = _factory(scope);
					scope.Set(this, result);
					return result;
				}
				default:
					throw new InvalidOperationException("Unknown lifetime");
				}
			}
		}

		private class Scope : INSubResolver
		{
			private readonly Dictionary<Registration, object> _cache = new Dictionary<Registration, object>();

			private readonly NSubContainer _mostNestedContainer;

			public Scope(NSubContainer mostNestedContainer)
			{
				_mostNestedContainer = mostNestedContainer;
			}

			public T Resolve<T>() where T : notnull
			{
				return (T)Resolve(typeof(T));
			}

			public bool TryGetCached(Registration registration, [MaybeNullWhen(false)] out object result)
			{
				return _cache.TryGetValue(registration, out result);
			}

			public void Set(Registration registration, object value)
			{
				_cache[registration] = value;
			}

			public object Resolve(Type type)
			{
				lock (_mostNestedContainer._syncRoot)
				{
					return (_mostNestedContainer.TryFindRegistration(type) ?? throw new InvalidOperationException("Type is not registered: " + type.FullName)).Resolve(this);
				}
			}

			public object Resolve(Registration registration)
			{
				lock (_mostNestedContainer._syncRoot)
				{
					return registration.Resolve(this);
				}
			}
		}

		private readonly NSubContainer? _parentContainer;

		private readonly object _syncRoot;

		private readonly Dictionary<Type, Registration> _registrations = new Dictionary<Type, Registration>();

		public NSubContainer()
		{
			_syncRoot = new object();
		}

		private NSubContainer(NSubContainer parentContainer)
		{
			_parentContainer = parentContainer;
			_syncRoot = parentContainer._syncRoot;
		}

		public T Resolve<T>() where T : notnull
		{
			return CreateScope().Resolve<T>();
		}

		public IConfigurableNSubContainer Register<TKey, TImpl>(NSubLifetime lifetime) where TKey : notnull where TImpl : TKey
		{
			ConstructorInfo[] constructors = typeof(TImpl).GetConstructors();
			if (constructors.Length != 1)
			{
				throw new ArgumentException("Type '" + typeof(TImpl).FullName + "' should contain only single public constructor. Please register type using factory method to avoid ambiguity.");
			}
			ConstructorInfo ctor = constructors[0];
			SetRegistration(typeof(TKey), new Registration(Factory, lifetime));
			return this;
			object Factory(Scope scope)
			{
				object[] parameters = (from p in ctor.GetParameters()
					select scope.Resolve(p.ParameterType)).ToArray();
				return ctor.Invoke(parameters);
			}
		}

		public IConfigurableNSubContainer Register<TKey>(Func<INSubResolver, TKey> factory, NSubLifetime lifetime) where TKey : notnull
		{
			SetRegistration(typeof(TKey), new Registration(Factory, lifetime));
			return this;
			object Factory(Scope scope)
			{
				return factory(scope);
			}
		}

		public IConfigurableNSubContainer Decorate<TKey>(Func<TKey, INSubResolver, TKey> factory) where TKey : notnull
		{
			Registration existingRegistration = TryFindRegistration(typeof(TKey));
			if (existingRegistration == null)
			{
				throw new ArgumentException("Cannot decorate type " + typeof(TKey).FullName + " as implementation is not registered.");
			}
			SetRegistration(typeof(TKey), new Registration(Factory, existingRegistration.Lifetime));
			return this;
			object Factory(Scope scope)
			{
				TKey arg = (TKey)scope.Resolve(existingRegistration);
				return factory(arg, scope);
			}
		}

		public IConfigurableNSubContainer Customize()
		{
			return new NSubContainer(this);
		}

		public INSubResolver CreateScope()
		{
			return new Scope(this);
		}

		private void SetRegistration(Type type, Registration registration)
		{
			lock (_syncRoot)
			{
				_registrations[type] = registration;
			}
		}

		private Registration? TryFindRegistration(Type type)
		{
			lock (_syncRoot)
			{
				for (NSubContainer nSubContainer = this; nSubContainer != null; nSubContainer = nSubContainer._parentContainer)
				{
					if (nSubContainer._registrations.TryGetValue(type, out var value))
					{
						return value;
					}
				}
				return null;
			}
		}
	}
}
