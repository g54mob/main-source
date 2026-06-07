using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gh.Tk
{
	public abstract class ActorBehaviour : AiComponent
	{
		private Dictionary<ActorStat, Func<bool>> _thresholds;

		private static float _maxGroupFavorDistanceSquared;

		[PersistenceOptIn]
		public bool canAbortJobs;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Actor Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[PersistenceOptIn]
		[DefaultValue(0)]
		public int Priority { get; set; }

		[PersistenceOptIn]
		private float CooldownEndTime { get; set; }

		public bool IsOnCooldown => false;

		protected ActorBehaviour()
		{
		}

		public ActorBehaviour(Actor owner, string name, int priority = 0)
		{
		}

		protected override int GetDefaultExecutionOrder()
		{
			return 0;
		}

		public virtual bool IsActive()
		{
			return false;
		}

		public void SetCooldown(float duration)
		{
		}

		protected void SetThreshold<T>(float threshold) where T : ActorStat
		{
		}

		public virtual bool IsTreshholdReached()
		{
			return false;
		}

		public override void Update()
		{
		}

		public bool TryTrigger()
		{
			return false;
		}

		protected abstract bool TriggerInternal();

		public Prop GetBestPropForBehaviour(Func<Prop, bool> propFilter = null, bool ignoreQueues = false)
		{
			return null;
		}

		public virtual string GetBehaviourFilterString()
		{
			return null;
		}

		public virtual void Reset()
		{
		}
	}
}
