using app.vis;
using haxe.lang;

namespace test.auto
{
	public class Playthrough : HxObject
	{
		public AutoRoute route;

		public PlaythroughStatus status;

		public EndReport endReport;

		public Playthrough(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Playthrough(Font font, AutoRoute route_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_Playthrough(Playthrough __hx_this, Font font, AutoRoute route_)
		{
		}

		public virtual void start()
		{
		}

		public virtual void finish(EndReport endReport_)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
