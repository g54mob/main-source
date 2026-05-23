using UnityEngine;

namespace MoreMountains.Tools
{
	public abstract class AIAction : MonoBehaviour
	{
		public enum InitializationModes
		{
			EveryTime = 0,
			OnlyOnce = 1
		}

		public InitializationModes InitializationMode;

		protected bool _initialized;

		public string Label;

		protected AIBrain _brain;

		public bool ActionInProgress { get; set; }

		protected virtual bool ShouldInitialize => InitializationMode switch
		{
			InitializationModes.EveryTime => true, 
			InitializationModes.OnlyOnce => !_initialized, 
			_ => true, 
		};

		public abstract void PerformAction();

		protected virtual void Awake()
		{
			_brain = base.gameObject.GetComponentInParent<AIBrain>();
		}

		public virtual void Initialization()
		{
			_initialized = true;
		}

		public virtual void OnEnterState()
		{
			ActionInProgress = true;
		}

		public virtual void OnExitState()
		{
			ActionInProgress = false;
		}
	}
}
