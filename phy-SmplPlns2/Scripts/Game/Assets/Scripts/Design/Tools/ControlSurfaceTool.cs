using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class ControlSurfaceTool : WingTool
	{
		public IEnumerable<ControlSurfaceScript> AllControlSurfaces
		{
			get
			{
				yield return ControlSurface;
				if (SymmetricControlSurfaces == null)
				{
					yield break;
				}
				foreach (ControlSurfaceScript symmetricControlSurface in SymmetricControlSurfaces)
				{
					yield return symmetricControlSurface;
				}
			}
		}

		public ControlSurfaceScript ControlSurface { get; set; }

		public Vector3 HingePosition
		{
			get
			{
				WingScript wingScript = ControlSurface.WingScript;
				float num = (float)ControlSurface.ControlSurface.Start / (float)ControlSurface.WingScript.SimulationSectionCount;
				float num2 = ((float)ControlSurface.ControlSurface.End / (float)ControlSurface.WingScript.SimulationSectionCount + num) / 2f;
				float num3 = (wingScript.Wing.TipChord - wingScript.Wing.BaseChord) * num2 + wingScript.Wing.BaseChord;
				float z = wingScript.WingSweep * num2 - num3 / 2f + num3 * wingScript.Wing.HingeDistanceFromTrailingEdge;
				float num4 = 0.075f;
				if (wingScript.Wing.Inverted)
				{
					num4 = 0f - num4;
				}
				Vector3 position = new Vector3(num4, ControlSurface.WingScript.Wing.WingSpan * num2, z);
				return WingRoot.TransformPoint(position);
			}
		}

		public Vector3 RootSide
		{
			get
			{
				float num = (float)ControlSurface.ControlSurface.Start / (float)ControlSurface.WingScript.SimulationSectionCount;
				float y = num * ControlSurface.WingScript.Wing.WingSpan;
				return WingRoot.TransformPoint(new Vector3(0f, y, GetZCoordinateOfTrailingEdgeAtPercent(num)));
			}
		}

		public List<ControlSurfaceScript> SymmetricControlSurfaces { get; set; }

		public Vector3 TipSide
		{
			get
			{
				float num = (float)ControlSurface.ControlSurface.End / (float)ControlSurface.WingScript.SimulationSectionCount;
				float y = num * ControlSurface.WingScript.Wing.WingSpan;
				return WingRoot.TransformPoint(new Vector3(0f, y, GetZCoordinateOfTrailingEdgeAtPercent(num)));
			}
		}

		public Transform WingRoot => ControlSurface.WingScript.WingRoot;

		public ControlSurfaceTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Stop()
		{
			base.Stop();
		}

		protected override void DrawGizmos()
		{
			if (ControlSurface != null)
			{
				CreateAdjustmentGizmo(WingRoot, -WingRoot.transform.forward, WingRoot.transform.up, secondaryFree: true, delegate(Vector3 position)
				{
					SetRootPosition(position);
				}, () => RootSide);
				CreateAdjustmentGizmo(WingRoot, -WingRoot.transform.forward, WingRoot.transform.up, secondaryFree: true, delegate(Vector3 position)
				{
					SetTipPosition(position);
				}, () => TipSide);
				CreateAdjustmentGizmo(WingRoot, WingRoot.transform.forward, WingRoot.transform.up, secondaryFree: false, delegate(Vector3 position)
				{
					SetHingePosition(position);
				}, () => HingePosition);
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStartGizmoTool);
			}
		}

		private float GetZCoordinateOfTrailingEdgeAtPercent(float percent)
		{
			WingScript wingScript = ControlSurface.WingScript;
			float num = (wingScript.Wing.TipChord - wingScript.Wing.BaseChord) * percent + wingScript.Wing.BaseChord;
			return wingScript.WingSweep * percent - num / 2f;
		}

		private void SetHingePosition(Vector3 position)
		{
			Vector3 vector = WingRoot.InverseTransformPoint(position);
			WingScript wingScript = ControlSurface.WingScript;
			float num = (float)ControlSurface.ControlSurface.Start / (float)ControlSurface.WingScript.SimulationSectionCount;
			float num2 = ((float)ControlSurface.ControlSurface.End / (float)ControlSurface.WingScript.SimulationSectionCount + num) / 2f;
			float num3 = (wingScript.Wing.TipChord - wingScript.Wing.BaseChord) * num2 + wingScript.Wing.BaseChord;
			float num4 = wingScript.WingSweep * num2;
			float num5 = (vector.z - num4 + num3 / 2f) / num3;
			num5 = (float)(int)(num5 * 10f + 0.5f) / 10f;
			num5 = Mathf.Clamp(num5, 0.1f, 0.9f);
			if (wingScript.Wing.HingeDistanceFromTrailingEdge == num5)
			{
				return;
			}
			foreach (ControlSurfaceScript allControlSurface in AllControlSurfaces)
			{
				allControlSurface.WingScript.Wing.HingeDistanceFromTrailingEdge = num5;
				allControlSurface.WingScript.UpdateWingShape();
				base.Designer.OnAircraftStructureChanged();
			}
		}

		private void SetRootPosition(Vector3 position)
		{
			int num = (int)(WingRoot.InverseTransformPoint(position).y / ControlSurface.WingScript.Wing.WingSpan * (float)ControlSurface.WingScript.SimulationSectionCount + 0.5f);
			if (num < 0)
			{
				num = 0;
			}
			else if (num >= ControlSurface.ControlSurface.End)
			{
				num = ControlSurface.ControlSurface.End - 1;
			}
			if (ControlSurface.ControlSurface.Start == num)
			{
				return;
			}
			foreach (ControlSurfaceScript allControlSurface in AllControlSurfaces)
			{
				allControlSurface.ControlSurface.Start = num;
				allControlSurface.WingScript.UpdateWingShape();
				base.Designer.OnAircraftStructureChanged();
			}
		}

		private void SetTipPosition(Vector3 position)
		{
			int num = (int)(WingRoot.InverseTransformPoint(position).y / ControlSurface.WingScript.Wing.WingSpan * (float)ControlSurface.WingScript.SimulationSectionCount + 0.5f);
			if (num <= ControlSurface.ControlSurface.Start)
			{
				num = ControlSurface.ControlSurface.Start + 1;
			}
			else if (num >= ControlSurface.WingScript.SimulationSectionCount)
			{
				num = ControlSurface.WingScript.SimulationSectionCount;
			}
			if (ControlSurface.ControlSurface.End == num)
			{
				return;
			}
			foreach (ControlSurfaceScript allControlSurface in AllControlSurfaces)
			{
				allControlSurface.ControlSurface.End = num;
				allControlSurface.WingScript.UpdateWingShape();
				base.Designer.OnAircraftStructureChanged();
			}
		}
	}
}
