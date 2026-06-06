using System;
using UnityEngine.Scripting;

namespace SQLite
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ColumnAttribute : UnityEngine.Scripting.PreserveAttribute
	{
		public string Name { get; set; }

		public ColumnAttribute(string name)
		{
		}
	}
}
