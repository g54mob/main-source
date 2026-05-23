using System;
using haxe.lang;

public class ValueType : haxe.lang.Enum
{
	public static readonly ValueType TNull;

	public static readonly ValueType TInt;

	public static readonly ValueType TFloat;

	public static readonly ValueType TBool;

	public static readonly ValueType TObject;

	public static readonly ValueType TFunction;

	public static readonly ValueType TUnknown;

	protected static readonly string[] __hx_constructs;

	protected ValueType(int index)
		: base(0)
	{
	}

	public static ValueType TClass(System.Type c)
	{
		return null;
	}

	public static ValueType TEnum(System.Type e)
	{
		return null;
	}
}
