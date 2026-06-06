using System;
using UnityEngine.Scripting;

namespace SQLite
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class IndexedAttribute : UnityEngine.Scripting.PreserveAttribute
	{
		public string Name { get; set; }

		public int Order { get; set; }

		public virtual bool Unique { get; set; }

		public IndexedAttribute()
		{
		}

		public IndexedAttribute(string name, int order)
		{
		}
	}
}
