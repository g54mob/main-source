using Easing;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Motorways.Views.MeshGeneration;
using Server;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class DraftHouse : MonoBehaviour, IReusable, IReleasedFromScopeHandler, ICreativeModeEditableObject
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DraftHouse");

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private City _city;

		[Dependency]
		private GameCamera _gameCamera;

		[SerializeField]
		private EditMenuButtonType _editOptions;

		[SerializeField]
		private MeshFilter _houseMesh;

		[SerializeField]
		private RawImage _renderTextureImage;

		[SerializeField]
		private float _ghostPreviewNormalOpacity = 0.8f;

		[SerializeField]
		private float _ghostPreviewInvalidOpacity = 0.5f;

		public Vector2Int tilePosition;

		public float transitionInDuration = 0.6f;

		private readonly TweenFloat _transitionTween = new TweenFloat();

		private IScope _scope;

		private float _spawnTime;

		private bool _isTicking;

		private int _groupIndex;

		private TileDirection _drivewayDirection;

		private bool _hasExistingView;

		private Vector2Int _originalPosition;

		private int _originalGroupIndex;

		private TileDirection _originalDrivewayDirection;

		public bool HasUnplaceableView { get; private set; }

		public bool IsTicking => _isTicking;

		public Vector2 Pan => _gameCamera.GetPanFromWorld(base.transform.position);

		public float Attenuation => _gameCamera.GetAttenuationFromWorld(base.transform.position);

		public void Initialize(Vector2Int initialTilePosition, IScope scope, int groupIndex, TileDirection drivewayDirection)
		{
			_isTicking = true;
			HasUnplaceableView = false;
			tilePosition = initialTilePosition;
			_originalPosition = initialTilePosition;
			_scope = scope;
			_groupIndex = groupIndex;
			_originalGroupIndex = groupIndex;
			_drivewayDirection = drivewayDirection;
			_originalDrivewayDirection = _drivewayDirection;
			UpdatePosition(tilePosition);
			_transitionTween.Start(0f, 1f, transitionInDuration, Easings.Functions.BackEaseOut);
			base.transform.localScale = new Vector3(0f, 0f, 1f);
			UpdateMesh(_groupIndex);
			_renderTextureImage.color = new Color(_renderTextureImage.color.r, _renderTextureImage.color.g, _renderTextureImage.color.b, _ghostPreviewNormalOpacity);
		}

		public void InitializeWithExistingView(IScope scope, HouseView view)
		{
			HasUnplaceableView = false;
			_hasExistingView = true;
			_originalGroupIndex = view.groupIndex;
			_originalDrivewayDirection = view.Model.DrivewayDirection;
			_originalPosition = view.tilePosition;
			_isTicking = true;
			tilePosition = view.tilePosition;
			_scope = scope;
			_groupIndex = view.groupIndex;
			_drivewayDirection = view.Model.DrivewayDirection;
			UpdatePosition(tilePosition);
			base.transform.localScale = Vector3.one;
			UpdateMesh(_groupIndex);
			_renderTextureImage.color = new Color(_renderTextureImage.color.r, _renderTextureImage.color.g, _renderTextureImage.color.b, _ghostPreviewNormalOpacity);
		}

		public void UpdatePosition(Vector2Int newPosition)
		{
			tilePosition = newPosition;
			base.transform.localPosition = new Vector3((float)tilePosition.x * (float)TilemapModel.TileWidth, (float)tilePosition.y * (float)TilemapModel.TileWidth, 0f);
			base.transform.localScale = Vector3.one;
		}

		public void UpdateDrivewayPosition(TileDirection drivewayDirection)
		{
			_drivewayDirection = drivewayDirection;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = Vector3.one;
		}

		public void Reset()
		{
			HasUnplaceableView = false;
			tilePosition = default(Vector2Int);
			_originalPosition = default(Vector2Int);
			_scope = null;
			_groupIndex = 0;
			_drivewayDirection = TileDirection.North;
			_isTicking = false;
			base.transform.localPosition = Vector3.zero;
			_hasExistingView = false;
			_originalDrivewayDirection = TileDirection.North;
			_originalGroupIndex = 0;
		}

		public void Tick(float frameTime)
		{
		}

		public float GetAttenuation(bool zoom, float falloffFactor = 5f)
		{
			return _gameCamera.GetAttenuationFromWorld(base.transform.position, zoom, falloffFactor);
		}

		public Bounds GetBounds()
		{
			float num = (float)TilemapModel.TileWidth;
			Vector3 vector = new Vector3(num, num, 0f) * 0.5f;
			Vector3 vector2 = new Vector3((float)tilePosition.x * num, (float)tilePosition.y * num, base.transform.position.z);
			return new Bounds
			{
				min = vector2 - vector,
				max = vector2 + vector
			};
		}

		public void StartUnplaceableView()
		{
			Log.Info("Start unplaceable ghost view for {0}", ToString());
			HasUnplaceableView = true;
			_renderTextureImage.color = new Color(_renderTextureImage.color.r, _renderTextureImage.color.g, _renderTextureImage.color.b, _ghostPreviewInvalidOpacity);
		}

		public void EndUnplaceableView()
		{
			Log.Info("Start unplaceable ghost view for {0}", ToString());
			HasUnplaceableView = false;
			_renderTextureImage.color = new Color(_renderTextureImage.color.r, _renderTextureImage.color.g, _renderTextureImage.color.b, _ghostPreviewNormalOpacity);
		}

		public void Delete(bool isReplacement)
		{
			_scope.Release(this);
		}

		public bool IsConfirmable()
		{
			return !HasUnplaceableView;
		}

		public BuildingLayout GetBuildingLayout()
		{
			return BuildingLayout.BuildingAbove;
		}

		public Vector2 GetWorldPosition()
		{
			return base.transform.position;
		}

		public Vector2Int GetTilePosition()
		{
			return tilePosition;
		}

		public Vector2 GetCenterForEditMenuPosition()
		{
			return GetWorldPosition();
		}

		public bool CompletelyOutOfPlayArea(City city)
		{
			if (city == null)
			{
				return false;
			}
			return !city.IsTileInPlayableArea(tilePosition, Fix64.MaxValue);
		}

		public EditMenuButtonType GetEditOptions()
		{
			return _editOptions;
		}

		public void Confirm()
		{
			if (Diagnostics.Verify(!HasUnplaceableView && IsConfirmable(), "We should only confirm if the house has a valid placement!"))
			{
				SpawnHouse();
				_scope.Release(this);
			}
		}

		private void SpawnHouse(bool original = false)
		{
			CityPlanModel.ScheduledBuilding scheduledBuilding = _scope.Get<CityPlanModel.ScheduledBuilding>();
			scheduledBuilding.type = CityTileType.Supply;
			scheduledBuilding.groupIndex = (original ? _originalGroupIndex : _groupIndex);
			scheduledBuilding.useFixedParameters = true;
			scheduledBuilding.positionOverride = (original ? _originalPosition : tilePosition);
			scheduledBuilding.drivewayDirectionOverride = (original ? _originalDrivewayDirection : _drivewayDirection);
			scheduledBuilding.time = _simulation.Timestep;
			_scope.Get<CityPlanModel>().ScheduleBuilding(scheduledBuilding);
		}

		public void Cancel()
		{
			if (_hasExistingView)
			{
				UpdatePosition(_originalPosition);
				SpawnHouse(original: true);
			}
			_scope.Release(this);
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public int GetGroupIndex()
		{
			return _groupIndex;
		}

		public void SetGroupIndex(int groupIndex, bool isReplacement)
		{
			if (_groupIndex != groupIndex)
			{
				_groupIndex = groupIndex;
				UpdateMesh(_groupIndex);
			}
		}

		public ICreativeModeEditableObject GetGhostPreview(out bool isReplacement)
		{
			isReplacement = false;
			return this;
		}

		public void Flip(bool isReplacement)
		{
			Diagnostics.FailAssert("Flip called on a DraftHouse, but only makes sense on Single Destinations!");
		}

		public void Rotate(bool isReplacement)
		{
			Diagnostics.FailAssert("Rotate called on a DraftHouse, but only makes sense on Destinations!");
		}

		public void UpgradeOrDowngrade(bool isReplacement)
		{
			Log.Error("UpgradeOrDowngrade called on a DraftHouse, but only makes sense on Destinations!");
		}

		private void UpdateMesh(int groupIndex)
		{
			if (Diagnostics.Verify(_houseMesh != null, "HouseMesh cannot be null, set it on prefab"))
			{
				HouseMeshCombiner houseMeshCombiner = _scope.Get<HouseMeshCombiner>();
				if (Diagnostics.Verify(houseMeshCombiner != null, "Cannot find HouseMeshCombiner in scope"))
				{
					Mesh mesh = houseMeshCombiner.MeshForGroupIndex(groupIndex);
					_houseMesh.mesh = mesh;
				}
			}
		}
	}
}
