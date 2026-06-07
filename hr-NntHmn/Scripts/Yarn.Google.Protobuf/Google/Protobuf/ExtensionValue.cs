using System;

namespace Google.Protobuf
{
	internal sealed class ExtensionValue<T> : IExtensionValue, IEquatable<IExtensionValue>, IDeepCloneable<IExtensionValue>
	{
		private T field;

		private readonly FieldCodec<T> codec;

		internal ExtensionValue(FieldCodec<T> codec)
		{
		}

		public int CalculateSize()
		{
			return 0;
		}

		public IExtensionValue Clone()
		{
			return null;
		}

		public bool Equals(IExtensionValue other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void MergeFrom(ref ParseContext ctx)
		{
		}

		public void MergeFrom(IExtensionValue value)
		{
		}

		public void WriteTo(ref WriteContext ctx)
		{
		}

		public T GetValue()
		{
			return default(T);
		}

		object IExtensionValue.GetValue()
		{
			return null;
		}

		public void SetValue(T value)
		{
		}

		public bool IsInitialized()
		{
			return false;
		}
	}
}
