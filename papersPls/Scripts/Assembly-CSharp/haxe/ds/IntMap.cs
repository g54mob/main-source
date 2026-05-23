using System;
using haxe.lang;

namespace haxe.ds
{
	public class IntMap : HxObject, IMap, IHxObject
	{
		private static bool __hx_init_called;

		public static double HASH_UPPER;

		public int[] flags;

		public int[] _keys;

		public object[] vals;

		public int nBuckets;

		public int size;

		public int nOccupied;

		public int upperBound;

		public int cachedKey;

		public int cachedIndex;

		static IntMap()
		{
		}

		public IntMap(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public IntMap()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds_IntMap(IntMap __hx_this)
		{
		}

		public static void assert(bool x)
		{
		}

		public static int defaultK()
		{
			return 0;
		}

		public static void arrayCopy(System.Array sourceArray, int sourceIndex, System.Array destinationArray, int destinationIndex, int length)
		{
		}

		public static int getInc(int k, int mask)
		{
			return 0;
		}

		public static int hash(int i)
		{
			return 0;
		}

		public static int getFlag(int[] flags, int i)
		{
			return 0;
		}

		public static bool isDel(int flag)
		{
			return false;
		}

		public static bool isEmpty(int flag)
		{
			return false;
		}

		public static bool isEither(int flag)
		{
			return false;
		}

		public static void setIsDelFalse(int[] flags, int i)
		{
		}

		public static void setIsEmptyFalse(int[] flags, int i)
		{
		}

		public static void setIsBothFalse(int[] flags, int i)
		{
		}

		public static void setIsDelTrue(int[] flags, int i)
		{
		}

		public static int roundUp(int x)
		{
			return 0;
		}

		public static int flagsSize(int m)
		{
			return 0;
		}

		IMap IMap.copy()
		{
			return null;
		}

		public virtual void set(object k, object v)
		{
		}

		public virtual void set(int key, object value)
		{
		}

		public int lookup(int key)
		{
			return 0;
		}

		public virtual object get(object k)
		{
			return null;
		}

		public virtual object get(int key)
		{
			return null;
		}

		public virtual object getDefault(int key, object def)
		{
			return null;
		}

		public virtual bool exists(object k)
		{
			return false;
		}

		public virtual bool exists(int key)
		{
			return false;
		}

		public virtual bool remove(object k)
		{
			return false;
		}

		public virtual bool remove(int key)
		{
			return false;
		}

		public void resize(int newNBuckets)
		{
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

		public virtual IntMap copy()
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
