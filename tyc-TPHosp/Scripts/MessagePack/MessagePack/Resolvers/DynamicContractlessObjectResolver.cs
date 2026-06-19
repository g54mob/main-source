using System;
using System.Reflection;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace MessagePack.Resolvers
{
	public sealed class DynamicContractlessObjectResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				if (typeof(T) == typeof(object))
				{
					return;
				}
				TypeInfo typeInfo = typeof(T).GetTypeInfo();
				if (typeInfo.IsInterface)
				{
					return;
				}
				if (typeInfo.IsNullable())
				{
					typeInfo = typeInfo.GenericTypeArguments[0].GetTypeInfo();
					object formatterDynamic = Instance.GetFormatterDynamic(typeInfo.AsType());
					if (formatterDynamic != null)
					{
						formatter = (IMessagePackFormatter<T>)Activator.CreateInstance(typeof(StaticNullableFormatter<>).MakeGenericType(typeInfo.AsType()), formatterDynamic);
					}
				}
				else if (typeInfo.IsAnonymous())
				{
					formatter = (IMessagePackFormatter<T>)DynamicObjectTypeBuilder.BuildFormatterToDynamicMethod(typeof(T), forceStringKey: true, contractless: true, allowPrivate: false);
				}
				else
				{
					TypeInfo typeInfo2 = DynamicObjectTypeBuilder.BuildType(assembly, typeof(T), forceStringKey: true, contractless: true);
					if (!(typeInfo2 == null))
					{
						formatter = (IMessagePackFormatter<T>)Activator.CreateInstance(typeInfo2.AsType());
					}
				}
			}
		}

		public static readonly DynamicContractlessObjectResolver Instance;

		private const string ModuleName = "MessagePack.Resolvers.DynamicContractlessObjectResolver";

		private static readonly DynamicAssembly assembly;

		private DynamicContractlessObjectResolver()
		{
		}

		static DynamicContractlessObjectResolver()
		{
			Instance = new DynamicContractlessObjectResolver();
			assembly = new DynamicAssembly("MessagePack.Resolvers.DynamicContractlessObjectResolver");
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
