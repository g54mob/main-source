using System;

namespace Aggro.Core
{
	[AttributeUsage(AttributeTargets.Field)]
	public class SheetsValueAttribute : Attribute
	{
		public readonly string header;

		public bool allowExport = true;

		public SheetsValueAttribute(string header)
		{
			this.header = header;
		}
	}
}
