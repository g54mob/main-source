using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Wing
{
	public class ControlSurfaceTool : WingTool
	{
		private Collider[] _canEditOverlapTestResult = new Collider[10];

		private ControlSurfaceScript _controlSurfaceScript;

		private ControlSurfaceScript _pendingControlSurface;

		public Vector3 HingePosition
		{
			get
			{
				WingScript wingScript = _controlSurfaceScript.WingScript;
				float num = (float)_controlSurfaceScript.Data.Start / (float)_controlSurfaceScript.WingScript.SimulationSectionCount;
				float num2 = ((float)_controlSurfaceScript.Data.End / (float)_controlSurfaceScript.WingScript.SimulationSectionCount + num) / 2f;
				float num3 = (wingScript.Data.TipChord - wingScript.Data.BaseChord) * num2 + wingScript.Data.BaseChord;
				float z = wingScript.WingSweep * num2 - num3 / 2f + num3 * wingScript.Data.HingeDistanceFromTrailingEdge;
				Vector3 position = new Vector3(0f, _controlSurfaceScript.WingScript.Data.WingSpan * num2, z);
				return WingRoot.TransformPoint(position);
			}
		}

		public override bool IsBaseTool => false;

		public Vector3 RootSide
		{
			get
			{
				float num = (float)_controlSurfaceScript.Data.Start / (float)_controlSurfaceScript.WingScript.SimulationSectionCount;
				float y = num * _controlSurfaceScript.WingScript.Data.WingSpan;
				return WingRoot.TransformPoint(new Vector3(0f, y, GetZCoordinateOfTrailingEdgeAtPercent(num)));
			}
		}

		public Vector3 TipSide
		{
			get
			{
				float num = (float)_controlSurfaceScript.Data.End / (float)_controlSurfaceScript.WingScript.SimulationSectionCount;
				float y = num * _controlSurfaceScript.WingScript.Data.WingSpan;
				return WingRoot.TransformPoint(new Vector3(0f, y, GetZCoordinateOfTrailingEdgeAtPercent(num)));
			}
		}

		public Transform WingRoot => _controlSurfaceScript.WingScript.WingRoot;

		public ControlSurfaceTool(DesignerScript designerScript)
			: base(designerScript)
		{
		}

		public override void Activate()
		{
			base.Activate();
			if (_pendingControlSurface != null)
			{
				_controlSurfaceScript = _pendingControlSurface;
				_pendingControlSurface = null;
			}
			else if (_controlSurfaceScript == null)
			{
				_controlSurfaceScript = base.SelectedPart.GetModifier<ControlSurfaceScript>();
			}
			CreateGizmos();
		}

		public override void Deactivate()
		{
			base.Deactivate();
			_controlSurfaceScript = null;
		}

		public void SetHingePosition(Vector3 position)
		{
			Vector3 vector = WingRoot.InverseTransformPoint(position);
			WingScript wingScript = _controlSurfaceScript.WingScript;
			float num = (float)_controlSurfaceScript.Data.Start / (float)_controlSurfaceScript.WingScript.SimulationSectionCount;
			float num2 = ((float)_controlSurfaceScript.Data.End / (float)_controlSurfaceScript.WingScript.SimulationSectionCount + num) / 2f;
			float num3 = (wingScript.Data.TipChord - wingScript.Data.BaseChord) * num2 + wingScript.Data.BaseChord;
			float num4 = wingScript.WingSweep * num2;
			float num5 = (vector.z - num4 + num3 / 2f) / num3;
			num5 = Mathf.Clamp((float)(int)(num5 * 20f + 0.5f) / 20f, 0.05f, 0.4f);
			wingScript.Data.HingeDistanceFromTrailingEdge = num5;
			_controlSurfaceScript.WingScript.UpdateWingShape();
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

		protected override bool CanEditPart(IPartScript part, RaycastHit? hit)
		{
			_pendingControlSurface = null;
			if (!hit.HasValue)
			{
				return false;
			}
			WingScript modifier = part.GetModifier<WingScript>();
			if (modifier == null)
			{
				return false;
			}
			int num = Physics.OverlapSphereNonAlloc(hit.Value.point, 0.05f, _canEditOverlapTestResult, -2147475456, QueryTriggerInteraction.Ignore);
			for (int i = 0; i < num; i++)
			{
				foreach (ControlSurfaceScript controlSurface in modifier.ControlSurfaces)
				{
					if (_canEditOverlapTestResult[i] == controlSurface.Collider)
					{
						_pendingControlSurface = controlSurface;
						return true;
					}
				}
			}
			return false;
		}

		protected override void CreateGizmos()
		{
			if (_controlSurfaceScript != null)
			{
				CreateAdjustmentGizmo(WingRoot, -WingRoot.transform.forward, restrictForwardAftMovement: false, restrictLateralMovement: false, restrictVerticalMovement: true, delegate(Vector3 position)
				{
					SetRootPosition(position);
					Symmetry.SynchronizePartModifiers(base.WingScript.PartScript);
				}, () => RootSide);
				CreateAdjustmentGizmo(WingRoot, -WingRoot.transform.forward, restrictForwardAftMovement: false, restrictLateralMovement: false, restrictVerticalMovement: true, delegate(Vector3 position)
				{
					SetTipPosition(position);
					Symmetry.SynchronizePartModifiers(base.WingScript.PartScript);
				}, () => TipSide);
				CreateAdjustmentGizmo(WingRoot, WingRoot.transform.forward, restrictForwardAftMovement: false, restrictLateralMovement: true, restrictVerticalMovement: true, delegate(Vector3 position)
				{
					SetHingePosition(position);
					Symmetry.SynchronizePartModifiers(base.WingScript.PartScript);
				}, () => HingePosition);
			}
		}

		private float GetZCoordinateOfTrailingEdgeAtPercent(float percent)
		{
			WingScript wingScript = _controlSurfaceScript.WingScript;
			float num = (wingScript.Data.TipChord - wingScript.Data.BaseChord) * percent + wingScript.Data.BaseChord;
			return wingScript.WingSweep * percent - num / 2f;
		}

		private void SetRootPosition(Vector3 position)
		{
			int num = (int)(WingRoot.InverseTransformPoint(position).y / _controlSurfaceScript.WingScript.Data.WingSpan * (float)_controlSurfaceScript.WingScript.SimulationSectionCount + 0.5f);
			if (num < 0)
			{
				num = 0;
			}
			else if (num >= _controlSurfaceScript.Data.End)
			{
				num = _controlSurfaceScript.Data.End - 1;
			}
			_controlSurfaceScript.Data.Start = num;
			_controlSurfaceScript.WingScript.UpdateWingShape();
		}

		private void SetTipPosition(Vector3 position)
		{
			int num = (int)(WingRoot.InverseTransformPoint(position).y / _controlSurfaceScript.WingScript.Data.WingSpan * (float)_controlSurfaceScript.WingScript.SimulationSectionCount + 0.5f);
			if (num <= _controlSurfaceScript.Data.Start)
			{
				num = _controlSurfaceScript.Data.Start + 1;
			}
			else if (num >= _controlSurfaceScript.WingScript.SimulationSectionCount)
			{
				num = _controlSurfaceScript.WingScript.SimulationSectionCount;
			}
			_controlSurfaceScript.Data.End = num;
			_controlSurfaceScript.WingScript.UpdateWingShape();
		}
	}
}
