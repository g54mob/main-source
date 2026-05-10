using System;

namespace Sirenix.Serialization
{
	public sealed class WeakMultiDimensionalArrayFormatter : WeakBaseFormatter
	{
		private const string RANKS_NAME = "ranks";

		private const char RANKS_SEPARATOR = '|';

		private readonly int ArrayRank;

		private readonly Type ElementType;

		private readonly Serializer ValueReaderWriter;

		public WeakMultiDimensionalArrayFormatter(Type arrayType, Type elementType)
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

		private void IterateArrayWrite(Array a, Func<object> write)
		{
		}

		private void IterateArrayWrite(Array a, int rank, int[] indices, Func<object> write)
		{
		}

		private void IterateArrayRead(Array a, Action<object> read)
		{
		}

		private void IterateArrayRead(Array a, int rank, int[] indices, Action<object> read)
		{
		}
	}
}
