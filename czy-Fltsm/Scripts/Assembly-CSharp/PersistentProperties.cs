using System;
using UnityEngine;

public abstract class PersistentProperties : ScriptableObject
{
	public enum Types
	{
		DrifterAttributeEffect = 0,
		DrifterLookMaterialProperties = 1,
		DrifterLookPart = 2,
		DrifterLookProperties = 3,
		BuildableProperties = 4,
		FlotsamProperties = 5,
		PointOfInterestProperties = 6,
		NotificationProperties = 7,
		CursorProperties = 8,
		ItemProperties = 9,
		LandmarkBehaviour = 10,
		ProjectProperties = 11,
		TileProperties = 12,
		DiseaseProperties = 13,
		SurvivalGuideNotificationProperties = 14,
		MoraleEffect = 15,
		LandmarkSalvageableCategory = 16,
		DecorationProperties = 17,
		TileGeneratorBase = 18,
		FishProperties = 19,
		QuestProperties = 20,
		DialogueProperties = 21,
		VoicePack = 22,
		ActorProfile = 23,
		Scenario = 24,
		ProductionRecipe = 25,
		RadioMessage = 26,
		Upgrade = 27,
		UnlockableGroup = 255
	}

	[NonSerialized]
	private PersistentProperties _originalAsset;

	public abstract Types Type { get; }

	protected PersistentProperties GetInstance()
	{
		PersistentProperties persistentProperties = ((_originalAsset == null) ? this : _originalAsset);
		PersistentProperties persistentProperties2 = UnityEngine.Object.Instantiate(persistentProperties);
		persistentProperties2._originalAsset = persistentProperties;
		return persistentProperties2;
	}

	public int GetIndex()
	{
		return GameManager.PersistenceManager.ReturnPropertiesIndex((_originalAsset == null) ? this : _originalAsset);
	}
}
