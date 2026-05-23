using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class CustomTile : Chip
	{
		public Function onComplete;

		public string prefix;

		public double fps;

		public bool loop;

		public bool animated;

		public double frame;

		public Array frames;

		public int time;

		public int prevFrame;

		public CustomTile(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CustomTile(Atlas atlas_, string prefix_, object fps_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_CustomTile(CustomTile __hx_this, Atlas atlas_, string prefix_, object fps_)
		{
		}

		public virtual void init()
		{
		}

		public virtual void stepAnim(double dt)
		{
		}

		public virtual void restartAnim()
		{
		}

		public virtual int get_currentFrame()
		{
			return 0;
		}

		public virtual int set_currentFrame(int value)
		{
			return 0;
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
