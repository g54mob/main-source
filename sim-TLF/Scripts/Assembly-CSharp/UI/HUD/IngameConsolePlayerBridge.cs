using System;
using Cheats;
using IngameDebugConsole;
using StarterAssets;
using UnityEngine;

namespace UI.HUD
{
	[RequireComponent(typeof(DebugLogManager))]
	public class IngameConsolePlayerBridge : MonoBehaviour
	{
		private DebugLogManager _console;

		private FirstPersonController _fpc;

		private CursorLockMode _prevLockState;

		private bool _prevVisible;

		private bool _prevCanRotate = true;

		private void Awake()
		{
			_console = GetComponent<DebugLogManager>();
		}

		private void Start()
		{
			DebugLogManager console = _console;
			console.OnLogWindowShown = (Action)Delegate.Combine(console.OnLogWindowShown, new Action(OnConsoleOpen));
			DebugLogManager console2 = _console;
			console2.OnLogWindowHidden = (Action)Delegate.Combine(console2.OnLogWindowHidden, new Action(OnConsoleClose));
		}

		private FirstPersonController GetFPC()
		{
			if (!(_fpc != null))
			{
				return _fpc = UnityEngine.Object.FindFirstObjectByType<FirstPersonController>();
			}
			return _fpc;
		}

		private void OnDestroy()
		{
			if (!(_console == null))
			{
				DebugLogManager console = _console;
				console.OnLogWindowShown = (Action)Delegate.Remove(console.OnLogWindowShown, new Action(OnConsoleOpen));
				DebugLogManager console2 = _console;
				console2.OnLogWindowHidden = (Action)Delegate.Remove(console2.OnLogWindowHidden, new Action(OnConsoleClose));
			}
		}

		private void OnConsoleOpen()
		{
			if (!TesterMode.IsTester)
			{
				_console.HideLogWindow();
				return;
			}
			FirstPersonController fPC = GetFPC();
			_prevCanRotate = fPC == null || fPC.CanRotateCamera;
			_prevLockState = Cursor.lockState;
			_prevVisible = Cursor.visible;
			fPC?.SetCanRotateCamera(value: false);
			CursorLockKeeper.Apply(CursorLockMode.None, visible: true);
		}

		private void OnConsoleClose()
		{
			GetFPC()?.SetCanRotateCamera(_prevCanRotate);
			CursorLockKeeper.Apply(_prevLockState, _prevVisible);
		}
	}
}
