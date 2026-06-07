using System.Collections.Generic;

namespace NUnit.Framework.Interfaces
{
	public class AttributeDictionary : Dictionary<string, string>
	{
		public new string this[string key]
		{
			get
			{
				if (TryGetValue(key, out var value))
				{
					return value;
				}
				return null;
			}
		}
	}
}
