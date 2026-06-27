using Restory.StorageSystem.StorageElements;
using Restory.UI.Views.StorageSlotElements;
using UnityEngine;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_StorageSlotElementDrag : MonoBehaviour
	{
		[SerializeField]
		private StorageSlotElementView view;

		public void SetItem(StorageItemElement itemElement)
		{
			view.UpdateElement(itemElement.Icon, itemElement.ElementData.Condition);
		}

		public void Show()
		{
			view.Show();
		}

		public void Hide()
		{
			view.Hide();
		}
	}
}
