using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerkSelectionGroup : MonoBehaviour
{
	private enum Type
	{
		Weapons = 0,
		Perks = 1,
		Mutations = 2,
		FixedLoadout = 3
	}

	public GameObject perkSelectionItemPrefab;

	public GameObject perkLockedPrefab;

	[SerializeField]
	private Type type;

	private PerkManager perkManager;

	private int selectableAmount = 10000;

	private List<PerkSelectionItem> selectedInMyGroup = new List<PerkSelectionItem>();

	[SerializeField]
	private TMP_Text headerText;

	[SerializeField]
	private string selectNone = "No perks unlocked yet.";

	[SerializeField]
	private string selectOne = "Select one perk.";

	[SerializeField]
	private string selectMulti = "Select <n> perks.";

	[SerializeField]
	private bool canDeselectPerks = true;

	[SerializeField]
	private Color textColorNormal = Color.white;

	[SerializeField]
	private Color textColorWarning = Color.red;

	private int unlockedPerks;

	private void Start()
	{
		UpdateVisuals();
	}

	public void UpdateVisuals()
	{
		perkManager = PerkManager.instance;
		int num = 0;
		for (int num2 = base.transform.childCount - 1; num2 >= 0; num2--)
		{
			Object.Destroy(base.transform.GetChild(num2).gameObject);
		}
		unlockedPerks = 0;
		foreach (Equippable allEquippable in PerkManager.instance.allEquippables)
		{
			if (allEquippable.IsUnlocked)
			{
				if (allEquippable.GetType() == typeof(PerkPoint))
				{
					num++;
				}
				if ((type == Type.Weapons && allEquippable.GetType() == typeof(EquippableWeapon)) || (type == Type.Perks && allEquippable.GetType() == typeof(EquippablePerk)) || (type == Type.Mutations && allEquippable.GetType() == typeof(EquippableMutation)))
				{
					Object.Instantiate(perkSelectionItemPrefab, base.transform).GetComponent<PerkSelectionItem>().Initialize(allEquippable);
					unlockedPerks++;
				}
			}
		}
		foreach (Equippable allEquippable2 in PerkManager.instance.allEquippables)
		{
			if (((type == Type.Weapons && allEquippable2.GetType() == typeof(EquippableWeapon)) || (type == Type.Perks && allEquippable2.GetType() == typeof(EquippablePerk)) || (type == Type.Mutations && allEquippable2.GetType() == typeof(EquippableMutation))) && !allEquippable2.IsUnlocked)
			{
				Object.Instantiate(perkLockedPrefab, base.transform);
			}
		}
		if (type == Type.FixedLoadout && LevelInteractor.lastActiveLevelInfo != null)
		{
			selectableAmount = 0;
			LevelInfo lastActiveLevelInfo = LevelInteractor.lastActiveLevelInfo;
			for (int i = 0; i < lastActiveLevelInfo.fixedLoadout.Count; i++)
			{
				Equippable equippable = lastActiveLevelInfo.fixedLoadout[i];
				PerkSelectionItem component = Object.Instantiate(perkSelectionItemPrefab, base.transform).GetComponent<PerkSelectionItem>();
				component.Selected = true;
				component.Initialize(equippable);
				selectableAmount++;
			}
		}
		if (type == Type.Weapons)
		{
			selectableAmount = 1;
		}
		if (type == Type.Perks)
		{
			selectableAmount = num;
		}
		if (type == Type.Mutations)
		{
			selectableAmount = 10000;
		}
		if (selectableAmount <= 0 || unlockedPerks <= 0)
		{
			headerText.text = selectNone;
		}
		else if (selectableAmount == 1)
		{
			headerText.text = selectOne;
		}
		else
		{
			headerText.text = selectMulti.Replace("<n>", selectableAmount.ToString());
		}
	}

	private void Update()
	{
		if (selectedInMyGroup.Count < Mathf.Min(unlockedPerks, selectableAmount))
		{
			headerText.color = textColorWarning;
		}
		else
		{
			headerText.color = textColorNormal;
		}
	}

	public void SelectPerk(PerkSelectionItem _selectedPerk)
	{
		if (!canDeselectPerks && _selectedPerk.Selected)
		{
			return;
		}
		_selectedPerk.Selected = !_selectedPerk.Selected;
		if (_selectedPerk.Selected)
		{
			selectedInMyGroup.Add(_selectedPerk);
			if (!perkManager.CurrentlyEquipped.Contains(_selectedPerk.Equippable))
			{
				perkManager.CurrentlyEquipped.Add(_selectedPerk.Equippable);
			}
			if (selectedInMyGroup.Count > selectableAmount)
			{
				PerkSelectionItem perkSelectionItem = selectedInMyGroup[0];
				perkSelectionItem.Selected = false;
				selectedInMyGroup.Remove(perkSelectionItem);
				perkManager.CurrentlyEquipped.Remove(perkSelectionItem.Equippable);
			}
		}
		else
		{
			selectedInMyGroup.Remove(_selectedPerk);
			perkManager.CurrentlyEquipped.Remove(_selectedPerk.Equippable);
		}
	}
}
