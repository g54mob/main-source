using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class CharConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (text != null && text.Length > 1)
			{
				text = text.Trim();
			}
			if (char.TryParse(text, out var result))
			{
				return result;
			}
			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
