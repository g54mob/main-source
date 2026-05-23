using app.vis;
using haxe.lang;

namespace app.ent
{
	public class Swipe : HxObject
	{
		public SwipeDir dir;

		public PointData startWorldPos;

		public Pointer pointer;

		public bool claimed;

		public Swipe(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Swipe(Pointer pointer_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ent_Swipe(Swipe __hx_this, Pointer pointer_)
		{
		}

		public virtual void claim()
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
