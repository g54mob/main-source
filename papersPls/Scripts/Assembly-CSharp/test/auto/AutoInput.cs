using app;
using app.ent;
using app.vis;
using haxe.ds;
using haxe.lang;

namespace test.auto
{
	public class AutoInput : HxObject
	{
		public static PointData kZeroPoint;

		public Input input;

		public HostState inputHostState;

		public Clock clock;

		public Action curAction;

		public int curActionStartFrame;

		public int curActionDuration;

		public int curActionButtonDownDuration;

		public Action nextAction;

		public Atlas historyAtlas;

		public Array historyChips;

		public List historyInputHostStates;

		public double kDragPixelsPerFrame;

		public double kSwipeDist;

		public int kSwipeFrameCount;

		public int kSwipeCooldownFrameCount;

		public int kDefaultButtonDownFrameCount;

		public int kButtonUpFrameCount;

		public int kDefaultCooldownFrameCount;

		public int kHistoryCount;

		public int kFixedFps;

		static AutoInput()
		{
		}

		public AutoInput(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoInput(Rect limitRect)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoInput(AutoInput __hx_this, Rect limitRect)
		{
		}

		public static HostState copyHostState(HostState hostState)
		{
			return null;
		}

		public bool get_running()
		{
			return false;
		}

		public virtual void run(Action action)
		{
		}

		public virtual bool preventDoubleClick(Action action, int pointerId, PointData worldPos)
		{
			return false;
		}

		public virtual Input stepAndGetInput()
		{
			return null;
		}

		public virtual bool hasAnyPointerJustUpOrJustDown()
		{
			return false;
		}

		public virtual void updateHistory()
		{
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
