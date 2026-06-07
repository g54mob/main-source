using System;
using System.Collections.Generic;
using System.Linq;
using Data.TechTree.Behaviours;
using Data.TechTree.Validators;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class TechTreeNodeSO : ScriptableObject
{
	public int ID;

	public Vector2Int GridPosition;

	[HideInInspector]
	public bool IsUnlocked;

	[HideInInspector]
	public int UnlockedIndex = -1;

	[HideInInspector]
	public bool IsUnlockable;

	public bool UnlockByDefault;

	[ReadOnly]
	public bool IsDefaultFocused;

	public bool SendGAEvent;

	public bool AddToBalancingGAData;

	[HideInInspector]
	public string Title;

	[HideInInspector]
	public string Description;

	public string LocaKey;

	public Sprite Thumbnail;

	public List<TechTreeNodeSO> IncomingNodes = new List<TechTreeNodeSO>();

	public List<TechTreeNodeSO> OutgoingNodes = new List<TechTreeNodeSO>();

	public ResourceCost Cost = new ResourceCost();

	public NodeTier Tier;

	public Tag Tag;

	public List<AbstractTechTreeNodeValidator> ShowValidators = new List<AbstractTechTreeNodeValidator>();

	public List<AbstractTechTreeNodeValidator> Validators = new List<AbstractTechTreeNodeValidator>();

	public List<AbstractTechTreeNodeBehaviour> Behaviors = new List<AbstractTechTreeNodeBehaviour>();

	[HideInInspector]
	public bool RevealingRunTimeValue;

	[HideInInspector]
	public bool IsDirty;

	public bool HasXPRankValidator => Validators.Count((AbstractTechTreeNodeValidator v) => v is RequiredXPRankValidator) > 0;

	public bool HasBlockedInDemoValidator => Validators.Count((AbstractTechTreeNodeValidator v) => v is BlockedInDemoValidator) > 0;

	public int RequiredRank
	{
		get
		{
			if (!HasXPRankValidator)
			{
				return 0;
			}
			return (Validators.Find((AbstractTechTreeNodeValidator v) => v is RequiredXPRankValidator) as RequiredXPRankValidator).MinRankRequired;
		}
	}

	public bool HasEnoughRank
	{
		get
		{
			if (!HasXPRankValidator)
			{
				return true;
			}
			return (Validators.Find((AbstractTechTreeNodeValidator v) => v is RequiredXPRankValidator) as RequiredXPRankValidator).CanBuy(this);
		}
	}

	public bool HasDataShardValidator => Validators.Count((AbstractTechTreeNodeValidator v) => v is DataShardsValidator) > 0;

	public bool HasEnoughDataShards
	{
		get
		{
			if (!HasDataShardValidator)
			{
				return true;
			}
			return (Validators.Find((AbstractTechTreeNodeValidator v) => v is DataShardsValidator) as DataShardsValidator).CanBuy(this);
		}
	}

	public bool HasAllIncomingNodesUnlocked => IncomingNodes.All((TechTreeNodeSO node) => node.IsUnlocked);

	public bool CanShowNode()
	{
		foreach (AbstractTechTreeNodeValidator showValidator in ShowValidators)
		{
			if (!showValidator.CanBuy(this))
			{
				return false;
			}
		}
		return true;
	}
}
