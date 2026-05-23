using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class TutorLesson : HxObject
	{
		public static double kDefaultCoverLerpDuration;

		public static int kDefaultIndicatorDelay;

		public EntEnv entEnv;

		public int counter;

		public TutorCover showCover;

		public TutorCover hideCover;

		public TutorIndicator indicator;

		public Function forAuto;

		public double duration;

		public Function onBegin;

		public Function onStep;

		public Function onReact;

		public double startTime;

		public double coverLerpDuration;

		public double indicatorInitialDelay;

		static TutorLesson()
		{
		}

		public TutorLesson(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TutorLesson(object init)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_TutorLesson(TutorLesson __hx_this, object init)
		{
		}

		public double get_time()
		{
			return 0.0;
		}

		public virtual bool begin()
		{
			return false;
		}

		public virtual bool step()
		{
			return false;
		}

		public virtual void react(Input input)
		{
		}

		public virtual void draw(PointData hostPos, Drawer drawer, int layer)
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
