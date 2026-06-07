using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class CustomToggleScript : MonoBehaviour
	{
		[SerializeField]
		private Image _offImage;

		private Toggle _toggle;

		public void UpdateOffImage()
		{
			_offImage.gameObject.SetActive(!_toggle.isOn);
		}

		private void Awake()
		{
			_toggle = GetComponent<Toggle>();
		}

		private void Start()
		{
			_toggle.onValueChanged.AddListener(OnValueChanged);
			UpdateOffImage();
		}

		private void OnValueChanged(bool arg0)
		{
			UpdateOffImage();
		}
	}
}
