using System;
using System.Collections;
using System.Collections.Generic;
using DevConsole;
using MadGoat_SSAA;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;
using UnityStandardAssets.ImageEffects;

public class AutoGfxSettings : MonoBehaviour
{
	public Antialiasing AntiAlias;

	public BloomOptimized Bloom;

	public ActorPerfTest ActorPrefab;

	public int ActorsToSpawn;

	public Vector2 ActorOrigX;

	public Vector2 ActorOrigY;

	public Vector2 ActorRangeX;

	public Vector2 ActorRangeY;

	public ScreenSpaceReflection SSR;

	public AntiAliasing SMAA;

	public MadGoatSSAA SSAAScript;

	public SSAOPro SSAO;

	public TiltShift TiltScript;

	public PipLight[] Lights;

	public Light MainLight;

	public Camera MainCam;

	public Text Label;

	public Rect GrassArea;

	public int CurrentStep = -1;

	private int LastVsync;

	private int LastTargetFrame;

	public MeshFilter Grass;

	public Mesh[] GrassLOD;

	[NonSerialized]
	private List<float> _fpsCounts = new List<float>(1024);

	private float FPSMax;

	private float lastDelta;

	public int FPSCounts = 10;

	private int CurrentFPSCount;

	private bool Started;

	public static int[] DefaultSettings = new int[6] { 0, 4, 9, 10, 13, 17 };

	public static string[] SettingNames = new string[6] { "GFXNothing", "GFXLow", "GFXMedium", "GFXHigh", "GFXVeryHigh", "GFXUltra" };

	private List<ActorPerfTest> _actors = new List<ActorPerfTest>();

	public static readonly string[] StepNames = new string[18]
	{
		"Nothing", "Bloom", "Tilt shift", "SSAO", "Simple AA", "Complex AA", "Low quality shadows", "High quality shadows", "Grass x 1", "Reflections",
		"More shadows", "Resolution x 1.2", "Resolution x 1.4", "Grass x 2", "Resolution x 1.6", "Resolution x 1.8", "Resolution x 2", "Grass x 3"
	};

	public static readonly Func<bool>[] PublicCheck = new Func<bool>[17]
	{
		() => Options.Bloom,
		() => Options.TiltShift,
		() => Options.AmbientOcclusion,
		() => Options.FXAA,
		() => Options.SMAA,
		() => Options.Shadows,
		() => Options.Shadows && Options.ShadowQuality == 3,
		() => Options.GrassQuality >= 1,
		() => Options.SSR,
		() => Options.MoreShadow,
		() => Options.SSAA >= 12,
		() => Options.SSAA >= 14,
		() => Options.GrassQuality >= 2,
		() => Options.SSAA >= 16,
		() => Options.SSAA >= 18,
		() => Options.SSAA >= 20,
		() => Options.GrassQuality == 3
	};

	public static readonly Action<AutoGfxSettings>[] LocalSteps = new Action<AutoGfxSettings>[17]
	{
		delegate(AutoGfxSettings o)
		{
			o.Bloom.enabled = true;
		},
		delegate(AutoGfxSettings o)
		{
			o.TiltScript.enabled = true;
		},
		delegate(AutoGfxSettings o)
		{
			o.SSAO.enabled = true;
		},
		delegate(AutoGfxSettings o)
		{
			o.AntiAlias.enabled = true;
		},
		delegate(AutoGfxSettings o)
		{
			o.SMAA.enabled = true;
		},
		delegate(AutoGfxSettings o)
		{
			Options.ShadowQuality = 0;
			o.MainLight.shadows = LightShadows.Soft;
		},
		delegate
		{
			Options.ShadowQuality = 3;
		},
		delegate(AutoGfxSettings o)
		{
			o.SetGrass(1);
		},
		delegate(AutoGfxSettings o)
		{
			o.SSR.enabled = true;
		},
		delegate(AutoGfxSettings o)
		{
			o.Lights.ForEachEnum(delegate(PipLight x)
			{
				x.shadowType = LightShadows.Hard;
				x.UpdateLOD(o.MainCam);
				x.UpdateShadowMap();
			});
		},
		delegate(AutoGfxSettings o)
		{
			o.SSAAScript.multiplier = 1.2f;
		},
		delegate(AutoGfxSettings o)
		{
			o.SSAAScript.multiplier = 1.4f;
		},
		delegate(AutoGfxSettings o)
		{
			o.SetGrass(2);
		},
		delegate(AutoGfxSettings o)
		{
			o.SSAAScript.multiplier = 1.6f;
		},
		delegate(AutoGfxSettings o)
		{
			o.SSAAScript.multiplier = 1.8f;
		},
		delegate(AutoGfxSettings o)
		{
			o.SSAAScript.multiplier = 2f;
		},
		delegate(AutoGfxSettings o)
		{
			o.SetGrass(3);
		}
	};

