using System;
using UnityEngine;

public class ExpertiseManager : MonoBehaviour
{
	[SerializeField]
	private ExpertiseProperties _properties;

	private float _researchPointRequirement;

	private float _previousResearchPointThreshold;

	private float _nextResearchPointThreshold;

	public static ExpertiseManager Instance { get; private set; }

	public static float Experience { get; private set; }

	public static int ResearchPoints { get; private set; }

	public static float ResearchPointProgress { get; private set; }

	public void Initialize()
	{
		Instance = this;
		GameEventDispatcher.AddListener(GameEventType.AgentActionRecipeProduced, OnRecipeProduced);
		GameEventDispatcher.AddListener(GameEventType.AgentActionCompositionAdded, OnCompositionAdded);
		GameEventDispatcher.AddListener(GameEventType.AgentActionCompositionRemoved, OnCompositionRemoved);
		GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedSalvagerItem, OnSalvagerItemSalvaged);
		GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedLandmarkItem, OnLandmarkItemSalvaged);
		GameEventDispatcher.AddListener(GameEventType.AgentActionSalvagedMarkerItem, OnMarkerItemSalvaged);
		GameEventDispatcher.AddListener(GameEventType.AgentActionItemHauled, OnItemHauled);
		GameEventDispatcher.AddListener(GameEventType.AgentActionResearched, OnResearched);
		GameEventDispatcher.AddListener(GameEventType.AgentActionGeneratedEnergy, OnEnergyGenerated);
		Experience = 0f;
		ResearchPoints = 0;
		_researchPointRequirement = _properties.ReturnCommunityLevelRequirement(ResearchPoints);
		_previousResearchPointThreshold = 0f;
		_nextResearchPointThreshold = _researchPointRequirement;
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionRecipeProduced, OnRecipeProduced);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionCompositionAdded, OnCompositionAdded);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionCompositionRemoved, OnCompositionRemoved);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedSalvagerItem, OnSalvagerItemSalvaged);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedLandmarkItem, OnLandmarkItemSalvaged);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionSalvagedMarkerItem, OnMarkerItemSalvaged);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionItemHauled, OnItemHauled);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionResearched, OnResearched);
		GameEventDispatcher.RemoveListener(GameEventType.AgentActionGeneratedEnergy, OnEnergyGenerated);
	}

	public void IncreaseExperience(Agent agent, float experience, bool applyMoraleEffect = true)
	{
		if (applyMoraleEffect && agent.Morale.TryReturnCurrentCategory(out var category))
		{
			experience *= category.ExperienceMultiplier;
		}
		agent.Attributes.AddTotalExperience(experience, addResearchPoints: false);
		IncreaseCommunityExperience(experience);
	}

	private void IncreaseCommunityExperience(float experience)
	{
		Experience += experience;
		int num = 0;
		while (_nextResearchPointThreshold < Experience)
		{
			ResearchPoints++;
			num++;
			_researchPointRequirement = _properties.ReturnCommunityLevelRequirement(ResearchPoints);
			_previousResearchPointThreshold = _nextResearchPointThreshold;
			_nextResearchPointThreshold = _previousResearchPointThreshold + _researchPointRequirement;
		}
		if (0 < num)
		{
			Community.PlayerCommunity.Research.AddResearchPoints(num);
		}
		ResearchPointProgress = (Experience - _previousResearchPointThreshold) / _researchPointRequirement;
		GameEventDispatcher.Dispatch(GameEventType.CommunityExperienceUpdated);
	}

	private void OnRecipeProduced(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionRecipeEvent agentActionRecipeEvent)
		{
			IncreaseExperience(agentActionRecipeEvent.Agent, _properties.ReturnProductionExperience(agentActionRecipeEvent.Recipe, agentActionRecipeEvent.AttributeType));
		}
	}

	private void OnCompositionAdded(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent agentActionItemPropertiesEvent)
		{
			IncreaseExperience(agentActionItemPropertiesEvent.Agent, _properties.ConstructionExperience);
		}
	}

	private void OnCompositionRemoved(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent agentActionItemPropertiesEvent)
		{
			IncreaseExperience(agentActionItemPropertiesEvent.Agent, _properties.ConstructionExperience);
		}
	}

	private void OnSalvagerItemSalvaged(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent agentActionItemPropertiesEvent)
		{
			float num = 0f;
			IncreaseExperience(experience: agentActionItemPropertiesEvent.AttributeType switch
			{
				DrifterAttributes.AttributeType.Fishing => _properties.ReturnFishingExperience(agentActionItemPropertiesEvent.ItemProperties, isFishingFromBoat: false), 
				DrifterAttributes.AttributeType.Salvaging => _properties.SalvageExperience, 
				_ => throw new NotImplementedException(), 
			}, agent: agentActionItemPropertiesEvent.Agent);
		}
	}

	private void OnMarkerItemSalvaged(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent { AttributeType: var attributeType } agentActionItemPropertiesEvent)
		{
			IncreaseExperience(experience: attributeType switch
			{
				DrifterAttributes.AttributeType.Fishing => _properties.ReturnFishingExperience(agentActionItemPropertiesEvent.ItemProperties, isFishingFromBoat: true), 
				DrifterAttributes.AttributeType.Salvaging => _properties.SalvageExperience, 
				_ => throw new NotImplementedException(), 
			}, agent: agentActionItemPropertiesEvent.Agent);
		}
	}

	private void OnLandmarkItemSalvaged(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent agentActionItemPropertiesEvent)
		{
			IncreaseExperience(agentActionItemPropertiesEvent.Agent, _properties.SalvageExperience);
		}
	}

	private void OnItemHauled(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionItemPropertiesEvent agentActionItemPropertiesEvent)
		{
			IncreaseExperience(agentActionItemPropertiesEvent.Agent, _properties.HaulExperience);
		}
	}

	private void OnResearched(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionEvent agentActionEvent)
		{
			IncreaseExperience(agentActionEvent.Agent, _properties.ResearchExperience);
		}
	}

	private void OnEnergyGenerated(GameEvent gameEvent)
	{
		if (gameEvent is AgentActionEvent agentActionEvent)
		{
			IncreaseExperience(agentActionEvent.Agent, _properties.EnergyGeneratedExperience);
		}
	}

	public static float ReturnDrifterLevelRequirement(int level)
	{
		if (Instance == null)
		{
			return 0f;
		}
		return Instance._properties.ReturnDrifterLevelRequirement(level);
	}
}
