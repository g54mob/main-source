using System;

namespace ymLib
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ExcelAssetAttribute : Attribute
	{
		public string AssetPath { get; set; }

		public string MstName { get; set; }

		public bool LogOnImport { get; set; }
	}
}
