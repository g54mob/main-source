using UnityEngine;

namespace ECM2
{
	[RequireComponent(typeof(BoxCollider))]
	public class PhysicsVolume : MonoBehaviour
	{
		[Tooltip("Determines which PhysicsVolume takes precedence if they overlap (higher value == higher priority).")]
		[SerializeField]
		private int _priority;

		[Tooltip("Determines the amount of friction applied by the volume as Character using CharacterMovement moves through it.\nThe higher this value, the harder it will feel to move through the volume.")]
		[SerializeField]
		private float _friction;

		[Tooltip("Determines the terminal velocity of Characters using CharacterMovement when falling.")]
		[SerializeField]
		private float _maxFallSpeed;

		[Tooltip("Determines if the volume contains a fluid, like water.")]
		[SerializeField]
		private bool _waterVolume;

		private BoxCollider _collider;

		public BoxCollider boxCollider => null;

		public int priority
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float friction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxFallSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool waterVolume
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected virtual void OnReset()
		{
		}

		protected virtual void OnOnValidate()
		{
		}

		protected virtual void OnAwake()
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private void Awake()
		{
		}
	}
}
