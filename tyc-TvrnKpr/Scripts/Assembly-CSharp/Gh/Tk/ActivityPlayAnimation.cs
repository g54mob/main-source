using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class ActivityPlayAnimation : Activity
	{
		private string _animation;

		private readonly IEnumerable<string> _animations;

		private readonly GameObjectX _target;

		private readonly bool _autoStop;

		private float _lastTick;

		private bool _animationHasDuration;

		private bool _stoppedAlready;

		private GlobalTimeController _tc;

		private readonly GameItem _item;

		private GameItemVisual _itemVisual;

		private bool _needsFinishedEvent;

		private readonly Action<Activity> _propOnFireInterruptAction;

		private bool _propOnFireInterruptActionCalled;

		private readonly Action _firstTimeInitAction;

		public Action TickCallback;

		private float _waitTimeForFinishedEvent;

		private bool _wasInIdleLastFrame;

		private readonly float _maxTime;

		private float _maxEndTime;

		public Action<object, AnimationEventArgs> AnimEvent;

		public GameItem GetTargetItem()
		{
			return null;
		}

		private ActivityPlayAnimation(GameObjectX target, bool autoStop)
		{
		}

		public ActivityPlayAnimation(IEnumerable<string> animations, GameObjectX target = null, bool autoStop = true, GameItem item = null, Action initAction = null, Action finishAction = null, Action<Activity> propOnFireInterruptAction = null, Action firstTimeInitAction = null, float maxTime = -1f)
		{
		}

		public override void Init()
		{
		}

		private void Initialize()
		{
		}

		private float GetLastTick(string animation)
		{
			return 0f;
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}

		public void ForceFinish()
		{
		}

		public override void Finish()
		{
		}

		public override string GetLogInfo()
		{
			return null;
		}

		private void RemoveAnimationListener()
		{
		}

		private void StopAnimation()
		{
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void SetBoolOnTarget(object sender, AnimationEventArgs e)
		{
		}
	}
}
