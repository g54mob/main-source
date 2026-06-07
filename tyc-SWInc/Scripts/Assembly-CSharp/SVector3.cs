using System;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public class SVector3
{
	public float x;

	public float y;

	public float z;

	public float w;

	public static SVector3 Zero = new SVector3(0f, 0f, 0f);

	public static SVector3 One = new SVector3(1f, 1f, 1f, 1f);

	public static SVector3 Black = new SVector3(0f, 0f, 0f, 1f);

	public const float DefaultSecondaryColorFactor = 0.5f;

	public SVector3()
	{
	}

	public SVector3(float X, float Y, float Z, float W = 0f)
	{
		x = X;
		y = Y;
		z = Z;
		w = W;
	}

	protected bool Equals(SVector3 other)
	{
		if (x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z))
		{
			return w.Equals(other.w);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((SVector3)obj);
	}

	public override int GetHashCode()
	{
		return (((-1743314642 * -1521134295 + x.GetHashCode()) * -1521134295 + y.GetHashCode()) * -1521134295 + z.GetHashCode()) * -1521134295 + w.GetHashCode();
	}

	public SVector3 GetDefaultSecondaryColor()
	{
		return new SVector3(x * 0.5f, y * 0.5f, z * 0.5f, w);
	}

	public static SVector3 operator *(SVector3 v, float m)
	{
		return new SVector3(v.x * m, v.y * m, v.z * m, v.w * m);
	}

	public static implicit operator SVector3(Rect v)
	{
		return new SVector3(v.x, v.y, v.width, v.height);
	}

	public static implicit operator SVector3(Vector3 v)
	{
		return new SVector3(v.x, v.y, v.z);
	}

	public static implicit operator SVector3(Vector4 v)
	{
		return new SVector3(v.x, v.y, v.z, v.w);
	}

	public static implicit operator SVector3(Quaternion q)
	{
		return new SVector3(q.x, q.y, q.z, q.w);
	}

	public static implicit operator SVector3(Color c)
	{
		return new SVector3(c.r, c.g, c.b, c.a);
	}

	public static implicit operator SVector3(Color32 c)
	{
		return new SVector3((float)(int)c.r / 255f, (float)(int)c.g / 255f, (float)(int)c.b / 255f, (float)(int)c.a / 255f);
	}

	public static implicit operator SVector3(Vector2 c)
	{
		return new SVector3(c.x, c.y, 0f);
	}

	public static implicit operator Rect(SVector3 c)
	{
		return new Rect(c.x, c.y, c.z, c.w);
	}

	public static implicit operator Vector2(SVector3 c)
	{
		return new Vector2(c.x, c.y);
	}

	public static implicit operator Vector3(SVector3 v)
	{
		return new Vector3(v.x, v.y, v.z);
	}

	public static implicit operator Vector4(SVector3 v)
	{
		return new Vector4(v.x, v.y, v.z, v.w);
	}

	public static implicit operator Quaternion(SVector3 q)
	{
		return new Quaternion(q.x, q.y, q.z, q.w);
	}

	public static implicit operator Color(SVector3 q)
	{
		return new Color(q.x, q.y, q.z, q.w);
	}

	public Quaternion ToQuaternion()
	{
		return new Quaternion(x, y, z, w);
	}

	public Color ToColor()
	{
		return new Color(x, y, z, w);
	}

	public Color32 ToColor32()
	{
		return new Color32((byte)Mathf.Clamp(Mathf.RoundToInt(x * 255f), 0, 255), (byte)Mathf.Clamp(Mathf.RoundToInt(y * 255f), 0, 255), (byte)Mathf.Clamp(Mathf.RoundToInt(z * 255f), 0, 255), (byte)Mathf.Clamp(Mathf.RoundToInt(w * 255f), 0, 255));
	}

	public Rect ToRect()
	{
		return new Rect(x, y, w, z);
	}

	public Vector2 ToVector2()
	{
		return new Vector2(x, y);
	}

	public Vector2 ToVector2Z()
	{
		return new Vector2(x, z);
	}

	public Vector3 ToVector3()
	{
		return new Vector3(x, y, z);
	}

	public Vector4 ToVector4()
	{
		return new Vector4(x, y, z, w);
	}

	public SVector3 Swizzle(float val, int comp)
	{
		switch (comp)
		{
		case 0:
			return new SVector3(val, y, z, w);
		case 1:
			return new SVector3(x, val, z, w);
		case 2:
			return new SVector3(x, y, val, w);
		case 3:
			return new SVector3(x, y, z, val);
		default:
			throw new Exception("Wrong component for vector swizzle: " + comp);
		}
	}

	public string Serialize(int components = 4)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		switch (components)
		{
		case 1:
			return x.ToString(invariantCulture);
		case 2:
			return string.Format("{0},{1}", x.ToString(invariantCulture), y.ToString(invariantCulture));
		case 3:
			return string.Format("{0},{1},{2}", x.ToString(invariantCulture), y.ToString(invariantCulture), z.ToString(invariantCulture));
		case 4:
			return string.Format("{0},{1},{2},{3}", x.ToString(invariantCulture), y.ToString(invariantCulture), z.ToString(invariantCulture), w.ToString(invariantCulture));
		default:
			throw new Exception("Wrong number of components for vector serialization: " + components);
		}
	}

	public static SVector3 Deserialize(string input, bool throwEx = false)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		string[] array = input.Split(',');
		float[] array2 = new float[4];
		for (int i = 0; i < Mathf.Min(array.Length, 4); i++)
		{
			if (throwEx)
			{
				array2[i] = (float)Convert.ToDouble(array[i], invariantCulture);
				continue;
			}
			try
			{
				array2[i] = (float)Convert.ToDouble(array[i], invariantCulture);
			}
			catch (Exception)
			{
				break;
			}
		}
		return new SVector3(array2[0], array2[1], array2[2], array2[3]);
	}

	public override string ToString()
	{
		return x + "," + y + "," + z + "," + w;
	}

	public bool IsZero()
	{
		if (Mathf.Approximately(x, 0f) && Mathf.Approximately(y, 0f) && Mathf.Approximately(z, 0f))
		{
			return Mathf.Approximately(w, 0f);
		}
		return false;
	}

	public SVector3 ZeroNaN()
	{
		if (float.IsNaN(x))
		{
			x = 0f;
		}
		if (float.IsNaN(y))
		{
			y = 0f;
		}
		if (float.IsNaN(z))
		{
			z = 0f;
		}
		if (float.IsNaN(w))
		{
			w = 0f;
		}
		return this;
	}

	public SVector3(string txt)
	{
		float[] array = txt.Split(',').SelectInPlace((string k) => (float)Convert.ToDouble(k));
		x = array[0];
		y = array[1];
		z = array[2];
		w = array[3];
	}

	public static bool MatchColor(SVector3 c1, Color c2, bool def = true)
	{
		if (c1 == null)
		{
			return def;
		}
		if (c1.x.Appx(c2.r) && c1.y.Appx(c2.g))
		{
			return c1.z.Appx(c2.b);
		}
		return false;
	}

	public static bool MatchColor(SVector3 c1, SVector3 c2, bool def = true)
	{
		if (c1 == null)
		{
			if (c2 == null)
			{
				return true;
			}
			return def;
		}
		if (c2 == null)
		{
			return def;
		}
		if (c1.x.Appx(c2.x) && c1.y.Appx(c2.y))
		{
			return c1.z.Appx(c2.z);
		}
		return false;
	}
}
