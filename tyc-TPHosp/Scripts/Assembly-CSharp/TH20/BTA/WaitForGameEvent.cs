using System;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	[TaskCategory(" TH20/Level Script")]
	public class WaitForGameEvent : ExpiringLevelAction
	{
		public ObjectiveGameEvent _gameEvent;

		private bool _eventFired;

		public override void OnStart()
		{
			base.OnStart();
			if (!HasTaskExpired())
			{
				_eventFired = false;
				ObjectiveEvents objectiveEvents = base.Owner.Level.ObjectiveEvents;
				objectiveEvents.OnGameEvent = (Action<ObjectiveGameEvent>)Delegate.Combine(objectiveEvents.OnGameEvent, new Action<ObjectiveGameEvent>(OnGameEvent));
			}
		}

		public override void OnEnd()
		{
			ObjectiveEvents objectiveEvents = base.Owner.Level.ObjectiveEvents;
			objectiveEvents.OnGameEvent = (Action<ObjectiveGameEvent>)Delegate.Remove(objectiveEvents.OnGameEvent, new Action<ObjectiveGameEvent>(OnGameEvent));
			HasTaskExpired();
			base.OnEnd();
		}

		private void OnGameEvent(ObjectiveGameEvent gameEvent)
		{
			if (gameEvent == _gameEvent)
			{
				_eventFired = true;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			if (!_eventFired)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
