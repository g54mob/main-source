using System;
using DG.Tweening;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("System/TimeScale", 50, false, false)]
	public class TimeScaleNode : Node
	{
		private const float DEFAULT_TARGET_VALUE = 1f;

		private const bool DEFAULT_ANIMATE_VALUE = false;

		private const float DEFAULT_ANIMATION_DURATION = 1f;

		private const Ease DEFAULT_ANIMATION_EASE = Ease.Linear;

		private const bool DEFAULT_WAIT_FOR_ANIMATION_TO_FINISH = false;

		public float TargetValue;

		public bool AnimateValue;

		public float AnimationDuration;

		public Ease AnimationEase;

		public bool WaitForAnimationToFinish;

		[NonSerialized]
		private Sequence m_animationSequence;

		[NonSerialized]
		private bool m_timerIsActive;

		[NonSerialized]
		private double m_timerStart;

		[NonSerialized]
		private float m_timeDuration;

		private string GetAnimationId => null;

		public float TimerProgress => 0f;

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void OnUpdate()
		{
		}

		private void ContinueToNextNode()
		{
		}

		private void ExecuteActions()
		{
		}

		private void ActivateTimer()
		{
		}

		private void StopTimer()
		{
		}

		private void KillAnimation(bool complete = false)
		{
		}

		private static Tween GetAnimationTween(float targetValue, float duration, Ease ease, string id)
		{
			return null;
		}
	}
}
