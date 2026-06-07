using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DV.Scenarios.Common;
using DV.UserManagement.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.UnityConverters.Math;

namespace DV.Scenarios
{
	internal static class Util
	{
		public static JsonSerializerSettings JsonSerializerSettings { get; } = new JsonSerializerSettings
		{
			Converters = 
			{
				(JsonConverter)new Vector3Converter(),
				(JsonConverter)new StringEnumConverter(),
				(JsonConverter)new AbstractConverter<Difficulty, IDifficulty>(),
				(JsonConverter)new AbstractConverter<Scenario, IScenario>(),
				(JsonConverter)new AbstractConverter<Train, ITrain>(),
				(JsonConverter)new AbstractConverter<Car, ICar>()
			}
		};

		public static JsonSerializer JsonSerializer { get; } = JsonSerializer.Create(JsonSerializerSettings);

		internal static string GetAutoIncrement(string name, List<string> existingNames, Dictionary<string, string> localizedValues = null)
		{
			Regex regex = new Regex("(.+) +\\((\\d+)\\)");
			name = name.Trim();
			Match match = regex.Match(name);
			if (match.Success)
			{
				name = match.Groups[1].Value.Trim();
			}
			name = TryLocalizeName(name);
			existingNames = (from n in existingNames
				where n != null
				select n.Trim()).ToList();
			Match match2 = (from n in existingNames
				select regex.Match(n) into m
				where m.Success && m.Groups[1].Value.Trim().ToLower() == name.ToLower()
				orderby int.Parse(m.Groups[2].Value) descending
				select m).FirstOrDefault();
			if (match2 != null)
			{
				return $"{match2.Groups[1].Value} ({int.Parse(match2.Groups[2].Value) + 1})";
			}
			if (!existingNames.Select(TryLocalizeName).Any((string n) => n.ToLower() == name.ToLower()))
			{
				return name;
			}
			return name.TrimEnd() + " (2)";
			string TryLocalizeName(string input)
			{
				if (localizedValues != null && localizedValues.TryGetValue(input, out var value))
				{
					return value;
				}
				return input;
			}
		}

		internal static string GetSuggestedFileName(IScenariosThing thing, IStorageProvider storage)
		{
			string text = GenerateSlug((thing.Name == null) ? thing.GetType().Name : thing.Name.Trim());
			int num = 0;
			string text2;
			while (true)
			{
				text2 = ((num != 0) ? $"{text}_{num}" : (text ?? ""));
				if (string.IsNullOrWhiteSpace(text2))
				{
					text2 = "_";
				}
				text2 = text2 + "." + thing.FileExtension;
				if (!storage.FileExists(text2))
				{
					break;
				}
				num++;
			}
			return text2;
		}

		internal static string GenerateSlug(string str)
		{
			str = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(str));
			str = str.ToLower();
			str = Regex.Replace(str, "[^a-z0-9\\s-]", "");
			str = Regex.Replace(str, "\\s+", " ").Trim();
			str = str.Substring(0, (str.Length <= 40) ? str.Length : 40).Trim();
			str = Regex.Replace(str, "\\s", "_");
			str = Regex.Replace(str, "_+", "_").Trim();
			return str;
		}
	}
}
