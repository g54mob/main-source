using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class MethodOptions : IExtendableMessage<MethodOptions>, IMessage<MethodOptions>, IMessage, IEquatable<MethodOptions>, IDeepCloneable<MethodOptions>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum IdempotencyLevel
			{
				[OriginalName("IDEMPOTENCY_UNKNOWN")]
				IdempotencyUnknown = 0,
				[OriginalName("NO_SIDE_EFFECTS")]
				NoSideEffects = 1,
				[OriginalName("IDEMPOTENT")]
				Idempotent = 2
			}
		}

		private static readonly MessageParser<MethodOptions> _parser;

		private UnknownFieldSet _unknownFields;

		internal ExtensionSet<MethodOptions> _extensions;

		private int _hasBits0;

		public const int DeprecatedFieldNumber = 33;

		private static readonly bool DeprecatedDefaultValue;

		private bool deprecated_;

		public const int IdempotencyLevelFieldNumber = 34;

		private static readonly Types.IdempotencyLevel IdempotencyLevelDefaultValue;

		private Types.IdempotencyLevel idempotencyLevel_;

		public const int FeaturesFieldNumber = 35;

		private FeatureSet features_;

		public const int UninterpretedOptionFieldNumber = 999;

		private static readonly FieldCodec<UninterpretedOption> _repeated_uninterpretedOption_codec;

		private readonly RepeatedField<UninterpretedOption> uninterpretedOption_;

		private ExtensionSet<MethodOptions> _Extensions => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<MethodOptions> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Deprecated
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDeprecated => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.IdempotencyLevel IdempotencyLevel
		{
			get
			{
				return default(Types.IdempotencyLevel);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasIdempotencyLevel => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSet Features
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<UninterpretedOption> UninterpretedOption => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MethodOptions()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MethodOptions(MethodOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public MethodOptions Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearDeprecated()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearIdempotencyLevel()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Equals(MethodOptions other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override string ToString()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void WriteTo(CodedOutputStream output)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalWriteTo(ref WriteContext output)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void MergeFrom(MethodOptions other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void MergeFrom(CodedInputStream input)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalMergeFrom(ref ParseContext input)
		{
		}

		public TValue GetExtension<TValue>(Extension<MethodOptions, TValue> extension)
		{
			return default(TValue);
		}

		public RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<MethodOptions, TValue> extension)
		{
			return null;
		}

		public RepeatedField<TValue> GetOrInitializeExtension<TValue>(RepeatedExtension<MethodOptions, TValue> extension)
		{
			return null;
		}

		public void SetExtension<TValue>(Extension<MethodOptions, TValue> extension, TValue value)
		{
		}

		public bool HasExtension<TValue>(Extension<MethodOptions, TValue> extension)
		{
			return false;
		}

		public void ClearExtension<TValue>(Extension<MethodOptions, TValue> extension)
		{
		}

		public void ClearExtension<TValue>(RepeatedExtension<MethodOptions, TValue> extension)
		{
		}
	}
}
