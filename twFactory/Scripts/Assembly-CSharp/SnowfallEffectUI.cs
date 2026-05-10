using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnowfallEffectUI : UIListElement
{
	public class FSnowfallEffectUIData
	{
		public GameplayEffectData geData;

		public bool isPositiveEffect;

		public FSnowfallEffectUIData(GameplayEffectData geData, bool isPositiveEffect)
		{
			this.geData = geData;
			this.isPositiveEffect = isPositiveEffect;
		}
	}

	[SerializeField]
	private Image image;

	[SerializeField]
	private TextMeshProUGUI description;

	[SerializeField]
	private Color positiveEffectColor;

	[SerializeField]
	private Color negativeEffectColor;

	[SerializeField]
	private TooltipComponent_detailedText tooltip;

	public override void LoadData()
	{
		FSnowfallEffectUIData fSnowfallEffectUIData = (FSnowfallEffectUIData)base.Data;
		image.sprite = fSnowfallEffectUIData.geData.Icon;
		image.color = (fSnowfallEffectUIData.isPositiveEffect ? positiveEffectColor : negativeEffectColor);
		if ((bool)description)
		{
			description.text = fSnowfallEffectUIData.geData.Description;
		}
		if ((bool)tooltip)
		{
			tooltip.HeaderText = fSnowfallEffectUIData.geData.DisplayName;
			tooltip.BodyText = fSnowfallEffectUIData.geData.Description;
		}
	}
}
