using UnityEngine;

namespace Kitchen
{
	public struct Door
	{
		public Vector3 Tile1;

		public Vector3 Tile2;

		public GameObject DoorGameObject;

		public GameObject HatchGameObject;

		public DoorController DoorController;

		public bool MoveAtNight;

		public bool IsCurrentlyDisabled;

		public void Update(bool is_door, bool force = false)
		{
			if (is_door && DoorController != null)
			{
				DoorController.ResetAngle();
			}
			DoorGameObject.SetActive(is_door);
			HatchGameObject.SetActive(!is_door);
			IsCurrentlyDisabled = !is_door;
		}
	}
}
