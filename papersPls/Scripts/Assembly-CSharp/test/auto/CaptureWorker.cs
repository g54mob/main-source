using app;
using app.ent;
using haxe.lang;

namespace test.auto
{
	public class CaptureWorker : HxObject
	{
		public Drawer drawer;

		public SoftwareRenderer softwareRenderer;

		public FrameRecorder frameRecorder;

		public CaptureWorker(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CaptureWorker(int width, int height)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_CaptureWorker(CaptureWorker __hx_this, int width, int height)
		{
		}

		public virtual void addFrame(Trunk trunk, Function extraDrawFunc)
		{
		}

		public virtual void close()
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
