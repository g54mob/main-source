using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class StartBlackOverlay : MonoBehaviour
{
	public RawImage overlay;

	private bool hasSubscribed;

	private void Awake()
	{
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			if (cfGameSettings.super_quick_resets == 1)
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
				overlay.enabled = false;
			}
		}
	}

	private void Start()
	{
		//IL_016c: Expected I, but got O
		if (!MapGenerationController.isGenerating)
		{
			return;
		}
		if ((object)overlay != null)
		{
			overlay.enabled = true;
			hasSubscribed = true;
			Action b = OnGenerationComplete;
			Delegate obj = Delegate.Combine(MapGenerationController.A_GenerationComplete, b);
			if ((object)obj == null)
			{
				MapGenerationController.A_GenerationComplete = null;
				return;
			}
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			Delegate obj3 = obj;
			nint num = (nint)typeof(Action);
			if (flag2)
			{
				goto IL_01ad;
			}
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag3 = (object)obj.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag3)
			{
				obj4 = obj;
			}
			bool flag4 = (object)obj4 == null;
			obj3 = obj;
			NullReferenceException typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (!flag4)
			{
				return;
			}
		}
		else
		{
			NullReferenceException typeFromHandle = new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ad;
		IL_01ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnGenerationComplete()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183173024]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("HideBlackScreen", 0f);
	}

	private void HideBlackScreen()
	{
		overlay.enabled = false;
	}

	private void OnDestroy()
	{
		//IL_0144: Expected I, but got O
		if (!hasSubscribed)
		{
			return;
		}
		Action value = OnGenerationComplete;
		Delegate obj = Delegate.Remove(MapGenerationController.A_GenerationComplete, value);
		if ((object)obj == null)
		{
			MapGenerationController.A_GenerationComplete = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}
}
