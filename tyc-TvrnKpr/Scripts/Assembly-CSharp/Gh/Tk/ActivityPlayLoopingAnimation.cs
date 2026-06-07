using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class ActivityPlayLoopingAnimation : ActivityWait
	{
		private string _animation;

		private IEnumerable<string> _animations;

		private IEnumerable<string> _breakAnimations;

		private float _minBreak;

		private float _maxBreak;

		private GameObjectX _target;

		private bool _paused;

		private string _usage;

		private bool _durationDone;

		private bool _handledFinishedEvent;

		private bool _needsFinishedEvent;

		private float _secondsUntilNextBreak;

		private bool _usesBreaks;

		private Func<bool> _condition;

		private bool _isStopping;

		private float _stoppingTime;

		private GameItem _item;

		private GameItemVisual _itemVisual;

		private float _maxStoppingTime;

		public ActivityPlayLoopingAnimation(IEnumerable<string> animations, float duration, GameObjectX target = null, GameItem item = null, Action<int> progressCallback = null, Func<bool> condition = null, Action finishAction = null, Action tickCallback = null)
			: base(0.0)
		{
		}

		public override void Init()
		{
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		protected override void ChangeSeconds(float delta)
		{
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}

		private void StartAnimation()
		{
		}

		private void MaintenanceNecessaryChanged(object sender, EventArgs<Prop> e)
		{
		}

		public override void Finish()
		{
		}

		private void StopAnimation()
		{
		}

		private void SetBoolOnTarget(object sender, AnimationEventArgs e)
		{
		}

		public override string GetLogInfo()
		{
			return null;
		}
	}
}
