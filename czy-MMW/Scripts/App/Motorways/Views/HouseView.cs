using Client;
using Easing;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Motorways.Themes;
using Motorways.Views.MeshGeneration;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	public class HouseView : MonoBehaviour, IView, IAudioView, HouseModel.IObserver, IReusable, IReleasedFromScopeHandler, ICreatedInScopeHandler
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				HouseView houseView = client.Scope.Get<HouseView>();
				houseView.Initialize(model as HouseModel);
				client.AddView(houseView);
			}
		}

		[Dependency]
		private ViewIndex _viewIndex;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private CombinedMeshView _combinedMeshView;

		[Dependency]
		private HouseMeshCombiner _houseMeshCombiner;

		[Dependency]
		private IScope _scope;

		private CombinedMeshView.Handle _combinedMeshHandle;

		public MeshFilter combinedHouseMeshFilter;

		private HouseModel _houseModel;

		public Vector2Int tilePosition;

		public int groupIndex = -1;

		public float transitionInDuration = 0.6f;

		private readonly TweenFloat _transitionTween = new TweenFloat();

		private bool _isPendingDeletion;

		private NetworkConnectivity _connectivity;

		private NetworkConnectivity _lastNotifiedConnectivity;

		private float _spawnTime;

		private bool _isTicking;

		[Dependency]
		public City City { get; private set; }

		public HouseModel Model => _houseModel;

		public VehicleView VehicleA
		{
			get
			{
				if (_houseModel.ownedVehicles.Count <= 0)
				{
					return null;
				}
				return _viewIndex.GetVehicleView(_houseModel.ownedVehicles[0]);
			}
		}

		public VehicleView VehicleB
		{
			get
			{
				if (_houseModel.ownedVehicles.Count <= 1)
				{
					return null;
				}
				return _viewIndex.GetVehicleView(_houseModel.ownedVehicles[1]);
			}
		}

		public Vector2 Pan => _gameCamera.GetPanFromWorld(base.transform.position);

		public float Attenuation => _gameCamera.GetAttenuationFromWorld(base.transform.position);

		public NetworkConnectivity NetworkConnectivity
		{
			get
			{
				return _connectivity;
			}
			set
			{
				_connectivity = value;
				if (_connectivity != NetworkConnectivity.Unknown && _lastNotifiedConnectivity != _connectivity)
				{
					_lastNotifiedConnectivity = _connectivity;
					_audioSystem.ScheduleEvent(AudioEvent.CreateHouseEvent(AudioEventType.HouseConnectedToNetwork, this, _connectivity == NetworkConnectivity.Connected));
				}
			}
		}

		Transform IAudioView.transform => base.transform;

		public void OnCreatedInScope(IScope scope)
		{
			_scope = scope;
		}

		private void Initialize(HouseModel model)
		{
			_isTicking = true;
			_houseModel = model;
			Model.Subscribe(this);
			_connectivity = NetworkConnectivity.Disconnected;
			_lastNotifiedConnectivity = NetworkConnectivity.Disconnected;
			tilePosition = _houseModel.tileModel.Coordinates;
			base.transform.localPosition = new Vector3((float)tilePosition.x * (float)TilemapModel.TileWidth, (float)tilePosition.y * (float)TilemapModel.TileWidth, 0f);
			_viewIndex.AddHouseView(this);
			groupIndex = _houseModel.GroupIndex;
			_theme.RegisterGameObjectToThemeByGroupIndex(base.gameObject, groupIndex);
			combinedHouseMeshFilter.sharedMesh = _houseMeshCombiner.MeshForGroupIndex(groupIndex);
			base.gameObject.GetComponent<CreativeModeEditableHouse>().Initialize(_scope, groupIndex, TileDirection.East);
			if (_viewClient.OnFirstFrame)
			{
				combinedHouseMeshFilter.gameObject.SetActive(value: false);
				_transitionTween.Stop();
				base.transform.localScale = Vector3.one;
				AddToCombinedMesh();
			}
			else
			{
				combinedHouseMeshFilter.gameObject.SetActive(value: true);
				_transitionTween.Start(0f, 1f, transitionInDuration, Easings.Functions.BackEaseOut);
				base.transform.localScale = new Vector3(0f, 0f, 1f);
				_audioSystem.ScheduleEvent(AudioEvent.CreateHouseEvent(AudioEventType.HouseSpawned, this));
			}
		}

		private void AddToCombinedMesh()
		{
			_combinedMeshHandle = _combinedMeshView.AddMesh(CombinedMeshView.CombinedMeshType.House, _houseMeshCombiner.MeshForGroupIndex(groupIndex), base.transform.localToWorldMatrix);
		}

		public void OnReleasedFromScope(IScope scope)
		{
			MotorwaysThemeDatabase.Log.Info("Releasing {0} with group index {1}", base.gameObject.name, groupIndex);
			_theme.UnregisterGameObjectFromThemeByGroupIndex(base.gameObject, groupIndex);
			if (_houseModel != null)
			{
				_viewIndex.RemoveHouseView(this);
				_houseModel.Unsubscribe(this);
				_houseModel = null;
			}
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = Vector3.one;
		}

		public void Reset()
		{
			tilePosition = default(Vector2Int);
			groupIndex = -1;
			_isPendingDeletion = false;
			_connectivity = NetworkConnectivity.Unknown;
			_lastNotifiedConnectivity = NetworkConnectivity.Unknown;
			_isTicking = false;
			base.transform.localPosition = Vector3.zero;
			combinedHouseMeshFilter.sharedMesh = null;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_transitionTween.IsActive)
			{
				float num = _transitionTween.Tick(timeInterval.Delta);
				base.transform.localScale = new Vector3(num, num, 1f);
				if (!_transitionTween.IsActive)
				{
					combinedHouseMeshFilter.gameObject.SetActive(value: false);
					AddToCombinedMesh();
				}
				return TickResult.ContinueTicking;
			}
			if (_isPendingDeletion)
			{
				_combinedMeshView.RemoveMesh(_combinedMeshHandle);
				return TickResult.Destroy;
			}
			_isTicking = false;
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public float GetAttenuation(bool zoom, float falloffFactor = 5f)
		{
			return _gameCamera.GetAttenuationFromWorld(base.transform.position, zoom, falloffFactor);
		}

		public Color GetBuildingColor(ThemeComponentGroupTarget groupTarget)
		{
			return (_theme.GetTheme() as Theme).GetBuildingColor(groupIndex, groupTarget);
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

		public void OnDrawGizmosSelected()
		{
			if (_houseModel != null && _houseModel.tileModel != null)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireCube(new Vector3((float)_houseModel.tileModel.Coordinates.x * (float)TilemapModel.TileWidth, (float)_houseModel.tileModel.Coordinates.y * (float)TilemapModel.TileWidth), Vector3.one * 0.2f);
			}
		}

		public void OnHouseChangedGroup(HouseModel house, int oldGroupIndex, int newGroupIndex)
		{
			VehicleA?.SetNewGroupIndex(newGroupIndex);
			VehicleB?.SetNewGroupIndex(newGroupIndex);
			_theme.UnregisterGameObjectFromThemeByGroupIndex(base.gameObject, groupIndex);
			groupIndex = newGroupIndex;
			_theme.RegisterGameObjectToThemeByGroupIndex(base.gameObject, groupIndex);
			_combinedMeshView.RemoveMesh(_combinedMeshHandle);
			AddToCombinedMesh();
		}

		public void OnHouseRemoved(HouseModel house)
		{
			_isPendingDeletion = true;
			if (!_isTicking)
			{
				_viewClient.ResumeTickingView(this);
			}
		}
	}
}
