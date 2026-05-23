using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class Intro : Ent
	{
		public static int kImageW;

		public static int kImageH;

		public Function whenDone;

		public bool visible;

		public Stater stater;

		public RevealTextEnt textField;

		public Sprite curSprite;

		public Sprite nexSprite;

		public Array pages;

		public int pageIndex;

		public Button nexButton;

		public FactSet storyFacts;

		public bool allowSkip;

		static Intro()
		{
		}

		public Intro(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Intro(Ent parent, FactSet storyFacts_, Array pages_, bool allowSkip_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_Intro(Intro __hx_this, Ent parent, FactSet storyFacts_, Array pages_, bool allowSkip_)
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

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public virtual void nexButton_onClick(Button b)
		{
		}

		public virtual void endFlipNow()
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
