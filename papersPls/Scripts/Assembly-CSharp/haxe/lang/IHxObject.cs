namespace haxe.lang
{
	public interface IHxObject
	{
		object __hx_lookupField(string field, int hash, bool throwErrors, bool isCheck);

		double __hx_lookupField_f(string field, int hash, bool throwErrors);

		object __hx_lookupSetField(string field, int hash, object value);

		double __hx_lookupSetField_f(string field, int hash, double value);

		double __hx_setField_f(string field, int hash, double value, bool handleProperties);

		object __hx_setField(string field, int hash, object value, bool handleProperties);

		object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties);

		double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties);

		object __hx_invokeField(string field, int hash, object[] dynargs);

		void __hx_getFields(Array baseArr);
	}
}
