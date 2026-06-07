namespace haxe.lang
{
	public class DynamicObject : HxObject
	{
		public static int __hx_toString_depth;

		public int[] __hx_hashes;

		public object[] __hx_dynamics;

		public int[] __hx_hashes_f;

		public double[] __hx_dynamics_f;

		public int __hx_length;

		public int __hx_length_f;

		public FieldHashConflict __hx_conflicts;

		static DynamicObject()
		{
		}

		public DynamicObject(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DynamicObject(int[] hashes, object[] dynamics, int[] hashes_f, double[] dynamics_f)
			: base(default(EmptyObject))
		{
		}

		public DynamicObject()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_lang_DynamicObject(DynamicObject __hx_this, int[] hashes, object[] dynamics, int[] hashes_f, double[] dynamics_f)
		{
		}

		protected static void __hx_ctor_haxe_lang_DynamicObject(DynamicObject __hx_this)
		{
		}

		public override bool __hx_deleteField(string field, int hash)
		{
			return false;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual string __hx_toString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
