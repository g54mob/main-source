using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class Kernel3D : MonoBehaviour
	{
		public enum KernelType
		{
			Good = 0,
			Bad = 1,
			Magenta = 2
		}

		[Header("Animation — Entrance")]
		[SerializeField]
		private TweenConfig entranceAnimation;

		[Header("Animation — Exit (reached end after deflection)")]
		[SerializeField]
		private TweenConfig exitAnimation;

		[Header("Animation — Shake (visual feedback on wrong sort)")]
		[SerializeField]
		private float shakeAmount;

		[SerializeField]
		private float shakeDuration;

		private KernelType type;

		private float moveSpeed;

		private Vector3 moveDirection;

		private float gateThreshold;

		private bool resolved;

		private bool reachedGate;

		private bool isDeflecting;

		private bool isPaused;

		private Vector3 deflectDir;

		private float deflectExitThreshold;

		private Vector3 targetScale;

		public KernelType Type => default(KernelType);

		public bool IsResolved => false;

		public bool HasReachedGate => false;

		public float MoveSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event Action<Kernel3D> OnReachedGate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Kernel3D> OnExited
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Kernel3D> OnRecycled
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Initialize(KernelType kernelType, float speed, Vector3 moveDir, float gateX)
		{
		}

		private void Update()
		{
		}

		public void SetDeflection(Vector3 direction, float exitX)
		{
		}

		public void Pause()
		{
		}

		public void Resume(bool bounce = false)
		{
		}

		public void Shake()
		{
		}

		private void Exit()
		{
		}

		private void Recycle()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
