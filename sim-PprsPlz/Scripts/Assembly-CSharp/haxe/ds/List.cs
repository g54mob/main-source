using haxe.ds._List;
using haxe.lang;

namespace haxe.ds
{
	public class List : HxObject
	{
		public ListNode h;

		public ListNode q;

		public int length;

		public List(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public List()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds_List(List __hx_this)
		{
		}

		public virtual void add(object item)
		{
		}

		public virtual void push(object item)
		{
		}

		public virtual object first()
		{
			return null;
		}

		public virtual object last()
		{
			return null;
		}

		public virtual object pop()
		{
			return null;
		}

		public virtual bool isEmpty()
		{
			return false;
		}

		public virtual void clear()
		{
		}

		public virtual bool remove(object v)
		{
			return false;
		}

		public ListIterator iterator()
		{
			return null;
		}

		public ListKeyValueIterator keyValueIterator()
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual string join(string sep)
		{
			return null;
		}

		public virtual List filter(Function f)
		{
			return null;
		}

		public virtual List map(Function f)
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
