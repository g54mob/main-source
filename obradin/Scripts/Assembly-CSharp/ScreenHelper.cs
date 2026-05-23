using System.Collections.Generic;
using UnityEngine;

public class ScreenHelper : MonoBehaviour
{
	private bool prevFullscreen;

	private void Start()
	{
		if (!Application.isEditor)
		{
			Screen.SetResolution(Resolution.nativeResW, Resolution.nativeResH, true);
			prevFullscreen = false;
		}
	}

	public static void Boot()
	{
		if (!Application.isEditor)
		{
			ApplyScreenResolution();
		}
	}

	private void Update()
	{
		if (Camera.main == null)
		{
			Blank();
			DebugDrawer.Render(null);
		}
		if (!Application.isEditor && prevFullscreen != Screen.fullScreen)
		{
			prevFullscreen = Screen.fullScreen;
			ApplyScreenResolution();
		}
		Cursor.visible = false;
	}

	public static void ApplyScreenResolution()
	{
		int num = 1600;
		int num2 = 900;
		if (Screen.fullScreen)
		{
			if (Settings.outputModeIsAnalog)
			{
				List<UnityEngine.Resolution> list = new List<UnityEngine.Resolution>(Screen.resolutions);
				list.Sort(delegate(UnityEngine.Resolution a, UnityEngine.Resolution b)
				{
					int num3 = b.width - a.width;
					return (num3 == 0) ? (b.height - a.height) : num3;
				});
				Vector2 vector = new Vector2(Resolution.nativeResW, Resolution.nativeResH);
				Vector2 vector2 = new Vector2(1600f, 900f);
				foreach (UnityEngine.Resolution item in list)
				{
					if ((float)item.width < vector2.x || (float)item.height < vector2.y)
					{
						break;
					}
					vector.x = item.width;
					vector.y = item.height;
				}
				num = Mathf.RoundToInt(vector.x);
				num2 = Mathf.RoundToInt(vector.y);
			}
			else
			{
				num = Resolution.nativeResW;
				num2 = Resolution.nativeResH;
			}
		}
		Debug.LogFormat("ApplyScreenResolution: {0}x{1} {2} (native {3}x{4})", num, num2, (!Screen.fullScreen) ? "windowed" : "fullscreen", Resolution.nativeResW, Resolution.nativeResH);
		Screen.SetResolution(num, num2, Screen.fullScreen);
		if (CommandLine._30fps)
		{
			Debug.Log("FPS: 30");
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 30;
		}
		else if (CommandLine._60fps)
		{
			Debug.Log("FPS: 60");
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 60;
		}
		else if (CommandLine.freefps)
		{
			Debug.Log("FPS: Free");
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = -1;
		}
		else if (CommandLine.syncfps)
		{
			Debug.Log("FPS: Sync");
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = -1;
		}
		else
		{
			Debug.Log("FPS: Default");
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 60;
		}
	}

	private void Blank()
	{
		GL.Clear(false, true, Settings.colorBlack);
	}
}
