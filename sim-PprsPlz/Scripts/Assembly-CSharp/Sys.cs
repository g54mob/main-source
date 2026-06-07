using haxe.ds;
using haxe.io;
using haxe.lang;

public class Sys : HxObject
{
	public static StringMap _env;

	public static Array _args;

	public static readonly long epochTicks;

	public Sys(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Sys()
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Sys(Sys __hx_this)
	{
	}

	public static void print(object v)
	{
	}

	public static void println(object v)
	{
	}

	public static Array args()
	{
		return null;
	}

	public static string getEnv(string s)
	{
		return null;
	}

	public static void putEnv(string s, string v)
	{
	}

	public static StringMap environment()
	{
		return null;
	}

	public static void sleep(double seconds)
	{
	}

	public static bool setTimeLocale(string loc)
	{
		return false;
	}

	public static string getCwd()
	{
		return null;
	}

	public static void setCwd(string s)
	{
	}

	public static string systemName()
	{
		return null;
	}

	public static int command(string cmd, Array args)
	{
		return 0;
	}

	public static void exit(int code)
	{
	}

	public static double time()
	{
		return 0.0;
	}

	public static double cpuTime()
	{
		return 0.0;
	}

	public static string executablePath()
	{
		return null;
	}

	public static string programPath()
	{
		return null;
	}

	public static int getChar(bool echo)
	{
		return 0;
	}

	public static Input stdin()
	{
		return null;
	}

	public static Output stdout()
	{
		return null;
	}

	public static Output stderr()
	{
		return null;
	}
}
