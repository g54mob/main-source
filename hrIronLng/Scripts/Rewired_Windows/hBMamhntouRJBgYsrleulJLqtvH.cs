using System;
using System.Globalization;

internal struct hBMamhntouRJBgYsrleulJLqtvH
{
	private IntPtr KxoaQduWpmsRutbbJilXLlDiBUs;

	public static readonly hBMamhntouRJBgYsrleulJLqtvH mlHwKYEqjUXizzlBBRzwZZoggsm = new hBMamhntouRJBgYsrleulJLqtvH(0);

	public hBMamhntouRJBgYsrleulJLqtvH(IntPtr size)
	{
		KxoaQduWpmsRutbbJilXLlDiBUs = size;
	}

	private unsafe hBMamhntouRJBgYsrleulJLqtvH(void* size)
	{
		KxoaQduWpmsRutbbJilXLlDiBUs = new IntPtr(size);
	}

	public hBMamhntouRJBgYsrleulJLqtvH(int size)
	{
		KxoaQduWpmsRutbbJilXLlDiBUs = new IntPtr(size);
	}

	public hBMamhntouRJBgYsrleulJLqtvH(long size)
	{
		KxoaQduWpmsRutbbJilXLlDiBUs = new IntPtr(size);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { KxoaQduWpmsRutbbJilXLlDiBUs });
	}

	public string jbeeBfpyRHgFdsemtguxfVuwPCaA(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { KxoaQduWpmsRutbbJilXLlDiBUs.ToString(P_0) });
	}

	public override int GetHashCode()
	{
		return KxoaQduWpmsRutbbJilXLlDiBUs.ToInt32();
	}

	public bool sDUAvZTXlEIwugPidIgHPcnkQFr(hBMamhntouRJBgYsrleulJLqtvH P_0)
	{
		return KxoaQduWpmsRutbbJilXLlDiBUs == P_0.KxoaQduWpmsRutbbJilXLlDiBUs;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(hBMamhntouRJBgYsrleulJLqtvH)))
		{
			return false;
		}
		return sDUAvZTXlEIwugPidIgHPcnkQFr((hBMamhntouRJBgYsrleulJLqtvH)value);
	}

	public static hBMamhntouRJBgYsrleulJLqtvH operator +(hBMamhntouRJBgYsrleulJLqtvH left, hBMamhntouRJBgYsrleulJLqtvH right)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(left.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64() + right.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64());
	}

	public static hBMamhntouRJBgYsrleulJLqtvH operator +(hBMamhntouRJBgYsrleulJLqtvH value)
	{
		return value;
	}

	public static hBMamhntouRJBgYsrleulJLqtvH operator -(hBMamhntouRJBgYsrleulJLqtvH left, hBMamhntouRJBgYsrleulJLqtvH right)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(left.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64() - right.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64());
	}

	public static hBMamhntouRJBgYsrleulJLqtvH operator -(hBMamhntouRJBgYsrleulJLqtvH value)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(-value.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64());
	}

	public static hBMamhntouRJBgYsrleulJLqtvH operator *(int scale, hBMamhntouRJBgYsrleulJLqtvH value)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(scale * value.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64());
	}

	public static hBMamhntouRJBgYsrleulJLqtvH operator *(hBMamhntouRJBgYsrleulJLqtvH value, int scale)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(scale * value.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64());
	}

	public static hBMamhntouRJBgYsrleulJLqtvH operator /(hBMamhntouRJBgYsrleulJLqtvH value, int scale)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(value.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64() / scale);
	}

	public static bool operator ==(hBMamhntouRJBgYsrleulJLqtvH left, hBMamhntouRJBgYsrleulJLqtvH right)
	{
		return left.sDUAvZTXlEIwugPidIgHPcnkQFr(right);
	}

	public static bool operator !=(hBMamhntouRJBgYsrleulJLqtvH left, hBMamhntouRJBgYsrleulJLqtvH right)
	{
		return !left.sDUAvZTXlEIwugPidIgHPcnkQFr(right);
	}

	public static implicit operator int(hBMamhntouRJBgYsrleulJLqtvH value)
	{
		return value.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt32();
	}

	public static implicit operator long(hBMamhntouRJBgYsrleulJLqtvH value)
	{
		return value.KxoaQduWpmsRutbbJilXLlDiBUs.ToInt64();
	}

	public static implicit operator hBMamhntouRJBgYsrleulJLqtvH(int value)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(value);
	}

	public static implicit operator hBMamhntouRJBgYsrleulJLqtvH(long value)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(value);
	}

	public static implicit operator hBMamhntouRJBgYsrleulJLqtvH(IntPtr value)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(value);
	}

	public static implicit operator IntPtr(hBMamhntouRJBgYsrleulJLqtvH value)
	{
		return value.KxoaQduWpmsRutbbJilXLlDiBUs;
	}

	public unsafe static implicit operator hBMamhntouRJBgYsrleulJLqtvH(void* value)
	{
		return new hBMamhntouRJBgYsrleulJLqtvH(value);
	}

	public unsafe static implicit operator void*(hBMamhntouRJBgYsrleulJLqtvH value)
	{
		return (void*)value.KxoaQduWpmsRutbbJilXLlDiBUs;
	}
}
