using System;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using Steamworks;

namespace Assets.Scripts.Steam;

public static class SteamTimelineManager
{
	public static void Init()
	{
		//IL_05c8: Expected I, but got O
		//IL_05d1: Expected O, but got I4
		//IL_063b: Expected O, but got I4
		//IL_0651: Expected I, but got O
		//IL_069f: Expected O, but got I4
		//IL_06b5: Expected I, but got O
		//IL_06db: Expected O, but got I4
		//IL_06f1: Expected I, but got O
		//IL_0717: Expected O, but got I4
		//IL_072d: Expected I, but got O
		//IL_0753: Expected O, but got I4
		//IL_0769: Expected I, but got O
		//IL_078f: Expected O, but got I4
		//IL_07a5: Expected I, but got O
		//IL_07cb: Expected O, but got I4
		//IL_07e1: Expected I, but got O
		//IL_0807: Expected O, but got I4
		//IL_081d: Expected I, but got O
		//IL_0843: Expected O, but got I4
		//IL_0859: Expected I, but got O
		//IL_087f: Expected O, but got I4
		//IL_0895: Expected I, but got O
		//IL_08bb: Expected O, but got I4
		//IL_08d1: Expected I, but got O
		//IL_08f7: Expected O, but got I4
		//IL_090d: Expected I, but got O
		//IL_0938: Expected I, but got O
		//IL_0941: Expected O, but got I4
		Action b = OnStageStarted;
		Delegate obj = Delegate.Combine(GameManager.A_StageStarted, b);
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			object obj3;
			Delegate obj4;
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_0a12;
			}
			GameManager.A_StageStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0957;
			}
		}
		Action b2 = OnPlayerDied;
		Delegate obj6 = Delegate.Combine(PlayerHealth.A_Died, b2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_Died = null;
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
			object obj3 = 0;
			Delegate obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0962;
			}
			PlayerHealth.A_Died = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0972;
			}
		}
		Action b3 = OnBossSpawned;
		Delegate obj9 = Delegate.Combine(InteractableBossSpawner.A_BossSpawned, b3);
		if ((object)obj9 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
		}
		else
		{
			bool flag8 = (object)obj9.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag8)
			{
				obj10 = obj9;
			}
			bool flag9 = (object)obj10 == null;
			object obj3 = 0;
			Delegate obj4 = obj9;
			nint num5 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0982;
			}
			InteractableBossSpawner.A_BossSpawned = (Action)obj10;
			bool flag10 = (object)obj9.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag10)
			{
				obj11 = obj9;
			}
			bool flag11 = (object)obj11 == null;
			obj3 = 0;
			obj4 = obj9;
			nint num6 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_0992;
			}
		}
		Action b4 = OnMiniBoss;
		Delegate obj12 = Delegate.Combine(SummonerController.A_MiniBoss, b4);
		if ((object)obj12 == null)
		{
			SummonerController.A_MiniBoss = null;
		}
		else
		{
			bool flag12 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag12)
			{
				obj13 = obj12;
			}
			bool flag13 = (object)obj13 == null;
			object obj3 = 0;
			Delegate obj4 = obj12;
			nint num7 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_09a2;
			}
			SummonerController.A_MiniBoss = (Action)obj13;
			bool flag14 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag14)
			{
				obj14 = obj12;
			}
			bool flag15 = (object)obj14 == null;
			obj3 = 0;
			obj4 = obj12;
			nint num8 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_09b2;
			}
		}
		Action b5 = OnSwarmStarted;
		Delegate obj15 = Delegate.Combine(SummonerController.A_SwarmStarted, b5);
		if ((object)obj15 == null)
		{
			SummonerController.A_SwarmStarted = null;
		}
		else
		{
			bool flag16 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag16)
			{
				obj16 = obj15;
			}
			bool flag17 = (object)obj16 == null;
			object obj3 = 0;
			Delegate obj4 = obj15;
			nint num9 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_09c2;
			}
			SummonerController.A_SwarmStarted = (Action)obj16;
			bool flag18 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag18)
			{
				obj17 = obj15;
			}
			bool flag19 = (object)obj17 == null;
			obj3 = 0;
			obj4 = obj15;
			nint num10 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_09d2;
			}
		}
		Action b6 = OnFinalSwarmStarted;
		Delegate obj18 = Delegate.Combine(SummonerController.A_FinalSwarmStarted, b6);
		if ((object)obj18 == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
		}
		else
		{
			bool flag20 = (object)obj18.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag20)
			{
				obj19 = obj18;
			}
			bool flag21 = (object)obj19 == null;
			object obj3 = 0;
			Delegate obj4 = obj18;
			nint num11 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_09e2;
			}
			SummonerController.A_FinalSwarmStarted = (Action)obj19;
			bool flag22 = (object)obj18.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag22)
			{
				obj20 = obj18;
			}
			bool flag23 = (object)obj20 == null;
			obj3 = 0;
			obj4 = obj18;
			nint num12 = (nint)typeof(Action);
			if (flag23)
			{
				goto IL_09f2;
			}
		}
		Action b7 = OnMainMenu;
		Delegate obj21 = Delegate.Combine(MainMenu.A_MenuOpened, b7);
		if ((object)obj21 == null)
		{
			MainMenu.A_MenuOpened = null;
		}
		else
		{
			bool flag24 = (object)obj21.GetType() != typeof(Action);
			Delegate obj22 = null;
			if (!flag24)
			{
				obj22 = obj21;
			}
			bool flag25 = (object)obj22 == null;
			object obj3 = 0;
			Delegate obj4 = obj21;
			nint num13 = (nint)typeof(Action);
			if (flag25)
			{
				goto IL_0a02;
			}
			MainMenu.A_MenuOpened = (Action)obj22;
			bool flag26 = (object)obj21.GetType() != typeof(Action);
			Delegate obj23 = null;
			if (!flag26)
			{
				obj23 = obj21;
			}
			bool flag27 = (object)obj23 == null;
			nint num = (nint)typeof(Action);
			obj3 = 0;
			obj4 = obj21;
			if (flag27)
			{
				goto IL_0a12;
			}
		}
		SteamTimeline.SetTimelineGameMode(ETimelineGameMode.k_ETimelineGameMode_Menus);
		return;
		IL_0a12:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a02;
		IL_0957:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0972:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0962;
		IL_0992:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0982;
		IL_0962:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0957;
		IL_09a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0992;
		IL_0982:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0972;
		IL_09f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09e2;
		IL_09b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09a2;
		IL_09d2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09c2;
		IL_09e2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09d2;
		IL_09c2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09b2;
		IL_0a02:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09f2;
	}

	public static void OnDestroy()
	{
		//IL_05b9: Expected I, but got O
		//IL_05c2: Expected O, but got I4
		//IL_062c: Expected O, but got I4
		//IL_0642: Expected I, but got O
		//IL_0690: Expected O, but got I4
		//IL_06a6: Expected I, but got O
		//IL_06cc: Expected O, but got I4
		//IL_06e2: Expected I, but got O
		//IL_0708: Expected O, but got I4
		//IL_071e: Expected I, but got O
		//IL_0744: Expected O, but got I4
		//IL_075a: Expected I, but got O
		//IL_0780: Expected O, but got I4
		//IL_0796: Expected I, but got O
		//IL_07bc: Expected O, but got I4
		//IL_07d2: Expected I, but got O
		//IL_07f8: Expected O, but got I4
		//IL_080e: Expected I, but got O
		//IL_0834: Expected O, but got I4
		//IL_084a: Expected I, but got O
		//IL_0870: Expected O, but got I4
		//IL_0886: Expected I, but got O
		//IL_08ac: Expected O, but got I4
		//IL_08c2: Expected I, but got O
		//IL_08e8: Expected O, but got I4
		//IL_08fe: Expected I, but got O
		//IL_0929: Expected I, but got O
		//IL_0932: Expected O, but got I4
		Action value = OnStageStarted;
		Delegate obj = Delegate.Remove(GameManager.A_StageStarted, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
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
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_0a03;
			}
			GameManager.A_StageStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0948;
			}
		}
		Action value2 = OnPlayerDied;
		Delegate obj6 = Delegate.Remove(PlayerHealth.A_Died, value2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_Died = null;
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
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0953;
			}
			PlayerHealth.A_Died = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0963;
			}
		}
		Action value3 = OnBossSpawned;
		Delegate obj9 = Delegate.Remove(InteractableBossSpawner.A_BossSpawned, value3);
		if ((object)obj9 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
		}
		else
		{
			bool flag8 = (object)obj9.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag8)
			{
				obj10 = obj9;
			}
			bool flag9 = (object)obj10 == null;
			obj3 = 0;
			obj4 = obj9;
			nint num5 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0973;
			}
			InteractableBossSpawner.A_BossSpawned = (Action)obj10;
			bool flag10 = (object)obj9.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag10)
			{
				obj11 = obj9;
			}
			bool flag11 = (object)obj11 == null;
			obj3 = 0;
			obj4 = obj9;
			nint num6 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_0983;
			}
		}
		Action value4 = OnMiniBoss;
		Delegate obj12 = Delegate.Remove(SummonerController.A_MiniBoss, value4);
		if ((object)obj12 == null)
		{
			SummonerController.A_MiniBoss = null;
		}
		else
		{
			bool flag12 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag12)
			{
				obj13 = obj12;
			}
			bool flag13 = (object)obj13 == null;
			obj3 = 0;
			obj4 = obj12;
			nint num7 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_0993;
			}
			SummonerController.A_MiniBoss = (Action)obj13;
			bool flag14 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag14)
			{
				obj14 = obj12;
			}
			bool flag15 = (object)obj14 == null;
			obj3 = 0;
			obj4 = obj12;
			nint num8 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_09a3;
			}
		}
		Action value5 = OnSwarmStarted;
		Delegate obj15 = Delegate.Remove(SummonerController.A_SwarmStarted, value5);
		if ((object)obj15 == null)
		{
			SummonerController.A_SwarmStarted = null;
		}
		else
		{
			bool flag16 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag16)
			{
				obj16 = obj15;
			}
			bool flag17 = (object)obj16 == null;
			obj3 = 0;
			obj4 = obj15;
			nint num9 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_09b3;
			}
			SummonerController.A_SwarmStarted = (Action)obj16;
			bool flag18 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag18)
			{
				obj17 = obj15;
			}
			bool flag19 = (object)obj17 == null;
			obj3 = 0;
			obj4 = obj15;
			nint num10 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_09c3;
			}
		}
		Action value6 = OnFinalSwarmStarted;
		Delegate obj18 = Delegate.Remove(SummonerController.A_FinalSwarmStarted, value6);
		if ((object)obj18 == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
		}
		else
		{
			bool flag20 = (object)obj18.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag20)
			{
				obj19 = obj18;
			}
			bool flag21 = (object)obj19 == null;
			obj3 = 0;
			obj4 = obj18;
			nint num11 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_09d3;
			}
			SummonerController.A_FinalSwarmStarted = (Action)obj19;
			bool flag22 = (object)obj18.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag22)
			{
				obj20 = obj18;
			}
			bool flag23 = (object)obj20 == null;
			obj3 = 0;
			obj4 = obj18;
			nint num12 = (nint)typeof(Action);
			if (flag23)
			{
				goto IL_09e3;
			}
		}
		Action value7 = OnMainMenu;
		Delegate obj21 = Delegate.Remove(MainMenu.A_MenuOpened, value7);
		if ((object)obj21 == null)
		{
			MainMenu.A_MenuOpened = null;
			return;
		}
		bool flag24 = (object)obj21.GetType() != typeof(Action);
		Delegate obj22 = null;
		if (!flag24)
		{
			obj22 = obj21;
		}
		bool flag25 = (object)obj22 == null;
		obj3 = 0;
		obj4 = obj21;
		nint num13 = (nint)typeof(Action);
		if (flag25)
		{
			goto IL_09f3;
		}
		MainMenu.A_MenuOpened = (Action)obj22;
		bool flag26 = (object)obj21.GetType() != typeof(Action);
		Delegate obj23 = null;
		if (!flag26)
		{
			obj23 = obj21;
		}
		bool flag27 = (object)obj23 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj21;
		if (!flag27)
		{
			return;
		}
		goto IL_0a03;
		IL_0a03:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09f3;
		IL_0953:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0948;
		IL_0973:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0963;
		IL_0948:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0963:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0953;
		IL_0993:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0983;
		IL_0983:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0973;
		IL_09e3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09d3;
		IL_09a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0993;
		IL_09c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09b3;
		IL_09d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09c3;
		IL_09b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09a3;
		IL_09f3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09e3;
	}

	private static void OnStageStarted()
	{
		float flStartOffsetSeconds = default(float);
		float flDurationSeconds = default(float);
		ETimelineEventClipPriority ePossibleClip = default(ETimelineEventClipPriority);
		if (!MapController.IsFirstStage())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string pchTitle = $"Next Stage ({arg})";
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string pchDescription = $"Teleported to next stage (Stage {arg2})";
			SteamTimeline.AddTimelineEvent("steam_flag", pchTitle, pchDescription, 0u, flStartOffsetSeconds, flDurationSeconds, ePossibleClip);
		}
		else
		{
			SteamTimeline.SetTimelineGameMode(ETimelineGameMode.k_ETimelineGameMode_Playing);
			string name = MapController._003CcurrentMap_003Ek__BackingField.GetName();
			string pchDescription2 = "A new run has been started (" + name + ")";
			SteamTimeline.AddTimelineEvent("steam_bolt", "Run Started", pchDescription2, 0u, flStartOffsetSeconds, flDurationSeconds, ePossibleClip);
		}
	}

	private static void OnPlayerDied()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725B3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float flStartOffsetSeconds = default(float);
		float flDurationSeconds = default(float);
		ETimelineEventClipPriority ePossibleClip = default(ETimelineEventClipPriority);
		SteamTimeline.AddTimelineEvent("steam_death", "Run Ended", "The run is over", 0u, flStartOffsetSeconds, flDurationSeconds, ePossibleClip);
	}

	public static void OnMainMenu()
	{
		SteamTimeline.SetTimelineGameMode(ETimelineGameMode.k_ETimelineGameMode_Menus);
	}

	private static void OnBossSpawned()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725B4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float flStartOffsetSeconds = default(float);
		float flDurationSeconds = default(float);
		ETimelineEventClipPriority ePossibleClip = default(ETimelineEventClipPriority);
		SteamTimeline.AddTimelineEvent("steam_attack", "Boss", "A boss has appeared", 0u, flStartOffsetSeconds, flDurationSeconds, ePossibleClip);
	}

	private static void OnMiniBoss()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725B5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float flStartOffsetSeconds = default(float);
		float flDurationSeconds = default(float);
		ETimelineEventClipPriority ePossibleClip = default(ETimelineEventClipPriority);
		SteamTimeline.AddTimelineEvent("steam_attack", "Mini Boss", "A miniboss has appeared", 0u, flStartOffsetSeconds, flDurationSeconds, ePossibleClip);
	}

	private static void OnSwarmStarted()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725B6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float flStartOffsetSeconds = default(float);
		float flDurationSeconds = default(float);
		ETimelineEventClipPriority ePossibleClip = default(ETimelineEventClipPriority);
		SteamTimeline.AddTimelineEvent("steam_caution", "Swarm", "A swarm has started", 0u, flStartOffsetSeconds, flDurationSeconds, ePossibleClip);
	}

	private static void OnFinalSwarmStarted()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725B7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float flStartOffsetSeconds = default(float);
		float flDurationSeconds = default(float);
		ETimelineEventClipPriority ePossibleClip = default(ETimelineEventClipPriority);
		SteamTimeline.AddTimelineEvent("steam_caution", "Final Swarm", "The final swarm has started", 0u, flStartOffsetSeconds, flDurationSeconds, ePossibleClip);
	}
}
