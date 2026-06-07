using UnityEngine;

namespace Assets.Scripts.Character
{
	public class Ragdoller : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		private Rigidbody _parentRigidbody;

		[SerializeField]
		private bool _ragdollEnabled;

		private bool _ragdollEnabledLastSet;

		private Rigidbody[] _rigidbodies;

		protected void Start()
		{
			_parentRigidbody = GetComponentInParent<Rigidbody>();
			_rigidbodies = GetComponentsInChildren<Rigidbody>();
			SetRagdollEnabled(_ragdollEnabled);
		}

		protected void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.CapsLock))
			{
				_ragdollEnabled = !_ragdollEnabled;
			}
			if (_ragdollEnabled != _ragdollEnabledLastSet)
			{
				SetRagdollEnabled(_ragdollEnabled);
			}
		}

		private void SetRagdollEnabled(bool state)
		{
			_animator.enabled = !state;
			for (int i = 0; i < _rigidbodies.Length; i++)
			{
				_rigidbodies[i].isKinematic = !state;
				_rigidbodies[i].detectCollisions = state;
				if (_parentRigidbody != null && state)
				{
					_rigidbodies[i].linearVelocity = _parentRigidbody.linearVelocity;
				}
			}
			_ragdollEnabledLastSet = state;
		}
	}
}
