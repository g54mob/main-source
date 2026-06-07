using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class Button : Ent
	{
		public string id;

		public Function whenClick;

		public double scale;

		public int shortcutKey;

		public string fontName;

		public Text text;

		public Sprite backgroundSprite;

		public Mode mode;

		public Array modes;

		public bool buttonVisible;

		public ButtonHelper buttonHelper;

		public Button(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Button(Ent parent_, string fontName_, string pressSoundId, string clickSoundId)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_Button(Button __hx_this, Ent parent_, string fontName_, string pressSoundId, string clickSoundId)
		{
		}

		public bool get_enabled()
		{
			return false;
		}

		public bool set_enabled(bool v)
		{
			return false;
		}

		public double set_scale(double s)
		{
			return 0.0;
		}

		public override void draw(Drawer drawer)
		{
		}

		public override void react(Input input)
		{
		}

		public virtual Mode addMode(string name, PartData normalImagePart, PartData pressingImagePart)
		{
			return null;
		}

		public virtual string get_modeName()
		{
			return null;
		}

		public virtual Mode findMode(string name)
		{
			return null;
		}

		public virtual string set_modeName(string name)
		{
			return null;
		}

		public virtual void applyMode()
		{
		}

		public virtual void cycleMode()
		{
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public virtual void setImageClip(Rect clip)
		{
		}

		public virtual void setVisualsLayer(int layer)
		{
		}

		public bool get_hasBackButtonId()
		{
			return false;
		}

		public virtual void setAsBackButton()
		{
		}

		public virtual void setReactMargin(int left, int right, int top, int bottom)
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
