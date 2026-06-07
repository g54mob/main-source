using app.vis;
using haxe.lang;

namespace app.ent
{
	public class Pointer : HxObject
	{
		public int id;

		public bool down;

		public bool justDown;

		public bool justUp;

		public PointData worldPos;

		public PointData preWorldPos;

		public PointData unclampedWorldPos;

		public Cursor cursor;

		public Ent capturingEnt;

		public bool justDoubleClicked;

		public Swipe swipe;

		public PointData swipeStartWorldPos;

		public PointData justDownWorldPos;

		public bool maskDownUntilRelease;

		public Clock clock;

		public int capturingEntCountdown;

		public double justDownTime;

		public bool fromTouch;

		public int downHistoryCount;

		public Array downHistoryWorldPos;

		public Pointer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Pointer(Clock clock_, int id_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_Pointer(Pointer __hx_this, Clock clock_, int id_)
		{
		}

		public bool get_active()
		{
			return false;
		}

		public virtual void update(Rect limitRect, HostPointer hostPointer)
		{
		}

		public void setCursor(Cursor cursor_)
		{
		}

		public void setCursorHand()
		{
		}

		public void setCursorArrow()
		{
		}

		public void setCursorCustom(Image image)
		{
		}

		public virtual void captureUntilNextFrameEnd(Ent capturingEnt_)
		{
		}

		public virtual bool isCapturing(Ent ent)
		{
			return false;
		}

		public virtual bool willDoubleClick(PointData worldPos)
		{
			return false;
		}

		public virtual bool justUpWithoutMoving(double moveDistThresholdX, double moveDistThresholdY)
		{
			return false;
		}

		public virtual bool hasMovedSinceJustDown(double moveDistThresholdX, double moveDistThresholdY)
		{
			return false;
		}

		public virtual bool hasChangedSinceLastFrame()
		{
			return false;
		}

		public virtual string toString()
		{
			return null;
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

		public override string ToString()
		{
			return null;
		}
	}
}
