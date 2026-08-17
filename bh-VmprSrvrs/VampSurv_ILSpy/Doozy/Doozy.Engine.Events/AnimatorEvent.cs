using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.Events;

[Serializable]
public class AnimatorEvent
{
	public enum ParameterType
	{
		Bool,
		Float,
		Int,
		Trigger
	}

	public Animator Animator;

	public bool BoolValue;

	public float FloatValue;

	public int IntValue;

	public string ParameterName;

	public bool ResetTrigger;

	public ParameterType TargetParameterType;

	public AnimatorEvent()
	{
		Reset();
	}

	public AnimatorEvent(Animator animator, string parameterName, bool boolValue)
	{
		Reset();
		TargetParameterType = ParameterType.Bool;
		Animator = animator;
		ParameterName = parameterName;
		BoolValue = boolValue;
	}

	public AnimatorEvent(Animator animator, string parameterName, int intValue)
	{
		Reset();
		TargetParameterType = ParameterType.Int;
		Animator = animator;
		ParameterName = parameterName;
		IntValue = intValue;
	}

	public AnimatorEvent(Animator animator, string parameterName, float floatValue)
	{
		Reset();
		TargetParameterType = ParameterType.Float;
		Animator = animator;
		ParameterName = parameterName;
		FloatValue = floatValue;
	}

	public AnimatorEvent(Animator animator, string parameterName)
	{
		Reset();
		TargetParameterType = ParameterType.Trigger;
		Animator = animator;
		ParameterName = parameterName;
	}

	public void Invoke(UnityAction<bool> callback = null)
	{
		//IL_01ba: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_013f: Expected O, but got I4
		//IL_018f: Expected O, but got I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_011a: Expected O, but got I4
		Animator animator = Animator;
		if ((object)Animator != null && ((UnityEngine.Object)animator).m_CachedPtr != (IntPtr)0)
		{
			bool flag = TargetParameterType == ParameterType.Bool;
			if (!flag)
			{
				object obj = TargetParameterType - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
							throw ex;
						}
						if (ResetTrigger)
						{
							Animator.ResetTriggerString(ParameterName);
						}
						Animator.SetTriggerString(ParameterName);
					}
					else
					{
						Animator.SetIntegerString(ParameterName, IntValue);
						object obj3 = 0;
					}
				}
				else
				{
					Animator.SetFloatString(ParameterName, FloatValue);
					object obj3 = 0;
				}
			}
			else
			{
				Animator.SetBoolString(ParameterName, BoolValue);
				object obj3 = 0;
			}
			if (callback == null)
			{
				return;
			}
			object obj4 = 1;
		}
		else
		{
			if (callback == null)
			{
				return;
			}
			object obj4 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [callback @ rdx (UnityEngine.Events.UnityAction`1<System.Boolean>)+18] (should have been resolved before IL gen)");
	}

	public void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B9D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Animator = null;
		TargetParameterType = ParameterType.Trigger;
		ParameterName = "";
		BoolValue = false;
		FloatValue = 0f;
		ResetTrigger = false;
	}

	public void SetValue()
	{
		//IL_002f: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		bool flag = TargetParameterType == ParameterType.Bool;
		if (!flag)
		{
			object obj = TargetParameterType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
						throw ex;
					}
					if (ResetTrigger)
					{
						Animator.ResetTriggerString(ParameterName);
					}
					Animator.SetTriggerString(ParameterName);
				}
				else
				{
					Animator.SetIntegerString(ParameterName, IntValue);
				}
			}
			else
			{
				Animator.SetFloatString(ParameterName, FloatValue);
			}
		}
		else
		{
			Animator.SetBoolString(ParameterName, BoolValue);
		}
	}

	private static void InvokeCallback(UnityAction<bool> callback, bool value)
	{
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [callback @ rcx (UnityEngine.Events.UnityAction`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}
}
