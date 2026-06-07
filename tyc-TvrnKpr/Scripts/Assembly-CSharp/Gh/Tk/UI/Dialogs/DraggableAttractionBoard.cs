using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class DraggableAttractionBoard : MonoBehaviour, IInteractableUI
	{
		private BoxCollider _collider;

		public Transform leftClamp;

		public Transform rightClamp;

		public Transform leftEdge;

		public Transform rightEdge;

		public float snapDistance;

		public AnimationCurve snapResistanceCurve;

		public float minSnapThreshold;

		public float maxSnapThreshold;

		private int _lastSnapSegment;

		public float snapReleaseDuration;

		public Ease snapReleaseEasing;

		public float maxDragSpeedModifier;

		public int resistanceCurvePollFactor;

		private bool _isDraggingActive;

		private bool _isPressed;

		private bool _isBoardMovingRight;

		private Vector3 _prevPos;

		private Tween _releaseTween;

		private int visibleSegments;

		public List<Transform> hideIfOutOfBounds;

		[Header("Debug Values")]
		public float snapProgressCheck;

		public float deltaCheck;

		public bool IsDraggingActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsHovered { get; set; }

		public bool IsPressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsInteractionSuspended { get; set; }

		private int MoveableSegements => 0;

		public event EventHandler<EventArgs<int>> BoardDragged
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

		public void OnClicked()
		{
		}

		public void OnHovering()
		{
		}

		public void Reset()
		{
		}

		private Vector3 GetDelta()
		{
			return default(Vector3);
		}

		private Vector3 GetLocalPosFromScreen(Vector3 pos)
		{
			return default(Vector3);
		}

		private Vector3 GetLeftClampLocalPosition()
		{
			return default(Vector3);
		}

		private Vector3 GetRightClampLocalPosition()
		{
			return default(Vector3);
		}

		private bool IsBoardMovingRight(float deltaZ)
		{
			return false;
		}

		private void OnReleased()
		{
		}

		public void Update()
		{
		}

		public void SnapToSegment(int segment)
		{
		}

		private float GetDistanceBetweenClamps(Vector3 leftClampLocal, Vector3 rightClampLocal)
		{
			return 0f;
		}

		private void UpdateDragging(float deltaZ)
		{
		}

		private float GetNearestSnapPosition(float position)
		{
			return 0f;
		}

		private float GetNearestSnapPosition(float position, bool isMovingRight)
		{
			return 0f;
		}

		private int GetSnapSegment(float position, bool isMovingRight)
		{
			return 0;
		}

		private void CheckObjectVisibilities()
		{
		}

		public bool IsTransformOnBoard(Transform checkTransform)
		{
			return false;
		}
	}
}
