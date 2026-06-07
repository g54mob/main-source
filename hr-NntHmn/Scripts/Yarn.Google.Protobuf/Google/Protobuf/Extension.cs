using System;

namespace Google.Protobuf
{
	public abstract class Extension
	{
		internal abstract Type TargetType { get; }

		public int FieldNumber { get; }

		internal abstract bool IsRepeated { get; }

		protected Extension(int fieldNumber)
		{
		}

		internal abstract IExtensionValue CreateValue();
	}
	public sealed class Extension<TTarget, TValue> : Extension where TTarget : IExtendableMessage<TTarget>
	{
		private readonly FieldCodec<TValue> codec;

		internal TValue DefaultValue => default(TValue);

		internal override Type TargetType => null;

		internal override bool IsRepeated => false;

		public Extension(int fieldNumber, FieldCodec<TValue> codec)
			: base(0)
		{
		}

		internal override IExtensionValue CreateValue()
		{
			return null;
		}
	}
}
