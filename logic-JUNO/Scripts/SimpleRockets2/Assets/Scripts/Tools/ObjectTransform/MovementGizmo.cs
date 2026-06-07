using System;
using ModApi.Audio;
using ModApi.Input.Events;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public abstract class MovementGizmo<TGizmoAxisScript> : IMovementGizmo where TGizmoAxisScript : GizmoAxisScript
	{
		public delegate void GizmoAdjustedHandler(MovementGizmo<TGizmoAxisScript> source, bool? newAxis);

		public delegate void GizmoClickHandler(MovementGizmo<TGizmoAxisScript> source, ClickEventArgs e);

		public enum MovementType
		{
			Self = 0,
			Connected = 1
		}

		private float _gridSize;

		private bool _isLocalOrientation = true;

		public Camera Camera { get; private set; }

		MonoBehaviour IMovementGizmo.GizmoBeingDragged => GizmoBeingDragged;

		public TGizmoAxisScript GizmoBeingDragged { get; private set; }

		public bool GizmosActive
		{
			get
			{
				if (GizmosCreated)
				{
					return GizmosParent.gameObject.activeSelf;
				}
				return false;
			}
		}

		public bool GizmosCreated => GizmosParent != null;

		public Transform GizmosParent { get; private set; }

		public float GridSize
		{
			get
			{
				if (GridSizeFunc != null)
				{
					return GridSizeFunc();
				}
				return _gridSize;
			}
			set
			{
				_gridSize = value;
			}
		}

		public Func<float> GridSizeFunc { get; set; }

		public bool IsAdjusting => GizmoBeingDragged != null;

		public bool IsLocalOrientation
		{
			get
			{
				return _isLocalOrientation;
			}
			set
			{
				_isLocalOrientation = value;
				OnOrientationChanged();
			}
		}

		public bool? IsNewAxis { get; private set; }

		public MouseDrag MouseDrag { get; private set; }

		public string Name { get; private set; }

		public float RaycastDistance { get; set; } = 10000f;

		public Transform SelectedTransform { get; protected set; }

		private bool IsPendingFirstDragEvent { get; set; }

		private GizmoAxisScript PreviousGizmoDragged { get; set; }

		public event GizmoAdjustedHandler GizmoAdjusted;

		public event GizmoAdjustedHandler GizmoAdjustmentEnded;

		public event GizmoAdjustedHandler GizmoAdjustmentStarted;

		public event GizmoClickHandler GizmoClickDown;

		public event GizmoClickHandler GizmoClicked;

		public event GizmoClickHandler GizmoClickUp;

		public MovementGizmo()
		{
		}

		public virtual void CreateGizmos(bool playGizmoFlyoutSound)
		{
			if (GizmosActive)
			{
				Debug.LogWarning("Gizmos already active, call DestroyGizmos before calling CreateGizmos");
				DestroyGizmos();
			}
			GizmosParent = CreateGizmosContainer(this, playGizmoFlyoutSound);
			MoveGizmosToNewParent(SelectedTransform);
		}

		public virtual void DestroyGizmos()
		{
			GizmoBeingDragged = null;
			if (GizmosParent != null)
			{
				UnityEngine.Object.Destroy(GizmosParent.gameObject);
				GizmosParent = null;
			}
		}

		public bool HandleClick(ClickEventArgs e)
		{
			MouseDrag.Update(e);
			switch (e.InputState)
			{
			case InputState.Begin:
				ProcessMouseBegin(e);
				break;
			case InputState.Updated:
				if (IsAdjusting)
				{
					ProcessGizmoDrag(e);
				}
				break;
			case InputState.End:
				ProcessMouseEnd(e);
				break;
			}
			return IsAdjusting;
		}

		public virtual void Initialize(Camera camera)
		{
			if (camera.clearFlags != MovementGizmoCamera.CameraClearFlags)
			{
				Debug.LogWarning("Camera provided doesn't have the proper clear flags...gizmos may not render properly.");
			}
			if (camera.cullingMask != MovementGizmoCamera.CullingMask)
			{
				Debug.LogWarning("Camera provided doesn't have the proper culling mask...gizmos may not render properly.");
			}
			Name = GetType().Name;
			Camera = camera;
			MouseDrag = new MouseDrag(Camera);
		}

		public void SetAdjustmentTransform(Transform transform, bool playGizmoFlyoutSound)
		{
			SelectedTransform = transform;
			MouseDrag.SetTransform(transform);
			if (transform != null)
			{
				if (GizmosCreated)
				{
					MoveGizmosToNewParent(transform);
				}
				else
				{
					CreateGizmos(playGizmoFlyoutSound);
				}
			}
			else
			{
				DestroyGizmos();
			}
		}

		public virtual void Update()
		{
		}

		protected TGizmoAxisScript GetGizmoUnderMouse(out RaycastHit rayHit)
		{
			return GetGizmoUnderMouse(sphereCast: false, 0f, out rayHit);
		}

		protected TGizmoAxisScript GetGizmoUnderMouse(bool sphereCast, float sphereCastRadius)
		{
			RaycastHit rayHit;
			return GetGizmoUnderMouse(sphereCast: false, sphereCastRadius, out rayHit);
		}

		protected TGizmoAxisScript GetGizmoUnderMouse(bool sphereCast, float sphereCastRadius, out RaycastHit rayHit)
		{
			TGizmoAxisScript result = null;
			if ((!sphereCast) ? Physics.Raycast(MouseDrag.MouseScreenRay, out rayHit, RaycastDistance, 1024) : Physics.SphereCast(MouseDrag.MouseScreenRay, sphereCastRadius, out rayHit, RaycastDistance, 1024))
			{
				return rayHit.collider.gameObject.GetComponentInParent<TGizmoAxisScript>();
			}
			return result;
		}

		protected void NotifyAdjustmentBeginning(bool? newAxis)
		{
			this.GizmoAdjustmentStarted?.Invoke(this, newAxis);
		}

		protected void NotifyAdjustmentEnded()
		{
			this.GizmoAdjustmentEnded?.Invoke(this, null);
		}

		protected void NotifyAdjustmentOccurred()
		{
			this.GizmoAdjusted?.Invoke(this, IsNewAxis);
		}

		protected virtual void OnOrientationChanged()
		{
			RecreateGizmos(playGizmoFlyoutSound: true);
		}

		protected virtual void ProcessGizmoClick(TGizmoAxisScript gizmo, RaycastHit rayHit, ClickEventArgs e)
		{
			IsPendingFirstDragEvent = true;
			GizmoBeingDragged = gizmo;
			this.GizmoClickDown?.Invoke(this, e);
		}

		protected virtual void ProcessGizmoDrag(ClickEventArgs e)
		{
			MouseDrag.ProcessMouseDrag(e);
			if (IsPendingFirstDragEvent)
			{
				IsPendingFirstDragEvent = false;
				ProcessMouseFirstDrag();
			}
		}

		protected virtual void ProcessGizmoDragEnd(GizmoAxisScript gizmo, ClickEventArgs e)
		{
			GizmoBeingDragged = null;
			this.GizmoClickUp?.Invoke(this, e);
			this.GizmoClicked?.Invoke(this, e);
		}

		protected virtual bool ShouldDragGizmo(TGizmoAxisScript gizmo, RaycastHit rayHit)
		{
			return true;
		}

		private static Transform CreateGizmosContainer(MovementGizmo<TGizmoAxisScript> gizmo, bool playGizmoFlyoutSound)
		{
			if (playGizmoFlyoutSound)
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.GizmoFlyout);
			}
			return new GameObject(gizmo.Name + "-GizmoContainer").transform;
		}

		private void MoveGizmosToNewParent(Transform newParent)
		{
			GizmosParent.SetParent(newParent, worldPositionStays: false);
			GizmosParent.localPosition = Vector3.zero;
			if (IsLocalOrientation)
			{
				GizmosParent.localRotation = Quaternion.identity;
			}
			else
			{
				GizmosParent.rotation = Quaternion.identity;
			}
			GizmosParent.localScale = Vector3.one;
			Vector3 lossyScale = GizmosParent.lossyScale;
			GizmosParent.localScale = new Vector3(1f / lossyScale.x, 1f / lossyScale.y, 1f / lossyScale.z);
		}

		private void ProcessFirstGizmoDrag()
		{
			IsNewAxis = GizmoBeingDragged != PreviousGizmoDragged && GizmoBeingDragged != null;
			NotifyAdjustmentBeginning(IsNewAxis);
			if (GizmoBeingDragged != null)
			{
				PreviousGizmoDragged = GizmoBeingDragged;
			}
		}

		private void ProcessMouseBegin(ClickEventArgs e)
		{
			if (e.IsTouchPrimary || Game.Instance.Settings.Game.MouseInputDesigner.CanSelectPart(e.InputButton))
			{
				MouseDrag.ProcessMouseBegin(e);
				RaycastHit rayHit;
				TGizmoAxisScript gizmoUnderMouse = GetGizmoUnderMouse(out rayHit);
				if (gizmoUnderMouse != null && gizmoUnderMouse.transform.parent == GizmosParent && ShouldDragGizmo(gizmoUnderMouse, rayHit))
				{
					ProcessGizmoClick(gizmoUnderMouse, rayHit, e);
				}
			}
		}

		private void ProcessMouseEnd(ClickEventArgs e)
		{
			if (IsAdjusting)
			{
				ProcessGizmoDragEnd(GizmoBeingDragged, e);
			}
			IsNewAxis = null;
		}

		private void ProcessMouseFirstDrag()
		{
			if (GizmoBeingDragged != null)
			{
				ProcessFirstGizmoDrag();
			}
		}

		private void RecreateGizmos(bool playGizmoFlyoutSound)
		{
			DestroyGizmos();
			CreateGizmos(playGizmoFlyoutSound);
		}
	}
}
