using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.UI.Wings;
using Assets.Scripts.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class TranslateTool : TransformTool
	{
		private float _gridSize;

		private bool _updatePaintOrigin;

		public float GridSize { get; set; }

		protected override float BaseToolScale => 0.015f;

		protected override string ToolPrefabName => "TranslateTool";

		public TranslateTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Stop()
		{
			(base.SelectedAxis as WingGizmoScript)?.OnDragEnd();
			base.Stop();
		}

		protected override float CalculateScale()
		{
			return 1f;
		}

		protected override void ProcessMouseDrag(InputEvent e)
		{
			if (base.PartSelection.Parts.Count == 1 && !base.PartSelection.Parts[0].Part.AllowTransformation)
			{
				PartData part = base.PartSelection.Parts[0].Part;
				base.Designer.DesignerScript.DesignerUI.ShowMessage("The '" + part.Name + "' part cannot be translated at this time.");
			}
			else
			{
				(base.SelectedAxis as WingGizmoScript).OnDragContinue(e.Ray);
			}
		}

		protected override void ProcessMouseEnd(InputEvent e)
		{
			if ((base.SelectedAxis as WingGizmoScript).OnDragEnd())
			{
				base.Designer.CreateUndoStepForSelectedPart("Translated");
			}
		}

		protected override void ProcessMouseStart(InputEvent e)
		{
			(base.SelectedAxis as WingGizmoScript).OnDragStart(e.Ray);
		}

		protected override void SetTransform(Transform transform)
		{
			base.SetTransform(transform);
			if (transform != null)
			{
				_updatePaintOrigin = base.InConnectedMode && base.PartSelection.Parts.FirstOrDefault()?.Part.GetModifier<CockpitData>()?.PrimaryCockpit == true;
				ConfigureGizmo("Forward", Constants.Colors.AxisForward, Vector3.forward, Vector3.up);
				ConfigureGizmo("Up", Constants.Colors.AxisUp, Vector3.up, Vector3.right);
				ConfigureGizmo("Right", Constants.Colors.AxisRight, Vector3.right, Vector3.up);
			}
		}

		private void ConfigureGizmo(string gizmoName, Color color, Vector3 primaryAxis, Vector3 secondaryAxis)
		{
			WingGizmoScript component = base.ToolObject.transform.Find(gizmoName).GetComponent<WingGizmoScript>();
			if (!base.Gizmos.Contains(component))
			{
				base.Gizmos.Add(component);
			}
			component.GridSize = () => GridSize;
			component.ResetTime();
			component.Configure(() => base.SelectedTransform.position, delegate(Vector3 p)
			{
				if (_updatePaintOrigin)
				{
					Vector3 value = p - base.SelectedTransform.position;
					base.Designer.UpdatePaintOrigin(value);
				}
				base.SelectedTransform.position = p;
				if (base.TrackedTransform != null)
				{
					base.TrackedTransform.hasChanged = false;
				}
				SyncSymmetricTransforms();
			}, () => base.SelectedTransform.TransformDirection(primaryAxis), () => base.SelectedTransform.TransformDirection(secondaryAxis), secondaryFree: false, color);
		}
	}
}
