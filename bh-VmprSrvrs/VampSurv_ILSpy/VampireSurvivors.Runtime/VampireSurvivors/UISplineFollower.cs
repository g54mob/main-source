using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using Dreamteck.Splines;
using UnityEngine;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors;

public class UISplineFollower : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public float progress;

		public UISplineFollower _003C_003E4__this;

		public TweenCallback _003C_003E9__6;

		internal float _003CDoAnimation_003Eb__0()
		{
			return progress;
		}

		internal void _003CDoAnimation_003Eb__1(float x)
		{
			progress = x;
		}

		internal float _003CDoAnimation_003Eb__2()
		{
			return progress;
		}

		internal void _003CDoAnimation_003Eb__3(float x)
		{
			progress = x;
		}

		internal void _003CDoAnimation_003Eb__4()
		{
			//IL_00ea: Invalid comparison between F4 and I4
			//IL_010c: Expected I, but got F4
			UISplineFollower uISplineFollower = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)uISplineFollower.Spline != null)
			{
				SplineSample splineSample = uISplineFollower.Spline.Evaluate(progress);
				if ((object)_003C_003E4__this != null)
				{
					Transform transform = _003C_003E4__this.transform;
					if (splineSample != null && (object)transform != null)
					{
						bool flag = ((_003C_003Ec__DisplayClass17_0)(object)transform).progress == 0f;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)((_003C_003Ec__DisplayClass17_0)(object)transform).progress, ref value);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CDoAnimation_003Eb__5()
		{
			UISplineFollower uISplineFollower = _003C_003E4__this;
			TrailRenderer trail = uISplineFollower._trail;
			if ((object)uISplineFollower._trail == null || ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			UISplineFollower uISplineFollower2 = _003C_003E4__this;
			float time = uISplineFollower2._trail.time;
			TweenCallback onComplete = _003C_003E9__6;
			if (_003C_003E9__6 == null)
			{
				onComplete = (_003C_003E9__6 = delegate
				{
					UISplineFollower uISplineFollower3 = _003C_003E4__this;
					TrailRenderer trail2 = uISplineFollower3._trail;
					if ((object)uISplineFollower3._trail != null && ((UnityEngine.Object)trail2).m_CachedPtr != (IntPtr)0)
					{
						UISplineFollower uISplineFollower4 = _003C_003E4__this;
						uISplineFollower4._trail.enabled = false;
					}
				});
			}
			float duration = time * 1000f;
			Tween tween = UITimerHelper.RegisterMillis(duration, onComplete);
		}

		internal void _003CDoAnimation_003Eb__6()
		{
			UISplineFollower uISplineFollower = _003C_003E4__this;
			TrailRenderer trail = uISplineFollower._trail;
			if ((object)uISplineFollower._trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
			{
				UISplineFollower uISplineFollower2 = _003C_003E4__this;
				uISplineFollower2._trail.enabled = false;
			}
		}
	}

	private sealed class _003CBeginPlaying_003Ed__16(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float initialDelay;

		public UISplineFollower _003C_003E4__this;

		public float duration;

		public bool shouldLoop;

		public int loopCount;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0079: Expected I4, but got I8
			//IL_00d2: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = initialDelay;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				Ease ease = default(Ease);
				_003C_003E4__this.DoAnimation(duration, shouldLoop, loopCount, ease);
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitAndMove_003Ed__20(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UISplineFollower _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0158: Expected I4, but got I8
			//IL_0039: Expected O, but got I4
			//IL_012c: Expected I4, but got I8
			//IL_0079: Expected I4, but got I8
			UISplineFollower uISplineFollower = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						return false;
					}
					_003C_003E1__state = -1;
					bool flag2 = (object)_003C_003E4__this == null;
					bool flag3 = (object)uISplineFollower.Spline == null;
					SplineSample splineSample = uISplineFollower.Spline.Evaluate(0.0010000000474974513);
					Transform transform = _003C_003E4__this.transform;
					bool flag4 = splineSample == null;
					bool flag5 = (object)transform == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					return false;
				}
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private SplineComputer Spline;

	private float Duration;

	private float InitialDelay;

	private bool ShouldLoop;

	private int LoopCount;

	private float LoopInterval;

	private bool PlayOnAwake;

	private Tween _toTween;

	private Tween _fromTween;

	private TrailRenderer _trail;

	private Sequence _sequence;

	private void OnEnable()
	{
		TrailRenderer component = GetComponent<TrailRenderer>();
		_trail = component;
		if (PlayOnAwake)
		{
			int loopCount = default(int);
			Ease ease = default(Ease);
			IEnumerator routine = BeginPlaying(Duration, InitialDelay, ShouldLoop, loopCount, ease);
			Coroutine coroutine = StartCoroutine(routine);
			Debug.Log("Playing spline tween");
		}
	}

	public void Play()
	{
		int loopCount = default(int);
		Ease ease = default(Ease);
		IEnumerator routine = BeginPlaying(Duration, InitialDelay, ShouldLoop, loopCount, ease);
		Coroutine coroutine = StartCoroutine(routine);
	}

	public void Complete()
	{
		if (_toTween != null)
		{
			TweenExtensions.Kill(_toTween, complete: true);
		}
		if (_fromTween != null)
		{
			TweenExtensions.Kill(_fromTween, complete: true);
		}
		if (_sequence != null)
		{
			TweenExtensions.Kill(_sequence, complete: true);
		}
		float optionalFloat = default(float);
		object optionalObj = default(object);
		object[] optionalArray = default(object[]);
		int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)this, false, optionalFloat, optionalObj, optionalArray);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public void Play(float duration, float initialDelay = 0f, bool shouldLoop = false, int loopCount = 1, Ease ease = Ease.Linear)
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		int loopCount2 = default(int);
		Ease ease2 = default(Ease);
		IEnumerator routine = BeginPlaying(duration, initialDelay, shouldLoop, loopCount2, ease2);
		Coroutine coroutine = StartCoroutine(routine);
	}

	public SplineComputer GetCurve()
	{
		return Spline;
	}

	private IEnumerator BeginPlaying(float duration, float initialDelay = 0f, bool shouldLoop = false, int loopCount = 1, Ease ease = Ease.Linear)
	{
		_003CBeginPlaying_003Ed__16 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		int loopCount2 = default(int);
		obj.loopCount = loopCount2;
		obj.duration = duration;
		obj.initialDelay = initialDelay;
		obj.shouldLoop = shouldLoop;
		return obj;
	}

	private void DoAnimation(float duration, bool shouldLoop = false, int loopCount = 1, Ease ease = Ease.Linear)
	{
		//IL_0181: Expected O, but got I4
		//IL_01ca: Expected O, but got I4
		//IL_011f: Expected O, but got I4
		//IL_0418: Expected O, but got I8
		//IL_0480: Invalid comparison between F4 and I4
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_06c8: Expected O, but got I4
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Expected O, but got Unknown
		//IL_039c: Expected I4, but got I8
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals21._003C_003E4__this = this;
		Sequence sequence = DOTween.Sequence();
		TrailRenderer trail = _trail;
		if ((object)_trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_trail.enabled = true;
		}
		CS_0024_003C_003E8__locals21.progress = 0f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass17_0)(object)dOSetter)._003CDoAnimation_003Eb__1(duration);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, duration);
		Ease ease2 = default(Ease);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				object obj = ease2 - 32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		_toTween = tweenerCore;
		bool flag = TweenSettingsExtensions.ValidateAddToSequence(sequence, _toTween, false);
		bool flag2 = !flag;
		object obj2 = 0;
		float num = 1f;
		if (!flag2)
		{
			num = ((Tween)sequence).duration;
			Sequence sequence2 = Sequence.DoInsert(sequence, _toTween, ((Tween)sequence).duration);
			obj2 = 0;
		}
		if (shouldLoop)
		{
			DOGetter<float> getter2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			((_003C_003Ec__DisplayClass17_0)(object)dOSetter2)._003CDoAnimation_003Eb__3(duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, 0f, duration);
			((_003C_003Ec__DisplayClass17_0)(object)tweenerCore2)._003CDoAnimation_003Eb__3(duration);
			Tween fromTween = default(Tween);
			_fromTween = fromTween;
			int num2;
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, _fromTween, false))
			{
				Sequence sequence3 = Sequence.DoInsert(sequence, _fromTween, ((Tween)sequence).duration);
				Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, LoopInterval);
				num2 = loopCount;
			}
			else
			{
				Sequence sequence5 = TweenSettingsExtensions.AppendInterval(sequence, LoopInterval);
				bool flag3 = sequence == null;
				num2 = loopCount;
				if (flag3)
				{
					goto IL_0597;
				}
			}
			if (((Tween)sequence)._003Cactive_003Ek__BackingField && !((Tween)sequence).creationLocked)
			{
				if (loopCount >= -1)
				{
					if (loopCount == 0)
					{
						num2 = 1;
					}
				}
				else
				{
					num2 = -1;
				}
				((Tween)sequence).loops = num2;
				if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
				{
					if (num2 <= -1)
					{
						((Tween)sequence).fullDuration = 1f / 0f;
					}
					else
					{
						float fullDuration = (float)num2 * ((Tween)sequence).duration;
						((Tween)sequence).fullDuration = fullDuration;
					}
				}
			}
		}
		goto IL_0597;
		IL_06ab:
		_sequence = sequence;
		return;
		IL_0597:
		TweenCallback onUpdate = delegate
		{
			//IL_00ea: Invalid comparison between F4 and I4
			//IL_010c: Expected I, but got F4
			UISplineFollower uISplineFollower = CS_0024_003C_003E8__locals21._003C_003E4__this;
			if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null && (object)uISplineFollower.Spline != null)
			{
				SplineSample splineSample = uISplineFollower.Spline.Evaluate(CS_0024_003C_003E8__locals21.progress);
				if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null)
				{
					Transform transform = CS_0024_003C_003E8__locals21._003C_003E4__this.transform;
					if (splineSample != null && (object)transform != null)
					{
						bool flag6 = ((_003C_003Ec__DisplayClass17_0)(object)transform).progress == 0f;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)((_003C_003Ec__DisplayClass17_0)(object)transform).progress, ref value);
						return;
					}
				}
			}
			throw new NullReferenceException();
		};
		TweenCallback onComplete;
		if (sequence != null)
		{
			bool flag4 = !((Tween)sequence)._003Cactive_003Ek__BackingField;
			object obj3 = 6603577472L;
			if (!flag4)
			{
				sequence.onUpdate = onUpdate;
				if (((Tween)sequence)._003Cactive_003Ek__BackingField)
				{
					float num3 = (float)ease2 - 32f;
					((Tween)sequence).easeType = ease2;
					if (!(num3 > 3f))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rbx+0C0h]\"");
						sequence.easeOvershootOrAmplitude = num3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag5 = (nint)0 == 0;
					((Tween)sequence).customEase = null;
					if (!flag5)
					{
						object obj4 = sequence + 184;
						object obj5 = obj4 >> 12;
						object obj6 = obj5 & 0x1FFFFF;
						object obj7 = obj6 >> 6;
						object obj8 = obj6 & 0x3F;
						nint num5;
						do
						{
							object obj9 = 1 << (int)obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rbp_v11+462E0+v1190 @ rdx_v26*8]");
							object obj10 = 0 | obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rbp_v11+462E0+v1190 @ rdx_v26*8]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rbp_v11+462E0+v1190 @ rdx_v26*8]");
							if (num4 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rbp_v11+462E0+v1190 @ rdx_v26*8]");
							num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rbp_v11+462E0+v1190 @ rdx_v26*8]");
						}
						while (num5 != 0);
						TweenCallback tweenCallback = delegate
						{
							UISplineFollower uISplineFollower = CS_0024_003C_003E8__locals21._003C_003E4__this;
							TrailRenderer trail2 = uISplineFollower._trail;
							if ((object)uISplineFollower._trail != null && ((UnityEngine.Object)trail2).m_CachedPtr != (IntPtr)0)
							{
								UISplineFollower uISplineFollower2 = CS_0024_003C_003E8__locals21._003C_003E4__this;
								float time = uISplineFollower2._trail.time;
								TweenCallback onComplete2 = CS_0024_003C_003E8__locals21._003C_003E9__6;
								if (CS_0024_003C_003E8__locals21._003C_003E9__6 == null)
								{
									onComplete2 = (CS_0024_003C_003E8__locals21._003C_003E9__6 = delegate
									{
										UISplineFollower uISplineFollower3 = CS_0024_003C_003E8__locals21._003C_003E4__this;
										TrailRenderer trail3 = uISplineFollower3._trail;
										if ((object)uISplineFollower3._trail != null && ((UnityEngine.Object)trail3).m_CachedPtr != (IntPtr)0)
										{
											UISplineFollower uISplineFollower4 = CS_0024_003C_003E8__locals21._003C_003E4__this;
											uISplineFollower4._trail.enabled = false;
										}
									});
								}
								float duration2 = time * 1000f;
								Tween tween = UITimerHelper.RegisterMillis(duration2, onComplete2);
							}
						};
						onComplete = tweenCallback;
						goto IL_0689;
					}
				}
			}
		}
		TweenCallback tweenCallback2 = delegate
		{
			UISplineFollower uISplineFollower = CS_0024_003C_003E8__locals21._003C_003E4__this;
			TrailRenderer trail2 = uISplineFollower._trail;
			if ((object)uISplineFollower._trail != null && ((UnityEngine.Object)trail2).m_CachedPtr != (IntPtr)0)
			{
				UISplineFollower uISplineFollower2 = CS_0024_003C_003E8__locals21._003C_003E4__this;
				float time = uISplineFollower2._trail.time;
				TweenCallback onComplete2 = CS_0024_003C_003E8__locals21._003C_003E9__6;
				if (CS_0024_003C_003E8__locals21._003C_003E9__6 == null)
				{
					onComplete2 = (CS_0024_003C_003E8__locals21._003C_003E9__6 = delegate
					{
						UISplineFollower uISplineFollower3 = CS_0024_003C_003E8__locals21._003C_003E4__this;
						TrailRenderer trail3 = uISplineFollower3._trail;
						if ((object)uISplineFollower3._trail != null && ((UnityEngine.Object)trail3).m_CachedPtr != (IntPtr)0)
						{
							UISplineFollower uISplineFollower4 = CS_0024_003C_003E8__locals21._003C_003E4__this;
							uISplineFollower4._trail.enabled = false;
						}
					});
				}
				float duration2 = time * 1000f;
				Tween tween = UITimerHelper.RegisterMillis(duration2, onComplete2);
			}
		};
		if (sequence != null)
		{
			onComplete = tweenCallback2;
			goto IL_0689;
		}
		goto IL_06ab;
		IL_0689:
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = onComplete;
		}
		goto IL_06ab;
	}

	private void OnDestroy()
	{
		Complete();
	}

	public void SetSpline(SplineComputer spline)
	{
		TrailRenderer component = GetComponent<TrailRenderer>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			TrailRenderer component2 = GetComponent<TrailRenderer>();
			component2.enabled = false;
		}
		Spline = spline;
		_003CWaitAndMove_003Ed__20 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitAndMove()
	{
		_003CWaitAndMove_003Ed__20 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public UISplineFollower()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
