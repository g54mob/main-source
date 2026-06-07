using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	public abstract class CharacterState : MonoBehaviour, IUpdatable
	{
		[SerializeField]
		private bool overrideAnimatorController = true;

		[Condition("overrideAnimatorController", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private RuntimeAnimatorController runtimeAnimatorController;

		private CharacterBrain CharacterBrain;

		public int StateNameHash { get; private set; }

		public RuntimeAnimatorController RuntimeAnimatorController => runtimeAnimatorController;

		public bool OverrideAnimatorController => overrideAnimatorController;

		public CharacterActor CharacterActor { get; private set; }

		public CharacterActions CharacterActions
		{
			get
			{
				if (!(CharacterBrain == null))
				{
					return CharacterBrain.CharacterActions;
				}
				return default(CharacterActions);
			}
		}

		public CharacterStateController CharacterStateController { get; private set; }

		protected virtual void Awake()
		{
			CharacterActor = this.GetComponentInBranch<CharacterActor>();
			CharacterStateController = this.GetComponentInBranch<CharacterActor, CharacterStateController>();
			CharacterBrain = this.GetComponentInBranch<CharacterActor, CharacterBrain>();
		}

		protected virtual void Start()
		{
			StateNameHash = Animator.StringToHash(GetType().Name);
		}

		public virtual void EnterBehaviour(float dt, CharacterState fromState)
		{
		}

		public virtual void PreUpdateBehaviour(float dt)
		{
		}

		public abstract void UpdateBehaviour(float dt);

		public virtual void PostUpdateBehaviour(float dt)
		{
		}

		public virtual void PreCharacterSimulation(float dt)
		{
		}

		public virtual void PostCharacterSimulation(float dt)
		{
		}

		public virtual void ExitBehaviour(float dt, CharacterState toState)
		{
		}

		public virtual void CheckExitTransition()
		{
		}

		public virtual bool CheckEnterTransition(CharacterState fromState)
		{
			return true;
		}

		public virtual void UpdateIK(int layerIndex)
		{
		}

		public virtual string GetInfo()
		{
			return "";
		}

		public bool IsAnimatorValid()
		{
			return CharacterActor.IsAnimatorValid();
		}
	}
}
