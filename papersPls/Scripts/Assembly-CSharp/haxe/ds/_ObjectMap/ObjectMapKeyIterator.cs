using haxe.lang;

namespace haxe.ds._ObjectMap
{
	public sealed class ObjectMapKeyIterator : HxObject
	{
		public ObjectMap m;

		public int i;

		public int len;

		public ObjectMapKeyIterator(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ObjectMapKeyIterator(ObjectMap m)
			: base(default(EmptyObject))
		{
		}

		private static void __hx_ctor_haxe_ds__ObjectMap_ObjectMapKeyIterator(ObjectMapKeyIterator __hx_this, ObjectMap m)
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
