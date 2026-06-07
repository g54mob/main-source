using System;
using ModApi.Input.Events;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public interface IMovementGizmo
	{
		Camera Camera { get; }

		MonoBehaviour GizmoBeingDragged { get; }

		bool GizmosActive { get; }

		bool GizmosCreated { get; }

		Transform GizmosParent { get; }

		float GridSize { get; set; }

		Func<float> GridSizeFunc { get; set; }

		bool IsAdjusting { get; }

		bool IsLocalOrientation { get; set; }

		bool? IsNewAxis { get; }

		MouseDrag MouseDrag { get; }

		string Name { get; }

		Transform SelectedTransform { get; }

		void CreateGizmos(bool playGizmoFlyoutSound);

		void DestroyGizmos();

		bool HandleClick(ClickEventArgs e);

		void Initialize(Camera camera);

		void SetAdjustmentTransform(Transform transform, bool playGizmoFlyoutSound);

		void Update();
	}
}
