using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class TutorIndicator : HxObject
	{
		public static int kDiagramColor;

		public bool visible;

		public Array frameSprites;

		public PointData frameOrigin;

		public double secondsPerFrame;

		public double showStartTime;

		public EntEnv entEnv;

		static TutorIndicator()
		{
		}

		public TutorIndicator(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TutorIndicator(EntEnv entEnv_, Image frameImage, int frameCount, PointData frameOrigin_, PointData focus_, object secondsPerFrame_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_TutorIndicator(TutorIndicator __hx_this, EntEnv entEnv_, Image frameImage, int frameCount, PointData frameOrigin_, PointData focus_, object secondsPerFrame_)
		{
		}

		public double set_focusX(double v)
		{
			return 0.0;
		}

		public double set_focusY(double v)
		{
			return 0.0;
		}

		public virtual void showAfterDelay(double delay)
		{
		}

		public virtual void hide()
		{
		}

		public virtual void step()
		{
		}

		public virtual void draw(PointData hostPos, Drawer drawer)
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
