using UnityEngine;

namespace EAST_UP
{
	public class EASTUP_InventoryPanel : MonoBehaviour
	{
		public CanvasGroup cg;

		private bool isOpen;

		private void Update()
		{
			if (isOpen)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.Confined;
			}
			else
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			if (Input.GetButtonDown("Inventory"))
			{
				if (isOpen)
				{
					DisableCanvas();
				}
				else
				{
					EnableCanvas();
				}
			}
		}

		public void EnableCanvas()
		{
			EASTUP_GameManager.isInputLocked = true;
			isOpen = true;
			cg.alpha = 1f;
			cg.blocksRaycasts = true;
			cg.interactable = true;
		}

		public void DisableCanvas()
		{
			EASTUP_GameManager.isInputLocked = false;
			isOpen = false;
			cg.alpha = 0f;
			cg.blocksRaycasts = false;
			cg.interactable = false;
		}
	}
}
