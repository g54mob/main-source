using System;
using System.Reflection;

namespace Sirenix.Serialization
{
	public sealed class WeakGenericCollectionFormatter : WeakBaseFormatter
	{
		private readonly Serializer ValueReaderWriter;

		private readonly Type ElementType;

		private readonly PropertyInfo CountProperty;

		private readonly MethodInfo AddMethod;

		public WeakGenericCollectionFormatter(Type collectionType, Type elementType)
			: base(null)
		{
		}

		protected override object GetUninitializedObject()
		{
			return null;
		}

		protected override void DeserializeImplementation(ref object value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref object value, IDataWriter writer)
		{
		}
	}
}
