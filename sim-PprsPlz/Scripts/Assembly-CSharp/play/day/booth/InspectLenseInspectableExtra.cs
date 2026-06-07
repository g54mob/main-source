using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class InspectLenseInspectableExtra : HxObject
	{
		public static int kExpand;

		public Inspectable inspectable;

		public Sprite sprite;

		public Rect scrolledRectInBooth;

		public Image image;

		public QuadIter quadIter;

		public Carousel carousel;

		public Drawer drawer;

		public Booth booth;

		public Rect expandedRectInBooth;

		public Frame highlightMaskFrame;

		public PointData workPoint;

		public double offscreenT;

		public Ent holdingEnt;

		public PointData posInHoldingEnt;

		static InspectLenseInspectableExtra()
		{
		}

		public InspectLenseInspectableExtra(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public InspectLenseInspectableExtra(int widthMax, int heightMax, Carousel carousel_, Drawer drawer_, Booth booth_, Image highlightMaskImage)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_InspectLenseInspectableExtra(InspectLenseInspectableExtra __hx_this, int widthMax, int heightMax, Carousel carousel_, Drawer drawer_, Booth booth_, Image highlightMaskImage)
		{
		}

		public static void resolveOffscreenOverlapping(InspectLenseInspectableExtra a, InspectLenseInspectableExtra b)
		{
		}

		public virtual bool hitTestWorldPos(PointData worldPos)
		{
			return false;
		}

		public virtual void sync(Inspectable inspectable_)
		{
		}

		public virtual void updateSpriteRect()
		{
		}

		public virtual void drawTree(Ent ent, Drawer drawer)
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
