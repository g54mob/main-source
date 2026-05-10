using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_SearchBar : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _inputTextField;

		private void Awake()
		{
			_inputTextField.text = string.Empty;
			FurnitureShop.FurnitureShopStatusChanged += FurnitureShop_FurnitureShopStatusChanged;
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
			FurnitureShop.FurnitureShopStatusChanged -= FurnitureShop_FurnitureShopStatusChanged;
		}

		public void ClearText()
		{
			_inputTextField.text = string.Empty;
		}

		private void FurnitureShop_FurnitureShopStatusChanged(bool obj)
		{
			_inputTextField.text = string.Empty;
		}

		public bool ComparatorNameAndText(string name)
		{
			string value = TextCorrection(_inputTextField.text);
			if (TextCorrection(name).Contains(value))
			{
				return true;
			}
			return false;
		}

		private string TextCorrection(string textToCorrect)
		{
			textToCorrect = textToCorrect.ToLower();
			textToCorrect = textToCorrect.Replace(" ", "");
			textToCorrect = textToCorrect.Replace("-", "");
			return textToCorrect;
		}

		public void StopMovementCamera()
		{
			MainCamera instance = MonoSingleton<MainCamera>.Instance;
			if (instance != null)
			{
				instance.Movements.enabled = false;
				instance.CameraRotation.enabled = false;
				instance.Zoom.enabled = false;
			}
		}

		public void GiveMovementCamera()
		{
			MainCamera instance = MonoSingleton<MainCamera>.Instance;
			if (instance != null)
			{
				instance.Movements.enabled = true;
				instance.CameraRotation.enabled = true;
				instance.Zoom.enabled = true;
			}
		}
	}
}
