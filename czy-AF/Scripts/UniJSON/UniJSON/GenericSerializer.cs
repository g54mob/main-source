using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniJSON
{
	internal static class GenericSerializer<T>
	{
		private delegate void Serializer(IFormatter f, T t);

		private static Serializer s_serializer;

		private static Action<IFormatter, T> GetSerializer()
		{
			Type typeFromHandle = typeof(T);
			if (typeof(T) == typeof(object) && typeFromHandle.GetType() != typeof(object))
			{
				return GenericInvokeCallFactory.StaticAction<IFormatter, T>(FormatterExtensionsSerializer.GetMethod("SerializeObject"));
			}
			try
			{
				MethodInfo method = typeof(IFormatter).GetMethod("Value", new Type[1] { typeFromHandle });
				if (method != null)
				{
					return GenericInvokeCallFactory.OpenAction<IFormatter, T>(method);
				}
			}
			catch (AmbiguousMatchException)
			{
			}
			if (typeFromHandle.GetInterfaces().FirstOrDefault((Type x) => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary<, >) && x.GetGenericArguments()[0] == typeof(string)) != null)
			{
				return GenericInvokeCallFactory.StaticAction<IFormatter, T>(FormatterExtensionsSerializer.GetMethod("SerializeDictionary"));
			}
			if (typeFromHandle == typeof(object[]))
			{
				return GenericInvokeCallFactory.StaticAction<IFormatter, T>(FormatterExtensionsSerializer.GetMethod("SerializeObjectArray"));
			}
			Type type = typeFromHandle.GetInterfaces().FirstOrDefault((Type x) => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
			if (type != null)
			{
				return GenericInvokeCallFactory.StaticAction<IFormatter, T>(FormatterExtensionsSerializer.GetMethod("SerializeArray").MakeGenericMethod(type.GetGenericArguments()));
			}
			JsonSchema schema = JsonSchema.FromType<T>();
			return delegate(IFormatter f, T value)
			{
				JsonSchemaValidationContext c = new JsonSchemaValidationContext(value)
				{
					EnableDiagnosisForNotRequiredFields = true
				};
				schema.Serialize(f, value, c);
			};
		}

		public static void Set(Action<IFormatter, T> serializer)
		{
			s_serializer = serializer.Invoke;
		}

		public static void Serialize(IFormatter f, T t)
		{
			if (s_serializer == null)
			{
				s_serializer = GetSerializer().Invoke;
			}
			s_serializer(f, t);
		}
	}
}
