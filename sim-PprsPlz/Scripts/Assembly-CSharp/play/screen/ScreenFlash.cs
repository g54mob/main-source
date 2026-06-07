using app.ent;
using app.vis;
using haxe.lang;

namespace play.screen
{
	public class ScreenFlash : HxObject
	{
		public double shakeStartTime;

		public double shakeDuration;

		public double shakeMagnitude;

		public double flashDuration;

		public double flashFadeDuration;

		public Fill fadeFill;

		public Fill flashFill;

		public ScreenFlash(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ScreenFlash(int width, int height)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_ScreenFlash(ScreenFlash __hx_this, int width, int height)
		{
		}

		public virtual bool get_isFading()
		{
			return false;
		}

		public virtual double get_fadeT()
		{
			return 0.0;
		}

		public virtual double set_fadeT(double f)
		{
			return 0.0;
		}

		public virtual double get_flashT()
		{
			return 0.0;
		}

		public virtual double set_flashT(double f)
		{
			return 0.0;
		}

		public virtual void clear()
		{
		}

		public virtual void startFlash(double flashDuration_, double flashFadeDuration_)
		{
		}

		public virtual bool applyFlash(double time)
		{
			return false;
		}

		public virtual void draw(Drawer drawer)
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
