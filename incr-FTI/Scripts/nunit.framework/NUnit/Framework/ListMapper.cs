using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace NUnit.Framework
{
	public class ListMapper
	{
		private ICollection original;

		public ListMapper(ICollection original)
		{
			this.original = original;
		}

		public ICollection Property(string name)
		{
			List<object> list = new List<object>();
			foreach (object item in original)
			{
				PropertyInfo property = item.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if ((object)property == null)
				{
					throw new ArgumentException($"{item} does not have a {name} property");
				}
				list.Add(property.GetValue(item, null));
			}
			return list;
		}
	}
}
