using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Debug;
using Assets.Scripts.UI.HUD;
using Assets.Scripts.UI.InGame.Levelup;
using Cpp2ILInjected;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	public DeathScreen deathScreen;

	public ScoreUi scoreUi;

	public EncounterWindows encounterWindows;

	public MapTitle mapTile;

	public PauseUi pause;

	public ShrineLogs shrineLogs;

	public ObjectiveArrow objectiveArrow;

	public AlertUi alertUi;

	public ServerFeed feed;

	public ObjectiveUi objective;

	public ColorFilterUI colorFilterUi;

	public GameObject hud;

	public CinematicBars cinematicBars;

	private bool inited;

	public static UiManager Instance;

	public CanvasGroup hudGroup;

	private void Awake()
	{
		TryInit();
	}

	private void Start()
	{
		RefreshHud();
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
	}

	public void TryInit()
	{
		//IL_036d: Expected O, but got I4
		//IL_0383: Expected I, but got O
		//IL_03a9: Expected O, but got I4
		//IL_03bf: Expected I, but got O
		//IL_03e5: Expected O, but got I4
		//IL_03fb: Expected I, but got O
		//IL_0421: Expected O, but got I4
		//IL_0437: Expected I, but got O
		//IL_0290: Expected I, but got O
		//IL_0481: Expected O, but got I4
		//IL_0300: Expected I, but got O
		if (inited)
		{
			return;
		}
		inited = true;
		if (Instance == null)
		{
			Instance = this;
			hud.SetActive(value: false);
			if (MapController.IsFirstStage())
			{
				List<StatModifier> backLog = new List<StatModifier>();
				ShrineLogs.backLog = backLog;
				List<StatModifier> shownLog = new List<StatModifier>();
				ShrineLogs.shownLog = shownLog;
			}
			Action b = OnPortalOpen;
			Delegate obj = Delegate.Combine(SpawnPlayerPortal.A_PortalOpen, b);
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				SpawnPlayerPortal.A_PortalOpen = null;
			}
			else
			{
				bool flag = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				bool flag2 = (object)obj2 == null;
				obj3 = 0;
				obj4 = obj;
				nint num = (nint)typeof(Action);
				if (flag2)
				{
					goto IL_048c;
				}
				SpawnPlayerPortal.A_PortalOpen = (Action)obj2;
				bool flag3 = (object)obj.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag3)
				{
					obj5 = obj;
				}
				bool flag4 = (object)obj5 == null;
				obj3 = 0;
				obj4 = obj;
				nint num2 = (nint)typeof(Action);
				if (flag4)
				{
					goto IL_049c;
				}
			}
			Action b2 = OnPortalClose;
			Delegate obj6 = Delegate.Combine(SpawnPlayerPortal.A_PortalClosed, b2);
			if ((object)obj6 == null)
			{
				SpawnPlayerPortal.A_PortalClosed = null;
			}
			else
			{
				bool flag5 = (object)obj6.GetType() != typeof(Action);
				Delegate obj7 = null;
				if (!flag5)
				{
					obj7 = obj6;
				}
				bool flag6 = (object)obj7 == null;
				obj3 = 0;
				obj4 = obj6;
				nint num3 = (nint)typeof(Action);
				if (flag6)
				{
					goto IL_04ac;
				}
				SpawnPlayerPortal.A_PortalClosed = (Action)obj7;
				bool flag7 = (object)obj6.GetType() != typeof(Action);
				Delegate obj8 = null;
				if (!flag7)
				{
					obj8 = obj6;
				}
				bool flag8 = (object)obj8 == null;
				obj3 = 0;
				obj4 = obj6;
				nint num4 = (nint)typeof(Action);
				if (flag8)
				{
					goto IL_04bc;
				}
			}
			Action<string, object, object> b3 = OnSettingUpdated;
			Delegate obj9 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b3);
			if ((object)obj9 == null)
			{
				CurrentSettings.A_SettingUpdated = null;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action = default(Action<string, object, object>);
			bool flag9 = action == null;
			nint num5 = (nint)typeof(Action<string, object, object>);
			if (!flag9)
			{
				CurrentSettings.A_SettingUpdated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj10 = default(object);
				if (obj10 != null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num5 = (nint)typeof(Action<string, object, object>);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj3 = 0;
			obj4 = null;
			goto IL_04bc;
		}
		GameObject obj11 = base.gameObject;
		UnityEngine.Object.Destroy(obj11);
		return;
		IL_04ac:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049c;
		IL_048c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		throw new NullReferenceException();
		IL_04bc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ac;
		IL_049c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_048c;
	}

	private void Update()
	{
		if (!(DebugConsole.Instance != null) || !DebugConsole.Instance.IsActive())
		{
			GameObject gameObject = pause.gameObject;
			if ((gameObject.activeInHierarchy && MyInputManager.GetButtonDown(MyInputManager.UICancel)) || MyInputManager.GetButtonDown(MyInputManager.UIAbort))
			{
				pause.Toggle();
			}
		}
	}

	private void RefreshHud()
	{
		//IL_00fa: Expected F4, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null && config.cfGameSettings != null)
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config2 = saveManager2.config;
				CFGameSettings cfGameSettings = config2.cfGameSettings;
				float alpha = ((cfGameSettings.show_hud != 1) ? 0f : 1f);
				hudGroup.alpha = alpha;
			}
		}
	}

	private void OnDestroy()
	{
		//IL_0276: Expected O, but got I4
		//IL_02e9: Expected O, but got I4
		//IL_02ff: Expected I, but got O
		//IL_0325: Expected O, but got I4
		//IL_033b: Expected I, but got O
		//IL_0361: Expected O, but got I4
		//IL_0377: Expected I, but got O
		//IL_01f2: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		Delegate a_PortalOpen = SpawnPlayerPortal.A_PortalOpen;
		Action action = OnPortalOpen;
		Delegate obj = Delegate.Remove(SpawnPlayerPortal.A_PortalOpen, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SpawnPlayerPortal.A_PortalOpen = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_03bd;
			}
			SpawnPlayerPortal.A_PortalOpen = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03cd;
			}
		}
		Action value = OnPortalClose;
		Delegate obj6 = Delegate.Remove(SpawnPlayerPortal.A_PortalClosed, value);
		if ((object)obj6 == null)
		{
			SpawnPlayerPortal.A_PortalClosed = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num2 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_03d8;
			}
			SpawnPlayerPortal.A_PortalClosed = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_03e8;
			}
		}
		Action<string, object, object> value2 = OnSettingUpdated;
		Delegate obj9 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value2);
		if ((object)obj9 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action3 = default(Action<string, object, object>);
		bool flag8 = action3 == null;
		a_PortalOpen = (Delegate)(object)typeof(Action<string, object, object>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (flag8)
		{
			goto IL_03ad;
		}
		CurrentSettings.A_SettingUpdated = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj10 = default(object);
		bool flag9 = obj10 == null;
		a_PortalOpen = (Delegate)(object)typeof(Action<string, object, object>);
		action2 = (Action)obj9;
		obj3 = 0;
		obj4 = null;
		if (!flag9)
		{
			return;
		}
		goto IL_03bd;
		IL_03bd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ad;
		IL_03ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03e8;
		IL_03e8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03d8;
		IL_03cd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03d8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03cd;
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183173038]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "show_hud")
		{
			RefreshHud();
		}
	}

	private void OnPortalOpen()
	{
		hud.SetActive(value: false);
	}

	private void OnPortalClose()
	{
		hud.SetActive(value: true);
	}
}
