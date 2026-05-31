using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Text;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Duration : IMessage<Duration>, IMessage, IEquatable<Duration>, IDeepCloneable<Duration>, IBufferMessage, ICustomDiagnosticMessage, IComparable<Duration>
	{
		private static readonly MessageParser<Duration> _parser;

		private UnknownFieldSet _unknownFields;

		public const int SecondsFieldNumber = 1;

		private long seconds_;

		public const int NanosFieldNumber = 2;

		private int nanos_;

		public const int NanosecondsPerSecond = 1000000000;

		public const int NanosecondsPerTick = 100;

		public const long MaxSeconds = 315576000000L;

		public const long MinSeconds = -315576000000L;

		internal const int MaxNanoseconds = 999999999;

		internal const int MinNanoseconds = -999999999;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Duration> Parser => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public long Seconds
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public int Nanos
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
		public Duration()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Duration(Duration other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Duration Clone()
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
		public bool Equals(Duration other)
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
		public void MergeFrom(Duration other)
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

		internal static bool IsNormalized(long seconds, int nanoseconds)
		{
			return false;
		}

		public TimeSpan ToTimeSpan()
		{
			return default(TimeSpan);
		}

		public static Duration FromTimeSpan(TimeSpan timeSpan)
		{
			return null;
		}

		public static Duration operator -(Duration value)
		{
			return null;
		}

		public static Duration operator +(Duration lhs, Duration rhs)
		{
			return null;
		}

		public static Duration operator -(Duration lhs, Duration rhs)
		{
			return null;
		}

		internal static Duration Normalize(long seconds, int nanoseconds)
		{
			return null;
		}

		internal static string ToJson(long seconds, int nanoseconds, bool diagnosticOnly)
		{
			return null;
		}

		public string ToDiagnosticString()
		{
			return null;
		}

		internal static void AppendNanoseconds(StringBuilder builder, int nanos)
		{
		}

		public int CompareTo(Duration other)
		{
			return 0;
		}
	}
}
