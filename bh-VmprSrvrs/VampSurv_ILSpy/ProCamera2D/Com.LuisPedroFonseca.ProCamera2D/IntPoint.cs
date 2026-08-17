using System;
using System.Runtime.CompilerServices;

namespace Com.LuisPedroFonseca.ProCamera2D;

internal struct IntPoint(int x, int y) : IEquatable<IntPoint>
{
	public static IntPoint MaxValue;

	public int X = x;

	public int Y = y;

	public bool IsEqual(IntPoint other)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if ((nint)other != X)
		{
			return false;
		}
		object obj = (object)other >> 32;
		object obj2 = obj - Y;
		return obj2 == null;
	}

	public unsafe override string ToString()
	{
		//IL_0046: Expected O, but got Ref
		string text = ((int)this).ToString();
		int num = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 4));
		string text2 = ((int*)num)->ToString();
		string text3 = "X: " + text + " - Y: " + text2;
		object[] array = Array.Empty<object>();
		if (array != null)
		{
			System.ParamsArray paramsArray = new System.ParamsArray(array);
			object obj = default(object);
			return string.FormatHelper((IFormatProvider)null, text3, (System.ParamsArray)(&obj));
		}
		bool flag = text3 == null;
		string paramName = "format";
		if (!flag)
		{
			paramName = "args";
		}
		ArgumentNullException ex = new ArgumentNullException(paramName);
		ex._002Ector(paramName);
		throw ex;
	}

	public bool Equals(IntPoint other)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if ((nint)other != X)
		{
			return false;
		}
		object obj = (object)other >> 32;
		object obj2 = obj - Y;
		return obj2 == null;
	}

	public override int GetHashCode()
	{
		//IL_0010: Expected O, but got I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected I4, but got Unknown
		object obj = X * 397;
		return obj ^ Y;
	}

	static IntPoint()
	{
		//IL_000f: Expected O, but got I4
		MaxValue = (IntPoint)2147483647;
	}
}
