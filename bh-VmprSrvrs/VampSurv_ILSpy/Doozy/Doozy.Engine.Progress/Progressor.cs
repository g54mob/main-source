using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Progress;

public class Progressor : MonoBehaviour
{
	public const float TOLERANCE = 0.001f;

	public const bool DEFAULT_ANIMATE_VALUE = false;

	public const float DEFAULT_DURATION = 0.5f;

	public const Ease DEFAULT_EASE = Ease.Linear;

	public const bool DEFAULT_IGNORE_UNITY_TIMESCALE = true;

	public bool DebugMode;

	public List<ProgressTarget> ProgressTargets;

	public bool AnimateValue;

	public float AnimationDuration = 0.5f;

	public Ease AnimationEase = Ease.Linear;

	public bool AnimationIgnoresUnityTimescale = true;

	public ResetValue OnEnableResetValue = ResetValue.ToMinValue;

	public ResetValue OnDisableResetValue;

	public float CustomResetValue;

	public ProgressEvent OnValueChanged;

	public ProgressEvent OnProgressChanged;

	public ProgressEvent OnInverseProgressChanged;

	private float m_minValue;

	private float m_maxValue;

	private bool m_wholeNumbers;

	private float m_currentValue;

	private float m_previousValue;

	private Sequence m_animationSequence;

	private float m_value;

	private float m_progress;

	private float m_inverseProgress;

	private bool m_updatePreviousValue;

	private Tweener m_tween;

	private bool m_tweenInitialized;

