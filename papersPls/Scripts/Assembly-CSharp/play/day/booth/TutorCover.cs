using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class TutorCover : Ent
	{
		public double coverT;

		public Fill fill;

		public TutorHideDir hideDir;

		public Rect rect;

		public bool maskInput;

		public TutorCover(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TutorCover(Ent parent, Rect rect_, TutorHideDir hideDir_, bool maskInput_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_TutorCover(TutorCover __hx_this, Ent parent, Rect rect_, TutorHideDir hideDir_, bool maskInput_)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual double set_coverT(double t)
		{
			return 0.0;
		}

		public override void react(Input input)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
