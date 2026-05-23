using app.ent;
using app.vis;
using haxe.lang;

namespace play.screen
{
	public class NewsScreenMagnifier : Ent
	{
		public static int kShadowOffsetX;

		public static int kShadowOffsetY;

		public Sprite sprite;

		public Image image;

		public Sprite srcSprite;

		public Sprite magSprite;

		public Fill shadowFill;

		public Rect hitRectInWorld;

		public PointData magSize;

		static NewsScreenMagnifier()
		{
		}

		public NewsScreenMagnifier(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NewsScreenMagnifier(Ent parent, Sprite srcSprite_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_NewsScreenMagnifier(NewsScreenMagnifier __hx_this, Ent parent, Sprite srcSprite_)
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
