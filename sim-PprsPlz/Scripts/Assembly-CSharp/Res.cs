using app.plat;
using app.vis;
using data;
using data.loc;
using haxe.ds;
using haxe.io;
using haxe.lang;

public class Res : HxObject
{
	public static Array builtinLangCodes;

	public Pack locPack;

	public string loadedLanguageCode;

	public PlatformDisk platformDisk;

	public StringMap defaultAssets;

	public StringMap localizedAssets;

	public Mogrifier mogrifier;

	static Res()
	{
	}

	public Res(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Res(PlatformDisk platformDisk_, string overrideDir, Mogrifier mogrifier_)
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Res(Res __hx_this, PlatformDisk platformDisk_, string overrideDir, Mogrifier mogrifier_)
	{
	}

	public static Asset toAsset(string filename, Bytes bytes, Mogrifier mogrifier)
	{
		return null;
	}

	public virtual void loadLanguage(string languageCode, object fallbackToEn)
	{
	}

	public virtual Asset getAsset(string filename)
	{
		return null;
	}

	public virtual string getText(string filename)
	{
		return null;
	}

	public virtual Image getImage(string filename)
	{
		return null;
	}

	public virtual Xml getXml(string filename)
	{
		return null;
	}

	public virtual CsvTable getCsvTable(string filename)
	{
		return null;
	}

	public virtual TabParser getTabParser(string filename)
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
