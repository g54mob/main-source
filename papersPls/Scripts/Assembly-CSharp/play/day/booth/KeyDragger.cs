using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class KeyDragger : HxObject
	{
		public DeskItem keyDeskItem;

		public DeskItemDragHelper dragHelper;

		public PointData startPos;

		public PointData interpEndPos;

		public bool draggedWhileOpening;

		public bool isKey;

		public KeyDragger(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public KeyDragger(EntEnv entEnv, DeskItem keyDeskItem_, PointData interpEndPos_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_KeyDragger(KeyDragger __hx_this, EntEnv entEnv, DeskItem keyDeskItem_, PointData interpEndPos_)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
