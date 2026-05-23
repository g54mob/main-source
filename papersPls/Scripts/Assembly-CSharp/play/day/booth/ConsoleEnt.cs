using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class ConsoleEnt : Ent
	{
		public static int kDarkColor;

		public static int kMedColor;

		public static int kLightColor;

		public static int kWeightTextRight;

		public double date;

		public int travelerCount;

		public string weight;

		public Sprite backgroundSprite0;

		public Sprite backgroundSprite1;

		public ConsoleClock consoleClock;

		public Sprite transcriptBoltSprite;

		public Text dateTextField;

		public Text weightTextField;

		public Text travelerCountTextField;

		public Stater stater;

		static ConsoleEnt()
		{
		}

		public ConsoleEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ConsoleEnt(Ent parent_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_ConsoleEnt(ConsoleEnt __hx_this, Ent parent_)
		{
		}

		public virtual double get_hour()
		{
			return 0.0;
		}

		public virtual double set_hour(double hour)
		{
			return 0.0;
		}

		public virtual double set_date(double date_)
		{
			return 0.0;
		}

		public virtual int set_travelerCount(int c)
		{
			return 0;
		}

		public virtual string set_weight(string w)
		{
			return null;
		}

		public virtual void flashTranscriptBolt()
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
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
