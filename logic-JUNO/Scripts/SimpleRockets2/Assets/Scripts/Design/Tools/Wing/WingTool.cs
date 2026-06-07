using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using ModApi;
using ModApi.Audio;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Input.Events;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Wing
{
	public abstract class WingTool : DesignerToolBase
	{
		public const int AdjustmentPlanesLayer = 11;

		private const float AdjustmentPlaneSide = 10f;

		private const string ForwardAftRestrictedPlaneName = "ForwardAftRestrictedPlane";

		private const string GizmoAdjustmentPlaneShader = "Particles/Alpha Blended";

		private const string LaterallyRestrictedPlaneName = "LaterallyRestrictedPlane";

		private const string VerticallyRestrictedPlaneName = "VerticallyRestrictedPlane";

		private static AudioSource _resizeSound;

		private List<GameObject> _adjustmentPlanes = new List<GameObject>();

		private List<AdjustmentGizmoScript> _gizmos;

		private Vector3 _gizmoStartPosition;

		private Vector3? _initialHitPosition;

		private MouseInputSettingsDesigner _mouseInputSettings;

		private Vector2? _startingMousePos;

		private float _timeLastMouseMovement;

		private GameObject _verticallyRestrictedPlane;

		public override ICollection<IPartScript> ActiveParts
		{
			get
			{
				ICollection<IPartScript> collection = ((base.SelectedPart == null) ? null : new IPartScript[1] { base.SelectedPart });
				return collection ?? Array.Empty<IPartScript>();
			}
		}

		public GameObject ForwardAftRestrictedPlaneHitGizmo { get; set; }

		public bool GizmosActive => _gizmos.Count > 0;

		public GameObject LaterallyRestrictedPlaneHitGizmo { get; set; }

		public WingScript WingScript
		{
			get
			{
				if (base.Designer.SelectedPart != null)
				{
					return base.Designer.SelectedPart.GetModifier<WingScript>();
				}
				return null;
			}
		}

		protected AdjustmentGizmoScript AdjustmentGizmoBeingDragged { get; private set; }

		protected bool CanPlayResizeSound { get; set; }

		private GameObject ForwardAftRestrictedPlane { get; set; }

		private GameObject LaterallyRestrictedPlane { get; set; }

		public WingTool(DesignerScript designer)
			: base(designer)
		{
			_gizmos = new List<AdjustmentGizmoScript>();
			if (_resizeSound == null)
			{
				_resizeSound = Game.Instance.AudioPlayer.CreateAudioSource(AudioLibrary.Design.ResizeSampleLooped, null);
			}
			_resizeSound.loop = false;
			CanPlayResizeSound = true;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}

		public static bool IsAdjustmentGizmo(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			return gameObject.GetComponentInParent<AdjustmentGizmoScript>() != null;
		}

		public override void Activate()
		{
			base.Activate();
			_startingMousePos = null;
			_timeLastMouseMovement = 0f;
		}

		public override void Deactivate()
		{
			base.Deactivate();
			if (GizmosActive)
			{
				DestroyGizmos();
			}
			if (_resizeSound.isPlaying)
			{
				_resizeSound.Stop();
			}
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			bool flag = base.HandleClick(e);
			if (!_startingMousePos.HasValue)
			{
				_startingMousePos = e.Position;
				_timeLastMouseMovement = Time.time;
			}
			else if (_startingMousePos != e.Position)
			{
				_timeLastMouseMovement = Time.time;
			}
			Ray ray = base.Designer.DesignerCamera.ScreenPointToRay(e.Position);
			if (e.InputState == InputState.Begin && AdjustmentGizmoBeingDragged != null)
			{
				OnStopDraggingGizmo();
			}
			if (GizmosActive && Physics.Raycast(ray, out var hitInfo, 10000f, 3072))
			{
				GameObject gameObject = hitInfo.transform.gameObject;
				if (gameObject != null)
				{
					bool flag2 = e.IsTouchPrimary || _mouseInputSettings.CanSelectPart(e.InputButton);
					if (e.InputState == InputState.Begin && flag2)
					{
						if (IsAdjustmentGizmo(gameObject))
						{
							OnStartDraggingGizmo(gameObject);
						}
						else if (AdjustmentGizmoBeingDragged == null)
						{
							ray.origin = hitInfo.point + ray.direction * 0.01f;
							if (Physics.Raycast(ray, out hitInfo, 10000f, 3072))
							{
								gameObject = hitInfo.transform.gameObject;
							}
							if (IsAdjustmentGizmo(gameObject))
							{
								OnStartDraggingGizmo(gameObject);
							}
						}
					}
					else if (e.InputState == InputState.End)
					{
						if (AdjustmentGizmoBeingDragged != null)
						{
							OnStopDraggingGizmo();
						}
					}
					else if (e.InputState == InputState.Updated && AdjustmentGizmoBeingDragged != null)
					{
						while (gameObject != null && gameObject.GetComponent<AdjustmentPlaneScript>() == null)
						{
							ray.origin = hitInfo.point + ray.direction * 0.01f;
							gameObject = ((!Physics.Raycast(ray, out hitInfo, 10000f, 3072)) ? null : hitInfo.transform.gameObject);
						}
						if (gameObject != null)
						{
							AdjustmentGizmoScript adjustmentGizmoBeingDragged = AdjustmentGizmoBeingDragged;
							if (IsCorrectAdjustmentPlaneForGizmo(gameObject))
							{
								MoveAdjustmentGizmo(gameObject, adjustmentGizmoBeingDragged, hitInfo);
							}
						}
					}
				}
			}
			if (!flag)
			{
				return AdjustmentGizmoBeingDragged != null;
			}
			return true;
		}

		public void HideGizmos()
		{
			DestroyGizmos();
		}

		public override void OnCapturedToolChanged(DesignerTool designerTool)
		{
			if (designerTool == base.DesignerScript.MovePartTool)
			{
				DestroyGizmos();
			}
			else if (!GizmosActive)
			{
				CreateGizmos();
			}
		}

		public override void SelectedPartChanged(IPartScript newPart, RaycastHit? hit, bool justAdded)
		{
			base.SelectedPartChanged(newPart, hit, justAdded);
			if (!base.Designer.IsToolActive<MovementTool>())
			{
				CheckCanEdit(newPart, hit);
			}
		}

		public override void SelectedPartClicked(IPartScript selectedPart, RaycastHit? hit)
		{
			base.SelectedPartClicked(selectedPart, hit);
			CheckCanEdit(selectedPart, hit);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.Active)
			{
				if (_timeLastMouseMovement + 0.05f < Time.time)
				{
					OnMouseStoppedMoving();
				}
				if (!CanPlayResizeSound && _resizeSound.isPlaying)
				{
					_resizeSound.Stop();
				}
			}
		}

		internal bool IsDraggingGizmo()
		{
			return AdjustmentGizmoBeingDragged != null;
		}

		protected abstract bool CanEditPart(IPartScript part, RaycastHit? hit);

		protected void CreateAdjustmentGizmo(Transform parent, Vector3 gizmoFlyoutDirection, bool restrictForwardAftMovement, bool restrictLateralMovement, bool restrictVerticalMovement, Action<Vector3> updateWorldPosition, Func<Vector3> getWorldPosition, Action onGizmoMoveStarted = null, Action onGizmoMoveCompleted = null, Color? colorOverride = null)
		{
			Color color = Constants.Colors.Primary.Gamma;
			if (colorOverride.HasValue)
			{
				color = colorOverride.Value;
			}
			AdjustmentGizmoScript component = CreateGizmo(parent, color, gizmoFlyoutDirection).GetComponent<AdjustmentGizmoScript>();
			component.RestrictForwardAftMovement = restrictForwardAftMovement;
			component.RestrictLateralMovement = restrictLateralMovement;
			component.RestrictVerticalMovement = restrictVerticalMovement;
			component.UpdateTargetWorldPosition = updateWorldPosition;
			component.GetTargetWorldPosition = getWorldPosition;
			component.OnGizmoMoveStarted = onGizmoMoveStarted;
			component.OnGizmoMoveCompleted = onGizmoMoveCompleted;
			component.RefreshPosition();
			_gizmos.Add(component);
		}

		protected abstract void CreateGizmos();

		protected void DestroyGizmos()
		{
			foreach (AdjustmentGizmoScript gizmo in _gizmos)
			{
				if (gizmo != null)
				{
					gizmo.OnDestroy();
					UnityEngine.Object.Destroy(gizmo.gameObject);
				}
			}
			AdjustmentGizmoBeingDragged = null;
			_initialHitPosition = null;
			_gizmos.Clear();
		}

		protected virtual void MoveAdjustmentGizmo(GameObject planeHit, AdjustmentGizmoScript gizmoScript, RaycastHit rayHit)
		{
			Vector3 newGizmoPosition = GetNewGizmoPosition(planeHit, gizmoScript, rayHit);
			gizmoScript.UpdateTargetWorldPosition(newGizmoPosition);
			Symmetry.SynchronizePartModifiers(WingScript.PartScript);
			RefreshGizmoPositions();
		}

		protected virtual void OnStartDraggingGizmo(GameObject gizmoObject)
		{
			AdjustmentGizmoBeingDragged = gizmoObject.GetComponentInParent<AdjustmentGizmoScript>();
			AdjustmentGizmoBeingDragged.AdjustmentGizmoMeshScript.IsSelected = true;
			AddAdjustmentPlanesThroughGizmo(AdjustmentGizmoBeingDragged.gameObject);
			_gizmoStartPosition = AdjustmentGizmoBeingDragged.GizmoBase.transform.position;
			_initialHitPosition = null;
			AdjustmentGizmoBeingDragged.GetComponentInChildren<Collider>().enabled = false;
			AdjustmentGizmoBeingDragged.OnGizmoMoveStarted?.Invoke();
		}

		protected virtual void OnStopDraggingGizmo()
		{
			AdjustmentGizmoBeingDragged.OnGizmoMoveCompleted?.Invoke();
			AdjustmentGizmoBeingDragged.AdjustmentGizmoMeshScript.IsSelected = false;
			base.DesignerScript.CreateUndoStep();
			AdjustmentGizmoBeingDragged.GetComponentInChildren<Collider>().enabled = true;
			AdjustmentGizmoBeingDragged = null;
			DestroyAdjustmentPlanes();
			OnMouseStoppedMoving();
			base.DesignerScript.CraftScript.SetStructureChanged();
		}

		protected void RefreshGizmoPositions()
		{
			foreach (AdjustmentGizmoScript gizmo in _gizmos)
			{
				Vector3 position = gizmo.transform.position;
				gizmo.RefreshPosition();
				if (!Utilities.CompareVector3s(position, gizmo.transform.position))
				{
					PlayMovedSound();
				}
			}
		}

		private static bool IsCorrectAdjustmentPlaneForGizmo(GameObject gameObjectToCheck)
		{
			if (!(gameObjectToCheck.name == "VerticallyRestrictedPlane") && !(gameObjectToCheck.name == "LaterallyRestrictedPlane"))
			{
				return gameObjectToCheck.name == "ForwardAftRestrictedPlane";
			}
			return true;
		}

		private GameObject AddAdjustmentPlane(GameObject objectToParentTo, string adjustmentPlaneName, Vector3 up, Vector3 right)
		{
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
			gameObject.name = adjustmentPlaneName;
			gameObject.transform.parent = objectToParentTo.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.forward = up;
			gameObject.transform.up = right;
			UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<MeshCollider>());
			gameObject.AddComponent<BoxCollider>();
			gameObject.transform.localScale = new Vector3(10f, 10f, 10f);
			gameObject.layer = 11;
			_adjustmentPlanes.Add(gameObject);
			Renderer component = gameObject.GetComponent<Renderer>();
			component.material.shader = Shader.Find("Particles/Alpha Blended");
			component.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.3f));
			gameObject.AddComponent<AdjustmentPlaneScript>();
			component.enabled = false;
			return gameObject;
		}

		private void AddAdjustmentPlanesThroughGizmo(GameObject gizmoGameObject)
		{
			AdjustmentGizmoScript componentInParent = gizmoGameObject.GetComponentInParent<AdjustmentGizmoScript>();
			foreach (GameObject adjustmentPlane in _adjustmentPlanes)
			{
				UnityEngine.Object.Destroy(adjustmentPlane);
			}
			_adjustmentPlanes.Clear();
			if (componentInParent.RestrictVerticalMovement)
			{
				_verticallyRestrictedPlane = AddAdjustmentPlane(gizmoGameObject, "VerticallyRestrictedPlane", gizmoGameObject.transform.parent.up, gizmoGameObject.transform.parent.right);
			}
			if (componentInParent.RestrictLateralMovement)
			{
				GameObject gameObject = gizmoGameObject.transform.parent.parent.gameObject;
				LaterallyRestrictedPlane = AddAdjustmentPlane(gizmoGameObject, "LaterallyRestrictedPlane", gizmoGameObject.transform.parent.right, gizmoGameObject.transform.parent.up);
				LaterallyRestrictedPlane.transform.parent = gameObject.transform;
			}
			if (componentInParent.RestrictForwardAftMovement)
			{
				ForwardAftRestrictedPlane = AddAdjustmentPlane(gizmoGameObject, "ForwardAftRestrictedPlane", gizmoGameObject.transform.parent.up, gizmoGameObject.transform.parent.forward);
			}
		}

		private void CheckCanEdit(IPartScript part, RaycastHit? hit)
		{
			if (part != null && (bool)Game.Instance.Settings.Game.Designer.EnableGizmos && CanEditPart(part, hit))
			{
				if (base.Active)
				{
					base.Designer.DeselectTool(this);
				}
				base.Designer.SelectTool(this);
			}
			else if (base.Active)
			{
				base.Designer.DeselectTool(this);
			}
		}

		private AdjustmentGizmoScript CreateGizmo(Transform parent, Color color, Vector3 gizmoFlyoutDirection)
		{
			IPartScript componentInParent = parent.GetComponentInParent<IPartScript>();
			AdjustmentGizmoMeshScript adjustmentGizmoMeshScript = AdjustmentGizmoMeshScript.Create(parent, gizmoFlyoutDirection, 1.5f, screenSizeConstant: true, base.Designer.DesignerCamera.Camera, color);
			AdjustmentGizmoScript adjustmentGizmoScript = adjustmentGizmoMeshScript.gameObject.AddComponent<AdjustmentGizmoScript>();
			adjustmentGizmoScript.AdjustmentGizmoMeshScript = adjustmentGizmoMeshScript;
			adjustmentGizmoScript.GizmoBase = adjustmentGizmoMeshScript.gameObject;
			adjustmentGizmoScript.GizmoFlyoutDirection = gizmoFlyoutDirection;
			adjustmentGizmoScript.GizmoFlyoutScalar = 0f;
			adjustmentGizmoScript.WingRoot = componentInParent.Transform;
			return adjustmentGizmoScript;
		}

		private void DestroyAdjustmentPlanes()
		{
			foreach (GameObject adjustmentPlane in _adjustmentPlanes)
			{
				UnityEngine.Object.Destroy(adjustmentPlane);
			}
			_adjustmentPlanes.Clear();
		}

		private Vector3 GetNewGizmoPosition(GameObject planeHit, AdjustmentGizmoScript gizmoScript, RaycastHit rayHit)
		{
			int num = (gizmoScript.RestrictForwardAftMovement ? 1 : 0) + (gizmoScript.RestrictLateralMovement ? 1 : 0) + (gizmoScript.RestrictVerticalMovement ? 1 : 0);
			Vector3 vector = Vector3.zero;
			switch (num)
			{
			case 1:
				vector = rayHit.point;
				break;
			case 2:
				if (gizmoScript.RestrictLateralMovement && gizmoScript.RestrictVerticalMovement)
				{
					if (planeHit == _verticallyRestrictedPlane)
					{
						vector = Math3d.ProjectPointOnPlane(LaterallyRestrictedPlane.transform.up, LaterallyRestrictedPlane.transform.position, rayHit.point);
					}
					else if (planeHit == LaterallyRestrictedPlane)
					{
						vector = Math3d.ProjectPointOnPlane(_verticallyRestrictedPlane.transform.up, _verticallyRestrictedPlane.transform.position, rayHit.point);
					}
				}
				else if (gizmoScript.RestrictForwardAftMovement && gizmoScript.RestrictLateralMovement)
				{
					UnityEngine.Object.Destroy(ForwardAftRestrictedPlaneHitGizmo);
					UnityEngine.Object.Destroy(LaterallyRestrictedPlaneHitGizmo);
					if (planeHit == ForwardAftRestrictedPlane)
					{
						vector = Math3d.ProjectPointOnPlane(LaterallyRestrictedPlane.transform.up.normalized, LaterallyRestrictedPlane.transform.position, rayHit.point);
					}
					else if (planeHit == LaterallyRestrictedPlane)
					{
						vector = Math3d.ProjectPointOnPlane(ForwardAftRestrictedPlane.transform.up.normalized, ForwardAftRestrictedPlane.transform.position, rayHit.point);
					}
				}
				else if (gizmoScript.RestrictForwardAftMovement && gizmoScript.RestrictVerticalMovement)
				{
					if (planeHit == ForwardAftRestrictedPlane)
					{
						vector = Math3d.ProjectPointOnPlane(_verticallyRestrictedPlane.transform.up.normalized, _verticallyRestrictedPlane.transform.position, rayHit.point);
					}
					else if (planeHit == _verticallyRestrictedPlane)
					{
						vector = Math3d.ProjectPointOnPlane(ForwardAftRestrictedPlane.transform.up.normalized, ForwardAftRestrictedPlane.transform.position, rayHit.point);
					}
				}
				break;
			default:
				_ = 3;
				break;
			}
			if (!_initialHitPosition.HasValue)
			{
				_initialHitPosition = vector;
			}
			Vector3 vector2 = vector - _initialHitPosition.Value;
			return _gizmoStartPosition + vector2;
		}

		private void OnMouseStoppedMoving()
		{
			if (_resizeSound != null)
			{
				_resizeSound.Stop();
			}
		}

		private void PlayMovedSound()
		{
			if (_resizeSound != null && !_resizeSound.isPlaying && IsDraggingGizmo() && CanPlayResizeSound)
			{
				_resizeSound.Play();
			}
		}
	}
}
