using System.Linq;
using Assets.Scripts.Craft.Parts;
using Shapes;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class DriveShaftStep : TutorialStep
	{
		private const float ArrowHeadLength = 0.15f;

		private const float ArrowHeadRadius = 0.06f;

		private const float ShaftThickness = 0.04f;

		private static readonly Color ArrowColor = new Color(0f, 0.85f, 0f, 0.5f);

		private Vector3 _arrowEnd;

		private Vector3 _arrowStart;

		private Camera _camera;

		private bool _drawArrow;

		private AttachPointScript _driveShaftAp;

		private int _driveShaftId;

		private AttachPointScript _targetAp;

		private int _targetId;

		public DriveShaftStep(TutorialStepBuilderContext context, string driveShaftPartName, string targetPartName, string stepText = null)
			: base(context, stepText)
		{
			_driveShaftId = context.GetPartIdByName(driveShaftPartName);
			_targetId = context.GetPartIdByName(targetPartName);
		}

		public void ClearArrow()
		{
			_drawArrow = false;
		}

		public void DrawArrow(Vector3 positionA, Vector3 positionB)
		{
			_arrowStart = positionA;
			_arrowEnd = positionB;
			_drawArrow = true;
		}

		protected override void OnEnd()
		{
			base.OnEnd();
			RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
			_camera = null;
			_drawArrow = false;
		}

		protected override void OnLateUpdate()
		{
			base.OnLateUpdate();
			ClearArrow();
			if (_driveShaftAp != null && _targetAp != null)
			{
				if (_driveShaftAp.AttachPoint.PartConnections.Count > 0)
				{
					CompleteStep();
				}
				else if (base.Designer.Designer.SelectedPart == _driveShaftAp.PartScript)
				{
					ClearHighlightedPart(_driveShaftAp.PartScript.Part);
					DrawArrow(_driveShaftAp.transform.position, _targetAp.transform.position);
					base.InstructionText = "Drag the end of the drive shaft to where the arrow is indicating.";
				}
				else
				{
					base.InstructionText = "Select the indicated part.";
					HighlightPart(_driveShaftAp.PartScript.Part);
				}
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			_camera = base.Designer.Designer.CameraController.Camera;
			RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
			PartData driveShaftPart = base.Designer.Aircraft.GetPartById(_driveShaftId, includeDisconnected: true);
			PartData targetPart = base.Designer.Aircraft.GetPartById(_targetId, includeDisconnected: true);
			PartConnection partConnection = driveShaftPart.PartConnections.Where((PartConnection x) => x.GetOtherPart(driveShaftPart) == targetPart).FirstOrDefault();
			_driveShaftAp = partConnection.AttachPointsA.FirstOrDefault((AttachPointData x) => x.AttachPointScript.PartScript == driveShaftPart.PartScript)?.AttachPointScript ?? partConnection.AttachPointsB.FirstOrDefault((AttachPointData x) => x.AttachPointScript.PartScript == driveShaftPart.PartScript)?.AttachPointScript;
			_targetAp = partConnection.AttachPointsA.FirstOrDefault((AttachPointData x) => x.AttachPointScript.PartScript == targetPart.PartScript)?.AttachPointScript ?? partConnection.AttachPointsB.FirstOrDefault((AttachPointData x) => x.AttachPointScript.PartScript == targetPart.PartScript)?.AttachPointScript;
			base.Designer.Designer.SelectedPart = null;
			if (_driveShaftAp != null)
			{
				_driveShaftAp.transform.position += new Vector3(-0.5f, 0f, -1f);
			}
			else
			{
				Debug.LogError("Could not find drive shaft AP");
			}
			if (_targetAp == null)
			{
				Debug.LogError("Could not find target AP");
			}
			partConnection.DestroyConnection(isSymmetryOperation: true, destroySymmetricConnections: true, raiseConnectionChangedEvents: false);
		}

		private void OnBeginCameraRendering(ScriptableRenderContext ctx, Camera cam)
		{
			if (!_drawArrow || cam != _camera)
			{
				return;
			}
			Vector3 vector = _arrowEnd - _arrowStart;
			float magnitude = vector.magnitude;
			if (magnitude < 0.001f)
			{
				return;
			}
			Vector3 vector2 = vector / magnitude;
			Vector3 vector3 = _arrowEnd - vector2 * 0.15f;
			using (Draw.Command(cam))
			{
				Draw.BlendMode = ShapesBlendMode.Transparent;
				Draw.Color = ArrowColor;
				Draw.SizeSpace = ThicknessSpace.Meters;
				Draw.ThicknessSpace = ThicknessSpace.Meters;
				Draw.Thickness = 0.04f;
				Draw.Line(_arrowStart, vector3);
				Draw.Cone(vector3, vector2, 0.06f, 0.15f, fillCap: true, ArrowColor);
			}
		}
	}
}
