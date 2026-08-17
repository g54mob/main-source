using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class TimeFreezeUi : MonoBehaviour
{
	public RawImage swirl;

	public RawImage vignette;

	private bool isTimeFrozen;

	public AudioSource a_start;

	public AudioSource a_end;

	public AudioSource a_loop;

	private void Awake()
	{
		//IL_0273: Expected I, but got O
		//IL_0284: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_02f2: Expected I, but got O
		//IL_033a: Expected O, but got I4
		//IL_0350: Expected I, but got O
		//IL_037e: Expected O, but got I4
		//IL_0394: Expected I, but got O
		Action<EStatusEffect, bool> b = OnStatusEffectAdded;
		Delegate obj = Delegate.Combine(PlayerStatusEffects.A_StatusEffectAdded, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = (Action<EStatusEffect, bool>)obj;
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
				goto IL_03b2;
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
				goto IL_02b6;
			}
		}
		Action<EStatusEffect> b2 = OnStatusEffectRemoved;
		Delegate obj6 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectRemoved, b2);
		if ((object)obj6 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = (Action<EStatusEffect>)obj6;
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
				goto IL_02c1;
			}
			PlayerStatusEffects.A_StatusEffectRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_02d1;
			}
		}
		num = (nint)MyTime.A_TimeScaleChange;
		Action action3 = RefreshTimeFreeze;
		Delegate obj8 = Delegate.Combine(MyTime.A_TimeScaleChange, action3);
		if ((object)obj8 == null)
		{
			MyTime.A_TimeScaleChange = null;
			return;
		}
		bool flag4 = (object)obj8.GetType() != typeof(Action);
		Delegate obj9 = null;
		if (!flag4)
		{
			obj9 = obj8;
		}
		bool flag5 = (object)obj9 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_03a2;
		}
		MyTime.A_TimeScaleChange = (Action)obj9;
		bool flag6 = (object)obj8.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj8;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num4 = (nint)typeof(Action);
		if (!flag7)
		{
			return;
		}
		goto IL_03b2;
		IL_03a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02d1;
		IL_03b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a2;
		IL_02d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02c1;
		IL_02b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b6;
	}

	private void OnDestroy()
	{
		//IL_0273: Expected I, but got O
		//IL_0284: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_02f2: Expected I, but got O
		//IL_033a: Expected O, but got I4
		//IL_0350: Expected I, but got O
		//IL_037e: Expected O, but got I4
		//IL_0394: Expected I, but got O
		Action<EStatusEffect, bool> value = OnStatusEffectAdded;
		Delegate obj = Delegate.Remove(PlayerStatusEffects.A_StatusEffectAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = (Action<EStatusEffect, bool>)obj;
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
				goto IL_03b2;
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
				goto IL_02b6;
			}
		}
		Action<EStatusEffect> value2 = OnStatusEffectRemoved;
		Delegate obj6 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectRemoved, value2);
		if ((object)obj6 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = (Action<EStatusEffect>)obj6;
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
				goto IL_02c1;
			}
			PlayerStatusEffects.A_StatusEffectRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_02d1;
			}
		}
		num = (nint)MyTime.A_TimeScaleChange;
		Action action3 = RefreshTimeFreeze;
		Delegate obj8 = Delegate.Remove(MyTime.A_TimeScaleChange, action3);
		if ((object)obj8 == null)
		{
			MyTime.A_TimeScaleChange = null;
			return;
		}
		bool flag4 = (object)obj8.GetType() != typeof(Action);
		Delegate obj9 = null;
		if (!flag4)
		{
			obj9 = obj8;
		}
		bool flag5 = (object)obj9 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_03a2;
		}
		MyTime.A_TimeScaleChange = (Action)obj9;
		bool flag6 = (object)obj8.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj8;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num4 = (nint)typeof(Action);
		if (!flag7)
		{
			return;
		}
		goto IL_03b2;
		IL_03a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02d1;
		IL_03b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a2;
		IL_02d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02c1;
		IL_02b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b6;
	}

	private void RefreshTimeFreeze()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		bool flag = inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze);
		if (1f > MyTime._003CtimeScale_003Ek__BackingField)
		{
			flag = true;
		}
		isTimeFrozen = flag;
		if (!isTimeFrozen)
		{
			if (flag)
			{
				vignette.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
				vignette.CrossFadeAlpha(1f, 1f, ignoreTimeScale: true);
				GameObject gameObject = vignette.gameObject;
				gameObject.SetActive(value: true);
				a_start.Play();
				a_loop.Play();
			}
		}
		else if (!flag)
		{
			GameObject gameObject2 = vignette.gameObject;
			gameObject2.SetActive(value: false);
			a_end.Play();
			a_loop.Stop();
		}
	}

	private void StartTimeFreeze()
	{
		vignette.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		vignette.CrossFadeAlpha(1f, 1f, ignoreTimeScale: true);
		GameObject gameObject = vignette.gameObject;
		gameObject.SetActive(value: true);
		a_start.Play();
		a_loop.Play();
	}

	private void EndTimeFreeze()
	{
		GameObject gameObject = vignette.gameObject;
		gameObject.SetActive(value: false);
		a_end.Play();
		a_loop.Stop();
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool newEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			RefreshTimeFreeze();
			GameObject gameObject = swirl.gameObject;
			gameObject.SetActive(value: true);
			swirl.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
			swirl.CrossFadeAlpha(1f, 1f, ignoreTimeScale: true);
		}
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			RefreshTimeFreeze();
			GameObject gameObject = swirl.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private unsafe void Update()
	{
		//IL_0054: Expected O, but got Ref
		if (isTimeFrozen)
		{
			Transform transform = swirl.transform;
			float deltaTime = Time.deltaTime;
			float angle = deltaTime * 50f;
			object obj = default(object);
			transform.Rotate((Vector3)(&obj), angle);
		}
	}
}
