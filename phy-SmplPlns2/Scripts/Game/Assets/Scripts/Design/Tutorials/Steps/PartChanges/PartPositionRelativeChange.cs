using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.PartChanges
{
	public class PartPositionRelativeChange : ITutorialStepPartChange
	{
		public bool ApplyPartRotation { get; }

		private Vector3 Change { get; }

		private int PartId { get; }

		public PartPositionRelativeChange(int partId, Vector3 change, bool applyPartRotation)
		{
			PartId = partId;
			Change = change;
			ApplyPartRotation = applyPartRotation;
		}

		public void Apply(AircraftData craft)
		{
			SetPosition(craft, Change);
		}

		public void Revert(AircraftData craft)
		{
			SetPosition(craft, -Change);
		}

		private void SetPosition(AircraftData craft, Vector3 positionChange)
		{
			PartScript partScript = craft.Assembly.GetPartById(PartId)?.PartScript;
			if (partScript == null)
			{
				return;
			}
			if (ApplyPartRotation)
			{
				positionChange = partScript.transform.rotation * positionChange;
			}
			partScript.transform.position += positionChange;
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				craft.Assembly.GetOtherSymmetricParts(partScript.Part, value);
				if (value.Count > 1)
				{
					throw new NotSupportedException("Multiple symmetric parts are not supported.");
				}
				if (value.Count != 0)
				{
					Vector3 mirroredPosition = SymmetryUtility.GetMirroredPosition(partScript.transform.position, Designer.Instance.Symmetry);
					value[0].PartScript.transform.position = mirroredPosition;
				}
			}
		}
	}
}
