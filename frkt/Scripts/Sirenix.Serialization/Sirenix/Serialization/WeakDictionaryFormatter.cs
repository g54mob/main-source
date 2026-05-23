using System;
using System.Reflection;

namespace Sirenix.Serialization
{
	internal sealed class WeakDictionaryFormatter : WeakBaseFormatter
	{
		private readonly bool KeyIsValueType;

		private readonly Serializer EqualityComparerSerializer;

		private readonly Serializer KeyReaderWriter;

		private readonly Serializer ValueReaderWriter;

		private readonly ConstructorInfo ComparerConstructor;

		private readonly PropertyInfo ComparerProperty;

		private readonly PropertyInfo CountProperty;

		private readonly Type KeyType;

		private readonly Type ValueType;

		public WeakDictionaryFormatter(Type serializedType)
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
