using System.Collections.Generic;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GenericPartScript : PartModifierScript<GenericPartData>
	{
		private Transform _attachPointPositions;

		private Transform _scalar;

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateScale(repositionAttachedParts: true);
		}

		public void UpdateScale(bool repositionAttachedParts = false)
		{
			if (!(_scalar != null))
			{
				return;
			}
			_scalar.localScale = Vector3.one * base.Data.Scale;
			if (!(_attachPointPositions != null))
			{
				return;
			}
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			foreach (Transform attachPointPosition in _attachPointPositions)
			{
				foreach (AttachPoint attachPoint in base.Data.Part.AttachPoints)
				{
					if (!(attachPoint.Name == attachPointPosition.name))
					{
						continue;
					}
					attachPoint.Scale = base.Data.AttachmentSize;
					Vector3 position = attachPoint.Position;
					attachPoint.Position = attachPointPosition.localPosition * base.Data.Scale + _scalar.localPosition * (1f - base.Data.Scale);
					if (!(attachPoint.AttachPointScript != null))
					{
						break;
					}
					if (repositionAttachedParts)
					{
						Vector3 position2 = attachPoint.Position;
						Vector3 delta = attachPoint.AttachPointScript.transform.parent.TransformVector(position2 - position);
						foreach (PartConnection partConnection in attachPoint.PartConnections)
						{
							DesignerUtilities.RepositionParts(base.Data.Part, partConnection, delta, movedParts);
						}
					}
					attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
					break;
				}
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_scalar = base.transform.Find("Scalar");
			if (_scalar != null)
			{
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPointPositions", _scalar.gameObject);
				if (gameObject != null)
				{
					_attachPointPositions = gameObject.transform;
				}
			}
			UpdateScale();
		}
	}
}
