using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.Operator;
using Data.Shapes;
using Events.FactoryFloor;
using NaughtyAttributes;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Presentation.Buildings
{
	public class BuildingView : FactoryResourceHolderView<BuildingBehaviour>, BuildingViewEvents
	{
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private BuildingVisuals _origBuildingObjectVisuals;

		[SerializeField]
		private BoxCollider _collider;

		[SerializeField]
		private BoxCollider _platformCollider;

		[SerializeField]
		private BoxCollider _droneCollider;

		[SerializeField]
		private FactoryObjectView _factoryObjectView;

		[Header("Custom Culling")]
		[SerializeField]
		private FactoryObjectViewCullingController _factoryObjectViewCullingController;

		[SerializeField]
		private List<Renderer> _cullableRenderers = new List<Renderer>();

		[Header("Platform")]
		[SerializeField]
		private Transform _platformParent;

		private readonly List<BuildingVisuals> _buildingObjectVisuals = new List<BuildingVisuals>();

		private bool _isInitialized;

		private readonly List<Collider> _manualColliders = new List<Collider>();

		private readonly List<Collider> _currentColliders = new List<Collider>();

		public event Action OnBuildingInit = delegate
		{
		};

		public event Action OnBuildingPreviewInit = delegate
		{
		};

		protected override void PreviewInit(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			BuildingObjectData data = _factoryObjectDatabase.GetObjectDataWithId(objectId) as BuildingObjectData;
			GeneratePlatform(data);
			bool flag = false;
			foreach (BehaviourSaveStateDto saveState in element.SaveStates)
			{
				if (!(saveState is BuildingBehaviourSaveStateDto buildingBehaviourSaveStateDto))
				{
					continue;
				}
				InitBuildingVisuals(data);
				SpawnBuildingVisuals(_buildingObjectVisuals.Count);
				SetBuildingStage(buildingBehaviourSaveStateDto.Stage, buildingBehaviourSaveStateDto.IsUpgrading, hologram: true);
				foreach (BuildingVisuals buildingObjectVisual in _buildingObjectVisuals)
				{
					buildingObjectVisual.ShowHologramVisuals();
				}
				flag = true;
			}
			if (!flag)
			{
				_origBuildingObjectVisuals.gameObject.SetActive(value: true);
				_origBuildingObjectVisuals.Init(data);
				_buildingObjectVisuals.Add(_origBuildingObjectVisuals);
				SpawnBuildingVisuals(0);
				_buildingObjectVisuals[0].ShowHologramVisuals();
			}
			_factoryObjectView.ValidPositionChanged += UpdateValidPosition;
			ToggleColliders(toggle: false);
			this.OnBuildingPreviewInit();
		}

		private void HandleCullState(CullableObjectState newCullState, CullableObjectState prevCullState = CullableObjectState.Normal)
		{
			switch (newCullState)
			{
			case CullableObjectState.Normal:
			case CullableObjectState.LOD:
				ForceCullableRenderers(value: false);
				break;
			case CullableObjectState.ShadowsOnly:
			case CullableObjectState.Culled:
				ForceCullableRenderers(value: true);
				break;
			}
		}

		private void ForceCullableRenderers(bool value)
		{
			for (int num = _cullableRenderers.Count - 1; num >= 0; num--)
			{
				Renderer renderer = _cullableRenderers[num];
				if (renderer == null)
				{
					_cullableRenderers.RemoveAt(num);
				}
				else
				{
					renderer.forceRenderingOff = value;
				}
			}
		}

		private void ToggleColliders(bool toggle)
		{
			foreach (Collider currentCollider in _currentColliders)
			{
				currentCollider.enabled = toggle;
			}
			_platformCollider.enabled = toggle;
		}

		private void UpdateValidPosition(bool isValid)
		{
			foreach (BuildingVisuals buildingObjectVisual in _buildingObjectVisuals)
			{
				buildingObjectVisual.SetValid(isValid);
			}
		}

		protected override void Init()
		{
			base.Init();
			Subscribe();
			_isInitialized = true;
			InitBuildingVisuals(_behaviour.BuildingObjectData);
			GeneratePlatform(_behaviour.BuildingObjectData);
			SetBuildingStage(_behaviour.CurrentBuildingStage, _behaviour.IsUpgrading);
			AddCurrentShapes();
			_platformParent.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
			ToggleColliders(toggle: true);
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			HandleCullState(_factoryObjectViewCullingController.CurrentState);
			this.OnBuildingInit();
		}

		private void Update()
		{
			if (!_isInitialized)
			{
				_platformParent.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
			}
		}

		private void Subscribe()
		{
			_behaviour.OnStageCompleted.RegisterMainThread(StageCompletedAnimation);
			_behaviour.OnShapeAdded.RegisterMainThread(ShapeAdded);
			_behaviour.OnUpgradeStateChanged.RegisterMainThread(OnUpgradeStateChanged);
			_behaviour.OnCreatedResources.RegisterMainThread(OnCreatedResources);
		}

		private void Unsubscribe()
		{
			_factoryObjectView.ValidPositionChanged += UpdateValidPosition;
			if ((bool)_behaviour)
			{
				if (_behaviour.CurrentBuildingStage < _buildingObjectVisuals.Count && _buildingObjectVisuals[_behaviour.CurrentBuildingStage].IsAnimating)
				{
					_buildingObjectVisuals[_behaviour.CurrentBuildingStage].OnTransitionEnd -= SetBuildingStageDelayed;
				}
				_behaviour.OnStageCompleted.UnRegisterMainThread(StageCompletedAnimation);
				_behaviour.OnShapeAdded.UnRegisterMainThread(ShapeAdded);
				_behaviour.OnUpgradeStateChanged.UnRegisterMainThread(OnUpgradeStateChanged);
				_behaviour.OnCreatedResources.UnRegisterMainThread(OnCreatedResources);
			}
		}

		protected override void OnDestroy()
		{
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			_cullableRenderers.Clear();
			_isInitialized = false;
			Unsubscribe();
			base.OnDestroy();
		}

		private void GeneratePlatform(BuildingObjectData data)
		{
			GameObject obj = UnityEngine.Object.Instantiate(data.PlatformPrefab, _platformParent);
			Renderer[] componentsInChildren = _platformParent.GetComponentsInChildren<Renderer>();
			_cullableRenderers.AddRange(componentsInChildren);
			HandleCullState(_factoryObjectViewCullingController.CurrentState);
			if (obj.TryGetComponent<BuildingOverclockReceiverView>(out var component))
			{
				component.SetObjectView(_objectView);
			}
			_platformParent.transform.localPosition = new Vector3(data.MeshOffset.x, -0.499f, data.MeshOffset.z);
		}

		private void AddCurrentShapes()
		{
			foreach (BuildingConstructionResource buildRequirement in _behaviour.BuildRequirements)
			{
				if (buildRequirement is ShapeConstructionResource shapeConstructionResource)
				{
					ShapeAddedNoAnim(shapeConstructionResource.ShapeData, shapeConstructionResource.Count);
				}
			}
		}

		private void InitBuildingVisuals(BuildingObjectData data)
		{
			_origBuildingObjectVisuals.Init(data);
			_buildingObjectVisuals.Add(_origBuildingObjectVisuals);
			BuildingCompletionEffect buildingCompletionEffect = UnityEngine.Object.Instantiate(data.SinglePrefabRef);
			for (int i = 0; i < data.Upgrades.Count; i++)
			{
				BuildingVisuals buildingVisuals = UnityEngine.Object.Instantiate(_origBuildingObjectVisuals, _origBuildingObjectVisuals.transform.parent);
				buildingVisuals.Init(data);
				buildingVisuals.transform.position += Vector3.up * (buildingCompletionEffect.BoundsSize.y * (float)(i + 1) * _origBuildingObjectVisuals.transform.localScale.y);
				if (_behaviour != null && data.RandomizeFloorRotation)
				{
					System.Random random = new System.Random(_behaviour.Position.x * _behaviour.Position.z + _behaviour.FactoryObject.ObjectId + i);
					if (data.Rotation180Only)
					{
						buildingVisuals.PolishedParent.transform.Rotate(Vector3.up, 180 * random.Next(2));
					}
					else
					{
						buildingVisuals.PolishedParent.transform.Rotate(Vector3.up, 90 * random.Next(4));
					}
				}
				buildingVisuals.gameObject.SetActive(value: false);
				_buildingObjectVisuals.Add(buildingVisuals);
			}
			UnityEngine.Object.Destroy(buildingCompletionEffect.gameObject);
		}

		private void SetBuildingStage(int stage, bool isUpgrading, bool hologram = false)
		{
			if (!isUpgrading)
			{
				stage = Mathf.Max(0, stage - 1);
			}
			SpawnBuildingVisuals(stage);
			for (int i = 0; i < stage; i++)
			{
				_buildingObjectVisuals[i].gameObject.SetActive(value: true);
				if (hologram)
				{
					_buildingObjectVisuals[i].ShowHologramVisuals();
				}
				else
				{
					_buildingObjectVisuals[i].ShowPolishedVisuals();
				}
			}
			_buildingObjectVisuals[stage].gameObject.SetActive(value: true);
			if (isUpgrading)
			{
				_buildingObjectVisuals[stage].ResetShapes();
				_buildingObjectVisuals[stage].ShowHologramVisuals();
			}
			else
			{
				if (hologram)
				{
					_buildingObjectVisuals[stage].ShowHologramVisuals();
				}
				else
				{
					_buildingObjectVisuals[stage].ShowPolishedVisuals();
				}
				if (stage + 1 < _buildingObjectVisuals.Count)
				{
					_buildingObjectVisuals[stage + 1].gameObject.SetActive(value: false);
				}
			}
			for (int j = 0; j <= stage; j++)
			{
				_cullableRenderers.AddRange(_buildingObjectVisuals[j].GetComponentsInChildren<Renderer>());
			}
			HandleCullState(_factoryObjectViewCullingController.CurrentState);
			UpdateBuildingCollider();
		}

		protected override void ResetFactoryObject()
		{
			Unsubscribe();
			for (int num = _platformParent.transform.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(_platformParent.GetChild(num).gameObject);
			}
			for (int num2 = _buildingObjectVisuals.Count - 1; num2 >= 1; num2--)
			{
				UnityEngine.Object.Destroy(_buildingObjectVisuals[num2].gameObject);
			}
			DeleteManualColliders();
			_buildingObjectVisuals[0].Reset();
			_buildingObjectVisuals.Clear();
			_currentColliders.Clear();
			_isInitialized = false;
			base.ResetFactoryObject();
		}

		private void OnUpgradeStateChanged(bool upgrading)
		{
			SetBuildingStage(_behaviour.CurrentBuildingStage, upgrading);
		}

		private void ShapeAdded(ShapeData shapeData, int index)
		{
			if (!(shapeData == null) && _behaviour.IsUpgrading && _buildingObjectVisuals.Count > _behaviour.CurrentBuildingStage)
			{
				_buildingObjectVisuals[_behaviour.CurrentBuildingStage].AddShape(shapeData, index);
			}
		}

		private void ShapeAddedNoAnim(ShapeData shapeData, int index)
		{
			if (_behaviour.IsUpgrading && _buildingObjectVisuals.Count > _behaviour.CurrentBuildingStage)
			{
				_buildingObjectVisuals[_behaviour.CurrentBuildingStage].AddShape(shapeData, index, anim: false);
			}
		}

		private void StageCompletedAnimation(int stage)
		{
			if (_behaviour.BuildingObjectData.CategoryType != BuildingCategoryType.Monuments)
			{
				TriggerBuildingCompletion(stage);
			}
		}

		public void TriggerBuildingCompletion(int stage)
		{
			_audioManagerLocator.AudioManager.PlayFloorCompleted(base.transform.position, _factoryObjectView.FactoryObject.FactoryObjectData.ObjectSize);
			_buildingObjectVisuals[stage].PlayBuildingVisualsFinishedAnimation();
			_buildingObjectVisuals[stage].OnTransitionEnd += SetBuildingStageDelayed;
		}

		private void SetBuildingStageDelayed()
		{
			_buildingObjectVisuals[_behaviour.CurrentBuildingStage - 1].OnTransitionEnd -= SetBuildingStageDelayed;
			if (_behaviour.IsUpgrading)
			{
				SetBuildingStage(_behaviour.CurrentBuildingStage, _behaviour.IsUpgrading);
			}
		}

		private void SpawnBuildingVisuals(int finishedStageIndex)
		{
			finishedStageIndex = Mathf.Max(finishedStageIndex, 0);
			if (finishedStageIndex == 0)
			{
				_buildingObjectVisuals[0].SpawnVisuals(BuildingVisuals.BuildingStageType.Single);
				return;
			}
			int num = Mathf.Min(finishedStageIndex + 1, _buildingObjectVisuals.Count);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					_buildingObjectVisuals[i].SpawnVisuals(BuildingVisuals.BuildingStageType.Bottom);
				}
				else if (i == num - 1)
				{
					_buildingObjectVisuals[i].SpawnVisuals(BuildingVisuals.BuildingStageType.Top);
				}
				else
				{
					_buildingObjectVisuals[i].SpawnVisuals(BuildingVisuals.BuildingStageType.Middle);
				}
			}
		}

		private void UpdateBuildingCollider()
		{
			if (_isInitialized)
			{
				DeleteManualColliders();
				if (_buildingObjectVisuals[0].BuildingCompletionEffect.OverrideColliders)
				{
					UpdateManualColliders();
				}
				else
				{
					UpdateAutoGeneratedCollider();
				}
				UpdatePlatformCollider();
			}
		}

		private void UpdatePlatformCollider()
		{
			_platformCollider.size = new Vector3(_behaviour.BuildingObjectData.BuildingSize.x - 1, _platformCollider.size.y, _behaviour.BuildingObjectData.BuildingSize.y - 1);
			_platformCollider.center = new Vector3((_behaviour.BuildingObjectData.BuildingSize.x % 2 == 0) ? (-0.5f) : 0f, _platformCollider.center.y, (_behaviour.BuildingObjectData.BuildingSize.y % 2 == 0) ? (-0.5f) : 0f);
		}

		private void UpdateAutoGeneratedCollider()
		{
			_collider.enabled = true;
			int num = (_behaviour.IsUpgrading ? (_behaviour.CurrentBuildingStage + 1) : _behaviour.CurrentBuildingStage);
			Vector3 boundsSize = _buildingObjectVisuals[0].BoundsSize;
			Vector3 vector = Quaternion.Euler(0f, _buildingObjectVisuals[0].transform.rotation.eulerAngles.y, 0f) * boundsSize;
			_collider.size = new Vector3(vector.x, boundsSize.y * (float)num, vector.z);
			_collider.center = base.transform.InverseTransformPoint(_buildingObjectVisuals[0].CenterPosition) + Vector3.up * (_collider.size.y * 0.5f);
			_currentColliders.Clear();
			_currentColliders.Add(_collider);
			_droneCollider.size = _collider.size;
			_droneCollider.center = _collider.center;
		}

		private void UpdateManualColliders()
		{
			_collider.enabled = false;
			_currentColliders.Clear();
			foreach (BoxCollider collider in _buildingObjectVisuals[0].BuildingCompletionEffect.Colliders)
			{
				collider.enabled = false;
				BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
				Quaternion quaternion = Quaternion.Euler(0f, _buildingObjectVisuals[0].BuildingCompletionEffect.transform.localRotation.eulerAngles.y, 0f);
				Vector3 localScale = _buildingObjectVisuals[0].BuildingCompletionEffect.transform.localScale;
				Vector3 position = _buildingObjectVisuals[0].BuildingCompletionEffect.transform.TransformPoint(collider.center);
				Vector3 size = Vector3.Scale(quaternion * collider.size, localScale);
				boxCollider.size = size;
				boxCollider.center = base.transform.InverseTransformPoint(position);
				_manualColliders.Add(boxCollider);
				_currentColliders.Add(boxCollider);
			}
		}

		private void DeleteManualColliders()
		{
			for (int num = _manualColliders.Count - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(_manualColliders[num]);
			}
			_manualColliders.Clear();
		}

		public override void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true)
		{
			ResourceViewManager.Instance.ReturnResourceToPool(resource);
		}

		private void OnCreatedResources(BuildingBehaviour behaviour)
		{
			if (!_behaviour.BuildingObjectData.ProducedSFX.IsNull)
			{
				_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_behaviour.BuildingObjectData.ProducedSFX, _objectView.transform.position, _behaviour.BuildingObjectData.ObjectSize);
			}
		}

		[Button("Find All MeshRenderers", EButtonEnableMode.Always)]
		private void EditorFindAllMeshRenderers()
		{
			GetComponentsInChildren(_cullableRenderers);
		}
	}
}
