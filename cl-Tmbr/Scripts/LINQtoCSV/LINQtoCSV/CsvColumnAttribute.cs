using System;
using System.Globalization;

namespace LINQtoCSV
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public class CsvColumnAttribute : Attribute
	{
		internal const int mc_DefaultFieldIndex = int.MaxValue;

		public string Name { get; set; }

		public bool CanBeNull { get; set; }

		public int FieldIndex { get; set; }

		public NumberStyles NumberStyle { get; set; }

		public string OutputFormat { get; set; }

		public int CharLength { get; set; }

		public CsvColumnAttribute()
		{
			Name = "";
			FieldIndex = int.MaxValue;
			CanBeNull = true;
			NumberStyle = NumberStyles.Any;
			OutputFormat = "G";
		}

		public CsvColumnAttribute(string name, int fieldIndex, bool canBeNull, string outputFormat, NumberStyles numberStyle, int charLength)
		{
			Name = name;
			FieldIndex = fieldIndex;
			CanBeNull = canBeNull;
			NumberStyle = numberStyle;
			OutputFormat = outputFormat;
			CharLength = charLength;
		}
	}
}
