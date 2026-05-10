using CTS.BBT;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class OpenBarToggle : CTSBehaviour, IRepaint
	{
		[SerializeField]
		[Inject(false)]
		private Toggle _toggle;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnValueChanged);
			LevelParameters.OnBarOpenedStatusChanged += OnBarOpenedStatusChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnValueChanged);
			LevelParameters.OnBarOpenedStatusChanged -= OnBarOpenedStatusChanged;
		}

		private void OnValueChanged(bool isOn)
		{
			CTSSingleton<LevelParameters>.Instance.SetOpened(!isOn);
		}

		private void OnBarOpenedStatusChanged(bool open)
		{
			if (_toggle.isOn != !CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				Repaint();
			}
		}

		public void Repaint()
		{
			_toggle.isOn = !CTSSingleton<LevelParameters>.Instance.IsOpen;
		}
	}
}
