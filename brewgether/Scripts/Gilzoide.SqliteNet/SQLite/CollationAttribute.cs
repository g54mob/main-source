using System;
using UnityEngine.Scripting;

namespace SQLite
{
	[AttributeUsage(AttributeTargets.Property)]
	public class CollationAttribute : UnityEngine.Scripting.PreserveAttribute
	{
		public string Value { get; private set; }

		public CollationAttribute(string collation)
		{
		}
	}
}
