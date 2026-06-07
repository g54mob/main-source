using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonStylesApplier : StylesApplierBase
{
	public enum ButtonType
	{
		Text = 0,
		Icon = 1,
		IconText = 2
	}

	public enum AudioType
	{
		Full = 0,
		Click = 1
	}

	[SerializeField]
	private ButtonType buttonType;

	[SerializeField]
	private AudioType audioType;

	[SerializeField]
	private string prefixIconText;

	[SerializeField]
	private string suffixIconText;

	private Button button;

	private ButtonAudioEffect buttonAudioEffect;

	private TextMeshProUGUI label;

	private NormalTooltipTrigger normalTooltipTrigger;

	private FixedTooltipTrigger fixedTooltipTrigger;

	public override void Initialize()
	{
		button = GetComponent<Button>();
		buttonAudioEffect = GetComponent<ButtonAudioEffect>();
		if (buttonType == ButtonType.IconText)
		{
			label = GetComponentsInChildren<TextMeshProUGUI>(includeInactive: true)[1];
		}
		else
		{
			label = GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
		}
		normalTooltipTrigger = GetComponent<NormalTooltipTrigger>();
		fixedTooltipTrigger = GetComponent<FixedTooltipTrigger>();
	}

	public override void UpdateStyles()
	{
		if (buttonAudioEffect != null)
		{
			buttonAudioEffect.Volume = gameStylesData.volumeStylesData.uiVolume;
			if (audioType == AudioType.Full)
			{
				buttonAudioEffect.MouseOverClip = gameStylesData.buttonMouseOverClip;
				buttonAudioEffect.MouseClickClip = gameStylesData.buttonMouseClickClip;
			}
			else if (audioType == AudioType.Click)
			{
				buttonAudioEffect.MouseOverClip = null;
				buttonAudioEffect.MouseClickClip = gameStylesData.iconMouseClickClip;
			}
		}
	}

	public override void UpdateTexts()
	{
		if (string.IsNullOrEmpty(baseId))
		{
			return;
		}
		if (label != null && (buttonType == ButtonType.Text || buttonType == ButtonType.IconText))
		{
			string id = "button.text." + baseId;
			if (languages.HasText(id))
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (!string.IsNullOrEmpty(prefixIconText))
				{
					stringBuilder.Append(Regex.Unescape(prefixIconText)).Append("  ");
				}
				stringBuilder.Append(languages.GetText(id));
				if (!string.IsNullOrEmpty(suffixIconText))
				{
					stringBuilder.Append("  ").Append(Regex.Unescape(suffixIconText));
				}
				label.text = stringBuilder.ToString();
			}
		}
		if (normalTooltipTrigger != null)
		{
			string id2 = "button.tooltip." + baseId;
			normalTooltipTrigger.HelpText = languages.GetText(id2, normalTooltipTrigger.HelpText);
		}
		if (fixedTooltipTrigger != null)
		{
			string id3 = "button.tooltip." + baseId;
			fixedTooltipTrigger.TooltipText = languages.GetText(id3, fixedTooltipTrigger.TooltipText);
		}
	}
}
