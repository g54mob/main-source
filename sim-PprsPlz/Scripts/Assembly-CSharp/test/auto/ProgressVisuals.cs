using app.ent;
using app.vis;
using haxe.lang;
using play;

namespace test.auto
{
	public class ProgressVisuals : HxObject
	{
		public Array playthroughs;

		public PointData pos;

		public PointData playthroughPos;

		public Text statusText;

		public Text timeText;

		public Text memText;

		public Fill backFill;

		public Font font;

		public double width;

		public Array playthroughTexts;

		public Array playthroughStatuses;

		public double startTime;

		public double endTime;

		public double topY;

		public bool running;

		public int kStatusPadding;

		public ProgressVisuals(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ProgressVisuals(Bootstrap bootstrap, Array playthroughs_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_ProgressVisuals(ProgressVisuals __hx_this, Bootstrap bootstrap, Array playthroughs_)
		{
		}

		public virtual void stop(string finalStatus)
		{
		}

		public virtual void draw(Drawer drawer, double memUsage, AutoPlayer autoPlayer)
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
