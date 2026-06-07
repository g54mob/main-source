using System;
using System.Collections.Generic;
using UMA.PoseTools;
using UnityEngine;

namespace UMA
{
	[Serializable]
	[PreferBinarySerialization]
	public class RaceData : ScriptableObject, INameProvider, IUMAIndexOptions
	{
		[Serializable]
		protected class CrossCompatibilityData
		{
			public string raceSlot;

			public string compatibleRaceSlot;

			public bool overlaysMatch;

			public CrossCompatibilityData()
			{
			}

			public CrossCompatibilityData(string _raceSlot, string _compatibleRaceSlot)
			{
			}

			public CrossCompatibilityData(string _raceSlot, string _compatibleRaceSlot, bool _overlaysMatch)
			{
			}
		}

		[Serializable]
		protected class CrossCompatibilitySettings
		{
			public string ccRace;

			public List<CrossCompatibilityData> ccSettings;

			public CrossCompatibilitySettings()
			{
			}

			public CrossCompatibilitySettings(string race)
			{
			}

			public CrossCompatibilitySettings(string race, List<CrossCompatibilityData> settings)
			{
			}

			public string GetCompatibleRacesSlot(string thisRacesSlot)
			{
				return null;
			}

			public string GetEquivalentSlot(string compatibleSlot, bool overlaysMustMatch = true)
			{
				return null;
			}

			public int GetOverlayCompatibility(string compatibleRaceSlot)
			{
				return 0;
			}

			public void SetEquivalentSlot(string thisRacesSlot, string compatibleRacesSlot = "", bool overlayCompatibility = true)
			{
			}
		}

		[Serializable]
		protected class CrossCompatibilitySettingsList
		{
			public List<CrossCompatibilitySettings> settingsData;

			public bool Contains(string crossCompatibleRace)
			{
				return false;
			}

			public void Add(string crossCompatibleRace)
			{
			}

			public void Remove(List<string> races)
			{
			}

			public void Remove(string crossCompatibleRace)
			{
			}
		}

		[Serializable]
		public class RaceThumbnails
		{
			[Serializable]
			public class WardrobeSlotThumb
			{
				[Tooltip("A comma separated list of wardrobe slots this is the base thumbnail for (no spaces)")]
				public string thumbIsFor;

				public Sprite thumb;
			}

			public Sprite fullThumb;

			public Sprite faceThumb;

			[SerializeField]
			private List<WardrobeSlotThumb> wardrobeSlotThumbs;

			public Sprite GetThumbFor(string thumbToGet = "")
			{
				return null;
			}
		}

		public enum UMATarget
		{
			Humanoid = 0,
			Generic = 1
		}

		[Tooltip("This should be set to true for Blender FBX models")]
		public bool FixupRotations;

		[Tooltip("UMA Text recipe that holds the slots and overlays that are the default set up for this race.")]
		public UMARecipeBase baseRaceRecipe;

		[Tooltip("Wardobe slots that wardrobe recipes can be assigned to.")]
		public List<string> wardrobeSlots;

		private UMAPackedRecipeBase.UMAPackRecipe packedRecipe;

		private UMAData.UMARecipe unPackedRecipe;

		private Dictionary<string, float> RaceDNAValues;

		private List<OverlayColorData> RaceColorValues;

		[Obsolete("[RaceData backwardsCompatibleWith is deprecated and will be removed in a future version. Please use RaceData.CrossCompatibleRaces instead.")]
		public List<string> backwardsCompatibleWith;

		[SerializeField]
		private CrossCompatibilitySettingsList _crossCompatibilitySettings;

		public RaceThumbnails raceThumbnails;

		private Dictionary<string, List<string>> _usedBlendshapeNames;

		public string raceName;

		public List<string> KeepBoneNames;

		public List<string> tags;

		public bool disableDNAConverters;

		[Tooltip("if true, this will not be added to the index when all items are scanned.")]
		public bool noAutoAdd;

		[SerializeField]
		[Tooltip("The list of DNA Converters that this race uses. These are usually DynamicDNAConverterController assets.")]
		private DNAConverterList _dnaConverterList;

		public bool forceKeep;

		public bool labelLocalFiles;

		public UmaTPose TPose;

		public UMATarget umaTarget;

		public string genericRootMotionTransformName;

		public UMAExpressionSet expressionSet;

		public DNARangeAsset[] dnaRanges;

		public float raceHeight;

		public float raceRadius;

		public float raceMass;

		public bool NoAutoAdd
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public DynamicDNAConverterController[] dnaConverterList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ForceKeep
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LabelLocalFiles
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<OverlayColorData> GetDefaultColors()
		{
			return null;
		}

		public UMAPackedRecipeBase.UMAPackRecipe GetPackedRecipe()
		{
			return null;
		}

		public Dictionary<string, List<string>> GetDNAToBlendShapes()
		{
			return null;
		}

		public Dictionary<string, float> GetDefaultDNA()
		{
			return null;
		}

		public void AddDefaultWardrobeSlots(bool forceOverride = false)
		{
		}

		public bool ValidateWardrobeSlots(bool setToDefault = false)
		{
			return false;
		}

		[Obsolete("findBackwardsCompatibleWith has been depricated and will be removed in a future version. Please use 'IsCrossCompatibleWith' instead.")]
		public bool findBackwardsCompatibleWith(List<string> compatibleStrings)
		{
			return false;
		}

		public bool IsCrossCompatibleWith(RaceData compatibleRace)
		{
			return false;
		}

		public bool IsCrossCompatibleWith(string compatibleString)
		{
			return false;
		}

		public bool IsCrossCompatibleWith(List<string> compatibleStrings)
		{
			return false;
		}

		private void UpdateOldRace()
		{
		}

		public List<string> GetCrossCompatibleRaces()
		{
			return null;
		}

		public void SetCrossCompatibleRaces(List<string> ccRaces)
		{
		}

		protected List<CrossCompatibilityData> GetSettingsFor(string crossCompatibleRace)
		{
			return null;
		}

		public string FindEquivalentSlot(List<string> races, string crossCompatibleSlot, bool overlaysMustMatch = true)
		{
			return null;
		}

		public string FindEquivalentSlot(string race, string crossCompatibleSlot, bool overlaysMustMatch = true)
		{
			return null;
		}

		public bool GetOverlayCompatibility(string crossCompatibleSlot)
		{
			return false;
		}

		public bool GetOverlayCompatibility(string race, string crossCompatibleSlot)
		{
			return false;
		}

		public string GetAssetName()
		{
			return null;
		}

		public int GetNameHash()
		{
			return 0;
		}

		public List<string> GetDNANames()
		{
			return null;
		}

		public bool HasTag(string tag)
		{
			return false;
		}

		public void ResetDNA()
		{
		}

		public DynamicDNAConverterController[] GetConverters(UMADnaBase DNA)
		{
			return null;
		}

		public void AddConverter(IDNAConverter converter)
		{
		}

		private void Awake()
		{
		}

		public bool Validate()
		{
			return false;
		}

		public void UpdateDictionary()
		{
		}
	}
}
