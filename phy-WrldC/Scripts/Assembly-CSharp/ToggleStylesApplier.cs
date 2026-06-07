using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleStylesApplier : StylesApplierBase
{
	public enum ToggleType
	{
		WithoutLabel = 0,
		WithLabel = 1
	}

	public enum AudioType
	{
		Full = 0,
		OnOff = 1,
		OverOn = 2,
		On = 3
	}

	[SerializeField]
	private ToggleType toggleType;

	[Tooltip("Full = Som no mouse over e quando ativado e desativado\nOnOff = Som quando ativado e desativado\nOn = Som quando ativado")]
	[SerializeField]
	private AudioType audioType;

	[SerializeField]
	private bool isLabelBold;

	[SerializeField]
	private string prefixLabelIconText;

	[SerializeField]
	private GameObject objectWhenOn;

	[SerializeField]
	private GameObject objectWhenOff;

	[SerializeField]
	private bool shouldChangeLabelColor;

	[SerializeField]
	private Color labelIsOnColor;

	[SerializeField]
	private Color labelIsOffColor;

	private Toggle toggle;

	private ToggleAudioEffect toggleAudioEffect;

	private TextMeshProUGUI label;

	private NormalTooltipTrigger tooltipTrigger;

	public override void Initialize()
	{
		toggle = GetComponent<Toggle>();
		toggleAudioEffect = GetComponent<ToggleAudioEffect>();
		if (toggleType == ToggleType.WithLabel)
		{
			label = base.transform.FindComponent<TextMeshProUGUI>("Label", isRecursively: true);
		}
		tooltipTrigger = GetComponent<NormalTooltipTrigger>();
		toggle.onValueChanged.AddListener(SetToggleStyles);
		SetToggleStyles(toggle.isOn);
	}

	public override void UpdateStyles()
	{
		if (toggleAudioEffect != null)
		{
			toggleAudioEffect.Volume = gameStylesData.volumeStylesData.uiVolume;
			if (audioType == AudioType.Full)
			{
				toggleAudioEffect.ToggleOverClip = gameStylesData.toggleOverClip;
				toggleAudioEffect.ToggleOffClip = gameStylesData.toggleOffClip;
				toggleAudioEffect.ToggleOnClip = gameStylesData.toggleOnClip;
			}
			else if (audioType == AudioType.OnOff)
			{
				toggleAudioEffect.ToggleOverClip = null;
				toggleAudioEffect.ToggleOffClip = gameStylesData.toggleOffClip;
				toggleAudioEffect.ToggleOnClip = gameStylesData.toggleOnClip;
			}
			else if (audioType == AudioType.OverOn)
			{
				toggleAudioEffect.ToggleOverClip = gameStylesData.toggleOverClip;
				toggleAudioEffect.ToggleOffClip = null;
				toggleAudioEffect.ToggleOnClip = gameStylesData.toggleOnClip;
			}
			else if (audioType == AudioType.On)
			{
				toggleAudioEffect.ToggleOverClip = null;
				toggleAudioEffect.ToggleOffClip = null;
				toggleAudioEffect.ToggleOnClip = gameStylesData.toggleOnClip;
			}
		}
	}

	public override void UpdateTexts()
	{
		if (string.IsNullOrEmpty(baseId))
		{
			return;
		}
		if (label != null && toggleType == ToggleType.WithLabel)
		{
			string text = languages.GetText("toggle.text." + baseId, label.text);
			if (!string.IsNullOrEmpty(prefixLabelIconText))
			{
				text = Regex.Unescape(prefixLabelIconText) + "  " + text;
			}
			if (isLabelBold)
			{
				label.text = "<b>" + text + "</b>";
			}
			else
			{
				label.text = text;
			}
		}
		if (tooltipTrigger != null)
		{
			string id = "toggle.tooltip." + baseId;
			tooltipTrigger.HelpText = languages.GetText(id, tooltipTrigger.HelpText);
		}
	}

	public void SetToggleStyles(bool isOn)
	{
		if (objectWhenOn != null)
		{
			objectWhenOn.SetActive(isOn);
		}
		if (objectWhenOff != null)
		{
			objectWhenOff.SetActive(!isOn);
		}
		if (shouldChangeLabelColor)
		{
			label.color = (isOn ? labelIsOnColor : labelIsOffColor);
		}
	}

	public void SetInteractivity(bool isInteractable)
	{
		toggle.interactable = isInteractable;
		if (label != null)
		{
			label.color = new Color(label.color.r, label.color.g, label.color.b, isInteractable ? 1f : 0.5f);
		}
	}
}
