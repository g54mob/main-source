using Data.GameState;
using Presentation.UI.LayoutElements;
using UnityEngine;

namespace Presentation.UI.Menus.MenuEvents
{
	public class PauseButton : MonoBehaviour
	{
		[SerializeField]
		private TextToggle _toggle;

		[SerializeField]
		private PauseStateData _pauseState;

		private void Awake()
		{
			_toggle.OnValueChanged.AddListener(OnToggleValueChanged);
			_pauseState.PauseStateChanged += OnPauseStateChanged;
		}

		private void OnDestroy()
		{
			_toggle.OnValueChanged.RemoveListener(OnToggleValueChanged);
			_pauseState.PauseStateChanged -= OnPauseStateChanged;
		}

		private void OnToggleValueChanged(bool value)
		{
			_pauseState.SetPausedBuildMode(value);
		}

		private void OnPauseStateChanged(bool value)
		{
			_toggle.SetIsOnWithoutNotify(value);
		}
	}
}
