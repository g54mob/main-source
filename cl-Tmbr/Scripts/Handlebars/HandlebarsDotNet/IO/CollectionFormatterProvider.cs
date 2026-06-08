using System;
using System.Collections.Generic;
using System.Reflection;

namespace HandlebarsDotNet.IO
{
	public class CollectionFormatterProvider : IFormatterProvider
	{
		private class CollectionFormatter<TValue, TCollection> : IFormatter where TCollection : class, ICollection<TValue>
		{
			public void Format<T>(T value, in EncodedTextWriter writer)
			{
				int num = 0;
				TCollection obj = value as TCollection;
				int num2 = obj.Count - 1;
				foreach (TValue item in obj)
				{
					writer.Write(item);
					if (num != num2)
					{
						writer.Write(",", encode: false);
					}
					num++;
				}
			}

			void IFormatter.Format<T>(T value, in EncodedTextWriter writer)
			{
				Format(value, in writer);
			}
		}

		private static readonly Type CollectionFormatterType = typeof(CollectionFormatter<, >);

		private static readonly Type CollectionType = typeof(ICollection<>);

		public bool TryCreateFormatter(Type type, out IFormatter formatter)
		{
			if (!type.GetTypeInfo().IsClass || !type.IsAssignableToGenericType(CollectionType, out var resolvedType))
			{
				formatter = null;
				return false;
			}
			Type type2 = resolvedType.GetGenericArguments()[0];
			Type type3 = CollectionFormatterType.MakeGenericType(type2, type);
			formatter = (IFormatter)Activator.CreateInstance(type3);
			return true;
		}
	}
}
