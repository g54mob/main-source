using System;
using System.Collections;
using DV.UI;
using DV.Utils;
using UnityEngine;

namespace DV.Hacks
{
	public static class BlackoutScreen
	{
		private const float FADE_TIME = 0.2f;

		private static Action ACTION;

		public static void Blackout(Action action)
		{
			if (ACTION != null)
			{
				Debug.LogError("Trying to blackout, when there is already a blackout in-place!");
				return;
			}
			ACTION = action;
			SingletonBehaviour<CoroutineManager>.Instance.Run(BlackoutCoroutine());
		}

		private static IEnumerator BlackoutCoroutine()
		{
			if ((bool)SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.mainCanvas.enabled = false;
			}
			ScreenFade.Fade(Color.black, 0.2f);
			yield return WaitFor.SecondsRealtime(0.2f);
			Camera camera = new GameObject("TempCam").AddComponent<Camera>();
			camera.depth = float.MaxValue;
			camera.clearFlags = CameraClearFlags.Color;
			camera.backgroundColor = Color.black;
			camera.cullingMask = 0;
			camera.Render();
			yield return null;
			camera.Render();
			yield return null;
			camera.Render();
			ACTION?.Invoke();
			ACTION = null;
		}
	}
}
