using System;
using haxe.lang;

public class Reflect : HxObject
{
	public Reflect(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Reflect()
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Reflect(Reflect __hx_this)
	{
	}

	public static bool hasField(object o, string field)
	{
		return false;
	}

	public static object field(object o, string field)
	{
		return null;
	}

	public static void setField(object o, string field, object value)
	{
	}

	public static object getProperty(object o, string field)
	{
		return null;
	}

	public static void setProperty(object o, string field, object value)
	{
	}

	public static object callMethod(object o, object func, Array args)
	{
		return null;
	}

	public static Array fields(object o)
	{
		return null;
	}

	public static Array instanceFields(System.Type c)
	{
		return null;
	}

	public static bool isFunction(object f)
	{
		return false;
	}

	public static int compare(object a, object b)
	{
		return 0;
	}

	public static bool compareMethods(object f1, object f2)
	{
		return false;
	}

	public static bool isObject(object v)
	{
		return false;
	}

	public static bool isEnumValue(object v)
	{
		return false;
	}

	public static bool deleteField(object o, string field)
	{
		return false;
	}

	public static object copy(object o)
	{
		return null;
	}

	public static object makeVarArgs(Function f)
	{
		return null;
	}
}
