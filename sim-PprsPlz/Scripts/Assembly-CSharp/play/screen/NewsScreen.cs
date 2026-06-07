using app.ent;
using app.vis;
using haxe.lang;
using play.day;
using play.ui;

namespace play.screen
{
	public class NewsScreen : GameScreen
	{
		public Day day;

		public Button goButton;

		public Sprite paperSprite;

		public Sprite newsSprite;

		public StoryState storyState;

		public NewsScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NewsScreen(Ent parent, Day day_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_NewsScreen(NewsScreen __hx_this, Ent parent, Day day_)
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void goButton_onClick(Button b)
		{
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
