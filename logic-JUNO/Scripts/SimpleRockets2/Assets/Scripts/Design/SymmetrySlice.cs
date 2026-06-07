using System;
using System.Collections.Generic;
using Assets.Scripts.Design.Tools;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class SymmetrySlice : ISymmetrySlice
	{
		public float Angle { get; private set; }

		public List<PartData> Parts { get; private set; }

		public PartData SliceRootPart { get; set; }

		public ISymmetryGroup SymmetryGroup { get; private set; }

		public SymmetrySlice(ISymmetryGroup group, float angle)
		{
			SymmetryGroup = group;
			Angle = angle;
			Parts = new List<PartData>();
		}

		public PartData GetPart(Guid symmetryId)
		{
			foreach (PartData part in Parts)
			{
				if (part.SymmetryId == symmetryId)
				{
					return part;
				}
			}
			return null;
		}

		public void UpdatePartTransform(IPartScript sourcePart, IPartScript symmetricPart)
		{
			Quaternion rotation = sourcePart.Transform.rotation;
			Vector3 position = sourcePart.Transform.position;
			if (SymmetryGroup.SymmetryMode == SymmetryMode.Mirror)
			{
				PartMirror.MirrorPartPositionAndRotation(symmetricPart, sourcePart.Data.PartType.MirrorConfig, rotation, position, SymmetryGroup.RootPart.Transform.rotation, SymmetryGroup.RootPart.Transform.position);
				return;
			}
			float angle = symmetricPart.SymmetrySlice.Angle - sourcePart.SymmetrySlice.Angle;
			Vector3 up = SymmetryGroup.RootPart.Transform.up;
			Vector3 position2 = SymmetryGroup.AttachPoint.AttachPointScript.transform.position;
			symmetricPart.Transform.SetPositionAndRotation(Utilities.RotatePointAroundPivot(position, position2, up, angle), Quaternion.AngleAxis(angle, up) * rotation);
		}
	}
}
