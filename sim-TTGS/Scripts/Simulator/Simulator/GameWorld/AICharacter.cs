using Dhs5.Utility.Updates;
using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class AICharacter : Character, IAIInputReceiver
	{
		[Header("Movement")]
		[SerializeField]
		private Rigidbody m_rigidbody;

		public override bool IsPlayer => false;

		protected abstract CharacterModel Model { get; }

		public bool IsMan => Model.IsMan;

		public int ModelIndex => Model.ModelIndex;

		public Transform LeftHand => Model.LeftHandRoot;

		public Transform RightHand => Model.RightHandRoot;

		public override CinemachineCamera Camera => null;

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Model != null && Model.HasAnimator)
			{
				RegisterToUpdate(register: true);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (Model != null && Model.HasAnimator)
			{
				RegisterToUpdate(register: false);
			}
		}

		public virtual void OnAIInput_Look(Vector3 lookDirection)
		{
			m_rigidbody.MoveRotation(Quaternion.LookRotation(lookDirection));
		}

		public virtual void OnAIInput_Move(Vector3 position)
		{
			m_rigidbody.MovePosition(position);
		}

		public virtual void OnAIInput_IsWalking(bool walking)
		{
			Model.SetWalking(walking);
		}

		public virtual void OnAIInput_MainInteraction(ISensable sensable)
		{
		}

		public virtual void OnAIInput_SecondaryInteraction(ISensable sensable)
		{
			if (sensable != null && sensable is ISecondInteractable secondInteractable)
			{
				secondInteractable.TrySecondInteract(this);
			}
		}

		protected void RegisterToUpdate(bool register)
		{
			Updater.RegisterChannelCallback(register, EUpdateChannel.MOVEMENT, OnUpdate);
		}

		protected virtual void OnUpdate(float deltaTime)
		{
		}

		public void SetAnimatorUpdateMode(AnimatorUpdateMode mode)
		{
			Model.SetUpdateMode(mode);
		}

		public void SetSitted(bool sitted)
		{
			Model.SetSitted(sitted);
		}
	}
}
