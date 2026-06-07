using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class UpdateAttachPointsScript : MonoBehaviour
	{
		[Serializable]
		private class UpdatingAttachPoint
		{
			[field: SerializeField]
			public bool RepositionAttachedParts { get; set; }

			[field: SerializeField]
			public Transform Transform { get; set; }

			[field: SerializeField]
			public bool UpdateAttachPoint { get; set; } = true;
		}

		[SerializeField]
		private List<UpdatingAttachPoint> _attachPoints;

		public void UpdateAttachPoints(PartScript partScript, bool updateAttachedParts)
		{
			for (int i = 0; i < _attachPoints.Count; i++)
			{
				UpdatingAttachPoint updatingAttachPoint = _attachPoints[i];
				if (updatingAttachPoint.UpdateAttachPoint)
				{
					AttachPointScript attachPointScript = partScript.AttachPointScripts[i];
					Vector3 vector = updatingAttachPoint.Transform.position - attachPointScript.transform.position;
					attachPointScript.transform.position = updatingAttachPoint.Transform.position;
					if (updateAttachedParts && updatingAttachPoint.RepositionAttachedParts && attachPointScript.AttachPoint.PartConnections.Count == 1)
					{
						attachPointScript.AttachPoint.PartConnections[0].GetOtherPart(partScript.Part).PartScript.transform.position += vector;
					}
				}
			}
		}
	}
}
