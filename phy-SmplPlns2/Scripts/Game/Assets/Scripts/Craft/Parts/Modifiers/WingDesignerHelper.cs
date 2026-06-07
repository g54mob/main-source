using System.Collections.Generic;
using Assets.Scripts.Design;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class WingDesignerHelper
	{
		private Designer _designer;

		private IGenericPartProperties _genericPartPropertiesScript;

		private WingScript _script;

		private IEnumerable<WingScript> AllWingScripts
		{
			get
			{
				if (_script.PartScript.Part.SymmetryId != 0)
				{
					IReadOnlyList<PartData> symmetricParts = _script.PartScript.Aircraft.Aircraft.Assembly.GetSymmetricParts(_script.PartScript.Part);
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
					yield return _script;
				}
			}
		}

		public WingDesignerHelper(WingScript script, IGenericPartProperties genericPartPropertiesScript)
		{
			_script = script;
			_genericPartPropertiesScript = genericPartPropertiesScript;
			_designer = Designer.Instance;
		}

		public void AddControlSurface()
		{
			if (GetNextControlSurfaceSpot(out var start, out var length))
			{
				if (length > 1)
				{
					length--;
					start++;
				}
				if (length > 5)
				{
					length = 5;
				}
				foreach (WingScript allWingScript in AllWingScripts)
				{
					allWingScript.AddControlSurface(start, length, "Roll", 35, invert: false);
					allWingScript.SortControlSurfaces();
					allWingScript.UpdateWingShape();
				}
			}
			_genericPartPropertiesScript.RefreshUI();
		}

		public void DeleteControlSurface(int controlSurfaceIndex)
		{
			foreach (WingScript allWingScript in AllWingScripts)
			{
				ControlSurfaceScript controlSurfaceScript = allWingScript.ControlSurfaces[controlSurfaceIndex];
				Designer.Instance.ControlSurfaceDeleted(controlSurfaceScript);
				allWingScript.DeleteControlSurface(controlSurfaceScript);
				allWingScript.UpdateWingShape();
			}
		}

		public void EditControlSurface(int index)
		{
			MoveObjectScript component = Camera.main.GetComponent<MoveObjectScript>();
			ControlSurfaceScript controlSurfaceScript = _script.ControlSurfaces[index];
			List<ControlSurfaceScript> list = new List<ControlSurfaceScript>();
			PartData part = _script.PartScript.Part;
			if (part.SymmetryId != 0)
			{
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					part.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(part, value);
					foreach (PartData item in value)
					{
						WingScript modifier = item.PartScript.GetModifier<WingScript>();
						ControlSurfaceScript controlSurfaceScript2 = (((modifier?.ControlSurfaces.Count ?? 0) > index) ? modifier.ControlSurfaces[index] : null);
						if (controlSurfaceScript2 != null)
						{
							list.Add(controlSurfaceScript2);
						}
					}
				}
			}
			_designer.Tools.EditControlSurface(controlSurfaceScript, list);
			_designer.EnableViewportPanningAndRotation = true;
			if (_designer.Tools.SelectedTool is ControlSurfaceTool controlSurfaceTool)
			{
				controlSurfaceTool.AllowPartSelection = false;
				int num = 5;
				Vector3 vector = ((!(controlSurfaceScript.transform.up.x > 0f)) ? new Vector3(num, 0f, 0f) : new Vector3(-num, 0f, 0f));
				component.ResetPanning();
				component.DestinationPanUp = controlSurfaceScript.WingScript.transform.forward;
				component.DestinationPanPosition = controlSurfaceScript.transform.TransformPoint(controlSurfaceScript.transform.InverseTransformPoint(controlSurfaceTool.HingePosition) + vector * Mathf.Max((float)controlSurfaceScript.ControlSurface.Length / 4.5f, 1.5f));
				component.TimeToFinishPanning = 0.65f;
				component.TimeToFinishPanningReset = component.TimeToFinishPanning;
				component.PanningFocus = controlSurfaceTool.HingePosition;
			}
		}

		public void EditDihedral()
		{
			MoveObjectScript component = Camera.main.GetComponent<MoveObjectScript>();
			_designer.Tools.EditDihedral();
			PanCameraForWingDihedral(component);
		}

		public void EditWingShape()
		{
			_designer.Tools.SelectWingAdjustmentTool();
			Designer.CenterViewOnPart(_designer.SelectedPart);
		}

		private bool GetNextControlSurfaceSpot(out int start, out int length)
		{
			bool[] array = new bool[_script.SimulationSectionCount];
			foreach (ControlSurfaceScript controlSurface in _script.ControlSurfaces)
			{
				for (int i = controlSurface.ControlSurface.Start; i < controlSurface.ControlSurface.End; i++)
				{
					array[i] = true;
				}
			}
			int num = -1;
			int num2 = 0;
			for (int num3 = array.Length - 1; num3 >= 0; num3--)
			{
				if (!array[num3])
				{
					num = num3;
					num2++;
				}
				else
				{
					if (num >= 0)
					{
						break;
					}
					num2 = 0;
				}
			}
			if (num >= 0)
			{
				start = num;
				length = num2;
				return true;
			}
			start = 0;
			length = 0;
			return false;
		}

		private void PanCameraForWingDihedral(MoveObjectScript moveObjectScript)
		{
			WingScript wingScriptFromPart = WingScript.GetWingScriptFromPart(_designer.SelectedPart);
			moveObjectScript.ResetPanning();
			Vector3 vector = (_designer.SelectedPart.transform.TransformPoint(wingScriptFromPart.RootLeadingEdge) + _designer.SelectedPart.transform.TransformPoint(wingScriptFromPart.RootTrailingEdge) + _designer.SelectedPart.transform.TransformPoint(wingScriptFromPart.TipLeadingEdge) + _designer.SelectedPart.transform.TransformPoint(wingScriptFromPart.TipTrailingEdge)) / 4f;
			Vector3 vector2 = Utilities.Abs(_designer.SelectedPart.transform.forward) * (wingScriptFromPart.Wing.WingSpan * 1.5f);
			float num = 4f;
			if (vector2.z <= num)
			{
				vector2.z = num;
			}
			moveObjectScript.DestinationPanPosition = vector + vector2;
			moveObjectScript.DestinationPanUp = Vector3.up;
			moveObjectScript.PanningFocus = vector;
			moveObjectScript.IsPanningFocusACameraTarget = true;
			moveObjectScript.CameraTarget = Camera.main.transform.parent;
			moveObjectScript.TimeToFinishPanning = 0.65f;
			moveObjectScript.TimeToFinishPanningReset = 0.65f;
		}
	}
}
