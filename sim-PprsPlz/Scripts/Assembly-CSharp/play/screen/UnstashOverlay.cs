using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class UnstashOverlay : Ent
	{
		public static int kNumPrepFrames;

		public static int kSpacing;

		public Fill backFill;

		public Sprite iconSprite;

		public Button resumeButton;

		public bool resumeButtonClicked;

		public int frameCount;

		public GameScreen gameScreen;

		static UnstashOverlay()
		{
		}

		public UnstashOverlay(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public UnstashOverlay(GameScreen gameScreen_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_UnstashOverlay(UnstashOverlay __hx_this, GameScreen gameScreen_)
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
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

		public virtual void resumeButton_onClick(Button b)
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
