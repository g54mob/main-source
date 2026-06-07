using UnityEngine;
using UnityEngine.UI;

public class TowerTargetProviderUI : UIListElement
{
	[SerializeField]
	private Image targetProviderImage;

	[SerializeField]
	private TooltipComponent_text tooltip;

	private TowerTargetProvider towerTargetProvider;

	public override void LoadData()
	{
		towerTargetProvider = base.Data as TowerTargetProvider;
		targetProviderImage.sprite = towerTargetProvider.Icon;
		tooltip.TooltipText = towerTargetProvider.DisplayName[0].ToString().ToUpper() + towerTargetProvider.DisplayName.Substring(1);
	}
}
