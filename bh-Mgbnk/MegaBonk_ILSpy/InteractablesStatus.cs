using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Chests;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Cpp2ILInjected;

public static class InteractablesStatus
{
	public class InteractableStatusContainer
	{
		public int numTotal;

		public int numUsed;

		public string debugName;

		public InteractableStatusContainer(string debugName)
		{
			this.debugName = debugName;
		}

		public bool DisplayInDebug()
		{
			return true;
		}

		public bool IsDone()
		{
			//IL_0011: Expected O, but got I4
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected I4, but got Unknown
			object obj = numUsed - numTotal;
			int num = numUsed ^ numTotal;
			int num2 = numUsed ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			return flag2 == flag;
		}
	}

	public static Dictionary<string, InteractableStatusContainer> interactablesByName;

	public static Action<string> A_InteractableUsed;

	public static Action<string> A_InteractableSpawned;

	public static void Init()
	{
		//IL_06e9: Expected I, but got O
		//IL_06f2: Expected O, but got I4
		//IL_0765: Expected O, but got I4
		//IL_077b: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_0227: Expected I, but got O
		//IL_0238: Expected O, but got I4
		//IL_07ec: Expected I, but got O
		//IL_027b: Expected I, but got O
		//IL_028c: Expected O, but got I4
		//IL_031e: Expected I, but got O
		//IL_032f: Expected O, but got I4
		//IL_0383: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		//IL_0452: Expected O, but got I4
		//IL_04cd: Expected O, but got I4
		//IL_0521: Expected O, but got I4
		//IL_08da: Expected O, but got I4
		//IL_08f0: Expected I, but got O
		//IL_091e: Expected O, but got I4
		//IL_0934: Expected I, but got O
		//IL_0962: Expected O, but got I4
		//IL_0978: Expected I, but got O
		//IL_09ab: Expected I, but got O
		//IL_09b4: Expected O, but got I4
		Delegate obj = MapGenerationController.A_PreGeneration;
		Action action = PreMapGeneration;
		Delegate obj2 = Delegate.Combine(MapGenerationController.A_PreGeneration, action);
		Action action2;
		nint num;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			MapGenerationController.A_PreGeneration = null;
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
				num = (nint)typeof(Action);
				obj4 = 0;
				obj5 = obj2;
				goto IL_0a05;
			}
			MapGenerationController.A_PreGeneration = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_09ca;
			}
		}
		Action<string> b = OnInteractableSpawn;
		Delegate obj7 = Delegate.Combine(BaseInteractable.A_DebugSpawn, b);
		nint num3;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			BaseInteractable.A_DebugSpawn = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action3 = default(Action<string>);
			bool flag4 = action3 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0789;
			}
			BaseInteractable.A_DebugSpawn = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0799;
			}
		}
		Action<string> b2 = OnInteractableDisable;
		Delegate obj10 = Delegate.Combine(BaseInteractable.A_DebugDisable, b2);
		if ((object)obj10 == null)
		{
			BaseInteractable.A_DebugDisable = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action4 = default(Action<string>);
			bool flag6 = action4 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag6)
			{
				goto IL_07a9;
			}
			BaseInteractable.A_DebugDisable = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag7)
			{
				goto IL_07b9;
			}
		}
		Action<BaseInteractable, bool> b3 = OnInteractableUse;
		Delegate obj12 = Delegate.Combine(DetectInteractables.A_Interacted, b3);
		if ((object)obj12 == null)
		{
			DetectInteractables.A_Interacted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BaseInteractable, bool> action5 = default(Action<BaseInteractable, bool>);
			bool flag8 = action5 == null;
			num3 = (nint)typeof(Action<BaseInteractable, bool>);
			obj8 = obj12;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_07c9;
			}
			DetectInteractables.A_Interacted = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj13 = default(object);
			bool flag9 = obj13 == null;
			obj = (Delegate)(object)typeof(Action<BaseInteractable, bool>);
			action2 = (Action)obj12;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_07d9;
			}
		}
		Action<bool> b4 = OnChargeShrineCharged;
		Delegate obj14 = Delegate.Combine(ChargeShrine.A_Charged, b4);
		if ((object)obj14 == null)
		{
			ChargeShrine.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action6 = default(Action<bool>);
			bool flag10 = action6 == null;
			obj = (Delegate)(object)typeof(Action<bool>);
			action2 = (Action)obj14;
			obj4 = 0;
			obj5 = null;
			if (flag10)
			{
				goto IL_0821;
			}
			ChargeShrine.A_Charged = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj15 = default(object);
			bool flag11 = obj15 == null;
			obj = (Delegate)(object)typeof(Action<bool>);
			action2 = (Action)obj14;
			obj4 = 0;
			obj5 = null;
			if (flag11)
			{
				goto IL_0831;
			}
		}
		Action<InteractableShadyGuy> b5 = OnShadyGuyUsed;
		Delegate obj16 = Delegate.Combine(InteractableShadyGuy.A_ShadyGuyDone, b5);
		if ((object)obj16 == null)
		{
			InteractableShadyGuy.A_ShadyGuyDone = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<InteractableShadyGuy> action7 = default(Action<InteractableShadyGuy>);
			bool flag12 = action7 == null;
			obj = (Delegate)(object)typeof(Action<InteractableShadyGuy>);
			action2 = (Action)obj16;
			obj4 = 0;
			obj5 = null;
			if (flag12)
			{
				goto IL_0869;
			}
			InteractableShadyGuy.A_ShadyGuyDone = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj17 = default(object);
			bool flag13 = obj17 == null;
			obj = (Delegate)(object)typeof(Action<InteractableShadyGuy>);
			action2 = (Action)obj16;
			obj4 = 0;
			obj5 = null;
			if (flag13)
			{
				goto IL_0879;
			}
		}
		obj = InteractableMicrowave.A_Exploded;
		Action action8 = OnMicrowaveExplode;
		Delegate obj18 = Delegate.Combine(InteractableMicrowave.A_Exploded, action8);
		if ((object)obj18 == null)
		{
			InteractableMicrowave.A_Exploded = null;
		}
		else
		{
			bool flag14 = (object)obj18.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag14)
			{
				obj19 = obj18;
			}
			bool flag15 = (object)obj19 == null;
			action2 = action8;
			obj4 = 0;
			obj5 = obj18;
			nint num4 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_09d5;
			}
			InteractableMicrowave.A_Exploded = (Action)obj19;
			bool flag16 = (object)obj18.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag16)
			{
				obj20 = obj18;
			}
			bool flag17 = (object)obj20 == null;
			action2 = action8;
			obj4 = 0;
			obj5 = obj18;
			nint num5 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_09e5;
			}
		}
		obj = GameManager.A_DungeonEnded;
		Action action9 = OnDungeonEnded;
		Delegate obj21 = Delegate.Combine(GameManager.A_DungeonEnded, action9);
		if ((object)obj21 == null)
		{
			GameManager.A_DungeonEnded = null;
			return;
		}
		bool flag18 = (object)obj21.GetType() != typeof(Action);
		Delegate obj22 = null;
		if (!flag18)
		{
			obj22 = obj21;
		}
		bool flag19 = (object)obj22 == null;
		action2 = action9;
		obj4 = 0;
		obj5 = obj21;
		nint num6 = (nint)typeof(Action);
		if (flag19)
		{
			goto IL_09f5;
		}
		GameManager.A_DungeonEnded = (Action)obj22;
		bool flag20 = (object)obj21.GetType() != typeof(Action);
		Delegate obj23 = null;
		if (!flag20)
		{
			obj23 = obj21;
		}
		bool flag21 = (object)obj23 == null;
		action2 = action9;
		num = (nint)typeof(Action);
		obj4 = 0;
		obj5 = obj21;
		if (!flag21)
		{
			return;
		}
		goto IL_0a05;
		IL_0821:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07d9;
		IL_07d9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num3 = (nint)obj;
		obj8 = action2;
		goto IL_07c9;
		IL_09e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09d5;
		IL_0799:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0789;
		IL_0831:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0821;
		IL_07b9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07a9;
		IL_07a9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0799;
		IL_0789:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09ca;
		IL_09d5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0879;
		IL_0a05:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09f5;
		IL_07c9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07b9;
		IL_09ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_09f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09e5;
		IL_0869:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0831;
		IL_0879:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0869;
	}

	public static void Cleanup()
	{
		//IL_06e9: Expected I, but got O
		//IL_06f2: Expected O, but got I4
		//IL_0765: Expected O, but got I4
		//IL_077b: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_0227: Expected I, but got O
		//IL_0238: Expected O, but got I4
		//IL_07ec: Expected I, but got O
		//IL_027b: Expected I, but got O
		//IL_028c: Expected O, but got I4
		//IL_031e: Expected I, but got O
		//IL_032f: Expected O, but got I4
		//IL_0383: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		//IL_0452: Expected O, but got I4
		//IL_04cd: Expected O, but got I4
		//IL_0521: Expected O, but got I4
		//IL_08da: Expected O, but got I4
		//IL_08f0: Expected I, but got O
		//IL_091e: Expected O, but got I4
		//IL_0934: Expected I, but got O
		//IL_0962: Expected O, but got I4
		//IL_0978: Expected I, but got O
		//IL_09ab: Expected I, but got O
		//IL_09b4: Expected O, but got I4
		Delegate obj = MapGenerationController.A_PreGeneration;
		Action action = PreMapGeneration;
		Delegate obj2 = Delegate.Remove(MapGenerationController.A_PreGeneration, action);
		Action action2;
		nint num;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			MapGenerationController.A_PreGeneration = null;
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
				num = (nint)typeof(Action);
				obj4 = 0;
				obj5 = obj2;
				goto IL_0a05;
			}
			MapGenerationController.A_PreGeneration = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_09ca;
			}
		}
		Action<string> value = OnInteractableSpawn;
		Delegate obj7 = Delegate.Remove(BaseInteractable.A_DebugSpawn, value);
		nint num3;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			BaseInteractable.A_DebugSpawn = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action3 = default(Action<string>);
			bool flag4 = action3 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0789;
			}
			BaseInteractable.A_DebugSpawn = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0799;
			}
		}
		Action<string> value2 = OnInteractableDisable;
		Delegate obj10 = Delegate.Remove(BaseInteractable.A_DebugDisable, value2);
		if ((object)obj10 == null)
		{
			BaseInteractable.A_DebugDisable = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action4 = default(Action<string>);
			bool flag6 = action4 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag6)
			{
				goto IL_07a9;
			}
			BaseInteractable.A_DebugDisable = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num3 = (nint)typeof(Action<string>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag7)
			{
				goto IL_07b9;
			}
		}
		Action<BaseInteractable, bool> value3 = OnInteractableUse;
		Delegate obj12 = Delegate.Remove(DetectInteractables.A_Interacted, value3);
		if ((object)obj12 == null)
		{
			DetectInteractables.A_Interacted = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BaseInteractable, bool> action5 = default(Action<BaseInteractable, bool>);
			bool flag8 = action5 == null;
			num3 = (nint)typeof(Action<BaseInteractable, bool>);
			obj8 = obj12;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_07c9;
			}
			DetectInteractables.A_Interacted = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj13 = default(object);
			bool flag9 = obj13 == null;
			obj = (Delegate)(object)typeof(Action<BaseInteractable, bool>);
			action2 = (Action)obj12;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_07d9;
			}
		}
		Action<bool> value4 = OnChargeShrineCharged;
		Delegate obj14 = Delegate.Remove(ChargeShrine.A_Charged, value4);
		if ((object)obj14 == null)
		{
			ChargeShrine.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action6 = default(Action<bool>);
			bool flag10 = action6 == null;
			obj = (Delegate)(object)typeof(Action<bool>);
			action2 = (Action)obj14;
			obj4 = 0;
			obj5 = null;
			if (flag10)
			{
				goto IL_0821;
			}
			ChargeShrine.A_Charged = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj15 = default(object);
			bool flag11 = obj15 == null;
			obj = (Delegate)(object)typeof(Action<bool>);
			action2 = (Action)obj14;
			obj4 = 0;
			obj5 = null;
			if (flag11)
			{
				goto IL_0831;
			}
		}
		Action<InteractableShadyGuy> value5 = OnShadyGuyUsed;
		Delegate obj16 = Delegate.Remove(InteractableShadyGuy.A_ShadyGuyDone, value5);
		if ((object)obj16 == null)
		{
			InteractableShadyGuy.A_ShadyGuyDone = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<InteractableShadyGuy> action7 = default(Action<InteractableShadyGuy>);
			bool flag12 = action7 == null;
			obj = (Delegate)(object)typeof(Action<InteractableShadyGuy>);
			action2 = (Action)obj16;
			obj4 = 0;
			obj5 = null;
			if (flag12)
			{
				goto IL_0869;
			}
			InteractableShadyGuy.A_ShadyGuyDone = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj17 = default(object);
			bool flag13 = obj17 == null;
			obj = (Delegate)(object)typeof(Action<InteractableShadyGuy>);
			action2 = (Action)obj16;
			obj4 = 0;
			obj5 = null;
			if (flag13)
			{
				goto IL_0879;
			}
		}
		obj = InteractableMicrowave.A_Exploded;
		Action action8 = OnMicrowaveExplode;
		Delegate obj18 = Delegate.Remove(InteractableMicrowave.A_Exploded, action8);
		if ((object)obj18 == null)
		{
			InteractableMicrowave.A_Exploded = null;
		}
		else
		{
			bool flag14 = (object)obj18.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag14)
			{
				obj19 = obj18;
			}
			bool flag15 = (object)obj19 == null;
			action2 = action8;
			obj4 = 0;
			obj5 = obj18;
			nint num4 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_09d5;
			}
			InteractableMicrowave.A_Exploded = (Action)obj19;
			bool flag16 = (object)obj18.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag16)
			{
				obj20 = obj18;
			}
			bool flag17 = (object)obj20 == null;
			action2 = action8;
			obj4 = 0;
			obj5 = obj18;
			nint num5 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_09e5;
			}
		}
		obj = GameManager.A_DungeonEnded;
		Action action9 = OnDungeonEnded;
		Delegate obj21 = Delegate.Remove(GameManager.A_DungeonEnded, action9);
		if ((object)obj21 == null)
		{
			GameManager.A_DungeonEnded = null;
			return;
		}
		bool flag18 = (object)obj21.GetType() != typeof(Action);
		Delegate obj22 = null;
		if (!flag18)
		{
			obj22 = obj21;
		}
		bool flag19 = (object)obj22 == null;
		action2 = action9;
		obj4 = 0;
		obj5 = obj21;
		nint num6 = (nint)typeof(Action);
		if (flag19)
		{
			goto IL_09f5;
		}
		GameManager.A_DungeonEnded = (Action)obj22;
		bool flag20 = (object)obj21.GetType() != typeof(Action);
		Delegate obj23 = null;
		if (!flag20)
		{
			obj23 = obj21;
		}
		bool flag21 = (object)obj23 == null;
		action2 = action9;
		num = (nint)typeof(Action);
		obj4 = 0;
		obj5 = obj21;
		if (!flag21)
		{
			return;
		}
		goto IL_0a05;
		IL_0821:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07d9;
		IL_07d9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num3 = (nint)obj;
		obj8 = action2;
		goto IL_07c9;
		IL_09e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09d5;
		IL_0799:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0789;
		IL_0831:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0821;
		IL_07b9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07a9;
		IL_07a9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0799;
		IL_0789:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09ca;
		IL_09d5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0879;
		IL_0a05:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09f5;
		IL_07c9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07b9;
		IL_09ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_09f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09e5;
		IL_0869:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0831;
		IL_0879:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0869;
	}

	private static void PreMapGeneration()
	{
		interactablesByName.Clear();
	}

	private static void OnInteractableSpawn(string debugName)
	{
		if (!interactablesByName.ContainsKey(debugName))
		{
			InteractableStatusContainer interactableStatusContainer = new InteractableStatusContainer(null);
			interactableStatusContainer.debugName = debugName;
			((Dictionary<object, object>)(object)interactablesByName).set_Item((object)debugName, (object)interactableStatusContainer);
		}
		InteractableStatusContainer interactableStatusContainer2 = interactablesByName.get_Item(debugName);
		int numTotal = interactableStatusContainer2.numTotal + 1;
		interactableStatusContainer2.numTotal = numTotal;
		Action<string> a_InteractableSpawned = A_InteractableSpawned;
		if (A_InteractableSpawned != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v242 @ rax_v14 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	private static void OnInteractableDisable(string debugName)
	{
		if (interactablesByName.ContainsKey(debugName))
		{
			InteractableStatusContainer interactableStatusContainer = interactablesByName.get_Item(debugName);
			int numTotal = interactableStatusContainer.numTotal - 1;
			interactableStatusContainer.numTotal = numTotal;
		}
	}

	private static void OnInteractableUse(BaseInteractable interactable, bool success)
	{
		if (!success)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(InteractableMicrowave));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B65E0");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		string debugName = interactable.GetDebugName();
		if (interactablesByName.ContainsKey(debugName))
		{
			InteractableStatusContainer interactableStatusContainer = interactablesByName.get_Item(debugName);
			int numUsed = interactableStatusContainer.numUsed + 1;
			interactableStatusContainer.numUsed = numUsed;
			Action<string> a_InteractableUsed = A_InteractableUsed;
			if (A_InteractableUsed != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ rax_v18 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private static void OnChargeShrineCharged(bool whatever)
	{
		if (interactablesByName.ContainsKey(ChargeShrine.debugName))
		{
			InteractableStatusContainer interactableStatusContainer = interactablesByName.get_Item(ChargeShrine.debugName);
			int numUsed = interactableStatusContainer.numUsed + 1;
			interactableStatusContainer.numUsed = numUsed;
			Action<string> a_InteractableUsed = A_InteractableUsed;
			if (A_InteractableUsed != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v149 @ rax_v17 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private static void OnShadyGuyUsed(InteractableShadyGuy shadyGuy)
	{
		if (interactablesByName.ContainsKey(InteractableShadyGuy.debugName))
		{
			InteractableStatusContainer interactableStatusContainer = interactablesByName.get_Item(InteractableShadyGuy.debugName);
			int numUsed = interactableStatusContainer.numUsed + 1;
			interactableStatusContainer.numUsed = numUsed;
			Action<string> a_InteractableUsed = A_InteractableUsed;
			if (A_InteractableUsed != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v149 @ rax_v17 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private static void OnMicrowaveExplode()
	{
		if (interactablesByName.ContainsKey(InteractableMicrowave.debugName))
		{
			InteractableStatusContainer interactableStatusContainer = interactablesByName.get_Item(InteractableMicrowave.debugName);
			int numUsed = interactableStatusContainer.numUsed + 1;
			interactableStatusContainer.numUsed = numUsed;
			Action<string> a_InteractableUsed = A_InteractableUsed;
			if (A_InteractableUsed != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v149 @ rax_v17 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private static void OnDungeonEnded()
	{
		bool flag = ((Dictionary<object, object>)(object)interactablesByName).Remove((object)InteractableChest.debugNameCrypt);
		bool flag2 = ((Dictionary<object, object>)(object)interactablesByName).Remove((object)InteractablePot.debugNameCrypt);
	}

	public unsafe static void PrintAll()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		object obj = default(object);
		string text3 = default(string);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj == null)
				{
					break;
				}
				int num = obj + 16;
				string text = ((int*)num)->ToString();
				string text2 = text3 + "- " + text;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				continue;
			}
			((Dictionary<string, InteractableStatusContainer>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	static InteractablesStatus()
	{
		Dictionary<string, InteractableStatusContainer> dictionary = new Dictionary<string, InteractableStatusContainer>();
		interactablesByName = dictionary;
	}
}
