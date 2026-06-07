using System.Collections.Generic;
using Factory;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Challenge", menuName = "Motorways/Challenges/Challenge", order = 3)]
	public class ChallengeData : ScriptableObject
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is ChallengeData challengeData)
				{
					context.Writer.Write(challengeData.name);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				string challengeName = context.Reader.ReadString();
				if (context.Scope.Get<ChallengeDatabase>().TryGetChallenge(challengeName, out var result))
				{
					return result;
				}
				return null;
			}
		}

		[EnumSearch(typeof(StringId), true)]
		public string challengeName;

		[EnumSearch(typeof(StringId), true)]
		public string challengeDescription;

		public Sprite icon;

		private const string SubIcon = "SubIcon";

		[FoldoutGroup("SubIcon")]
		public Sprite subIconBackground;

		[FoldoutGroup("SubIcon")]
		public Sprite subIcon;

		public List<ChallengeModifier> modifiers = new List<ChallengeModifier>();

		public int modifierToUseForLocalization;

		private const string Incompatibilities = "Incompatibilities";

		[FoldoutGroup("Incompatibilities")]
		public List<MapDefinition.CityNames> incompatibleMaps = new List<MapDefinition.CityNames>();

		[FoldoutGroup("Incompatibilities")]
		public List<CityChallengeCompatibilityGroup> incompatibleCityGroups = new List<CityChallengeCompatibilityGroup>();

		[FoldoutGroup("Incompatibilities")]
		public List<ChallengeData> automaticIncompatibleChallenges = new List<ChallengeData>();

		[FoldoutGroup("Incompatibilities")]
		public List<ChallengeData> manualIncompatibleChallenges = new List<ChallengeData>();

		public override string ToString()
		{
			string text = base.name;
			if (modifiers.Count > 0)
			{
				text += $" ({modifiers[0]}";
				for (int i = 1; i < modifiers.Count; i++)
				{
					text += $", {modifiers[i]}";
				}
				text += ")";
			}
			return text;
		}

		public bool IsCompatibleWith(MapDefinition city)
		{
			if (incompatibleMaps.Contains(ChallengeSystem.GetCityName(city)))
			{
				return false;
			}
			foreach (CityChallengeCompatibilityGroup incompatibleCityGroup in incompatibleCityGroups)
			{
				if (!incompatibleCityGroup.IsMapCompatible(ChallengeSystem.GetCityName(city)))
				{
					return false;
				}
			}
			foreach (ChallengeModifier modifier in modifiers)
			{
				if (!modifier.IsCompatibleWithMap(city))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsIncompatibleWith(ChallengeData otherChallenge)
		{
			if (automaticIncompatibleChallenges.Contains(otherChallenge) || manualIncompatibleChallenges.Contains(otherChallenge))
			{
				return true;
			}
			return false;
		}

		public bool AreModifiersCompatibleWith(ChallengeData otherChallenge)
		{
			foreach (ChallengeModifier modifier in modifiers)
			{
				foreach (ChallengeModifier modifier2 in otherChallenge.modifiers)
				{
					if (!modifier.IsCompatibleWith(modifier2))
					{
						return false;
					}
				}
			}
			return true;
		}

		public float GetSelectedModifierLocalizationParameter()
		{
			if (Diagnostics.Verify(modifierToUseForLocalization >= 0 && modifierToUseForLocalization < modifiers.Count, "Incorrect modifier index for localisation parameter! Have {0}, max {1}", modifierToUseForLocalization, modifiers.Count))
			{
				return modifiers[modifierToUseForLocalization].GetLocalizationParameter();
			}
			return -1f;
		}
	}
}
