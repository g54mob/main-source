using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : UIListElement
{
	[SerializeField]
	private Image effectImage;

	[SerializeField]
	private TooltipComponent_detailedText tooltipComponent;

	private Ability ability;

	public override void LoadData()
	{
		ability = base.Data as Ability;
		effectImage.sprite = ability.Splash;
		tooltipComponent.HeaderText = ability.AbilityName;
		tooltipComponent.BodyText = ability.Description;
	}
}
