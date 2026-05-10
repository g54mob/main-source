using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed class Timestamp : IMessage<Timestamp>, IMessage, IEquatable<Timestamp>, IDeepCloneable<Timestamp>, IBufferMessage, ICustomDiagnosticMessage, IComparable<Timestamp>
	{
		private static readonly MessageParser<Timestamp> _parser;

		private UnknownFieldSet _unknownFields;

		public const int SecondsFieldNumber = 1;

		private long seconds_;

		public const int NanosFieldNumber = 2;

		private int nanos_;

		private static readonly DateTime UnixEpoch;

		private const long BclSecondsAtUnixEpoch = 62135596800L;

		internal const long UnixSecondsAtBclMaxValue = 253402300799L;

		internal const long UnixSecondsAtBclMinValue = -62135596800L;

		internal const int MaxNanos = 999999999;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<Timestamp> Parser => null;

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
		public Timestamp()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Timestamp(Timestamp other)
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Timestamp Clone()
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
		public bool Equals(Timestamp other)
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
		public void MergeFrom(Timestamp other)
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

		private static bool IsNormalized(long seconds, int nanoseconds)
		{
			return false;
		}

		public static Duration operator -(Timestamp lhs, Timestamp rhs)
		{
			return null;
		}

		public static Timestamp operator +(Timestamp lhs, Duration rhs)
		{
			return null;
		}

		public static Timestamp operator -(Timestamp lhs, Duration rhs)
		{
			return null;
		}

		public DateTime ToDateTime()
		{
			return default(DateTime);
		}

		public DateTimeOffset ToDateTimeOffset()
		{
			return default(DateTimeOffset);
		}

		public static Timestamp FromDateTime(DateTime dateTime)
		{
			return null;
		}

		public static Timestamp FromDateTimeOffset(DateTimeOffset dateTimeOffset)
		{
			return null;
		}

		internal static Timestamp Normalize(long seconds, int nanoseconds)
		{
			return null;
		}

		internal static string ToJson(long seconds, int nanoseconds, bool diagnosticOnly)
		{
			return null;
		}

		public int CompareTo(Timestamp other)
		{
			return 0;
		}

		public static bool operator <(Timestamp a, Timestamp b)
		{
			return false;
		}

		public static bool operator >(Timestamp a, Timestamp b)
		{
			return false;
		}

		public static bool operator <=(Timestamp a, Timestamp b)
		{
			return false;
		}

		public static bool operator >=(Timestamp a, Timestamp b)
		{
			return false;
		}

		public static bool operator ==(Timestamp a, Timestamp b)
		{
			return false;
		}

		public static bool operator !=(Timestamp a, Timestamp b)
		{
			return false;
		}

		public string ToDiagnosticString()
		{
			return null;
		}
	}
}
