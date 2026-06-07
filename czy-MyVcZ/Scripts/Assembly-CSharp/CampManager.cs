using System.Collections.Generic;
using UnityEngine;

public class CampManager : MonoSingleton<CampManager>
{
	[SerializeField]
	private List<Camp> _campList;

	private Dictionary<CampType, bool> _campStateDict;

	private Dictionary<CampType, long> _campCostDict = new Dictionary<CampType, long>
	{
		{
			CampType.Jungle,
			2000L
		},
		{
			CampType.Forest,
			4000L
		},
		{
			CampType.Snow,
			6000L
		},
		{
			CampType.Savannah,
			8000L
		}
	};

	public Dictionary<CampType, bool> CampStateDict => _campStateDict;

	public void Init()
	{
		_campStateDict = new Dictionary<CampType, bool>();
		_campStateDict[CampType.Forest] = false;
		_campStateDict[CampType.Snow] = false;
		_campStateDict[CampType.Jungle] = false;
		_campStateDict[CampType.Savannah] = false;
		RefreshSetActive_AllCamps();
	}

	public void Init(CampSaveData campSaveData)
	{
		_campStateDict = new Dictionary<CampType, bool>();
		_campStateDict[CampType.Forest] = campSaveData.IsBuy_Forest;
		_campStateDict[CampType.Snow] = campSaveData.IsBuy_Snow;
		_campStateDict[CampType.Jungle] = campSaveData.IsBuy_Jungle;
		_campStateDict[CampType.Savannah] = campSaveData.IsBuy_Savannah;
		RefreshSetActive_AllCamps();
	}

	public bool BuyCamp(CampType campType)
	{
		if (!Wallet.Instance.HasEnoughGold(_campCostDict[campType]))
		{
			return false;
		}
		_campStateDict[campType] = true;
		RefreshSetActive_AllCamps();
		Wallet.Instance.ReduceGold(_campCostDict[campType]);
		MonoSingleton<GameManager>.Instance.CameraController.StartFocusOnCamp(_campList.Find((Camp c) => c.CampType == campType).transform);
		return true;
	}

	public void RefreshSetActive_AllCamps()
	{
		foreach (KeyValuePair<CampType, bool> item in _campStateDict)
		{
			CampType campType = item.Key;
			bool value = item.Value;
			_campList.Find((Camp c) => c.CampType == campType).gameObject.SetActive(value);
		}
	}

	public long GetCampCost(CampType campType)
	{
		if (_campCostDict.TryGetValue(campType, out var value))
		{
			return value;
		}
		return 0L;
	}

	public bool GetCampState(CampType campType)
	{
		if (_campStateDict.TryGetValue(campType, out var value))
		{
			return value;
		}
		return false;
	}
}
