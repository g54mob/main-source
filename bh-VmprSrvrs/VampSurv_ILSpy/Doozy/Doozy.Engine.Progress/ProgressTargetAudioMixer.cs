using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Progress;

public class ProgressTargetAudioMixer : ProgressTarget
{
	private const float MIN_VALUE = 0.0001f;

	private const float MAX_VALUE = 1f;

	public string ExposedParameterName;

	public AudioMixer TargetMixer;

	public bool UseLogarithmicConversion;

	public override void UpdateTarget(Progressor progressor)
	{
		AudioMixer targetMixer = TargetMixer;
		if ((object)TargetMixer == null || ((UnityEngine.Object)targetMixer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float num;
		if (UseLogarithmicConversion)
		{
			num = progressor.Progress;
			bool flag = 0.0001f > num;
			float num2 = 0.0001f;
			float num3;
			if (!flag)
			{
				bool flag2 = !(num > 1f);
				num2 = 1f;
				num3 = 1f;
				if (flag2)
				{
					goto IL_0133;
				}
			}
			num3 = num2;
			num = num2;
			goto IL_0133;
		}
		float value = progressor.m_currentValue;
		goto IL_00e1;
		IL_0133:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FD90");
		value = num * 20f;
		goto IL_00e1;
		IL_00e1:
		bool flag3 = TargetMixer.SetFloat(ExposedParameterName, value);
	}

	private static float GetLogarithmicValue(float value)
	{
		float num = default(float);
		bool flag = 0.0001f > num;
		float num2 = 0.0001f;
		float num3;
		if (!flag)
		{
			bool flag2 = !(num > 1f);
			num2 = 1f;
			num3 = 1f;
			if (flag2)
			{
				goto IL_0065;
			}
		}
		num3 = num2;
		goto IL_0065;
		IL_0065:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FD90");
		return num2 * 20f;
	}

	public ProgressTargetAudioMixer()
	{
		//IL_0020: Expected I, but got O
		UseLogarithmicConversion = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
