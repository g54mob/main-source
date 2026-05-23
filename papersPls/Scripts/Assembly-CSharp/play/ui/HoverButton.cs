using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class HoverButton : Button
	{
		public static int kNormalColor;

		public static int kPressedColor;

		public bool visible;

		public HoverButtonKind kind;

		public Sprite arrowBackSprite;

		public Sprite arrowForeSprite;

		public double arrowAnimT;

		public double visibleT;

		public Rect arrowClip;

		public Rect buttonClip;

		public double delayBeforeShowing;

		static HoverButton()
		{
		}

		public HoverButton(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public HoverButton(Ent parent, HoverButtonKind kind_, string text_, object playButtonUpSound, object delayBeforeShowing_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_HoverButton(HoverButton __hx_this, Ent parent, HoverButtonKind kind_, string text_, object playButtonUpSound, object delayBeforeShowing_)
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public override void react(Input input)
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
