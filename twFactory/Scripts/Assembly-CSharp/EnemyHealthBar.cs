using System.Collections;
using UnityEngine;

[RequireComponent(typeof(WorldObjectUI))]
public class EnemyHealthBar : MonoBehaviour
{
	private const float CHECK_CHARACTER_VISIBILITY_TIME = 2f;

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

	[Space]
	[SerializeField]
	private bool hideIfUndamaged = true;

	private StatsComponent statsComponent;

	private GameplayEffectsComponent gameplayEffectsComponent;

	private bool characterHidden;

	public bool CharacterHidden
	{
		get
		{
			return characterHidden;
		}
		set
		{
			characterHidden = value;
			UpdateVisibility();
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
				GetComponent<WorldObjectUI>().SetFollowTarget(StatsComponent.gameObject);
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

	private void Start()
	{
		healthBar.onValueChanged += OnValueChanged;
		armorBar.onValueChanged += OnValueChanged;
		shieldBar.onValueChanged += OnValueChanged;
		healthBar.onMaxStatChanged += OnMaxStatChanged;
		armorBar.onMaxStatChanged += OnMaxStatChanged;
		shieldBar.onMaxStatChanged += OnMaxStatChanged;
		bleedUI.onVisibilityChanged += OnGameplayEffectUIVisibilityChanged;
		burnUI.onVisibilityChanged += OnGameplayEffectUIVisibilityChanged;
		poisonUI.onVisibilityChanged += OnGameplayEffectUIVisibilityChanged;
		slowUI.onVisibilityChanged += OnGameplayEffectUIVisibilityChanged;
		StartCoroutine(CheckCharacterVisibilityCoroutine());
		ResizeBars();
		UpdateVisibility();
	}

	private void ResizeBars()
	{
		float a = 0f;
		Vector2 sizeDelta = healthBar.GetComponent<RectTransform>().sizeDelta;
		a = Mathf.Max(a, StatsComponent.GetStat(EStats.HealthMax));
		a = Mathf.Max(a, StatsComponent.GetStat(EStats.ArmorMax));
		a = Mathf.Max(a, StatsComponent.GetStat(EStats.ShieldMax));
		healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x * (StatsComponent.GetStat(EStats.HealthMax) / a), sizeDelta.y);
		armorBar.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x * (StatsComponent.GetStat(EStats.ArmorMax) / a), sizeDelta.y);
		shieldBar.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x * (StatsComponent.GetStat(EStats.ShieldMax) / a), sizeDelta.y);
	}

	private void UpdateVisibility()
	{
		if (characterHidden)
		{
			SetHealthBarVisible(visible: false);
		}
		else
		{
			SetHealthBarVisible(!hideIfUndamaged || healthBar.Value < healthBar.MaxValue || armorBar.Value < armorBar.MaxValue || shieldBar.Value < shieldBar.MaxValue || bleedUI.IsVisible() || burnUI.IsVisible() || poisonUI.IsVisible() || slowUI.IsVisible());
		}
	}

	private void SetHealthBarVisible(bool visible)
	{
		base.transform.SetChildrenActive(visible);
	}

	private void OnValueChanged(float newValue, float oldValue)
	{
		UpdateVisibility();
		if (healthBar.Value == 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnMaxStatChanged()
	{
		ResizeBars();
	}

	private void OnGameplayEffectUIVisibilityChanged(bool visible)
	{
		UpdateVisibility();
	}

	private IEnumerator CheckCharacterVisibilityCoroutine()
	{
		WaitForSeconds wfs = new WaitForSeconds(2f);
		while (true)
		{
			bool flag = LTFunctionLibrary.GetFogOfWarController().IsPositionVisible(statsComponent.transform.position);
			if (flag && CharacterHidden)
			{
				CharacterHidden = false;
			}
			else if (!flag && !CharacterHidden)
			{
				CharacterHidden = true;
			}
			yield return wfs;
		}
	}
}
