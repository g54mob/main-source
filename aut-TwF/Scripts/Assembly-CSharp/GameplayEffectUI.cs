using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayEffectUI : UIListElement
{
	[SerializeField]
	private Image effectImage;

	[SerializeField]
	private TextMeshProUGUI stacksAmountText;

	[SerializeField]
	private TooltipComponent_detailedText tooltipComponent;

	private GameplayEffect effect;

	public override void LoadData()
	{
		effect = base.Data as GameplayEffect;
		effectImage.sprite = effect.EffectData.Icon;
		tooltipComponent.HeaderText = effect.EffectData.DisplayName;
		tooltipComponent.BodyText = effect.EffectData.Description;
		UpdateStacks();
		effect.onStacksChanged += OnStacksChanged;
	}

	private void UpdateStacks()
	{
		stacksAmountText.text = ((effect.CurrentStacks > 1) ? effect.CurrentStacks.ToString() : "");
	}

	private void OnDestroy()
	{
		effect.onStacksChanged -= OnStacksChanged;
	}

	private void OnStacksChanged(int currentStacks, int oldStacks)
	{
		UpdateStacks();
	}
}
