using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class DeskItemDragHelper : HxObject
	{
		public bool dragging;

		public PointData draggingPointerStartPos;

		public PointData draggingDeskItemStartPos;

		public Ent hostEnt;

		public Rect innerBounds;

		public Rect outerBounds;

		public bool passthroughClicks;

		public DeskItemDragHelper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DeskItemDragHelper(Ent hostEnt_, Rect innerBounds_, Rect outerBounds_, object passthroughClicks_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_DeskItemDragHelper(DeskItemDragHelper __hx_this, Ent hostEnt_, Rect innerBounds_, Rect outerBounds_, object passthroughClicks_)
		{
		}

		public virtual void react(Input input, DeskItem candidateDeskItem, object movementEnabled, object showInnerShadowIfPointerOver)
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
