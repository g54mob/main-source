using haxe.lang;

namespace haxe.ds._List
{
	public class ListNode : HxObject
	{
		public object item;

		public ListNode next;

		public ListNode(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ListNode(object item, ListNode next)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds__List_ListNode(ListNode __hx_this, object item, ListNode next)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
