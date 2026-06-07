using System;
using System.Diagnostics.CodeAnalysis;

namespace Coherence.Cloud
{
	internal readonly struct Value : IEquatable<Value>
	{
		public static readonly Value None;

		internal const int MaxJsonLength = 4096;

		internal string Json { get; }

		private (bool hasValue, object value) ValueThatWasSerialized { get; }

		public T As<T>()
		{
			return default(T);
		}

		public bool As<T>(out T value)
		{
			value = default(T);
			return false;
		}

		public Value([AllowNull] string value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(bool value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(int value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(float value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(double value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(byte value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(short value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(Enum value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		public Value(object value)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		internal Value([AllowNull] object value, [DisallowNull] string json)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		private Value([DisallowNull] string json, bool hasValue)
		{
			Json = null;
			ValueThatWasSerialized = default((bool, object));
		}

		internal static Value FromJson(string json)
		{
			return default(Value);
		}

		private static string Serialize(object content)
		{
			return null;
		}

		private static string ToJson(object content)
		{
			return null;
		}

		private static T FromJson<T>(string json)
		{
			return default(T);
		}

		private static StorageException GetException(string message, Exception innerException = null)
		{
			return null;
		}

		public bool ValueEquals<T>(T other)
		{
			return false;
		}

		public bool Equals(Value other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static bool operator ==(Value left, Value right)
		{
			return false;
		}

		public static bool operator !=(Value left, Value right)
		{
			return false;
		}

		public static bool operator ==(Value left, string right)
		{
			return false;
		}

		public static bool operator !=(Value left, string right)
		{
			return false;
		}

		public static bool operator ==(Value left, bool right)
		{
			return false;
		}

		public static bool operator !=(Value left, bool right)
		{
			return false;
		}

		public static bool operator ==(Value left, int right)
		{
			return false;
		}

		public static bool operator !=(Value left, int right)
		{
			return false;
		}

		public static bool operator ==(Value left, byte right)
		{
			return false;
		}

		public static bool operator !=(Value left, byte right)
		{
			return false;
		}

		public static bool operator ==(Value left, Enum right)
		{
			return false;
		}

		public static bool operator !=(Value left, Enum right)
		{
			return false;
		}

		public static implicit operator string(Value value)
		{
			return null;
		}

		public static implicit operator bool(Value value)
		{
			return false;
		}

		public static implicit operator double(Value value)
		{
			return 0.0;
		}

		public static implicit operator float(Value value)
		{
			return 0f;
		}

		public static implicit operator int(Value value)
		{
			return 0;
		}

		public static implicit operator short(Value value)
		{
			return 0;
		}

		public static implicit operator byte(Value value)
		{
			return 0;
		}

		public static implicit operator Enum(Value value)
		{
			return null;
		}

		public static implicit operator Value(string value)
		{
			return default(Value);
		}

		public static implicit operator Value(bool value)
		{
			return default(Value);
		}

		public static implicit operator Value(int value)
		{
			return default(Value);
		}

		public static implicit operator Value(float value)
		{
			return default(Value);
		}

		public static implicit operator Value(double value)
		{
			return default(Value);
		}

		public static implicit operator Value(byte value)
		{
			return default(Value);
		}

		public static implicit operator Value(short value)
		{
			return default(Value);
		}

		public static implicit operator Value(Enum value)
		{
			return default(Value);
		}
	}
}