	public float Progress
	{
		get
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_0036: Invalid comparison between F4 and O
			//IL_0091: Invalid comparison between I4 and F4
			//IL_00d4: Expected F4, but got I4
			//IL_0053: Expected F4, but got I4
			float num = m_minValue - m_maxValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				return 0f;
			}
			float num2 = m_currentValue - m_minValue;
			float num3 = m_maxValue - m_minValue;
			float num4 = num2 / num3;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					return 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			return num4;
		}
	}

	public float InverseProgress
	{
		get
		{
			float progress = Progress;
			return 1f - progress;
		}
	}

	public float Value
	{
		get
		{
			return m_currentValue;
		}
		private set
		{
			m_currentValue = value;
		}
	}

	public float MinValue
	{
		get
		{
			return m_minValue;
		}
		protected set
		{
			m_minValue = value;
		}
	}

	public float MaxValue
	{
		get
		{
			return m_maxValue;
		}
		protected set
		{
			m_maxValue = value;
		}
	}

	public bool WholeNumbers => m_wholeNumbers;

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugProgressor;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private unsafe string GetAnimationId
	{
		get
		{
			//IL_0046: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980ADE]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			int instanceID = GetInstanceID();
			object obj = default(object);
			string text = System.Number.FormatInt32(instanceID, (ReadOnlySpan<char>)(&obj), null);
			return text + " - Progressor Animation";
		}
	}

	private void OnEnable()
	{
		KillAnimation();
		ResetValueTo(OnEnableResetValue, instantUpdate: true);
		bool flag = !m_tweenInitialized;
		m_updatePreviousValue = true;
		if (!flag)
		{
			TweenExtensions.Kill(m_tween, complete: true);
			m_tweenInitialized = false;
		}
	}

	private void OnDisable()
	{
		KillAnimation();
		ResetValueTo(OnDisableResetValue, instantUpdate: true);
		if (m_tweenInitialized)
		{
			TweenExtensions.Kill(m_tween, complete: true);
			m_tweenInitialized = false;
		}
	}

	private void Update()
	{
		float num = m_minValue;
		float num2 = m_currentValue;
		if (!(m_minValue > m_currentValue))
		{
			num = m_maxValue;
			if (!(m_currentValue > m_maxValue))
			{
				goto IL_00e8;
			}
		}
		num2 = num;
		goto IL_00e8;
		IL_00e8:
		if (m_wholeNumbers)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		}
		m_currentValue = num2;
		if (!m_updatePreviousValue)
		{
			bool flag = m_previousValue == num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C2FAE0h\"");
			if (flag)
			{
				return;
			}
		}
		OnValueChanged.Invoke(m_currentValue);
		UpdateProgress();
		UpdateProgressTargets();
		m_previousValue = m_currentValue;
		m_updatePreviousValue = false;
	}

	public void OnValueUpdated()
	{
		OnValueChanged.Invoke(m_currentValue);
		UpdateProgress();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 43 Invalid \"Jump target not found in method: 0x182C2FBC0\"");
		throw new NullReferenceException();
	}

	public unsafe void UpdateProgressTargets()
	{
		//IL_0013: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00b8: Expected O, but got Ref
		//IL_00e2: Expected O, but got Ref
		//IL_007a: Expected O, but got I4
		//IL_0153: Expected O, but got I
		//IL_0226: Expected O, but got I4
		if (ProgressTargets == null)
		{
			return;
		}
		object obj = 0;
		List<ProgressTarget>.Enumerator enumerator = default(List<ProgressTarget>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj2 = 0;
			obj = 1;
		}
		if (obj == null)
		{
			return;
		}
		List<ProgressTarget> progressTargets = ProgressTargets;
		bool flag = (nint)ProgressTargets < 0;
		bool flag2 = ProgressTargets == null;
		List<ProgressTarget>.Enumerator enumerator2 = (List<ProgressTarget>.Enumerator)(&enumerator);
		if (!flag2)
		{
			int num = progressTargets._size - 1;
			enumerator2 = (List<ProgressTarget>.Enumerator)(&enumerator);
			if (flag)
			{
				return;
			}
			while (true)
			{
				List<ProgressTarget> progressTargets2 = ProgressTargets;
				if (ProgressTargets == null)
				{
					break;
				}
				bool flag3;
				if (num < progressTargets2._size)
				{
					enumerator2 = (List<ProgressTarget>.Enumerator)progressTargets2._items;
					if (progressTargets2._items == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Progress.ProgressTarget>+Enumerator<Doozy.Engine.Progress.ProgressTarget>)+20+v401 @ rbx_v10 (System.Int32)*8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rcx_v10 (System.Collections.Generic.List`1<Doozy.Engine.Progress.ProgressTarget>+Enumerator<Doozy.Engine.Progress.ProgressTarget>)+20+v401 @ rbx_v10 (System.Int32)*8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdi_v9+10]");
						flag3 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdi_v9+10]");
						bool flag4 = (nint)0 != 0;
						enumerator2 = (List<ProgressTarget>.Enumerator)typeof(UnityEngine.Object);
						if (flag4)
						{
							goto IL_020d;
						}
					}
					flag3 = (nint)ProgressTargets < 0;
					bool flag5 = ProgressTargets == null;
					enumerator2 = (List<ProgressTarget>.Enumerator)ProgressTargets;
					if (flag5)
					{
						break;
					}
					ProgressTargets.RemoveAt(num);
					enumerator2 = (List<ProgressTarget>.Enumerator)ProgressTargets;
					goto IL_020d;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_020d:
				num--;
				object obj4 = !flag3;
				if (obj4 == null)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetValue(float value)
	{
		SetValue(value, instantUpdate: false);
	}

	public void InstantSetValue(float value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x182C2FF70\"");
	}

	public void SetValue(float value, bool instantUpdate)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_009c: Invalid comparison between F4 and O
		float num;
		if (!(m_minValue > value))
		{
			float maxValue = m_maxValue;
			bool flag = !(value > m_maxValue);
			num = value;
			if (!flag)
			{
				num = m_maxValue;
			}
		}
		else
		{
			float maxValue = value;
			num = m_minValue;
		}
		if (m_wholeNumbers)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		}
		float num2 = num - m_currentValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			return;
		}
		bool flag2 = !AnimateValue;
		bool flag3 = instantUpdate;
		if (!flag2)
		{
			KillAnimation();
			flag3 = false;
		}
		if (!instantUpdate && AnimateValue != instantUpdate)
		{
			if (m_tweenInitialized != instantUpdate)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object newEndValue = default(object);
				Tweener tweener = m_tween.ChangeEndValue(newEndValue, snapStartValue: true);
			}
			else
			{
				bool ignoreTimescale = default(bool);
				Tweener animationTween = GetAnimationTween(num, AnimationDuration, AnimationEase, ignoreTimescale);
				m_tween = animationTween;
			}
			Sequence animationSequence = m_animationSequence;
			if (TweenSettingsExtensions.ValidateAddToSequence(m_animationSequence, (Tween)m_tween, false))
			{
				Sequence sequence = Sequence.DoInsert(m_animationSequence, (Tween)m_tween, ((Tween)animationSequence).duration);
			}
			Sequence sequence2 = TweenExtensions.Play(m_animationSequence);
		}
		else
		{
			m_currentValue = num;
		}
	}

	public void SetProgress(float progressValue)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_005c: Expected F4, but got I4
		float num;
		if (!(0f > progressValue))
		{
			bool flag = !(progressValue > 1f);
			num = progressValue;
			if (!flag)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = m_maxValue - m_minValue;
		float num3 = num2 * num;
		float value = num3 + m_minValue;
		SetValue(value, instantUpdate: false);
	}

	public void InstantSetProgress(float progressValue)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_005c: Expected F4, but got I4
		float num;
		if (!(0f > progressValue))
		{
			bool flag = !(progressValue > 1f);
			num = progressValue;
			if (!flag)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = m_maxValue - m_minValue;
		float num3 = num2 * num;
		float value = num3 + m_minValue;
		SetValue(value, instantUpdate: true);
	}

	public void SetProgress(float progressValue, bool instantUpdate)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_005c: Expected F4, but got I4
		float num;
		if (!(0f > progressValue))
		{
			bool flag = !(progressValue > 1f);
			num = progressValue;
			if (!flag)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = m_maxValue - m_minValue;
		float num3 = num2 * num;
		float value = num3 + m_minValue;
		SetValue(value, instantUpdate);
	}

	public float GetProgress(TargetProgress direction)
	{
		switch (direction)
		{
		case TargetProgress.Progress:
			return Progress;
		case TargetProgress.InverseProgress:
		{
			float progress = Progress;
			return 1f - progress;
		}
		default:
		{
			TargetProgress targetProgress = default(TargetProgress);
			object actualValue = targetProgress;
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("direction", actualValue, null);
			throw ex;
		}
		}
	}

	public void UpdateProgress()
	{
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugProgressor)
			{
				goto IL_01b1;
			}
		}
		string[] array = new string[8];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string text = GetName();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text2 = System.Number.FormatSingle(m_currentValue, null, currentInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		float progress = Progress;
		NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
		string text3 = System.Number.FormatSingle(progress, null, currentInfo2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		float progress2 = Progress;
		float value = 1f - progress2;
		NumberFormatInfo currentInfo3 = NumberFormatInfo.CurrentInfo;
		string text4 = System.Number.FormatSingle(value, null, currentInfo3);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string message = string.Concat(array);
		DDebug.Log(message, this);
		goto IL_01b1;
		IL_01b1:
		float progress3 = Progress;
		OnProgressChanged.Invoke(progress3);
		float progress4 = Progress;
		float arg = 1f - progress4;
		OnInverseProgressChanged.Invoke(arg);
	}

	public void SetMin(float value)
	{
		float num = m_maxValue;
		bool flag = m_maxValue == value;
		if (m_maxValue > value)
		{
			num = value;
		}
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		}
		m_minValue = num;
		if (num > m_currentValue)
		{
			SetValue(num, instantUpdate: false);
		}
		UpdateProgress();
	}

	public void SetMax(float value)
	{
		float num = m_minValue;
		bool flag = m_minValue == value;
		if (m_minValue < value)
		{
			num = value;
		}
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		}
		m_maxValue = num;
		if (m_currentValue > num)
		{
			SetValue(num, instantUpdate: false);
		}
		UpdateProgress();
	}

	public void EnableWholeNumbers()
	{
		m_wholeNumbers = true;
	}

	public void DisableWholeNumbers()
	{
		m_wholeNumbers = false;
	}

	public void ResetValueTo(ResetValue resetValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x182C306B0\"");
	}

	public unsafe void ResetValueTo(ResetValue resetValue, bool instantUpdate)
	{
		//IL_02bf: Expected O, but got I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_00e1: Expected Ref, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980AE3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = resetValue - 1;
		bool flag = resetValue == ResetValue.ToMinValue;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 == 1)
				{
					if (!DebugMode)
					{
						DoozySettings instance = DoozySettings.Instance;
						if (!instance.DebugProgressor)
						{
							goto IL_0114;
						}
					}
					string text = GetName();
					float num = (float)this + 72f;
					string text2 = ((float*)num)->ToString();
					string message = "[" + text + "] Resetting Value to CustomResetValue: " + text2;
					DDebug.Log(message, this);
					goto IL_0114;
				}
				goto IL_028e;
			}
			if (!DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if (!instance2.DebugProgressor)
				{
					goto IL_01c7;
				}
			}
			string text3 = GetName();
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string text4 = System.Number.FormatSingle(m_maxValue, null, currentInfo);
			string message2 = "[" + text3 + "] Resetting Value to MaxValue: " + text4;
			DDebug.Log(message2, this);
			goto IL_01c7;
		}
		if (!DebugMode)
		{
			DoozySettings instance3 = DoozySettings.Instance;
			if (!instance3.DebugProgressor)
			{
				goto IL_027a;
			}
		}
		string text5 = GetName();
		NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
		string text6 = System.Number.FormatSingle(m_minValue, null, currentInfo2);
		string message3 = "[" + text5 + "] Resetting Value to MinValue: " + text6;
		DDebug.Log(message3, this);
		goto IL_027a;
		IL_01c7:
		float value = m_maxValue;
		goto IL_02dc;
		IL_027a:
		value = m_minValue;
		goto IL_02dc;
		IL_0114:
		value = CustomResetValue;
		goto IL_02dc;
		IL_028e:
		OnValueChanged.Invoke(m_currentValue);
		UpdateProgress();
		UpdateProgressTargets();
		return;
		IL_02dc:
		SetValue(value, instantUpdate);
		goto IL_028e;
	}

	public float ClampValueBetweenMinAndMax(float value, bool roundValue = false)
	{
		float result = m_minValue;
		float num = default(float);
		if (!(m_minValue > num))
		{
			result = m_maxValue;
			if (!(num > m_maxValue))
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 43 Invalid \"Jump target not found in method: 0x18049A960\"");
		return result;
	}

	public Tweener GetAnimationTween(float targetValue, float duration, Ease ease, bool ignoreTimescale)
	{
		//IL_00ac: Expected O, but got I4
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((Progressor)(object)dOSetter)._003CGetAnimationTween_003Eb__68_1(targetValue);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, targetValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				object obj = ease - 32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [r9+0C0h]\"");
				}
				_ = 0;
			}
		}
		bool isIndependentUpdate = default(bool);
		Tweener tweener = TweenSettingsExtensions.SetUpdate(tweenerCore, isIndependentUpdate);
		if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)tweener).creationLocked)
			{
				((Tween)tweener).autoKill = false;
			}
			if (((Tween)tweener)._003Cactive_003Ek__BackingField)
			{
				((Tween)tweener).isRecyclable = true;
			}
		}
		return tweener;
	}

	public void StopAnimation(bool complete = false)
	{
		KillAnimation(complete);
	}

	private void KillAnimation(bool complete = false)
	{
		int num = DOTween.Kill(this, complete);
		if (m_animationSequence != null)
		{
			TweenExtensions.Kill(m_animationSequence, complete);
			m_animationSequence = null;
		}
	}

	private void KillTweener(bool complete = false)
	{
		if (m_tweenInitialized)
		{
			TweenExtensions.Kill(m_tween, complete);
			m_tweenInitialized = false;
		}
	}

	private static float RoundValue(float value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		return value;
	}

	private static Progressor AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<Progressor>("Progressor", isSingleton: false, selectGameObjectAfterCreation);
	}

	public Progressor()
	{
		ProgressEvent onValueChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnValueChanged = onValueChanged;
		ProgressEvent onProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnProgressChanged = onProgressChanged;
		ProgressEvent onInverseProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnInverseProgressChanged = onInverseProgressChanged;
		m_maxValue = 1f;
		m_updatePreviousValue = true;
	}

	private float _003CGetAnimationTween_003Eb__68_0()
	{
		return m_currentValue;
	}

	private void _003CGetAnimationTween_003Eb__68_1(float x)
	{
		m_currentValue = x;
	}
}
