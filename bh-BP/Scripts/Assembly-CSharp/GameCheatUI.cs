using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCheatUI : MonoBehaviour
{
	public static GameCheatUI I;

	public TextMeshProUGUI TxtTitle;

	public TextMeshProUGUI TxtFilter;

	public string CurFilter;

	public CheatUIMode CurMode;

	public CheatListItem PrefabItem;

	private ObjectPool<CheatListItem> _itemPool;

	private List<UpgradeInfo> _listedUpgrades;

	private List<int> _listedIdxes;

	private bool _didJustOpen;

	public Transform Wrapper;

	public CoolSelectableWrapper SelectWrapper;

	public CoolButton BtnUnderlay;

	private HeroInfo _comboHero1;

	private CharInfo _tgtChar;

	private PetBattleInst _petToUpgrade;

	private void Awake()
	{
	}

	private void OnBPressed()
	{
	}

	public void Activate(CheatUIMode mode)
	{
	}

	private void SetFilter(string f)
	{
	}

	private void MyUpdate()
	{
	}

	public void SelectItem(int idx)
	{
	}

	private int GetNumDisplayed()
	{
		return 0;
	}

	public void Deactivate()
	{
	}
}
