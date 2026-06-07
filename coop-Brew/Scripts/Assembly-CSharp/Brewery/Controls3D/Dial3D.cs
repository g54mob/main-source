using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class Dial3D : MonoBehaviour
	{
		[Header("Needle")]
		[SerializeField]
		private Transform needle;

		[Header("Orientation")]
		[Tooltip("Offset (degrees) applied to the visual rotation. Use to align the dial's visual zero with the mesh orientation.")]
		[SerializeField]
		private float angleOffset;

		[Tooltip("Flip drag direction if dragging feels inverted relative to the visual.")]
		[SerializeField]
		private bool invertDragDirection;

		[Tooltip("Local axis the needle rotates around. Default (0,0,1) = Z-forward.")]
		[SerializeField]
		private Vector3 rotationAxis;

		[Header("Range")]
		[SerializeField]
		private float minAngle;

		[SerializeField]
		private float maxAngle;

		[Tooltip("Number of snap positions. 0 = continuous, 2+ = discrete steps.")]
		[SerializeField]
		private int detents;

		[Tooltip("Allow multiple full rotations (e.g. valve wheel).")]
		[SerializeField]
		private bool multiTurn;

		[SerializeField]
		private float maxTurns;

		[Header("Smoothing")]
		[Tooltip("Needle rotation smoothing speed. Higher = faster. 0 = instant.")]
		[SerializeField]
		private float smoothSpeed;

		[Header("State")]
		[SerializeField]
		[Range(0f, 1f)]
		private float value;

		private Plane dragPlane;

		private bool isDragging;

		private Collider cachedCollider;

		private float lastDragAngle;

		private float dragStartValue;

		private float accumulatedAngle;

		private float targetNeedleAngle;

		private float currentNeedleAngle;

		private float needleVelocity;

		private bool isAnimating;

		public float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private Vector3 SafeAxis => default(Vector3);

		public event Action<float> OnValueChanged
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

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void HandleDragInput()
		{
		}

		private float GetAngleFromCenter(Vector3 worldPoint)
		{
			return 0f;
		}

		private static float NormalizeAngleDelta(float delta)
		{
			return 0f;
		}

		private void UpdateTargetAngle()
		{
		}

		private void SnapNeedle()
		{
		}

		public void SetValueWithoutNotify(float normalized)
		{
		}

		public void AnimateToValue(float target)
		{
		}

		public void SetValueFromInput(float normalized)
		{
		}

		private void OnValidate()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private static Vector3 AngleToDirection(float angleDeg, Vector3 up, Vector3 right)
		{
			return default(Vector3);
		}
	}
}
