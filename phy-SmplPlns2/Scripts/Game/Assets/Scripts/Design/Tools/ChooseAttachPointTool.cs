using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class ChooseAttachPointTool : DesignerTool
	{
		private Action<AttachPointData> _callback;

		private Material _hiddenSelectedMaterial;

		private AttachPointGizmo _selected;

		private List<AttachPointData> _visibleAttachPoints = new List<AttachPointData>();

		public ChooseAttachPointTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowFingerAid = true;
			base.AllowPartSelection = false;
			_hiddenSelectedMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerPartHiddenSelected");
		}

		public override void HandleInput(InputEvent e)
		{
			if (!base.Designer.FingerAidEnabled && e.InputState == InputState.End && e.InputButton == InputButton.Primary && e.DeltaPositionSinceBegin == Vector2.zero)
			{
				AttachPointGizmo attachPointGizmo = RaycastToAttachPoint(e.Position);
				if (attachPointGizmo != null)
				{
					attachPointGizmo.Highlighted = false;
					_callback(attachPointGizmo.AttachPoint);
					base.Designer.Tools.SelectMovePartTool();
				}
			}
			base.HandleInput(e);
		}

		public AttachPointGizmo RaycastToAttachPoint(Vector2 screenPos)
		{
			if (Physics.Raycast(base.CameraController.Camera.ScreenPointToRay(screenPos), out var hitInfo, 10000f, 1024) && hitInfo.transform.TryGetComponent<AttachPointGizmo>(out var component))
			{
				return component;
			}
			return null;
		}

		public void Setup(PartData part, Action<AttachPointData> callback, Func<AttachPointData, bool> filter)
		{
			_selected = null;
			_callback = callback;
			base.Designer.GhostViewEnabled = true;
			part.PartScript.PartMaterialScript.OverrideMaterial = _hiddenSelectedMaterial;
			foreach (AttachPointData attachPoint in part.AttachPoints)
			{
				if (filter(attachPoint))
				{
					CreateGizmo(attachPoint);
				}
			}
		}

		public override void Start()
		{
			base.Start();
			base.Designer.DisableMovePart = true;
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: true);
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked += OnDoneEditingButtonClicked;
		}

		public override void Stop()
		{
			base.Stop();
			base.Designer.DisableMovePart = base.Designer.FingerAidEnabled;
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: false);
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked -= OnDoneEditingButtonClicked;
			foreach (PartData part in base.Designer.Aircraft.Parts)
			{
				part.PartScript.PartMaterialScript.OverrideMaterial = null;
			}
			base.Designer.GhostViewEnabled = false;
			foreach (AttachPointData visibleAttachPoint in _visibleAttachPoints)
			{
				visibleAttachPoint.AttachPointScript.ShowGizmo(show: false);
			}
			_visibleAttachPoints.Clear();
		}

		public override void Update()
		{
			Vector2 screenPos = ((!base.Designer.FingerAidEnabled) ? ((Vector2)UnityEngine.Input.mousePosition) : base.Designer.DesignerScript.DesignerUI.FingerTool.Position);
			AttachPointGizmo attachPointGizmo = RaycastToAttachPoint(screenPos);
			if (_selected != attachPointGizmo)
			{
				if (_selected != null)
				{
					_selected.Highlighted = false;
				}
				_selected = attachPointGizmo;
				if (attachPointGizmo != null)
				{
					attachPointGizmo.Highlighted = true;
				}
			}
		}

		private void CreateGizmo(AttachPointData attachPoint)
		{
			attachPoint.AttachPointScript.ShowGizmo(show: true);
			_visibleAttachPoints.Add(attachPoint);
		}

		private void OnDoneEditingButtonClicked()
		{
			_callback(_selected?.AttachPoint);
			_selected = null;
			base.Designer.Tools.SelectMovePartTool();
		}
	}
}
