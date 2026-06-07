using Assets.Nimbatus.Scripts.Controls;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class VersusCameraControls : MonoBehaviour
	{
		public UIButton AutoButton;

		public UIButton P1Button;

		public UIButton P2Button;

		public UIButton FreeButton;

		public Vector2 FreeModeMinPos;

		public Vector2 FreeModeMaxPos;

		private CameraController _cam;

		public void Start()
		{
			_cam = RuntimeGlobals.Camera;
			base.gameObject.SetActive(_cam.VsFocusMode != ECameraVersusMode.Off);
			_cam.SetClamp(_cam.VsFocusMode != ECameraVersusMode.Off, FreeModeMinPos, FreeModeMaxPos);
			UpdateStatus();
		}

		public void Update()
		{
			if (!RuntimeGlobals.IsGamePaused)
			{
				if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.CameraModeAuto))
				{
					_cam.SetMode(ECameraVersusMode.Auto);
				}
				else if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.CameraModePlayer1))
				{
					_cam.SetMode(ECameraVersusMode.Player1);
				}
				else if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.CameraModePlayer2))
				{
					_cam.SetMode(ECameraVersusMode.Player2);
				}
				else if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.CameraModeFree))
				{
					_cam.SetMode(ECameraVersusMode.Free);
				}
				UpdateStatus();
			}
		}

		private void UpdateStatus()
		{
			ECameraVersusMode vsFocusMode = _cam.VsFocusMode;
			AutoButton.SetState((vsFocusMode == ECameraVersusMode.Auto) ? UIButtonColor.State.Pressed : UIButtonColor.State.Normal, false);
			P1Button.SetState((vsFocusMode == ECameraVersusMode.Player1) ? UIButtonColor.State.Pressed : UIButtonColor.State.Normal, false);
			P2Button.SetState((vsFocusMode == ECameraVersusMode.Player2) ? UIButtonColor.State.Pressed : UIButtonColor.State.Normal, false);
			FreeButton.SetState((vsFocusMode == ECameraVersusMode.Free) ? UIButtonColor.State.Pressed : UIButtonColor.State.Normal, false);
		}

		public void Auto()
		{
			_cam.SetMode(ECameraVersusMode.Auto);
		}

		public void P1()
		{
			_cam.SetMode(ECameraVersusMode.Player1);
		}

		public void P2()
		{
			_cam.SetMode(ECameraVersusMode.Player2);
		}

		public void Free()
		{
			_cam.SetMode(ECameraVersusMode.Free);
		}
	}
}
