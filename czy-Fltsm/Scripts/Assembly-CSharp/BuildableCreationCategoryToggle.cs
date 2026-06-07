using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildableCreationCategoryToggle : AnimatedToggle
{
	public enum State
	{
		Disabled = 0,
		Enabled = 1,
		ConstructionAvailable = 2
	}

	[Header("Buildable Creation Category Toggle")]
	[SerializeField]
	private BuildableToggle _buildableTogglePrefab;

	[SerializeField]
	private StoredBuildableToggle _storedBuildableTogglePrefab;

	[SerializeField]
	private Image _iconImage;

	[SerializeField]
	private Tooltip _tooltip;

	[Header("Animation")]
	[SerializeField]
	[Tooltip("The parameter that is toggled when there are buildables in this category that can be build.")]
	private string _constructionAvailableParameter = "ConstructionAvailable";

	private State _state;

	public BuildableCategory Category { get; private set; }

	public SelectableGroup BuildableToggleGroup { get; private set; }

	public List<BuildableToggle> BuildableToggles { get; private set; }

	protected override void OnEnable()
	{
		base.OnEnable();
		base.animator.SetBool(_constructionAvailableParameter, _state == State.ConstructionAvailable);
		OnValueChanged(base.isOn);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.UnlockableUnlocked, OnUnlockableUnlocked);
	}

	public void Initialize(BuildableCategory category, SelectableGroup buildableToggleGroup, bool isOn)
	{
		Category = category;
		BuildableToggleGroup = buildableToggleGroup;
		BuildableToggles = new List<BuildableToggle>();
		_iconImage.sprite = category.IconSprite;
		_tooltip.LocalizedText = category.Name;
		base.isOn = isOn;
		OnValueChanged(isOn);
		GameEventDispatcher.AddListener(GameEventType.UnlockableUnlocked, OnUnlockableUnlocked);
	}

	public bool TryAddBuildableToggle(IPlaceable placeable)
	{
		return TryAddBuildableToggle(placeable, _buildableTogglePrefab);
	}

	public bool TryAddStoredBuildableToggle(IPlaceable placeable)
	{
		if (TryAddBuildableToggle(placeable, _storedBuildableTogglePrefab))
		{
			base.isOn = false;
			return true;
		}
		return false;
	}

	private bool TryAddBuildableToggle(IPlaceable placeable, BuildableToggle prefab)
	{
		if (placeable.Category != Category)
		{
			return false;
		}
		BuildableToggle buildableToggle = Object.Instantiate(prefab, BuildableToggleGroup.transform);
		if (placeable is BuildableProperties buildableProperties && buildableProperties == GameManager.Settings.BuildableSettings.EnergyPoleBuildableProperties)
		{
			placeable = GameManager.Settings.BuildableSettings.EnergyPoleDecorationProperties;
		}
		buildableToggle.Initialize(placeable);
		BuildableToggles.Add(buildableToggle);
		return true;
	}

	public void UpdateState()
	{
		SetState(ReturnState());
	}

	public void SetEnabled(bool enabled, bool isOn = false)
	{
		base.gameObject.SetActive(enabled);
		base.isOn = isOn;
	}

	private void SetState(State stateToSet)
	{
		if (stateToSet != _state)
		{
			_state = stateToSet;
			switch (_state)
			{
			case State.Disabled:
				base.gameObject.SetActive(value: false);
				base.animator.SetBool(_constructionAvailableParameter, value: false);
				base.isOn = false;
				break;
			case State.Enabled:
				base.gameObject.SetActive(value: true);
				base.animator.SetBool(_constructionAvailableParameter, value: false);
				break;
			case State.ConstructionAvailable:
				base.gameObject.SetActive(value: true);
				base.animator.SetBool(_constructionAvailableParameter, value: true);
				break;
			}
		}
	}

	private void OnUnlockableUnlocked(GameEvent gameEvent)
	{
		if (gameEvent is UnlockableEvent { Unlockable: IPlaceable unlockable } && unlockable.Category == Category)
		{
			UpdateState();
		}
	}

	protected override void OnValueChanged(bool value)
	{
		base.OnValueChanged(value);
		if ((bool)BuildableToggleGroup)
		{
			BuildableToggleGroup.gameObject.SetActive(value);
			CheckBuildableToggleRequirements();
		}
	}

	private void CheckBuildableToggleRequirements()
	{
		foreach (BuildableToggle buildableToggle in BuildableToggles)
		{
			buildableToggle.CheckRequirements();
		}
	}

	private State ReturnState()
	{
		State result = State.Disabled;
		foreach (BuildableToggle buildableToggle in BuildableToggles)
		{
			buildableToggle.CheckRequirementsImmediately();
			if (buildableToggle.Placeable.IsCategoryEnabled)
			{
				result = State.Enabled;
				if (buildableToggle.Interactable)
				{
					return State.ConstructionAvailable;
				}
			}
		}
		return result;
	}
}
