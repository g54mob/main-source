using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.UI
{
	public class UIInteractMessages : MonoBehaviour
	{
		[Header("Item Pickup Message")]
		[SerializeField]
		private GameObject PickUpMessageObject;

		[SerializeField]
		private bool SetMessagePositionToItemPosition = true;

		[SerializeField]
		private Vector3 Offset;

		[SerializeField]
		private bool ShowItemNameOnText;

		[SerializeField]
		private Text WarningText;

		[SerializeField]
		private string PickUpLabelText = "[HOLD] TO PICK UP ";

		[Header("Vehicle Enter Message")]
		[SerializeField]
		private string VehicleEnterLabelText = "TO DRIVE";

		[SerializeField]
		private Vector3 VehicleOffset;

		private void Update()
		{
			if (JUGameManager.InstancedPlayer == null)
			{
				PickUpMessageObject.SetActive(value: false);
				return;
			}
			if (JUGameManager.InstancedPlayer.Inventory == null)
			{
				PickUpMessageObject.SetActive(value: false);
				base.gameObject.SetActive(value: false);
				return;
			}
			if (JUGameManager.InstancedPlayer.VehicleInArea != null && !JUGameManager.InstancedPlayer.IsDriving)
			{
				PickUpMessageObject.SetActive(value: true);
				UIElementToWorldPosition.SetUIWorldPosition(PickUpMessageObject, JUGameManager.InstancedPlayer.VehicleInArea.transform.position, VehicleOffset);
				if ((bool)WarningText)
				{
					WarningText.text = VehicleEnterLabelText;
				}
				return;
			}
			PickUpMessageObject.SetActive(JUGameManager.InstancedPlayer.Inventory.ItemToPickUp != null);
			if (PickUpMessageObject.activeInHierarchy && SetMessagePositionToItemPosition)
			{
				UIElementToWorldPosition.SetUIWorldPosition(PickUpMessageObject, JUGameManager.InstancedPlayer.Inventory.ItemToPickUp.transform.position, Offset);
			}
			if (ShowItemNameOnText && (bool)WarningText && JUGameManager.InstancedPlayer.Inventory.ItemToPickUp != null)
			{
				WarningText.text = PickUpLabelText + JUGameManager.InstancedPlayer.Inventory.ItemToPickUp.ItemName;
			}
		}
	}
}
