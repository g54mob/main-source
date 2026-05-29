using System;
using UnityEngine;

namespace ExitGames.Client.Photon.StructWrapping
{
	public abstract class StructWrapper : IDisposable
	{
		public readonly WrappedType wrappedType;

		public readonly Type ttype;

		public StructWrapper(Type ttype, WrappedType wrappedType)
		{
		}

		public abstract object Box();

		public abstract void DisconnectFromPool();

		public abstract void Dispose();

		public abstract string ToString(bool writeType);

		public static implicit operator StructWrapper(bool value)
		{
			return null;
		}

		public static implicit operator StructWrapper(byte value)
		{
			return null;
		}

		public static implicit operator StructWrapper(float value)
		{
			return null;
		}

		public static implicit operator StructWrapper(double value)
		{
			return null;
		}

		public static implicit operator StructWrapper(short value)
		{
			return null;
		}

		public static implicit operator StructWrapper(int value)
		{
			return null;
		}

		public static implicit operator StructWrapper(long value)
		{
			return null;
		}

		public static implicit operator bool(StructWrapper wrapper)
		{
			return false;
		}

		public static implicit operator byte(StructWrapper wrapper)
		{
			return 0;
		}

		public static implicit operator float(StructWrapper wrapper)
		{
			return 0f;
		}

		public static implicit operator double(StructWrapper wrapper)
		{
			return 0.0;
		}

		public static implicit operator short(StructWrapper wrapper)
		{
			return 0;
		}

		public static implicit operator int(StructWrapper wrapper)
		{
			return 0;
		}

		public static implicit operator long(StructWrapper wrapper)
		{
			return 0L;
		}

		public static implicit operator StructWrapper(Vector2 value)
		{
			return null;
		}

		public static implicit operator StructWrapper(Vector3 value)
		{
			return null;
		}

		public static implicit operator StructWrapper(Quaternion value)
		{
			return null;
		}

		public static implicit operator Vector2(StructWrapper wrapper)
		{
			return default(Vector2);
		}

		public static implicit operator Vector3(StructWrapper wrapper)
		{
			return default(Vector3);
		}

		public static implicit operator Quaternion(StructWrapper wrapper)
		{
			return default(Quaternion);
		}
	}
	public class StructWrapper<T> : StructWrapper
	{
		internal Pooling pooling;

		internal T value;

		internal static StructWrapperPool<T> staticPool;

		public StructWrapperPool<T> ReturnPool { get; internal set; }

		public StructWrapper(Pooling releasing)
			: base(null, default(WrappedType))
		{
		}

		public StructWrapper(Pooling releasing, Type tType, WrappedType wType)
			: base(null, default(WrappedType))
		{
		}

		public StructWrapper<T> Poke(byte value)
		{
			return null;
		}

		public StructWrapper<T> Poke(bool value)
		{
			return null;
		}

		public StructWrapper<T> Poke(T value)
		{
			return null;
		}

		public T Unwrap()
		{
			return default(T);
		}

		public T Peek()
		{
			return default(T);
		}

		public override object Box()
		{
			return null;
		}

		public override void Dispose()
		{
		}

		public override void DisconnectFromPool()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override string ToString(bool writeTypeInfo)
		{
			return null;
		}

		public static implicit operator StructWrapper<T>(T value)
		{
			return null;
		}
	}
}
