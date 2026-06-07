using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class Draggable3D : MonoBehaviour
	{
		[Header("Configuration")]
		[Tooltip("Optional BoxCollider whose world-space bounds constrain the drag area.")]
		[SerializeField]
		private BoxCollider dragBounds;

		[Header("Animation")]
		[SerializeField]
		private TweenConfig pickUpAnimation;

		[SerializeField]
		private TweenConfig dropAnimation;

		[SerializeField]
		private float dragScaleMultiplier;

		[Tooltip("How far to lift the object toward the camera while dragging.")]
		[SerializeField]
		private float liftOffset;

		private Collider cachedCollider;

		private Plane dragPlane;

		private Vector3 dragOffset;

		private bool isDragging;

		private Vector3 homeLocalPos;

		private Vector3 restScale;

		private int scaleTweenId;

		private int moveTweenId;

		private bool snapBackEnabled;

		public bool IsDragging => false;

		public event Action<Draggable3D> OnDragStart
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

		public event Action<Draggable3D> OnDragEnd
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

		private void Update()
		{
		}

		private void EndDrag()
		{
		}

		public void DisableSnapBack()
		{
		}

		public void EnableSnapBack()
		{
		}

		private void SnapToHome()
		{
		}

		private Vector3 ClampToBounds(Vector3 worldPoint)
		{
			return default(Vector3);
		}

		public void ResetToHome()
		{
		}

		public void SetHome(Vector3 worldPosition)
		{
		}

		public void SetHomeLocal(Vector3 localPosition)
		{
		}

		public void SetRestScale(Vector3 scale)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
