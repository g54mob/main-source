using System;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Motorways.Processes;
using Motorways.Views.MeshGeneration;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	[SelectionBase]
	public class CarparkView : MonoBehaviour, IView, CarparkModel.IObserver, IReleasedFromScopeHandler, IReusable
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				CarparkView carparkView = client.Scope.Get<CarparkView>();
				carparkView.Initialize(model as CarparkModel);
				client.AddView(carparkView);
			}
		}

		private CarparkModel _model;

		[Dependency]
		private TilemapView _tilemap;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private CombinedMeshView _combinedMeshView;

		[Dependency]
		private CarparkMeshCombiner _carparkMeshCombiner;

		private CombinedMeshView.Handle _combinedMeshHandle;

		private bool _isPendingDeletion;

		private bool _isReversedLayout;

		[SerializeField]
		private GameObject _secondDestinationOutline;

		[SerializeField]
		private GameObject _secondDestinationOutlineReversed;

		[SerializeField]
		private GameObject _secondStationOutline;

		[SerializeField]
		private GameObject _secondStationOutlineReversed;

		[SerializeField]
		private GameObject _extraParkingSpaceLine;

		[SerializeField]
		private GameObject _extraParkingSpaceLineReversed;

		[SerializeField]
		private Transform _boatDockingTransform;

		public CarparkModel Model => _model;

		private GameObject SecondDestinationOutline
		{
			get
			{
				if (!_isReversedLayout)
				{
					return _secondDestinationOutline;
				}
				return _secondDestinationOutlineReversed;
			}
		}

		private GameObject SecondStationOutline
		{
			get
			{
				if (!_isReversedLayout)
				{
					return _secondStationOutline;
				}
				return _secondStationOutlineReversed;
			}
		}

		private GameObject ExtraParkingSpaceLine
		{
			get
			{
				if (!_isReversedLayout)
				{
					return _extraParkingSpaceLine;
				}
				return _extraParkingSpaceLineReversed;
			}
		}

		public Transform BoatDockingTransform => _boatDockingTransform;

		public Bounds GetBounds()
		{
			float num = (float)TilemapModel.TileWidth;
			Vector3 vector = new Vector3(num, num, 0f) * 0.5f;
			Vector2Int coordinates = _model.TileModels[0].Coordinates;
			Vector3 center = new Vector3((float)coordinates.x * num, (float)coordinates.y * num, base.transform.position.z);
			Bounds result = new Bounds(center, Vector3.zero);
			foreach (TileModel tileModel in _model.TileModels)
			{
				Vector2Int coordinates2 = tileModel.Coordinates;
				Vector3 vector2 = new Vector3((float)coordinates2.x * num, (float)coordinates2.y * num, center.z);
				Vector3 point = vector2 - vector;
				result.Encapsulate(point);
				Vector3 point2 = vector2 + vector;
				result.Encapsulate(point2);
			}
			return result;
		}

		public Bounds GetEmptyDestinationSlotBounds()
		{
			if (!Diagnostics.Verify(_model.destinationOffsets.Count == 2 && _model.destinations.Count == 1, "There should be exactly one empty destination slot available."))
			{
				return default(Bounds);
			}
			Vector2Int vector2Int = _model.destinationOffsets[_model.destinations.Count];
			Vector2Int vector2Int2 = _model.origin + vector2Int;
			float num = (float)TilemapModel.TileWidth;
			float num2 = (float)TilemapModel.HalfTileWidth;
			Vector2Int destinationFootprint = BuildingSpawningProcess.DestinationFootprint;
			Vector2 vector = new Vector2(num * (float)destinationFootprint.x, num * (float)destinationFootprint.y);
			return new Bounds(new Vector2((float)vector2Int2.x * num - num2, (float)vector2Int2.y * num - num2) + vector / 2f, vector);
		}

		private void Awake()
		{
		}

		private void Initialize(CarparkModel model)
		{
			_model = model;
			_model.Subscribe(this);
			Transform transform = base.transform;
			transform.position = TilemapView.GetWorldPositionForCoordinates(model.TopLeftCarparkTileCoordinate);
			switch (model.carparkSide)
			{
			case TileDirection.North:
				if (model.SupportsTwoDestinations)
				{
					_isReversedLayout = true;
				}
				break;
			case TileDirection.East:
				if (model.SupportsTwoDestinations)
				{
					transform.localEulerAngles = new Vector3(0f, 0f, -90f);
					_isReversedLayout = true;
				}
				break;
			case TileDirection.West:
				transform.localEulerAngles = new Vector3(0f, 0f, -90f);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case TileDirection.South:
				break;
			}
			AddToCombinedMesh(_model);
			SetupSecondDestinationOutline();
			ExtraParkingSpaceLine.SetActive(value: true);
		}

		private void SetupSecondDestinationOutline()
		{
			bool flag = _model.SupportsTwoDestinations && _model.destinations.Count < 2;
			bool flag2 = _model.destinations.Count == 1 && _model.destinations[0].IsTrainStation;
			SecondDestinationOutline.SetActive(flag && !flag2);
			SecondStationOutline.SetActive(flag && flag2);
		}

		private void AddToCombinedMesh(CarparkModel model)
		{
			Mesh mesh = null;
			if (model.supportsBoats)
			{
				mesh = _carparkMeshCombiner.BoatTerminalCarpark;
			}
			else if (model.SupportsTwoDestinations)
			{
				mesh = ((!_isReversedLayout) ? _carparkMeshCombiner.HorizontalDoubleCarpark : _carparkMeshCombiner.ReversedHorizontalDoubleCarpark);
			}
			else if (model.entranceAtTopLeft)
			{
				mesh = _carparkMeshCombiner.HorizontalSingleCarparkLeftEntrance;
			}
			else if (model.entranceAtBottomRight)
			{
				mesh = _carparkMeshCombiner.HorizontalSingleCarparkRightEntrance;
			}
			if (mesh != null)
			{
				_combinedMeshHandle = _combinedMeshView.AddMesh(CombinedMeshView.CombinedMeshType.Carpark, mesh, base.transform.localToWorldMatrix);
			}
		}

		public void OnDestinationAdded()
		{
			SetupSecondDestinationOutline();
		}

		public void OnCarparkRemoved(CarparkModel carparkModel)
		{
			_isPendingDeletion = true;
			_viewClient.ResumeTickingView(this);
			_combinedMeshView.RemoveMesh(_combinedMeshHandle);
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_model != null)
			{
				_model.Unsubscribe(this);
				_model = null;
			}
		}

		public void Reset()
		{
			SecondDestinationOutline.SetActive(value: false);
			SecondStationOutline.SetActive(value: false);
			ExtraParkingSpaceLine.SetActive(value: false);
			_model = null;
			_isPendingDeletion = false;
			_isReversedLayout = false;
			Transform obj = base.transform;
			obj.localPosition = Vector3.zero;
			obj.localRotation = Quaternion.identity;
			obj.localScale = Vector3.one;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (!_isPendingDeletion)
			{
				return TickResult.StopTicking;
			}
			return TickResult.Destroy;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}
	}
}
