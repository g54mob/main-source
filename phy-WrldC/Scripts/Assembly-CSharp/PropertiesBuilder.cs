using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using EncryptString;

public static class PropertiesBuilder
{
	public static Properties CreateProperties(XElement xProperties)
	{
		Properties properties = new Properties();
		ConcatenateProperties(properties, xProperties);
		return properties;
	}

	public static void ConcatenateProperties(Properties properties, XElement xProperties)
	{
		if (xProperties == null)
		{
			return;
		}
		foreach (XElement item in xProperties.Elements())
		{
			properties.AddProperty(item.Name.LocalName, item.Value);
		}
	}

	public static string PopulatePropertiesCollectionFromCSVFile(GenericCollection<Properties> propCollection, string filePath, bool isFileEncrypted)
	{
		string text = File.ReadAllText(filePath);
		if (isFileEncrypted)
		{
			text = StringCipher.Decrypt(text, Util.PassPhrase);
		}
		PopulatePropertiesCollectionFromCSVString(propCollection, text);
		return Util.GetHashSHA256(text);
	}

	public static void PopulatePropertiesCollectionFromCSVString(GenericCollection<Properties> propCollection, string content)
	{
		string[] array = Regex.Split(content, "\r\n|\r|\n");
		string[] array2 = array[0].Split(';');
		int num = array2.Length;
		for (int i = 1; i < array.Length; i++)
		{
			string[] array3 = array[i].Split(';');
			if (num != array3.Length)
			{
				continue;
			}
			Properties properties = new Properties();
			bool flag = false;
			for (int j = 0; j < array3.Length; j++)
			{
				if (string.IsNullOrEmpty(array3[j]))
				{
					flag = true;
					break;
				}
				properties.AddProperty(array2[j], array3[j]);
			}
			if (!flag)
			{
				propCollection.AddItem(properties);
			}
		}
	}

	public static void PopulatePropertiesFromINIFile(Properties properties, string filePath)
	{
		using (StreamReader streamReader = new StreamReader(filePath))
		{
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine().Trim();
				if (text.Length <= 0 || text[0] == '#')
				{
					continue;
				}
				string[] array = text.Split(new char[1] { '=' }, 2);
				if (array.Length != 2)
				{
					continue;
				}
				array[0] = array[0].Trim();
				array[1] = array[1].Trim().Replace("\\n", "\n").Replace("\\r", "\r")
					.Replace("\\t", "\t");
				if (array[1] == "{")
				{
					StringBuilder stringBuilder = new StringBuilder();
					while (!streamReader.EndOfStream)
					{
						text = streamReader.ReadLine().Trim();
						if (text.Contains("}"))
						{
							break;
						}
						stringBuilder.AppendLine(text);
					}
					array[1] = stringBuilder.ToString();
				}
				properties.AddProperty(array[0], array[1]);
			}
		}
	}
}
