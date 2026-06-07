using haxe.lang;

public class Trace : HxObject
{
	public static bool enabled;

	public static bool showVerbose;

	public static Function redirect;

	static Trace()
	{
	}

	public Trace(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Trace()
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Trace(Trace __hx_this)
	{
	}

	public static void init(Function redirect_, object enabled_)
	{
	}

	public static void info(object value, object pos)
	{
	}

	public static void verbose(object value, object pos)
	{
	}

	public static void error(object value, object pos)
	{
	}

	public static void callstack(object value, object pos)
	{
	}

	public static void always(object value, object pos)
	{
	}

	public static string shortClassName(string className)
	{
		return null;
	}

	public static void customPrint(object value, object pos)
	{
	}
}
