using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes;

public class TimeScaleNode : Node
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static DOGetter<float> _003C_003E9__28_0;

		public static DOSetter<float> _003C_003E9__28_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CGetAnimationTween_003Eb__28_0()
		{
			//IL_0006: Expected O, but got I
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ rax_v2 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
			/*Error: End of method reached without returning.*/;
		}

		internal void _003CGetAnimationTween_003Eb__28_1(float x)
		{
			//IL_0006: Expected O, but got I
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v46 @ rax_v2 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-38), the output could be wrong!");
			/*Error: End of method reached without returning.*/;
		}
	}

	private const float DEFAULT_TARGET_VALUE = 1f;

	private const bool DEFAULT_ANIMATE_VALUE = false;

	private const float DEFAULT_ANIMATION_DURATION = 1f;

	private const Ease DEFAULT_ANIMATION_EASE = Ease.Linear;

	private const bool DEFAULT_WAIT_FOR_ANIMATION_TO_FINISH = false;

	public float TargetValue = 1f;

	public bool AnimateValue;

	public float AnimationDuration = 1f;

	public Ease AnimationEase = Ease.Linear;

	public bool WaitForAnimationToFinish;

	[NonSerialized]
	private Sequence m_animationSequence;

	[NonSerialized]
	private bool m_timerIsActive;

	[NonSerialized]
	private double m_timerStart;

	[NonSerialized]
	private float m_timeDuration;

	private string GetAnimationId
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980821]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TimeScale Animation";
		}
	}

	public float TimerProgress
	{
		get
		{
			//IL_002d: Expected F4, but got I4
			//IL_00a8: Invalid comparison between I4 and F4
			//IL_0061: Expected F4, but got I4
			//IL_006f: Expected O, but got F4
			float num;
			if (!m_timerIsActive)
			{
				num = 0f;
			}
			else
			{
				object obj = Time.realtimeSinceStartup;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rbx+0A8h]\"");
				num = 0f / m_timeDuration;
			}
			if (!(0f > num))
			{
				if (num > 1f)
				{
					return 1f;
				}
			}
			else
			{
				num = 0f;
			}
			return num;
		}
	}

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.TimeScaleNodeName;
		base.m_allowDuplicateNodeName = true;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddInputSocket(ConnectionMode.Multiple, valueType, canBeDeleted: false, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType2 = default(Type);
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: false, canBeReordered);
	}

	public override void CopyNode(Node original)
	{
		//IL_00f9: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0098: Expected F4, but got I
		//IL_00bc: Expected F4, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(TimeScaleNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.TimeScaleNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.TimeScaleNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(TimeScaleNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				TargetValue = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+84]");
				AnimateValue = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+88]");
				AnimationDuration = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+8C]");
				AnimationEase = Ease.Unset;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
				WaitForAnimationToFinish = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980821]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			int num = DOTween.Kill("TimeScale Animation", complete: true);
			ExecuteActions();
		}
	}

	public override void OnUpdate()
	{
		//IL_0087: Expected O, but got F4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_002d: Invalid comparison between O and F4
		//IL_00d1: Expected O, but got F4
		//IL_004a: Invalid comparison between F4 and O
		if (!m_timerIsActive)
		{
			return;
		}
		object obj = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rbx+0A8h]\"");
		object obj2 = 0 / m_timeDuration;
		if (0 > (nint)obj2)
		{
			return;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				return;
			}
		}
		m_timerIsActive = false;
		object obj3 = Time.realtimeSinceStartup;
		bool flag = !WaitForAnimationToFinish;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_timerStart = 0.0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 140 Invalid \"Jump target not found in method: 0x182BD7B00\"");
		}
	}

	private void ContinueToNextNode()
	{
		Socket firstOutputSocket = base.FirstOutputSocket;
		List<Connection> connections = firstOutputSocket.m_connections;
		if (connections._size > 0)
		{
			Socket firstOutputSocket2 = base.FirstOutputSocket;
			Connection firstConnection = firstOutputSocket2.FirstConnection;
			Node nodeById = base.m_activeGraph.GetNodeById(firstConnection.m_inputNodeId);
			base.m_activeGraph.SetActiveNode(nodeById, firstConnection);
		}
	}

	private void ExecuteActions()
	{
		//IL_0487: Invalid comparison between I4 and F4
		//IL_0675: Expected F4, but got O
		//IL_0085: Invalid comparison between I4 and F4
		//IL_04a4: Expected O, but got F4
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00d1: Invalid comparison between F4 and O
		//IL_061a: Expected O, but got F4
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		bool flag = !AnimateValue;
		TimeScaleNode timeScaleNode = this;
		if (!flag)
		{
			bool flag2 = m_animationSequence == null;
			timeScaleNode = this;
			if (!flag2)
			{
				TweenExtensions.Kill(m_animationSequence, complete: true);
				m_animationSequence = null;
				timeScaleNode = (TimeScaleNode)(object)m_animationSequence;
				m_timerIsActive = false;
				base.m_useUpdate = false;
			}
		}
		if (!(0f < AnimationDuration))
		{
			AnimationDuration = 0f;
		}
		Sequence animationSequence;
		Tween t;
		object message;
		float num3;
		if (AnimateValue && 0f < AnimationDuration)
		{
			object obj = Time.timeScale;
			float num = 0f - TargetValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj2 = num & 0;
			bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
			timeScaleNode = (TimeScaleNode)(object)typeof(Math);
			if (!flag3)
			{
				animationSequence = m_animationSequence;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980821]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Tween animationTween = GetAnimationTween(TargetValue, AnimationDuration, AnimationEase, "TimeScale Animation");
				if (m_animationSequence != null)
				{
					if (((Tween)animationSequence)._003Cactive_003Ek__BackingField)
					{
						if (!((Tween)animationSequence).creationLocked)
						{
							if (animationTween != null)
							{
								if (animationTween._003Cactive_003Ek__BackingField)
								{
									if (!animationTween.isSequenced)
									{
										DG.Tweening.Core.TweenManager.RemoveActiveTween(animationTween);
										float num2 = (animationSequence.lastTweenInsertTime = ((Tween)animationSequence).duration + animationTween.delay);
										animationTween.creationLocked = true;
										animationTween.isSequenced = true;
										animationTween.sequenceParent = m_animationSequence;
										if (animationTween.loops == -1)
										{
											animationTween.loops = 1;
										}
										animationTween.isSpeedBased = false;
										animationTween.elapsedDelay = 0f;
										animationTween.delay = 0f;
										animationTween.delayComplete = true;
										((ABSSequentiable)animationTween).sequencedPosition = num2;
										object obj3 = animationTween.loops * animationTween.duration;
										num3 = (((ABSSequentiable)animationTween).sequencedEndPosition = (float)obj3 + num2);
										if (num3 > ((Tween)animationSequence).duration)
										{
											((Tween)animationSequence).duration = num3;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF30");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
										goto IL_03a8;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DC0]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									t = animationTween;
									message = "You can't add a tween that is already nested into a Sequence to another Sequence";
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBF]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									t = animationTween;
									message = "You can't add an inactive/killed tween to a Sequence";
								}
								goto IL_06a0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBE]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							message = "You can't add a NULL tween to a Sequence";
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						message = "You can't add elements to an inactive/killed Sequence";
					}
					t = null;
					goto IL_06a0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Debugger.LogWarning("You can't add elements to a NULL Sequence");
				TweenCallback tweenCallback = StopTimer;
				num3 = TargetValue;
				goto IL_0429;
			}
		}
		Time.timeScale = (float)timeScaleNode;
		ContinueToNextNode();
		return;
		IL_0429:
		Sequence sequence = TweenExtensions.Play(m_animationSequence);
		m_timerIsActive = true;
		object obj4 = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_timeDuration = AnimationDuration;
		base.m_useUpdate = true;
		m_timerStart = 0.0;
		if (!WaitForAnimationToFinish)
		{
			ContinueToNextNode();
		}
		return;
		IL_03a8:
		TweenCallback onComplete = StopTimer;
		if (((Tween)animationSequence)._003Cactive_003Ek__BackingField)
		{
			animationSequence.onComplete = onComplete;
		}
		goto IL_0429;
		IL_06a0:
		Debugger.LogWarning(message, t);
		num3 = TargetValue;
		goto IL_03a8;
	}

	private void ActivateTimer()
	{
		//IL_0019: Expected O, but got F4
		m_timerIsActive = true;
		object obj = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_timeDuration = AnimationDuration;
		base.m_useUpdate = true;
		m_timerStart = 0.0;
	}

	private void StopTimer()
	{
		m_timerIsActive = false;
		base.m_useUpdate = false;
	}

	private void KillAnimation(bool complete = false)
	{
		if (m_animationSequence != null)
		{
			TweenExtensions.Kill(m_animationSequence, complete);
			m_animationSequence = null;
			m_timerIsActive = false;
			base.m_useUpdate = false;
		}
	}

	private static Tween GetAnimationTween(float targetValue, float duration, Ease ease, string id)
	{
		//IL_008a: Expected O, but got I4
		DOGetter<float> getter = _003C_003Ec._003C_003E9__28_0;
		if (_003C_003Ec._003C_003E9__28_0 == null)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__28_0 = dOGetter;
			getter = dOGetter;
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__28_1;
		if (_003C_003Ec._003C_003E9__28_1 == null)
		{
			DOSetter<float> dOSetter = null;
			((_003C_003Ec)(object)dOSetter)._003CGetAnimationTween_003Eb__28_1(duration);
			_003C_003Ec._003C_003E9__28_1 = dOSetter;
			setter = dOSetter;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, targetValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				object obj = ease - 32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		return TweenSettingsExtensions.SetUpdate(tweenerCore, isIndependentUpdate: true);
	}
}
