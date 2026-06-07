using System.Collections.Generic;
using System.Linq;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class MirrorCraftTool : DesignerToolBase
	{
		private Transform _mirrorPlane;

		private PartMirror _partMirror;

		private Vector3 _startPosition;

		public override bool IsBaseTool => false;

		public int Location { get; set; }

		public int Rotation { get; set; }

		public MirrorCraftTool(DesignerScript designer)
			: base(designer)
		{
			_mirrorPlane = base.DesignerScript.DesignerPlatform.MirrorPlaneTransform;
		}

		public override void Activate()
		{
			base.Activate();
			base.Designer.AllowPartSelection = false;
			base.Designer.DeselectPart();
			base.Designer.HighlightedPart = null;
			StartMirror();
		}

		public override void Deactivate()
		{
			base.Deactivate();
			EndMirror();
			base.Designer.AllowPartSelection = true;
		}

		public void EndMirror()
		{
			if (_partMirror != null)
			{
				_partMirror.EndMirror();
				_partMirror = null;
			}
			_mirrorPlane.gameObject.SetActive(value: false);
		}

		public void IdentifyAffectedPartsFromMirrorPlane()
		{
			_partMirror.IdentifyAffectedPartsFromMirrorPlane();
		}

		public void Mirror()
		{
			_partMirror.MirrorSelectedParts();
			base.Designer.DesignerUi.ShowMessage($"Mirrored {_partMirror.PartsToMirror.Count} part(s) to the other side.");
			base.Designer.CreateUndoStep();
		}

		public override void OnCraftStructureChanged()
		{
			base.OnCraftStructureChanged();
			EndMirror();
		}

		public void QuickMirror(int location, int rotation)
		{
			Location = location;
			Rotation = rotation;
			StartMirror();
			IdentifyAffectedPartsFromMirrorPlane();
			Mirror();
			EndMirror();
			base.DesignerScript.CraftScript.SetStructureChanged();
		}

		public void QuickMirrorSelectedPart()
		{
			IPartScript selectedPart = base.Designer.SelectedPart;
			if (selectedPart != null)
			{
				QuickMirrorPart(selectedPart, includeConnectedParts: true);
			}
			else
			{
				base.Designer.DesignerUi.ShowMessage("No part is selected to mirror to other side.");
			}
		}

		public void QuickMirrorToLeft()
		{
			QuickMirror(0, 0);
		}

		public void QuickMirrorToRight()
		{
			QuickMirror(0, 180);
		}

		public void StartMirror()
		{
			EndMirror();
			_mirrorPlane.localScale = Vector3.one;
			_mirrorPlane.rotation = Quaternion.Euler(0f, Rotation, 0f);
			_mirrorPlane.gameObject.SetActive(value: true);
			Bounds bounds = base.DesignerScript.CraftScript.CalculateBounds();
			Vector3 position = bounds.size + Utilities.GetMaximumComponentVector(bounds.size * 0.1f, new Vector3(2f, 2f, 2f));
			Vector3 vector = _mirrorPlane.InverseTransformPoint(position);
			base.DesignerScript.DesignerPlatform.MirrorPlaneScale = new Vector2(vector.z, vector.y);
			_mirrorPlane.position = base.DesignerScript.CraftScript.RootPart.Transform.position;
			Vector3 position2 = _mirrorPlane.InverseTransformPoint(bounds.center);
			position2.x = 0f;
			_startPosition = _mirrorPlane.TransformPoint(position2);
			_mirrorPlane.position = _startPosition + _mirrorPlane.transform.right * ((float)Location * 0.25f);
			_partMirror = new PartMirror(_mirrorPlane, base.DesignerScript.CraftScript);
			_partMirror.StartMirror();
		}

		private void QuickMirrorPart(IPartScript part, bool includeConnectedParts)
		{
			Location = 0;
			StartMirror();
			new List<PartData>();
			if (includeConnectedParts)
			{
				PartSelection.PartLimb partLimb = PartSelection.FindPartLimb(part);
				_partMirror.PartsToMirror.AddRange(partLimb.Parts.Select((IPartScript x) => x.Data));
			}
			else
			{
				_partMirror.PartsToMirror.Add(part.Data);
			}
			Mirror();
			EndMirror();
			base.DesignerScript.CraftScript.SetStructureChanged();
		}
	}
}
