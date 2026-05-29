using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class WallHideButtonUpdater : CTSBehaviour
	{
		[SerializeField]
		private UnityEvent<bool> _onActiveStateChanged;

		public static event Action ChangeWallStateSound;

		protected override void OnAwake()
		{
			base.OnAwake();
			WallHideButton.ActiveStateChanged += OnValueChanged;
		}

		private void OnDestroy()
		{
			WallHideButton.ActiveStateChanged -= OnValueChanged;
		}

		private void OnValueChanged(bool value)
		{
			WallHideButtonUpdater.ChangeWallStateSound?.Invoke();
			_onActiveStateChanged.Invoke(value);
		}
	}
}
