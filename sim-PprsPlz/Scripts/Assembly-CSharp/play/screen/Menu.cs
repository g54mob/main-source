using app.ent;
using app.vis;
using haxe.ds;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class Menu : HxObject
	{
		public Function whenClick;

		public Ent host;

		public double centerY;

		public StringMap buttons;

		public Array centerButtons;

		public Menu(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Menu(Ent host_, double centerY_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_Menu(Menu __hx_this, Ent host_, double centerY_)
		{
		}

		public virtual void addButton(Button button, object centerButton)
		{
		}

		public virtual Button addPushButton(string id, string text, app.vis.Align align)
		{
			return null;
		}

		public virtual Button manageButton(Button button, object inCentralList)
		{
			return null;
		}

		public virtual Button addImageButton(string id, Image image, object cellHeight, string fontName)
		{
			return null;
		}

		public virtual Button getButton(string id)
		{
			return null;
		}

		public virtual void applyCenterY()
		{
		}

		public virtual void button_onClick(Button b)
		{
		}

		public virtual Rect getCenterButtonsBounds()
		{
			return null;
		}

		public virtual void setAllButtonsActive(bool active_)
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
