using haxe.lang;

namespace haxe.ds
{
	public class WeakMap : HxObject, IMap, IHxObject
	{
		public WeakMap(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public WeakMap()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds_WeakMap(WeakMap __hx_this)
		{
		}

		IMap IMap.copy()
		{
			return null;
		}

		public virtual void set(object key, object value)
		{
		}

		public virtual object get(object key)
		{
			return null;
		}

		public virtual bool exists(object key)
		{
			return false;
		}

		public virtual bool remove(object key)
		{
			return false;
		}

		public virtual object keys()
		{
			return null;
		}

		public virtual object iterator()
		{
			return null;
		}

		public object keyValueIterator()
		{
			return null;
		}

		public virtual WeakMap copy()
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual void clear()
		{
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
