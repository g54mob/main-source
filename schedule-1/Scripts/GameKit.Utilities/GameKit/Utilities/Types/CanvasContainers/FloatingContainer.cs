using System.Runtime.CompilerServices;
using GameKit.Dependencies.Inspectors;
using UnityEngine;

namespace GameKit.Utilities.Types.CanvasContainers
{
	public class FloatingContainer : CanvasGroupFader
	{
		[Tooltip("RectTransform to move.")]
		[SerializeField]
		[Group("Components", false)]
		protected RectTransform RectTransform;

		[Tooltip("True to use edge avoidance.")]
		[SerializeField]
		[Group("Sizing", false)]
		protected bool UseEdgeAvoidance;

		[Tooltip("How much to avoid screen edges when being moved.")]
		[SerializeField]
		[Group("Sizing", false)]
		[ShowIf(/*Could not decode attribute arguments.*/)]
		protected Vector2 EdgeAvoidance;

		private Vector3 _positionGoal;

		private Quaternion _rotationGoal;

		private Vector3 _scaleGoal;

		private Vector2? _edgeAvoidance;

		public void AttachGameObject(GameObject go)
		{
		}

		public virtual void Show(Vector3 position, Quaternion rotation, Vector3 scale, Vector2 pivot, Vector2? edgeAvoidanceOverride = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual void Show(Vector3 position, Vector2? edgeAvoidanceOverride = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual void Show(Vector3 position, Quaternion rotation, Vector2? edgeAvoidanceOverride = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual void Show(Transform startingPoint, Vector2? edgeAvoidanceOverride = null)
		{
		}

		public virtual void UpdatePivot(Vector2 pivot, bool move = true)
		{
		}

		public virtual void UpdatePosition(Vector3 position, bool move = true)
		{
		}

		public virtual void UpdateRotation(Quaternion rotation, bool move = true)
		{
		}

		public virtual void UpdateScale(Vector3 scale, bool move = true)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual void UpdatePositionAndRotation(Vector3 position, Quaternion rotation, bool move = true)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual void UpdatePositionRotationAndScale(Vector3 position, Quaternion rotation, Vector3 scale, bool move = true)
		{
		}

		public virtual void UpdateEdgeAvoidance(Vector2? edgeAvoidanceOverride = null, bool move = true)
		{
		}

		protected virtual void Move()
		{
		}
	}
}
