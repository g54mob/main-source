using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.Engine.Settings;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI.Animation;

public static class UIAnimator
{
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CMove_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CMove_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CRotate_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CRotate_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CScale_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CScale_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CFade_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CFade_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public UnityAction onCompleteCallback;

		public UnityAction onStartCallback;

		public Sequence loopSequence;

		internal void _003CMoveLoop_003Eb__0()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CMoveLoop_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CMoveLoop_003Eb__2()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CMoveLoop_003Eb__3()
		{
			Sequence sequence = TweenExtensions.Play(loopSequence);
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public UnityAction onCompleteCallback;

		public UnityAction onStartCallback;

		public Sequence loopSequence;

		internal void _003CRotateLoop_003Eb__0()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CRotateLoop_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CRotateLoop_003Eb__2()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CRotateLoop_003Eb__3()
		{
			Sequence sequence = TweenExtensions.Play(loopSequence);
		}
	}

	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public UnityAction onCompleteCallback;

		public UnityAction onStartCallback;

		public Sequence loopSequence;

		internal void _003CScaleLoop_003Eb__0()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CScaleLoop_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CScaleLoop_003Eb__2()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CScaleLoop_003Eb__3()
		{
			Sequence sequence = TweenExtensions.Play(loopSequence);
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public UnityAction onCompleteCallback;

		public UnityAction onStartCallback;

		public Sequence loopSequence;

		internal void _003CFadeLoop_003Eb__0()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CFadeLoop_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CFadeLoop_003Eb__2()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CFadeLoop_003Eb__3()
		{
			Sequence sequence = TweenExtensions.Play(loopSequence);
		}
	}

	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public UnityAction onStartCallback;

		public RectTransform target;

		public Vector3 startValue;

		public UnityAction onCompleteCallback;

		public TweenCallback _003C_003E9__2;

		internal void _003CMovePunch_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CMovePunch_003Eb__1()
		{
			Vector2 endValue = default(Vector2);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(target, endValue, 0.05f);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					if (onCompleteCallback != null)
					{
						UnityAction unityAction = onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
		}

		internal void _003CMovePunch_003Eb__2()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public UnityAction onStartCallback;

		public RectTransform target;

		public Vector3 startValue;

		public UnityAction onCompleteCallback;

		public TweenCallback _003C_003E9__2;

		internal void _003CRotatePunch_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal unsafe void _003CRotatePunch_003Eb__1()
		{
			//IL_00a5: Expected O, but got Ref
			object obj = default(object);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), 0.05f);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					if (onCompleteCallback != null)
					{
						UnityAction unityAction = onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
		}

		internal void _003CRotatePunch_003Eb__2()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public UnityAction onStartCallback;

		public RectTransform target;

		public Vector3 startValue;

		public UnityAction onCompleteCallback;

		public TweenCallback _003C_003E9__2;

