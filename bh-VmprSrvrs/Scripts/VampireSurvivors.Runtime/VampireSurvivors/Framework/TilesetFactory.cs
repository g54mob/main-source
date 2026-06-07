using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "TilesetFactory", menuName = "VampireSurvivors/New TilesetFactory")]
	public class TilesetFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class TilesetRefsDictionary : UnitySerializedDictionary<StageType, PrefabRefData>
		{
		}

		[Serializable]
		public class PrefabRefData
		{
			[SerializeField]
			private AssetReference _PrefabRef;

			public AssetReference PrefabRef
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class TilesetPathsDictionary : UnitySerializedDictionary<StageType, TilesetPathData>
		{
		}

		[Serializable]
		public class TilesetPathData
		{
			[SerializeField]
			private string _TilemapPath;

			public string TilemapPath => null;

			public string TilemapPathWithExtension => null;
		}

		[SerializeField]
		private TilesetPathsDictionary _TilesetPaths;

		[SerializeField]
		private TilesetRefsDictionary _TilesetRefs;

		[SerializeField]
		private TilesetRefsDictionary _TilesetSupportRefs;

		[SerializeField]
		private List<TilesetFactory> _LinkedFactories;

		private Dictionary<StageType, SuperMap> _mapInstances;

		private SuperMap LoadFromAddressables(DlcType? dlcType, StageType stageType, TilesetFactory factory)
		{
			return null;
		}

		private void LoadFromAddressablesAsync(DlcType? dlcType, StageType stageType, TilesetFactory factory, Action<SuperMap> onComplete)
		{
		}

		public SuperMap CacheTilesetInstance(StageType stageType)
		{
			return null;
		}

		public SuperMap GetCachedTilesetInstance(StageType stageType)
		{
			return null;
		}

		public void ClearCachedTilesets()
		{
		}

		private SuperMap GetTilesetPrefabInternal(StageType stageType, Action<SuperMap> onComplete = null)
		{
			return null;
		}

		public GameObject GetTilesetSupportPrefab(StageType stageType)
		{
			return null;
		}

		public void GetTilesetSupportPrefabAsync(StageType stageType, Action<GameObject> onComplete)
		{
		}

		private GameObject GetTilesetSupportPrefabInternal(StageType stageType, Action<GameObject> onComplete = null)
		{
			return null;
		}

		public bool ContainsStage(StageType stageType)
		{
			return false;
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
