using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class SourceCodeInfo : IMessage<SourceCodeInfo>, IMessage, IEquatable<SourceCodeInfo>, IDeepCloneable<SourceCodeInfo>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			[DebuggerDisplay("{ToString(),nq}")]
			public sealed class Location : IMessage<Location>, IMessage, IEquatable<Location>, IDeepCloneable<Location>, IBufferMessage
			{
				private static readonly MessageParser<Location> _parser;

				private UnknownFieldSet _unknownFields;

				public const int PathFieldNumber = 1;

				private static readonly FieldCodec<int> _repeated_path_codec;

				private readonly RepeatedField<int> path_;

				public const int SpanFieldNumber = 2;

				private static readonly FieldCodec<int> _repeated_span_codec;

				private readonly RepeatedField<int> span_;

				public const int LeadingCommentsFieldNumber = 3;

				private static readonly string LeadingCommentsDefaultValue;

				private string leadingComments_;

				public const int TrailingCommentsFieldNumber = 4;

				private static readonly string TrailingCommentsDefaultValue;

				private string trailingComments_;

				public const int LeadingDetachedCommentsFieldNumber = 6;

				private static readonly FieldCodec<string> _repeated_leadingDetachedComments_codec;

				private readonly RepeatedField<string> leadingDetachedComments_;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageParser<Location> Parser => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public static MessageDescriptor Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				MessageDescriptor IMessage.Descriptor => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public RepeatedField<int> Path => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public RepeatedField<int> Span => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public string LeadingComments
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
				public bool HasLeadingComments => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public string TrailingComments
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
				public bool HasTrailingComments => false;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public RepeatedField<string> LeadingDetachedComments => null;

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Location()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Location(Location other)
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public Location Clone()
				{
					return null;
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearLeadingComments()
				{
				}

				[DebuggerNonUserCode]
				[GeneratedCode("protoc", null)]
				public void ClearTrailingComments()
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
				public bool Equals(Location other)
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
				public void MergeFrom(Location other)
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

		private static readonly MessageParser<SourceCodeInfo> _parser;

		private UnknownFieldSet _unknownFields;

		public const int LocationFieldNumber = 1;

		private static readonly FieldCodec<Types.Location> _repeated_location_codec;

		private readonly RepeatedField<Types.Location> location_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<SourceCodeInfo> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<Types.Location> Location => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public SourceCodeInfo()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public SourceCodeInfo(SourceCodeInfo other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public SourceCodeInfo Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool Equals(SourceCodeInfo other)
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
		public void MergeFrom(SourceCodeInfo other)
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
