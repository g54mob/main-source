using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	[Serializable]
	public class DronePartStack
	{
		public bool CombinedParts;

		[ShowIf("CombinedParts", true)]
		public List<DronePart> DronePartList = new List<DronePart>();

		[ShowIf("CombinedParts", true)]
		public Texture2D CombinedPartsIcon;

		[ShowIf("CombinedParts", true)]
		public TranslationTerm CombinedPartsToolTip;

		[HideIf("CombinedParts", true)]
		public DronePart DronePart;

		public int Amount;

		public bool ContainsPart(NimbatusItem part)
		{
			if (!CombinedParts && DronePart != null)
			{
				return DronePart.UniqueId == part.UniqueId;
			}
			if (CombinedParts)
			{
				return DronePartList.Any((DronePart p) => p.UniqueId == part.UniqueId);
			}
			return false;
		}
	}
}
