using System;
using app.vis;
using haxe.lang;

namespace app.ent
{
	public class Input : HxObject
	{
		public static int POINTER_COUNT;

		public static double kDoubleClickSpan;

		public static double kDragClickDist;

		public bool wantVisibleCursor;

		public Array pointers;

		public Array curKeyDowns;

		public Array preKeyDowns;

		public Array maskUntilReleaseKeyDowns;

		public Array maskedAreas;

		public int maskedAreasCount;

		public Rect workRect;

		public Array curPointerCapturingEnts;

		public Array prePointerCapturingEnts;

		public Rect _checkPointerJustDownHitRectInWorld;

		public Ent maskingAllPointersForEnt;

		public Clock clock;

		public Rect limitRect;

		public int hidePointersCountdown;

		public bool hostStateWantVisibleCursor;

		static Input()
		{
		}

		public Input(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Input(Rect limitRect_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_Input(Input __hx_this, Rect limitRect_)
		{
		}

		public bool get_wantVisibleCursor()
		{
			return false;
		}

		public virtual void update(HostState hostState)
		{
		}

		public virtual Pointer getPointerOver(Ent ent, Rect worldRect, object onlyId)
		{
			return null;
		}

		public virtual Pointer getPointerOverEvenIfCaptured(Rect worldRect)
		{
			return null;
		}

		public virtual Swipe getSwipe(Rect worldRect)
		{
			return null;
		}

		public virtual Pointer getPointerJustDown(Ent ent, PointData entWorldPos, Rect entLocalRect, Cursor cursor)
		{
			return null;
		}

		public virtual bool checkPointerJustDown(Ent ent, PointData entWorldPos, Rect entLocalRect, Cursor cursor)
		{
			return false;
		}

		public virtual void maskAreaUntilFrameEnd(Rect areaInWorld)
		{
		}

		public virtual bool isInMaskedArea(PointData worldPos)
		{
			return false;
		}

		public virtual bool getIntersectsMaskedArea(Rect worldRect)
		{
			return false;
		}

		public virtual bool isCapturing(Ent ent)
		{
			return false;
		}

		public virtual Pointer getFirstCapturingPointer(System.Type capturingEntClass)
		{
			return null;
		}

		public virtual void maskPointerDownUntilRelease(int pointerId)
		{
		}

		public virtual void maskAllPointersDownUntilRelease()
		{
		}

		public virtual bool getKeyDown(int key)
		{
			return false;
		}

		public virtual bool getKeyUp(int key)
		{
			return false;
		}

		public virtual bool getKeyJustDown(int key)
		{
			return false;
		}

		public virtual bool getAnyKeyJustDown()
		{
			return false;
		}

		public virtual bool getKeyJustUp(int key)
		{
			return false;
		}

		public virtual void maskKeyUntilRelease(int key)
		{
		}

		public virtual Pointer getMainPointer()
		{
			return null;
		}

		public virtual Pointer getPointer(int id)
		{
			return null;
		}

		public virtual bool getAnyPointerJustDown()
		{
			return false;
		}

		public virtual bool getAnyPointerJustUp()
		{
			return false;
		}

		public virtual void hidePointersForOneFrame()
		{
		}

		public virtual bool hasChangedSinceLastFrame()
		{
			return false;
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
