using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class Inspectable : HxObject
	{
		public string factPath;

		public Rect rectInBooth;

		public bool selectable;

		public uint holdingEntGuid;

		public Inspectable(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Inspectable(string factPath_, Rect rectInBooth_, uint holdingEntGuid_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Inspectable(Inspectable __hx_this, string factPath_, Rect rectInBooth_, uint holdingEntGuid_)
		{
		}

		public bool get_isFromBooth()
		{
			return false;
		}

		public virtual bool isParentOf(Inspectable i)
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
