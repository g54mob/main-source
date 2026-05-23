using app.plat;
using app.vis;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class Mogrifier : HxObject
	{
		public StringMap processAfterLoadImages;

		public Mogrifier(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Mogrifier()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Mogrifier(Mogrifier __hx_this)
		{
		}

		public static Mogrifier makeForPlatform(PlatformKind platformKind)
		{
			return null;
		}

		public virtual Image mogrifyImage(string assetPath, Image image)
		{
			return null;
		}

		public virtual void mogrifyXml(string assetPath, Xml xml)
		{
		}

		public virtual void processAfterLoad(Res res)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
