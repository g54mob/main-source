using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.SaveUI
{
	public class MapSelectionToggle : MonoBehaviour
	{
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private CanvasGroup _selected;

		private void Awake()
		{
			_toggle.onValueChanged.AddListener(OnValueChanged);
			_selected.alpha = (_toggle.isOn ? 1f : 0f);
		}

		private void OnDestroy()
		{
			_toggle.onValueChanged.RemoveListener(OnValueChanged);
		}

		private void OnValueChanged(bool value)
		{
			_selected.DOKill();
			_selected.DOFade(value ? 1f : 0f, 0.3f);
		}
	}
}
