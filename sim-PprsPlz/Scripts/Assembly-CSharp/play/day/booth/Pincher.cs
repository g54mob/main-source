using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class Pincher : Ent
	{
		public static int kSize;

		public static int kFrameIdle;

		public static int kFrameOpen;

		public static int kFrameHold;

		public DeskItem holdingDeskItem;

		public Array pincherSprites;

		public Array armSprites;

		public Stater stater;

		public Carousel carousel;

		public DeskItemDragHelper deskItemDragHelper;

		public PointData idlePos;

		public PointData releaseStartPos;

		public PointData holdingDeskItemInitialPos;

		public int pincherSpriteFrame;

		static Pincher()
		{
		}

		public Pincher(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Pincher(Ent parent, Carousel carousel_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Pincher(Pincher __hx_this, Ent parent, Carousel carousel_)
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
