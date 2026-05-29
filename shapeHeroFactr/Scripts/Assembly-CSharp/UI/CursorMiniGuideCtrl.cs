using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
	public class CursorMiniGuideCtrl : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private Image image;

		private InputAction action;

		public void SetActive(bool enable)
		{
		}

		public void SetPosition(Vector3 position)
		{
		}

		private void Awake()
		{
		}

		public void ChangeInput(InputAction newAction)
		{
		}

		private void ChangeInputMode(PadInputManager.InputType inputType)
		{
		}

		private void UpdateSpriteFont()
		{
		}
	}
}
