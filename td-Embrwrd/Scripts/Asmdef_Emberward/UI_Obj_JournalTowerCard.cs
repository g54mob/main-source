using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_JournalTowerCard : UI_Obj_ShopCard
{
	[SerializeField]
	private Image icon_TowerBuilt;

	[SerializeField]
	private GameObject node_Locked;

	private void Awake()
	{
	}

	public void ToggleTowerBuiltIcon(bool isBuilt)
	{
	}

	public void ToggleShowLocked(bool isLocked)
	{
	}
}
