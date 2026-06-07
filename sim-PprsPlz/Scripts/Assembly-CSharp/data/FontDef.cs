using app.vis;
using haxe.lang;

namespace data
{
	public class FontDef : HxObject
	{
		public string id;

		public Font font;

		public int lineHeight;

		public string name;

		public FontDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FontDef(Res res, Xml node, Lang lang)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FontDef(FontDef __hx_this, Res res, Xml node, Lang lang)
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
}
