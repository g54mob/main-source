using UnityEngine;
using UnityEngine.EventSystems;

namespace VRTK
{
	public struct UIPointerEventArgs
	{
		public VRTK_ControllerReference controllerReference;

		public bool isActive;

		public GameObject currentTarget;

		public GameObject previousTarget;

		public RaycastResult raycastResult;
	}
}
