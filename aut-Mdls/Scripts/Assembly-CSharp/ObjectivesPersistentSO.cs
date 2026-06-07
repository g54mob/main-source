#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.SaveData;
using Data.Shapes;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "PersistentSOs/Objectives", fileName = "ObjectivesPersistentSO")]
public class ObjectivesPersistentSO : AbstractPersistentSO
{
	private readonly Dictionary<int, int> _deliveryTargetsClaimedAmount = new Dictionary<int, int>();

	private readonly Dictionary<RotationIndependentHash, int> _moduleChallengesClaimedAmount = new Dictionary<RotationIndependentHash, int>();

	private readonly List<int> _claimedModuleChallengeAwards = new List<int>();

	protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
	{
		if (!(saveData is ObjectiveSaveData objectiveSaveData))
		{
			this.DevException("Expected save data of type ObjectiveSaveData, but received " + (saveData?.GetType().Name ?? "null") + ".", "ApplyLoadedSaveData", 21);
			return;
		}
		foreach (KeyValuePair<int, int> claimedDeliveryTarget in objectiveSaveData.ClaimedDeliveryTargets)
		{
			_deliveryTargetsClaimedAmount.Add(claimedDeliveryTarget.Key, claimedDeliveryTarget.Value);
		}
		foreach (KeyValuePair<string, int> claimedModuleChallenge in objectiveSaveData.ClaimedModuleChallenges)
		{
			_moduleChallengesClaimedAmount.Add(RotationIndependentHash.Parse(claimedModuleChallenge.Key), claimedModuleChallenge.Value);
		}
		if (objectiveSaveData.ClaimedModuleChallengeAwards != null)
		{
			for (int i = 0; i < objectiveSaveData.ClaimedModuleChallengeAwards.Count; i++)
			{
				_claimedModuleChallengeAwards.Add(objectiveSaveData.ClaimedModuleChallengeAwards[i]);
			}
		}
	}

	public override void ResetToDefaults()
	{
		_deliveryTargetsClaimedAmount.Clear();
		_moduleChallengesClaimedAmount.Clear();
		_claimedModuleChallengeAwards.Clear();
	}

	public override AbstractSaveData GetSaveData()
	{
		return new ObjectiveSaveData(_deliveryTargetsClaimedAmount, _moduleChallengesClaimedAmount, _claimedModuleChallengeAwards);
	}

	public override bool TryLoadSaveData(string fullPath)
	{
		return TryLoadSaveDataInternal<ObjectiveSaveData>(fullPath);
	}

	public bool IsDeliveryTargetClaimed(int resourceId, int claimIndex)
	{
		return GetDeliveryTargetClaimedTiersAmount(resourceId) > claimIndex;
	}

	public int GetDeliveryTargetClaimedTiersAmount(int resourceId)
	{
		if (!_deliveryTargetsClaimedAmount.TryGetValue(resourceId, out var value))
		{
			return 0;
		}
		return value;
	}

	public void SetDeliveryTargetClaimedTier(int resourceId, int claimIndex)
	{
		_deliveryTargetsClaimedAmount[resourceId] = claimIndex + 1;
	}

	public bool IsModuleChallengeClaimed(RotationIndependentHash shapeHash, int claimIndex)
	{
		return GetModuleChallengeClaimedTier(shapeHash) > claimIndex;
	}

	public int GetModuleChallengeClaimedTier(RotationIndependentHash shapeHash)
	{
		if (!_moduleChallengesClaimedAmount.TryGetValue(shapeHash, out var value))
		{
			return 0;
		}
		return value;
	}

	public void SetModuleChallengeClaimedTier(RotationIndependentHash shapeHash, int claimIndex)
	{
		_moduleChallengesClaimedAmount[shapeHash] = claimIndex + 1;
	}

	public bool IsModuleChallengeAwardClaimed(int setIndex)
	{
		return _claimedModuleChallengeAwards.Contains(setIndex);
	}

	public bool SetModuleChallengeAwardClaimed(int setIndex)
	{
		if (_claimedModuleChallengeAwards.Contains(setIndex))
		{
			return false;
		}
		_claimedModuleChallengeAwards.Add(setIndex);
		return true;
	}
}
