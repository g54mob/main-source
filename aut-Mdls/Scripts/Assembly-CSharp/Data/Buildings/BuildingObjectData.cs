using System;
using System.Collections.Generic;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables;
using FMODUnity;
using NaughtyAttributes;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using UnityEngine;

namespace Data.Buildings
{
	[Serializable]
	[CreateAssetMenu(menuName = "Factory/Buildings/BuildingObjectData", fileName = "BuildingObjectData", order = 0)]
	public class BuildingObjectData : FactoryObjectData
	{
		[Serializable]
		public struct BuildingResourceData
		{
			public ResourceDataSO ResourceData;

			public int Value;
		}

		[Serializable]
		public struct BuildingUpgrade
		{
			public int CostMultiplier;

			public ResourceCost UpgradeCost;

			public int ProductionLevel;

			public List<BuildingResourceData> ResourceCounts;
		}

		[SerializeField]
		private string _name;

		[Header("Input")]
		[SerializeField]
		private List<BuildingResourceData> _additionalProduceInputs = new List<BuildingResourceData>();

		[Header("Output")]
		[SerializeField]
		private float _producingCostMultiplier = 0.25f;

		[SerializeField]
		private List<BuildingResourceData> _resourceOutputs;

		[SerializeField]
		private EventReference _producedSFX;

		[SerializeField]
		private bool _needsConditionToWork;

		[SerializeField]
		[ShowIf("_needsConditionToWork")]
		private BoolVariableSO _conditionToWork;

		[SerializeField]
		[ShowIf("_needsConditionToWork")]
		private MainThreadBoolVariableSO _mainThreadConditionToWork;

		[Header("Upgrades")]
		[SerializeField]
		private List<BuildingUpgrade> _upgrades = new List<BuildingUpgrade>();

		[SerializeField]
		private BuildingMaxLockedStageData _buildingMaxLockedStageData;

		[SerializeField]
		[BoxGroup("Refs")]
		private DioramaEditorSave _dioramaSave;

		[SerializeField]
		[BoxGroup("Refs")]
		private AnimationClip _activationAnimationClip;

		[SerializeField]
		[BoxGroup("Refs")]
		[ShowAssetPreview(64, 64)]
		private Texture2D _meshRenderIcon;

		[SerializeField]
		[BoxGroup("General")]
		private int _familyID;

		[SerializeField]
		[BoxGroup("General")]
		private BuildingCategoryType _categoryType;

		[SerializeField]
		[BoxGroup("General")]
		private Vector2Int _buildingSize = new Vector2Int(6, 6);

		[SerializeField]
		[BoxGroup("Polished Prefabs")]
		private bool _randomizeFloorRotation = true;

		[SerializeField]
		[BoxGroup("Polished Prefabs")]
		[ShowIf("_randomizeFloorRotation")]
		private bool _180RotationOnly;

		[SerializeField]
		[HideInInspector]
		private Vector3 _meshOffset;

		private ModuleViewerData _moduleViewerData;

