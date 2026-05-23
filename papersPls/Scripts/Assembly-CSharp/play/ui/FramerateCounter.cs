using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class FramerateCounter : Ent
	{
		public static double lastFrameTimestamp;

		public Text text;

		public Array history;

		public int cur;

		public double time;

		public int displayFps;

		public FramerateCounter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FramerateCounter(Ent parent)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_FramerateCounter(FramerateCounter __hx_this, Ent parent)
		{
		}

		public static void limitFps(object maxFps)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
