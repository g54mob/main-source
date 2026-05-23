using haxe.iterators;
using haxe.lang;

public class StringTools : HxObject
{
	public static Array winMetaCharacters;

	public static int MIN_SURROGATE_CODE_POINT;

	static StringTools()
	{
	}

	public StringTools(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public StringTools()
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__StringTools(StringTools __hx_this)
	{
	}

	public static string urlEncode(string s)
	{
		return null;
	}

	public static string urlDecode(string s)
	{
		return null;
	}

	public static string htmlEscape(string s, object quotes)
	{
		return null;
	}

	public static string htmlUnescape(string s)
	{
		return null;
	}

	public static bool contains(string s, string value)
	{
		return false;
	}

	public static bool startsWith(string s, string start)
	{
		return false;
	}

	public static bool endsWith(string s, string end)
	{
		return false;
	}

	public static bool isSpace(string s, int pos)
	{
		return false;
	}

	public static string ltrim(string s)
	{
		return null;
	}

	public static string rtrim(string s)
	{
		return null;
	}

	public static string trim(string s)
	{
		return null;
	}

	public static string lpad(string s, string c, int l)
	{
		return null;
	}

	public static string rpad(string s, string c, int l)
	{
		return null;
	}

	public static string replace(string s, string sub, string by)
	{
		return null;
	}

	public static string hex(int n, object digits)
	{
		return null;
	}

	public static int fastCodeAt(string s, int index)
	{
		return 0;
	}

	public static int unsafeCodeAt(string s, int index)
	{
		return 0;
	}

	public static StringIterator iterator(string s)
	{
		return null;
	}

	public static StringKeyValueIterator keyValueIterator(string s)
	{
		return null;
	}

	public static bool isEof(int c)
	{
		return false;
	}

	public static string quoteUnixArg(string argument)
	{
		return null;
	}

	public static string quoteWinArg(string argument, bool escapeMetaCharacters)
	{
		return null;
	}

	public static int utf16CodePointAt(string s, int index)
	{
		return 0;
	}
}