		internal void _003CScalePunch_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal unsafe void _003CScalePunch_003Eb__1()
		{
			//IL_00a0: Expected O, but got Ref
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&obj), 0.05f);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					if (onCompleteCallback != null)
					{
						UnityAction unityAction = onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
		}

		internal void _003CScalePunch_003Eb__2()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CMoveState_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CMoveState_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CRotateState_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CRotateState_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CScaleState_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CScaleState_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		internal void _003CFadeState_003Eb__0()
		{
			if (onStartCallback != null)
			{
				UnityAction unityAction = onStartCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CFadeState_003Eb__1()
		{
			if (onCompleteCallback != null)
			{
				UnityAction unityAction = onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public static Vector3 DEFAULT_START_POSITION;

	public static Vector3 DEFAULT_START_ROTATION;

	public static Vector3 DEFAULT_START_SCALE;

	public const float DEFAULT_START_ALPHA = 1f;

	public const bool DefaultAnimationEnabledState = false;

	public const Direction DefaultDirection = Direction.Left;

	public const RotateMode DefaultRotateMode = RotateMode.FastBeyond360;

	public const LoopType DefaultLoopType = LoopType.Yoyo;

	public const EaseType DefaultEaseType = EaseType.Ease;

	public const Ease DefaultEase = Ease.Linear;

	public const float DefaultDuration = 1f;

	public const float DefaultStartDelay = 0f;

	public const int DefaultNumberOfLoops = -1;

	public const float DefaultDurationOnComplete = 0.05f;

	public const float DefaultDurationInitLoop = 0.2f;

	public const float DefaultDurationResetTarget = 0.1f;

	public const int DefaultVibrato = 10;

	public const float DefaultElasticity = 1f;

	private static DoozySettings Settings => DoozySettings.Instance;

	public unsafe static Tween MoveTween(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue)
	{
		//IL_0013: Expected O, but got Ref
		//IL_007a: Expected O, but got Ref
		if ((object)target != null)
		{
			float num = default(float);
			target.anchoredPosition3D = (Vector3)(&num);
			if (animation != null)
			{
				Move move = animation.Move;
				if (animation.Move != null)
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t = DOTweenModuleUI.DOAnchorPos3D(target, (Vector3)(&num), move.Duration);
					Move move2 = animation.Move;
					if (animation.Move != null)
					{
						TweenerCore<Vector3, Vector3, VectorOptions> t2 = TweenSettingsExtensions.SetDelay(t, move2.StartDelay);
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
							DoozySettings instance2 = DoozySettings.Instance;
							if ((object)instance2 != null)
							{
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
										if ((nint)0 == 0)
										{
											_ = instance2.SpeedBasedAnimations;
										}
									}
								}
								Move move3 = animation.Move;
								if (animation.Move != null)
								{
									if (move3.EaseType == EaseType.Ease)
									{
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)move3.Ease != 0);
									}
									else if (move3.EaseType == EaseType.AnimationCurve)
									{
										Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, move3.AnimationCurve);
									}
									return tweenerCore;
								}
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static Vector3 MoveLoopPositionA(UIAnimation animation, Vector3 startValue)
	{
		//IL_0070: Expected native int or pointer, but got O
		//IL_007d: Expected native int or pointer, but got O
		if (animation != null)
		{
			Move move = animation.Move;
			if (animation.Move != null)
			{
				float num = startValue.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rax_v3 (Doozy.Engine.UI.Animation.Move)+38]");
				float z = num - 0f;
				Vector3 vector = default(Vector3);
				float x = default(float);
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 MoveLoopPositionB(UIAnimation animation, Vector3 startValue)
	{
		//IL_0070: Expected native int or pointer, but got O
		//IL_007d: Expected native int or pointer, but got O
		if (animation != null)
		{
			Move move = animation.Move;
			if (animation.Move != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rax_v3 (Doozy.Engine.UI.Animation.Move)+38]");
				float z = 0f + startValue.z;
				Vector3 vector = default(Vector3);
				float x = default(float);
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public static Tween MoveLoopTween(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		//IL_0229: Expected I4, but got I8
		//IL_026b: Expected O, but got I
		if (animation != null)
		{
			Move move = animation.Move;
			if (animation.Move != null)
			{
				Vector2 endValue = default(Vector2);
				TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPos(target, endValue, move.Duration);
				DoozySettings instance = DoozySettings.Instance;
				if ((object)instance != null)
				{
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t, instance.IgnoreUnityTimescale);
					DoozySettings instance2 = DoozySettings.Instance;
					if ((object)instance2 != null)
					{
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = instance2.SpeedBasedAnimations;
								}
							}
						}
						Move move2 = animation.Move;
						if (animation.Move != null)
						{
							int num = move2.NumberOfLoops;
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
									if ((nint)0 == 0)
									{
										if (move2.NumberOfLoops >= -1)
										{
											if (num == 0)
											{
												num = 1;
											}
										}
										else
										{
											num = -1;
										}
										_ = move2.LoopType;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
										if ((nint)0 == 0)
										{
											if (num <= -1)
											{
												_ = 2139095040;
											}
											else
											{
												int num2 = num;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
												Vector2 vector = (Vector2)((nint)num2 * (nint)0);
											}
										}
									}
								}
							}
							Move move3 = animation.Move;
							if (animation.Move != null)
							{
								if (move3.EaseType == EaseType.Ease)
								{
									TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)move3.Ease != 0);
									return tweenerCore;
								}
								if (move3.EaseType == EaseType.AnimationCurve)
								{
									Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, move3.AnimationCurve);
								}
								return tweenerCore;
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public static Tween MovePunchTween(RectTransform target, UIAnimation animation)
	{
		if (animation != null)
		{
			Move move = animation.Move;
			if (animation.Move != null)
			{
				Vector2 punch = default(Vector2);
				float elasticity = default(float);
				bool snapping = default(bool);
				Tweener t = DOTweenModuleUI.DOPunchAnchorPos(target, punch, move.Duration, move.Vibrato, elasticity, snapping);
				Move move2 = animation.Move;
				if (animation.Move != null)
				{
					Tweener t2 = TweenSettingsExtensions.SetDelay(t, move2.StartDelay);
					DoozySettings instance = DoozySettings.Instance;
					if ((object)instance != null)
					{
						Tweener tweener = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
						DoozySettings instance2 = DoozySettings.Instance;
						if ((object)instance2 != null)
						{
							if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField && !((Tween)tweener).creationLocked)
							{
								((Tween)tweener).isSpeedBased = instance2.SpeedBasedAnimations;
							}
							return tweener;
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public static Tween MoveStateTween(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		if (animation != null)
		{
			Move move = animation.Move;
			if (animation.Move != null)
			{
				Vector2 endValue = default(Vector2);
				TweenerCore<Vector2, Vector2, VectorOptions> t = DOTweenModuleUI.DOAnchorPos(target, endValue, move.Duration);
				Move move2 = animation.Move;
				if (animation.Move != null)
				{
					TweenerCore<Vector2, Vector2, VectorOptions> t2 = TweenSettingsExtensions.SetDelay(t, move2.StartDelay);
					DoozySettings instance = DoozySettings.Instance;
					if ((object)instance != null)
					{
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
						DoozySettings instance2 = DoozySettings.Instance;
						if ((object)instance2 != null)
						{
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = instance2.SpeedBasedAnimations;
									}
								}
							}
							Move move3 = animation.Move;
							if (animation.Move != null)
							{
								if (move3.EaseType == EaseType.Ease)
								{
									TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)move3.Ease != 0);
									return tweenerCore;
								}
								if (move3.EaseType == EaseType.AnimationCurve)
								{
									Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, move3.AnimationCurve);
								}
								return tweenerCore;
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static Tween RotateTween(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue)
	{
		//IL_005d: Expected O, but got Ref
		//IL_0266->IL0210: Incompatible stack heights: 1 vs 0
		//IL_0039->IL0210: Incompatible stack heights: 1 vs 0
		//IL_008b->IL0210: Incompatible stack heights: 1 vs 0
		//IL_00cc->IL0210: Incompatible stack heights: 1 vs 0
		//IL_010d->IL0210: Incompatible stack heights: 1 vs 0
		//IL_02c4->IL0210: Incompatible stack heights: 1 vs 0
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		if ((object)target != null)
		{
			bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
			if (animation != null)
			{
				Rotate rotate = animation.Rotate;
				if (animation.Rotate != null)
				{
					TweenerCore<Quaternion, Vector3, QuaternionOptions> t = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&euler), rotate.Duration, rotate.RotateMode);
					Rotate rotate2 = animation.Rotate;
					if (animation.Rotate != null)
					{
						TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = TweenSettingsExtensions.SetDelay(t, rotate2.StartDelay);
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
							DoozySettings instance2 = DoozySettings.Instance;
							if ((object)instance2 != null)
							{
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
										if ((nint)0 == 0)
										{
											_ = instance2.SpeedBasedAnimations;
										}
									}
								}
								Rotate rotate3 = animation.Rotate;
								if (animation.Rotate != null)
								{
									if (rotate3.EaseType == EaseType.Ease)
									{
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)rotate3.Ease != 0);
									}
									else if (rotate3.EaseType == EaseType.AnimationCurve)
									{
										Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, rotate3.AnimationCurve);
									}
									return tweenerCore;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static Vector3 RotateLoopRotationA(UIAnimation animation, Vector3 startValue)
	{
		//IL_0070: Expected native int or pointer, but got O
		//IL_007d: Expected native int or pointer, but got O
		if (animation != null)
		{
			Rotate rotate = animation.Rotate;
			if (animation.Rotate != null)
			{
				float num = startValue.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rax_v3 (Doozy.Engine.UI.Animation.Rotate)+38]");
				float z = num - 0f;
				Vector3 vector = default(Vector3);
				float x = default(float);
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 RotateLoopRotationB(UIAnimation animation, Vector3 startValue)
	{
		//IL_0070: Expected native int or pointer, but got O
		//IL_007d: Expected native int or pointer, but got O
		if (animation != null)
		{
			Rotate rotate = animation.Rotate;
			if (animation.Rotate != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rax_v3 (Doozy.Engine.UI.Animation.Rotate)+38]");
				float z = 0f + startValue.z;
				Vector3 vector = default(Vector3);
				float x = default(float);
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Tween RotateLoopTween(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		//IL_0071: Expected O, but got Ref
		//IL_022e: Expected I4, but got I8
		//IL_0270: Expected O, but got I
		if (animation != null)
		{
			Rotate rotate = animation.Rotate;
			if (animation.Rotate != null)
			{
				float num = default(float);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> t = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&num), rotate.Duration, rotate.RotateMode);
				DoozySettings instance = DoozySettings.Instance;
				if ((object)instance != null)
				{
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t, instance.IgnoreUnityTimescale);
					DoozySettings instance2 = DoozySettings.Instance;
					if ((object)instance2 != null)
					{
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = instance2.SpeedBasedAnimations;
								}
							}
						}
						Rotate rotate2 = animation.Rotate;
						if (animation.Rotate != null)
						{
							int num2 = rotate2.NumberOfLoops;
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
									if ((nint)0 == 0)
									{
										if (rotate2.NumberOfLoops >= -1)
										{
											if (num2 == 0)
											{
												num2 = 1;
											}
										}
										else
										{
											num2 = -1;
										}
										_ = rotate2.LoopType;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
										if ((nint)0 == 0)
										{
											if (num2 <= -1)
											{
												_ = 2139095040;
											}
											else
											{
												int num3 = num2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
												object obj = (nint)num3 * (nint)0;
											}
										}
									}
								}
							}
							Rotate rotate3 = animation.Rotate;
							if (animation.Rotate != null)
							{
								if (rotate3.EaseType == EaseType.Ease)
								{
									TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)rotate3.Ease != 0);
									return tweenerCore;
								}
								if (rotate3.EaseType == EaseType.AnimationCurve)
								{
									Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, rotate3.AnimationCurve);
								}
								return tweenerCore;
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static Tween RotatePunchTween(RectTransform target, UIAnimation animation)
	{
		//IL_0057: Expected O, but got Ref
		if (animation != null)
		{
			Rotate rotate = animation.Rotate;
			if (animation.Rotate != null)
			{
				object obj = default(object);
				float elasticity = default(float);
				Tweener t = ShortcutExtensions.DOPunchRotation(target, (Vector3)(&obj), rotate.Duration, rotate.Vibrato, elasticity);
				Rotate rotate2 = animation.Rotate;
				if (animation.Rotate != null)
				{
					Tweener t2 = TweenSettingsExtensions.SetDelay(t, rotate2.StartDelay);
					DoozySettings instance = DoozySettings.Instance;
					if ((object)instance != null)
					{
						Tweener tweener = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
						DoozySettings instance2 = DoozySettings.Instance;
						if ((object)instance2 != null)
						{
							if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField && !((Tween)tweener).creationLocked)
							{
								((Tween)tweener).isSpeedBased = instance2.SpeedBasedAnimations;
							}
							return tweener;
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static Tween RotateStateTween(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		//IL_0054: Expected O, but got Ref
		if (animation != null)
		{
			Rotate rotate = animation.Rotate;
			if (animation.Rotate != null)
			{
				float num = default(float);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> t = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&num), rotate.Duration, rotate.RotateMode);
				Rotate rotate2 = animation.Rotate;
				if (animation.Rotate != null)
				{
					TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = TweenSettingsExtensions.SetDelay(t, rotate2.StartDelay);
					DoozySettings instance = DoozySettings.Instance;
					if ((object)instance != null)
					{
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
						DoozySettings instance2 = DoozySettings.Instance;
						if ((object)instance2 != null)
						{
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = instance2.SpeedBasedAnimations;
									}
								}
							}
							Rotate rotate3 = animation.Rotate;
							if (animation.Rotate != null)
							{
								if (rotate3.EaseType == EaseType.Ease)
								{
									TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)rotate3.Ease != 0);
									return tweenerCore;
								}
								if (rotate3.EaseType == EaseType.AnimationCurve)
								{
									Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, rotate3.AnimationCurve);
								}
								return tweenerCore;
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static Tween ScaleTween(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue)
	{
		//IL_0217: Expected native int or pointer, but got O
		//IL_0225: Expected native int or pointer, but got O
		//IL_0054: Expected O, but got Ref
		//IL_028f->IL0207: Incompatible stack heights: 1 vs 0
		//IL_0039->IL0207: Incompatible stack heights: 1 vs 0
		//IL_0082->IL0207: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL0207: Incompatible stack heights: 1 vs 0
		//IL_0104->IL0207: Incompatible stack heights: 1 vs 0
		//IL_02c3->IL0207: Incompatible stack heights: 1 vs 0
		((Vector3*)(nint)startValue)->z = 1f;
		((Vector3*)(nint)endValue)->z = 1f;
		if ((object)target != null)
		{
			bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_localScale_Injected(((UnityEngine.Object)target).m_CachedPtr, ref *(Vector3*)(&value));
			if (animation != null)
			{
				Scale scale = animation.Scale;
				if (animation.Scale != null)
				{
					object obj = default(object);
					TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, (Vector3)(&obj), scale.Duration);
					Scale scale2 = animation.Scale;
					if (animation.Scale != null)
					{
						TweenerCore<Vector3, Vector3, VectorOptions> t2 = TweenSettingsExtensions.SetDelay(t, scale2.StartDelay);
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
							DoozySettings instance2 = DoozySettings.Instance;
							if ((object)instance2 != null)
							{
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
										if ((nint)0 == 0)
										{
											_ = instance2.SpeedBasedAnimations;
										}
									}
								}
								Scale scale3 = animation.Scale;
								if (animation.Scale != null)
								{
									if (scale3.EaseType == EaseType.Ease)
									{
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)scale3.Ease != 0);
									}
									else if (scale3.EaseType == EaseType.AnimationCurve)
									{
										Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, scale3.AnimationCurve);
									}
									return tweenerCore;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static Tween ScaleLoopTween(RectTransform target, UIAnimation animation)
	{
		//IL_0056: Expected O, but got Ref
		//IL_0213: Expected I4, but got I8
		//IL_0255: Expected O, but got I
		if (animation != null)
		{
			Scale scale = animation.Scale;
			if (animation.Scale != null)
			{
				_ = 1065353216;
				_ = 1065353216;
				object obj = default(object);
				TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, (Vector3)(&obj), scale.Duration);
				DoozySettings instance = DoozySettings.Instance;
				if ((object)instance != null)
				{
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t, instance.IgnoreUnityTimescale);
					DoozySettings instance2 = DoozySettings.Instance;
					if ((object)instance2 != null)
					{
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = instance2.SpeedBasedAnimations;
								}
							}
						}
						Scale scale2 = animation.Scale;
						if (animation.Scale != null)
						{
							int num = scale2.NumberOfLoops;
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
									if ((nint)0 == 0)
									{
										if (scale2.NumberOfLoops >= -1)
										{
											if (num == 0)
											{
												num = 1;
											}
										}
										else
										{
											num = -1;
										}
										_ = scale2.LoopType;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
										if ((nint)0 == 0)
										{
											if (num <= -1)
											{
												_ = 2139095040;
											}
											else
											{
												int num2 = num;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
												Vector3 vector = (Vector3)((nint)num2 * (nint)0);
											}
										}
									}
								}
							}
							Scale scale3 = animation.Scale;
							if (animation.Scale != null)
							{
								if (scale3.EaseType == EaseType.Ease)
								{
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)scale3.Ease != 0);
									return tweenerCore;
								}
								if (scale3.EaseType == EaseType.AnimationCurve)
								{
									Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, scale3.AnimationCurve);
								}
								return tweenerCore;
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static Tween ScalePunchTween(RectTransform target, UIAnimation animation)
	{
		//IL_007f: Expected O, but got Ref
		if (animation != null)
		{
			Scale scale = animation.Scale;
			if (animation.Scale != null)
			{
				_ = 0;
				if (animation.Scale != null)
				{
					object obj = default(object);
					float elasticity = default(float);
					Tweener t = ShortcutExtensions.DOPunchScale(target, (Vector3)(&obj), scale.Duration, scale.Vibrato, elasticity);
					Scale scale2 = animation.Scale;
					if (animation.Scale != null)
					{
						Tweener t2 = TweenSettingsExtensions.SetDelay(t, scale2.StartDelay);
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							Tweener tweener = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
							DoozySettings instance2 = DoozySettings.Instance;
							if ((object)instance2 != null)
							{
								if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField && !((Tween)tweener).creationLocked)
								{
									((Tween)tweener).isSpeedBased = instance2.SpeedBasedAnimations;
								}
								return tweener;
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static Tween ScaleStateTween(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		//IL_0051: Expected O, but got Ref
		if (animation != null)
		{
			Scale scale = animation.Scale;
			if (animation.Scale != null)
			{
				_ = 0;
				float num = default(float);
				TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, (Vector3)(&num), scale.Duration);
				Scale scale2 = animation.Scale;
				if (animation.Scale != null)
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t2 = TweenSettingsExtensions.SetDelay(t, scale2.StartDelay);
					DoozySettings instance = DoozySettings.Instance;
					if ((object)instance != null)
					{
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
						DoozySettings instance2 = DoozySettings.Instance;
						if ((object)instance2 != null)
						{
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = instance2.SpeedBasedAnimations;
									}
								}
							}
							Scale scale3 = animation.Scale;
							if (animation.Scale != null)
							{
								if (scale3.EaseType == EaseType.Ease)
								{
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)scale3.Ease != 0);
									return tweenerCore;
								}
								if (scale3.EaseType == EaseType.AnimationCurve)
								{
									Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, scale3.AnimationCurve);
								}
								return tweenerCore;
							}
						}
					}
				}
			}
		}
		return (Tween)(object)new NullReferenceException();
	}

	public static Tween FadeTween(RectTransform target, UIAnimation animation, float startValue, float endValue)
	{
		//IL_0357: Invalid comparison between I4 and F4
		//IL_0044: Expected F4, but got I4
		//IL_0374: Invalid comparison between I4 and F4
		//IL_0088: Expected F4, but got I4
		float alpha;
		if (!(0f > startValue))
		{
			bool flag = !(startValue > 1f);
			alpha = startValue;
			if (!flag)
			{
				alpha = 1f;
			}
		}
		else
		{
			alpha = 0f;
		}
		float endValue2;
		if (!(0f > endValue))
		{
			bool flag2 = !(endValue > 1f);
			endValue2 = endValue;
			if (!flag2)
			{
				endValue2 = 1f;
			}
		}
		else
		{
			endValue2 = 0f;
		}
		CanvasGroup canvasGroup;
		if ((object)target != null)
		{
			CanvasGroup component = target.GetComponent<CanvasGroup>();
			bool flag3 = (object)component != null;
			canvasGroup = component;
			if (flag3)
			{
				goto IL_011e;
			}
			GameObject gameObject = target.gameObject;
			if ((object)gameObject != null)
			{
				CanvasGroup canvasGroup2 = gameObject.AddComponent<CanvasGroup>();
				bool flag4 = (object)canvasGroup2 == null;
				canvasGroup = canvasGroup2;
				if (!flag4)
				{
					goto IL_011e;
				}
			}
		}
		goto IL_0340;
		IL_0340:
		return (Tween)(object)new NullReferenceException();
		IL_011e:
		canvasGroup.alpha = alpha;
		if (animation != null)
		{
			Fade fade = animation.Fade;
			if (animation.Fade != null)
			{
				TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(canvasGroup, endValue2, fade.Duration);
				Fade fade2 = animation.Fade;
				if (animation.Fade != null)
				{
					TweenerCore<float, float, FloatOptions> t2 = TweenSettingsExtensions.SetDelay(t, fade2.StartDelay);
					DoozySettings instance = DoozySettings.Instance;
					if ((object)instance != null)
					{
						TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
						DoozySettings instance2 = DoozySettings.Instance;
						if ((object)instance2 != null)
						{
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v12 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v12 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = instance2.SpeedBasedAnimations;
									}
								}
							}
							Fade fade3 = animation.Fade;
							if (animation.Fade != null)
							{
								if (fade3.EaseType == EaseType.Ease)
								{
									TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)fade3.Ease != 0);
								}
								else if (fade3.EaseType == EaseType.AnimationCurve)
								{
									Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, fade3.AnimationCurve);
								}
								return tweenerCore;
							}
						}
					}
				}
			}
		}
		goto IL_0340;
	}

	public static Tween FadeLoopTween(RectTransform target, UIAnimation animation)
	{
		//IL_004f: Invalid comparison between I4 and F4
		//IL_009a: Expected F4, but got I4
		//IL_00ba: Invalid comparison between I4 and F4
		//IL_0105: Expected F4, but got I4
		//IL_03a2: Expected I4, but got I8
		if (animation != null)
		{
			Fade fade = animation.Fade;
			if (animation.Fade != null)
			{
				float num = fade.From;
				if (!(0f > fade.From))
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
				fade.From = num;
				if (animation.Fade != null)
				{
					float num2 = fade.To;
					if (!(0f > fade.To))
					{
						if (num2 > 1f)
						{
							num2 = 1f;
						}
					}
					else
					{
						num2 = 0f;
					}
					fade.To = num2;
					if ((object)target != null)
					{
						CanvasGroup component = target.GetComponent<CanvasGroup>();
						CanvasGroup target2;
						if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
						{
							target2 = target.GetComponent<CanvasGroup>();
						}
						else
						{
							GameObject gameObject = target.gameObject;
							if ((object)gameObject == null)
							{
								goto IL_0475;
							}
							target2 = gameObject.AddComponent<CanvasGroup>();
						}
						Fade fade2 = animation.Fade;
						if (animation.Fade != null)
						{
							TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(target2, fade2.To, fade2.Duration);
							DoozySettings instance = DoozySettings.Instance;
							if ((object)instance != null)
							{
								TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t, instance.IgnoreUnityTimescale);
								DoozySettings instance2 = DoozySettings.Instance;
								if ((object)instance2 != null)
								{
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
											if ((nint)0 == 0)
											{
												_ = instance2.SpeedBasedAnimations;
											}
										}
									}
									Fade fade3 = animation.Fade;
									if (animation.Fade != null)
									{
										int num3 = fade3.NumberOfLoops;
										if (tweenerCore != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
												if ((nint)0 == 0)
												{
													if (fade3.NumberOfLoops >= -1)
													{
														if (num3 == 0)
														{
															num3 = 1;
														}
													}
													else
													{
														num3 = -1;
													}
													_ = fade3.LoopType;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
													if ((nint)0 == 0)
													{
														if (num3 <= -1)
														{
															_ = 2139095040;
														}
														else
														{
															float num4 = num3;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
															float num5 = num4 * 0f;
														}
													}
												}
											}
										}
										Fade fade4 = animation.Fade;
										if (animation.Fade != null)
										{
											if (fade4.EaseType == EaseType.Ease)
											{
												TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)fade4.Ease != 0);
												return tweenerCore;
											}
											if (fade4.EaseType == EaseType.AnimationCurve)
											{
												Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, fade4.AnimationCurve);
											}
											return tweenerCore;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0475;
		IL_0475:
		return (Tween)(object)new NullReferenceException();
	}

	public static Tween FadeStateTween(RectTransform target, UIAnimation animation, float startValue)
	{
		//IL_00ff: Invalid comparison between I4 and F4
		//IL_014a: Expected F4, but got I4
		if ((object)target != null)
		{
			CanvasGroup component = target.GetComponent<CanvasGroup>();
			CanvasGroup target2;
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				target2 = target.GetComponent<CanvasGroup>();
			}
			else
			{
				GameObject gameObject = target.gameObject;
				if ((object)gameObject == null)
				{
					goto IL_02cf;
				}
				target2 = gameObject.AddComponent<CanvasGroup>();
			}
			if (animation != null)
			{
				Fade fade = animation.Fade;
				if (animation.Fade != null)
				{
					float num = startValue + fade.By;
					if (!(0f > num))
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
					TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(target2, num, fade.Duration);
					Fade fade2 = animation.Fade;
					if (animation.Fade != null)
					{
						TweenerCore<float, float, FloatOptions> t2 = TweenSettingsExtensions.SetDelay(t, fade2.StartDelay);
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t2, instance.IgnoreUnityTimescale);
							DoozySettings instance2 = DoozySettings.Instance;
							if ((object)instance2 != null)
							{
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
										if ((nint)0 == 0)
										{
											_ = instance2.SpeedBasedAnimations;
										}
									}
								}
								Fade fade3 = animation.Fade;
								if (animation.Fade != null)
								{
									if (fade3.EaseType == EaseType.Ease)
									{
										TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetUpdate(tweenerCore, (byte)fade3.Ease != 0);
									}
									else if (fade3.EaseType == EaseType.AnimationCurve)
									{
										Tween tween = TweenSettingsExtensions.SetEase((Tween)tweenerCore, fade3.AnimationCurve);
									}
									return tweenerCore;
								}
							}
						}
					}
				}
			}
		}
		goto IL_02cf;
		IL_02cf:
		return (Tween)(object)new NullReferenceException();
	}

	public unsafe static void Move(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_0085: Expected O, but got Ref
		//IL_03e0: Expected O, but got Ref
		//IL_03e0: Expected O, but got Ref
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_04c9: Expected O, but got I4
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Expected O, but got Unknown
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass19_0();
		object obj = 6603577472L;
		UnityAction onStartCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onStartCallback = onStartCallback2;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onCompleteCallback = onCompleteCallback2;
		Move move = animation.Move;
		object obj2 = default(object);
		Sequence sequence2;
		TweenCallback onComplete;
		if (!move.Enabled)
		{
			if (obj2 == null)
			{
				return;
			}
		}
		else if (obj2 == null)
		{
			Sequence sequence = DOTween.Sequence();
			string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Move);
			if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				sequence.stringId = tweenId;
			}
			DoozySettings instance = DoozySettings.Instance;
			sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
			DoozySettings instance2 = DoozySettings.Instance;
			TweenCallback onStart;
			if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
			{
				((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
				TweenCallback tweenCallback = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onStart = tweenCallback;
			}
			else
			{
				TweenCallback tweenCallback2 = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				bool flag = sequence2 == null;
				onStart = tweenCallback2;
				if (flag)
				{
					goto IL_0359;
				}
			}
			if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				((ABSSequentiable)sequence2).onStart = onStart;
				if (!flag2)
				{
					object obj3 = sequence2 + 32;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v2+462E0+v762 @ rdx_v21*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v2+462E0+v762 @ rdx_v21*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v2+462E0+v762 @ rdx_v21*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v2+462E0+v762 @ rdx_v21*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v2+462E0+v762 @ rdx_v21*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback3 = delegate
					{
						if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
						{
							UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					};
					onComplete = tweenCallback3;
					goto IL_0397;
				}
			}
			goto IL_0359;
		}
		object obj10 = default(object);
		target.anchoredPosition3D = (Vector3)(&obj10);
		if (CS_0024_003C_003E8__locals14.onStartCallback != null)
		{
			UnityAction onStartCallback3 = CS_0024_003C_003E8__locals14.onStartCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v533.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
		{
			UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals14.onCompleteCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v544.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return;
		IL_0397:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_03cb;
		IL_0359:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_0397;
		}
		goto IL_03cb;
		IL_03cb:
		object obj11 = default(object);
		Tween t = MoveTween(target, animation, (Vector3)(&obj10), (Vector3)(&obj11));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
	}

	public unsafe static void Rotate(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_03a3: Expected O, but got Ref
		//IL_03a3: Expected O, but got Ref
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_0510: Expected O, but got I4
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_0571->IL040c: Incompatible stack heights: 1 vs 0
		//IL_044f->IL040c: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass20_0();
		object obj = 6603577472L;
		UnityAction onStartCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onStartCallback = onStartCallback2;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onCompleteCallback = onCompleteCallback2;
		Rotate rotate = animation.Rotate;
		object obj2 = default(object);
		Sequence sequence2;
		TweenCallback onComplete;
		if (!rotate.Enabled)
		{
			if (obj2 == null)
			{
				return;
			}
		}
		else if (obj2 == null)
		{
			Sequence sequence = DOTween.Sequence();
			string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Rotate);
			if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				sequence.stringId = tweenId;
			}
			DoozySettings instance = DoozySettings.Instance;
			sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
			DoozySettings instance2 = DoozySettings.Instance;
			TweenCallback onStart;
			if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
			{
				((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
				TweenCallback tweenCallback = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onStart = tweenCallback;
			}
			else
			{
				TweenCallback tweenCallback2 = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				bool flag = sequence2 == null;
				onStart = tweenCallback2;
				if (flag)
				{
					goto IL_031c;
				}
			}
			if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				((ABSSequentiable)sequence2).onStart = onStart;
				if (!flag2)
				{
					object obj3 = sequence2 + 32;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v6+462E0+v1071 @ rdx_v28*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v6+462E0+v1071 @ rdx_v28*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v6+462E0+v1071 @ rdx_v28*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v6+462E0+v1071 @ rdx_v28*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v6+462E0+v1071 @ rdx_v28*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback3 = delegate
					{
						if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
						{
							UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					};
					onComplete = tweenCallback3;
					goto IL_035a;
				}
			}
			goto IL_031c;
		}
		object obj10 = default(object);
		float num3 = (float)obj10 * ((float)Math.PI / 180f);
		float num4 = endValue.z * ((float)Math.PI / 180f);
		Vector3 euler = default(Vector3);
		Quaternion ret = default(Quaternion);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret);
		bool flag3 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
		if (CS_0024_003C_003E8__locals14.onStartCallback != null)
		{
			UnityAction onStartCallback3 = CS_0024_003C_003E8__locals14.onStartCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v906.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
		{
			UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals14.onCompleteCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v910.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return;
		IL_035a:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_038e;
		IL_031c:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag4 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag4)
		{
			goto IL_035a;
		}
		goto IL_038e;
		IL_038e:
		Tween t = RotateTween(target, animation, (Vector3)(&euler), (Vector3)(&ret));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
	}

	public unsafe static void Scale(RectTransform target, UIAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_0081: Expected native int or pointer, but got O
		//IL_008f: Expected native int or pointer, but got O
		//IL_0395: Expected O, but got Ref
		//IL_0395: Expected O, but got Ref
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_04f0: Expected O, but got I4
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_0551->IL03fe: Incompatible stack heights: 1 vs 0
		//IL_0441->IL03fe: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass21_0();
		object obj = 6603577472L;
		UnityAction onStartCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onStartCallback = onStartCallback2;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onCompleteCallback = onCompleteCallback2;
		Scale scale = animation.Scale;
		object obj2 = default(object);
		if (!scale.Enabled && obj2 == null)
		{
			return;
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->z = 1f;
		((Vector3*)(nint)endValue)->z = 1f;
		Sequence sequence2;
		TweenCallback onComplete;
		if (obj2 == null)
		{
			Sequence sequence = DOTween.Sequence();
			string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Scale);
			if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				sequence.stringId = tweenId;
			}
			DoozySettings instance = DoozySettings.Instance;
			sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
			DoozySettings instance2 = DoozySettings.Instance;
			TweenCallback onStart;
			if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
			{
				((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
				TweenCallback tweenCallback = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onStart = tweenCallback;
			}
			else
			{
				TweenCallback tweenCallback2 = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				bool flag = sequence2 == null;
				onStart = tweenCallback2;
				if (flag)
				{
					goto IL_030e;
				}
			}
			if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				((ABSSequentiable)sequence2).onStart = onStart;
				if (!flag2)
				{
					object obj3 = sequence2 + 32;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v5+462E0+v917 @ rdx_v30*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v5+462E0+v917 @ rdx_v30*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v5+462E0+v917 @ rdx_v30*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v5+462E0+v917 @ rdx_v30*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r12_v5+462E0+v917 @ rdx_v30*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback3 = delegate
					{
						if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
						{
							UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					};
					onComplete = tweenCallback3;
					goto IL_034c;
				}
			}
			goto IL_030e;
		}
		bool flag3 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_localScale_Injected(((UnityEngine.Object)target).m_CachedPtr, ref *(Vector3*)(&value));
		if (CS_0024_003C_003E8__locals14.onStartCallback != null)
		{
			UnityAction onStartCallback3 = CS_0024_003C_003E8__locals14.onStartCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v752.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
		{
			UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals14.onCompleteCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v756.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return;
		IL_030e:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag4 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag4)
		{
			goto IL_034c;
		}
		goto IL_0380;
		IL_0380:
		object obj10 = default(object);
		Tween t = ScaleTween(target, animation, (Vector3)(&value), (Vector3)(&obj10));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_034c:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_0380;
	}

	public static void Fade(RectTransform target, UIAnimation animation, float startValue, float endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_051a: Expected O, but got I4
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass22_0();
		object obj = 6603577472L;
		UnityAction onStartCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onStartCallback = onStartCallback2;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals14.onCompleteCallback = onCompleteCallback2;
		Fade fade = animation.Fade;
		object obj2 = default(object);
		if (!fade.Enabled && obj2 == null)
		{
			return;
		}
		CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
		if ((object)canvasGroup == null)
		{
			GameObject gameObject = target.gameObject;
			canvasGroup = gameObject.AddComponent<CanvasGroup>();
		}
		Sequence sequence2;
		TweenCallback onComplete;
		if (obj2 == null)
		{
			Sequence sequence = DOTween.Sequence();
			string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Fade);
			if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				sequence.stringId = tweenId;
			}
			DoozySettings instance = DoozySettings.Instance;
			sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
			DoozySettings instance2 = DoozySettings.Instance;
			TweenCallback onStart;
			if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
			{
				((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
				TweenCallback tweenCallback = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onStart = tweenCallback;
			}
			else
			{
				TweenCallback tweenCallback2 = delegate
				{
					if (CS_0024_003C_003E8__locals14.onStartCallback != null)
					{
						UnityAction onStartCallback4 = CS_0024_003C_003E8__locals14.onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				bool flag = sequence2 == null;
				onStart = tweenCallback2;
				if (flag)
				{
					goto IL_0343;
				}
			}
			if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				((ABSSequentiable)sequence2).onStart = onStart;
				if (!flag2)
				{
					object obj3 = sequence2 + 32;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v801 @ rdx_v26*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v801 @ rdx_v26*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v801 @ rdx_v26*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v801 @ rdx_v26*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v801 @ rdx_v26*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback3 = delegate
					{
						if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
						{
							UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					};
					onComplete = tweenCallback3;
					goto IL_0381;
				}
			}
			goto IL_0343;
		}
		canvasGroup.alpha = endValue;
		if (CS_0024_003C_003E8__locals14.onStartCallback != null)
		{
			UnityAction onStartCallback3 = CS_0024_003C_003E8__locals14.onStartCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v578.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
		{
			UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals14.onCompleteCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v593.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return;
		IL_0381:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_03b5;
		IL_03b5:
		Tween t = FadeTween(target, animation, startValue, endValue);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_0343:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals14.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback4 = CS_0024_003C_003E8__locals14.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_0381;
		}
		goto IL_03b5;
	}

	public unsafe static void MoveLoop(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_08b0: Expected O, but got Ref
		//IL_02b4: Expected I4, but got I8
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_0a19: Expected O, but got I4
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2e: Expected O, but got Unknown
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Expected O, but got Unknown
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Expected O, but got Unknown
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Expected O, but got Unknown
		//IL_0a6b: Expected O, but got I4
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a80: Expected O, but got Unknown
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass23_0();
		object obj = 6603577472L;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals17.onCompleteCallback = onCompleteCallback2;
		CS_0024_003C_003E8__locals17.onStartCallback = onStartCallback;
		Move move = animation.Move;
		if (!move.Enabled || animation.AnimationType != AnimationType.Loop)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Move);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
		}
		Vector3 vector = default(Vector3);
		Tween t = MoveLoopTween(target, animation, (Vector3)(&vector));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Move move2 = animation.Move;
		int num = move2.NumberOfLoops;
		TweenCallback onComplete;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			if (move2.NumberOfLoops >= -1)
			{
				if (num == 0)
				{
					num = 1;
				}
			}
			else
			{
				num = -1;
			}
			((Tween)sequence2).loops = num;
			((Tween)sequence2).loopType = move2.LoopType;
			if (((ABSSequentiable)sequence2).tweenType == TweenType.Tweener)
			{
				if (num <= -1)
				{
					((Tween)sequence2).fullDuration = 1f / 0f;
				}
				else
				{
					float fullDuration = (float)num * ((Tween)sequence2).duration;
					((Tween)sequence2).fullDuration = fullDuration;
				}
			}
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onComplete = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onComplete = tweenCallback2;
			if (flag)
			{
				goto IL_041c;
			}
		}
		TweenCallback onKill;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			sequence2.onComplete = onComplete;
			if (!flag2)
			{
				object obj2 = sequence2 + 128;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num3;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1096 @ rdx_v45*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1096 @ rdx_v45*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1096 @ rdx_v45*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1096 @ rdx_v45*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1096 @ rdx_v45*8]");
				}
				while (num3 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onKill = tweenCallback3;
				goto IL_045a;
			}
		}
		goto IL_041c;
		IL_080c:
		TweenCallback tweenCallback4 = delegate
		{
			Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
		};
		Sequence sequence4;
		bool flag3 = sequence4 == null;
		TweenCallback onComplete2 = tweenCallback4;
		if (!flag3)
		{
			goto IL_084a;
		}
		return;
		IL_045a:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onKill = onKill;
		}
		goto IL_048e;
		IL_084a:
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			sequence4.onComplete = onComplete2;
		}
		return;
		IL_041c:
		TweenCallback tweenCallback5 = delegate
		{
			if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag4 = sequence2 == null;
		onKill = tweenCallback5;
		if (!flag4)
		{
			goto IL_045a;
		}
		goto IL_048e;
		IL_048e:
		Sequence loopSequence = TweenExtensions.Pause(sequence2);
		CS_0024_003C_003E8__locals17.loopSequence = loopSequence;
		Move move3 = animation.Move;
		float duration = move3.Duration * 0.5f;
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> t2 = DOTweenModuleUI.DOAnchorPos(target, endValue, duration);
		Move move4 = animation.Move;
		TweenerCore<Vector2, Vector2, VectorOptions> t3 = TweenSettingsExtensions.SetDelay(t2, move4.StartDelay);
		DoozySettings instance3 = DoozySettings.Instance;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t3, instance3.IgnoreUnityTimescale);
		DoozySettings instance4 = DoozySettings.Instance;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1315 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1315 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = instance4.SpeedBasedAnimations;
				}
			}
		}
		TweenerCore<Vector2, Vector2, VectorOptions> t4 = TweenExtensions.Pause(tweenerCore);
		Sequence sequence5 = DOTween.Sequence();
		string tweenId2 = GetTweenId(target, animation.AnimationType, AnimationAction.Move);
		if (sequence5 != null && ((Tween)sequence5)._003Cactive_003Ek__BackingField)
		{
			sequence5.stringId = tweenId2;
		}
		DoozySettings instance5 = DoozySettings.Instance;
		sequence4 = TweenSettingsExtensions.SetUpdate(sequence5, instance5.IgnoreUnityTimescale);
		DoozySettings instance6 = DoozySettings.Instance;
		if (sequence4 != null && ((Tween)sequence4)._003Cactive_003Ek__BackingField && !((Tween)sequence4).creationLocked)
		{
			((Tween)sequence4).isSpeedBased = instance6.SpeedBasedAnimations;
		}
		TweenCallback onStart;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence4, (Tween)t4, false))
		{
			Sequence sequence6 = Sequence.DoInsert(sequence4, (Tween)t4, ((Tween)sequence4).duration);
			TweenCallback tweenCallback6 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback6;
		}
		else
		{
			TweenCallback tweenCallback7 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag5 = sequence4 == null;
			onStart = tweenCallback7;
			if (flag5)
			{
				goto IL_080c;
			}
		}
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag6 = (nint)0 == 0;
			((ABSSequentiable)sequence4).onStart = onStart;
			if (!flag6)
			{
				object obj9 = sequence4 + 32;
				object obj10 = obj9 >> 12;
				object obj11 = obj10 & 0x1FFFFF;
				object obj12 = obj11 >> 6;
				object obj13 = obj11 & 0x3F;
				nint num5;
				do
				{
					object obj14 = 1 << (int)obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1595 @ rdx_v29*8]");
					object obj15 = 0 | obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1595 @ rdx_v29*8]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1595 @ rdx_v29*8]");
					if (num4 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1595 @ rdx_v29*8]");
					num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r15_v2+462E0+v1595 @ rdx_v29*8]");
				}
				while (num5 != 0);
				TweenCallback tweenCallback8 = delegate
				{
					Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
				};
				onComplete2 = tweenCallback8;
				goto IL_084a;
			}
		}
		goto IL_080c;
	}

	public unsafe static void RotateLoop(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_08b5: Expected O, but got Ref
		//IL_04ee: Expected O, but got Ref
		//IL_02b4: Expected I4, but got I8
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_0a1e: Expected O, but got I4
		//IL_0a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a33: Expected O, but got Unknown
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected O, but got Unknown
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected O, but got Unknown
		//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07db: Expected O, but got Unknown
		//IL_0a70: Expected O, but got I4
		//IL_0a80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a85: Expected O, but got Unknown
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass24_0();
		object obj = 6603577472L;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals17.onCompleteCallback = onCompleteCallback2;
		CS_0024_003C_003E8__locals17.onStartCallback = onStartCallback;
		Rotate rotate = animation.Rotate;
		if (!rotate.Enabled || animation.AnimationType != AnimationType.Loop)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Rotate);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
		}
		Vector3 vector = default(Vector3);
		Tween t = RotateLoopTween(target, animation, (Vector3)(&vector));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Rotate rotate2 = animation.Rotate;
		int num = rotate2.NumberOfLoops;
		TweenCallback onComplete;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			if (rotate2.NumberOfLoops >= -1)
			{
				if (num == 0)
				{
					num = 1;
				}
			}
			else
			{
				num = -1;
			}
			((Tween)sequence2).loops = num;
			((Tween)sequence2).loopType = rotate2.LoopType;
			if (((ABSSequentiable)sequence2).tweenType == TweenType.Tweener)
			{
				if (num <= -1)
				{
					((Tween)sequence2).fullDuration = 1f / 0f;
				}
				else
				{
					float fullDuration = (float)num * ((Tween)sequence2).duration;
					((Tween)sequence2).fullDuration = fullDuration;
				}
			}
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onComplete = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onComplete = tweenCallback2;
			if (flag)
			{
				goto IL_041c;
			}
		}
		TweenCallback onKill;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			sequence2.onComplete = onComplete;
			if (!flag2)
			{
				object obj2 = sequence2 + 128;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num3;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1103 @ rdx_v45*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1103 @ rdx_v45*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1103 @ rdx_v45*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1103 @ rdx_v45*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1103 @ rdx_v45*8]");
				}
				while (num3 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onKill = tweenCallback3;
				goto IL_045a;
			}
		}
		goto IL_041c;
		IL_0810:
		TweenCallback tweenCallback4 = delegate
		{
			Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
		};
		Sequence sequence4;
		bool flag3 = sequence4 == null;
		TweenCallback onComplete2 = tweenCallback4;
		if (!flag3)
		{
			goto IL_084e;
		}
		return;
		IL_045a:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onKill = onKill;
		}
		goto IL_048e;
		IL_084e:
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			sequence4.onComplete = onComplete2;
		}
		return;
		IL_041c:
		TweenCallback tweenCallback5 = delegate
		{
			if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals17.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag4 = sequence2 == null;
		onKill = tweenCallback5;
		if (!flag4)
		{
			goto IL_045a;
		}
		goto IL_048e;
		IL_048e:
		Sequence loopSequence = TweenExtensions.Pause(sequence2);
		CS_0024_003C_003E8__locals17.loopSequence = loopSequence;
		Rotate rotate3 = animation.Rotate;
		float duration = rotate3.Duration * 0.5f;
		float num4 = default(float);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&num4), duration, rotate3.RotateMode);
		Rotate rotate4 = animation.Rotate;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t3 = TweenSettingsExtensions.SetDelay(t2, rotate4.StartDelay);
		DoozySettings instance3 = DoozySettings.Instance;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t3, instance3.IgnoreUnityTimescale);
		DoozySettings instance4 = DoozySettings.Instance;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1322 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1322 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = instance4.SpeedBasedAnimations;
				}
			}
		}
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t4 = TweenExtensions.Pause(tweenerCore);
		Sequence sequence5 = DOTween.Sequence();
		string tweenId2 = GetTweenId(target, animation.AnimationType, AnimationAction.Rotate);
		if (sequence5 != null && ((Tween)sequence5)._003Cactive_003Ek__BackingField)
		{
			sequence5.stringId = tweenId2;
		}
		DoozySettings instance5 = DoozySettings.Instance;
		sequence4 = TweenSettingsExtensions.SetUpdate(sequence5, instance5.IgnoreUnityTimescale);
		DoozySettings instance6 = DoozySettings.Instance;
		if (sequence4 != null && ((Tween)sequence4)._003Cactive_003Ek__BackingField && !((Tween)sequence4).creationLocked)
		{
			((Tween)sequence4).isSpeedBased = instance6.SpeedBasedAnimations;
		}
		TweenCallback onStart;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence4, (Tween)t4, false))
		{
			Sequence sequence6 = Sequence.DoInsert(sequence4, (Tween)t4, ((Tween)sequence4).duration);
			TweenCallback tweenCallback6 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback6;
		}
		else
		{
			TweenCallback tweenCallback7 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag5 = sequence4 == null;
			onStart = tweenCallback7;
			if (flag5)
			{
				goto IL_0810;
			}
		}
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag6 = (nint)0 == 0;
			((ABSSequentiable)sequence4).onStart = onStart;
			if (!flag6)
			{
				object obj9 = sequence4 + 32;
				object obj10 = obj9 >> 12;
				object obj11 = obj10 & 0x1FFFFF;
				object obj12 = obj11 >> 6;
				object obj13 = obj11 & 0x3F;
				nint num6;
				do
				{
					object obj14 = 1 << (int)obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1602 @ rdx_v29*8]");
					object obj15 = 0 | obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1602 @ rdx_v29*8]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1602 @ rdx_v29*8]");
					if (num5 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1602 @ rdx_v29*8]");
					num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+462E0+v1602 @ rdx_v29*8]");
				}
				while (num6 != 0);
				TweenCallback tweenCallback8 = delegate
				{
					Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
				};
				onComplete2 = tweenCallback8;
				goto IL_084e;
			}
		}
		goto IL_0810;
	}

	public unsafe static void ScaleLoop(RectTransform target, UIAnimation animation, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_04d9: Expected O, but got Ref
		//IL_02a8: Expected I4, but got I8
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_0a04: Expected O, but got I4
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Expected O, but got Unknown
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_078e: Expected O, but got Unknown
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Expected O, but got Unknown
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Expected O, but got Unknown
		//IL_0a56: Expected O, but got I4
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Expected O, but got Unknown
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass25_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals17.onCompleteCallback = onCompleteCallback;
		CS_0024_003C_003E8__locals17.onStartCallback = onStartCallback;
		Scale scale = animation.Scale;
		if (!scale.Enabled || animation.AnimationType != AnimationType.Loop)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Scale);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
		}
		Tween t = ScaleLoopTween(target, animation);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Scale scale2 = animation.Scale;
		int num = scale2.NumberOfLoops;
		TweenCallback onComplete;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			if (scale2.NumberOfLoops >= -1)
			{
				if (num == 0)
				{
					num = 1;
				}
			}
			else
			{
				num = -1;
			}
			((Tween)sequence2).loops = num;
			((Tween)sequence2).loopType = scale2.LoopType;
			if (((ABSSequentiable)sequence2).tweenType == TweenType.Tweener)
			{
				if (num <= -1)
				{
					((Tween)sequence2).fullDuration = 1f / 0f;
				}
				else
				{
					float fullDuration = (float)num * ((Tween)sequence2).duration;
					((Tween)sequence2).fullDuration = fullDuration;
				}
			}
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onComplete = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onComplete = tweenCallback2;
			if (flag)
			{
				goto IL_0410;
			}
		}
		TweenCallback onKill;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			sequence2.onComplete = onComplete;
			if (!flag2)
			{
				object obj2 = sequence2 + 128;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num3;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1010 @ rdx_v45*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1010 @ rdx_v45*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1010 @ rdx_v45*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1010 @ rdx_v45*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1010 @ rdx_v45*8]");
				}
				while (num3 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onKill = tweenCallback3;
				goto IL_044e;
			}
		}
		goto IL_0410;
		IL_07fb:
		TweenCallback tweenCallback4 = delegate
		{
			Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
		};
		Sequence sequence4;
		bool flag3 = sequence4 == null;
		TweenCallback onComplete2 = tweenCallback4;
		if (!flag3)
		{
			goto IL_0839;
		}
		return;
		IL_044e:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onKill = onKill;
		}
		goto IL_0482;
		IL_0839:
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			sequence4.onComplete = onComplete2;
		}
		return;
		IL_0410:
		TweenCallback tweenCallback5 = delegate
		{
			if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag4 = sequence2 == null;
		onKill = tweenCallback5;
		if (!flag4)
		{
			goto IL_044e;
		}
		goto IL_0482;
		IL_0482:
		Sequence loopSequence = TweenExtensions.Pause(sequence2);
		CS_0024_003C_003E8__locals17.loopSequence = loopSequence;
		Scale scale3 = animation.Scale;
		float duration = scale3.Duration * 0.5f;
		object obj9 = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj9), duration);
		Scale scale4 = animation.Scale;
		TweenerCore<Vector3, Vector3, VectorOptions> t3 = TweenSettingsExtensions.SetDelay(t2, scale4.StartDelay);
		DoozySettings instance3 = DoozySettings.Instance;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t3, instance3.IgnoreUnityTimescale);
		DoozySettings instance4 = DoozySettings.Instance;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = instance4.SpeedBasedAnimations;
				}
			}
		}
		TweenerCore<Vector3, Vector3, VectorOptions> t4 = TweenExtensions.Pause(tweenerCore);
		Sequence sequence5 = DOTween.Sequence();
		string tweenId2 = GetTweenId(target, animation.AnimationType, AnimationAction.Scale);
		if (sequence5 != null && ((Tween)sequence5)._003Cactive_003Ek__BackingField)
		{
			sequence5.stringId = tweenId2;
		}
		DoozySettings instance5 = DoozySettings.Instance;
		sequence4 = TweenSettingsExtensions.SetUpdate(sequence5, instance5.IgnoreUnityTimescale);
		DoozySettings instance6 = DoozySettings.Instance;
		if (sequence4 != null && ((Tween)sequence4)._003Cactive_003Ek__BackingField && !((Tween)sequence4).creationLocked)
		{
			((Tween)sequence4).isSpeedBased = instance6.SpeedBasedAnimations;
		}
		TweenCallback onStart;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence4, (Tween)t4, false))
		{
			Sequence sequence6 = Sequence.DoInsert(sequence4, (Tween)t4, ((Tween)sequence4).duration);
			TweenCallback tweenCallback6 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback6;
		}
		else
		{
			TweenCallback tweenCallback7 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag5 = sequence4 == null;
			onStart = tweenCallback7;
			if (flag5)
			{
				goto IL_07fb;
			}
		}
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag6 = (nint)0 == 0;
			((ABSSequentiable)sequence4).onStart = onStart;
			if (!flag6)
			{
				object obj10 = sequence4 + 32;
				object obj11 = obj10 >> 12;
				object obj12 = obj11 & 0x1FFFFF;
				object obj13 = obj12 >> 6;
				object obj14 = obj12 & 0x3F;
				nint num5;
				do
				{
					object obj15 = 1 << (int)obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1507 @ rdx_v29*8]");
					object obj16 = 0 | obj15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1507 @ rdx_v29*8]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1507 @ rdx_v29*8]");
					if (num4 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1507 @ rdx_v29*8]");
					num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v1507 @ rdx_v29*8]");
				}
				while (num5 != 0);
				TweenCallback tweenCallback8 = delegate
				{
					Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
				};
				onComplete2 = tweenCallback8;
				goto IL_0839;
			}
		}
		goto IL_07fb;
	}

	public static void FadeLoop(RectTransform target, UIAnimation animation, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_001f: Expected O, but got I8
		//IL_0321: Expected I4, but got I8
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_0aa4: Expected O, but got I4
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Expected O, but got Unknown
		//IL_0807: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected O, but got Unknown
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Expected O, but got Unknown
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Expected O, but got Unknown
		//IL_0af6: Expected O, but got I4
		//IL_0b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0b: Expected O, but got Unknown
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals17.onCompleteCallback = onCompleteCallback;
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals17.onStartCallback = onStartCallback;
		Fade fade = animation.Fade;
		if (!fade.Enabled || animation.AnimationType != AnimationType.Loop)
		{
			return;
		}
		CanvasGroup component = target.GetComponent<CanvasGroup>();
		CanvasGroup target2;
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			target2 = target.GetComponent<CanvasGroup>();
		}
		else
		{
			GameObject gameObject = target.gameObject;
			target2 = gameObject.AddComponent<CanvasGroup>();
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Fade);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
		}
		Tween t = FadeLoopTween(target, animation);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Fade fade2 = animation.Fade;
		int num = fade2.NumberOfLoops;
		TweenCallback onComplete;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			if (fade2.NumberOfLoops >= -1)
			{
				if (num == 0)
				{
					num = 1;
				}
			}
			else
			{
				num = -1;
			}
			((Tween)sequence2).loops = num;
			((Tween)sequence2).loopType = fade2.LoopType;
			if (((ABSSequentiable)sequence2).tweenType == TweenType.Tweener)
			{
				if (num <= -1)
				{
					((Tween)sequence2).fullDuration = 1f / 0f;
				}
				else
				{
					float fullDuration = (float)num * ((Tween)sequence2).duration;
					((Tween)sequence2).fullDuration = fullDuration;
				}
			}
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onComplete = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
				{
					UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onComplete = tweenCallback2;
			if (flag)
			{
				goto IL_0489;
			}
		}
		TweenCallback onKill;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			sequence2.onComplete = onComplete;
			if (!flag2)
			{
				object obj2 = sequence2 + 128;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num3;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1174 @ rdx_v46*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1174 @ rdx_v46*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1174 @ rdx_v46*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1174 @ rdx_v46*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1174 @ rdx_v46*8]");
				}
				while (num3 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onKill = tweenCallback3;
				goto IL_04c7;
			}
		}
		goto IL_0489;
		IL_0489:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals17.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback2 = CS_0024_003C_003E8__locals17.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag3 = sequence2 == null;
		onKill = tweenCallback4;
		if (!flag3)
		{
			goto IL_04c7;
		}
		goto IL_04fb;
		IL_08b7:
		Sequence sequence4;
		TweenCallback onComplete2;
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			sequence4.onComplete = onComplete2;
		}
		return;
		IL_0879:
		TweenCallback tweenCallback5 = delegate
		{
			Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
		};
		bool flag4 = sequence4 == null;
		onComplete2 = tweenCallback5;
		if (!flag4)
		{
			goto IL_08b7;
		}
		return;
		IL_04fb:
		Sequence loopSequence = TweenExtensions.Pause(sequence2);
		CS_0024_003C_003E8__locals17.loopSequence = loopSequence;
		Fade fade3 = animation.Fade;
		float duration = fade3.Duration * 0.5f;
		TweenerCore<float, float, FloatOptions> t2 = DOTweenModuleUI.DOFade(target2, fade3.From, duration);
		Fade fade4 = animation.Fade;
		TweenerCore<float, float, FloatOptions> t3 = TweenSettingsExtensions.SetDelay(t2, fade4.StartDelay);
		DoozySettings instance3 = DoozySettings.Instance;
		TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetUpdate(t3, instance3.IgnoreUnityTimescale);
		DoozySettings instance4 = DoozySettings.Instance;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1390 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1390 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = instance4.SpeedBasedAnimations;
				}
			}
		}
		TweenerCore<float, float, FloatOptions> t4 = TweenExtensions.Pause(tweenerCore);
		Sequence sequence5 = DOTween.Sequence();
		string tweenId2 = GetTweenId(target, animation.AnimationType, AnimationAction.Fade);
		if (sequence5 != null && ((Tween)sequence5)._003Cactive_003Ek__BackingField)
		{
			sequence5.stringId = tweenId2;
		}
		DoozySettings instance5 = DoozySettings.Instance;
		sequence4 = TweenSettingsExtensions.SetUpdate(sequence5, instance5.IgnoreUnityTimescale);
		DoozySettings instance6 = DoozySettings.Instance;
		if (sequence4 != null && ((Tween)sequence4)._003Cactive_003Ek__BackingField && !((Tween)sequence4).creationLocked)
		{
			((Tween)sequence4).isSpeedBased = instance6.SpeedBasedAnimations;
		}
		TweenCallback onStart;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence4, (Tween)t4, false))
		{
			Sequence sequence6 = Sequence.DoInsert(sequence4, (Tween)t4, ((Tween)sequence4).duration);
			TweenCallback tweenCallback6 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback6;
		}
		else
		{
			TweenCallback tweenCallback7 = delegate
			{
				if (CS_0024_003C_003E8__locals17.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals17.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag5 = sequence4 == null;
			onStart = tweenCallback7;
			if (flag5)
			{
				goto IL_0879;
			}
		}
		if (((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag6 = (nint)0 == 0;
			((ABSSequentiable)sequence4).onStart = onStart;
			if (!flag6)
			{
				object obj9 = sequence4 + 32;
				object obj10 = obj9 >> 12;
				object obj11 = obj10 & 0x1FFFFF;
				object obj12 = obj11 >> 6;
				object obj13 = obj11 & 0x3F;
				nint num5;
				do
				{
					object obj14 = 1 << (int)obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1670 @ rdx_v30*8]");
					object obj15 = 0 | obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1670 @ rdx_v30*8]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1670 @ rdx_v30*8]");
					if (num4 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1670 @ rdx_v30*8]");
					num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r12_v2+462E0+v1670 @ rdx_v30*8]");
				}
				while (num5 != 0);
				TweenCallback tweenCallback8 = delegate
				{
					Sequence sequence7 = TweenExtensions.Play(CS_0024_003C_003E8__locals17.loopSequence);
				};
				onComplete2 = tweenCallback8;
				goto IL_08b7;
			}
		}
		goto IL_0879;
		IL_04c7:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onKill = onKill;
		}
		goto IL_04fb;
	}

	public static void MovePunch(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_0531: Expected O, but got F4
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_055b: Expected O, but got I4
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass27_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals22.onStartCallback = onStartCallback;
		CS_0024_003C_003E8__locals22.target = target;
		CS_0024_003C_003E8__locals22.startValue = (Vector3)startValue.x;
		_ = startValue.z;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals22.onCompleteCallback = onCompleteCallback2;
		Move move = animation.Move;
		if (!move.Enabled || animation.AnimationType != AnimationType.Punch)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(CS_0024_003C_003E8__locals22.target, animation.AnimationType, AnimationAction.Move);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		TweenCallback onStart;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals22.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals22.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals22.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals22.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onStart = tweenCallback2;
			if (flag)
			{
				goto IL_02dc;
			}
		}
		TweenCallback onComplete;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			((ABSSequentiable)sequence2).onStart = onStart;
			if (!flag2)
			{
				object obj2 = sequence2 + 32;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v835 @ rdx_v23*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v835 @ rdx_v23*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v835 @ rdx_v23*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v835 @ rdx_v23*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v835 @ rdx_v23*8]");
				}
				while (num2 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					Vector2 endValue = default(Vector2);
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(CS_0024_003C_003E8__locals22.target, endValue, 0.05f);
					TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals22._003C_003E9__2;
					if (CS_0024_003C_003E8__locals22._003C_003E9__2 == null)
					{
						tweenCallback5 = (CS_0024_003C_003E8__locals22._003C_003E9__2 = delegate
						{
							if (CS_0024_003C_003E8__locals22.onCompleteCallback != null)
							{
								UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals22.onCompleteCallback;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						});
					}
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
				};
				onComplete = tweenCallback3;
				goto IL_031a;
			}
		}
		goto IL_02dc;
		IL_04de:
		Move move2 = animation.Move;
		Vector2 punch = default(Vector2);
		float elasticity = default(float);
		bool snapping = default(bool);
		Tweener t = DOTweenModuleUI.DOPunchAnchorPos(CS_0024_003C_003E8__locals22.target, punch, move2.Duration, move2.Vibrato, elasticity, snapping);
		Move move3 = animation.Move;
		Tweener t2 = TweenSettingsExtensions.SetDelay(t, move3.StartDelay);
		DoozySettings instance3 = DoozySettings.Instance;
		Tweener tweener = TweenSettingsExtensions.SetUpdate(t2, instance3.IgnoreUnityTimescale);
		DoozySettings instance4 = DoozySettings.Instance;
		if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField && !((Tween)tweener).creationLocked)
		{
			((Tween)tweener).isSpeedBased = instance4.SpeedBasedAnimations;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweener, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweener, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_031a:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_04de;
		IL_02dc:
		TweenCallback tweenCallback4 = delegate
		{
			Vector2 endValue = default(Vector2);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(CS_0024_003C_003E8__locals22.target, endValue, 0.05f);
			TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals22._003C_003E9__2;
			if (CS_0024_003C_003E8__locals22._003C_003E9__2 == null)
			{
				tweenCallback5 = (CS_0024_003C_003E8__locals22._003C_003E9__2 = delegate
				{
					if (CS_0024_003C_003E8__locals22.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals22.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_031a;
		}
		goto IL_04de;
	}

	public unsafe static void RotatePunch(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_052d: Expected O, but got F4
		//IL_037b: Expected O, but got Ref
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_0557: Expected O, but got I4
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass28_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals22.onStartCallback = onStartCallback;
		CS_0024_003C_003E8__locals22.target = target;
		CS_0024_003C_003E8__locals22.startValue = (Vector3)startValue.x;
		_ = startValue.z;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals22.onCompleteCallback = onCompleteCallback2;
		Rotate rotate = animation.Rotate;
		if (!rotate.Enabled || animation.AnimationType != AnimationType.Punch)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(CS_0024_003C_003E8__locals22.target, animation.AnimationType, AnimationAction.Rotate);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		TweenCallback onStart;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals22.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals22.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals22.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals22.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onStart = tweenCallback2;
			if (flag)
			{
				goto IL_02dc;
			}
		}
		TweenCallback onComplete;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			((ABSSequentiable)sequence2).onStart = onStart;
			if (!flag2)
			{
				object obj2 = sequence2 + 32;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v816 @ rdx_v24*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v816 @ rdx_v24*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v816 @ rdx_v24*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v816 @ rdx_v24*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v816 @ rdx_v24*8]");
				}
				while (num2 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					//IL_00a5: Expected O, but got Ref
					object obj10 = default(object);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(CS_0024_003C_003E8__locals22.target, (Vector3)(&obj10), 0.05f);
					TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals22._003C_003E9__2;
					if (CS_0024_003C_003E8__locals22._003C_003E9__2 == null)
					{
						tweenCallback5 = (CS_0024_003C_003E8__locals22._003C_003E9__2 = delegate
						{
							if (CS_0024_003C_003E8__locals22.onCompleteCallback != null)
							{
								UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals22.onCompleteCallback;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						});
					}
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
				};
				onComplete = tweenCallback3;
				goto IL_031a;
			}
		}
		goto IL_02dc;
		IL_04da:
		Rotate rotate2 = animation.Rotate;
		object obj9 = default(object);
		float elasticity = default(float);
		Tweener t = ShortcutExtensions.DOPunchRotation(CS_0024_003C_003E8__locals22.target, (Vector3)(&obj9), rotate2.Duration, rotate2.Vibrato, elasticity);
		Rotate rotate3 = animation.Rotate;
		Tweener t2 = TweenSettingsExtensions.SetDelay(t, rotate3.StartDelay);
		DoozySettings instance3 = DoozySettings.Instance;
		Tweener tweener = TweenSettingsExtensions.SetUpdate(t2, instance3.IgnoreUnityTimescale);
		DoozySettings instance4 = DoozySettings.Instance;
		if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField && !((Tween)tweener).creationLocked)
		{
			((Tween)tweener).isSpeedBased = instance4.SpeedBasedAnimations;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweener, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweener, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_031a:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_04da;
		IL_02dc:
		TweenCallback tweenCallback4 = delegate
		{
			//IL_00a5: Expected O, but got Ref
			object obj10 = default(object);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(CS_0024_003C_003E8__locals22.target, (Vector3)(&obj10), 0.05f);
			TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals22._003C_003E9__2;
			if (CS_0024_003C_003E8__locals22._003C_003E9__2 == null)
			{
				tweenCallback5 = (CS_0024_003C_003E8__locals22._003C_003E9__2 = delegate
				{
					if (CS_0024_003C_003E8__locals22.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals22.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_031a;
		}
		goto IL_04da;
	}

	public unsafe static void ScalePunch(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_0538: Expected O, but got F4
		//IL_0386: Expected O, but got Ref
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_0562: Expected O, but got I4
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected O, but got Unknown
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass29_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals22.onStartCallback = onStartCallback;
		CS_0024_003C_003E8__locals22.target = target;
		CS_0024_003C_003E8__locals22.startValue = (Vector3)startValue.x;
		_ = startValue.z;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals22.onCompleteCallback = onCompleteCallback2;
		Scale scale = animation.Scale;
		if (!scale.Enabled || animation.AnimationType != AnimationType.Punch)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(CS_0024_003C_003E8__locals22.target, animation.AnimationType, AnimationAction.Scale);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		TweenCallback onStart;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals22.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals22.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals22.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals22.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onStart = tweenCallback2;
			if (flag)
			{
				goto IL_02dc;
			}
		}
		TweenCallback onComplete;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			((ABSSequentiable)sequence2).onStart = onStart;
			if (!flag2)
			{
				object obj2 = sequence2 + 32;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v827 @ rdx_v23*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v827 @ rdx_v23*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v827 @ rdx_v23*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v827 @ rdx_v23*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r15_v2+462E0+v827 @ rdx_v23*8]");
				}
				while (num2 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					//IL_00a0: Expected O, but got Ref
					object obj10 = default(object);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals22.target, (Vector3)(&obj10), 0.05f);
					TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals22._003C_003E9__2;
					if (CS_0024_003C_003E8__locals22._003C_003E9__2 == null)
					{
						tweenCallback5 = (CS_0024_003C_003E8__locals22._003C_003E9__2 = delegate
						{
							if (CS_0024_003C_003E8__locals22.onCompleteCallback != null)
							{
								UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals22.onCompleteCallback;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						});
					}
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
				};
				onComplete = tweenCallback3;
				goto IL_031a;
			}
		}
		goto IL_02dc;
		IL_04e5:
		Scale scale2 = animation.Scale;
		_ = 0;
		object obj9 = default(object);
		float elasticity = default(float);
		Tweener t = ShortcutExtensions.DOPunchScale(CS_0024_003C_003E8__locals22.target, (Vector3)(&obj9), scale2.Duration, scale2.Vibrato, elasticity);
		Scale scale3 = animation.Scale;
		Tweener t2 = TweenSettingsExtensions.SetDelay(t, scale3.StartDelay);
		DoozySettings instance3 = DoozySettings.Instance;
		Tweener tweener = TweenSettingsExtensions.SetUpdate(t2, instance3.IgnoreUnityTimescale);
		DoozySettings instance4 = DoozySettings.Instance;
		if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField && !((Tween)tweener).creationLocked)
		{
			((Tween)tweener).isSpeedBased = instance4.SpeedBasedAnimations;
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweener, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweener, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_031a:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_04e5;
		IL_02dc:
		TweenCallback tweenCallback4 = delegate
		{
			//IL_00a0: Expected O, but got Ref
			object obj10 = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals22.target, (Vector3)(&obj10), 0.05f);
			TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals22._003C_003E9__2;
			if (CS_0024_003C_003E8__locals22._003C_003E9__2 == null)
			{
				tweenCallback5 = (CS_0024_003C_003E8__locals22._003C_003E9__2 = delegate
				{
					if (CS_0024_003C_003E8__locals22.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals22.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_031a;
		}
		goto IL_04e5;
	}

	public unsafe static void MoveState(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_035a: Expected O, but got Ref
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_0421: Expected O, but got I4
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass30_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals10.onStartCallback = onStartCallback;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals10.onCompleteCallback = onCompleteCallback2;
		Move move = animation.Move;
		if (!move.Enabled || animation.AnimationType != AnimationType.State)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Move);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		TweenCallback onStart;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onStart = tweenCallback2;
			if (flag)
			{
				goto IL_02d7;
			}
		}
		TweenCallback onComplete;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			((ABSSequentiable)sequence2).onStart = onStart;
			if (!flag2)
			{
				object obj2 = sequence2 + 32;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
				}
				while (num2 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onComplete = tweenCallback3;
				goto IL_0315;
			}
		}
		goto IL_02d7;
		IL_0349:
		object obj9 = default(object);
		Tween t = MoveStateTween(target, animation, (Vector3)(&obj9));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_0315:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_0349;
		IL_02d7:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_0315;
		}
		goto IL_0349;
	}

	public unsafe static void RotateState(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_035a: Expected O, but got Ref
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_0421: Expected O, but got I4
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass31_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals10.onStartCallback = onStartCallback;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals10.onCompleteCallback = onCompleteCallback2;
		Rotate rotate = animation.Rotate;
		if (!rotate.Enabled || animation.AnimationType != AnimationType.State)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Rotate);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		TweenCallback onStart;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onStart = tweenCallback2;
			if (flag)
			{
				goto IL_02d7;
			}
		}
		TweenCallback onComplete;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			((ABSSequentiable)sequence2).onStart = onStart;
			if (!flag2)
			{
				object obj2 = sequence2 + 32;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
				}
				while (num2 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onComplete = tweenCallback3;
				goto IL_0315;
			}
		}
		goto IL_02d7;
		IL_0349:
		object obj9 = default(object);
		Tween t = RotateStateTween(target, animation, (Vector3)(&obj9));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_0315:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_0349;
		IL_02d7:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_0315;
		}
		goto IL_0349;
	}

	public unsafe static void ScaleState(RectTransform target, UIAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_035a: Expected O, but got Ref
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_0421: Expected O, but got I4
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass32_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals10.onStartCallback = onStartCallback;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals10.onCompleteCallback = onCompleteCallback2;
		Scale scale = animation.Scale;
		if (!scale.Enabled || animation.AnimationType != AnimationType.State)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Scale);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		TweenCallback onStart;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onStart = tweenCallback2;
			if (flag)
			{
				goto IL_02d7;
			}
		}
		TweenCallback onComplete;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			((ABSSequentiable)sequence2).onStart = onStart;
			if (!flag2)
			{
				object obj2 = sequence2 + 32;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r12_v2+462E0+v666 @ rdx_v21*8]");
				}
				while (num2 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onComplete = tweenCallback3;
				goto IL_0315;
			}
		}
		goto IL_02d7;
		IL_0349:
		object obj9 = default(object);
		Tween t = ScaleStateTween(target, animation, (Vector3)(&obj9));
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_0315:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_0349;
		IL_02d7:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_0315;
		}
		goto IL_0349;
	}

	public static void FadeState(RectTransform target, UIAnimation animation, float startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0012: Expected O, but got I8
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_0421: Expected O, but got I4
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass33_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals10.onStartCallback = onStartCallback;
		UnityAction onCompleteCallback2 = default(UnityAction);
		CS_0024_003C_003E8__locals10.onCompleteCallback = onCompleteCallback2;
		Fade fade = animation.Fade;
		if (!fade.Enabled || animation.AnimationType != AnimationType.State)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		string tweenId = GetTweenId(target, animation.AnimationType, AnimationAction.Fade);
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.stringId = tweenId;
		}
		DoozySettings instance = DoozySettings.Instance;
		Sequence sequence2 = TweenSettingsExtensions.SetUpdate(sequence, instance.IgnoreUnityTimescale);
		DoozySettings instance2 = DoozySettings.Instance;
		TweenCallback onStart;
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField && !((Tween)sequence2).creationLocked)
		{
			((Tween)sequence2).isSpeedBased = instance2.SpeedBasedAnimations;
			TweenCallback tweenCallback = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			onStart = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback2 = delegate
			{
				if (CS_0024_003C_003E8__locals10.onStartCallback != null)
				{
					UnityAction onStartCallback2 = CS_0024_003C_003E8__locals10.onStartCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			bool flag = sequence2 == null;
			onStart = tweenCallback2;
			if (flag)
			{
				goto IL_02d7;
			}
		}
		TweenCallback onComplete;
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			((ABSSequentiable)sequence2).onStart = onStart;
			if (!flag2)
			{
				object obj2 = sequence2 + 32;
				object obj3 = obj2 >> 12;
				object obj4 = obj3 & 0x1FFFFF;
				object obj5 = obj4 >> 6;
				object obj6 = obj4 & 0x3F;
				nint num2;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r15_v2+462E0+v654 @ rdx_v21*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r15_v2+462E0+v654 @ rdx_v21*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r15_v2+462E0+v654 @ rdx_v21*8]");
					if (num == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r15_v2+462E0+v654 @ rdx_v21*8]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r15_v2+462E0+v654 @ rdx_v21*8]");
				}
				while (num2 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
					{
						UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				onComplete = tweenCallback3;
				goto IL_0315;
			}
		}
		goto IL_02d7;
		IL_0349:
		Tween t = FadeStateTween(target, animation, startValue);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, t, ((Tween)sequence2).duration);
		}
		Sequence sequence4 = TweenExtensions.Play(sequence2);
		return;
		IL_0315:
		if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = onComplete;
		}
		goto IL_0349;
		IL_02d7:
		TweenCallback tweenCallback4 = delegate
		{
			if (CS_0024_003C_003E8__locals10.onCompleteCallback != null)
			{
				UnityAction onCompleteCallback3 = CS_0024_003C_003E8__locals10.onCompleteCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool flag3 = sequence2 == null;
		onComplete = tweenCallback4;
		if (!flag3)
		{
			goto IL_0315;
		}
		goto IL_0349;
	}

	public unsafe static Vector3 GetAnimationMoveFrom(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		//IL_01f3: Expected I, but got O
		//IL_025a: Expected F4, but got I
		//IL_0268: Expected F4, but got O
		//IL_0263: Expected native int or pointer, but got O
		//IL_0230: Expected native int or pointer, but got O
		//IL_01db: Expected native int or pointer, but got O
		//IL_008b: Expected F4, but got I
		//IL_009d: Expected F4, but got O
		//IL_0098: Expected native int or pointer, but got O
		//IL_01aa: Expected F4, but got I
		//IL_01bc: Expected F4, but got O
		//IL_01b7: Expected native int or pointer, but got O
		//IL_00fc: Expected O, but got Ref
		//IL_011a: Expected native int or pointer, but got O
		if (animation != null)
		{
			float z;
			Vector3 vector = default(Vector3);
			if (animation.AnimationType == AnimationType.Show)
			{
				Move move = animation.Move;
				if (animation.Move == null)
				{
					goto IL_01f8;
				}
				if (move.UseCustomFromAndTo)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6 (Doozy.Engine.UI.Animation.Move)+20]");
					z = 0f;
					((Vector3*)(nint)vector)->x = (float)move.From;
				}
				else
				{
					if (animation.Move == null)
					{
						goto IL_01f8;
					}
					if (move.UseCustomFromAndTo)
					{
					}
					object obj = default(object);
					Vector3 toPositionByDirection = GetToPositionByDirection(target, animation, (Vector3)(&obj));
					z = toPositionByDirection.z;
					((Vector3*)(nint)vector)->x = toPositionByDirection.x;
				}
			}
			else if (animation.AnimationType == AnimationType.Hide)
			{
				Move move2 = animation.Move;
				if (animation.Move == null)
				{
					goto IL_01f8;
				}
				if (move2.UseCustomFromAndTo)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v13 (Doozy.Engine.UI.Animation.Move)+20]");
					z = 0f;
					((Vector3*)(nint)vector)->x = (float)move2.From;
				}
				else
				{
					z = startValue.z;
					((Vector3*)(nint)vector)->x = startValue.x;
				}
			}
			else
			{
				nint num = (nint)typeof(UIAnimator);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v8 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v9 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+8]");
				z = 0f;
				((Vector3*)(nint)vector)->x = (float)DEFAULT_START_POSITION;
			}
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		goto IL_01f8;
		IL_01f8:
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetAnimationMoveTo(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		//IL_01f3: Expected I, but got O
		//IL_025a: Expected F4, but got I
		//IL_0268: Expected F4, but got O
		//IL_0263: Expected native int or pointer, but got O
		//IL_022b: Expected native int or pointer, but got O
		//IL_00bc: Expected native int or pointer, but got O
		//IL_008b: Expected F4, but got I
		//IL_009d: Expected F4, but got O
		//IL_0098: Expected native int or pointer, but got O
		//IL_014c: Expected F4, but got I
		//IL_015e: Expected F4, but got O
		//IL_0159: Expected native int or pointer, but got O
		//IL_01bd: Expected O, but got Ref
		//IL_01db: Expected native int or pointer, but got O
		if (animation != null)
		{
			float z;
			Vector3 vector = default(Vector3);
			if (animation.AnimationType == AnimationType.Show)
			{
				Move move = animation.Move;
				if (animation.Move == null)
				{
					goto IL_01f8;
				}
				if (move.UseCustomFromAndTo)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v18 (Doozy.Engine.UI.Animation.Move)+2C]");
					z = 0f;
					((Vector3*)(nint)vector)->x = (float)move.To;
				}
				else
				{
					z = startValue.z;
					((Vector3*)(nint)vector)->x = startValue.x;
				}
			}
			else if (animation.AnimationType == AnimationType.Hide)
			{
				Move move2 = animation.Move;
				if (animation.Move == null)
				{
					goto IL_01f8;
				}
				if (move2.UseCustomFromAndTo)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6 (Doozy.Engine.UI.Animation.Move)+2C]");
					z = 0f;
					((Vector3*)(nint)vector)->x = (float)move2.To;
				}
				else
				{
					if (animation.Move == null)
					{
						goto IL_01f8;
					}
					if (move2.UseCustomFromAndTo)
					{
					}
					object obj = default(object);
					Vector3 toPositionByDirection = GetToPositionByDirection(target, animation, (Vector3)(&obj));
					z = toPositionByDirection.z;
					((Vector3*)(nint)vector)->x = toPositionByDirection.x;
				}
			}
			else
			{
				nint num = (nint)typeof(UIAnimator);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v8 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v9 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+8]");
				z = 0f;
				((Vector3*)(nint)vector)->x = (float)DEFAULT_START_POSITION;
			}
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		goto IL_01f8;
		IL_01f8:
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetAnimationRotateFrom(UIAnimation animation, Vector3 startValue)
	{
		//IL_012b: Expected I, but got O
		//IL_018d: Expected F4, but got I
		//IL_019b: Expected F4, but got O
		//IL_0196: Expected native int or pointer, but got O
		//IL_0163: Expected native int or pointer, but got O
		//IL_0069: Expected F4, but got I
		//IL_007b: Expected F4, but got O
		//IL_0076: Expected native int or pointer, but got O
		//IL_0113: Expected native int or pointer, but got O
		Rotate rotate;
		float z;
		Vector3 vector = default(Vector3);
		if (animation != null)
		{
			if (animation.AnimationType != AnimationType.Show)
			{
				if (animation.AnimationType == AnimationType.Hide)
				{
					rotate = animation.Rotate;
					if (animation.Rotate == null)
					{
						goto IL_0130;
					}
					if (rotate.UseCustomFromAndTo)
					{
						goto IL_0059;
					}
					z = startValue.z;
					((Vector3*)(nint)vector)->x = startValue.x;
				}
				else
				{
					nint num = (nint)typeof(UIAnimator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v8 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v9 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
					z = 0f;
					((Vector3*)(nint)vector)->x = (float)DEFAULT_START_ROTATION;
				}
				goto IL_015b;
			}
			rotate = animation.Rotate;
			if (animation.Rotate != null)
			{
				goto IL_0059;
			}
		}
		goto IL_0130;
		IL_0059:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v15 (Doozy.Engine.UI.Animation.Rotate)+20]");
		z = 0f;
		((Vector3*)(nint)vector)->x = (float)rotate.From;
		goto IL_015b;
		IL_015b:
		((Vector3*)(nint)vector)->z = z;
		return vector;
		IL_0130:
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetAnimationRotateTo(UIAnimation animation, Vector3 startValue)
	{
		//IL_012b: Expected I, but got O
		//IL_018d: Expected F4, but got I
		//IL_019b: Expected F4, but got O
		//IL_0196: Expected native int or pointer, but got O
		//IL_0163: Expected native int or pointer, but got O
		//IL_0106: Expected F4, but got I
		//IL_0118: Expected F4, but got O
		//IL_0113: Expected native int or pointer, but got O
		//IL_0098: Expected native int or pointer, but got O
		if (animation == null)
		{
			goto IL_0130;
		}
		Rotate rotate;
		float z;
		Vector3 vector = default(Vector3);
		if (animation.AnimationType == AnimationType.Show)
		{
			rotate = animation.Rotate;
			if (animation.Rotate == null)
			{
				goto IL_0130;
			}
			if (rotate.UseCustomFromAndTo)
			{
				goto IL_00f6;
			}
			z = startValue.z;
			((Vector3*)(nint)vector)->x = startValue.x;
		}
		else
		{
			if (animation.AnimationType == AnimationType.Hide)
			{
				rotate = animation.Rotate;
				if (animation.Rotate != null)
				{
					goto IL_00f6;
				}
				goto IL_0130;
			}
			nint num = (nint)typeof(UIAnimator);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v10 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v11 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
			z = 0f;
			((Vector3*)(nint)vector)->x = (float)DEFAULT_START_ROTATION;
		}
		goto IL_015b;
		IL_00f6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v7 (Doozy.Engine.UI.Animation.Rotate)+2C]");
		z = 0f;
		((Vector3*)(nint)vector)->x = (float)rotate.To;
		goto IL_015b;
		IL_0130:
		return (Vector3)new NullReferenceException();
		IL_015b:
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public unsafe static Vector3 GetAnimationScaleFrom(UIAnimation animation, Vector3 startValue)
	{
		//IL_015a: Expected F4, but got O
		//IL_0155: Expected native int or pointer, but got O
		//IL_0162: Expected native int or pointer, but got O
		//IL_0170: Expected native int or pointer, but got O
		//IL_0110: Expected O, but got F4
		if (animation != null)
		{
			Vector3 vector;
			float y;
			float num = default(float);
			if (animation.AnimationType == AnimationType.Show)
			{
				Scale scale = animation.Scale;
				if (animation.Scale == null)
				{
					goto IL_0122;
				}
				vector = scale.From;
				y = num;
			}
			else if (animation.AnimationType == AnimationType.Hide)
			{
				Scale scale2 = animation.Scale;
				if (animation.Scale == null)
				{
					goto IL_0122;
				}
				float num2 = default(float);
				if (scale2.UseCustomFromAndTo)
				{
					vector = scale2.From;
					y = num2;
				}
				else
				{
					vector = (Vector3)startValue.x;
					y = num2;
				}
			}
			else
			{
				vector = DEFAULT_START_SCALE;
				y = num;
			}
			Vector3 vector2 = default(Vector3);
			((Vector3*)(nint)vector2)->x = (float)vector;
			((Vector3*)(nint)vector2)->y = y;
			((Vector3*)(nint)vector2)->z = 1f;
			return vector2;
		}
		goto IL_0122;
		IL_0122:
		return (Vector3)new NullReferenceException();
	}

	public unsafe static Vector3 GetAnimationScaleTo(UIAnimation animation, Vector3 startValue)
	{
		//IL_0190: Expected F4, but got O
		//IL_014d: Expected native int or pointer, but got O
		//IL_015a: Expected native int or pointer, but got O
		//IL_0168: Expected native int or pointer, but got O
		//IL_0110: Expected F4, but got O
		//IL_0090: Expected F4, but got O
		if (animation != null)
		{
			float y;
			float x;
			if (animation.AnimationType == AnimationType.Show)
			{
				Scale scale = animation.Scale;
				if (animation.Scale == null)
				{
					goto IL_011a;
				}
				float num = default(float);
				if (scale.UseCustomFromAndTo)
				{
					y = num;
					x = (float)scale.To;
				}
				else
				{
					y = num;
					x = startValue.x;
				}
			}
			else
			{
				float num2;
				if (animation.AnimationType == AnimationType.Hide)
				{
					Scale scale2 = animation.Scale;
					if (animation.Scale == null)
					{
						goto IL_011a;
					}
					num2 = (float)scale2.To;
				}
				else
				{
					num2 = (float)DEFAULT_START_SCALE;
				}
				float num3 = default(float);
				y = num3;
				x = num2;
			}
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->y = y;
			((Vector3*)(nint)vector)->z = 1f;
			return vector;
		}
		goto IL_011a;
		IL_011a:
		return (Vector3)new NullReferenceException();
	}

	public static float GetAnimationFadeFrom(UIAnimation animation, float startValue)
	{
		Fade fade;
		if (animation.AnimationType == AnimationType.Show)
		{
			fade = animation.Fade;
		}
		else
		{
			if (animation.AnimationType != AnimationType.Hide)
			{
				return 1f;
			}
			fade = animation.Fade;
			if (!fade.UseCustomFromAndTo)
			{
				return startValue;
			}
		}
		return fade.From;
	}

	public static float GetAnimationFadeTo(UIAnimation animation, float startValue)
	{
		Fade fade;
		if (animation.AnimationType == AnimationType.Show)
		{
			fade = animation.Fade;
			if (!fade.UseCustomFromAndTo)
			{
				return startValue;
			}
		}
		else
		{
			if (animation.AnimationType != AnimationType.Hide)
			{
				return 1f;
			}
			fade = animation.Fade;
		}
		return fade.To;
	}

	public static Direction ReverseDirection(Direction direction)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (direction <= Direction.CustomPosition)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+2BF991C+direction @ rcx (Doozy.Engine.UI.Animation.Direction)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return Direction.Left;
	}

	public unsafe static Vector3 GetToPositionByDirection(RectTransform target, UIAnimation animation, Vector3 startValue)
	{
		//IL_0256: Expected I, but got O
		//IL_0274: Expected F4, but got O
		//IL_026f: Expected native int or pointer, but got O
		//IL_0102: Expected O, but got I8
		//IL_011c: Expected O, but got I8
		//IL_0243: Expected F4, but got I
		//IL_023e: Expected native int or pointer, but got O
		//IL_0229->IL012b: Incompatible stack heights: 3 vs 0
		//IL_00c1->IL012b: Incompatible stack heights: 3 vs 0
		if ((object)target != null)
		{
			Canvas component = target.GetComponent<Canvas>();
			if ((object)component != null)
			{
				Canvas rootCanvas = component.rootCanvas;
				if ((object)rootCanvas != null)
				{
					RectTransform component2 = rootCanvas.GetComponent<RectTransform>();
					if ((object)component2 != null)
					{
						bool flag = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)component2).m_CachedPtr, out Rect _);
						bool flag2 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)target).m_CachedPtr, out Rect ret2);
						Vector2 pivot = target.pivot;
						bool flag3 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)target).m_CachedPtr, out ret2);
						Vector2 pivot2 = target.pivot;
						object obj = default(object);
						float num = (float)obj * 0.5f;
						object obj3 = default(object);
						object obj4 = default(object);
						object obj2 = obj3 * obj4;
						float num2 = num + (float)obj2;
						if (animation != null)
						{
							Move move = animation.Move;
							if (animation.Move != null)
							{
								Direction direction = move.Direction;
								if (move.Direction <= Direction.CustomPosition)
								{
									object obj5 = 6442450944L;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rdx_v22+2BF9D64+v600 @ rcx_v32 (Doozy.Engine.UI.Animation.Direction)*4]");
									object obj6 = 0 + 6442450944L;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v436 @ rcx_v36 (should have been resolved before IL gen)");
								}
								nint num3 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num4 = 0;
								Vector3 vector = default(Vector3);
								((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rax_v39 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								((Vector3*)(nint)vector)->z = 0f;
								return vector;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static string GetTweenId(RectTransform target, AnimationType animationType, AnimationAction animationAction)
	{
		//IL_002a: Expected O, but got Ref
		//IL_006d: Expected O, but got Ref
		//IL_0093: Expected O, but got Ref
		string[] array = new string[5];
		if ((object)target != null)
		{
			int instanceID = target.GetInstanceID();
			IntPtr intPtr = default(IntPtr);
			string text = System.Number.FormatInt32(instanceID, (ReadOnlySpan<char>)(&intPtr), null);
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text2 = ((Enum)(&intPtr)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text3 = ((Enum)(&intPtr)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				return string.Concat(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public static void ResetCanvasGroup(RectTransform target, bool interactable = true, bool blocksRaycasts = true)
	{
		if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0)
		{
			CanvasGroup component = target.GetComponent<CanvasGroup>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				component.interactable = interactable;
				component.blocksRaycasts = blocksRaycasts;
			}
		}
	}

	public static void StopAnimations(RectTransform target, AnimationType animationType, bool complete = true)
	{
		if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0)
		{
			string tweenId = GetTweenId(target, animationType, AnimationAction.Move);
			int num = DOTween.Kill(tweenId, complete);
			string tweenId2 = GetTweenId(target, animationType, AnimationAction.Rotate);
			int num2 = DOTween.Kill(tweenId2, complete);
			string tweenId3 = GetTweenId(target, animationType, AnimationAction.Scale);
			int num3 = DOTween.Kill(tweenId3, complete);
			string tweenId4 = GetTweenId(target, animationType, AnimationAction.Fade);
			int num4 = DOTween.Kill(tweenId4, complete);
		}
	}

	private static void SetEase(Tween tween, Move move)
	{
		if (move.EaseType == EaseType.Ease)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
		}
		else if (move.EaseType == EaseType.AnimationCurve)
		{
			Tween tween2 = TweenSettingsExtensions.SetEase(tween, move.AnimationCurve);
		}
	}

	private static void SetEase(Tween tween, Rotate rotate)
	{
		if (rotate.EaseType == EaseType.Ease)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
		}
		else if (rotate.EaseType == EaseType.AnimationCurve)
		{
			Tween tween2 = TweenSettingsExtensions.SetEase(tween, rotate.AnimationCurve);
		}
	}

	private static void SetEase(Tween tween, Scale scale)
	{
		if (scale.EaseType == EaseType.Ease)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
		}
		else if (scale.EaseType == EaseType.AnimationCurve)
		{
			Tween tween2 = TweenSettingsExtensions.SetEase(tween, scale.AnimationCurve);
		}
	}

	private static void SetEase(Tween tween, Fade fade)
	{
		if (fade.EaseType == EaseType.Ease)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
		}
		else if (fade.EaseType == EaseType.AnimationCurve)
		{
			Tween tween2 = TweenSettingsExtensions.SetEase(tween, fade.AnimationCurve);
		}
	}

	static UIAnimator()
	{
		//IL_0070: Expected I, but got O
		//IL_008e: Expected I, but got O
		//IL_0018: Expected I, but got O
		//IL_0036: Expected I, but got O
		//IL_00c8: Expected I, but got O
		//IL_00e6: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		nint num3 = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num4 = 0;
		DEFAULT_START_POSITION = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		nint num7 = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v7 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num8 = 0;
		DEFAULT_START_ROTATION = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		nint num11 = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v10 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num12 = 0;
		DEFAULT_START_SCALE = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
	}
}
