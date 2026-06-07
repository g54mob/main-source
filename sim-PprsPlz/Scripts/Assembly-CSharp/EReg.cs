using System.Text.RegularExpressions;
using haxe.lang;

public sealed class EReg : HxObject
{
	public Regex regex;

	public Match m;

	public bool isGlobal;

	public string cur;

	public EReg(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public EReg(string r, string opt)
		: base(default(EmptyObject))
	{
	}

	private static void __hx_ctor__EReg(EReg __hx_this, string r, string opt)
	{
	}

	public static string escape(string s)
	{
		return null;
	}

	public bool match(string s)
	{
		return false;
	}

	public string matched(int n)
	{
		return null;
	}

	public string matchedLeft()
	{
		return null;
	}

	public string matchedRight()
	{
		return null;
	}

	public object matchedPos()
	{
		return null;
	}

	public bool matchSub(string s, int pos, object len)
	{
		return false;
	}

	public Array split(string s)
	{
		return null;
	}

	public int start(int group)
	{
		return 0;
	}

	public int len(int group)
	{
		return 0;
	}

	public string replace(string s, string by)
	{
		return null;
	}

	public string map(string s, Function f)
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
}
