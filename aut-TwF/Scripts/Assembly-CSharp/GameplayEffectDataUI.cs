using UnityEngine;
using UnityEngine.UI;

public class GameplayEffectDataUI : UIListElement
{
	[SerializeField]
	private Image effectImage;

	[SerializeField]
	private TooltipComponent_detailedText tooltipComponent;

	private GameplayEffectData effectData;

	public override void LoadData()
	{
		effectData = base.Data as GameplayEffectData;
		effectImage.sprite = effectData.Icon;
		tooltipComponent.HeaderText = effectData.DisplayName;
		tooltipComponent.BodyText = effectData.Description;
	}
}
