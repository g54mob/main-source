using app.vis;
using haxe.lang;
using sys.thread;
using sys.thread._Thread;

namespace app
{
	public class FrameRecorder : HxObject
	{
		public static string kffmpegPath;

		public int frameCount;

		public object settings;

		public Deque inDeque;

		public Deque outDeque;

		public HaxeThread thread;

		public bool open;

		static FrameRecorder()
		{
		}

		public FrameRecorder(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FrameRecorder(object settings_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_FrameRecorder(FrameRecorder __hx_this, object settings_)
		{
		}

		public static object getFormatInfo(Format format)
		{
			return null;
		}

		public virtual void addFrame(Image image)
		{
		}

		public virtual void close()
		{
		}

		public virtual void runThread()
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
