using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

public static class ClassToCsvConverter
{
	public static string ToCsv<T>(T data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = "";
		string text2 = "";
		FieldInfo[] fields = data.GetType().GetFields();
		foreach (FieldInfo obj in fields)
		{
			string name = obj.Name;
			object value = obj.GetValue(data);
			text = text + name + ",";
			if (value is int num)
			{
				text2 = text2 + num + ",";
			}
			else if (value is float num2)
			{
				text2 = text2 + num2.ToString("0.##", CultureInfo.InvariantCulture) + ",";
			}
			else if (value is string)
			{
				text2 += $"{value},";
			}
			else if (value is bool flag)
			{
				text2 = text2 + flag + ",";
			}
			else if (value is List<string> values)
			{
				text2 = text2 + string.Join("|", values) + ",";
			}
			else if (value is Dictionary<string, float> dict)
			{
				text2 = text2 + string.Join("|", DictionaryToString(dict)) + ",";
			}
		}
		text.Trim(',');
		text2.Trim(',');
		stringBuilder.AppendLine(text);
		stringBuilder.AppendLine(text2);
		return stringBuilder.ToString();
	}

	private static List<string> DictionaryToString(Dictionary<string, float> dict)
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, float> item in dict)
		{
			list.Add(item.Key + ":" + item.Value.ToString("0.##", CultureInfo.InvariantCulture));
		}
		return list;
	}
}