		[field: SerializeField]
		[field: BoxGroup("Polished Prefabs")]
		public GameObject PlatformPrefab { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Polished Prefabs")]
		[field: Space]
		public BuildingCompletionEffect SinglePrefabRef { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Polished Prefabs")]
		public BuildingCompletionEffect BottomPrefabRef { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Polished Prefabs")]
		public BuildingCompletionEffect MiddlePrefabRef { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Polished Prefabs")]
		public BuildingCompletionEffect TopPrefabRef { get; private set; }

		public string Name => _name;

		public bool RandomizeFloorRotation => _randomizeFloorRotation;

		public bool Rotation180Only => _180RotationOnly;

		public bool ConditionToWorkIsMet
		{
			get
			{
				if (_needsConditionToWork)
				{
					if (!(_conditionToWork != null) || !_conditionToWork.Value)
					{
						if (_mainThreadConditionToWork != null)
						{
							return _mainThreadConditionToWork.Value;
						}
						return false;
					}
					return true;
				}
				return true;
			}
		}

		public DioramaEditorSave DioramaSave => _dioramaSave;

		public Texture2D MeshRenderIcon => _meshRenderIcon;

		public int FamilyID => _familyID;

		public BuildingCategoryType CategoryType => _categoryType;

		public Vector2Int BuildingSize => _buildingSize;

		public List<BuildingResourceData> AdditionalInputs => _additionalProduceInputs;

		public float ProducingCostMultiplier => _producingCostMultiplier;

		public List<BuildingUpgrade> Upgrades => _upgrades;

		public int BuildingMaxLockedStage => _buildingMaxLockedStageData.MaxLockedBuildingStage;

		public List<BuildingResourceData> ResourceOutputs => _resourceOutputs;

		public EventReference ProducedSFX => _producedSFX;

		public Vector3 MeshOffset => _meshOffset;

		public ModuleViewerData GetModuleViewerData => _moduleViewerData ?? (_moduleViewerData = InitModuleViewerData());

		public AnimationClip ActivationAnimationClip => _activationAnimationClip;

		protected override void OnValidate()
		{
			base.OnValidate();
			foreach (BuildingUpgrade upgrade in _upgrades)
			{
				foreach (BuildingResourceData resourceOutput in _resourceOutputs)
				{
					bool flag = false;
					foreach (BuildingResourceData resourceCount in upgrade.ResourceCounts)
					{
						if (resourceCount.ResourceData == resourceOutput.ResourceData)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						upgrade.ResourceCounts.Add(new BuildingResourceData
						{
							ResourceData = resourceOutput.ResourceData
						});
					}
				}
				for (int num = upgrade.ResourceCounts.Count - 1; num >= 0; num--)
				{
					foreach (BuildingResourceData resourceOutput2 in _resourceOutputs)
					{
						bool flag2 = false;
						foreach (BuildingResourceData resourceCount2 in upgrade.ResourceCounts)
						{
							if (resourceCount2.ResourceData == resourceOutput2.ResourceData)
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							upgrade.ResourceCounts.RemoveAt(num);
						}
					}
				}
			}
			foreach (BuildingUpgrade upgrade2 in _upgrades)
			{
				while (upgrade2.ResourceCounts.Count < _resourceOutputs.Count)
				{
					upgrade2.ResourceCounts.Add(new BuildingResourceData
					{
						ResourceData = _resourceOutputs[upgrade2.ResourceCounts.Count].ResourceData,
						Value = 2
					});
				}
				while (upgrade2.ResourceCounts.Count > _resourceOutputs.Count)
				{
					upgrade2.ResourceCounts.RemoveAt(upgrade2.ResourceCounts.Count - 1);
				}
				for (int i = 0; i < upgrade2.ResourceCounts.Count; i++)
				{
					upgrade2.ResourceCounts[i] = new BuildingResourceData
					{
						ResourceData = _resourceOutputs[i].ResourceData,
						Value = upgrade2.ResourceCounts[i].Value
					};
				}
			}
		}

		[Button("Set Positions From Building Size", EButtonEnableMode.Always)]
		public override void UpdateRelativePositions()
		{
			base.RelativePositions.Clear();
			base.RelativePositions.Add(Vector3Int.zero);
			int num = _buildingSize.x / 2;
			int num2 = _buildingSize.y / 2;
			for (int i = 0; i < _buildingSize.y; i++)
			{
				for (int j = 0; j < _buildingSize.x; j++)
				{
					Vector3Int item = new Vector3Int(j - num, 0, i - num2);
					if (item.x != 0 || item.z != 0)
					{
						base.RelativePositions.Add(item);
					}
				}
			}
			_meshOffset = new Vector3((_buildingSize.x % 2 == 0) ? (-0.5f) : 0f, 0f, (_buildingSize.y % 2 == 0) ? (-0.5f) : 0f);
		}

		public int GetResourceOutputAtStage(ResourceDataSO resourceData, int stage)
		{
			stage--;
			if (stage > _upgrades.Count)
			{
				stage = _upgrades.Count;
			}
			int num = -1;
			for (int i = 0; i < _resourceOutputs.Count; i++)
			{
				if (_resourceOutputs[i].ResourceData == resourceData)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return 0;
			}
			if (stage <= 0)
			{
				return _resourceOutputs[num].Value;
			}
			return _upgrades[stage - 1].ResourceCounts[num].Value;
		}

		public int GetProductionLevelAtStage(int stage)
		{
			stage--;
			if (stage > _upgrades.Count)
			{
				stage = _upgrades.Count;
			}
			if (stage <= 0)
			{
				return 1;
			}
			return _upgrades[stage - 1].ProductionLevel;
		}

		public int GetProductionLevelAtStageMax()
		{
			if (_upgrades.Count == 0)
			{
				return 1;
			}
			List<BuildingUpgrade> upgrades = _upgrades;
			return upgrades[upgrades.Count - 1].ProductionLevel;
		}

		private ModuleViewerData InitModuleViewerData()
		{
			string nameLocKey = base.NameLocKey;
			Sprite previewSprite = null;
			if (MeshRenderIcon != null)
			{
				previewSprite = Sprite.Create(MeshRenderIcon, new Rect(0f, 0f, MeshRenderIcon.width, MeshRenderIcon.height), new Vector2(0.5f, 0.5f));
			}
			List<ModuleViewerData.ShapeDataAndAmount> list = new List<ModuleViewerData.ShapeDataAndAmount>(DioramaSave.DioramaShapesDictionary.Count);
			foreach (DioramaEditorSave.DioramaShapeCollection value in DioramaSave.DioramaShapesDictionary.Values)
			{
				list.Add(new ModuleViewerData.ShapeDataAndAmount(value.ShapeData, value.Shapes.Count));
			}
			return new ModuleViewerData(nameLocKey, previewSprite, list, base.ID);
		}
	}
}
