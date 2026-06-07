using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.PartChanges
{
	public class PartRotationRelativeChange : ITutorialStepPartChange
	{
		public bool UseLocalSpace { get; }

		private Vector3 Change { get; }

		private int PartId { get; }

		public PartRotationRelativeChange(int partId, Vector3 change, bool useLocalSpace)
		{
			PartId = partId;
			Change = change;
			UseLocalSpace = useLocalSpace;
		}

		public void Apply(AircraftData craft)
		{
			SetRotation(craft, Change);
		}

		public void Revert(AircraftData craft)
		{
			SetRotation(craft, -Change);
		}

		private void SetRotation(AircraftData craft, Vector3 rotationChange)
		{
			PartScript partScript = craft.Assembly.GetPartById(PartId)?.PartScript;
			if (partScript == null)
			{
				return;
			}
			Quaternion quaternion = Quaternion.Euler(rotationChange);
			if (UseLocalSpace)
			{
				partScript.transform.localEulerAngles += rotationChange;
			}
			else
			{
				partScript.transform.rotation = quaternion * partScript.transform.rotation;
			}
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				craft.Assembly.GetOtherSymmetricParts(partScript.Part, value);
				if (value.Count > 1)
				{
					throw new NotSupportedException("Multiple symmetric parts are not supported.");
				}
				if (value.Count == 0)
				{
					return;
				}
				List<SymmetryTransform> value2;
				using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value2))
				{
					SymmetryUtility.GetSymmetricTransforms(partScript.Part, Designer.Instance.Symmetry, value2);
					value[0].PartScript.transform.rotation = value2[0].Rotation;
				}
			}
		}
	}
}
