using System;
using System.Runtime.CompilerServices;

namespace MagicaCloth2
{
	[Serializable]
	public struct VertexAttribute : IEquatable<VertexAttribute>
	{
		public const byte Flag_Fixed = 1;

		public const byte Flag_Move = 2;

		public const byte Flag_InvalidMotion = 8;

		public const byte Flag_DisableCollision = 16;

		public const byte Flag_ZeroDistance = 32;

		public const byte Flag_Triangle = 128;

		public static readonly VertexAttribute Invalid;

		public static readonly VertexAttribute Fixed;

		public static readonly VertexAttribute Move;

		public static readonly VertexAttribute DisableCollision;

		public byte Value;

		public VertexAttribute(byte initialValue = 0)
		{
			Value = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetFlag(byte flag, bool sw)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetFlag(VertexAttribute attr, bool sw)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsSet(byte flag)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsInvalid()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsFixed()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsMove()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsDontMove()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsMotion()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsDisableCollision()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static VertexAttribute JoinAttribute(VertexAttribute attr1, VertexAttribute attr2)
		{
			return default(VertexAttribute);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(VertexAttribute other)
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(VertexAttribute lhs, VertexAttribute rhs)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(VertexAttribute lhs, VertexAttribute rhs)
		{
			return false;
		}
	}
}
