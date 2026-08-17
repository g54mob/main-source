using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.HUD.Chatbox;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableCryptLeave : BaseInteractable
{
	public LocalizedString stringLeave;

	private bool hasInteracted;

	public static Action<float> A_FirstDungeonCompleted;

	private RsgController.EDungeonType dungeonType;

	private Vector3 teleportPosition;

	private Vector3 teleportDir;

	private Vector3 teleportDirCamera;

	public override bool Interact()
	{
		//IL_009b: Expected I4, but got O
		hasInteracted = true;
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			instance.isTeleporting = true;
			if ((object)AudioManager.Instance != null)
			{
				AudioManager.Instance.PlayDungeonDoorEnter();
				Action action = Teleport;
				if ((object)TransitionUI.Instance != null)
				{
					TransitionUI.Instance.StartTransition(action, 0.25f, 0f);
					return true;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void SetType(RsgController.EDungeonType dungeonType)
	{
		this.dungeonType = dungeonType;
	}

	private unsafe void Teleport()
	{
		//IL_0041: Expected O, but got Ref
		//IL_0041: Expected O, but got Ref
		//IL_0041: Expected O, but got Ref
		GameManager.Instance.StopDungeon();
		MyPlayer instance = MyPlayer.Instance;
		instance.isTeleporting = false;
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		float cameraPitch = default(float);
		MyPlayer.Instance.TeleportPlayerImmediate((Vector3)(&obj), (Vector3)(&obj2), (Vector3)(&obj3), cameraPitch);
		if (dungeonType != RsgController.EDungeonType.BossDungeon)
		{
			if (!ChallengesTracker.HasChallengeModifier("crypt"))
			{
				UiManager instance2 = UiManager.Instance;
				instance2.mapTile.StartAnimation();
			}
			ShowTime();
			UiManager instance3 = UiManager.Instance;
			instance3.objective.GraveyardKeys();
			Action<float> a_FirstDungeonCompleted = A_FirstDungeonCompleted;
			if (A_FirstDungeonCompleted != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v373 @ rbx_v5 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			RsgController instance4 = RsgController.Instance;
			instance4.roomBoss.Activate();
			MusicController.Instance.StopMusic();
		}
		RsgController.Instance.ClearMap();
	}

	private void Update()
	{
	}

	private unsafe void ShowTime()
	{
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected F4, but got I4
		//IL_01af: Expected O, but got I4
		//IL_02af: Invalid comparison between F4 and O
		//IL_02cd: Invalid comparison between F4 and I4
		//IL_02f6: Expected O, but got I4
		//IL_01bc: Invalid comparison between F4 and O
		//IL_01da: Invalid comparison between F4 and I4
		//IL_020c: Expected O, but got I4
		//IL_0252: Expected O, but got Ref
		//IL_0328: Invalid comparison between O and F4
		//IL_00f3: Invalid comparison between F4 and I4
		//IL_0105: Expected O, but got I4
		//IL_0116: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		//IL_018f: Expected O, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		object obj;
		float num2;
		object obj2;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			StatsSaveFile stats = saveManager.stats;
			if (saveManager.stats != null && stats.times != null)
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				StatsSaveFile stats2 = saveManager2.stats;
				float num = ((Dictionary<System.Int32Enum, float>)(object)stats2.times).get_Item((System.Int32Enum)0);
				if (!(num > MyTime.cryptTimer))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001804C873Fh\"");
					bool flag = num != 0f;
					obj = 0;
					num2 = num;
					obj2 = 0;
					if (flag)
					{
						goto IL_049c;
					}
				}
				SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
				StatsSaveFile stats3 = saveManager3.stats;
				((Dictionary<System.Int32Enum, float>)(object)stats3.times).set_Item((System.Int32Enum)0, MyTime.cryptTimer);
				SaveManager._003CInstance_003Ek__BackingField.SaveStats();
				obj = 0;
				num2 = num;
				obj2 = 1;
				goto IL_049c;
			}
		}
		obj = 0;
		num2 = 0f;
		obj2 = 0;
		goto IL_049c;
		IL_049c:
		string text;
		object obj3;
		string text7;
		if (obj2 != null)
		{
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			float num3 = num2 - (float)obj;
			bool flag3 = num3 == 0f;
			text = MyColorUtility.positiveColorString;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			obj3 = flag5 & flag4;
			string text2 = TimerUtility.TimerToString(MyTime.cryptTimer);
			string text3 = "Escape time: " + text2 + "!";
			Color itemRarityColor = MyColorUtility.GetItemRarityColor(EItemRarity.Legendary);
			object obj4 = default(object);
			string text4 = MyColorUtility.ColorToHex((Color)(&obj4));
			string text5 = "<color=#" + text4 + ">";
			string text6 = TimerUtility.TimerToString(MyTime.cryptTimer);
			text7 = "[PB] Escape time: " + text5 + text6 + "</color>!";
		}
		else
		{
			bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			float num4 = num2 - (float)obj;
			bool flag7 = num4 == 0f;
			bool flag8 = !flag6;
			bool flag9 = !flag7;
			obj3 = flag9 & flag8;
			text = MyColorUtility.negativeColorString;
			string text8 = TimerUtility.TimerToString(MyTime.cryptTimer);
			text7 = "Escape time: " + text8 + "!";
		}
		bool flag10 = obj3 == null;
		string text9 = text7;
		if (!flag10)
		{
			float num5 = default(float);
			string text10;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5))
			{
				text10 = num5.ToString("F2");
			}
			else
			{
				string text11 = num5.ToString("F2");
				text10 = "+" + text11;
			}
			string text12 = text7 + " (<color=" + text + ">" + text10 + "</color>)";
			text9 = text12;
		}
		UiManager instance = UiManager.Instance;
		instance.feed.SetFeed(text9, 8.5f);
	}

	public override string GetInteractString()
	{
		if (stringLeave != null)
		{
			return stringLeave.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public override bool CanInteract()
	{
		return !hasInteracted;
	}

	public void SetTeleportTransform(Vector3 pos, Vector3 dir, Vector3 cameraDir)
	{
		//IL_000f: Expected O, but got F4
		//IL_001e: Expected O, but got F4
		//IL_0041: Expected O, but got F4
		teleportPosition = (Vector3)pos.x;
		teleportDir = (Vector3)dir.x;
		_ = pos.z;
		_ = dir.z;
		teleportDirCamera = (Vector3)cameraDir.x;
		_ = cameraDir.z;
	}

	public InteractableCryptLeave()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
