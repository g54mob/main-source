using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.UI.Wings;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public abstract class WingTool : DesignerTool
	{
		private Vector3 _backupCameraPosition;

		private WingGizmoScript _draggingGizmo;

		private GameObject _gizmoPrefab;

		private List<WingGizmoScript> _gizmos = new List<WingGizmoScript>();

		private WingGizmoScript _hoverGizmo;

		private List<List<AttachPointScript>> _pylonAttachPoints = new List<List<AttachPointScript>>();

		private IFlyout _selectedFlyout;

		private WingGizmoScript HoverGizmo
		{
			get
			{
				return _hoverGizmo;
			}
			set
			{
				if (_hoverGizmo != value)
				{
					if (_hoverGizmo != null)
					{
						_hoverGizmo.Highlighted = false;
					}
					_hoverGizmo = value;
					if (_hoverGizmo != null)
					{
						_hoverGizmo.Highlighted = true;
					}
				}
			}
		}

		private WingScript WingScript
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

		public WingTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowFingerAid = false;
			_gizmoPrefab = Resources.Load<GameObject>("Designer/JWingGizmo");
		}

		public override void HandleInput(InputEvent e)
		{
			if (e.InputButton != InputButton.Primary)
			{
				base.HandleInput(e);
				return;
			}
			bool flag = UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl);
			if (e.InputState == InputState.Begin && !flag)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragEnd();
					_draggingGizmo = null;
				}
				if (Physics.Raycast(e.Ray, out var hitInfo, float.PositiveInfinity, 1024))
				{
					WingGizmoScript componentInParent = hitInfo.transform.GetComponentInParent<WingGizmoScript>();
					if (componentInParent != null)
					{
						componentInParent.OnDragStart(e.Ray);
						base.PartScript.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: true);
						_draggingGizmo = componentInParent;
						DisconnectPylons();
						base.AllowPartSelection = false;
						return;
					}
				}
			}
			else if (e.InputState == InputState.Updated)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragContinue(e.Ray);
					return;
				}
			}
			else if (e.InputState == InputState.End && _draggingGizmo != null)
			{
				_draggingGizmo.OnDragEnd();
				base.PartScript.PartMaterialScript.SetSelected(selected: true, updateSymmetricParts: true);
				int num = _gizmos.IndexOf(_draggingGizmo);
				_draggingGizmo = null;
				ReconnectPylons();
				base.Designer.CreateUndoStepForSelectedPart("Modified Legacy Wing", $"WingToolHandle-{num}");
				base.AllowPartSelection = true;
			}
			base.HandleInput(e);
		}

		public bool IsDraggingGizmo()
		{
			return _draggingGizmo != null;
		}

		public override void MouseHover(Vector3? screenPosition)
		{
			if (screenPosition.HasValue)
			{
				Ray ray = base.CameraController.Camera.ScreenPointToRay(screenPosition.Value);
				HoverGizmo = JWingTool.GetGizmo(ray);
			}
			base.MouseHover((HoverGizmo == null) ? screenPosition : ((Vector3?)null));
		}

		public override void Start()
		{
			base.Start();
			DrawGizmos();
			base.Designer.GhostViewEnabled = true;
			_backupCameraPosition = Camera.main.transform.position;
			_selectedFlyout = base.Designer.DesignerScript.DesignerUI.Flyouts.Selected;
			base.Designer.DesignerScript.DesignerUI.Flyouts.Selected = null;
			base.Designer.DisableMovePart = true;
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: true);
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked += OnDoneEditingWingTool;
		}

		public override void Stop()
		{
			base.Stop();
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked -= OnDoneEditingWingTool;
			base.Designer.DisableMovePart = false;
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: false);
			DestroyGizmos();
			base.Designer.GhostViewEnabled = false;
			MoveObjectScript component = Camera.main.GetComponent<MoveObjectScript>();
			component.ResetPanning();
			component.DestinationPanPosition = _backupCameraPosition;
			component.DestinationPanUp = Vector3.up;
			component.TimeToFinishPanning = 0.65f;
			component.TimeToFinishPanningReset = 0.65f;
			component.IsInterruptable = false;
			component.PanningFocus = DesignerScript.DefaultCameraTarget.transform.position;
		}

		protected void CreateAdjustmentGizmo(Transform parent, Vector3 primaryAxis, Vector3 secondaryAxis, bool secondaryFree, Action<Vector3> updateWorldPosition, Func<Vector3> getWorldPosition, WingGizmoScript.HandleOrientation handleOrientation = WingGizmoScript.HandleOrientation.Default)
		{
			parent.InverseTransformPoint(getWorldPosition());
			WingGizmoScript component = UnityEngine.Object.Instantiate(_gizmoPrefab).GetComponent<WingGizmoScript>();
			component.Configure(() => getWorldPosition(), delegate(Vector3 p)
			{
				updateWorldPosition(p);
			}, () => primaryAxis, () => secondaryAxis, secondaryFree, null, handleOrientation);
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStartGizmoTool);
			_gizmos.Add(component);
		}

		protected void DestroyGizmos()
		{
			foreach (WingGizmoScript gizmo in _gizmos)
			{
				gizmo.transform.parent = null;
				UnityEngine.Object.Destroy(gizmo.gameObject);
			}
			_gizmos.Clear();
		}

		protected abstract void DrawGizmos();

		protected override void SelectedPartChanged(PartScript newPart)
		{
			base.SelectedPartChanged(newPart);
			DestroyGizmos();
			if (newPart == null)
			{
				base.Designer.Tools.SelectMovePartTool();
			}
			else
			{
				DrawGizmos();
			}
		}

		private void DisconnectPylons()
		{
			if (!(WingScript != null))
			{
				return;
			}
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				WingScript.PartScript.Aircraft.Aircraft.Assembly.GetSymmetricParts(WingScript.PartScript.Part, value);
				if (value.Count == 0)
				{
					value.Add(WingScript.PartScript.Part);
				}
				for (int i = 0; i < value.Count; i++)
				{
					PartData partData = value[i];
					List<AttachPointScript> list = ((_pylonAttachPoints.Count <= i) ? null : _pylonAttachPoints[i]);
					if (list == null)
					{
						_pylonAttachPoints.Add(list = new List<AttachPointScript>());
					}
					list.Clear();
					PartConnection[] array = partData.PartConnections.ToArray();
					foreach (PartConnection partConnection in array)
					{
						if (partConnection.GetOtherPart(partData).PartType.PartTypeId.StartsWith("Pylon-"))
						{
							AttachPointScript attachPointScript = partConnection.AttachPointsA[0].AttachPointScript;
							AttachPointScript attachPointScript2 = partConnection.AttachPointsB[0].AttachPointScript;
							AttachPointScript item = ((attachPointScript == partData.PartScript) ? attachPointScript2 : attachPointScript);
							list.Add(item);
							partConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
						}
					}
				}
			}
		}

		private void OnDoneEditingWingTool()
		{
			base.Designer.Tools.SelectMovePartTool();
			base.Designer.DesignerScript.DesignerUI.Flyouts.Selected = _selectedFlyout;
		}

		private void ReconnectPylons()
		{
			List<AttachPointScript> value;
			using (CollectionPool<List<AttachPointScript>, AttachPointScript>.Get(out value))
			{
				foreach (List<AttachPointScript> pylonAttachPoint in _pylonAttachPoints)
				{
					foreach (AttachPointScript item in pylonAttachPoint)
					{
						if (item.AttachPoint.IsAvailable)
						{
							value.Add(item);
							MovePartTool.DetectAttachPointConnectionsAndConnect(value, item.PartScript.gameObject, connectSymmetricParts: true, autoConcealSymmetricParts: true);
							value.Clear();
						}
					}
					pylonAttachPoint.Clear();
				}
			}
		}
	}
}
