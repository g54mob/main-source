using System;
using Cpp2ILInjected;
using Doozy.Engine.Progress;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Examples;

public class ExampleProgressTargetAudioMixer : ProgressTarget
{
	public AudioMixer AudioMixer;

	public string ExposedParameter;

	public TargetVariable TargetVariable;

	private float m_targetValue;

	public override void UpdateTarget(Progressor progressor)
	{
		//IL_0070: Expected O, but got I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		AudioMixer audioMixer = AudioMixer;
		if ((object)AudioMixer == null || ((UnityEngine.Object)audioMixer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		m_targetValue = 0f;
		bool flag = TargetVariable == TargetVariable.Value;
		float targetValue2;
		if (!flag)
		{
			object obj = TargetVariable - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 == 1)
						{
							float progress = progressor.Progress;
							float targetValue = 1f - progress;
							m_targetValue = targetValue;
						}
					}
					else
					{
						float progress2 = progressor.Progress;
						m_targetValue = progress2;
					}
					goto IL_0154;
				}
				targetValue2 = progressor.m_maxValue;
			}
			else
			{
				targetValue2 = progressor.m_minValue;
			}
		}
		else
		{
			targetValue2 = progressor.m_currentValue;
		}
		m_targetValue = targetValue2;
		goto IL_0154;
		IL_0154:
		bool flag2 = AudioMixer.SetFloat(ExposedParameter, m_targetValue);
	}

	public ExampleProgressTargetAudioMixer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
