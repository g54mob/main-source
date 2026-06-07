using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class EndlessScoreboard : Ent
	{
		public static int kTextColor;

		public static int kBackColor;

		public static double kIconX;

		public static double kExtraLeft;

		public static double kClockRight;

		public static double kScoreRight;

		public static double kTextPadding;

		public Endless endless;

		public Text totalTextField;

		public Text extraTextField;

		public Text clockTextField;

		public FlashingScore totalFlashingScore;

		public FlashingScore extraFlashingScore;

		public FlashingScore clockFlashingScore;

		public int curScoreScale;

		public Array visuals;

		static EndlessScoreboard()
		{
		}

		public EndlessScoreboard(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndlessScoreboard(Ent parent, Endless endless_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_EndlessScoreboard(EndlessScoreboard __hx_this, Ent parent, Endless endless_)
		{
		}

		public static string toSignedString(int i)
		{
			return null;
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void endless_onNotifyScoreboard(Notification notification)
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
