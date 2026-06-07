using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Demo;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class DesignerTools
	{
		private Designer _designer;

		public ChooseAttachPointTool ChooseAttachPointTool { get; }

		public ChoosePartTool ChoosePartTool { get; }

		public ColorTool ColorTool { get; }

		public ControlSurfaceTool ControlSurfaceTool { get; }

		public FuselageTool FuselageTool { get; }

		public bool IsColorToolSelected => SelectedTool == ColorTool;

		public JFuselageTool JFuselageTool { get; }

		public JWingTool JWingTool { get; }

		public MovePartTool MovePartTool { get; }

		public RotateTool RotateTool { get; }

		public DesignerTool SelectedTool { get; private set; }

		public ShareAircraftTool ShareAircraftTool { get; }

		public TranslateTool TranslateTool { get; }

		public TrapezoidShapeTool TrapezoidShapeTool { get; }

		public ViewTool ViewTool { get; }

		public WingAdjustmentTool WingAdjustmentTool { get; }

		public event EventHandler<ToolChangedEventArgs> SelectedToolChanged;

		public DesignerTools(Designer designer)
		{
			_designer = designer;
			MovePartTool = new MovePartTool(designer, designer.CameraController);
			ChoosePartTool = new ChoosePartTool(designer, designer.CameraController);
			ChooseAttachPointTool = new ChooseAttachPointTool(designer, designer.CameraController);
			ColorTool = new ColorTool(designer, designer.CameraController);
			FuselageTool = new FuselageTool(designer, designer.CameraController);
			WingAdjustmentTool = new WingAdjustmentTool(designer, designer.CameraController);
			JWingTool = new JWingTool(designer, designer.CameraController);
			JFuselageTool = new JFuselageTool(designer, designer.CameraController);
			ControlSurfaceTool = new ControlSurfaceTool(designer, designer.CameraController);
			ShareAircraftTool = new ShareAircraftTool(designer, designer.CameraController);
			RotateTool = new RotateTool(designer, designer.CameraController);
			TranslateTool = new TranslateTool(designer, designer.CameraController);
			TrapezoidShapeTool = new TrapezoidShapeTool(designer, designer.CameraController);
			ViewTool = new ViewTool(designer, designer.CameraController);
			SelectTool(MovePartTool);
		}

		public void AddPart(DesignerPart designerPart, Vector2 position)
		{
			PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
			partCreationInfo.CreateHingeJoints = false;
			partCreationInfo.IsRigidBodyKinematic = true;
			partCreationInfo.CreateRigidBody = false;
			partCreationInfo.EnableWingScript = false;
			Assembly assembly = new Assembly(designerPart.AssemblyElement, 23, CraftLoadContext.Designer);
			if (_designer.Symmetry.SymmetryDisabledForNewParts)
			{
				foreach (PartData part in assembly.Parts)
				{
					part.SymmetryDisabled = true;
				}
			}
			assembly.CreateGameObjects(_designer.Aircraft, partCreationInfo, _designer.Aircraft.Children);
			Ray ray = _designer.ScreenPointToRay(position);
			float num = Mathf.Max(1f, Vector3.Dot(_designer.CameraController.TargetPosition - ray.origin, ray.direction));
			Vector3 partPosition = ray.origin + ray.direction * num;
			List<PartScript> list = new List<PartScript>();
			foreach (PartData part2 in assembly.Parts)
			{
				list.Add(part2.PartScript);
				part2.PartScript.OnPartAdded();
			}
			if (_designer.CameraController.Camera.transform.position.x < _designer.Aircraft.MainCockpit.transform.position.x && list.Count == 1)
			{
				PartScript partScript = list[0];
				if (partScript.Part.InitialRotationMirrored.HasValue)
				{
					partScript.transform.rotation = Quaternion.Euler(partScript.Part.InitialRotationMirrored.Value);
				}
			}
			if (list.Count == 1)
			{
				list[0].transform.position -= list[0].transform.TransformPoint(list[0].Part.CenterOfMass);
			}
			_designer.SelectedPart = ((assembly.Parts.Count > 0) ? assembly.Parts[0].PartScript : null);
			_designer.Aircraft.Aircraft.Assembly.Absorb(assembly);
			SelectTool(MovePartTool);
			MovePartTool.AddingNewParts(list, partPosition, num);
		}

		public void EditControlSurface(ControlSurfaceScript controlSurface, List<ControlSurfaceScript> symmetricControlSurfaces)
		{
			if (SelectTool(ControlSurfaceTool))
			{
				ControlSurfaceTool.ControlSurface = controlSurface;
				ControlSurfaceTool.SymmetricControlSurfaces = symmetricControlSurfaces;
			}
		}

		public void EditDihedral()
		{
			if (SelectTool(WingAdjustmentTool))
			{
				WingAdjustmentTool.CurrentEditType = WingAdjustmentTool.EditType.Dihedral;
			}
		}

		public void EndAttachmentEditorTool()
		{
			SelectTool(MovePartTool);
		}

		public void OnAircraftStructureChanged()
		{
			SelectedTool.AircraftStructureChanged();
			UpdateToolInformationDisplay();
		}

		public void SelectChooseAttachPointTool(PartData part, Action<AttachPointData> callback, Func<AttachPointData, bool> filter)
		{
			if (SelectTool(ChooseAttachPointTool))
			{
				ChooseAttachPointTool.Setup(part, callback, filter);
			}
		}

		public void SelectChoosePartTool(Func<PartData, bool> partFilter, bool connectedToSelectedPart, int selectedPartId, string zeroChoicesMessage, Action<PartData> callback, bool waitForDoneClicked = true)
		{
			if (SelectTool(ChoosePartTool))
			{
				ChoosePartTool.Setup(partFilter, connectedToSelectedPart, selectedPartId, zeroChoicesMessage, callback, waitForDoneClicked);
			}
		}

		public void SelectJWingAdjustmentTool()
		{
			SelectTool(JWingTool);
		}

		public void SelectMovePartTool()
		{
			SelectTool(MovePartTool);
		}

		public void SelectShareAircraftTool()
		{
			SelectTool(ShareAircraftTool);
		}

		public bool SelectTool(DesignerTool tool)
		{
			bool result = true;
			if (Device.IsDemoBuild)
			{
				if (tool == MovePartTool)
				{
					tool = ViewTool;
				}
				if (tool != ViewTool && tool != ColorTool)
				{
					Game.Instance.UserInterface.CreateMessageDialog(DemoMessages.ToolNotAvailable(tool), "Not Available In Demo");
					tool = ViewTool;
					result = false;
				}
			}
			if (SelectedTool != tool)
			{
				DesignerTool selectedTool = SelectedTool;
				if (SelectedTool != null)
				{
					SelectedTool.Stop();
				}
				if (_designer.SelectedPart != null)
				{
					_designer.SelectedPart.PartMaterialScript.SetSelected(tool.ShowSelectionHighlight, updateSymmetricParts: true);
				}
				SelectedTool = tool;
				SelectedTool.Start();
				UpdateToolInformationDisplay();
				this.SelectedToolChanged?.Invoke(this, new ToolChangedEventArgs(selectedTool, tool));
			}
			return result;
		}

		public void SelectWingAdjustmentTool()
		{
			if (SelectTool(WingAdjustmentTool))
			{
				WingAdjustmentTool.CurrentEditType = WingAdjustmentTool.EditType.Shape;
			}
		}

		public void StartFuselageTool()
		{
			if (SelectTool(FuselageTool))
			{
				_designer.DesignerScript.DesignerUI.Flyouts.Selected = _designer.DesignerScript.DesignerUI.Flyouts.FuselageShape;
			}
		}

		public void Update()
		{
			SelectedTool.Update();
		}

		public void UpdateToolInformationDisplay()
		{
			_designer.DesignerScript.DesignerUI.SetAircraftInformationDisplay(SelectedTool.GetAircraftInformationDisplay());
		}
	}
}
