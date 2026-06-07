using ModApi.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public interface IMovementGizmoWrapper
	{
		bool AutoClickHandling { get; set; }

		bool AutoUpdate { get; set; }

		bool AutoUpdateTargetTransform { get; set; }

		IMovementGizmo Gizmo { get; }

		bool IsAdjusting { get; }

		bool IsShowing { get; }

		bool HandleClick(ClickEventArgs e);

		void Start(Transform adjustmentTransform, bool showAdjustmentGizmo);

		void Stop();

		void Update();
	}
}
