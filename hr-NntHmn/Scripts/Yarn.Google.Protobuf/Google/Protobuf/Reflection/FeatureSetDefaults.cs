using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class FeatureSetDefaults : IMessage<FeatureSetDefaults>, IMessage, IEquatable<FeatureSetDefaults>, IDeepCloneable<FeatureSetDefaults>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class FeatureSetEditionDefault : IMessage<FeatureSetEditionDefault>, IMessage, IEquatable<FeatureSetEditionDefault>, IDeepCloneable<FeatureSetEditionDefault>, IBufferMessage
			{
				private static readonly MessageParser<FeatureSetEditionDefault> _parser;

				private UnknownFieldSet _unknownFields;

				private int _hasBits0;

				public const int EditionFieldNumber = 3;

				private static readonly Edition EditionDefaultValue;

				private Edition edition_;

				public const int FeaturesFieldNumber = 2;

				private FeatureSet features_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<FeatureSetEditionDefault> Parser => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageDescriptor Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				MessageDescriptor IMessage.Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Edition Edition
				{
					get
					{
						return default(Edition);
					}
					set
					{
					}
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public bool HasEdition => false;

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
				public FeatureSetEditionDefault()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public FeatureSetEditionDefault(FeatureSetEditionDefault other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public FeatureSetEditionDefault Clone()
				{
					return null;
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearEdition()
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
				public bool Equals(FeatureSetEditionDefault other)
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
				public void MergeFrom(FeatureSetEditionDefault other)
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
			}
		}

		private static readonly MessageParser<FeatureSetDefaults> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int DefaultsFieldNumber = 1;

		private static readonly FieldCodec<Types.FeatureSetEditionDefault> _repeated_defaults_codec;

		private readonly RepeatedField<Types.FeatureSetEditionDefault> defaults_;

		public const int MinimumEditionFieldNumber = 4;

		private static readonly Edition MinimumEditionDefaultValue;

		private Edition minimumEdition_;

		public const int MaximumEditionFieldNumber = 5;

		private static readonly Edition MaximumEditionDefaultValue;

		private Edition maximumEdition_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<FeatureSetDefaults> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.FeatureSetEditionDefault> Defaults => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Edition MinimumEdition
		{
			get
			{
				return default(Edition);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasMinimumEdition => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Edition MaximumEdition
		{
			get
			{
				return default(Edition);
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasMaximumEdition => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSetDefaults()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSetDefaults(FeatureSetDefaults other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FeatureSetDefaults Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearMinimumEdition()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearMaximumEdition()
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
		public bool Equals(FeatureSetDefaults other)
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
		public void MergeFrom(FeatureSetDefaults other)
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
	}
}
