using data;
using haxe.lang;

namespace play.day
{
	public class EndlessResult : HxObject
	{
		public EndlessStyle style;

		public EndlessCourse course;

		public int score;

		public double time;

		public EndlessResult(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndlessResult(EndlessStyle style_, EndlessCourse course_, int score_, double time_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_EndlessResult(EndlessResult __hx_this, EndlessStyle style_, EndlessCourse course_, int score_, double time_)
		{
		}

		public virtual string getDescription(Lang lang)
		{
			return null;
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
