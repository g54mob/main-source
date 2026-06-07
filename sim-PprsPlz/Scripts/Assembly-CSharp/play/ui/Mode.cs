using app.vis;
using haxe.ds;
using haxe.lang;

namespace play.ui
{
	public class Mode : HxObject
	{
		public string name;

		public string text;

		public uint textNormalColor;

		public uint textPressingColor;

		public app.vis.Align textAlign;

		public PartData normalImagePart;

		public PartData pressingImagePart;

		public List overlays;

		public Button button;

		public Mode(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Mode(Button button_, string name_, PartData normalImagePart_, PartData pressingImagePart_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_Mode(Mode __hx_this, Button button_, string name_, PartData normalImagePart_, PartData pressingImagePart_)
		{
		}

		public bool get_hasText()
		{
			return false;
		}

		public virtual Mode setText(string text_)
		{
			return null;
		}

		public virtual Mode setTextNormalColor(uint textNormalColor_)
		{
			return null;
		}

		public virtual Mode setTextPressingColor(uint textPressingColor_)
		{
			return null;
		}

		public virtual Mode setTextAlign(app.vis.Align textAlign_)
		{
			return null;
		}

		public virtual Mode addOverlay(Visual overlay)
		{
			return null;
		}

		public virtual Mode apply()
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
	}
}
