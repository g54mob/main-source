using System;
using Assets.Scripts.Design.Tools.Wing;
using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public class TranslateGizmoAxisScript : GizmoAxisScript
	{
		public enum GizmoAxisType
		{
			Up = 0,
			Right = 1,
			Forward = 2,
			Custom = 3
		}

		private Func<Vector3> _directionFunc;

		public AdjustmentGizmoMeshScript AdjustmentGizmoScript { get; private set; }

		public GizmoAxisType AxisType { get; set; }

		public Vector3 Direction => _directionFunc().normalized;

		public Vector2i Id { get; set; }

		public static TranslateGizmoAxisScript Create(Transform parent, Func<Vector3> gizmoFlyoutDirection, Color color, float gizmoFlyoutDistance, bool screenSizeConstant, Camera screenSizeConstantCamera, GizmoAxisType axisType)
		{
			Vector3 gizmoFlyoutDirection2 = gizmoFlyoutDirection();
			AdjustmentGizmoMeshScript adjustmentGizmoMeshScript = AdjustmentGizmoMeshScript.Create(parent, gizmoFlyoutDirection2, gizmoFlyoutDistance, screenSizeConstant, screenSizeConstantCamera, color);
			TranslateGizmoAxisScript translateGizmoAxisScript = adjustmentGizmoMeshScript.gameObject.AddComponent<TranslateGizmoAxisScript>();
			translateGizmoAxisScript._directionFunc = gizmoFlyoutDirection;
			translateGizmoAxisScript.AdjustmentGizmoScript = adjustmentGizmoMeshScript;
			translateGizmoAxisScript.AxisType = axisType;
			switch (axisType)
			{
			case GizmoAxisType.Forward:
				translateGizmoAxisScript.gameObject.name += " Forward";
				break;
			case GizmoAxisType.Right:
				translateGizmoAxisScript.gameObject.name += " Right";
				break;
			case GizmoAxisType.Up:
				translateGizmoAxisScript.gameObject.name += " Up";
				break;
			}
			return translateGizmoAxisScript;
		}
	}
}
