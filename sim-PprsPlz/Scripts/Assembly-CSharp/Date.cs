using System;
using haxe.lang;

public class Date : HxObject
{
	public static readonly long epochTicks;

	public DateTime date;

	public DateTime dateUTC;

	public Date(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Date(DateTime native)
		: base(default(EmptyObject))
	{
	}

	public Date(int year, int month, int day, int hour, int min, int sec)
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Date(Date __hx_this, DateTime native)
	{
	}

	protected static void __hx_ctor__Date(Date __hx_this, int year, int month, int day, int hour, int min, int sec)
	{
	}

	public static Date now()
	{
		return null;
	}

	public static Date fromTime(double t)
	{
		return null;
	}

	public static Date fromString(string s)
	{
		return null;
	}

	public static Date fromNative(DateTime d)
	{
		return null;
	}

	public double getTime()
	{
		return 0.0;
	}

	public int getHours()
	{
		return 0;
	}

	public int getMinutes()
	{
		return 0;
	}

	public int getSeconds()
	{
		return 0;
	}

	public int getFullYear()
	{
		return 0;
	}

	public int getMonth()
	{
		return 0;
	}

	public int getDate()
	{
		return 0;
	}

	public int getDay()
	{
		return 0;
	}

	public int getUTCHours()
	{
		return 0;
	}

	public int getUTCMinutes()
	{
		return 0;
	}

	public int getUTCSeconds()
	{
		return 0;
	}

	public int getUTCFullYear()
	{
		return 0;
	}

	public int getUTCMonth()
	{
		return 0;
	}

	public int getUTCDate()
	{
		return 0;
	}

	public int getUTCDay()
	{
		return 0;
	}

	public int getTimezoneOffset()
	{
		return 0;
	}

	public virtual string toString()
	{
		return null;
	}

	public override object __hx_setField(string field, int hash, object value, bool handleProperties)
	{
		return null;
	}

	public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
	{
		return null;
	}

	public override object __hx_invokeField(string field, int hash, object[] dynargs)
	{
		return null;
	}

	public override void __hx_getFields(Array baseArr)
	{
	}

	public override string ToString()
	{
		return null;
	}
}
