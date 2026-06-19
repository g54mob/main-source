using System.Collections.Generic;
using UnityEngine;

public class CraftingCategoryNavigationUI : MonoBehaviour
{
	public GameObject root;

	public UIelement upArrow;

	public UIelement downArrow;

	public SpriteRenderer iconSR;

	public void MoveToNextCategory()
	{
		Manager.ui.ChangeCraftingCategoryWindowInfo(moveForward: true);
		LateUpdate();
		upArrow.Select();
		Manager.ui.mouse.PlaceMousePositionOnSelectedUIElementWhenControlledByJoystick();
		AudioManager.Sfx(SfxTableID.inventorySFXCraftingTier, Manager.main.player.transform.position);
	}

	public void MoveToPreviousCategory()
	{
		Manager.ui.ChangeCraftingCategoryWindowInfo(moveForward: false);
		LateUpdate();
		downArrow.Select();
		Manager.ui.mouse.PlaceMousePositionOnSelectedUIElementWhenControlledByJoystick();
		AudioManager.Sfx(SfxTableID.inventorySFXCraftingTier, Manager.main.player.transform.position);
	}

	private void LateUpdate()
	{
		bool flag = Manager.ui.isCraftingUIShowing;
		if (Manager.prefs.hideInGameUI)
		{
			flag = false;
		}
		if (flag)
		{
			List<CraftingBuilding.CraftingCategoryWindowInfo> craftingCategoryWindowInfos = Manager.ui.GetCraftingCategoryWindowInfos();
			flag = craftingCategoryWindowInfos != null && craftingCategoryWindowInfos.Count > 0;
		}
		if (root.activeSelf != flag)
		{
			root.SetActive(flag);
		}
		if (flag)
		{
			switch (Manager.ui.simpleCraftingUIContainer.amountOfWindowsShowing)
			{
			case 1:
				root.transform.localPosition = new Vector3(-2.8125f, 0f, 0f);
				break;
			case 2:
				root.transform.localPosition = new Vector3(-5.3125f, 0f, 0f);
				break;
			case 3:
				root.transform.localPosition = new Vector3(-7.8125f, 0f, 0f);
				break;
			}
			CraftingBuilding.CraftingCategoryWindowInfo craftingCategoryWindowInfo = Manager.ui.GetCraftingCategoryWindowInfo();
			if (craftingCategoryWindowInfo != null)
			{
				iconSR.sprite = craftingCategoryWindowInfo.icon;
			}
		}
	}
}
