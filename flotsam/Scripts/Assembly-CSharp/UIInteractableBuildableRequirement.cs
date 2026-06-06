using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractableBuildableRequirement : UIInteractableRequirementBase
{
	public enum BuildableType
	{
		PropertiesList = 0,
		Producer = 1,
		ResearchStation = 2
	}

	[SerializeField]
	private BuildableType _type;

	[SerializeField]
	[ConditionalEnumHide("_type", 0, false)]
	private List<BuildableProperties> _buildableProperties;

	private Selectable _selectable;

	protected override void Awake()
	{
		base.Awake();
		_selectable = GetComponent<Selectable>();
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, UpdateInteractable);
		GameEventDispatcher.AddListener(GameEventType.BuildableSalvaged, UpdateInteractable);
	}

	private void Start()
	{
		UpdateInteractable();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, UpdateInteractable);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSalvaged, UpdateInteractable);
	}

	private void UpdateInteractable(GameEvent gameEvent = null)
	{
		base.IsMet = ReturnIsMet();
	}

	public override bool ReturnIsMet()
	{
		switch (_type)
		{
		case BuildableType.PropertiesList:
		{
			List<Buildable> buildables = Community.PlayerCommunity.Buildables;
			if (_buildableProperties.IsNullOrEmpty())
			{
				return true;
			}
			foreach (Buildable item in buildables)
			{
				if (_buildableProperties.Contains(item.Properties) && item.BuildPhase == BuildPhase.Finished)
				{
					return true;
				}
			}
			return false;
		}
		case BuildableType.Producer:
			return !Community.PlayerCommunity.Producers.IsNullOrEmpty();
		case BuildableType.ResearchStation:
			return Community.PlayerCommunity.Research.HasBuiltResearchStation();
		default:
			return false;
		}
	}
}
