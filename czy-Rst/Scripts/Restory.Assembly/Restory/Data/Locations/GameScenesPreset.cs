using System;
using System.Collections.Generic;
using FullSerializer;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.FullSerializerWrappers.GameScenesPresets;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Restory.Data.Locations
{
	[CreateAssetMenu(fileName = "SceneList - NewListName", menuName = "Restory/Data/GameScenesPreset", order = 0)]
	[fsObject(Processor = typeof(GameScenesPresetProcessor))]
	public class GameScenesPreset : SerializedScriptableObject
	{
		private static class OdinStyle
		{
			public const string PresetType = "Preset Type";

			public const string GameMode = "GameMode";

			public const string GroupID = "General settings/I/Id";
		}

		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		[Range(0f, 1f)]
		private float loadingScreenAppearDuration = 1f;

		[SerializeField]
		private ScenePresetType presetType = ScenePresetType.Gameplay;

		[SerializeField]
		private GameMode gameplayMode;

		[SerializeField]
		private GameplaySubtype gameplaySubtype;

		[SerializeField]
		[Tooltip("Used to identify concrete container from save file, where SaveSystem will read or write data")]
		private SaveDataContainerId saveDataContainerId;

		[SerializeField]
		private AssetReference mainScene;

		[SerializeField]
		private AdditiveLocationInfo[] additiveScenes = Array.Empty<AdditiveLocationInfo>();

		public string ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public float LoadingScreenAppearDuration => loadingScreenAppearDuration;

		public ScenePresetType PresetType => presetType;

		public GameMode GameplayMode => gameplayMode;

		public GameplaySubtype GameplaySubtype => gameplaySubtype;

		public AssetReference MainScene => mainScene;

		public IReadOnlyCollection<AdditiveLocationInfo> AdditiveScenes => additiveScenes;

		public SaveDataContainerId SaveDataContainerId => saveDataContainerId;

		protected void OnValidate()
		{
			FillEmptyFields();
		}

		protected virtual void FillEmptyFields()
		{
		}
	}
}
