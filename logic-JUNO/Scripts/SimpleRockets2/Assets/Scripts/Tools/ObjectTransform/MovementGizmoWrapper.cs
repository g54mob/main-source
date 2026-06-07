using System;
using Assets.Scripts.Design;
using ModApi.Common.Events;
using ModApi.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public class MovementGizmoWrapper<TMovementGizmo, TGizmoAxisScript> : IMovementGizmoWrapper where TMovementGizmo : MovementGizmo<TGizmoAxisScript>, new() where TGizmoAxisScript : GizmoAxisScript
	{
		public delegate void ClickHandler(MovementGizmoWrapper<TMovementGizmo, TGizmoAxisScript> source);

		public delegate void ClickHandlerEulers(MovementGizmoWrapper<TMovementGizmo, TGizmoAxisScript> source, Vector3 finalEulerAngles);

		private Transform _adjustmentTransform;

		private DesignerScript _designer;

		private Action _updaterAction;

		private GameObject _visualization;

		public bool AutoClickHandling { get; set; } = true;

		public bool AutoUpdate { get; set; } = true;

		public bool AutoUpdateTargetTransform { get; set; } = true;

		IMovementGizmo IMovementGizmoWrapper.Gizmo => Gizmo;

		public TMovementGizmo Gizmo { get; private set; }

		public bool IsAdjusting => Gizmo.IsAdjusting;

		public bool IsShowing { get; private set; }

		public event ClickHandlerEulers AdjustmentEnded;

		public event ClickHandler AdjustmentStarted;

		public MovementGizmoWrapper(Camera camera, GameObject visualizationObject)
		{
			_visualization = visualizationObject;
			_visualization.SetActive(value: false);
			Gizmo = new TMovementGizmo();
			Gizmo.Initialize(camera);
			Gizmo.GizmoClickDown += OnGizmoClickDown;
			Gizmo.GizmoClickUp += OnGizmoClickUp;
			_updaterAction = delegate
			{
				Update();
			};
			if (Game.InDesignerScene)
			{
				_designer = Game.Instance.Designer as DesignerScript;
				if (AutoClickHandling)
				{
					_designer.Click += HandleClick;
				}
			}
		}

		public bool HandleClick(ClickEventArgs e)
		{
			return Gizmo.HandleClick(e);
		}

		public void Start(Transform adjustmentTransform, bool showAdjustmentGizmo)
		{
			IsShowing = true;
			_adjustmentTransform = adjustmentTransform;
			_visualization.SetActive(value: true);
			if (showAdjustmentGizmo)
			{
				Gizmo.SetAdjustmentTransform(_visualization.transform, playGizmoFlyoutSound: true);
			}
			if (AutoUpdate)
			{
				UnityEventDispatcher.Instance.Register(_updaterAction, UnityEventDispatcher.EventType.Update);
			}
		}

		public void Stop()
		{
			IsShowing = false;
			_adjustmentTransform = null;
			_visualization.SetActive(value: false);
			Gizmo.SetAdjustmentTransform(null, playGizmoFlyoutSound: false);
			UnityEventDispatcher.Instance.UnRegister(_updaterAction, UnityEventDispatcher.EventType.Update, suppressActionDoesntExistWarning: true);
		}

		public void Update()
		{
			if (!IsShowing)
			{
				return;
			}
			if (_adjustmentTransform != null)
			{
				if (!Gizmo.IsAdjusting)
				{
					UpdateVisualization();
				}
				Gizmo.Update();
				if (AutoUpdateTargetTransform)
				{
					_adjustmentTransform.SetPositionAndRotation(_visualization.transform.position, _visualization.transform.rotation);
				}
			}
			else
			{
				Gizmo.SetAdjustmentTransform(null, playGizmoFlyoutSound: false);
			}
		}

		private void OnGizmoClickDown(MovementGizmo<TGizmoAxisScript> source, ClickEventArgs e)
		{
			if (_designer != null)
			{
				_designer.SetNonToolCapture(captured: true);
			}
			this.AdjustmentStarted?.Invoke(this);
		}

		private void OnGizmoClickUp(MovementGizmo<TGizmoAxisScript> source, ClickEventArgs e)
		{
			if (_designer != null)
			{
				_designer.SetNonToolCapture(captured: false);
			}
			this.AdjustmentEnded?.Invoke(this, _visualization.transform.eulerAngles);
		}

		private void UpdateVisualization()
		{
			_visualization.transform.SetPositionAndRotation(_adjustmentTransform.position, _adjustmentTransform.rotation);
		}
	}
}
