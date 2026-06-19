using UnityEngine;

namespace TH20
{
	public abstract class ObjectiveSubGoal : MustCallDestroy
	{
		public float HiScoreWeight = 1f;

		[SerializeField]
		private bool _previouslyCompleted;

		[SerializeField]
		protected Objective Owner;

		[SerializeField]
		public SubGoalDefinition Definition { get; private set; }

		protected abstract bool HasCompleted();

		public abstract float PercentComplete();

		public abstract int Score();

		public abstract string ProgressText();

		public virtual void OnUpdate(float timeDelta, float unscaledTimeDelta)
		{
		}

		public virtual bool Failed()
		{
			return false;
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnEnd()
		{
		}

		public virtual bool IsDefinitionValid()
		{
			return true;
		}

		protected ObjectiveSubGoal(Objective objective, SubGoalDefinition definition)
		{
			Owner = objective;
			Definition = definition;
		}

		public void Start()
		{
			OnStart();
			UpdateProgress();
		}

		public void End()
		{
			OnEnd();
		}

		public override void Destroy()
		{
			if (Owner != null && Owner.State == Objective.ObjectiveState.Active)
			{
				OnEnd();
			}
			base.Destroy();
		}

		public Objective GetOwnerObjective()
		{
			return Owner;
		}

		protected bool ShouldUpdate()
		{
			bool result = false;
			if (!Definition.OnceCompleteStayComplete || !Completed())
			{
				result = true;
			}
			return result;
		}

		protected void UpdateProgress()
		{
			Owner.ReportSubGoalProgress(this);
			if (!_previouslyCompleted && Completed())
			{
				_previouslyCompleted = true;
				Owner.ReportSubGoalCompleted(this);
			}
		}

		public bool Completed()
		{
			if (!Owner.CanComplete())
			{
				return false;
			}
			return HasCompleted();
		}
	}
}
