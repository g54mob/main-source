using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class RatingPopup : Ent
	{
		public Fill backFill;

		public Sprite iconSprite;

		public Button doneButton;

		public Clock localClock;

		public Rect screenRect;

		public Frame boxFrame;

		public RatingPopup(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public RatingPopup(Ent parent)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_RatingPopup(RatingPopup __hx_this, Ent parent)
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public virtual void close()
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
