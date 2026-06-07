using System;
using System.Collections.Generic;

namespace MoonSharp.Interpreter.Interop
{
	public class CustomConvertersCollection
	{
		private Dictionary<Type, Func<DynValue, object>>[] m_Script2Clr = new Dictionary<Type, Func<DynValue, object>>[11];

		private Dictionary<Type, Func<object, DynValue>> m_Clr2Script = new Dictionary<Type, Func<object, DynValue>>();

		internal CustomConvertersCollection()
		{
			for (int i = 0; i < m_Script2Clr.Length; i++)
			{
				m_Script2Clr[i] = new Dictionary<Type, Func<DynValue, object>>();
			}
		}

		public void SetScriptToClrCustomConversion(DataType scriptDataType, Type clrDataType, Func<DynValue, object> converter = null)
		{
			if ((int)scriptDataType > m_Script2Clr.Length)
			{
				throw new ArgumentException("scriptDataType");
			}
			Dictionary<Type, Func<DynValue, object>> dictionary = m_Script2Clr[(int)scriptDataType];
			if (converter == null)
			{
				if (dictionary.ContainsKey(clrDataType))
				{
					dictionary.Remove(clrDataType);
				}
			}
			else
			{
				dictionary[clrDataType] = converter;
			}
		}

		public Func<DynValue, object> GetScriptToClrCustomConversion(DataType scriptDataType, Type clrDataType)
		{
			if ((int)scriptDataType > m_Script2Clr.Length)
			{
				return null;
			}
			Dictionary<Type, Func<DynValue, object>> dictionary = m_Script2Clr[(int)scriptDataType];
			return dictionary.GetOrDefault(clrDataType);
		}

		public void SetClrToScriptCustomConversion(Type clrDataType, Func<object, DynValue> converter = null)
		{
			if (converter == null)
			{
				if (m_Clr2Script.ContainsKey(clrDataType))
				{
					m_Clr2Script.Remove(clrDataType);
				}
			}
			else
			{
				m_Clr2Script[clrDataType] = converter;
			}
		}

		public void SetClrToScriptCustomConversion<T>(Func<T, DynValue> converter = null)
		{
			SetClrToScriptCustomConversion(typeof(T), (object o) => converter((T)o));
		}

		public Func<object, DynValue> GetClrToScriptCustomConversion(Type clrDataType)
		{
			return m_Clr2Script.GetOrDefault(clrDataType);
		}

		public void Clear()
		{
			m_Clr2Script.Clear();
			for (int i = 0; i < m_Script2Clr.Length; i++)
			{
				m_Script2Clr[i].Clear();
			}
		}
	}
}
