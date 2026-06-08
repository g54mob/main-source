using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class Biome : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public ElementSubType targetSubType;

		public ElementType targetElementType;

		public ElementVisualOption visualOption;

		public SessionQuestReward filterReward;

		internal bool _003CGetBiomeObjectConfiguration_003Eb__6(SegmentGroundColorOption x)
		{
			return x.segmentGroundType == targetSubType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__11(SegmentGroundColorOption x)
		{
			return x.segmentGroundType == targetSubType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__7(ElementOption x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__12(ElementOption x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__13(ElementVisualOptionCollection x)
		{
			return x.visualOptions.Contains(visualOption);
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__8(ElementOption x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__14(ElementOption x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__15(ElementVisualOptionCollection x)
		{
			return x.visualOptions.Contains(visualOption);
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__9(ElementOption x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__16(ElementOption x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__17(ElementVisualOptionCollection x)
		{
			return x.visualOptions.Contains(visualOption);
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__18(ElementVisualOptionCollection x)
		{
			return x.visualOptions.Contains(visualOption);
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__10(ElementOptionCollection x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__19(ElementOptionCollection x)
		{
			return x.elementType == targetElementType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__20(CollectionElementOption x)
		{
			return x.element.SubType == targetSubType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__21(CollectionElementOption x)
		{
			return x.element.SubType == targetSubType;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__0(ColorSet x)
		{
			return x.unlockReward == filterReward;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__1(ColorSet x)
		{
			return x.unlockReward == filterReward;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__3(ColorSet x)
		{
			return x.unlockReward == filterReward;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__4(ColorSet x)
		{
			return x.unlockReward == filterReward;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ColorSet, bool> _003C_003E9__37_2;

		public static Func<ColorSet, bool> _003C_003E9__37_5;

		public static Func<ElementVisualOption, bool> _003C_003E9__38_2;

		public static Func<ColorOption, bool> _003C_003E9__41_0;

		public static Func<SegmentGroundColorOption, bool> _003C_003E9__42_0;

		public static Func<SegmentGroundColorOption, bool> _003C_003E9__42_1;

		internal bool _003CGetBiomeObjectConfiguration_003Eb__37_2(ColorSet x)
		{
			if (!(x.unlockReward == null))
			{
				return x.unlockReward.state == RewardState.Completed;
			}
			return true;
		}

		internal bool _003CGetBiomeObjectConfiguration_003Eb__37_5(ColorSet x)
		{
			if (!(x.unlockReward == null))
			{
				return x.unlockReward.state == RewardState.Completed;
			}
			return true;
		}

		internal bool _003CUnlockedVisualOptions_003Eb__38_2(ElementVisualOption x)
		{
			if (!(x.unlockReward == null))
			{
				return x.unlockReward.state == RewardState.Completed;
			}
			return true;
		}

		internal bool _003CGetBiomeWaterMaterial_003Eb__41_0(ColorOption x)
		{
			return x.propertyName == "_WaterCol";
		}

		internal bool _003CGetColorSetsFor_003Eb__42_0(SegmentGroundColorOption x)
		{
			return x.segmentGroundType.groupTypeId == GroupTypeId.Forest;
		}

		internal bool _003CGetColorSetsFor_003Eb__42_1(SegmentGroundColorOption x)
		{
			return x.segmentGroundType.groupTypeId == GroupTypeId.Village;
		}
	}

	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public SessionQuestReward filterReward;

		internal bool _003CUnlockedVisualOptions_003Eb__0(ElementVisualOption x)
		{
			return x.unlockReward == filterReward;
		}

		internal bool _003CUnlockedVisualOptions_003Eb__1(ElementVisualOption x)
		{
			return x.unlockReward == filterReward;
		}
	}

	[SerializeField]
	private BiomeId id;

	[SerializeField]
	private Color cameraBackgroundColor;

	[SerializeField]
	private BiomePostProcessing postProcessingConfig;

	[SerializeField]
	private ColorSet uiColorSet;

	[SerializeField]
	private ColorSet tileSlotColorSets;

	[SerializeField]
	private List<ColorSet> groundColorSets;

	[SerializeField]
	private List<SegmentGroundColorOption> segmentGroundColorOptions;

	[SerializeField]
	private ColorSet waterColor;

	[FormerlySerializedAs("elements")]
	[SerializeField]
	private List<ElementOption> freeElements;

	[SerializeField]
	private List<ElementOptionCollection> elementCollections;

	[SerializeField]
	private List<ElementOption> questGivers;

	[SerializeField]
	private List<ElementOption> decorations;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	public SessionQuestReward unlockReward;

	[SerializeField]
	private Material tileSlotMaterial;

	private Material biomeTileSlotMaterial;

	[SerializeField]
	private Color overwriteAddedBackgroundColor = Color.clear;

	[SerializeField]
	private Material waterMaterial;

	private Material biomeWaterMaterial;

	public float biomeInstancingTextureCoordinate;

	public float windowGlow;

	public List<FloatOption> biomeFloatOptions;

	public List<CustomElementTypeTextures> customElementTypeTextures;

	private BiomeObjectConfiguration targetConfiguration = new BiomeObjectConfiguration();

	private List<ColorSet> defaultColors = new List<ColorSet>();

	public Color CameraBackgroundColor => cameraBackgroundColor;

	public BiomePostProcessing BiomePostProcessing => postProcessingConfig;

	public ColorSet WaterColorSet => waterColor;

	public BiomeId Id => id;

	public bool IsUnlocked
	{
		get
		{
			if (!(unlockReward == null))
			{
				return unlockReward.state == RewardState.Completed;
			}
			return true;
		}
	}

	public Dictionary<string, Color> GetGroundColor(Tile tileToUpdate)
	{
		Dictionary<string, Color> dictionary = new Dictionary<string, Color>();
		UnityEngine.Random.InitState(tileToUpdate.Seed);
		if (groundColorSets == null || groundColorSets.Count == 0)
		{
			return null;
		}
		foreach (ColorOption colorOption in groundColorSets[UnityEngine.Random.Range(0, groundColorSets.Count)].colorOptions)
		{
			dictionary.Add(colorOption.propertyName, colorOption.possibleColors.Evaluate(UnityEngine.Random.value));
		}
		Randomizer.RandomizeSeed();
		return dictionary;
	}

	public BiomeObjectConfiguration GetBiomeObjectConfiguration(IBiomeAffectedObject targetObject, SessionQuestReward filterReward = null)
	{
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals56 = new _003C_003Ec__DisplayClass37_0();
		CS_0024_003C_003E8__locals56.filterReward = filterReward;
		targetConfiguration.Clear();
		defaultColors.Clear();
		CS_0024_003C_003E8__locals56.visualOption = new ElementVisualOption();
		CS_0024_003C_003E8__locals56.targetElementType = null;
		CS_0024_003C_003E8__locals56.targetSubType = null;
		float overwriteAlpha = 0.5f;
		InstanceableCategoryId instanceableCategoryId = InstanceableCategoryId.Undefined;
		if (targetObject is Element element)
		{
			CS_0024_003C_003E8__locals56.targetElementType = element.ElementType;
			CS_0024_003C_003E8__locals56.targetSubType = element.SubType;
			overwriteAlpha = element.VariationAlpha;
		}
		else if (targetObject is QuestGiver questGiver)
		{
			CS_0024_003C_003E8__locals56.targetElementType = questGiver.ElementType;
			overwriteAlpha = questGiver.VariationAlpha;
		}
		else if (targetObject is InstanceableVisual instanceableVisual)
		{
			CS_0024_003C_003E8__locals56.targetElementType = instanceableVisual.ElementType;
			CS_0024_003C_003E8__locals56.targetSubType = instanceableVisual.elementSubType;
			overwriteAlpha = instanceableVisual.VariationAlpha;
			instanceableCategoryId = instanceableVisual.InstanceableCategory;
		}
		else if (targetObject is SegmentGround segmentGround)
		{
			CS_0024_003C_003E8__locals56.targetSubType = segmentGround.SubType;
		}
		if (targetObject is TileVisual)
		{
			CS_0024_003C_003E8__locals56.visualOption.colorSets = groundColorSets;
		}
		else
		{
			if (targetObject is ChangeCameraBackgroundBasedOnFocus)
			{
				targetConfiguration.biomeEffectValues.Add(new BiomeEffectValue("CameraBackground", cameraBackgroundColor));
				return targetConfiguration;
			}
			if (targetObject is ChangePostProcessingBasedOnFocus)
			{
				targetConfiguration.biomeEffectValues.Add(new BiomeEffectValue("BloomIntensity", postProcessingConfig.bloomIntensity));
				targetConfiguration.biomeEffectValues.Add(new BiomeEffectValue("BloomTint", postProcessingConfig.bloomColor));
				return targetConfiguration;
			}
			if (targetObject is ChangeMaterialBasedOnFocus changeMaterialBasedOnFocus)
			{
				if (changeMaterialBasedOnFocus.GroupType == null)
				{
					CS_0024_003C_003E8__locals56.visualOption.colorSets = new List<ColorSet> { tileSlotColorSets };
				}
				else
				{
					if (waterColor == null)
					{
						return null;
					}
					CS_0024_003C_003E8__locals56.visualOption.colorSets = new List<ColorSet> { waterColor };
				}
			}
			else if (targetObject is ChangeUIBasedOnFocus)
			{
				CS_0024_003C_003E8__locals56.visualOption.colorSets = new List<ColorSet> { uiColorSet };
			}
			else if ((targetObject is SegmentGround || (targetObject is InstanceableVisual && instanceableCategoryId == InstanceableCategoryId.SegmentGround)) && Enumerable.Count(segmentGroundColorOptions, (SegmentGroundColorOption x) => x.segmentGroundType == CS_0024_003C_003E8__locals56.targetSubType) > 0)
			{
				SegmentGroundColorOption segmentGroundColorOption = Enumerable.First(segmentGroundColorOptions, (SegmentGroundColorOption x) => x.segmentGroundType == CS_0024_003C_003E8__locals56.targetSubType);
				CS_0024_003C_003E8__locals56.visualOption.colorSets = segmentGroundColorOption.colorSets;
			}
			else if (targetObject is QuestGiver && Enumerable.Count(questGivers, (ElementOption x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType) > 0)
			{
				ElementOption elementOption = Enumerable.First(questGivers, (ElementOption x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType);
				List<ElementVisualOption> list = new List<ElementVisualOption>();
				foreach (ElementVisualOptionCollection item in elementOption.elementVisualOptionCollection)
				{
					list.AddRange(item.visualOptions);
				}
				list = UnlockedVisualOptions(list, CS_0024_003C_003E8__locals56.filterReward);
				CS_0024_003C_003E8__locals56.visualOption = Randomizer.SelectWeightedRandom(list, overwriteAlpha);
				ElementVisualOptionCollection elementVisualOptionCollection = Enumerable.First(elementOption.elementVisualOptionCollection, (ElementVisualOptionCollection x) => x.visualOptions.Contains(CS_0024_003C_003E8__locals56.visualOption));
				defaultColors.AddRange(elementVisualOptionCollection.defaultColors);
			}
			else if ((targetObject is DecorationElement || (targetObject is InstanceableVisual && instanceableCategoryId == InstanceableCategoryId.DecorationElement)) && Enumerable.Count(decorations, (ElementOption x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType) > 0)
			{
				ElementOption elementOption2 = Enumerable.First(decorations, (ElementOption x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType);
				List<ElementVisualOption> list2 = new List<ElementVisualOption>();
				foreach (ElementVisualOptionCollection item2 in elementOption2.elementVisualOptionCollection)
				{
					list2.AddRange(item2.visualOptions);
				}
				list2 = UnlockedVisualOptions(list2, CS_0024_003C_003E8__locals56.filterReward);
				CS_0024_003C_003E8__locals56.visualOption = Randomizer.SelectWeightedRandom(list2, overwriteAlpha);
				ElementVisualOptionCollection elementVisualOptionCollection2 = Enumerable.First(elementOption2.elementVisualOptionCollection, (ElementVisualOptionCollection x) => x.visualOptions.Contains(CS_0024_003C_003E8__locals56.visualOption));
				defaultColors.AddRange(elementVisualOptionCollection2.defaultColors);
				targetConfiguration.biomeValues.Add("displayProbability", settingsRouter.DecorationEnabled ? elementVisualOptionCollection2.displayProbability : 0f);
			}
			else if ((targetObject is Element || (targetObject is InstanceableVisual && instanceableCategoryId == InstanceableCategoryId.Element)) && Enumerable.Count(freeElements, (ElementOption x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType) > 0)
			{
				ElementOption elementOption3 = Enumerable.First(freeElements, (ElementOption x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType);
				List<ElementVisualOption> list3 = new List<ElementVisualOption>();
				foreach (ElementVisualOptionCollection item3 in elementOption3.elementVisualOptionCollection)
				{
					list3.AddRange(item3.visualOptions);
				}
				list3 = UnlockedVisualOptions(list3, CS_0024_003C_003E8__locals56.filterReward);
				CS_0024_003C_003E8__locals56.visualOption = Randomizer.SelectWeightedRandom(list3, overwriteAlpha);
				if (CS_0024_003C_003E8__locals56.visualOption == null)
				{
					Debug.LogError($"{base.name} no visual option selected for {targetObject}");
				}
				if (Enumerable.Count(elementOption3.elementVisualOptionCollection, (ElementVisualOptionCollection x) => x.visualOptions.Contains(CS_0024_003C_003E8__locals56.visualOption)) == 0)
				{
					Debug.LogError($"{base.name} collection {elementOption3.elementType} doesn't contain {CS_0024_003C_003E8__locals56.visualOption.visual}");
				}
				ElementVisualOptionCollection elementVisualOptionCollection3 = Enumerable.First(elementOption3.elementVisualOptionCollection, (ElementVisualOptionCollection x) => x.visualOptions.Contains(CS_0024_003C_003E8__locals56.visualOption));
				defaultColors.AddRange(elementVisualOptionCollection3.defaultColors);
				targetConfiguration.biomeValues.Add("displayProbability", elementVisualOptionCollection3.displayProbability);
			}
			else
			{
				if ((!(targetObject is Element) && (!(targetObject is InstanceableVisual) || instanceableCategoryId != InstanceableCategoryId.Element)) || Enumerable.Count(elementCollections, (ElementOptionCollection x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType) <= 0)
				{
					return null;
				}
				ElementOptionCollection elementOptionCollection = Enumerable.First(elementCollections, (ElementOptionCollection x) => x.elementType == CS_0024_003C_003E8__locals56.targetElementType);
				if (Enumerable.Count(elementOptionCollection.elementOptions, (CollectionElementOption x) => x.element.SubType == CS_0024_003C_003E8__locals56.targetSubType) == 0)
				{
					Debug.LogWarning($"{this}: no subType {CS_0024_003C_003E8__locals56.targetSubType} entry in collection for {CS_0024_003C_003E8__locals56.targetElementType}");
					return null;
				}
				CollectionElementOption collectionElementOption = Enumerable.First(elementOptionCollection.elementOptions, (CollectionElementOption x) => x.element.SubType == CS_0024_003C_003E8__locals56.targetSubType);
				List<ElementVisualOption> selection = UnlockedVisualOptions(collectionElementOption.elementVisualOptions);
				CS_0024_003C_003E8__locals56.visualOption = Randomizer.SelectWeightedRandom(selection, overwriteAlpha);
				defaultColors.AddRange(elementOptionCollection.defaultColors);
			}
		}
		if ((bool)CS_0024_003C_003E8__locals56.visualOption.visual)
		{
			targetConfiguration.visual = CS_0024_003C_003E8__locals56.visualOption.visual.GetComponent<ElementVisual>();
		}
		List<ColorSet> list4 = new List<ColorSet>();
		if (CS_0024_003C_003E8__locals56.visualOption.colorSets.Count > 0)
		{
			if ((bool)CS_0024_003C_003E8__locals56.filterReward && Enumerable.Count(CS_0024_003C_003E8__locals56.visualOption.colorSets, (ColorSet x) => x.unlockReward == CS_0024_003C_003E8__locals56.filterReward) > 0)
			{
				list4 = Enumerable.ToList(Enumerable.Where(CS_0024_003C_003E8__locals56.visualOption.colorSets, (ColorSet x) => x.unlockReward == CS_0024_003C_003E8__locals56.filterReward));
			}
			else
			{
				foreach (ColorSet colorSet2 in CS_0024_003C_003E8__locals56.visualOption.colorSets)
				{
					if (colorSet2 == null)
					{
						Debug.LogError($"colorSet in {base.name} for {targetObject} is null");
					}
				}
				list4.AddRange(Enumerable.Where(CS_0024_003C_003E8__locals56.visualOption.colorSets, (ColorSet x) => x.unlockReward == null || x.unlockReward.state == RewardState.Completed));
			}
		}
		if (defaultColors.Count > 0 && list4.Count == 0)
		{
			if ((bool)CS_0024_003C_003E8__locals56.filterReward && Enumerable.Count(defaultColors, (ColorSet x) => x.unlockReward == CS_0024_003C_003E8__locals56.filterReward) > 0)
			{
				list4 = Enumerable.ToList(Enumerable.Where(defaultColors, (ColorSet x) => x.unlockReward == CS_0024_003C_003E8__locals56.filterReward));
			}
			else
			{
				list4.AddRange(Enumerable.Where(defaultColors, (ColorSet x) => x.unlockReward == null || x.unlockReward.state == RewardState.Completed));
			}
		}
		if (list4.Count == 0)
		{
			if (defaultColors.Count > 0 || CS_0024_003C_003E8__locals56.visualOption.colorSets.Count > 0)
			{
				Debug.LogError($"No color set for {targetObject} in {this} is useable (all locked or unlockLevel too high)");
			}
			return targetConfiguration;
		}
		UnityEngine.Random.InitState(targetObject.Seed);
		ColorSet colorSet = list4[UnityEngine.Random.Range(0, list4.Count)];
		if (colorSet == null)
		{
			Debug.LogError($"selectedColorSet for {targetObject} in {this} is null");
		}
		foreach (TextureOption textureOption in colorSet.textureOptions)
		{
			Texture2D value = textureOption.possibleTextures[UnityEngine.Random.Range(0, textureOption.possibleTextures.Count)];
			targetConfiguration.biomeEffectValues.Add(new BiomeEffectValue(textureOption.propertyName, value, textureOption.rendererIndices));
		}
		foreach (ColorOption colorOption in colorSet.colorOptions)
		{
			Color color = colorOption.possibleColors.Evaluate(UnityEngine.Random.value);
			targetConfiguration.biomeEffectValues.Add(new BiomeEffectValue(colorOption.propertyName, color, colorOption.rendererIndices));
		}
		foreach (FloatOption floatOption in colorSet.floatOptions)
		{
			targetConfiguration.biomeEffectValues.Add(new BiomeEffectValue(floatOption.propertyName, floatOption.value, floatOption.rendererIndices));
		}
		Randomizer.RandomizeSeed();
		return targetConfiguration;
	}

	private List<ElementVisualOption> UnlockedVisualOptions(List<ElementVisualOption> visualOptions, SessionQuestReward filterReward = null)
	{
		_003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass38_0();
		CS_0024_003C_003E8__locals4.filterReward = filterReward;
		if ((bool)CS_0024_003C_003E8__locals4.filterReward && Enumerable.Count(visualOptions, (ElementVisualOption x) => x.unlockReward == CS_0024_003C_003E8__locals4.filterReward) > 0)
		{
			return Enumerable.ToList(Enumerable.Where(visualOptions, (ElementVisualOption x) => x.unlockReward == CS_0024_003C_003E8__locals4.filterReward));
		}
		return Enumerable.ToList(Enumerable.Where(visualOptions, (ElementVisualOption x) => x.unlockReward == null || x.unlockReward.state == RewardState.Completed));
	}

	public Color GetUiColor(out Color secondaryColor)
	{
		Color color = cameraBackgroundColor;
		if (overwriteAddedBackgroundColor != Color.clear)
		{
			secondaryColor = color + overwriteAddedBackgroundColor;
			return color;
		}
		secondaryColor = color;
		Color.RGBToHSV(secondaryColor, out var H, out var S, out var V);
		Vector3 vector = new Vector3(0f, -20f, 7f);
		Vector3 vector2 = new Vector3(H + vector.x / 100f, S + vector.y / 100f, V + vector.z / 100f);
		secondaryColor = Color.HSVToRGB(vector2.x, vector2.y, vector2.z);
		return color;
	}

	public Material GetBiomeTileSlotMaterial()
	{
		if (!biomeTileSlotMaterial)
		{
			biomeTileSlotMaterial = new Material(tileSlotMaterial);
			biomeTileSlotMaterial.name = "TileSlotMat_" + base.name;
			foreach (ColorOption colorOption in tileSlotColorSets.colorOptions)
			{
				biomeTileSlotMaterial.SetColor(colorOption.propertyName, (Color.white + colorOption.possibleColors.Evaluate(0f)) / 2f);
			}
		}
		return biomeTileSlotMaterial;
	}

	public Material GetBiomeWaterMaterial()
	{
		if (!biomeWaterMaterial)
		{
			biomeWaterMaterial = new Material(waterMaterial);
			biomeWaterMaterial.name = "WaterMat_" + base.name;
			foreach (ColorOption colorOption in waterColor.colorOptions)
			{
				biomeWaterMaterial.SetColor(colorOption.propertyName, (Color.white + colorOption.possibleColors.Evaluate(0f)) / 2f);
			}
			biomeWaterMaterial.SetFloat("_FoamIntensity", 0f);
			Color rgbColor = Enumerable.First(waterColor.colorOptions, (ColorOption x) => x.propertyName == "_WaterCol").possibleColors.Evaluate(0f);
			Color.RGBToHSV(rgbColor, out var H, out var S, out var V);
			rgbColor = Color.HSVToRGB(H, S * 1.5f, V);
			biomeWaterMaterial.SetColor("_WaterCol", rgbColor);
		}
		return biomeWaterMaterial;
	}

	public List<ColorSet> GetColorSetsFor(RecyclableType targetRecyclableId)
	{
		switch (targetRecyclableId)
		{
		case RecyclableType.TileGround:
			return groundColorSets;
		case RecyclableType.GroupShape_1A_Forest:
			return Enumerable.First(segmentGroundColorOptions, (SegmentGroundColorOption x) => x.segmentGroundType.groupTypeId == GroupTypeId.Forest).colorSets;
		case RecyclableType.GroupShape_1A_Village:
			return Enumerable.First(segmentGroundColorOptions, (SegmentGroundColorOption x) => x.segmentGroundType.groupTypeId == GroupTypeId.Village).colorSets;
		default:
			foreach (ElementOption freeElement in freeElements)
			{
				foreach (ElementVisualOptionCollection item in freeElement.elementVisualOptionCollection)
				{
					foreach (ElementVisualOption visualOption in item.visualOptions)
					{
						Instanceable componentInChildren = visualOption.visual.GetComponentInChildren<Instanceable>();
						if ((bool)componentInChildren && componentInChildren.RecyclableId == targetRecyclableId)
						{
							List<ColorSet> colorSets = visualOption.colorSets;
							if (colorSets != null && colorSets.Count > 0)
							{
								return visualOption.colorSets;
							}
							List<ColorSet> list = item.defaultColors;
							if (list != null && list.Count > 0)
							{
								return item.defaultColors;
							}
							return null;
						}
					}
				}
			}
			foreach (ElementOptionCollection elementCollection in elementCollections)
			{
				foreach (CollectionElementOption elementOption in elementCollection.elementOptions)
				{
					foreach (ElementVisualOption elementVisualOption in elementOption.elementVisualOptions)
					{
						Instanceable componentInChildren2 = elementVisualOption.visual.GetComponentInChildren<Instanceable>();
						if ((bool)componentInChildren2 && componentInChildren2.RecyclableId == targetRecyclableId)
						{
							List<ColorSet> colorSets2 = elementVisualOption.colorSets;
							if (colorSets2 != null && colorSets2.Count > 0)
							{
								return elementVisualOption.colorSets;
							}
							List<ColorSet> list2 = elementCollection.defaultColors;
							if (list2 != null && list2.Count > 0)
							{
								return elementCollection.defaultColors;
							}
							return null;
						}
					}
				}
			}
			foreach (ElementOption decoration in decorations)
			{
				foreach (ElementVisualOptionCollection item2 in decoration.elementVisualOptionCollection)
				{
					foreach (ElementVisualOption visualOption2 in item2.visualOptions)
					{
						Instanceable componentInChildren3 = visualOption2.visual.GetComponentInChildren<Instanceable>();
						if ((bool)componentInChildren3 && componentInChildren3.RecyclableId == targetRecyclableId)
						{
							List<ColorSet> colorSets3 = visualOption2.colorSets;
							if (colorSets3 != null && colorSets3.Count > 0)
							{
								return visualOption2.colorSets;
							}
							List<ColorSet> list3 = item2.defaultColors;
							if (list3 != null && list3.Count > 0)
							{
								return item2.defaultColors;
							}
							return null;
						}
					}
				}
			}
			return null;
		}
	}
}
