using haxe.lang;

namespace haxe.ds._List
{
	public class ListIterator : HxObject
	{
		public ListNode head;

		public ListIterator(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ListIterator(ListNode head)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds__List_ListIterator(ListIterator __hx_this, ListNode head)
		{
		}

		public bool hasNext()
		{
			return false;
		}

		public object next()
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
