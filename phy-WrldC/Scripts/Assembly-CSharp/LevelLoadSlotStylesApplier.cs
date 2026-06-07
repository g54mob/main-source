using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoadSlotStylesApplier : StylesApplierBase
{
	private ButtonAudioEffect buttonAudioEffect;

	private TextMeshProUGUI nameText;

	private LevelLoadSlotView levelLoadSlotView;

	public override void Initialize()
	{
		levelLoadSlotView = GetComponent<LevelLoadSlotView>();
		buttonAudioEffect = GetComponent<ButtonAudioEffect>();
		nameText = base.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
	}

	public override void UpdateStyles()
	{
		if (levelLoadSlotView != null)
		{
			levelLoadSlotView.LevelNameColor = gameStylesData.brightBackground;
			levelLoadSlotView.LevelNumberColor = gameStylesData.brightText;
			levelLoadSlotView.BestTimeColor = gameStylesData.blue;
			levelLoadSlotView.DisabledColor = gameStylesData.lightBackground;
		}
		if (buttonAudioEffect != null)
		{
			buttonAudioEffect.Volume = gameStylesData.volumeStylesData.uiVolume;
			buttonAudioEffect.MouseOverClip = gameStylesData.levelSlotMouseOverClip;
			buttonAudioEffect.MouseClickClip = gameStylesData.levelSlotMouseClickClip;
		}
	}

	public override void UpdateTexts()
	{
		if (levelLoadSlotView != null)
		{
			string text = languages.GetText("level.name." + baseId, nameText.text);
			nameText.text = (levelLoadSlotView.IsInteractible ? text : "???");
		}
	}
}
