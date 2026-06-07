using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectableUI_enemy : SelectableUI
{
	[SerializeField]
	private TextMeshProUGUI enemyNameText;

	[Header("Bars")]
	[SerializeField]
	private StatBar healthBar;

	[SerializeField]
	private StatBar armorBar;

	[SerializeField]
	private StatBar shieldBar;

	[Header("Dots")]
	[SerializeField]
	private EnemyGameplayEffectUI bleedUI;

	[SerializeField]
	private EnemyGameplayEffectUI burnUI;

	[SerializeField]
	private EnemyGameplayEffectUI poisonUI;

	[SerializeField]
	private EnemyGameplayEffectUI slowUI;

	[Header("Side Stats")]
	[SerializeField]
	private Sprite groundSprite;

	[SerializeField]
	private Sprite flyingSprite;

	[SerializeField]
	private Image typeIcon;

	[SerializeField]
	private TextMeshProUGUI speedText;

	[SerializeField]
	private TextMeshProUGUI damageText;

	[Header("Abilities & Traits")]
	[SerializeField]
	private UIList abilitiesList;

	[SerializeField]
	private GameObject abilitiesDash;

	[SerializeField]
	private UIList traitsList;

	[SerializeField]
	private GameObject traitsDash;

	private Enemy enemy;

	private StatsComponent statsComponent;

	private GameplayEffectsComponent gameplayEffectsComponent;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			enemy = SelectedObject as Enemy;
			StatsComponent = enemy.StatsComponent;
			GameplayEffectsComponent = enemy.GameplayEffectsComponent;
			healthBar.onVisibilityChange += OnStatBarVisibilityChange;
			armorBar.onVisibilityChange += OnStatBarVisibilityChange;
			shieldBar.onVisibilityChange += OnStatBarVisibilityChange;
			enemy.onDie += OnEnemyDies;
			StatsComponent.onStatChanged += OnStatChanged;
			UpdateName();
			UpdateSideStats();
			UpdateAbilities();
			UpdateTraits();
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	public StatsComponent StatsComponent
	{
		get
		{
			return statsComponent;
		}
		set
		{
			statsComponent = value;
			if ((bool)statsComponent)
			{
				healthBar.StatsComponent = StatsComponent;
				armorBar.StatsComponent = StatsComponent;
				shieldBar.StatsComponent = StatsComponent;
			}
		}
	}

	public GameplayEffectsComponent GameplayEffectsComponent
	{
		get
		{
			return gameplayEffectsComponent;
		}
		set
		{
			gameplayEffectsComponent = value;
			bleedUI.SetupGameplayEffectComponent(gameplayEffectsComponent);
			burnUI.SetupGameplayEffectComponent(gameplayEffectsComponent);
			poisonUI.SetupGameplayEffectComponent(gameplayEffectsComponent);
			slowUI.SetupGameplayEffectComponent(gameplayEffectsComponent);
		}
	}

	private void OnDestroy()
	{
		if ((bool)enemy)
		{
			enemy.onDie -= OnEnemyDies;
		}
	}

	private void UpdateName()
	{
		enemyNameText.text = enemy.Data.EnemyName;
	}

	private void UpdateSideStats()
	{
		typeIcon.sprite = (((enemy.EnemyType & Enemy.EEnemyType.Ground) > (Enemy.EEnemyType)0) ? groundSprite : flyingSprite);
		UpdateSpeedText(StatsComponent.GetStat(EStats.MovementSpeed));
		damageText.text = enemy.Damage.ToString();
	}

	private void UpdateSpeedText(float speed)
	{
		speedText.text = FunctionLibrary.RoundToDecimals(speed, 2).ToString();
	}

	private void UpdateAbilities()
	{
		List<Ability> list = enemy.AbilityManager?.GetAllAbilities(includeAutoattack: false);
		if (list != null && list.Count > 0)
		{
			abilitiesDash.gameObject.SetActive(value: false);
			abilitiesList.gameObject.SetActive(value: true);
			abilitiesList.LoadList(list);
		}
		else
		{
			abilitiesDash.gameObject.SetActive(value: true);
			abilitiesList.gameObject.SetActive(value: false);
		}
	}

	private void UpdateTraits()
	{
		List<GameplayEffectData> initialEffects = enemy.GameplayEffectsComponent.GetInitialEffects(excludeHiddenEffects: true);
		if (initialEffects != null && initialEffects.Count > 0)
		{
			traitsDash.gameObject.SetActive(value: false);
			traitsList.gameObject.SetActive(value: true);
			traitsList.LoadList(initialEffects);
		}
		else
		{
			traitsDash.gameObject.SetActive(value: true);
			traitsList.gameObject.SetActive(value: false);
		}
	}

	private void OnEnemyDies(Enemy enemy)
	{
		(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = null;
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.MovementSpeed)
		{
			UpdateSpeedText(newValue);
		}
	}

	private void OnStatBarVisibilityChange(bool visible)
	{
		if (base.gameObject.activeSelf)
		{
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}
}
