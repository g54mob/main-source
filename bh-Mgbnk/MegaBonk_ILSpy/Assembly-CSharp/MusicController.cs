using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	public static MusicController Instance;

	public AudioSource musicSource;

	public AudioLowPassFilter lowpassFilter;

	private float volumeMultiplier = 1f;

	private float desiredVolumeMultiplier = 1f;

	private float desiredVolume = 1f;

	private float desiredLowpass = 22000f;

	public MusicTrack menuMusicTrack;

	private MusicTrack currentTrack;

	private bool isPlayingIntro;

	private float introLength;

	private float defaultPitch = 1f;

	private float nextCheckTime;

	private float checkCooldown = 0.05f;

	private FinalFightController finalFightController;

	private int lowpassLow = 600;

	private float currentDangerPitch = 1f;

	private Dictionary<MusicPauseZone, float> zoneInfluences;

	private float zoneMultiplier;

	private void Awake()
	{
		//IL_06f7: Expected O, but got I4
		//IL_070d: Expected I, but got O
		//IL_0733: Expected O, but got I4
		//IL_0749: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_07b7: Expected I, but got O
		//IL_07c8: Expected O, but got I4
		//IL_07de: Expected I, but got O
		//IL_0804: Expected I, but got O
		//IL_0815: Expected O, but got I4
		//IL_082b: Expected I, but got O
		//IL_0851: Expected I, but got O
		//IL_0862: Expected O, but got I4
		//IL_0878: Expected I, but got O
		//IL_089e: Expected I, but got O
		//IL_08af: Expected O, but got I4
		//IL_08c5: Expected I, but got O
		//IL_08eb: Expected I, but got O
		//IL_08fc: Expected O, but got I4
		//IL_0912: Expected I, but got O
		//IL_0938: Expected I, but got O
		//IL_0949: Expected O, but got I4
		//IL_095f: Expected I, but got O
		//IL_0985: Expected I, but got O
		//IL_0996: Expected O, but got I4
		//IL_09ac: Expected I, but got O
		//IL_09d2: Expected I, but got O
		//IL_09e3: Expected O, but got I4
		//IL_09f9: Expected I, but got O
		//IL_0a1f: Expected I, but got O
		//IL_0a30: Expected O, but got I4
		//IL_0a46: Expected I, but got O
		//IL_0a6c: Expected I, but got O
		//IL_0a7d: Expected O, but got I4
		//IL_0a93: Expected I, but got O
		//IL_063c: Expected I, but got O
		//IL_0ae5: Expected O, but got I4
		//IL_06ad: Expected I, but got O
		if (Instance == null)
		{
			Instance = this;
			Action b = OnPlayerDied;
			Delegate obj = Delegate.Combine(PlayerHealth.A_Died, b);
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				PlayerHealth.A_Died = null;
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
					goto IL_0aef;
				}
				PlayerHealth.A_Died = (Action)obj2;
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
					goto IL_0afa;
				}
			}
			Action<string, object, object> b2 = OnSettingUpdated;
			Delegate obj6 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b2);
			nint num3;
			Delegate obj7;
			if ((object)obj6 == null)
			{
				CurrentSettings.A_SettingUpdated = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<string, object, object> action = default(Action<string, object, object>);
				bool flag5 = action == null;
				num3 = (nint)typeof(Action<string, object, object>);
				obj7 = obj6;
				obj3 = 0;
				obj4 = null;
				if (flag5)
				{
					goto IL_077f;
				}
				CurrentSettings.A_SettingUpdated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj8 = default(object);
				bool flag6 = obj8 == null;
				num3 = (nint)typeof(Action<string, object, object>);
				obj7 = obj6;
				obj3 = 0;
				obj4 = null;
				if (flag6)
				{
					goto IL_078f;
				}
			}
			Action action2 = OnChestOpening;
			Delegate obj9 = Delegate.Combine(ChestWindowUi.A_Open, action2);
			if ((object)obj9 == null)
			{
				ChestWindowUi.A_Open = null;
			}
			else
			{
				bool flag7 = (object)obj9.GetType() != typeof(Action);
				Delegate obj10 = null;
				if (!flag7)
				{
					obj10 = obj9;
				}
				bool flag8 = (object)obj10 == null;
				num3 = (nint)ChestWindowUi.A_Open;
				obj7 = action2;
				obj3 = 0;
				obj4 = obj9;
				nint num4 = (nint)typeof(Action);
				if (flag8)
				{
					goto IL_0b0a;
				}
				ChestWindowUi.A_Open = (Action)obj10;
				bool flag9 = (object)obj9.GetType() != typeof(Action);
				Delegate obj11 = null;
				if (!flag9)
				{
					obj11 = obj9;
				}
				bool flag10 = (object)obj11 == null;
				num3 = (nint)ChestWindowUi.A_Open;
				obj7 = action2;
				obj3 = 0;
				obj4 = obj9;
				nint num5 = (nint)typeof(Action);
				if (flag10)
				{
					goto IL_0b1a;
				}
			}
			Action action3 = OnChestClosed;
			Delegate obj12 = Delegate.Combine(ChestWindowUi.A_Close, action3);
			if ((object)obj12 == null)
			{
				ChestWindowUi.A_Close = null;
			}
			else
			{
				bool flag11 = (object)obj12.GetType() != typeof(Action);
				Delegate obj13 = null;
				if (!flag11)
				{
					obj13 = obj12;
				}
				bool flag12 = (object)obj13 == null;
				num3 = (nint)ChestWindowUi.A_Close;
				obj7 = action3;
				obj3 = 0;
				obj4 = obj12;
				nint num6 = (nint)typeof(Action);
				if (flag12)
				{
					goto IL_0b2a;
				}
				ChestWindowUi.A_Close = (Action)obj13;
				bool flag13 = (object)obj12.GetType() != typeof(Action);
				Delegate obj14 = null;
				if (!flag13)
				{
					obj14 = obj12;
				}
				bool flag14 = (object)obj14 == null;
				num3 = (nint)ChestWindowUi.A_Close;
				obj7 = action3;
				obj3 = 0;
				obj4 = obj12;
				nint num7 = (nint)typeof(Action);
				if (flag14)
				{
					goto IL_0b3a;
				}
			}
			Action action4 = OnStageStarted;
			Delegate obj15 = Delegate.Combine(GameManager.A_StageStarted, action4);
			if ((object)obj15 == null)
			{
				GameManager.A_StageStarted = null;
			}
			else
			{
				bool flag15 = (object)obj15.GetType() != typeof(Action);
				Delegate obj16 = null;
				if (!flag15)
				{
					obj16 = obj15;
				}
				bool flag16 = (object)obj16 == null;
				num3 = (nint)GameManager.A_StageStarted;
				obj7 = action4;
				obj3 = 0;
				obj4 = obj15;
				nint num8 = (nint)typeof(Action);
				if (flag16)
				{
					goto IL_0b4a;
				}
				GameManager.A_StageStarted = (Action)obj16;
				bool flag17 = (object)obj15.GetType() != typeof(Action);
				Delegate obj17 = null;
				if (!flag17)
				{
					obj17 = obj15;
				}
				bool flag18 = (object)obj17 == null;
				num3 = (nint)GameManager.A_StageStarted;
				obj7 = action4;
				obj3 = 0;
				obj4 = obj15;
				nint num9 = (nint)typeof(Action);
				if (flag18)
				{
					goto IL_0b5a;
				}
			}
			Action action5 = OnMainMenu;
			Delegate obj18 = Delegate.Combine(MainMenu.A_MenuOpened, action5);
			if ((object)obj18 == null)
			{
				MainMenu.A_MenuOpened = null;
			}
			else
			{
				bool flag19 = (object)obj18.GetType() != typeof(Action);
				Delegate obj19 = null;
				if (!flag19)
				{
					obj19 = obj18;
				}
				bool flag20 = (object)obj19 == null;
				num3 = (nint)MainMenu.A_MenuOpened;
				obj7 = action5;
				obj3 = 0;
				obj4 = obj18;
				nint num10 = (nint)typeof(Action);
				if (flag20)
				{
					goto IL_0b6a;
				}
				MainMenu.A_MenuOpened = (Action)obj19;
				bool flag21 = (object)obj18.GetType() != typeof(Action);
				Delegate obj20 = null;
				if (!flag21)
				{
					obj20 = obj18;
				}
				bool flag22 = (object)obj20 == null;
				num3 = (nint)MainMenu.A_MenuOpened;
				obj7 = action5;
				obj3 = 0;
				obj4 = obj18;
				nint num11 = (nint)typeof(Action);
				if (flag22)
				{
					goto IL_0b7a;
				}
			}
			Action action6 = OnSceneTransitionStart;
			Delegate obj21 = Delegate.Combine(TransitionUI.A_MapTransitionStart, action6);
			if ((object)obj21 == null)
			{
				TransitionUI.A_MapTransitionStart = null;
			}
			else
			{
				bool flag23 = (object)obj21.GetType() != typeof(Action);
				Delegate obj22 = null;
				if (!flag23)
				{
					obj22 = obj21;
				}
				bool flag24 = (object)obj22 == null;
				num3 = (nint)TransitionUI.A_MapTransitionStart;
				obj7 = action6;
				obj3 = 0;
				obj4 = obj21;
				nint num12 = (nint)typeof(Action);
				if (flag24)
				{
					goto IL_0b8a;
				}
				TransitionUI.A_MapTransitionStart = (Action)obj22;
				bool flag25 = (object)obj21.GetType() != typeof(Action);
				Delegate obj23 = null;
				if (!flag25)
				{
					obj23 = obj21;
				}
				bool flag26 = (object)obj23 == null;
				num3 = (nint)TransitionUI.A_MapTransitionStart;
				obj7 = action6;
				obj3 = 0;
				obj4 = obj21;
				nint num13 = (nint)typeof(Action);
				if (flag26)
				{
					goto IL_0b9a;
				}
			}
			Action<bool> b3 = OnPause;
			Delegate obj24 = Delegate.Combine(MyTime.A_Pause, b3);
			if ((object)obj24 == null)
			{
				MyTime.A_Pause = null;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action7 = default(Action<bool>);
			bool flag27 = action7 == null;
			num3 = (nint)typeof(Action<bool>);
			if (!flag27)
			{
				MyTime.A_Pause = action7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj25 = default(object);
				if (obj25 != null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num3 = (nint)typeof(Action<bool>);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj7 = obj24;
			obj3 = 0;
			obj4 = null;
			goto IL_0b9a;
		}
		GameObject obj26 = base.gameObject;
		UnityEngine.Object.Destroy(obj26);
		return;
		IL_0b3a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b2a;
		IL_0b0a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_078f;
		IL_0b6a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b5a;
		IL_0b2a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b1a;
		IL_0aef:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_078f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_077f;
		IL_0b9a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b8a;
		IL_0b4a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b3a;
		IL_0b5a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b4a;
		IL_0b8a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b7a;
		IL_077f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0afa;
		IL_0afa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0aef;
		IL_0b7a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b6a;
		IL_0b1a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b0a;
	}

	private void OnDestroy()
	{
		//IL_06ee: Expected O, but got I4
		//IL_0767: Expected O, but got I4
		//IL_077d: Expected I, but got O
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_0b2b: Expected I, but got O
		//IL_07eb: Expected I, but got O
		//IL_07fc: Expected O, but got I4
		//IL_0812: Expected I, but got O
		//IL_0838: Expected I, but got O
		//IL_0849: Expected O, but got I4
		//IL_085f: Expected I, but got O
		//IL_0884: Expected I, but got O
		//IL_0895: Expected O, but got I4
		//IL_08ab: Expected I, but got O
		//IL_08d9: Expected O, but got I4
		//IL_08ef: Expected I, but got O
		//IL_091d: Expected O, but got I4
		//IL_0933: Expected I, but got O
		//IL_0961: Expected O, but got I4
		//IL_0977: Expected I, but got O
		//IL_09a5: Expected O, but got I4
		//IL_09bb: Expected I, but got O
		//IL_09e9: Expected O, but got I4
		//IL_09ff: Expected I, but got O
		//IL_0a2d: Expected O, but got I4
		//IL_0a43: Expected I, but got O
		//IL_0a71: Expected O, but got I4
		//IL_0a87: Expected I, but got O
		//IL_066b: Expected O, but got I4
		//IL_06bf: Expected O, but got I4
		if (!(Instance == this))
		{
			return;
		}
		Delegate obj = PlayerHealth.A_Died;
		Action action = OnPlayerDied;
		Delegate obj2 = Delegate.Remove(PlayerHealth.A_Died, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			PlayerHealth.A_Died = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_0acd;
			}
			PlayerHealth.A_Died = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0add;
			}
		}
		Action<string, object, object> value = OnSettingUpdated;
		Delegate obj7 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action3 = default(Action<string, object, object>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_07b3;
			}
			CurrentSettings.A_SettingUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_07c3;
			}
		}
		Action action4 = OnChestOpening;
		Delegate obj10 = Delegate.Remove(ChestWindowUi.A_Open, action4);
		if ((object)obj10 == null)
		{
			ChestWindowUi.A_Open = null;
		}
		else
		{
			bool flag6 = (object)obj10.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag6)
			{
				obj11 = obj10;
			}
			bool flag7 = (object)obj11 == null;
			num2 = (nint)ChestWindowUi.A_Open;
			obj8 = action4;
			obj4 = 0;
			obj5 = obj10;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0ae8;
			}
			ChestWindowUi.A_Open = (Action)obj11;
			bool flag8 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag8)
			{
				obj12 = obj10;
			}
			bool flag9 = (object)obj12 == null;
			num2 = (nint)ChestWindowUi.A_Open;
			obj8 = action4;
			obj4 = 0;
			obj5 = obj10;
			nint num4 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0af8;
			}
		}
		obj = ChestWindowUi.A_Close;
		Action action5 = OnChestClosed;
		Delegate obj13 = Delegate.Remove(ChestWindowUi.A_Close, action5);
		if ((object)obj13 == null)
		{
			ChestWindowUi.A_Close = null;
		}
		else
		{
			bool flag10 = (object)obj13.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj13;
			}
			bool flag11 = (object)obj14 == null;
			num2 = (nint)obj;
			obj8 = action5;
			obj4 = 0;
			obj5 = obj13;
			nint num5 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_0b08;
			}
			ChestWindowUi.A_Close = (Action)obj14;
			bool flag12 = (object)obj13.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag12)
			{
				obj15 = obj13;
			}
			bool flag13 = (object)obj15 == null;
			action2 = action5;
			obj4 = 0;
			obj5 = obj13;
			nint num6 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_0b18;
			}
		}
		obj = GameManager.A_StageStarted;
		Action action6 = OnStageStarted;
		Delegate obj16 = Delegate.Remove(GameManager.A_StageStarted, action6);
		if ((object)obj16 == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag14 = (object)obj16.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj16;
			}
			bool flag15 = (object)obj17 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj16;
			nint num7 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0b38;
			}
			GameManager.A_StageStarted = (Action)obj17;
			bool flag16 = (object)obj16.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag16)
			{
				obj18 = obj16;
			}
			bool flag17 = (object)obj18 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj16;
			nint num8 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_0b48;
			}
		}
		obj = MainMenu.A_MenuOpened;
		Action action7 = OnMainMenu;
		Delegate obj19 = Delegate.Remove(MainMenu.A_MenuOpened, action7);
		if ((object)obj19 == null)
		{
			MainMenu.A_MenuOpened = null;
		}
		else
		{
			bool flag18 = (object)obj19.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag18)
			{
				obj20 = obj19;
			}
			bool flag19 = (object)obj20 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj19;
			nint num9 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_0b58;
			}
			MainMenu.A_MenuOpened = (Action)obj20;
			bool flag20 = (object)obj19.GetType() != typeof(Action);
			Delegate obj21 = null;
			if (!flag20)
			{
				obj21 = obj19;
			}
			bool flag21 = (object)obj21 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj19;
			nint num10 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_0b68;
			}
		}
		obj = TransitionUI.A_transitionStart;
		Action action8 = OnSceneTransitionStart;
		Delegate obj22 = Delegate.Remove(TransitionUI.A_transitionStart, action8);
		if ((object)obj22 == null)
		{
			TransitionUI.A_transitionStart = null;
		}
		else
		{
			bool flag22 = (object)obj22.GetType() != typeof(Action);
			Delegate obj23 = null;
			if (!flag22)
			{
				obj23 = obj22;
			}
			bool flag23 = (object)obj23 == null;
			action2 = action8;
			obj4 = 0;
			obj5 = obj22;
			nint num11 = (nint)typeof(Action);
			if (flag23)
			{
				goto IL_0b78;
			}
			TransitionUI.A_transitionStart = (Action)obj23;
			bool flag24 = (object)obj22.GetType() != typeof(Action);
			Delegate obj24 = null;
			if (!flag24)
			{
				obj24 = obj22;
			}
			bool flag25 = (object)obj24 == null;
			action2 = action8;
			obj4 = 0;
			obj5 = obj22;
			nint num12 = (nint)typeof(Action);
			if (flag25)
			{
				goto IL_0b88;
			}
		}
		Action<bool> value2 = OnPause;
		Delegate obj25 = Delegate.Remove(MyTime.A_Pause, value2);
		if ((object)obj25 == null)
		{
			MyTime.A_Pause = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action9 = default(Action<bool>);
		bool flag26 = action9 == null;
		obj = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj25;
		obj4 = 0;
		obj5 = null;
		if (flag26)
		{
			goto IL_0abd;
		}
		MyTime.A_Pause = action9;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj26 = default(object);
		bool flag27 = obj26 == null;
		obj = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj25;
		obj4 = 0;
		obj5 = null;
		if (!flag27)
		{
			return;
		}
		goto IL_0acd;
		IL_07c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07b3;
		IL_0b38:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b18;
		IL_0b08:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0af8;
		IL_0ae8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07c3;
		IL_0abd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b88;
		IL_0b58:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b48;
		IL_0acd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0abd;
		IL_0b88:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b78;
		IL_0b48:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b38;
		IL_0b18:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_0b08;
		IL_0b78:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b68;
		IL_07b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0add;
		IL_0add:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0b68:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b58;
		IL_0af8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0ae8;
	}

	private void OnStageStarted()
	{
		desiredVolumeMultiplier = 0f;
		zoneInfluences.Clear();
		zoneMultiplier = 1f;
		if (!MapController.isFinalBossStage)
		{
			MusicTrack musicTrackToPlay = MusicUtility.GetMusicTrackToPlay(MapController.runConfig);
			PlayMusicTrack(musicTrackToPlay);
			desiredVolume = 1f;
			musicSource.volume = 1f;
		}
	}

	private void OnSceneTransitionStart()
	{
		zoneInfluences.Clear();
		zoneMultiplier = 1f;
		desiredVolumeMultiplier = 0f;
	}

	public void StopMusic()
	{
		desiredVolumeMultiplier = 0f;
	}

	public void PlayStageMusic()
	{
		MusicTrack musicTrackToPlay = MusicUtility.GetMusicTrackToPlay(MapController.runConfig);
		PlayMusicTrack(musicTrackToPlay);
		desiredVolume = 1f;
		musicSource.volume = 1f;
	}

	public void PlayMenuTrack()
	{
		zoneInfluences.Clear();
		zoneMultiplier = 1f;
		PlayMusicTrack(menuMusicTrack);
		desiredVolume = 0.75f;
		musicSource.volume = 0.75f;
	}

	public void PlayMusicTrack(MusicTrack musicTrack)
	{
		//IL_00b5: Invalid comparison between F4 and I4
		if (currentTrack != null && currentTrack != musicTrack)
		{
			currentTrack.UnloadFromMemory();
		}
		if (currentTrack == musicTrack)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000180359767h\"");
			if (desiredVolumeMultiplier != 0f)
			{
				return;
			}
		}
		currentTrack = musicTrack;
		musicTrack.LoadToMemory();
		if (!(musicTrack.intro != null))
		{
			musicSource.loop = true;
			isPlayingIntro = false;
			musicSource.clip = musicTrack.loop;
		}
		else
		{
			musicSource.clip = musicTrack.intro;
			musicSource.loop = false;
			isPlayingIntro = true;
			float length = musicTrack.intro.length;
			introLength = length;
		}
		musicSource.Play();
		desiredVolumeMultiplier = 1f;
	}

	private unsafe void OnMainMenu()
	{
		currentDangerPitch = 1f;
		zoneInfluences.Clear();
		zoneMultiplier = 1f;
		PlayMusicTrack(menuMusicTrack);
		desiredVolume = 0.75f;
		musicSource.volume = 0.75f;
		DataManager instance = DataManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		UnityEngine.Object obj = default(UnityEngine.Object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj != menuMusicTrack)
				{
					if ((object)obj == null)
					{
						break;
					}
					((MusicTrack)obj).UnloadFromMemory();
				}
				continue;
			}
			((List<MusicTrack>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private void Update()
	{
		//IL_01fa: Invalid comparison between I4 and F4
		//IL_010b: Expected F4, but got I4
		//IL_0182: Invalid comparison between I4 and F4
		//IL_01cd: Expected F4, but got I4
		if (isPlayingIntro)
		{
			float time = musicSource.time;
			float num = introLength - 0.02f;
			if (!(time < num) || !musicSource.isPlaying)
			{
				MusicTrack musicTrack = currentTrack;
				musicSource.clip = musicTrack.loop;
				musicSource.loop = true;
				musicSource.Play();
				isPlayingIntro = false;
			}
		}
		UpdateZoneInfluences();
		float deltaTime = Time.deltaTime;
		float num2 = deltaTime * 3f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = desiredVolumeMultiplier - volumeMultiplier;
		float num4 = num3 * num2;
		float num5 = (volumeMultiplier = num4 + volumeMultiplier) * desiredVolume;
		float volume = num5 * zoneMultiplier;
		musicSource.volume = volume;
		UpdateDesiredLowpass();
		float cutoffFrequency = lowpassFilter.cutoffFrequency;
		float deltaTime2 = Time.deltaTime;
		float num6 = deltaTime2 * 8f;
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		float num7 = desiredLowpass - cutoffFrequency;
		float num8 = num7 * num6;
		float cutoffFrequency2 = num8 + cutoffFrequency;
		lowpassFilter.cutoffFrequency = cutoffFrequency2;
		UpdatePitch();
	}

	private void UpdatePitch()
	{
		//IL_01b5: Invalid comparison between I4 and F4
		//IL_0200: Expected F4, but got I4
		//IL_00f7: Invalid comparison between I4 and F4
		float num;
		float num2;
		float num3;
		if (MyPlayer.Instance != null)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFVisualsSettings cfVisualsSettings = config.cfVisualsSettings;
			if (cfVisualsSettings.low_hp_effects != 0)
			{
				MyPlayer instance = MyPlayer.Instance;
				float dangerRatioMusic = instance.playerEffects.GetDangerRatioMusic();
				if (!(dangerRatioMusic > 0.01f))
				{
					if (!(currentDangerPitch < 0.99f))
					{
						num = 1f;
						goto IL_02af;
					}
					float deltaTime = Time.deltaTime;
					num2 = deltaTime + deltaTime;
					bool flag = 0f > num2;
					num3 = 1f;
					if (flag)
					{
						goto IL_01f7;
					}
					bool flag2 = !(num2 > 1f);
					num3 = 1f;
					if (!flag2)
					{
						num3 = 1f;
						num2 = 1f;
					}
				}
				else
				{
					float num4 = dangerRatioMusic * 0.25f;
					float num5 = 1f - num4;
					num3 = num5 * defaultPitch;
					float deltaTime2 = Time.deltaTime;
					num2 = deltaTime2 * 0.5f;
					if (0f > num2)
					{
						goto IL_01f7;
					}
					if (num2 > 1f)
					{
						num2 = 1f;
					}
				}
				goto IL_0279;
			}
		}
		float pitch = musicSource.pitch;
		bool flag3 = pitch == defaultPitch;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180359EE1h\"");
		if (!flag3)
		{
			musicSource.pitch = defaultPitch;
		}
		return;
		IL_02af:
		currentDangerPitch = num;
		musicSource.pitch = currentDangerPitch;
		return;
		IL_0279:
		float num6 = num3 - currentDangerPitch;
		float num7 = num6 * num2;
		num = num7 + currentDangerPitch;
		goto IL_02af;
		IL_01f7:
		num2 = 0f;
		goto IL_0279;
	}

	private void UpdateDesiredLowpass()
	{
		//IL_0045: Expected F4, but got I4
		//IL_01e2: Expected F4, but got I4
		//IL_0147: Expected F4, but got I4
		float time = Time.time;
		if (nextCheckTime > time)
		{
			return;
		}
		float time2 = Time.time;
		float num = time2 + checkCooldown;
		desiredLowpass = 22000f;
		nextCheckTime = num;
		if (MyTime.paused)
		{
			desiredLowpass = lowpassLow;
		}
		if (MapController._003CcurrentMap_003Ek__BackingField != null)
		{
			MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData.eMap == EMap.Graveyard && RsgController.Instance != null)
			{
				RsgController instance = RsgController.Instance;
				GraveyardBossRoom roomBoss = instance.roomBoss;
				if (roomBoss.isBossDefeated && !GameManager.Instance.IsFinalSwarm())
				{
					desiredLowpass = lowpassLow;
				}
			}
		}
		if (!MapController.isFinalBossStage)
		{
			return;
		}
		if (this.finalFightController != null)
		{
			if (this.finalFightController.isBossDefeated && !GameManager.Instance.IsFinalSwarm())
			{
				desiredLowpass = lowpassLow;
			}
		}
		else
		{
			FinalFightController finalFightController = UnityEngine.Object.FindAnyObjectByType<FinalFightController>();
			this.finalFightController = finalFightController;
		}
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
	}

	public void SetMusicVolume(float volume)
	{
		desiredVolume = volume;
		musicSource.volume = volume;
	}

	public void RegisterZoneInfluence(MusicPauseZone zone, float influence)
	{
		((Dictionary<object, float>)(object)zoneInfluences).set_Item((object)zone, influence);
	}

	private void UpdateZoneInfluences()
	{
		//IL_013f: Invalid comparison between I4 and F4
		//IL_0062: Expected F4, but got I4
		//IL_0094: Invalid comparison between F4 and O
		//IL_00cd: Invalid comparison between I4 and F4
		//IL_0118: Expected F4, but got I4
		float deltaTime = Time.deltaTime;
		float num;
		if (!(0f > deltaTime))
		{
			bool flag = !(deltaTime > 1f);
			num = deltaTime;
			if (!flag)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = 1f - zoneMultiplier;
		float num3 = num2 * num;
		float num4 = num3 + zoneMultiplier;
		zoneMultiplier = num4;
		Dictionary<MusicPauseZone, float>.ValueCollection values = zoneInfluences.Values;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
		Dictionary<MusicPauseZone, float>.ValueCollection.Enumerator enumerator = default(Dictionary<MusicPauseZone, float>.ValueCollection.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			float num5 = zoneMultiplier;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				continue;
			}
			float deltaTime2 = Time.deltaTime;
			float num6 = deltaTime2 * 7f;
			if (!(0f > num6))
			{
				if (num6 > 1f)
				{
					num6 = 1f;
				}
			}
			else
			{
				num6 = 0f;
			}
			float num7 = (float)obj - zoneMultiplier;
			float num8 = num7 * num6;
			float num9 = num8 + zoneMultiplier;
			zoneMultiplier = num9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	private void OnPlayerDied()
	{
		AudioSource component = GetComponent<AudioSource>();
		component.Stop();
	}

	private void OnChestOpening()
	{
		desiredVolumeMultiplier = 0.2f;
	}

	private void OnChestClosed()
	{
		desiredVolumeMultiplier = 1f;
	}

	private void OnPause(bool p)
	{
		UpdateDesiredLowpass();
	}

	public void RefreshFilter()
	{
		UpdateDesiredLowpass();
	}

	public MusicController()
	{
		Dictionary<MusicPauseZone, float> dictionary = new Dictionary<MusicPauseZone, float>();
		zoneInfluences = dictionary;
		zoneMultiplier = 1f;
		base._002Ector();
	}
}
