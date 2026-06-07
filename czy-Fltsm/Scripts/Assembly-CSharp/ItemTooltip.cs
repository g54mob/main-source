using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemTooltip : Tooltip
{
	[SerializeField]
	[Tooltip("The tooltip message shown when no valid ItemProperties have been set.")]
	private LocalizedString _fallbackTooltip;

	private ItemProperties _properties;

	public void Initialize(ItemProperties properties)
	{
		_properties = properties;
		LocalizedText = (_properties ? ((LocalizedString)_properties.LocalizedName) : _fallbackTooltip);
	}

	public void Initialize(LocalizedString tooltip)
	{
		_properties = null;
		LocalizedText = tooltip;
	}

	public override string ParsedText()
	{
		string text = (((string)LocalizedText == null) ? LocalizedText.mTerm : LocalizedText.ToString());
		text = "<style=\"Tooltip Name\">" + text + "</style>";
		if (_properties != null)
		{
			string text2 = Regex.Replace(GameManager.Settings.ItemSettings.CategoryText, "%CATEGORY%", _properties.ItemType.Name.ToString(), RegexOptions.IgnoreCase);
			text += "<line-height=80%>";
			text = text + "\n<i><b><color=#" + ColorUtility.ToHtmlStringRGBA(_properties.ItemType.LabelColor) + ">" + text2 + "</color></b></i>";
			text += "</line-height>";
			if (_properties.Quality != null)
			{
				string text3 = Regex.Replace(GameManager.Settings.ItemSettings.QualityText, "%QUALITY%", _properties.Quality.Name.ToString(), RegexOptions.IgnoreCase);
				text = text + "\n" + text3;
			}
			if (Item.ContainsTagSet(Item.Tags.Food | Item.Tags.Drink, _properties.Tags))
			{
				text = text + "\n" + Regex.Replace(GameManager.Settings.ItemSettings.PollutionText, "%POLLUTION%", _properties.ConsumptionPollution.ToString(), RegexOptions.IgnoreCase);
			}
		}
		return text;
	}
}
