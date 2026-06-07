using UnityEngine;

namespace CurvedUI
{
	public class CUI_TMPChecker : MonoBehaviour
	{
		[SerializeField]
		private GameObject testMsg;

		[SerializeField]
		private GameObject enabledMsg;

		[SerializeField]
		private GameObject disabledMsg;

		private void Start()
		{
			testMsg.gameObject.SetActive(value: false);
			enabledMsg.gameObject.SetActive(value: true);
			disabledMsg.gameObject.SetActive(value: false);
		}
	}
}
