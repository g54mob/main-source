using app.ent;
using app.vis;
using data;
using haxe.lang;
using play.day.booth;

namespace test.auto
{
	public class DeskItemDrag : HxObject
	{
		public PointData p0;

		public PointData p1;

		public SwipeDir swipeDir;

		public DeskItemDrag(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DeskItemDrag(PointData p0_, PointData p1_, SwipeDir swipeDir_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_DeskItemDrag(DeskItemDrag __hx_this, PointData p0_, PointData p1_, SwipeDir swipeDir_)
		{
		}

		public static DeskItemDrag drag(DeskItem deskItem, DeskItemPlacement targetPlacement, PointData targetCenter)
		{
			return null;
		}

		public static DeskItemDrag swipe(PointData p0, SwipeDir swipeDir)
		{
			return null;
		}

		public static DeskItemDrag click(PointData clickPoint)
		{
			return null;
		}

		public static bool testObstructionHit(Ent ent, PointData worldPos)
		{
			return false;
		}

		public static PointData getGrabPos(DeskItem deskItem)
		{
			return null;
		}

		public static PointData getDragP1(DeskItem deskItem, PointData p0, DeskItemPlacement targetPlacement, PointData targetCenter)
		{
			return null;
		}

		public bool get_hasMovement()
		{
			return false;
		}

		public virtual Action toInputAction(int pointerId, object dragHold)
		{
			return null;
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