	public static readonly Action<bool>[] PublicSteps = new Action<bool>[17]
	{
		delegate(bool v)
		{
			Options.Bloom = v;
		},
		delegate(bool v)
		{
			Options.TiltShift = v;
		},
		delegate(bool v)
		{
			Options.AmbientOcclusion = v;
		},
		delegate(bool v)
		{
			Options.FXAA = v;
		},
		delegate(bool v)
		{
			Options.SMAA = v;
		},
		delegate(bool v)
		{
			if (v)
			{
				Options.Shadows = true;
				Options.ShadowQuality = 0;
			}
			else
			{
				Options.Shadows = false;
			}
		},
		delegate(bool v)
		{
			if (v)
			{
				Options.Shadows = true;
				Options.ShadowQuality = 3;
			}
		},
		delegate(bool v)
		{
			Options.GrassQuality = (v ? 1 : 0);
		},
		delegate(bool v)
		{
			Options.SSR = v;
		},
		delegate(bool v)
		{
			Options.MoreShadow = v;
		},
		delegate(bool v)
		{
			if (v)
			{
				Options.SSAA = 12;
			}
			else
			{
				Options.SSAA = 10;
			}
		},
		delegate(bool v)
		{
			if (v)
			{
				Options.SSAA = 14;
			}
		},
		delegate(bool v)
		{
			Options.GrassQuality = (v ? 2 : Options.GrassQuality);
		},
		delegate(bool v)
		{
			if (v)
			{
				Options.SSAA = 16;
			}
		},
		delegate(bool v)
		{
			if (v)
			{
				Options.SSAA = 18;
			}
		},
		delegate(bool v)
		{
			if (v)
			{
				Options.SSAA = 20;
			}
		},
		delegate(bool v)
		{
			Options.GrassQuality = (v ? 3 : Options.GrassQuality);
		}
	};

	private int _firstFrame;

	public void SetGrass(int lvl)
	{
		if (lvl == 0)
		{
			Grass.gameObject.SetActive(false);
			return;
		}
		Grass.gameObject.SetActive(true);
		Grass.sharedMesh = GrassLOD[lvl];
	}

	public static int GetLevel()
	{
		int i;
		for (i = 0; i < PublicCheck.Length && PublicCheck[i](); i++)
		{
		}
		return i;
	}

	public static int GetSetting()
	{
		int value = 0;
		bool flag = true;
		for (int i = 0; i < PublicCheck.Length; i++)
		{
			if (PublicCheck[i]())
			{
				if (!flag)
				{
					return -1;
				}
				value = i + 1;
			}
			else
			{
				flag = false;
			}
		}
		return Array.IndexOf(DefaultSettings, value);
	}

	public static void SetLevel(int lvl)
	{
		Options.MoreShadow = false;
		for (int i = 0; i < PublicSteps.Length; i++)
		{
			PublicSteps[i](i < lvl);
		}
	}

	private void Start()
	{
		PipLight.ForceWhite = false;
		LastVsync = Options.VSync;
		LastTargetFrame = Options.TargetFrameRate;
		Options.VSync = 0;
		Options.TargetFrameRate = -1;
		Shader.SetGlobalFloat("_Snow", 0f);
		for (int i = 0; i < ActorsToSpawn; i++)
		{
			ActorPerfTest actorPerfTest = UnityEngine.Object.Instantiate(ActorPrefab);
			actorPerfTest.OrigY = ActorOrigY;
			actorPerfTest.OrigX = ActorOrigX;
			actorPerfTest.RangeX = ActorRangeX;
			actorPerfTest.RangeY = ActorRangeY;
			actorPerfTest.Initialize();
			actorPerfTest.gameObject.SetActive(true);
			_actors.Add(actorPerfTest);
		}
		StartCoroutine(WaitForGo());
	}

	private IEnumerator WaitForGo()
	{
		yield return new WaitForSeconds(1f);
		Label.text = "Rendering...";
		lastDelta = Time.realtimeSinceStartup;
		Started = true;
	}

