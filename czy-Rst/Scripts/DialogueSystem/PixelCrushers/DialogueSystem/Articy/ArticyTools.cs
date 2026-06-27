using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PixelCrushers.DialogueSystem.Articy
{
	public static class ArticyTools
	{
		public const string SubtableFieldPrefix = "SUBTABLE__";

		public static bool convertMarkupToRichText = true;

		private static string[] htmlTags = new string[18]
		{
			"<html>", "<head>", "<style>", "#s0", "{text-align:left;}", "#s1", "{font-size:11pt;}", "</style>", "</head>", "<body>",
			"<p>", "<p id=\"s0\">", "<span id=\"s1\">", "</span>", "</p>", "<br/>", "</body>", "</html>"
		};

		private const RegexOptions Options = RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant;

		private static readonly Regex StylesRegex = new Regex("<style>(?<styles>.*?)</style>", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

		private static readonly Regex StyleRegex = new Regex("#(?<id>s[1-9]\\d*) {(?<style>.*?)}", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

		private static readonly Regex BoldRegex = new Regex("font-weight\\s*?:\\s*?bold", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

		private static readonly Regex ItalicRegex = new Regex("font-style\\s*?:\\s*?italic", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

		private static readonly Regex ColorRegex = new Regex("color\\s*?:\\s*?(?<color>#\\w{6})", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

		private static readonly Regex TextRegex = new Regex("<p id=\"s0\">(?<text>.*?)</p>", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

		private static readonly Regex PartsRegex = new Regex("<span id=\"(?<id>s[1-9]\\d*)\">(?<text>.*?)</span>", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

		public static bool DataContainsSchemaId(string xmlData, string schemaId)
		{
			StringReader stringReader = new StringReader(xmlData);
			if (stringReader != null)
			{
				for (int i = 0; i < 5; i++)
				{
					string text = stringReader.ReadLine();
					if (!string.IsNullOrEmpty(text) && text.Contains(schemaId))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static string RemoveHtml(string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				if (convertMarkupToRichText)
				{
					s = ReplaceMarkup(s);
				}
				string[] array = htmlTags;
				foreach (string oldValue in array)
				{
					s = s.Replace(oldValue, string.Empty);
				}
				if (s.Contains("&#"))
				{
					s = ReplaceHtmlCharacterCodes(s);
				}
				s = s.Replace("&quot;", "\"");
				s = s.Replace("&amp;", "&");
				s = s.Replace("&lt;", "<");
				s = s.Replace("&gt;", ">");
				s = s.Replace("&nbsp;", " ");
				s = s.Trim();
			}
			return s;
		}

		public static string ReplaceHtmlCharacterCodes(string s)
		{
			return new Regex("&#[0-9]+;").Replace(s, (Match match) => (!int.TryParse(match.Value.Substring(2, match.Value.Length - 3), out var result)) ? match.Value : char.ConvertFromUtf32(result).ToString());
		}

		private static string ReplaceMarkup(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}
			return ConvertToRichText(s);
		}

		private static string ConvertToRichText(string s)
		{
			s = s.Replace("&#39;", "'");
			if (!StylesRegex.IsMatch(s))
			{
				return s;
			}
			string value = StylesRegex.Match(s).Value;
			var source = from Match match in StyleRegex.Matches(value)
				select new
				{
					Id = match.Groups["id"].Value,
					Style = match.Groups["style"].Value
				};
			var styles = source.Select(style => new
			{
				Id = style.Id,
				Bold = BoldRegex.IsMatch(style.Style),
				Italic = ItalicRegex.IsMatch(style.Style),
				Color = ColorRegex.Match(style.Style).Groups["color"].Value
			});
			MatchCollection matchCollection = TextRegex.Matches(s);
			List<string> list = new List<string>();
			foreach (object item in matchCollection)
			{
				string[] value2 = (from Match match in PartsRegex.Matches(item.ToString())
					select new
					{
						StyleId = match.Groups["id"].Value,
						Text = match.Groups["text"].Value
					}).Select(anon2 =>
				{
					var anon = styles.First(style => style.Id == anon2.StyleId);
					return ApplyStyle(anon2.Text, anon.Bold, anon.Italic, anon.Color);
				}).ToArray();
				string text = string.Join(string.Empty, value2);
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			return string.Join("\n", list.ToArray());
		}

		private static string ApplyStyle(string innerText, bool bold, bool italic, string color)
		{
			StringBuilder builder = new StringBuilder(innerText);
			if (bold)
			{
				WrapInTag(ref builder, "b");
			}
			if (italic)
			{
				WrapInTag(ref builder, "i");
			}
			if (color != string.Empty)
			{
				WrapInTag(ref builder, "color", color);
			}
			return builder.ToString();
		}

		private static void WrapInTag(ref StringBuilder builder, string tag, string value = "")
		{
			builder.Insert(0, (value != string.Empty) ? $"<{tag}={value}>" : $"<{tag}>");
			builder.Append($"</{tag}>");
		}

		public static bool IsQuestStateArticyPropertyName(string propertyName)
		{
			if (!string.Equals(propertyName, "State"))
			{
				return Regex.Match(propertyName, "^Entry_[0-9]+_State").Success;
			}
			return true;
		}

		public static string EnumValueToQuestState(int enumValue, string stringValue)
		{
			if (string.Equals("unassigned", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Unassigned);
			}
			if (string.Equals("active", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Active);
			}
			if (string.Equals("success", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Success);
			}
			if (string.Equals("failure", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Failure);
			}
			if (string.Equals("abandoned", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Abandoned);
			}
			if (string.Equals("grantable", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.Grantable);
			}
			if (string.Equals("returntonpc", stringValue, StringComparison.OrdinalIgnoreCase))
			{
				return QuestLog.StateToString(QuestState.ReturnToNPC);
			}
			switch (enumValue)
			{
			case 1:
				return QuestLog.StateToString(QuestState.Unassigned);
			case 2:
				return QuestLog.StateToString(QuestState.Active);
			case 3:
				return QuestLog.StateToString(QuestState.Success);
			case 4:
				return QuestLog.StateToString(QuestState.Failure);
			case 5:
				return QuestLog.StateToString(QuestState.Abandoned);
			case 6:
				return QuestLog.StateToString(QuestState.Grantable);
			case 7:
				return QuestLog.StateToString(QuestState.ReturnToNPC);
			default:
			{
				string[] names = Enum.GetNames(typeof(QuestState));
				foreach (string text in names)
				{
					if (string.Equals(text, stringValue, StringComparison.OrdinalIgnoreCase))
					{
						return text.Substring(0, 1).ToLowerInvariant() + text.Substring(1);
					}
				}
				return QuestLog.StateToString(QuestState.Unassigned);
			}
			}
		}

		public static void InitializeLuaSubtables()
		{
			if (!(DialogueManager.masterDatabase == null))
			{
				InitializeLuaSubtablesForAsset("Actor", DialogueManager.masterDatabase.actors);
				InitializeLuaSubtablesForAsset("Item", DialogueManager.masterDatabase.items);
			}
		}

		private static void InitializeLuaSubtablesForAsset<T>(string tableName, List<T> assets) where T : Asset
		{
			for (int i = 0; i < assets.Count; i++)
			{
				T val = assets[i];
				for (int j = 0; j < val.fields.Count; j++)
				{
					Field field = val.fields[j];
					if (!field.title.StartsWith("SUBTABLE__"))
					{
						continue;
					}
					string s = field.title.Substring("SUBTABLE__".Length);
					string text = tableName + "[\"" + DialogueLua.StringToTableIndex(val.Name) + "\"]." + DialogueLua.StringToTableIndex(s) + " = { ";
					if (!string.IsNullOrEmpty(field.value.Trim()))
					{
						string[] array = field.value.Split(';');
						foreach (string text2 in array)
						{
							Asset asset = FindAssetByArticyId(text2);
							text = ((asset == null) ? (text + "\"" + text2 + "\"") : (text + ((asset is Actor) ? "Actor" : "Item") + "[\"" + DialogueLua.StringToTableIndex(asset.Name) + "\"]"));
							text += ", ";
						}
					}
					text += "}";
					Lua.Run(text, DialogueDebug.logInfo);
					Lua.Run(tableName + "[\"" + DialogueLua.StringToTableIndex(val.Name) + "\"]." + DialogueLua.StringToFieldName(field.title) + " = nil", debug: true);
				}
			}
		}

		public static Asset FindAssetByArticyId(string articyId)
		{
			if (DialogueManager.masterDatabase == null)
			{
				return null;
			}
			Asset asset = FindAssetInListByArticyId(DialogueManager.masterDatabase.actors, articyId);
			if (asset != null)
			{
				return asset;
			}
			asset = FindAssetInListByArticyId(DialogueManager.masterDatabase.items, articyId);
			if (asset != null)
			{
				return asset;
			}
			return null;
		}

		private static Asset FindAssetInListByArticyId<T>(List<T> assets, string articyId) where T : Asset
		{
			if (DialogueManager.masterDatabase == null)
			{
				return null;
			}
			for (int i = 0; i < assets.Count; i++)
			{
				T val = assets[i];
				if (string.Equals(articyId, val.LookupValue("Articy Id")))
				{
					return val;
				}
			}
			return null;
		}
	}
}
