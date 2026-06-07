using System.Collections.Generic;

namespace Sirenix.Serialization
{
	public class StackFormatter<TStack, TValue> : BaseFormatter<TStack> where TStack : Stack<TValue>, new()
	{
		private static readonly Serializer<TValue> TSerializer;

		private static readonly bool IsPlainStack;

		static StackFormatter()
		{
		}

		protected override TStack GetUninitializedObject()
		{
			return null;
		}

		protected override void DeserializeImplementation(ref TStack value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref TStack value, IDataWriter writer)
		{
		}
	}
}
