using System;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Wing
{
	public class AdjustmentGizmoScript : MonoBehaviour
	{
		public float GizmoFlyoutScalar;

		public bool RestrictForwardAftMovement = true;

		public bool RestrictLateralMovement = true;

		public bool RestrictVerticalMovement = true;

		public Func<Vector3> GetTargetWorldPosition { get; set; }

		public GameObject GizmoBase { get; set; }

		public Vector3 GizmoFlyoutDirection { get; set; }

		public Action OnGizmoMoveCompleted { get; set; }

		public Action OnGizmoMoveStarted { get; set; }

		public Action<Vector3> UpdateTargetWorldPosition { get; set; }

		public Transform WingRoot { get; set; }

		internal AdjustmentGizmoMeshScript AdjustmentGizmoMeshScript { get; set; }

		public void OnDestroy()
		{
			AdjustmentGizmoMeshScript.OnDestroy();
		}

		public void RefreshPosition()
		{
			Vector3 position = GetTargetWorldPosition() + GizmoFlyoutDirection.normalized * GizmoFlyoutScalar;
			base.transform.position = position;
		}

		public void Start()
		{
		}
	}
}
