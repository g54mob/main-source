using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Button))]
	public class UIButtonToggle : MonoBehaviour
	{
		[SerializeField]
		private GameObject _gameObject;

		private void OnEnable()
		{
			GetComponent<Button>().onClick.AddListener(ToggleObject);
		}

		private void ToggleObject()
		{
			_gameObject.SetActive(!_gameObject.activeSelf);
		}

		private void OnDisable()
		{
			GetComponent<Button>().onClick.RemoveListener(ToggleObject);
		}
	}
}
