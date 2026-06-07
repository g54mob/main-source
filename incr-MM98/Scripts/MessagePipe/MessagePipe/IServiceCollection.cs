using System;

namespace MessagePipe
{
	public interface IServiceCollection
	{
		void Add(Type serviceType, InstanceLifetime lifetime);

		void Add(Type serviceType, Type implementationType, InstanceLifetime lifetime);

		void AddSingleton<T>(T instance);

		void AddSingleton(Type type);

		void AddTransient(Type type);

		void TryAddTransient(Type type);
	}
}
