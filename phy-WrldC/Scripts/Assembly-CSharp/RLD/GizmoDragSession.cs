using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public abstract class GizmoDragSession : IGizmoDragSession
	{
		private List<GizmoTransform> _targetTransforms = new List<GizmoTransform>();

		protected Vector3 _totalDragOffset;

		protected Quaternion _totalDragRotation;

		protected Vector3 _totalDragScale;

		protected Vector3 _relativeDragOffset;

		protected Quaternion _relativeDragRotation = Quaternion.identity;

		protected Vector3 _relativeDragScale = Vector3.one;

		public int NumTargetTransforms => _targetTransforms.Count;

		public Vector3 TotalDragOffset => _totalDragOffset;

		public Quaternion TotalDragRotation => _totalDragRotation;

		public Vector3 TotalDragScale => _totalDragScale;

		public Vector3 RelativeDragOffset => _relativeDragOffset;

		public Quaternion RelativeDragRotation => _relativeDragRotation;

		public Vector3 RelativeDragScale => _relativeDragScale;

		public abstract bool IsActive { get; }

		public abstract GizmoDragChannel DragChannel { get; }

		public bool ContainsTargetTransform(GizmoTransform transform)
		{
			return _targetTransforms.Contains(transform);
		}

		public void AddTargetTransform(GizmoTransform transform)
		{
			if (!IsActive && !ContainsTargetTransform(transform))
			{
				_targetTransforms.Add(transform);
			}
		}

		public void RemoveTargetTransform(GizmoTransform transform)
		{
			if (!IsActive)
			{
				_targetTransforms.Remove(transform);
			}
		}

		public bool Begin()
		{
			if (!CanBegin())
			{
				return false;
			}
			if (!DoBeginSession())
			{
				return false;
			}
			OnSessionBegin();
			return true;
		}

		public bool Update()
		{
			if (!IsActive)
			{
				return false;
			}
			if (DoUpdateSession())
			{
				CalculateDragValues();
				ApplyDrag();
				return true;
			}
			return false;
		}

		public void End()
		{
			if (IsActive)
			{
				DoEndSession();
				_totalDragOffset = (_relativeDragOffset = Vector3.zero);
				_totalDragRotation = (_relativeDragRotation = Quaternion.identity);
				_totalDragScale = (_relativeDragScale = Vector3.one);
				OnSessionEnd();
			}
		}

		protected abstract bool DoBeginSession();

		protected abstract bool DoUpdateSession();

		protected abstract void DoEndSession();

		protected abstract void CalculateDragValues();

		protected void ApplyDrag()
		{
			List<GizmoTransform> list = GizmoTransform.FilterParentsOnly(_targetTransforms);
			if (DragChannel == GizmoDragChannel.Offset)
			{
				foreach (GizmoTransform item in list)
				{
					item.Position3D += _relativeDragOffset;
				}
				return;
			}
			if (DragChannel != GizmoDragChannel.Rotation)
			{
				return;
			}
			foreach (GizmoTransform item2 in list)
			{
				item2.Rotation3D = _relativeDragRotation * item2.Rotation3D;
			}
		}

		protected virtual bool CanBegin()
		{
			return !IsActive;
		}

		protected virtual void OnSessionBegin()
		{
		}

		protected virtual void OnSessionEnd()
		{
		}
	}
}
