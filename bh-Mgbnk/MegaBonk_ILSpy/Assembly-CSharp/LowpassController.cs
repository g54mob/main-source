using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Audio;

public class LowpassController : MonoBehaviour
{
	public AudioLowPassFilter filter;

	private float defaultCutoff = 22000f;

	private float desiredCutoff = 22000f;

	private float lowCutoff = 1400f;

	private bool isTimeFreeze;

	private bool isUnderwater;

	public AudioMixer audioMixer;

	private float lowpassFrequency = 22000f;

	private void Awake()
	{
		//IL_061f: Expected I, but got O
		//IL_0630: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_0221: Expected I, but got O
		//IL_0232: Expected O, but got I4
		//IL_0275: Expected I, but got O
		//IL_0286: Expected O, but got I4
		//IL_0318: Expected I, but got O
		//IL_0329: Expected O, but got I4
		//IL_036c: Expected I, but got O
		//IL_037d: Expected O, but got I4
		//IL_06de: Expected I, but got O
		//IL_0726: Expected O, but got I4
		//IL_073c: Expected I, but got O
		//IL_044a: Expected I, but got O
		//IL_076a: Expected O, but got I4
		//IL_0780: Expected I, but got O
		//IL_07ae: Expected O, but got I4
		//IL_07c4: Expected I, but got O
		//IL_052c: Expected I, but got O
		//IL_07f2: Expected O, but got I4
		//IL_0808: Expected I, but got O
		//IL_0836: Expected O, but got I4
		//IL_084c: Expected I, but got O
		//IL_087a: Expected O, but got I4
		//IL_0890: Expected I, but got O
		Action<EStatusEffect, bool> b = OnStatusEffectAdded;
		Delegate obj = Delegate.Combine(PlayerStatusEffects.A_StatusEffectAdded, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect, bool> action = default(Action<EStatusEffect, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStatusEffect, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_08ee;
			}
			PlayerStatusEffects.A_StatusEffectAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0662;
			}
		}
		Action<EStatusEffect> b2 = OnStatusEffectRemoved;
		Delegate obj6 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectRemoved, b2);
		if ((object)obj6 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect> action2 = default(Action<EStatusEffect>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_066d;
			}
			PlayerStatusEffects.A_StatusEffectRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_067d;
			}
		}
		Action<Water> b3 = OnWaterFilterEnter;
		Delegate obj8 = Delegate.Combine(Water.A_CameraEnterWater, b3);
		if ((object)obj8 == null)
		{
			Water.A_CameraEnterWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action3 = default(Action<Water>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_068d;
			}
			Water.A_CameraEnterWater = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_069d;
			}
		}
		Action<Water> b4 = OnWaterFilterExit;
		Delegate obj10 = Delegate.Combine(Water.A_CameraExitWater, b4);
		if ((object)obj10 == null)
		{
			Water.A_CameraExitWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action4 = default(Action<Water>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<Water>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_06ad;
			}
			Water.A_CameraExitWater = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<Water>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_06c5;
			}
		}
		num = (nint)MyTime.A_TimeScaleChange;
		Action action5 = RefreshTimeFreeze;
		Delegate obj12 = Delegate.Combine(MyTime.A_TimeScaleChange, action5);
		if ((object)obj12 == null)
		{
			MyTime.A_TimeScaleChange = null;
		}
		else
		{
			bool flag8 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag8)
			{
				obj13 = obj12;
			}
			bool flag9 = (object)obj13 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_089e;
			}
			MyTime.A_TimeScaleChange = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_08ae;
			}
		}
		num = (nint)Lava.A_CameraEnterWater;
		Action action6 = OnLavaEnter;
		Delegate obj15 = Delegate.Combine(Lava.A_CameraEnterWater, action6);
		if ((object)obj15 == null)
		{
			Lava.A_CameraEnterWater = null;
		}
		else
		{
			bool flag12 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag12)
			{
				obj16 = obj15;
			}
			bool flag13 = (object)obj16 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num5 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_08be;
			}
			Lava.A_CameraEnterWater = (Action)obj16;
			bool flag14 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj15;
			}
			bool flag15 = (object)obj17 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num6 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_08ce;
			}
		}
		num = (nint)Lava.A_CameraExitWater;
		Action action7 = OnLavaExit;
		Delegate obj18 = Delegate.Combine(Lava.A_CameraExitWater, action7);
		if ((object)obj18 == null)
		{
			Lava.A_CameraExitWater = null;
			return;
		}
		bool flag16 = (object)obj18.GetType() != typeof(Action);
		Delegate obj19 = null;
		if (!flag16)
		{
			obj19 = obj18;
		}
		bool flag17 = (object)obj19 == null;
		obj2 = action7;
		obj3 = 0;
		obj4 = obj18;
		nint num7 = (nint)typeof(Action);
		if (flag17)
		{
			goto IL_08de;
		}
		Lava.A_CameraExitWater = (Action)obj19;
		bool flag18 = (object)obj18.GetType() != typeof(Action);
		Delegate obj20 = null;
		if (!flag18)
		{
			obj20 = obj18;
		}
		bool flag19 = (object)obj20 == null;
		obj2 = action7;
		obj3 = 0;
		obj4 = obj18;
		nint num8 = (nint)typeof(Action);
		if (!flag19)
		{
			return;
		}
		goto IL_08ee;
		IL_08ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08be;
		IL_0662:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_08be:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08ae;
		IL_06c5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06ad;
		IL_08ae:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_089e;
		IL_068d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_067d;
		IL_06ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_069d;
		IL_069d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_068d;
		IL_067d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_066d;
		IL_089e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06c5;
		IL_08de:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08ce;
		IL_08ee:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08de;
		IL_066d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0662;
	}

	private void OnDestroy()
	{
		//IL_0724: Expected I, but got O
		//IL_0735: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_0221: Expected I, but got O
		//IL_0232: Expected O, but got I4
		//IL_0275: Expected I, but got O
		//IL_0286: Expected O, but got I4
		//IL_0318: Expected I, but got O
		//IL_0329: Expected O, but got I4
		//IL_036c: Expected I, but got O
		//IL_037d: Expected O, but got I4
		//IL_07e3: Expected I, but got O
		//IL_082b: Expected O, but got I4
		//IL_0841: Expected I, but got O
		//IL_044a: Expected I, but got O
		//IL_086f: Expected O, but got I4
		//IL_0885: Expected I, but got O
		//IL_08b3: Expected O, but got I4
		//IL_08c9: Expected I, but got O
		//IL_052c: Expected I, but got O
		//IL_08f7: Expected O, but got I4
		//IL_090d: Expected I, but got O
		//IL_093b: Expected O, but got I4
		//IL_0951: Expected I, but got O
		//IL_0627: Expected O, but got I4
		//IL_097f: Expected O, but got I4
		//IL_0681: Expected O, but got I4
		//IL_06db: Expected O, but got I4
		Action<EStatusEffect, bool> value = OnStatusEffectAdded;
		Delegate obj = Delegate.Remove(PlayerStatusEffects.A_StatusEffectAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect, bool> action = default(Action<EStatusEffect, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStatusEffect, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_09a3;
			}
			PlayerStatusEffects.A_StatusEffectAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0767;
			}
		}
		Action<EStatusEffect> value2 = OnStatusEffectRemoved;
		Delegate obj6 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectRemoved, value2);
		if ((object)obj6 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect> action2 = default(Action<EStatusEffect>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_0772;
			}
			PlayerStatusEffects.A_StatusEffectRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_0782;
			}
		}
		Action<Water> value3 = OnWaterFilterEnter;
		Delegate obj8 = Delegate.Remove(Water.A_CameraEnterWater, value3);
		if ((object)obj8 == null)
		{
			Water.A_CameraEnterWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action3 = default(Action<Water>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_0792;
			}
			Water.A_CameraEnterWater = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_07a2;
			}
		}
		Action<Water> value4 = OnWaterFilterExit;
		Delegate obj10 = Delegate.Remove(Water.A_CameraExitWater, value4);
		if ((object)obj10 == null)
		{
			Water.A_CameraExitWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action4 = default(Action<Water>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_07b2;
			}
			Water.A_CameraExitWater = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<Water>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_07c2;
			}
		}
		num = (nint)MyTime.A_TimeScaleChange;
		Action action5 = RefreshTimeFreeze;
		Delegate obj12 = Delegate.Remove(MyTime.A_TimeScaleChange, action5);
		if ((object)obj12 == null)
		{
			MyTime.A_TimeScaleChange = null;
		}
		else
		{
			bool flag8 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag8)
			{
				obj13 = obj12;
			}
			bool flag9 = (object)obj13 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_09b2;
			}
			MyTime.A_TimeScaleChange = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_09c2;
			}
		}
		num = (nint)Lava.A_CameraEnterWater;
		Action action6 = OnLavaEnter;
		Delegate obj15 = Delegate.Remove(Lava.A_CameraEnterWater, action6);
		if ((object)obj15 == null)
		{
			Lava.A_CameraEnterWater = null;
		}
		else
		{
			bool flag12 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag12)
			{
				obj16 = obj15;
			}
			bool flag13 = (object)obj16 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num5 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_09d2;
			}
			Lava.A_CameraEnterWater = (Action)obj16;
			bool flag14 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj15;
			}
			bool flag15 = (object)obj17 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num6 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_09e2;
			}
		}
		num = (nint)Lava.A_CameraExitWater;
		Action action7 = OnLavaExit;
		Delegate obj18 = Delegate.Remove(Lava.A_CameraExitWater, action7);
		NullReferenceException typeFromHandle;
		if ((object)obj18 == null)
		{
			Lava.A_CameraExitWater = null;
		}
		else
		{
			bool flag16 = (object)obj18.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag16)
			{
				obj19 = obj18;
			}
			bool flag17 = (object)obj19 == null;
			obj2 = action7;
			obj3 = 0;
			obj4 = obj18;
			nint num7 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_09f2;
			}
			Lava.A_CameraExitWater = (Action)obj19;
			bool flag18 = (object)obj18.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag18)
			{
				obj20 = obj18;
			}
			bool flag19 = (object)obj20 == null;
			obj2 = action7;
			obj3 = 0;
			obj4 = obj18;
			typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (flag19)
			{
				goto IL_0a02;
			}
		}
		bool flag20 = (object)audioMixer == null;
		obj2 = action7;
		obj3 = 0;
		obj4 = obj18;
		if (!flag20)
		{
			bool flag21 = audioMixer.SetFloat("AmbienceLowpass", 22000f);
			bool flag22 = (object)audioMixer == null;
			float num8 = 22000f;
			obj2 = action7;
			obj3 = 0;
			obj4 = obj18;
			if (!flag22)
			{
				bool flag23 = audioMixer.SetFloat("GameSfxLowpass", 22000f);
				bool flag24 = (object)audioMixer == null;
				num8 = 22000f;
				obj2 = action7;
				obj3 = 0;
				obj4 = obj18;
				if (!flag24)
				{
					bool flag25 = audioMixer.SetFloat("MusicLowpass", 22000f);
					return;
				}
			}
		}
		goto IL_09a3;
		IL_0767:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_07c2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_07b2;
		IL_09b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07c2;
		IL_0a02:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09f2;
		IL_09f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09e2;
		IL_0792:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0782;
		IL_0782:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0772;
		IL_07a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0792;
		IL_07b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07a2;
		IL_0772:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0767;
		IL_09a3:
		typeFromHandle = new NullReferenceException();
		goto IL_0a02;
		IL_09d2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09c2;
		IL_09c2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09b2;
		IL_09e2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09d2;
	}

	private void OnWaterFilterEnter(Water filter)
	{
		isUnderwater = true;
	}

	private void OnWaterFilterExit(Water filter)
	{
		isUnderwater = false;
	}

	private void OnLavaEnter()
	{
		isUnderwater = true;
	}

	private void OnLavaExit()
	{
		isUnderwater = false;
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool newEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x180357A10\"");
		}
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x180357A10\"");
		}
	}

	private void RefreshTimeFreeze()
	{
		//IL_0070: Invalid comparison between F4 and I4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (!inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
		{
			bool flag = 1f < MyTime._003CtimeScale_003Ek__BackingField;
			float num = 1f - MyTime._003CtimeScale_003Ek__BackingField;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			isTimeFreeze = flag5;
		}
		else
		{
			isTimeFreeze = true;
		}
	}

	private float GetDesiredCutoff()
	{
		//IL_00af: Invalid comparison between I4 and F4
		//IL_00fa: Expected F4, but got I4
		if (!isTimeFreeze)
		{
			UiManager instance = UiManager.Instance;
			bool flag = instance.pause.IsPaused();
			if (!flag && isUnderwater == flag)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerEffects playerEffects = instance2.playerEffects;
				float num = playerEffects.dangerValue;
				if (!(playerEffects.dangerValue > 0.01f))
				{
					return defaultCutoff;
				}
				if (!(0f > playerEffects.dangerValue))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				float num2 = 900f - defaultCutoff;
				float num3 = num2 * num;
				return num3 + defaultCutoff;
			}
		}
		return lowCutoff;
	}

	private void Update()
	{
		//IL_023b: Invalid comparison between I4 and F4
		//IL_018d: Expected F4, but got I4
		//IL_00f7: Invalid comparison between I4 and F4
		//IL_0142: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171FC0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float cutoffFrequency = filter.cutoffFrequency;
		float num2;
		if (!isTimeFreeze)
		{
			UiManager instance = UiManager.Instance;
			bool flag = instance.pause.IsPaused();
			if (!flag && isUnderwater == flag)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerEffects playerEffects = instance2.playerEffects;
				float num = playerEffects.dangerValue;
				num2 = defaultCutoff;
				if (playerEffects.dangerValue > 0.01f)
				{
					if (!(0f > playerEffects.dangerValue))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					float num3 = 900f - num2;
					float num4 = num3 * num;
					float num5 = num4 + num2;
					num2 = num5;
				}
				goto IL_0219;
			}
		}
		num2 = lowCutoff;
		goto IL_0219;
		IL_0219:
		float deltaTime = Time.deltaTime;
		float num6 = deltaTime * 6f;
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
		float num7 = num2 - cutoffFrequency;
		float num8 = num7 * num6;
		float value = (lowpassFrequency = num8 + cutoffFrequency);
		bool flag2 = audioMixer.SetFloat("AmbienceLowpass", value);
		bool flag3 = audioMixer.SetFloat("GameSfxLowpass", lowpassFrequency);
		bool flag4 = audioMixer.SetFloat("MusicLowpass", lowpassFrequency);
	}
}
