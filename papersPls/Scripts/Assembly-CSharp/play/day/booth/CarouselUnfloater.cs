using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class CarouselUnfloater : Ent
	{
		public static double kRepeatDelay;

		public static double kRepeatDistSqr;

		public Ent deskItemsParent;

		public double lastUnfloatTime;

		public PointData lastUnfloatWorldPos;

		public TakeBursts takeBursts;

		static CarouselUnfloater()
		{
		}

		public CarouselUnfloater(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CarouselUnfloater(Ent parent, Ent deskItemsParent_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_CarouselUnfloater(CarouselUnfloater __hx_this, Ent parent, Ent deskItemsParent_)
		{
		}

		public override void react(Input input)
		{
		}

		public virtual DeskItem getFloatingDeskItemAt(PointData stagePos)
		{
			return null;
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
