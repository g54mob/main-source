using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Button))]
	public class ToggleableButton : MonoBehaviour, ILockable
	{
		private Button _buttonRef;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public LockToggle Toggle { get; private set; }

		public Button.ButtonClickedEvent onClick => _buttonRef.onClick;

		public bool interactable => _buttonRef.interactable;

		private void Awake()
		{
			_buttonRef = GetComponent<Button>();
			Toggle = new LockToggle(this);
		}

		public void OnToggledOff()
		{
		}

		public void OnToggledOn()
		{
		}

		void ILockable.OnLocked()
		{
			_buttonRef.interactable = false;
		}

		void ILockable.OnUnlocked()
		{
			_buttonRef.interactable = true;
		}
	}
}
