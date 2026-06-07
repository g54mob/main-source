using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class FieldMask : IMessage<FieldMask>, IMessage, IEquatable<FieldMask>, IDeepCloneable<FieldMask>, IBufferMessage, ICustomDiagnosticMessage
	{
		public sealed class MergeOptions
		{
			public bool ReplaceMessageFields { get; set; }

			public bool ReplaceRepeatedFields { get; set; }

			public bool ReplacePrimitiveFields { get; set; }
		}

		private static readonly MessageParser<FieldMask> _parser;

		private UnknownFieldSet _unknownFields;

		public const int PathsFieldNumber = 1;

		private static readonly FieldCodec<string> _repeated_paths_codec;

		private readonly RepeatedField<string> paths_;

		private const char FIELD_PATH_SEPARATOR = ',';

		private const char FIELD_SEPARATOR_REGEX = '.';

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<FieldMask> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<string> Paths => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldMask()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldMask(FieldMask other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public FieldMask Clone()
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
		public bool Equals(FieldMask other)
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
		public void MergeFrom(FieldMask other)
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

		internal static string ToJson(IList<string> paths, bool diagnosticOnly)
		{
			return null;
		}

		public string ToDiagnosticString()
		{
			return null;
		}

		public static FieldMask FromString(string value)
		{
			return null;
		}

		public static FieldMask FromString<T>(string value) where T : IMessage
		{
			return null;
		}

		public static FieldMask FromStringEnumerable<T>(IEnumerable<string> paths) where T : IMessage
		{
			return null;
		}

		public static FieldMask FromFieldNumbers<T>(params int[] fieldNumbers) where T : IMessage
		{
			return null;
		}

		public static FieldMask FromFieldNumbers<T>(IEnumerable<int> fieldNumbers) where T : IMessage
		{
			return null;
		}

		private static bool IsPathValid(string input)
		{
			return false;
		}

		public static bool IsValid<T>(FieldMask fieldMask) where T : IMessage
		{
			return false;
		}

		public static bool IsValid(MessageDescriptor descriptor, FieldMask fieldMask)
		{
			return false;
		}

		public static bool IsValid<T>(string path) where T : IMessage
		{
			return false;
		}

		public static bool IsValid(MessageDescriptor descriptor, string path)
		{
			return false;
		}

		public FieldMask Normalize()
		{
			return null;
		}

		public FieldMask Union(params FieldMask[] otherMasks)
		{
			return null;
		}

		public FieldMask Intersection(FieldMask additionalMask)
		{
			return null;
		}

		public void Merge(IMessage source, IMessage destination, MergeOptions options)
		{
		}

		public void Merge(IMessage source, IMessage destination)
		{
		}
	}
}
