using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class ButtonHelper : HxObject
	{
		public bool pressing;

		public Ent ent;

		public string pressSoundId;

		public string clickSoundId;

		public double marginL;

		public double marginR;

		public double marginT;

		public double marginB;

		public Rect wr;

		public ButtonHelper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ButtonHelper(Ent ent_, string pressSoundId_, string clickSoundId_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_ButtonHelper(ButtonHelper __hx_this, Ent ent_, string pressSoundId_, string clickSoundId_)
		{
		}

		public virtual bool react(Input input, object shortcutKey)
		{
			return false;
		}

		public virtual void setReactMargin(int marginL_, int marginR_, int marginT_, int marginB_)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
