using System;
using Coherence.Entities;
using UnityEngine;

namespace Coherence.Interpolation
{
	[Serializable]
	public class Interpolator : IInterpolator<float>, IInterpolator<double>, IInterpolator<bool>, IInterpolator<byte>, IInterpolator<sbyte>, IInterpolator<short>, IInterpolator<ushort>, IInterpolator<char>, IInterpolator<int>, IInterpolator<uint>, IInterpolator<long>, IInterpolator<ulong>, IInterpolator<Vector2>, IInterpolator<Vector3>, IInterpolator<Quaternion>, IInterpolator<Color>, IInterpolator<string>, IInterpolator<byte[]>, IInterpolator<Entity>
	{
		public virtual int NumberOfSamplesToStayBehind => 0;

		public virtual float InterpolateFloat(float value0, float value1, float value2, float value3, float t)
		{
			return 0f;
		}

		public virtual double InterpolateDouble(double value0, double value1, double value2, double value3, float t)
		{
			return 0.0;
		}

		public virtual bool InterpolateBoolean(bool value0, bool value1, bool value2, bool value3, float t)
		{
			return false;
		}

		public virtual byte InterpolateByte(byte value0, byte value1, byte value2, byte value3, float t)
		{
			return 0;
		}

		public virtual sbyte InterpolateSByte(sbyte value0, sbyte value1, sbyte value2, sbyte value3, float t)
		{
			return 0;
		}

		public virtual short InterpolateShort(short value0, short value1, short value2, short value3, float t)
		{
			return 0;
		}

		public virtual ushort InterpolateUShort(ushort value0, ushort value1, ushort value2, ushort value3, float t)
		{
			return 0;
		}

		public virtual char InterpolateChar(char value0, char value1, char value2, char value3, float t)
		{
			return '\0';
		}

		public virtual int InterpolateInt(int value0, int value1, int value2, int value3, float t)
		{
			return 0;
		}

		public virtual uint InterpolateUInt(uint value0, uint value1, uint value2, uint value3, float t)
		{
			return 0u;
		}

		public virtual long InterpolateLong(long value0, long value1, long value2, long value3, float t)
		{
			return 0L;
		}

		public virtual ulong InterpolateULong(ulong value0, ulong value1, ulong value2, ulong value3, float t)
		{
			return 0uL;
		}

		public virtual Vector2 InterpolateVector2(Vector2 value0, Vector2 value1, Vector2 value2, Vector2 value3, float t)
		{
			return default(Vector2);
		}

		public virtual Vector3 InterpolateVector3(Vector3 value0, Vector3 value1, Vector3 value2, Vector3 value3, float t)
		{
			return default(Vector3);
		}

		public virtual Quaternion InterpolateQuaternion(Quaternion value0, Quaternion value1, Quaternion value2, Quaternion value3, float t)
		{
			return default(Quaternion);
		}

		public virtual Color InterpolateColor(Color value0, Color value1, Color value2, Color value3, float t)
		{
			return default(Color);
		}

		public virtual string InterpolateString(string value0, string value1, string value2, string value3, float t)
		{
			return null;
		}

		public virtual byte[] InterpolateBytes(byte[] value0, byte[] value1, byte[] value2, byte[] value3, float t)
		{
			return null;
		}

		public virtual Entity InterpolateEntityReference(Entity value0, Entity value1, Entity value2, Entity value3, float t)
		{
			return default(Entity);
		}

		public virtual float InterpolateFloat(float value1, float value2, float t)
		{
			return 0f;
		}

		public virtual double InterpolateDouble(double value1, double value2, float t)
		{
			return 0.0;
		}

		public virtual bool InterpolateBoolean(bool value1, bool value2, float t)
		{
			return false;
		}

		public virtual byte InterpolateByte(byte value1, byte value2, float t)
		{
			return 0;
		}

		public virtual sbyte InterpolateSByte(sbyte value1, sbyte value2, float t)
		{
			return 0;
		}

