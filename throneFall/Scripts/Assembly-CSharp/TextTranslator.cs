using System.Text;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

public class TextTranslator : MonoBehaviour
{
	[SerializeField]
	private BalancingParameters balancingParameters;

	public static TextTranslator instance;

	public static InputActionGlyph.InputPriority inputPriority;

	private void Awake()
	{
		instance = this;
	}

	public static string Translate(string locaKey, bool fixForRTL = true, int maxLineLenghtForRTL = 0, bool ignoreRTLNumbers = true, bool applyParameters = true)
	{
		if (locaKey == "")
		{
			return "";
		}
		try
		{
			string text = LocalizationManager.GetTranslation(locaKey, fixForRTL, maxLineLenghtForRTL, ignoreRTLNumbers, applyParameters);
			foreach (Match item in new Regex("\\{(.+?)\\}").Matches(text))
			{
				string text2 = item.Groups[1].Value;
				bool flag = text2.EndsWith(".NOMIN");
				if (flag)
				{
					text2 = text2.Substring(0, text2.Length - 6);
				}
				string value;
				if (text2.StartsWith("ACTION."))
				{
					string input = text2.Substring(7);
					input = ConvertToSpacedString(input);
					input = InputActionGlyph.GetActionGlyph(input, inputPriority);
					text = text.Replace(item.Value, input);
				}
				else if (instance.balancingParameters.parameters.TryGetValue(text2.Replace(" ", ""), out value))
				{
					if (flag && value.StartsWith("-"))
					{
						value = value.Substring(1);
					}
					text = text.Replace(item.Value, value);
				}
				else
				{
					Debug.LogWarning("Key " + text2 + " not found in balancing parameters.");
				}
			}
			return text;
		}
		catch
		{
			return locaKey;
		}
	}

	public static string ConvertToSpacedString(string input)
	{
		if (string.IsNullOrEmpty(input) || input.Contains(' '))
		{
			return input;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(input[0]);
		for (int i = 1; i < input.Length; i++)
		{
			if (char.IsUpper(input[i]))
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append(input[i]);
		}
		return stringBuilder.ToString();
	}

	public static string TranslateAndInsertLevelNumber(string locaKey, int targetLevel, bool highlighted, bool fixForRTL = true, int maxLineLenghtForRTL = 0, bool ignoreRTLNumbers = true, bool applyParameters = true)
	{
		if (locaKey == "")
		{
			return "";
		}
		try
		{
			string text = LocalizationManager.GetTranslation(locaKey, fixForRTL, maxLineLenghtForRTL, ignoreRTLNumbers, applyParameters);
			foreach (Match item in new Regex("\\{(.+?)\\}").Matches(text))
			{
				string value = item.Groups[1].Value;
				string value2;
				if (value.Contains("ACTION."))
				{
					string actionName = value.Replace("ACTION.", "");
					actionName = InputActionGlyph.GetActionGlyph(actionName, inputPriority);
					text = text.Replace(item.Value, actionName);
				}
				else if (instance.balancingParameters.parameters.TryGetValue(value, out value2))
				{
					text = text.Replace(item.Value, value2);
				}
				else if (value.Contains("LEVEL"))
				{
					text = (highlighted ? text.Replace(item.Value, "<style=Highlighted>" + LocalizationManager.GetTranslation("Menu/Level") + " <style=\"Body Numerals\">" + targetLevel + "</style></style>") : text.Replace(item.Value, LocalizationManager.GetTranslation("Menu/Level") + " <style=\"Body Numerals\">" + targetLevel + "</style>"));
				}
				else
				{
					Debug.LogWarning("Key " + value + " not found in balancing parameters.");
				}
			}
			return text;
		}
		catch
		{
			return locaKey;
		}
	}

	public static string TranslateAndInsertMapName(string locaKey, string mapName, bool highlighted, bool fixForRTL = true, int maxLineLenghtForRTL = 0, bool ignoreRTLNumbers = true, bool applyParameters = true)
	{
		if (locaKey == "")
		{
			return "";
		}
		try
		{
			string text = LocalizationManager.GetTranslation(locaKey, fixForRTL, maxLineLenghtForRTL, ignoreRTLNumbers, applyParameters);
			foreach (Match item in new Regex("\\{(.+?)\\}").Matches(text))
			{
				string value = item.Groups[1].Value;
				string value2;
				if (value.Contains("ACTION."))
				{
					string actionName = value.Replace("ACTION.", "");
					actionName = InputActionGlyph.GetActionGlyph(actionName, inputPriority);
					text = text.Replace(item.Value, actionName);
				}
				else if (instance.balancingParameters.parameters.TryGetValue(value, out value2))
				{
					text = text.Replace(item.Value, value2);
				}
				else if (value.Contains("MAP"))
				{
					text = (highlighted ? text.Replace(item.Value, "<style=Highlighted>" + LocalizationManager.GetTranslation("Map Name/" + mapName) + "</style></style>") : text.Replace(item.Value, LocalizationManager.GetTranslation("Map Name/" + mapName) + "</style>"));
				}
				else
				{
					Debug.LogWarning("Key " + value + " not found in balancing parameters.");
				}
			}
			return text;
		}
		catch
		{
			return locaKey;
		}
	}
}
