using haxe.lang;

namespace app.vis
{
	public class FontLetter : HxObject
	{
		public int charCode;

		public string charLetter;

		public int pageIndex;

		public Rect rect;

		public PointData offset;

		public int advanceX;

		public FontLetter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FontLetter(int charCode, string charLetter, int pageIndex, Rect rect, PointData offset, int advanceX)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_FontLetter(FontLetter __hx_this, int charCode, string charLetter, int pageIndex, Rect rect, PointData offset, int advanceX)
		{
		}

		public virtual string toString()
		{
			return null;
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
