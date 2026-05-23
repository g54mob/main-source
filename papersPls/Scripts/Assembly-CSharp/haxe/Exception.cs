using System;
using System.Diagnostics;
using haxe.lang;

namespace haxe
{
	public class Exception : System.Exception, IHxObject
	{
		public Array __exceptionStack;

		public StackTrace __nativeStack;

		public bool __ownStack;

		public int __skipStack;

		public System.Exception __nativeException;

		public Exception __previousException;

		public Exception(EmptyObject empty)
		{
		}

		public Exception(string message, Exception previous, object native)
		{
		}

		public static Exception caught(object value)
		{
			return null;
		}

		public static object thrown(object value)
		{
			return null;
		}

		public virtual object unwrap()
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual string details()
		{
			return null;
		}

		public void __shiftStack()
		{
		}

		public virtual string get_message()
		{
			return null;
		}

		public virtual Exception get_previous()
		{
			return null;
		}

		public object get_native()
		{
			return null;
		}

		public virtual Array get_stack()
		{
			return null;
		}

		public virtual object __hx_lookupField(string field, int hash, bool throwErrors, bool isCheck)
		{
			return null;
		}

		public virtual double __hx_lookupField_f(string field, int hash, bool throwErrors)
		{
			return 0.0;
		}

		public virtual object __hx_lookupSetField(string field, int hash, object value)
		{
			return null;
		}

		public virtual double __hx_lookupSetField_f(string field, int hash, double value)
		{
			return 0.0;
		}

		public virtual double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public virtual object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public virtual object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public virtual double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public virtual object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public virtual void __hx_getFields(Array baseArr)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
