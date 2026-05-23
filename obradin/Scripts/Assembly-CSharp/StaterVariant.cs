using UnityEngine;

public struct StaterVariant
{
	public Vector4 val;

	public float f
	{
		get
		{
			return val.x;
		}
		set
		{
			val.x = value;
		}
	}

	public StaterVariant(Vector4 val_)
	{
		val = val_;
	}

	public static implicit operator StaterVariant(float v)
	{
		return new StaterVariant(new Vector4(v, 0f, 0f, 0f));
	}

	public static implicit operator StaterVariant(Vector4 v)
	{
		return new StaterVariant(v);
	}

	public static implicit operator float(StaterVariant v)
	{
		return v.val.x;
	}

	public static implicit operator Vector4(StaterVariant v)
	{
		return v.val;
	}

	public static StaterVariant Lerp(StaterVariant a, StaterVariant b, float t)
	{
		return new StaterVariant(Vector4.Lerp(a.val, b.val, t));
	}

	public override string ToString()
	{
		return val.ToString();
	}
}
