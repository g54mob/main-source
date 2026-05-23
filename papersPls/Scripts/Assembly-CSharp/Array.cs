using haxe.iterators;
using haxe.lang;

public sealed class Array : HxObject
{
	private static bool __hx_init_called;

	public static int __hx_toString_depth;

	public static int __hx_defaultCapacity;

	public int length;

	public object[] __a;

	public object Item
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	static Array()
	{
	}

	public Array(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Array(object[] native)
		: base(default(EmptyObject))
	{
	}

	public Array()
		: base(default(EmptyObject))
	{
	}

	private static void __hx_ctor__Array(Array __hx_this, object[] native)
	{
	}

	private static void __hx_ctor__Array(Array __hx_this)
	{
	}

	public static Array ofNative(object[] native)
	{
		return null;
	}

	public static Array alloc(int size)
	{
		return null;
	}

	public Array concat(Array a)
	{
		return null;
	}

	public void concatNative(object[] a)
	{
	}

	public int indexOf(object x, object fromIndex)
	{
		return 0;
	}

	public int lastIndexOf(object x, object fromIndex)
	{
		return 0;
	}

	public string join(string sep)
	{
		return null;
	}

	public object pop()
	{
		return null;
	}

	public int push(object x)
	{
		return 0;
	}

	public void reverse()
	{
	}

	public object shift()
	{
		return null;
	}

	public Array slice(int pos, object end)
	{
		return null;
	}

	public void sort(Function f)
	{
	}

	public void quicksort(int lo, int hi, Function f)
	{
	}

	public Array splice(int pos, int len)
	{
		return null;
	}

	public void spliceVoid(int pos, int len)
	{
	}

	public string toString()
	{
		return null;
	}

	public string __hx_toString()
	{
		return null;
	}

	public void unshift(object x)
	{
	}

	public void insert(int pos, object x)
	{
	}

	public bool remove(object x)
	{
		return false;
	}

	public Array map(Function f)
	{
		return null;
	}

	public bool contains(object x)
	{
		return false;
	}

	public Array filter(Function f)
	{
		return null;
	}

	public Array copy()
	{
		return null;
	}

	public ArrayIterator iterator()
	{
		return null;
	}

	public ArrayKeyValueIterator keyValueIterator()
	{
		return null;
	}

	public void resize(int len)
	{
	}

	public object __get(int idx)
	{
		return null;
	}

	public object __set(int idx, object v)
	{
		return null;
	}

	public object __unsafe_get(int idx)
	{
		return null;
	}

	public object __unsafe_set(int idx, object val)
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
