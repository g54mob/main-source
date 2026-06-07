using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Performance/MMFPSUnlock")]
	public class MMFPSUnlock : MonoBehaviour
	{
		[Tooltip("the target FPS you want the game to run at, that's up to how many times Update will run every second")]
		public int TargetFPS = 300;

		[Tooltip("the number of frames to wait before rendering the next one. 0 will render every frame, 1 will render every 2 frames, 5 will render every 5 frames, etc")]
		public int RenderFrameInterval;

		[Range(0f, 2f)]
		[Tooltip("whether vsync should be enabled or not (on a 60Hz screen, 1 : 60fps, 2 : 30fps, 0 : don't wait for vsync)")]
		public int VSyncCount;

		[Tooltip("if this is true, the user can press a number key to change the target FPS (1 : 10fps, 2 : 20fps, etc)")]
		public bool EnableNumberShortcuts;

		protected virtual void Start()
		{
			UpdateSettings();
		}

		protected virtual void Update()
		{
			HandleInput();
		}

		protected virtual void OnValidate()
		{
			UpdateSettings();
		}

		protected virtual void UpdateSettings()
		{
			QualitySettings.vSyncCount = VSyncCount;
			Application.targetFrameRate = TargetFPS;
			OnDemandRendering.renderFrameInterval = RenderFrameInterval;
		}

		protected virtual void HandleInput()
		{
			if (EnableNumberShortcuts)
			{
				if (Keyboard.current[Key.Digit0].wasPressedThisFrame)
				{
					TargetFPS = 300;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
				{
					TargetFPS = 10;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
				{
					TargetFPS = 20;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit3].wasPressedThisFrame)
				{
					TargetFPS = 30;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit4].wasPressedThisFrame)
				{
					TargetFPS = 40;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit5].wasPressedThisFrame)
				{
					TargetFPS = 50;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit6].wasPressedThisFrame)
				{
					TargetFPS = 60;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit7].wasPressedThisFrame)
				{
					TargetFPS = 70;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit8].wasPressedThisFrame)
				{
					TargetFPS = 80;
					UpdateSettings();
				}
				if (Keyboard.current[Key.Digit9].wasPressedThisFrame)
				{
					TargetFPS = 90;
					UpdateSettings();
				}
			}
		}
	}
}
