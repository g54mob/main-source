using Data.Variables;
using UnityEngine;

namespace Presentation.UI.Utils
{
	public class ToggleCanvasWidget : MonoBehaviour
	{
		[SerializeField]
		private BoolVariableSO _uiVisibility;

		private CanvasGroup _canvasGroup;

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			if (_canvasGroup == null)
			{
				_canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
			}
			_uiVisibility.ValueChanged += OnValueChanged;
		}

		private void OnDestroy()
		{
			_uiVisibility.ValueChanged -= OnValueChanged;
		}

		private void OnValueChanged(bool value)
		{
			_canvasGroup.alpha = (value ? 1 : 0);
		}
	}
}
