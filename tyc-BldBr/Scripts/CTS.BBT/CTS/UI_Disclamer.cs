using UnityEngine;

namespace CTS
{
	public class UI_Disclamer : MonoBehaviour
	{
		[SerializeField]
		private bool _showForTest;

		private void Awake()
		{
			if (!_showForTest)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
