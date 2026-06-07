using haxe.lang;
using play;

public class ScreenChange : HxObject
{
	public string screenName;

	public GameTransitionKind gameTransitionKind;

	public ScreenChange(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public ScreenChange(string screenName, GameTransitionKind gameTransitionKind)
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__ScreenChange(ScreenChange __hx_this, string screenName, GameTransitionKind gameTransitionKind)
	{
	}

	public override object __hx_setField(string field, int hash, object value, bool handleProperties)
	{
		return null;
	}

	public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
	{
		return null;
	}

	public override void __hx_getFields(Array baseArr)
	{
	}
}
