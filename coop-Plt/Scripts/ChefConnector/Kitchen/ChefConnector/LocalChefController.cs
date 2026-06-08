using UnityEngine;

namespace Kitchen.ChefConnector
{
	public class LocalChefController : MonoBehaviour
	{
		public static LocalChefController Main;

		public Camera UICamera;

		public void SetUIVisibility(bool visibility)
		{
			UICamera.cullingMask = (visibility ? (1 << LayerMask.NameToLayer("UI")) : 0);
		}

		private void Start()
		{
			Main = this;
		}
	}
}
