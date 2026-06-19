using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sentry.Internal.Extensions;

namespace Sentry.Internal
{
	internal static class ObjectExtensions
	{
		private static ConditionalWeakTable<object, Dictionary<string, object?>> Map { get; } = new ConditionalWeakTable<object, Dictionary<string, object>>();

		private static Dictionary<string, object?> AssociatedProperties(this object source)
		{
			return Map.GetValue(source, (object _) => new Dictionary<string, object>());
		}

		public static void SetFused(this object source, string propertyName, object? value)
		{
			source.AssociatedProperties()[propertyName] = value;
		}

		public static void SetFused<T>(this object source, T value)
		{
			source.SetFused(typeof(T).Name, value);
		}

		public static T? GetFused<T>(this object source, string? propertyName = null)
		{
			if (propertyName == null)
			{
				propertyName = typeof(T).Name;
			}
			if (!source.AssociatedProperties().TryGetTypedValue<T>(propertyName, out var value))
			{
				return default(T);
			}
			return value;
		}
	}
}
