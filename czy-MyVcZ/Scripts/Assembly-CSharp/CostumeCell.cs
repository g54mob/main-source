using System;
using UnityEngine;
using UnityEngine.UI;

public class CostumeCell : MonoBehaviour
{
	[SerializeField]
	private Image _costumeIcon;

	[SerializeField]
	private GameObject _selectFrame;

	[SerializeField]
	private GameObject _equipGO;

	private Action<CostumeID> _onSelectCostumeCell;

	public CostumeID CostumeID { get; private set; }

	public void Init(CostumeID costumeID, Action<CostumeID> onSelectCostumeCell)
	{
		CostumeID = costumeID;
		_onSelectCostumeCell = onSelectCostumeCell;
		MonoSingleton<CostumeManager>.Instance.OnEquipCostume += Handle_OnEquipCostume;
		UpdateUI();
	}

	public void Release()
	{
		_onSelectCostumeCell = null;
		MonoSingleton<CostumeManager>.Instance.OnEquipCostume -= Handle_OnEquipCostume;
	}

	public void UpdateUI()
	{
		CostumeData costumeData = DataManager.Instance.GetCostumeData(CostumeID);
		_costumeIcon.sprite = Resources.Load<Sprite>(costumeData.IconPath);
		bool active = MonoSingleton<CostumeManager>.Instance.IsEquippedCostume(CostumeID);
		_equipGO.SetActive(active);
	}

	public void SetSelect(bool isSelect)
	{
		_selectFrame.SetActive(isSelect);
	}

	private void Handle_OnEquipCostume(CostumeID costumeID)
	{
		UpdateUI();
	}

	public void OnClick_SelectButton()
	{
		_onSelectCostumeCell?.Invoke(CostumeID);
	}
}
