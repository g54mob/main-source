using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Assets.Scripts.Character.State
{
	public abstract class CharacterState : MonoBehaviour, IUpdateable
	{
		private CharacterBrain _characterBrain;

		[SerializeField]
		private bool _overrideAnimatorController = true;

		[Condition("overrideAnimatorController", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private RuntimeAnimatorController _runtimeAnimatorController;

		public CharacterActions CharacterActions
		{
			get
			{
				if (!(_characterBrain == null))
				{
					return _characterBrain.Actions;
				}
				return default(CharacterActions);
			}
		}

		public CharacterActor CharacterActor { get; private set; }

		public CharacterStateController CharacterStateController { get; private set; }

		public bool OverrideAnimatorController => _overrideAnimatorController;

		public RuntimeAnimatorController RuntimeAnimatorController => _runtimeAnimatorController;

		public int StateNameHash { get; private set; }

		public virtual bool CheckEnterTransition(CharacterState fromState)
		{
			return true;
		}

		public virtual void CheckExitTransition()
		{
		}

		public virtual void EnterBehaviour(float dt, CharacterState fromState)
		{
		}

		public virtual void ExitBehaviour(float dt, CharacterState toState)
		{
		}

		public virtual string GetInfo()
		{
			return string.Empty;
		}

		public bool IsAnimatorValid()
		{
			return CharacterActor.IsAnimatorValid();
		}

		public virtual void PostCharacterSimulation(float dt)
		{
		}

		public virtual void PostUpdateBehaviour(float dt)
		{
		}

		public virtual void PreCharacterSimulation(float dt)
		{
		}

		public virtual void PreUpdateBehaviour(float dt)
		{
		}

		public abstract void UpdateBehaviour(float dt);

		public virtual void UpdateIK(int layerIndex)
		{
		}

		protected virtual void Awake()
		{
			CharacterActor = this.GetComponentInBranch<CharacterActor>();
			CharacterStateController = this.GetComponentInBranch<CharacterActor, CharacterStateController>();
			_characterBrain = this.GetComponentInBranch<CharacterActor, CharacterBrain>();
		}

		protected virtual void Start()
		{
			StateNameHash = Animator.StringToHash(GetType().Name);
		}
	}
}
