using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.PartChanges
{
	public class PartPositionAbsoluteChange : ITutorialStepPartChange
	{
		private Vector3 NewPosition { get; }

		private Vector3 OriginalPosition { get; }

		private int PartId { get; }

		public PartPositionAbsoluteChange(int partId, Vector3 originalPosition, Vector3 newPosition)
		{
			PartId = partId;
			OriginalPosition = originalPosition;
			NewPosition = newPosition;
		}

		public void Apply(AircraftData craft)
		{
			SetPosition(craft, NewPosition);
		}

		public void Revert(AircraftData craft)
		{
			SetPosition(craft, OriginalPosition);
		}

		private void SetPosition(AircraftData craft, Vector3 position)
		{
			PartScript partScript = craft.Assembly.GetPartById(PartId)?.PartScript;
			if (partScript == null)
			{
				return;
			}
			partScript.transform.position = position;
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
