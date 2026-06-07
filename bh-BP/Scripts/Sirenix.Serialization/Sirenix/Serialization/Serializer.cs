using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sirenix.Serialization
{
	public abstract class Serializer
	{
		private static readonly Dictionary<Type, Type> PrimitiveReaderWriterTypes;

		private static readonly object LOCK;

		private static readonly Dictionary<Type, Serializer> Weak_ReaderWriterCache;

		private static readonly Dictionary<Type, Serializer> Strong_ReaderWriterCache;

		[Conditional("UNITY_EDITOR")]
		protected static void FireOnSerializedType(Type type)
		{
		}

		public static Serializer GetForValue(object value)
		{
			return null;
		}

		public static Serializer<T> Get<T>()
		{
			return null;
		}

		public static Serializer Get(Type type)
		{
			return null;
		}

		private static Serializer Get(Type type, bool allowWeakFallback)
		{
			return null;
		}

		public abstract object ReadValueWeak(IDataReader reader);

		public void WriteValueWeak(object value, IDataWriter writer)
		{
		}

		public abstract void WriteValueWeak(string name, object value, IDataWriter writer);

		private static Serializer Create(Type type, bool allowWeakfallback)
		{
			return null;
		}

		private static void LogAOTError(Type type, ExecutionEngineException ex)
		{
		}
	}
	public abstract class Serializer<T> : Serializer
	{
		public override object ReadValueWeak(IDataReader reader)
		{
			return null;
		}

		public override void WriteValueWeak(string name, object value, IDataWriter writer)
		{
		}

		public abstract T ReadValue(IDataReader reader);

		public void WriteValue(T value, IDataWriter writer)
		{
		}

		public abstract void WriteValue(string name, T value, IDataWriter writer);

		[Conditional("UNITY_EDITOR")]
		protected static void FireOnSerializedType()
		{
		}
	}
}
