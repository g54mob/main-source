#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Objectives.Events;
using Data.Shapes;
using NaughtyAttributes;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "Objectives/Create Module Challenge")]
public class ModuleChallengeSO : ScriptableObject
{
	[SerializeField]
	private List<ModuleChallengeSet> _sets;

	[SerializeField]
	private ObjectivesPersistentSO _objectivesPersistentSO;

	private readonly Dictionary<RotationIndependentHash, uint> _totalDeliveredModuleChallenges = new Dictionary<RotationIndependentHash, uint>();

	public List<ModuleChallengeSet> Sets => _sets;

	public bool CheckChallengeSetCompleted(ObjectiveTargetItem claimedItem, out ModuleChallengeSet claimedItemSet)
	{
		claimedItemSet = null;
		foreach (ModuleChallengeSet set in _sets)
		{
			foreach (ObjectiveTargetCategorySO category in set.Categories)
			{
				if (category.Items.Contains(claimedItem))
				{
					claimedItemSet = set;
					break;
				}
			}
			if (claimedItemSet != null)
			{
				break;
			}
		}
		if (claimedItemSet == null)
		{
			this.LogError($"Couldn't find a set where {claimedItem} belongs!", "CheckChallengeSetCompleted", 37);
			return false;
		}
		if (claimedItemSet.AllFirstTiersCompleted)
		{
			foreach (AbstractObjectiveEvent @event in claimedItemSet.Events)
			{
				@event.Execute();
			}
			if (_objectivesPersistentSO.SetModuleChallengeAwardClaimed(claimedItemSet.ID))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public int GetClaimedSetsAmount()
	{
		int num = 0;
		foreach (ModuleChallengeSet set in _sets)
		{
			if (set.AllFirstTiersCompleted)
			{
				num++;
			}
		}
		return num;
	}

	public void ExecuteRewardsEvent(ModuleChallengeSet claimedItemSet)
	{
		foreach (AbstractObjectiveEvent @event in claimedItemSet.Events)
		{
			@event.Execute();
		}
	}

	public void InitModuleViewerDatas()
	{
		for (int i = 0; i < Sets.Count; i++)
		{
			Sets[i].InitModuleViewerData(i);
		}
	}

	[Button("Generate All Targets Data List", EButtonEnableMode.Always)]
	public void GenerateAllTargetsData()
	{
		foreach (ModuleChallengeSet set in Sets)
		{
			if (set?.Categories == null)
			{
				continue;
			}
			foreach (ObjectiveTargetCategorySO category in set.Categories)
			{
				if (category != null)
				{
					category.GenerateTargetsData();
				}
			}
		}
	}

	[Button("Generate All Amount Start Offsets", EButtonEnableMode.Always)]
	public void GenerateAllStartOffsets()
	{
		foreach (ModuleChallengeSet set in Sets)
		{
			if (set?.Categories == null)
			{
				continue;
			}
			foreach (ObjectiveTargetCategorySO category in set.Categories)
			{
				if (category != null)
				{
					category.GenerateAmountOffsets();
				}
			}
		}
	}

	public void SetShapeDeliveredModuleChallenge(RotationIndependentHash shapeHash, uint deliveredAmount)
	{
		_totalDeliveredModuleChallenges[shapeHash] = deliveredAmount;
	}

	public uint GetTotalDeliveredModuleChallenges()
	{
		uint num = 0u;
		foreach (uint value in _totalDeliveredModuleChallenges.Values)
		{
			num += value;
		}
		return num;
	}
}
