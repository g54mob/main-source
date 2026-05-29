using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.Compiler
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Version : IMessage<Version>, IMessage, IEquatable<Version>, IDeepCloneable<Version>, IBufferMessage
	{
		private static readonly MessageParser<Version> _parser;

		private UnknownFieldSet _unknownFields;

		private int _hasBits0;

		public const int MajorFieldNumber = 1;

		private static readonly int MajorDefaultValue;

		private int major_;

		public const int MinorFieldNumber = 2;

		private static readonly int MinorDefaultValue;

		private int minor_;

		public const int PatchFieldNumber = 3;

		private static readonly int PatchDefaultValue;

		private int patch_;

		public const int SuffixFieldNumber = 4;

		private static readonly string SuffixDefaultValue;

		private string suffix_;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Version> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int Major
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasMajor => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int Minor
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasMinor => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int Patch
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPatch => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Suffix
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
		public bool HasSuffix => false;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Version()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Version(Version other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Version Clone()
		{
			return null;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearMajor()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearMinor()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearPatch()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public void ClearSuffix()
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
		public bool Equals(Version other)
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
		public void MergeFrom(Version other)
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
