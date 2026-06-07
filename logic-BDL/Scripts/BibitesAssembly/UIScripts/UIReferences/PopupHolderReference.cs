using ManagementScripts;
using UnityEngine;

namespace UIScripts.UIReferences
{
	public class PopupHolderReference : MonoBehaviour
	{
		[SerializeField]
		private GameObject blockingScreenRef;

		private void Awake()
		{
			PopupManager.popupHolder = base.transform;
			PopupManager.screenBlocker = blockingScreenRef;
			blockingScreenRef.SetActive(value: false);
		}
	}
}
