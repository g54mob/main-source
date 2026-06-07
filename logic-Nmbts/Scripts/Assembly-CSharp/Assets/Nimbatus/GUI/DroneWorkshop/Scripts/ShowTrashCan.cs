using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowTrashCan : MonoBehaviour
	{
		public TrashCan TrashCan;

		public void Update()
		{
			if (DragAndDropHelper.DraggedItem != null)
			{
				TrashCan.gameObject.SetActive(true);
			}
			else
			{
				TrashCan.gameObject.SetActive(false);
			}
		}
	}
}
