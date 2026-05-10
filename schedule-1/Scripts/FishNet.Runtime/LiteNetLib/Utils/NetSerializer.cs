using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace LiteNetLib.Utils
{
	public class NetSerializer
	{
		private enum CallType
		{
			Basic = 0,
			Array = 1,
			List = 2
		}

		private abstract class FastCall<T>
		{
			public CallType Type;

			public virtual void Init(MethodInfo getMethod, MethodInfo setMethod, CallType type)
			{
			}

			public abstract void Read(T inf, NetDataReader r);

			public abstract void Write(T inf, NetDataWriter w);

			public abstract void ReadArray(T inf, NetDataReader r);

			public abstract void WriteArray(T inf, NetDataWriter w);

			public abstract void ReadList(T inf, NetDataReader r);

			public abstract void WriteList(T inf, NetDataWriter w);
		}

		private abstract class FastCallSpecific<TClass, TProperty> : FastCall<TClass>
		{
			protected Func<TClass, TProperty> Getter;

			protected Action<TClass, TProperty> Setter;

			protected Func<TClass, TProperty[]> GetterArr;

			protected Action<TClass, TProperty[]> SetterArr;

			protected Func<TClass, List<TProperty>> GetterList;

			protected Action<TClass, List<TProperty>> SetterList;

			public override void ReadArray(TClass inf, NetDataReader r)
			{
			}

			public override void WriteArray(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadList(TClass inf, NetDataReader r)
			{
			}

			public override void WriteList(TClass inf, NetDataWriter w)
			{
			}

			protected TProperty[] ReadArrayHelper(TClass inf, NetDataReader r)
			{
				return null;
			}

			protected TProperty[] WriteArrayHelper(TClass inf, NetDataWriter w)
			{
				return null;
			}

			protected List<TProperty> ReadListHelper(TClass inf, NetDataReader r, out int len)
			{
				len = default(int);
				return null;
			}

			protected List<TProperty> WriteListHelper(TClass inf, NetDataWriter w, out int len)
			{
				len = default(int);
				return null;
			}

			public override void Init(MethodInfo getMethod, MethodInfo setMethod, CallType type)
			{
			}
		}

		private abstract class FastCallSpecificAuto<TClass, TProperty> : FastCallSpecific<TClass, TProperty>
		{
			protected abstract void ElementRead(NetDataReader r, out TProperty prop);

			protected abstract void ElementWrite(NetDataWriter w, ref TProperty prop);

			public override void Read(TClass inf, NetDataReader r)
			{
			}

			public override void Write(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadArray(TClass inf, NetDataReader r)
			{
			}

			public override void WriteArray(TClass inf, NetDataWriter w)
			{
			}
		}

		private sealed class FastCallStatic<TClass, TProperty> : FastCallSpecific<TClass, TProperty>
		{
			private readonly Action<NetDataWriter, TProperty> _writer;

			private readonly Func<NetDataReader, TProperty> _reader;

			public FastCallStatic(Action<NetDataWriter, TProperty> write, Func<NetDataReader, TProperty> read)
			{
			}

			public override void Read(TClass inf, NetDataReader r)
			{
			}

			public override void Write(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadList(TClass inf, NetDataReader r)
			{
			}

			public override void WriteList(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadArray(TClass inf, NetDataReader r)
			{
			}

			public override void WriteArray(TClass inf, NetDataWriter w)
			{
			}
		}

		private sealed class FastCallStruct<TClass, TProperty> : FastCallSpecific<TClass, TProperty> where TProperty : struct, INetSerializable
		{
			private TProperty _p;

			public override void Read(TClass inf, NetDataReader r)
			{
			}

			public override void Write(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadList(TClass inf, NetDataReader r)
			{
			}

			public override void WriteList(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadArray(TClass inf, NetDataReader r)
			{
			}

			public override void WriteArray(TClass inf, NetDataWriter w)
			{
			}
		}

		private sealed class FastCallClass<TClass, TProperty> : FastCallSpecific<TClass, TProperty> where TProperty : class, INetSerializable
		{
			private readonly Func<TProperty> _constructor;

			public FastCallClass(Func<TProperty> constructor)
			{
			}

			public override void Read(TClass inf, NetDataReader r)
			{
			}

			public override void Write(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadList(TClass inf, NetDataReader r)
			{
			}

			public override void WriteList(TClass inf, NetDataWriter w)
			{
			}

			public override void ReadArray(TClass inf, NetDataReader r)
			{
			}

			public override void WriteArray(TClass inf, NetDataWriter w)
			{
			}
		}

		private class IntSerializer<T> : FastCallSpecific<T, int>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class UIntSerializer<T> : FastCallSpecific<T, uint>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class ShortSerializer<T> : FastCallSpecific<T, short>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class UShortSerializer<T> : FastCallSpecific<T, ushort>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class LongSerializer<T> : FastCallSpecific<T, long>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class ULongSerializer<T> : FastCallSpecific<T, ulong>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class ByteSerializer<T> : FastCallSpecific<T, byte>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class SByteSerializer<T> : FastCallSpecific<T, sbyte>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class FloatSerializer<T> : FastCallSpecific<T, float>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class DoubleSerializer<T> : FastCallSpecific<T, double>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class BoolSerializer<T> : FastCallSpecific<T, bool>
		{
			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class CharSerializer<T> : FastCallSpecificAuto<T, char>
		{
			protected override void ElementWrite(NetDataWriter w, ref char prop)
			{
			}

			protected override void ElementRead(NetDataReader r, out char prop)
			{
				prop = default(char);
			}
		}

		private class IPEndPointSerializer<T> : FastCallSpecificAuto<T, IPEndPoint>
		{
			protected override void ElementWrite(NetDataWriter w, ref IPEndPoint prop)
			{
			}

			protected override void ElementRead(NetDataReader r, out IPEndPoint prop)
			{
				prop = null;
			}
		}

		private class StringSerializer<T> : FastCallSpecific<T, string>
		{
			private readonly int _maxLength;

			public StringSerializer(int maxLength)
			{
			}

			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}
		}

		private class EnumByteSerializer<T> : FastCall<T>
		{
			protected readonly PropertyInfo Property;

			protected readonly Type PropertyType;

			public EnumByteSerializer(PropertyInfo property, Type propertyType)
			{
			}

			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}

			public override void ReadArray(T inf, NetDataReader r)
			{
			}

			public override void WriteArray(T inf, NetDataWriter w)
			{
			}

			public override void ReadList(T inf, NetDataReader r)
			{
			}

			public override void WriteList(T inf, NetDataWriter w)
			{
			}
		}

		private class EnumIntSerializer<T> : EnumByteSerializer<T>
		{
			public EnumIntSerializer(PropertyInfo property, Type propertyType)
			{
			}

			public override void Read(T inf, NetDataReader r)
			{
			}

			public override void Write(T inf, NetDataWriter w)
			{
			}
		}

		private sealed class ClassInfo<T>
		{
			public static ClassInfo<T> Instance;

			private readonly FastCall<T>[] _serializers;

			private readonly int _membersCount;

			public ClassInfo(List<FastCall<T>> serializers)
			{
			}

			public void Write(T obj, NetDataWriter writer)
			{
			}

			public void Read(T obj, NetDataReader reader)
			{
			}
		}

		private abstract class CustomType
		{
			public abstract FastCall<T> Get<T>();
		}

		private sealed class CustomTypeStruct<TProperty> : CustomType where TProperty : struct, INetSerializable
		{
			public override FastCall<T> Get<T>()
			{
				return null;
			}
		}

		private sealed class CustomTypeClass<TProperty> : CustomType where TProperty : class, INetSerializable
		{
			private readonly Func<TProperty> _constructor;

			public CustomTypeClass(Func<TProperty> constructor)
			{
			}

			public override FastCall<T> Get<T>()
			{
				return null;
			}
		}

		private sealed class CustomTypeStatic<TProperty> : CustomType
		{
			private readonly Action<NetDataWriter, TProperty> _writer;

			private readonly Func<NetDataReader, TProperty> _reader;

			public CustomTypeStatic(Action<NetDataWriter, TProperty> writer, Func<NetDataReader, TProperty> reader)
			{
			}

			public override FastCall<T> Get<T>()
			{
				return null;
			}
		}

		private NetDataWriter _writer;

		private readonly int _maxStringLength;

		private readonly Dictionary<Type, CustomType> _registeredTypes;

		public void RegisterNestedType<T>() where T : struct, INetSerializable
		{
		}

		public void RegisterNestedType<T>(Func<T> constructor) where T : class, INetSerializable
		{
		}

		public void RegisterNestedType<T>(Action<NetDataWriter, T> writer, Func<NetDataReader, T> reader)
		{
		}

		public NetSerializer()
		{
		}

		public NetSerializer(int maxStringLength)
		{
		}

		private ClassInfo<T> RegisterInternal<T>()
		{
			return null;
		}

		public void Register<T>()
		{
		}

		public T Deserialize<T>(NetDataReader reader) where T : class, new()
		{
			return null;
		}

		public bool Deserialize<T>(NetDataReader reader, T target) where T : class, new()
		{
			return false;
		}

		public void Serialize<T>(NetDataWriter writer, T obj) where T : class, new()
		{
		}

		public byte[] Serialize<T>(T obj) where T : class, new()
		{
			return null;
		}
	}
}
