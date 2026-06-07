using System.Linq;
using Lightbug.Utilities;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Scripts.Character.State
{
	public class Ragdoll : CharacterState
	{
		private Collider[] _colliders;

		private Transform _graphicsParent;

		private IK _ik;

		private RigidbodyComponent _parentRigidbody;

		private Transform _ragdollTransform;

		private float _ragTime;

		private float _ragTimeTarget = 5f;

		private Rigidbody[] _rigidbodies;

		public override void CheckExitTransition()
		{
			if (_ragTime >= _ragTimeTarget)
			{
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.EnterBehaviour(dt, fromState);
			RunSetup();
			SetRagdollEnabled(state: true);
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			base.ExitBehaviour(dt, toState);
			base.CharacterActor.Position = _rigidbodies[0].position;
			base.CharacterActor.transform.position = _rigidbodies[0].position;
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < _rigidbodies.Length; i++)
			{
				zero += _rigidbodies[i].linearVelocity;
			}
			zero /= (float)_rigidbodies.Length;
			base.CharacterActor.Velocity = zero;
			SetRagdollEnabled(state: false);
			_ragTime = 0f;
		}

		public override void UpdateBehaviour(float dt)
		{
			_ragTime += dt;
			base.CharacterActor.Position = _rigidbodies[0].position;
			base.CharacterActor.Velocity = _rigidbodies[0].linearVelocity;
		}

		protected override void Start()
		{
			base.Start();
			RunSetup();
			SetRagdollEnabled(state: false);
		}

		private void RunSetup()
		{
			_graphicsParent = base.CharacterActor.Animator.transform.parent;
			_ragdollTransform = base.CharacterActor.Animator.transform;
			_parentRigidbody = base.CharacterActor.RigidbodyComponent;
			_ik = _ragdollTransform.GetComponent<IK>();
			_rigidbodies = _ragdollTransform.GetComponentsInChildren<Rigidbody>();
			_colliders = (from x in _ragdollTransform.GetComponentsInChildren<Collider>()
				where !x.isTrigger
				select x).ToArray();
		}

		private void SetRagdollEnabled(bool state)
		{
			base.CharacterActor.Animator.enabled = !state;
			base.CharacterActor.ColliderComponent.enabled = !state;
			_ik.enabled = !state;
			_ragdollTransform.SetParent(state ? base.CharacterActor.transform.parent : _graphicsParent);
			if (!state)
			{
				_ragdollTransform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			}
			for (int i = 0; i < _rigidbodies.Length; i++)
			{
				_rigidbodies[i].isKinematic = !state;
				_rigidbodies[i].detectCollisions = state;
				if (_parentRigidbody != null && state)
				{
					_rigidbodies[i].linearVelocity = _parentRigidbody.GetPointVelocity(_rigidbodies[i].position);
				}
			}
			for (int j = 0; j < _colliders.Length; j++)
			{
				_colliders[j].enabled = state;
			}
		}
	}
}
