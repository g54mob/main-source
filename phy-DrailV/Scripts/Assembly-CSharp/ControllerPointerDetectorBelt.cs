using DV.CabControls;
using DV.InventorySystem;
using UnityEngine;
using VRTK;

public class ControllerPointerDetectorBelt : ControllerPointerDetector
{
	[SerializeField]
	private GameObject directionGuide;

	public bool occupied;

	public ItemBase reservedItem;

	private bool triggersEnabled;

	private ItemBeltVR itemBeltVR;

	protected override bool InteractionAllowed => triggersEnabled;

	private void Start()
	{
		itemBeltVR = InventoryViewVR.Instance.beltVR;
		if (!itemBeltVR)
		{
			Debug.LogError("itemBeltVR not found! It is necessary for ControllerPointerDetectorBelt to function!", base.gameObject);
		}
	}

	public bool IsTouchedByController(bool right)
	{
		if (!right)
		{
			return isLeftPointerPresent;
		}
		return isRightPointerPresent;
	}

	public void EnableTriggers(bool enable)
	{
		triggersEnabled = enable;
		UpdateHighlight();
		UpdateDirectionGuideVisibility(!occupied);
	}

	public void UpdateDirectionGuideVisibility(bool on)
	{
		if (!(directionGuide == null))
		{
			directionGuide.SetActive(on && !occupied);
		}
	}

	protected override bool ValidIntersect(VRTK_InteractGrab grab)
	{
		if (itemBeltVR.ControllerAlreadyTouchingOtherSlots(this, VRTK_DeviceFinder.IsControllerRightHand(grab.gameObject)))
		{
			return false;
		}
		if (CheckWarnImproperTouch(grab))
		{
			return false;
		}
		GameObject grabbedObject = grab.GetGrabbedObject();
		if (occupied)
		{
			return grabbedObject == null;
		}
		ItemBase itemBase = ((grabbedObject != null) ? grabbedObject.GetComponent<ItemBase>() : null);
		if (itemBase != null)
		{
			return itemBase.IsBeltSnappable;
		}
		return false;
	}

	protected override bool CheckWarnImproperTouch(VRTK_InteractGrab grab)
	{
		bool flag = VRTK_DeviceFinder.IsControllerRightHand(grab.gameObject);
		GameObject grabbedObject = grab.GetGrabbedObject();
		if (grabbedObject == null)
		{
			if (flag)
			{
				warnImproperTouchRight = false;
			}
			else
			{
				warnImproperTouchLeft = false;
			}
			return false;
		}
		ItemBase component = grabbedObject.GetComponent<ItemBase>();
		if (component == null)
		{
			if (flag)
			{
				warnImproperTouchRight = false;
			}
			else
			{
				warnImproperTouchLeft = false;
			}
			return false;
		}
		if (reservedItem == null || reservedItem == component)
		{
			if (flag)
			{
				warnImproperTouchRight = false;
			}
			else
			{
				warnImproperTouchLeft = false;
			}
			return false;
		}
		if (flag)
		{
			warnImproperTouchRight = true;
		}
		else
		{
			warnImproperTouchLeft = true;
		}
		return true;
	}
}
