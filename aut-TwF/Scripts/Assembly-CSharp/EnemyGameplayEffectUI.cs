using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGameplayEffectUI : MonoBehaviour
{
	[SerializeField]
	private GameplayEffectData GEDataToTrack;

	[SerializeField]
	private GameObject uiContainer;

	[SerializeField]
	private Image geImage;

	[SerializeField]
	private TextMeshProUGUI stacksText;

	[SerializeField]
	private bool hideIfInactive = true;

	[SerializeField]
	private Color defaultColor = Color.white;

	[SerializeField]
	private Color inactiveColor = Color.black;

	private LayoutElement LayoutElement;

	private GameplayEffectsComponent gameplayEffectsComponent;

	public event Action<bool> onVisibilityChanged;

	private void Awake()
	{
		LayoutElement = GetComponent<LayoutElement>();
		ShowDotUI(show: false);
	}

	private void Start()
	{
		TooltipComponent_detailedText component = GetComponent<TooltipComponent_detailedText>();
		if ((bool)component)
		{
			component.HeaderText = GEDataToTrack.DisplayName;
			component.BodyText = GEDataToTrack.Description;
		}
	}

	public void SetupGameplayEffectComponent(GameplayEffectsComponent gameplayEffectsComponent)
	{
		if ((bool)this.gameplayEffectsComponent)
		{
			this.gameplayEffectsComponent.onEffectAdded -= OnEffectAdded;
			this.gameplayEffectsComponent.onEffectRemoved -= OnEffectRemoved;
			ShowDotUI(show: false);
		}
		if ((bool)gameplayEffectsComponent)
		{
			this.gameplayEffectsComponent = gameplayEffectsComponent;
			this.gameplayEffectsComponent.onEffectAdded += OnEffectAdded;
			this.gameplayEffectsComponent.onEffectRemoved += OnEffectRemoved;
			GameplayEffect gameplayEffect = this.gameplayEffectsComponent.FindEffect(GEDataToTrack);
			if (gameplayEffect != null)
			{
				OnEffectAdded(gameplayEffect);
			}
		}
	}

	public bool IsVisible()
	{
		return uiContainer.activeSelf;
	}

	private void OnDestroy()
	{
		if ((bool)gameplayEffectsComponent)
		{
			gameplayEffectsComponent.onEffectAdded -= OnEffectAdded;
			gameplayEffectsComponent.onEffectRemoved -= OnEffectRemoved;
		}
	}

	private void ShowDotUI(bool show)
	{
		if (show)
		{
			LayoutElement.ignoreLayout = false;
			uiContainer.SetActive(value: true);
			geImage.color = defaultColor;
		}
		else if (hideIfInactive)
		{
			LayoutElement.ignoreLayout = true;
			uiContainer.SetActive(value: false);
		}
		else
		{
			geImage.color = inactiveColor;
			stacksText.text = "";
		}
		this.onVisibilityChanged?.Invoke(show);
	}

	private void OnEffectAdded(GameplayEffect effect)
	{
		if (effect.EffectData == GEDataToTrack)
		{
			effect.onStacksChanged += OnStacksChanged;
			ShowDotUI(show: true);
			SetStacks(effect.CurrentStacks);
		}
	}

	private void OnEffectRemoved(GameplayEffect effect)
	{
		if (effect.EffectData == GEDataToTrack)
		{
			effect.onStacksChanged -= OnStacksChanged;
			ShowDotUI(show: false);
		}
	}

	private void OnStacksChanged(int newStacks, int oldStacks)
	{
		SetStacks(newStacks);
	}

	private void SetStacks(int amount)
	{
		stacksText.text = amount.ToString();
	}
}
