using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class Rack : Ent
	{
		public static int kMarginLR;

		public static int kBorderLR;

		public static int kPaddingLR;

		public static int kItemBottomY;

		public Carousel carousel;

		public Sprite backSprite;

		public Sprite needleSprite;

		public double needleX;

		public Array drawListeners;

		public double itemStep;

		public RackState state;

		public PointData stateBaselineWorldPos;

		public RackState prevState;

		public double prevStateStartTime;

		public double stateLerpNeedleX0;

		public double stateLerpNeedleX1;

		public Rect reactWorldRect;

		static Rack()
		{
		}

		public Rack(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Rack(Ent parent, Carousel carousel_, bool useMarginL, bool useMarginR)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Rack(Rack __hx_this, Ent parent, Carousel carousel_, bool useMarginL, bool useMarginR)
		{
		}

		public double get_stateLerpT()
		{
			return 0.0;
		}

		public virtual void addDrawListener(Function drawListener)
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

		public virtual PointData autoGetFocusClickWorldPos(int slotIndex)
		{
			return null;
		}

		public virtual double tutorGetFirstEntryXInBooth()
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
