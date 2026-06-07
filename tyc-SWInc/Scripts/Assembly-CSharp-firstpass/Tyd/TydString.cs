using System;
using System.ComponentModel;

namespace Tyd
{
	public class TydString : TydNode
	{
		public string Value { get; set; }

		public TydString(string name, string val, int docLine = -1)
			: base(name, docLine)
		{
			Value = val;
		}

		public override TydNode DeepClone()
		{
			return new TydString(_name, Value, DocLine)
			{
				DocIndexEnd = DocIndexEnd
			};
		}

		public override string ToString()
		{
			return string.Format("{0}=\"{1}\"", base.Name ?? "NullName", Value);
		}

		public T GetValue<T>(string name = null)
		{
			Type typeFromHandle = typeof(T);
			T val;
			try
			{
				val = (T)TypeDescriptor.GetConverter(typeFromHandle).ConvertFrom(Value);
			}
			catch (Exception)
			{
				throw new Exception(string.Format("Could not convert node {1} = \"{2}\" to {0}", typeFromHandle.Name, name ?? base.Name, Value));
			}
			if (val != null)
			{
				return val;
			}
			throw new Exception(string.Format("Could not convert node {1} = \"{2}\" to {0}", typeFromHandle.Name, name ?? base.Name, Value));
		}
	}
}
