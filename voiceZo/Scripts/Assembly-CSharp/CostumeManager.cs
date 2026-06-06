using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CostumeManager : MonoSingleton<CostumeManager>
{
	[SerializeField]
	private Player _player;

	[SerializeField]
	private AnimalPrefabController _animalPrefabController;

	public Dictionary<CostumeID, bool> CostumeBuyStateDict { get; private set; } = new Dictionary<CostumeID, bool>();

	public CostumeID EquippedCostumeID { get; private set; }

	public event Action<CostumeID> OnBuyCostume;

	public event Action<CostumeID> OnEquipCostume;

	public void Init(CostumeSaveData costumeSaveData)
	{
		CostumeBuyStateDict = costumeSaveData.CostumeBuyStateDict;
		EquippedCostumeID = costumeSaveData.EquippedCostumeID;
		EquipCostume(EquippedCostumeID);
	}

	public void BuyCostume(CostumeID costumeID)
	{
		if (CostumeBuyStateDict.TryGetValue(costumeID, out var value) && value)
		{
			Debug.Log($"이미 구매한 코스튬입니다. {costumeID}");
			return;
		}
		if (!CanBuyCostumeCondition(costumeID))
		{
			Debug.Log($"코스튬 구매 조건을 충족하지 않습니다. {costumeID}");
			return;
		}
		long buyCost = DataManager.Instance.GetCostumeData(costumeID).BuyCost;
		if (!Wallet.Instance.HasEnoughGold(buyCost))
		{
			Debug.Log($"골드가 부족합니다. {costumeID}");
			return;
		}
		CostumeBuyStateDict[costumeID] = true;
		Wallet.Instance.ReduceGold(buyCost);
		this.OnBuyCostume?.Invoke(costumeID);
	}

	public void EquipCostume(CostumeID costumeID)
	{
		EquippedCostumeID = costumeID;
		SpriteLibraryAsset spriteLibraryAsset = Resources.Load<SpriteLibraryAsset>(DataManager.Instance.GetCostumeData(EquippedCostumeID).SpriteLibraryPath);
		_player.ChangeCostume(spriteLibraryAsset);
		this.OnEquipCostume?.Invoke(EquippedCostumeID);
		UpdateAnimalsCostumeVoice();
		MonoSingleton<GameManager>.Instance.SaveGame();
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_AdoptComplete);
		string message = "";
		switch (EquippedCostumeID)
		{
		case CostumeID.Default:
			message = LocaleHelper.Get("TOAST_COSTUME_EQUIP_DEFAULT");
			break;
		case CostumeID.Duck:
			message = LocaleHelper.Get("TOAST_COSTUME_EQUIP_DUCK");
			break;
		case CostumeID.Reindeer:
			message = LocaleHelper.Get("TOAST_COSTUME_EQUIP_REINDEER");
			break;
		case CostumeID.Frog:
			message = LocaleHelper.Get("TOAST_COSTUME_EQUIP_FROG");
			break;
		case CostumeID.Cat:
			message = LocaleHelper.Get("TOAST_COSTUME_EQUIP_CAT");
			break;
		}
		MonoSingleton<ToastManager>.Instance.ShowToast(message);
	}

	public void UpdateAnimalsCostumeVoice()
	{
		int conditionAnimalID = DataManager.Instance.GetCostumeData(EquippedCostumeID).conditionAnimalID;
		if (conditionAnimalID == 0)
		{
			_animalPrefabController.ResetAllCostumeVoice();
			return;
		}
		AudioClip voiceClip = _animalPrefabController.GetAnimalPrefab(conditionAnimalID).GetVoiceClip();
		_animalPrefabController.SetAllCostumeVoice(voiceClip);
	}

	public bool CanBuyCostumeCondition(CostumeID costumeID)
	{
		int conditionAnimalID = DataManager.Instance.GetCostumeData(costumeID).conditionAnimalID;
		if (conditionAnimalID == 0)
		{
			return true;
		}
		if (AnimalManager.Instance.IsAnimalCollected(conditionAnimalID))
		{
			return true;
		}
		return false;
	}

	public bool IsBuyCostume(CostumeID costumeID)
	{
		if (CostumeBuyStateDict.TryGetValue(costumeID, out var value))
		{
			return value;
		}
		Debug.LogError($"코스튬을 찾을 수 없습니다. {costumeID}");
		return false;
	}

	public bool IsEquippedCostume(CostumeID costumeID)
	{
		return EquippedCostumeID == costumeID;
	}
}
