using System;

namespace MessagePipe
{
	public static class DependencyInjectionShims
	{
		public static T GetRequiredService<T>(this IServiceProvider provider)
		{
			return (T)(provider.GetService(typeof(T)) ?? throw new InvalidOperationException(typeof(T).FullName + " is not registered."));
		}

		public static object GetRequiredService(this IServiceProvider provider, Type type)
		{
			return provider.GetService(type) ?? throw new InvalidOperationException(type.FullName + " is not registered.");
		}
	}
}
