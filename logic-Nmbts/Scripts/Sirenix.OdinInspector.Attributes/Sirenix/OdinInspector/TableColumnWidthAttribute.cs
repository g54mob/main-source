using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class TableColumnWidthAttribute : Attribute
	{
		public int Width;

		public bool Resizable = true;

		public TableColumnWidthAttribute(int width, bool resizable = true)
		{
			Width = width;
			Resizable = resizable;
		}
	}
}
