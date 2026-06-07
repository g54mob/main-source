using System;
using ModApi.Input.Events;
using UnityEngine;

namespace ModApi.Ui
{
	public class MouseDrag
	{
		private Vector3? _dragDirection;

		private Vector2? _mouseDragVec;

		private Ray _mouseScreenRay;

		private Vector2 _startMousePos;

		public Camera Camera { get; }

		public float DeltaMag { get; private set; }

		public float DeltaScreenMag { get; private set; }

		public Vector3 DeltaVec { get; private set; }

		public Vector3 Direction
		{
			get
			{
				if (_dragDirection.HasValue)
				{
					return _dragDirection.Value;
				}
				Debug.LogError("Invalid operation: MouseDrag._dragDirection has not yet been set.");
				return Vector3.zero;
			}
		}

		public Vector3? DirectionRaw => _dragDirection;

		public Transform DragTransform { get; protected set; }

		public Vector2? MouseDragVec => _mouseDragVec;

		public Ray MouseScreenRay => _mouseScreenRay;

		public MouseDrag(Camera camera)
		{
			Camera = camera;
		}

		public virtual void ProcessMouseBegin(ClickEventArgs e)
		{
			_startMousePos = e.Position;
			_mouseDragVec = null;
		}

		public virtual void ProcessMouseDrag(ClickEventArgs e)
		{
			if (DragTransform != null)
			{
				Camera camera = Camera;
				if (!_dragDirection.HasValue && !_mouseDragVec.HasValue)
				{
					_mouseDragVec = (e.Position - _startMousePos).normalized;
				}
				float num = Vector3.Distance(camera.transform.position, DragTransform.position);
				float num2 = 2f * num * Mathf.Tan(camera.fieldOfView * 0.5f * (MathF.PI / 180f));
				Vector2 b = new Vector2(num2 * Camera.aspect / (float)camera.pixelWidth, num2 / (float)camera.pixelHeight) * Game.Instance.ResolutionScale;
				Vector2 lhs;
				if (_dragDirection.HasValue)
				{
					Vector3 vector = Utilities.GameWorldToScreenPoint(camera, DragTransform.position + _dragDirection.Value);
					Vector3 vector2 = Utilities.GameWorldToScreenPoint(camera, DragTransform.position);
					lhs = ((Vector2)(vector - vector2)).normalized;
				}
				else
				{
					lhs = _mouseDragVec.Value;
				}
				float num3 = Vector2.Dot(lhs, e.DeltaPosition.normalized);
				float magnitude = Vector2.Scale(e.DeltaPosition, b).magnitude;
				DeltaMag = num3 * magnitude;
				DeltaScreenMag = num3 * e.DeltaPosition.magnitude;
				if (_dragDirection.HasValue)
				{
					DeltaVec = _dragDirection.Value.normalized * DeltaMag;
				}
			}
		}

		public void SetDragDirection(Vector3 direction)
		{
			_dragDirection = direction.normalized;
		}

		public void SetTransform(Transform dragTransform)
		{
			DragTransform = dragTransform;
		}

		public void Update(ClickEventArgs mouseInfo)
		{
			_mouseScreenRay = Utilities.ScreenPointToRay(Camera, mouseInfo.Position);
		}
	}
}
