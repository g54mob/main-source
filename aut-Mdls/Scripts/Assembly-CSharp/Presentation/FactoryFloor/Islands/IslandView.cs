using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.GameMode;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Events.FactoryFloor.Islands;
using Events.Generic;
using Events.Islands;
using Logic.Factory;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandView : MonoBehaviour
	{
		private static readonly int MainTex = Shader.PropertyToID("_PixelTextureIDs");

		private static readonly int GridSize = Shader.PropertyToID("_GridSize");

		private static readonly int Elevated = Shader.PropertyToID("_Elevated");

		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private MeshRenderer _heightMeshRenderer;

		[SerializeField]
		private MeshRenderer _waterPlaneMeshRenderer;

		[SerializeField]
		private MeshRenderer _waterBottomMeshRenderer;

		[SerializeField]
		private Material _islandMaterial;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private BoxCollider _boxCollider;

		[SerializeField]
		private BoxCollider _heightBoxCollider;

		[SerializeField]
		private BoolEvent _islandEditorHeightEvent;

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private IslandViewBottom[] _smallIslandBottomObjects;

		[SerializeField]
		private IslandViewBottom[] _mediumIslandBottomObjects;

		[SerializeField]
		private IslandViewBottom[] _bigIslandBottomObjects;

		[SerializeField]
		private IslandViewBottom[] _creativeModeBigIslandBottomObjects;

		[SerializeField]
		private CurrentGameMode _currentGameMode;

		[SerializeField]
		private GameModeSO _levelEditorGameMode;

		[SerializeField]
		private IslandCullStateChangedEventSO _islandCullStateChangedEvent;

		[SerializeField]
		private BaseIslandLockView _islandLockView;

		[SerializeField]
		private ZenModeVariableSO _zenMode;

		[Header("Culling")]
		[SerializeField]
		private IslandInstancedObjectsDrawer _islandInstancedObjectsDrawer;

		private IslandViewBottom _spawnedBottom;

		private IslandObject _islandObject;

		private IslandData _instancedIslandData;

		private readonly Dictionary<FactoryObjectView, Dictionary<Vector3Int, Color32>> _previousTilesColor = new Dictionary<FactoryObjectView, Dictionary<Vector3Int, Color32>>();

		private readonly Dictionary<FactoryObject, FactoryObjectView> _currentFactoryObjectViews = new Dictionary<FactoryObject, FactoryObjectView>();

		private MeshRenderer[] _bottomMeshRenderers;

		private List<MeshRenderer> _bottomLockedMeshRenderers;

		public IslandData IslandData => _instancedIslandData;

		public event Action OnViewShow;

		public event Action OnViewHide;

		public event Action<IslandData> OnViewCreated;

		public event Action<FactoryObjectView, FactoryObject> OnFactoryObjectViewCreatedOnIsland;

		public event Action<FactoryObjectView, FactoryObject> OnFactoryObjectViewRemovedOnIsland;

		private void Start()
		{
			_islandEditorHeightEvent.Register(SetHeightCollider);
			_islandCullStateChangedEvent.Register(IslandChangedCullingState);
		}

		private void OnDestroy()
		{
			_islandEditorHeightEvent.UnRegister(SetHeightCollider);
			_islandCullStateChangedEvent.UnRegister(IslandChangedCullingState);
			if (_currentGameMode.Mode != _levelEditorGameMode)
			{
				if (_islandObject != null)
				{
					_islandObject.OnFactoryObjectRemoved -= OnFactoryObjectRemoved;
				}
				if (FactoryObjectViewManager.Instance != null)
				{
					FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated -= OnFactoryObjectViewCreated;
					FactoryObjectViewManager.Instance.OnFactoryObjectViewRemoved -= OnFactoryObjectViewRemoved;
				}
			}
			_islandInstancedObjectsDrawer = null;
			_spawnedBottom = null;
			_islandObject = null;
		}

		private void SetHeightCollider(bool enabled)
		{
			_heightBoxCollider.enabled = enabled;
		}

		public void SetIslandObject(IslandObject islandObject)
		{
			_islandObject = islandObject;
			if (_currentGameMode.Mode != _levelEditorGameMode)
			{
				_islandObject.OnFactoryObjectRemoved += OnFactoryObjectRemoved;
			}
			switch (_islandObject.GetCullState())
			{
			case IslandCullState.Active:
				this.OnViewShow?.Invoke();
				break;
			case IslandCullState.PlayerNearby:
				this.OnViewHide?.Invoke();
				break;
			case IslandCullState.Virtual:
				this.OnViewHide?.Invoke();
				break;
			}
			_islandLockView.Setup(_spawnedBottom, _islandObject);
		}

		public void SetConfig(IslandConfig islandConfig)
		{
			if (_currentGameMode.Mode == _levelEditorGameMode)
			{
				_instancedIslandData = islandConfig.IslandData;
			}
			else
			{
				_instancedIslandData = new IslandData(islandConfig.IslandData);
			}
			base.transform.SetPositionAndRotation(islandConfig.Position, Quaternion.Euler(0f, islandConfig.Rotation, 0f));
			base.transform.localScale = new Vector3(islandConfig.Size.x / 10f, 1f, islandConfig.Size.y / 10f);
			Material material = UnityEngine.Object.Instantiate(_islandMaterial);
			Material material2 = UnityEngine.Object.Instantiate(_islandMaterial);
			material2.renderQueue = 3000;
			material.SetTexture(MainTex, _instancedIslandData.Texture2D);
			material.SetVector(GridSize, islandConfig.Size);
			material.SetFloat(Elevated, 0f);
			_meshRenderer.material = material;
			material2.SetTexture(MainTex, _instancedIslandData.Texture2D);
			material2.SetVector(GridSize, islandConfig.Size);
			material2.SetFloat(Elevated, 1f);
			_heightMeshRenderer.material = material2;
			_boxCollider.size = new Vector3(islandConfig.Size.x, 0.1f, islandConfig.Size.y);
			SetBottomPrefab(islandConfig);
			_instancedIslandData.InitializeIsland(islandConfig.Position, islandConfig.Rotation, _gridLocator.GetCellSize().x);
			this.OnViewCreated?.Invoke(_instancedIslandData);
			if (FactoryObjectViewManager.Instance != null && _currentGameMode.Mode != _levelEditorGameMode)
			{
				FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated += OnFactoryObjectViewCreated;
				FactoryObjectViewManager.Instance.OnFactoryObjectViewRemoved += OnFactoryObjectViewRemoved;
			}
		}

		public void SetBottomPrefab(IslandConfig islandConfig)
		{
			if (_spawnedBottom != null)
			{
				UnityEngine.Object.Destroy(_spawnedBottom.gameObject);
			}
			IslandViewBottom bottom = GetBottom(islandConfig.SizeUnits, islandConfig.IslandBottom.SelectedIndex);
			if (bottom != null)
			{
				_spawnedBottom = UnityEngine.Object.Instantiate(bottom, _container);
				_spawnedBottom.transform.localScale = new Vector3(1f / base.transform.localScale.x, 1f, 1f / base.transform.localScale.z);
				_spawnedBottom.transform.localRotation = Quaternion.Euler(0f, (float)islandConfig.IslandBottom.Rotation * 90f, 0f);
			}
			_spawnedBottom.Initalize(this);
			_bottomMeshRenderers = _spawnedBottom.CachedMeshRenderers;
			_bottomLockedMeshRenderers = _spawnedBottom.CachedLockedMeshRenderers;
		}

		private void IslandChangedCullingState(IslandObject islandObject)
		{
			if (islandObject == _islandObject)
			{
				switch (islandObject.GetCullState())
				{
				case IslandCullState.Active:
					SetRenderersTo(cull: false);
					this.OnViewShow?.Invoke();
					break;
				case IslandCullState.PlayerNearby:
					SetRenderersTo(cull: true);
					this.OnViewHide?.Invoke();
					break;
				case IslandCullState.Virtual:
					SetRenderersTo(cull: true);
					this.OnViewHide?.Invoke();
					break;
				}
			}
		}

		private void SetRenderersTo(bool cull)
		{
			_meshRenderer.forceRenderingOff = cull;
			_heightMeshRenderer.forceRenderingOff = cull;
			_waterBottomMeshRenderer.forceRenderingOff = cull;
			_waterPlaneMeshRenderer.forceRenderingOff = cull;
			_islandInstancedObjectsDrawer.enabled = !cull;
			_islandLockView.Cull(cull);
			if (_bottomMeshRenderers == null)
			{
				return;
			}
			MeshRenderer[] bottomMeshRenderers = _bottomMeshRenderers;
			for (int i = 0; i < bottomMeshRenderers.Length; i++)
			{
				bottomMeshRenderers[i].forceRenderingOff = cull;
			}
			if (_bottomLockedMeshRenderers == null)
			{
				return;
			}
			foreach (MeshRenderer bottomLockedMeshRenderer in _bottomLockedMeshRenderers)
			{
				bottomLockedMeshRenderer.forceRenderingOff = cull;
			}
		}

		private void OnFactoryObjectViewCreated(FactoryObjectView factoryObjView, FactoryObject factoryObj)
		{
			if (!factoryObjView.GrassTiles || factoryObj.IslandObject != _islandObject || factoryObjView.transform.position.y >= _heightMeshRenderer.transform.position.y)
			{
				return;
			}
			Dictionary<Vector3Int, Color32> dictionary = new Dictionary<Vector3Int, Color32>();
			foreach (Vector3Int occupiedPosition in factoryObj.OccupiedPositions)
			{
				dictionary.Add(occupiedPosition, EnvironmentColorIDs.GetColor(EnvironmentColorIDs.FloorType.Grass));
			}
			_previousTilesColor.Add(factoryObjView, _instancedIslandData.GetTexturePixels(factoryObj.OccupiedPositions));
			_instancedIslandData.PaintTexture(dictionary);
			_currentFactoryObjectViews.Add(factoryObj, factoryObjView);
			this.OnFactoryObjectViewCreatedOnIsland?.Invoke(factoryObjView, factoryObj);
		}

		private void OnFactoryObjectViewRemoved(FactoryObjectView factoryObjView, FactoryObject factoryObj)
		{
			if (_currentFactoryObjectViews.ContainsKey(factoryObj) && factoryObjView.GrassTiles && factoryObj.IslandObject == _islandObject && !(factoryObjView.transform.position.y >= _heightMeshRenderer.transform.position.y))
			{
				_instancedIslandData.PaintTexture(_previousTilesColor[factoryObjView]);
				_previousTilesColor.Remove(factoryObjView);
				_currentFactoryObjectViews.Remove(factoryObj);
			}
		}

		private void OnFactoryObjectRemoved(FactoryLayer factoryLayer, FactoryObject factoryObject, IslandObject islandObject)
		{
			if (_currentFactoryObjectViews.ContainsKey(factoryObject))
			{
				FactoryObjectView factoryObjectView = _currentFactoryObjectViews[factoryObject];
				if (factoryObjectView.GrassTiles && factoryObject.IslandObject == _islandObject)
				{
					_instancedIslandData.PaintTexture(_previousTilesColor[factoryObjectView]);
					_previousTilesColor.Remove(factoryObjectView);
					_currentFactoryObjectViews.Remove(factoryObject);
					this.OnFactoryObjectViewRemovedOnIsland?.Invoke(factoryObjectView, factoryObject);
				}
			}
		}

		private IslandViewBottom GetBottom(Vector2Int size, int index)
		{
			if (index == -1)
			{
				return null;
			}
			if (size.x <= 44)
			{
				return _smallIslandBottomObjects[index];
			}
			if (size.x <= 66)
			{
				return _mediumIslandBottomObjects[index];
			}
			if (!_zenMode.Value)
			{
				return _bigIslandBottomObjects[index];
			}
			return _creativeModeBigIslandBottomObjects[index];
		}

		public int GetBottomMaxIndex(Vector2Int size)
		{
			if (size.x <= 44)
			{
				return _smallIslandBottomObjects.Length - 1;
			}
			if (size.x <= 66)
			{
				return _mediumIslandBottomObjects.Length - 1;
			}
			if (!_zenMode.Value)
			{
				return _bigIslandBottomObjects.Length - 1;
			}
			return _creativeModeBigIslandBottomObjects.Length - 1;
		}

		public void UpdateValues(UpdateIslandDto updateIslandDto)
		{
			base.transform.SetPositionAndRotation(updateIslandDto.Position, Quaternion.Euler(0f, updateIslandDto.Rotation, 0f));
			base.transform.localScale = new Vector3(updateIslandDto.Mirrored ? (0f - base.transform.localScale.x) : base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z);
		}

		public void Hover()
		{
			_islandLockView.Hover();
		}

		public void HoverStopped()
		{
			_islandLockView.HoverStopped();
		}
	}
}
