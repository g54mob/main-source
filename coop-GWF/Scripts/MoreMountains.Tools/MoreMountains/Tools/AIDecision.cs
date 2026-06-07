using UnityEngine;

namespace MoreMountains.Tools
{
	public abstract class AIDecision : MonoBehaviour
	{
		[Tooltip("a label you can set to organize your AI Decisions, not used by anything else")]
		public string Label;

		protected AIBrain _brain;

		public virtual bool DecisionInProgress { get; set; }

		public abstract bool Decide();

		protected virtual void Awake()
		{
			_brain = base.gameObject.GetComponentInParent<AIBrain>();
		}

		public virtual void Initialization()
		{
		}

		public virtual void OnEnterState()
		{
			DecisionInProgress = true;
		}

		public virtual void OnExitState()
		{
			DecisionInProgress = false;
		}
	}
}
