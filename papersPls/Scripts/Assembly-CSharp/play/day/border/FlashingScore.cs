using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class FlashingScore : HxObject
	{
		public static int kNumFlashes;

		public static double kFlashDuration;

		public string text;

		public Text textField;

		public string flashText0;

		public string flashText1;

		public double flashingCountdown;

		public double centerY;

		public double anchorX;

		static FlashingScore()
		{
		}

		public FlashingScore(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FlashingScore(Text textField_, double centerY_, double anchorX_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_FlashingScore(FlashingScore __hx_this, Text textField_, double centerY_, double anchorX_)
		{
		}

		public virtual string set_text(string text_)
		{
			return null;
		}

		public virtual void align()
		{
		}

		public virtual void update(double dt)
		{
		}

		public virtual void flash(string flashText0_, string flashText1_)
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
