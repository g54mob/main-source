using System;
using System.Reflection;

namespace Sirenix.Serialization
{
	public class WeakHashSetFormatter : WeakBaseFormatter
	{
		private readonly Serializer ElementSerializer;

		private readonly MethodInfo AddMethod;

		private readonly PropertyInfo CountProperty;

		public WeakHashSetFormatter(Type serializedType)
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
