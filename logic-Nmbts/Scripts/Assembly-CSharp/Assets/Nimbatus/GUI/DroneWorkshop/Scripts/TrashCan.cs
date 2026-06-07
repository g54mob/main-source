using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class TrashCan : MonoBehaviour
	{
		public void OnClick()
		{
			OnDrop(DragAndDropHelper.DraggedItem.gameObject);
		}

		public void OnDrop(GameObject o)
		{
			if (DragAndDropHelper.DraggedItem != null)
			{
				DragAndDropHelper.DeleteDraggedItem();
			}
		}
	}
}
