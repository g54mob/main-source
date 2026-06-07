namespace Gh.Tk
{
	public abstract class ActorJob : Job
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public ActorBehaviour Behaviour;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string UsageKey;

		public new Actor Owner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ActorJob()
		{
		}

		protected ActorJob(GameObjectX source, GameObjectX target = null, ActorBehaviour behaviour = null, string usageKeyOverride = null, int priority = 0)
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		public void MarkBehaviourAsDone()
		{
		}

		internal override void ForceCompleteReset(bool removeOwner = true, bool forceDestroy = false)
		{
		}

		public override void Abort(bool destroy = false)
		{
		}
	}
}