	private void Update()
	{
		if (!Started)
		{
			return;
		}
		if (_firstFrame < 5)
		{
			_firstFrame++;
			if (_firstFrame >= 5)
			{
				lastDelta = Time.realtimeSinceStartup;
			}
		}
		else
		{
			float num = Time.realtimeSinceStartup - lastDelta;
			FPSMax += num;
			num = 1f / num;
			_fpsCounts.Add(num);
			lastDelta = Time.realtimeSinceStartup;
			CurrentFPSCount++;
		}
		if (CurrentFPSCount < FPSCounts)
		{
			return;
		}
		CurrentFPSCount = 0;
		FPSMax = 0f;
		CurrentStep++;
		float num2 = _fpsCounts.Median();
		UpdateLabel(num2);
		if (CurrentStep < LocalSteps.Length)
		{
			if (num2 < 90f)
			{
				BreakNow();
				return;
			}
			LocalSteps[CurrentStep](this);
			_firstFrame = 0;
			int num3 = Array.IndexOf(DefaultSettings, CurrentStep - 1);
			if (num3 > 0)
			{
				Text label = Label;
				label.text = label.text + "\nReached " + SettingNames[num3].Loc();
			}
		}
		else
		{
			Options.VSync = LastVsync;
			Options.TargetFrameRate = LastTargetFrame;
			ChangeSettings();
			Started = false;
			NewFinish();
		}
	}

	private float GetPercentile(float perc)
	{
		_fpsCounts.Sort();
		int count = _fpsCounts.Count;
		float num = (float)(count - 1) * perc + 1f;
		if (num == 1f)
		{
			return _fpsCounts[0];
		}
		if (num == (float)count)
		{
			return _fpsCounts[count - 1];
		}
		int num2 = Mathf.FloorToInt(num);
		float num3 = num - (float)num2;
		return _fpsCounts[num2 - 1] + num3 * (_fpsCounts[num2] - _fpsCounts[num2 - 1]);
	}

	private void BreakNow()
	{
		Label.text += "\nFPS too low, stopping test";
		Options.VSync = LastVsync;
		Options.TargetFrameRate = LastTargetFrame;
		CurrentStep--;
		ChangeSettings();
		Started = false;
		NewFinish();
	}

	private void NewFinish()
	{
		_actors.ForEach(delegate(ActorPerfTest x)
		{
			x.Stop();
		});
		Options.SaveToFile();
		int level = GetLevel();
		int num = Array.IndexOf(DefaultSettings, level);
		string msg;
		if (num >= 0)
		{
			msg = "AutoGfxResultExact".Loc(SettingNames[num].Loc());
		}
		else
		{
			int num2;
			for (num2 = 1; num2 < DefaultSettings.Length && level >= DefaultSettings[num2]; num2++)
			{
			}
			msg = "AutoGfxResultBetween".Loc(SettingNames[num2 - 1].Loc(), SettingNames[num2].Loc());
		}
		WindowManager.Instance.ShowMessageBox(msg, false, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("OK", delegate
		{
			ErrorLogging.SceneChanging = true;
			DevConsole.Console.SaveConsole();
			SceneManager.LoadScene("MainMenu");
		}));
	}

	private IEnumerator Finish()
	{
		Options.SaveToFile();
		yield return new WaitForSeconds(2f);
		ErrorLogging.SceneChanging = true;
		DevConsole.Console.SaveConsole();
		SceneManager.LoadScene("MainMenu");
	}

	private void ChangeSettings()
	{
		for (int i = 0; i < PublicSteps.Length; i++)
		{
			PublicSteps[i](i < CurrentStep);
		}
	}

	private void UpdateLabel(float pct)
	{
		_fpsCounts.Average();
		float num = _fpsCounts.MaxOrDefault(0f);
		float num2 = _fpsCounts.MinOrDefault(0f);
		Text label = Label;
		label.text = label.text + "\n" + StepNames[CurrentStep] + " - " + pct.ToString("F0") + " FPS - (" + num2.ToString("F0") + "-" + num.ToString("F0") + ")";
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(GrassArea.center.ToVector3(1f), GrassArea.size.ToVector3(2f));
		Vector3 vector = ActorOrigX.ToVector3(0f);
		Vector3 vector2 = (ActorOrigX + ActorRangeX).ToVector3(0f);
		Vector3 vector3 = (ActorOrigY + ActorRangeY).ToVector3(0f);
		Vector3 vector4 = ActorOrigY.ToVector3(0f);
		Gizmos.DrawLine(vector, vector2);
		Gizmos.DrawLine(vector2, vector3);
		Gizmos.DrawLine(vector3, vector4);
		Gizmos.DrawLine(vector4, vector);
	}
}
