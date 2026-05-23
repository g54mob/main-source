using haxe.lang;

namespace haxe.ds
{
	public class ObjectMap : HxObject, IMap, IHxObject
	{
		public int[] hashes;

		public object[] _keys;

		public object[] vals;

		public int nBuckets;

		public int size;

		public int nOccupied;

		public int upperBound;

		public object cachedKey;

		public int cachedIndex;

		public ObjectMap(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ObjectMap()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds_ObjectMap(ObjectMap __hx_this)
		{
		}

		IMap IMap.copy()
		{
			return null;
		}

		public virtual void set(object key, object value)
		{
		}

		public int lookup(object key)
		{
			return 0;
		}

		public void resize(int newNBuckets)
		{
		}

		public virtual object get(object key)
		{
			return null;
		}

		public virtual object getDefault(object key, object def)
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

		public virtual ObjectMap copy()
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
