using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[DefaultExecutionOrder(1)]
	public class CanvasGroupControllerToggler : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroupController _objectToToggle;

		private Button _button;

		private bool _shown;

		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void Start()
		{
			_shown = _objectToToggle.IsShown;
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			ToggleCanvasGroup();
		}

		public void ToggleCanvasGroup()
		{
			_shown = !_shown;
			_objectToToggle.ShowCanvasGroup(_shown, 0.25f);
		}
	}
}
