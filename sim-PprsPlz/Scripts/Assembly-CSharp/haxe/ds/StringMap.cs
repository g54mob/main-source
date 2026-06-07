using haxe.lang;

namespace haxe.ds
{
	public class StringMap : HxObject, IMap, IHxObject
	{
		public int[] hashes;

		public string[] _keys;

		public object[] vals;

		public int nBuckets;

		public int size;

		public int nOccupied;

		public int upperBound;

		public string cachedKey;

		public int cachedIndex;

		public StringMap(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StringMap()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds_StringMap(StringMap __hx_this)
		{
		}

		IMap IMap.copy()
		{
			return null;
		}

		public virtual void set(object k, object v)
		{
		}

		public virtual void set(string key, object value)
		{
		}

		public int lookup(string key)
		{
			return 0;
		}

		public void resize(int newNBuckets)
		{
		}

		public virtual object get(object k)
		{
			return null;
		}

		public virtual object get(string key)
		{
			return null;
		}

		public virtual object getDefault(string key, object def)
		{
			return null;
		}

		public virtual bool exists(object k)
		{
			return false;
		}

		public virtual bool exists(string key)
		{
			return false;
		}

		public virtual bool remove(object k)
		{
			return false;
		}

		public virtual bool remove(string key)
		{
			return false;
		}

		public object keys()
		{
			return null;
		}

		public object iterator()
		{
			return null;
		}

		public object keyValueIterator()
		{
			return null;
		}

		public virtual StringMap copy()
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
