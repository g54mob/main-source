using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class Button3D : MonoBehaviour
	{
		[Header("Configuration")]
		[SerializeField]
		private float pressDepth;

		[SerializeField]
		private float pressSpeed;

		[SerializeField]
		private float lockoutDuration;

		[Header("Visual")]
		[SerializeField]
		private Renderer buttonRenderer;

		[SerializeField]
		private Color readyColor;

		[SerializeField]
		private Color lockedColor;

		[Header("Hover")]
		[SerializeField]
		private float hoverScaleMultiplier;

		[SerializeField]
		private float hoverSpeed;

		private float pressAmount;

		private bool pressing;

		private bool isHovered;

		private float currentHoverScale;

		private Vector3 restLocalPos;

		private Vector3 restScale;

		private Collider cachedCollider;

		private MaterialPropertyBlock propBlock;

		private bool lastColorWasLocked;

		private bool colorInitialized;

		public bool IsLockedOut { get; private set; }

		public float LockoutRemaining { get; private set; }

		public bool PulseOverride { get; set; }

		public Vector3 RestScale => default(Vector3);

		public event Action OnPressed
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

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void ApplyColor(bool locked)
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void SetLockoutState(bool locked, float remaining)
		{
		}

		public void SetLocked(bool locked)
		{
		}
	}
}