		public virtual short InterpolateShort(short value1, short value2, float t)
		{
			return 0;
		}

		public virtual ushort InterpolateUShort(ushort value1, ushort value2, float t)
		{
			return 0;
		}

		public virtual char InterpolateChar(char value1, char value2, float t)
		{
			return '\0';
		}

		public virtual int InterpolateInt(int value1, int value2, float t)
		{
			return 0;
		}

		public virtual uint InterpolateUInt(uint value1, uint value2, float t)
		{
			return 0u;
		}

		public virtual long InterpolateLong(long value1, long value2, float t)
		{
			return 0L;
		}

		public virtual ulong InterpolateULong(ulong value1, ulong value2, float t)
		{
			return 0uL;
		}

		public virtual Vector2 InterpolateVector2(Vector2 value1, Vector2 value2, float t)
		{
			return default(Vector2);
		}

		public virtual Vector3 InterpolateVector3(Vector3 value1, Vector3 value2, float t)
		{
			return default(Vector3);
		}

		public virtual Quaternion InterpolateQuaternion(Quaternion value1, Quaternion value2, float t)
		{
			return default(Quaternion);
		}

		public virtual Color InterpolateColor(Color value1, Color value2, float t)
		{
			return default(Color);
		}

		public virtual string InterpolateString(string value1, string value2, float t)
		{
			return null;
		}

		public virtual byte[] InterpolateBytes(byte[] value1, byte[] value2, float t)
		{
			return null;
		}

		public virtual Entity InterpolateEntityReference(Entity value1, Entity value2, float t)
		{
			return default(Entity);
		}

		public float Interpolate(float value0, float value1, float value2, float value3, float t)
		{
			return 0f;
		}

		public double Interpolate(double value0, double value1, double value2, double value3, float t)
		{
			return 0.0;
		}

		public bool Interpolate(bool value0, bool value1, bool value2, bool value3, float t)
		{
			return false;
		}

		public byte Interpolate(byte value0, byte value1, byte value2, byte value3, float t)
		{
			return 0;
		}

		public sbyte Interpolate(sbyte value0, sbyte value1, sbyte value2, sbyte value3, float t)
		{
			return 0;
		}

		public short Interpolate(short value0, short value1, short value2, short value3, float t)
		{
			return 0;
		}

		public ushort Interpolate(ushort value0, ushort value1, ushort value2, ushort value3, float t)
		{
			return 0;
		}

		public char Interpolate(char value0, char value1, char value2, char value3, float t)
		{
			return '\0';
		}

		public int Interpolate(int value0, int value1, int value2, int value3, float t)
		{
			return 0;
		}

		public uint Interpolate(uint value0, uint value1, uint value2, uint value3, float t)
		{
			return 0u;
		}

		public long Interpolate(long value0, long value1, long value2, long value3, float t)
		{
			return 0L;
		}

		public ulong Interpolate(ulong value0, ulong value1, ulong value2, ulong value3, float t)
		{
			return 0uL;
		}

		public Vector2 Interpolate(Vector2 value0, Vector2 value1, Vector2 value2, Vector2 value3, float t)
		{
			return default(Vector2);
		}

		public Vector3 Interpolate(Vector3 value0, Vector3 value1, Vector3 value2, Vector3 value3, float t)
		{
			return default(Vector3);
		}

		public Quaternion Interpolate(Quaternion value0, Quaternion value1, Quaternion value2, Quaternion value3, float t)
		{
			return default(Quaternion);
		}

		public Color Interpolate(Color value0, Color value1, Color value2, Color value3, float t)
		{
			return default(Color);
		}

		public string Interpolate(string value0, string value1, string value2, string value3, float t)
		{
			return null;
		}

		public byte[] Interpolate(byte[] value0, byte[] value1, byte[] value2, byte[] value3, float t)
		{
			return null;
		}

		public Entity Interpolate(Entity value0, Entity value1, Entity value2, Entity value3, float t)
		{
			return default(Entity);
		}
	}
}
