using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class HumanAppearance : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> skinColor;

		[SerializeField]
		private List<string> hairColor;

		[SerializeField]
		private List<HumanAppearanceBodyPartsGroup> bodyParts;

		[NonSerialized]
		private Dictionary<string, HumanAppearanceBodyPartsGroup> bodyPartsByGroupName;

		public List<string> HairColor => hairColor;

		public List<string> SkinColor => skinColor;

		public List<HumanAppearanceBodyPartsGroup> BodyParts => bodyParts;

		public override string GetID()
		{
			return id;
		}

		public bool IsBodyPartAllowed(string bodyPartVariant, string groupName)
		{
			if (bodyPartsByGroupName == null)
			{
				bodyPartsByGroupName = new Dictionary<string, HumanAppearanceBodyPartsGroup>();
			}
			if (!bodyPartsByGroupName.ContainsKey(groupName))
			{
				bodyPartsByGroupName.Add(groupName, null);
				using IEnumerator<HumanAppearanceBodyPartsGroup> enumerator = bodyParts.Where((HumanAppearanceBodyPartsGroup group) => group.GroupName.Equals(groupName)).GetEnumerator();
				if (enumerator.MoveNext())
				{
					HumanAppearanceBodyPartsGroup current = enumerator.Current;
					bodyPartsByGroupName[groupName] = current;
				}
			}
			if (bodyPartsByGroupName[groupName] != null)
			{
				return bodyPartsByGroupName[groupName].AllowedItems.Contains(bodyPartVariant);
			}
			return true;
		}
	}
}
