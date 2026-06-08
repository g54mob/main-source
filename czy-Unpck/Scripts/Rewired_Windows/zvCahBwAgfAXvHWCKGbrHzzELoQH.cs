using System;
using System.Globalization;

internal struct zvCahBwAgfAXvHWCKGbrHzzELoQH
{
	private IntPtr IDaaDPtlfdwgEHSPiaoMeHlZYNdP;

	public static readonly zvCahBwAgfAXvHWCKGbrHzzELoQH efXYRwJzdNWmZXhhkhunVKEPjxba = new zvCahBwAgfAXvHWCKGbrHzzELoQH(0);

	public zvCahBwAgfAXvHWCKGbrHzzELoQH(IntPtr size)
	{
		IDaaDPtlfdwgEHSPiaoMeHlZYNdP = size;
	}

	private unsafe zvCahBwAgfAXvHWCKGbrHzzELoQH(void* size)
	{
		IDaaDPtlfdwgEHSPiaoMeHlZYNdP = new IntPtr(size);
	}

	public zvCahBwAgfAXvHWCKGbrHzzELoQH(int size)
	{
		IDaaDPtlfdwgEHSPiaoMeHlZYNdP = new IntPtr(size);
	}

	public zvCahBwAgfAXvHWCKGbrHzzELoQH(long size)
	{
		IDaaDPtlfdwgEHSPiaoMeHlZYNdP = new IntPtr(size);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { IDaaDPtlfdwgEHSPiaoMeHlZYNdP });
	}

	public string xTkYeHqBZWJlRSAWGtjqDfOHERd(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToString(P_0) });
	}

	public override int GetHashCode()
	{
		return IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt32();
	}

	public bool uxGAirIytVqwSOxUUxSKDfDVCZe(zvCahBwAgfAXvHWCKGbrHzzELoQH P_0)
	{
		return IDaaDPtlfdwgEHSPiaoMeHlZYNdP == P_0.IDaaDPtlfdwgEHSPiaoMeHlZYNdP;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(zvCahBwAgfAXvHWCKGbrHzzELoQH)))
		{
			return false;
		}
		return uxGAirIytVqwSOxUUxSKDfDVCZe((zvCahBwAgfAXvHWCKGbrHzzELoQH)value);
	}

	public static zvCahBwAgfAXvHWCKGbrHzzELoQH operator +(zvCahBwAgfAXvHWCKGbrHzzELoQH left, zvCahBwAgfAXvHWCKGbrHzzELoQH right)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(left.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64() + right.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64());
	}

	public static zvCahBwAgfAXvHWCKGbrHzzELoQH operator +(zvCahBwAgfAXvHWCKGbrHzzELoQH value)
	{
		return value;
	}

	public static zvCahBwAgfAXvHWCKGbrHzzELoQH operator -(zvCahBwAgfAXvHWCKGbrHzzELoQH left, zvCahBwAgfAXvHWCKGbrHzzELoQH right)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(left.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64() - right.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64());
	}

	public static zvCahBwAgfAXvHWCKGbrHzzELoQH operator -(zvCahBwAgfAXvHWCKGbrHzzELoQH value)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(-value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64());
	}

	public static zvCahBwAgfAXvHWCKGbrHzzELoQH operator *(int scale, zvCahBwAgfAXvHWCKGbrHzzELoQH value)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(scale * value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64());
	}

	public static zvCahBwAgfAXvHWCKGbrHzzELoQH operator *(zvCahBwAgfAXvHWCKGbrHzzELoQH value, int scale)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(scale * value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64());
	}

	public static zvCahBwAgfAXvHWCKGbrHzzELoQH operator /(zvCahBwAgfAXvHWCKGbrHzzELoQH value, int scale)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64() / scale);
	}

	public static bool operator ==(zvCahBwAgfAXvHWCKGbrHzzELoQH left, zvCahBwAgfAXvHWCKGbrHzzELoQH right)
	{
		return left.uxGAirIytVqwSOxUUxSKDfDVCZe(right);
	}

	public static bool operator !=(zvCahBwAgfAXvHWCKGbrHzzELoQH left, zvCahBwAgfAXvHWCKGbrHzzELoQH right)
	{
		return !left.uxGAirIytVqwSOxUUxSKDfDVCZe(right);
	}

	public static implicit operator int(zvCahBwAgfAXvHWCKGbrHzzELoQH value)
	{
		return value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt32();
	}

	public static implicit operator long(zvCahBwAgfAXvHWCKGbrHzzELoQH value)
	{
		return value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP.ToInt64();
	}

	public static implicit operator zvCahBwAgfAXvHWCKGbrHzzELoQH(int value)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(value);
	}

	public static implicit operator zvCahBwAgfAXvHWCKGbrHzzELoQH(long value)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(value);
	}

	public static implicit operator zvCahBwAgfAXvHWCKGbrHzzELoQH(IntPtr value)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(value);
	}

	public static implicit operator IntPtr(zvCahBwAgfAXvHWCKGbrHzzELoQH value)
	{
		return value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP;
	}

	public unsafe static implicit operator zvCahBwAgfAXvHWCKGbrHzzELoQH(void* value)
	{
		return new zvCahBwAgfAXvHWCKGbrHzzELoQH(value);
	}

	public unsafe static implicit operator void*(zvCahBwAgfAXvHWCKGbrHzzELoQH value)
	{
		return (void*)value.IDaaDPtlfdwgEHSPiaoMeHlZYNdP;
	}
}
