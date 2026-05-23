using haxe.lang;

namespace data
{
	public class FactAdaptorInt : HxObject
	{
		public FactSet factSet;

		public string path;

		public int def;

		public FactAdaptorInt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FactAdaptorInt(FactSet factSet_, string path_, int def_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FactAdaptorInt(FactAdaptorInt __hx_this, FactSet factSet_, string path_, int def_)
		{
		}

		public int get()
		{
			return 0;
		}

		public int set(int v)
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
