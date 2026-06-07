using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	public class TableColumnWidthAttribute : Attribute
	{
		public int Width;

		public bool Resizable;

		public TableColumnWidthAttribute(int width, bool resizable = true)
		{
		}
	}
}
