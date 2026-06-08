using System;
using System.Collections.Generic;

namespace MoonSharp.Interpreter.Interop
{
	public class CustomConvertersCollection
	{
		private Dictionary<Type, Func<DynValue, object>>[] m_Script2Clr;

		private Dictionary<Type, Func<Script, object, DynValue>> m_Clr2Script;

		internal CustomConvertersCollection()
		{
		}

		public void SetScriptToClrCustomConversion(DataType scriptDataType, Type clrDataType, Func<DynValue, object> converter = null)
		{
		}

		public Func<DynValue, object> GetScriptToClrCustomConversion(DataType scriptDataType, Type clrDataType)
		{
			return null;
		}

		public void SetClrToScriptCustomConversion(Type clrDataType, Func<Script, object, DynValue> converter = null)
		{
		}

		public void SetClrToScriptCustomConversion<T>(Func<Script, T, DynValue> converter = null)
		{
		}

		public Func<Script, object, DynValue> GetClrToScriptCustomConversion(Type clrDataType)
		{
			return null;
		}

		[Obsolete("This method is deprecated. Use the overloads accepting functions with a Script argument.")]
		public void SetClrToScriptCustomConversion(Type clrDataType, Func<object, DynValue> converter = null)
		{
		}

		[Obsolete("This method is deprecated. Use the overloads accepting functions with a Script argument.")]
		public void SetClrToScriptCustomConversion<T>(Func<T, DynValue> converter = null)
		{
		}

		public void Clear()
		{
		}
	}
}
