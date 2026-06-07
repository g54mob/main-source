using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.UI;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class WingAdjustmentTool : WingTool
	{
		public enum EditType
		{
			Dihedral = 0,
			Shape = 1
		}

		private EditType _editType;

		private bool _hasPlayedErrorYet;

		public EditType CurrentEditType
		{
			get
			{
				return _editType;
			}
			set
			{
				_editType = value;
				EditTypeChanged(value);
			}
		}

		private IEnumerable<WingScript> AllWingScripts
		{
			get
			{
				if (base.PartScript.Part.SymmetryId != 0)
				{
					IReadOnlyList<PartData> symmetricParts = base.PartScript.Aircraft.Aircraft.Assembly.GetSymmetricParts(base.PartScript.Part);
					foreach (PartData item in symmetricParts)
					{
						WingScript modifier = item.PartScript.GetModifier<WingScript>();
						if (modifier != null)
						{
							yield return modifier;
						}
					}
				}
				else
				{
					yield return base.PartScript.GetModifier<WingScript>();
				}
			}
		}

		public WingAdjustmentTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			_editType = EditType.Shape;
		}

		protected override void DrawGizmos()
		{
			WingScript wingScript = base.PartScript.GetModifier<WingScript>();
			if (!wingScript)
			{
				return;
			}
			DestroyGizmos();
			if (CurrentEditType == EditType.Shape)
			{
				base.AllowPartSelection = true;
				base.Designer.EnableViewportPanningAndRotation = true;
				CreateAdjustmentGizmo(base.PartScript.transform, -base.PartScript.transform.forward, base.PartScript.transform.up, secondaryFree: false, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.RootTrailingEdge);
				}, () => GetWingPoint(wingScript.RootTrailingEdge));
				CreateAdjustmentGizmo(base.PartScript.transform, base.PartScript.transform.forward, base.PartScript.transform.up, secondaryFree: false, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.RootLeadingEdge);
				}, () => GetWingPoint(wingScript.RootLeadingEdge));
				CreateAdjustmentGizmo(base.PartScript.transform, base.PartScript.transform.forward, base.PartScript.transform.up, secondaryFree: false, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.TipLeadingEdge);
				}, () => GetWingPoint(wingScript.TipLeadingEdge));
				CreateAdjustmentGizmo(base.PartScript.transform, -base.PartScript.transform.forward, base.PartScript.transform.up, secondaryFree: false, delegate(Vector3 position)
				{
					UpdateWingPoint(position, WingScript.WingPointType.TipTrailingEdge);
				}, () => GetWingPoint(wingScript.TipTrailingEdge));
				if (wingScript.IsWingTipAvailable)
				{
					CreateAdjustmentGizmo(base.PartScript.transform, base.PartScript.transform.transform.up, base.PartScript.transform.forward, secondaryFree: true, delegate(Vector3 position)
					{
						UpdateWingPoint(position, WingScript.WingPointType.TipPosition);
					}, () => GetWingPoint(wingScript.Wing.TipPosition));
				}
			}
			else if (CurrentEditType == EditType.Dihedral)
			{
				base.AllowPartSelection = false;
				base.Designer.EnableViewportPanningAndRotation = true;
				if (wingScript.IsWingTipAvailable)
				{
					Vector3 vector = new Vector3(0f, 0f, -90f);
					Vector3 vector2 = base.PartScript.transform.transform.right;
					if (wingScript.Wing.Inverted)
					{
						vector = -vector;
						vector2 = -vector2;
					}
					CreateAdjustmentGizmo(base.PartScript.transform, vector2, base.PartScript.transform.up, secondaryFree: false, delegate(Vector3 position)
					{
						UpdateWingPoint(position, WingScript.WingPointType.TipPosition);
					}, () => GetWingPoint(wingScript.Wing.TipPosition));
				}
			}
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStartGizmoTool);
		}

		private static Vector3 GetWingPoint(WingScript wingScript, WingScript.WingPointType wingPointType)
		{
			Vector3 result = Vector3.zero;
			switch (wingPointType)
			{
			case WingScript.WingPointType.RootLeadingEdge:
				result = wingScript.RootLeadingEdge;
				break;
			case WingScript.WingPointType.RootTrailingEdge:
				result = wingScript.RootTrailingEdge;
				break;
			case WingScript.WingPointType.TipLeadingEdge:
				result = wingScript.TipLeadingEdge;
				break;
			case WingScript.WingPointType.TipPosition:
				result = wingScript.Wing.TipPosition;
				break;
			case WingScript.WingPointType.TipTrailingEdge:
				result = wingScript.TipTrailingEdge;
				break;
			}
			return result;
		}

		private void EditTypeChanged(EditType value)
		{
			DrawGizmos();
		}

		private Vector3 GetWingPoint(Vector3 position)
		{
			return base.PartScript.transform.TransformPoint(position);
		}

		private void UpdateWingPoint(Vector3 position, WingScript.WingPointType wingPointType)
		{
			WingScript modifier = base.PartScript.GetModifier<WingScript>();
			Dictionary<int, Vector3> value;
			using (CollectionPool<Dictionary<int, Vector3>, KeyValuePair<int, Vector3>>.Get(out value))
			{
				position = base.PartScript.transform.InverseTransformPoint(position);
				foreach (WingScript allWingScript in AllWingScripts)
				{
					value.Add(allWingScript.PartScript.Part.Id, GetWingPoint(allWingScript, wingPointType));
					Vector3 position2 = position;
					if (wingPointType == WingScript.WingPointType.TipPosition)
					{
						bool inverted = modifier.Wing.Inverted;
						if (allWingScript.Wing.Inverted != inverted)
						{
							position2.x = 0f - position2.x;
						}
					}
					allWingScript.UpdateWingPoint(position2, wingPointType);
				}
				if (!(GetWingPoint(modifier, wingPointType) - value[base.PartScript.Part.Id] != Vector3.zero))
				{
					return;
				}
				List<PartScript> list = new List<PartScript>();
				list.Add(base.PartScript);
				PartGraph partGraph = new PartGraph(base.PartScript.Part, breakOnRigidBodyBoundary: false);
				List<PartScript> list2 = new List<PartScript>();
				foreach (PartData part in partGraph.Parts)
				{
					list2.Add(part.PartScript);
				}
				if (PartCollisionDetection.CheckIfAnyPartsCollide(list, list2))
				{
					foreach (WingScript allWingScript2 in AllWingScripts)
					{
						allWingScript2.UpdateWingPoint(value[allWingScript2.PartScript.Part.Id], wingPointType);
					}
					if (!_hasPlayedErrorYet)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerDragPartPositionError, 0.55f);
						_hasPlayedErrorYet = true;
					}
				}
				else
				{
					_hasPlayedErrorYet = false;
				}
				base.Designer.OnAircraftStructureChanged();
			}
		}
	}
}
