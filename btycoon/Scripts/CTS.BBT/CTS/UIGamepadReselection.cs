using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public class UIGamepadReselection : MonoBehaviour
	{
		[SerializeField]
		private bool _wantUseAGamepad;

		[SerializeField]
		private Button _reselectionButton;

		private void Update()
		{
			if (_wantUseAGamepad && (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && EventSystem.current.currentSelectedGameObject == null)
			{
				EventSystem.current.SetSelectedGameObject(_reselectionButton.gameObject);
			}
		}
	}
}
