using System;

namespace Sirenix.Serialization
{
	public class DelegateFormatter<T> : BaseFormatter<T> where T : class
	{
		private static readonly Serializer<object> ObjectSerializer;

		private static readonly Serializer<string> StringSerializer;

		private static readonly Serializer<Type> TypeSerializer;

		private static readonly Serializer<Type[]> TypeArraySerializer;

		private static readonly Serializer<Delegate[]> DelegateArraySerializer;

		public readonly Type DelegateType;

		public DelegateFormatter()
		{
		}

		public DelegateFormatter(Type delegateType)
		{
		}

		protected override void DeserializeImplementation(ref T value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref T value, IDataWriter writer)
		{
		}

		protected override T GetUninitializedObject()
		{
			return null;
		}
	}
}
