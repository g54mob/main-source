using haxe.lang;

namespace haxe.ds._IntMap
{
	public sealed class IntMapKeyIterator : HxObject
	{
		public IntMap m;

		public int i;

		public int len;

		public IntMapKeyIterator(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public IntMapKeyIterator(IntMap m)
			: base(default(EmptyObject))
		{
		}

		private static void __hx_ctor_haxe_ds__IntMap_IntMapKeyIterator(IntMapKeyIterator __hx_this, IntMap m)
		{
		}

		public bool hasNext()
		{
			return false;
		}

		public int next()
		{
			return 0;
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
