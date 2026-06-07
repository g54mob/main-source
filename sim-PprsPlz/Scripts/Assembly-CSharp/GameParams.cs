using app;
using app.plat;
using haxe.lang;

public class GameParams : HxObject
{
	public Platform platform;

	public CommandLine commandLine;

	public object randomSeed;

	public bool restoreFromStashIfPossible;

	public bool allowPhoneTabletPlatformChange;

	public GameParams(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public GameParams(Platform platform_, CommandLine commandLine_, object randomSeed_, object restoreFromStashIfPossible_, object allowPhoneTabletPlatformChange_)
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__GameParams(GameParams __hx_this, Platform platform_, CommandLine commandLine_, object randomSeed_, object restoreFromStashIfPossible_, object allowPhoneTabletPlatformChange_)
	{
	}

	public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
	{
		return 0.0;
	}

	public override object __hx_setField(string field, int hash, object value, bool handleProperties)
	{
		return null;
	}

	public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
	{
		return null;
	}

	public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
	{
		return 0.0;
	}

	public override void __hx_getFields(Array baseArr)
	{
	}
}
