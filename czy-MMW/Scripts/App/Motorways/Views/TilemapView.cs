using System;
using System.Collections.Generic;
using System.Linq;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	public class TilemapView : MonoBehaviour, IView, ISimulationObserver, IViewClientObserver, ITilemap, IReusable, IReleasedFromScopeHandler
	{
		public enum ViewMode
		{
			Normal = 0,
			Edit = 1
		}

		public delegate void OnDebugZoneIndexChanged(int debugZoneIndex);

		public interface IObserver
		{
			void OnClientTileChanged(Tile tile);
		}

		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				if (typeof(TilemapModel).IsAssignableFrom(model.GetType()))
				{
					TilemapView tilemapView = client.Scope.Get<TilemapView>();
					tilemapView.Initialize(model as TilemapModel);
					client.AddView(tilemapView);
				}
			}
		}

		[Dependency]
		private IScope _scope;

		[Dependency]
		private MotorwaysThemeDatabase _themeDatabase;

		[Dependency]
		private MotorwayVisualParameters _motorwayVisualParameters;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private InputState _inputState;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private ViewClient _viewClient;

		private ClockView _clockViewBackingField;

		private MotorwayGeometryInfo _motorwayGeometryInfo;

		private readonly MotorwaySorter _motorwaySorter = new MotorwaySorter();

		private bool _shouldResortMotorways = true;

		private float _screenDistanceZoom = -1f;

		private float _screenDistanceBetweenTiles;

		private TilemapModel _tilemapModel;

		private Dictionary<int, MotorwayView> _motorwayViews = new Dictionary<int, MotorwayView>();

		private Dictionary<Vector2Int, TileView> _tileViews = new Dictionary<Vector2Int, TileView>();

		private Dictionary<int, int> _motorwayDefaultSortOrder = new Dictionary<int, int>();

		private ViewMode _viewMode;

		private readonly TweenFloat _motorwayViewModeOpacity = new TweenFloat();

		private static readonly int ViewModeOpacityShaderId = Shader.PropertyToID("_ViewModeOpacity");

		private const float MaxMotorwayOpacity = 1f;

		private bool _alwaysOpaqueMotorways;

		private int _debugZoneIndexValue;

		[Serialize(false, null)]
		private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		private ClockView ClockView => _clockViewBackingField ?? (_clockViewBackingField = _scope.Get<ClockView>());

		public MotorwayGeometryInfo MotorwayGeometryInfo => _motorwayGeometryInfo;

		public int MotorwayCount => _motorwayViews.Count;

		public TilemapModel TilemapModel => _tilemapModel;

		public float ViewModeOpacity => _motorwayViewModeOpacity.Value;

		public ViewMode viewMode
		{
			set
			{
				_viewMode = value;
				StartMotorwayOpacityAnimation();
			}
		}

		private float MotorwayOpacityTarget
		{
			get
			{
				if (!ShouldMotorwaysBeTransparent)
				{
					return 1f;
				}
				return _motorwayVisualParameters.editModeOpacity;
			}
		}

		private bool ShouldMotorwaysBeTransparent
		{
			get
			{
				if (!_alwaysOpaqueMotorways)
				{
					if (_viewMode != ViewMode.Edit)
					{
						if (ClockView != null)
						{
							return ClockView.IsVisuallyPaused;
						}
						return false;
					}
					return true;
				}
				return false;
			}
		}

		public float ScreenDistanceBetweenTiles
		{
			get
			{
				float orthographicSize = _gameCamera.OrthographicSize;
				if (_screenDistanceZoom == orthographicSize)
				{
					return _screenDistanceBetweenTiles;
				}
				_screenDistanceZoom = orthographicSize;
				_screenDistanceBetweenTiles = (GetScreenPositionFromTileCoordinates(Vector2Int.right) - GetScreenPositionFromTileCoordinates(Vector2Int.zero)).magnitude;
				return _screenDistanceBetweenTiles;
			}
		}

		public int DebugZoneIndex
		{
			get
			{
				return _debugZoneIndexValue;
			}
			set
			{
				_debugZoneIndexValue = value;
				this.DebugZoneIndexChanged?.Invoke(_debugZoneIndexValue);
			}
		}

		public event OnDebugZoneIndexChanged DebugZoneIndexChanged;

		public int GetDefaultSortOrderForMotorway(Motorway motorway)
		{
			if (!_motorwayDefaultSortOrder.TryGetValue(motorway.Id, out var value))
			{
				return 0;
			}
			return value;
		}

		public void TurnOffMotorwayTransparency()
		{
			_alwaysOpaqueMotorways = true;
			_motorwayViewModeOpacity.Set(1f);
			UpdateMotorwayOpacityShaderValue();
		}

		public void TurnOnMotorwayTransparency()
		{
			_alwaysOpaqueMotorways = false;
			_motorwayViewModeOpacity.Set(MotorwayOpacityTarget);
			UpdateMotorwayOpacityShaderValue();
		}

		private void UpdateMotorwayOpacityShaderValue()
		{
			Shader.SetGlobalFloat(ViewModeOpacityShaderId, _motorwayViewModeOpacity.Value);
			foreach (MotorwayView value in _motorwayViews.Values)
			{
				value.UpdateMotorwayOpacity();
			}
		}

		private void OnMotorwayVisualParametersChanged()
		{
			if (ShouldMotorwaysBeTransparent)
			{
				_motorwayViewModeOpacity.Set(MotorwayOpacityTarget);
				UpdateMotorwayOpacityShaderValue();
			}
		}

		private void StartMotorwayOpacityAnimation()
		{
			float motorwayOpacityTarget = MotorwayOpacityTarget;
			float num = (ShouldMotorwaysBeTransparent ? _motorwayVisualParameters.viewModeOpacityInDuration : _motorwayVisualParameters.viewModeOpacityOutDuration);
			float num2 = Mathf.Abs(motorwayOpacityTarget - _motorwayViewModeOpacity.Value) / (1f - _motorwayVisualParameters.editModeOpacity);
			_motorwayViewModeOpacity.Start(_motorwayViewModeOpacity.Value, motorwayOpacityTarget, num * num2, _motorwayVisualParameters.viewModeOpacityAnimationFunction);
		}

		private void OnClockViewVisuallyPausedChanged(bool isVisuallyPaused)
		{
			StartMotorwayOpacityAnimation();
		}

		public void Initialize(TilemapModel tilemapModel)
		{
			_tilemapModel = tilemapModel;
			_screenDistanceZoom = -1f;
			_simulation.Subscribe(this);
			_viewClient.Subscribe(this);
			ClockView.VisuallyPausedChanged += OnClockViewVisuallyPausedChanged;
			_motorwayGeometryInfo = new MotorwayGeometryInfo(_motorwayVisualParameters);
			_motorwayVisualParameters.OnParameterChanged += OnMotorwayVisualParametersChanged;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_simulation.Unsubscribe(this);
			_viewClient.Unsubscribe(this);
		}

		public void Reset()
		{
			_observers.UnsubscribeAll();
			_tilemapModel = null;
			_tileViews.Clear();
			_motorwayViews.Clear();
			_screenDistanceZoom = -1f;
			_screenDistanceBetweenTiles = 0f;
			_motorwayViewModeOpacity.Reset();
			_motorwaySorter.Reset();
			_motorwayGeometryInfo = null;
			_shouldResortMotorways = true;
			_motorwayDefaultSortOrder.Clear();
			ClockView.VisuallyPausedChanged -= OnClockViewVisuallyPausedChanged;
			_alwaysOpaqueMotorways = false;
			_motorwayVisualParameters.OnParameterChanged -= OnMotorwayVisualParametersChanged;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_motorwayViewModeOpacity.IsActive)
			{
				_motorwayViewModeOpacity.Tick(timeInterval.Delta);
				UpdateMotorwayOpacityShaderValue();
			}
			if (_shouldResortMotorways && _motorwaySorter.CanCalculateDepthSegments(_motorwayViews))
			{
				_motorwayGeometryInfo.ComputeGeometryInfo(_motorwayViews);
				_motorwaySorter.CalculateDepthSegments(_motorwayViews, _motorwayGeometryInfo);
				_shouldResortMotorways = false;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public Motorway GetMotorway(int motorwayId)
		{
			return GetMotorwayView(motorwayId)?.Motorway;
		}

		public Motorway CreateMotorway(int motorwayId, int motorwayNumber, int replacedMotorwayId)
		{
			return CreateMotorwayView(motorwayId, motorwayNumber, replacedMotorwayId).Motorway;
		}

		public MotorwayView GetMotorwayView(int motorwayId)
		{
			if (_motorwayViews.TryGetValue(motorwayId, out var value))
			{
				return value;
			}
			return null;
		}

		public MotorwayView TryGetMotorwayViewForLane(LaneModel lane)
		{
			if (lane.connection.IsUTurn)
			{
				return null;
			}
			int motorwayId = lane.connection.input.motorwayId;
			if (motorwayId == -1 || motorwayId != lane.connection.output.motorwayId)
			{
				return null;
			}
			MotorwayView motorwayView = GetMotorwayView(motorwayId);
			if (!Diagnostics.Verify(motorwayView.Model.startToEndLane == lane || motorwayView.Model.endToStartLane == lane))
			{
				return null;
			}
			return motorwayView;
		}

		private MotorwayView CreateMotorwayView(int motorwayId, int motorwayNumber, RoadState roadState, MotorwayView replacedMotorwayView = null)
		{
			if (Diagnostics.Verify(!_motorwayViews.ContainsKey(motorwayId), "Motorway view should not already exist on creation"))
			{
				MotorwayView motorwayView = _scope.Get<MotorwayView>();
				if (_motorwayViews.Count <= 0)
				{
					_motorwayViewModeOpacity.Set(MotorwayOpacityTarget);
					UpdateMotorwayOpacityShaderValue();
				}
				motorwayView.Initialize(this, motorwayId, motorwayNumber, roadState, replacedMotorwayView);
				_motorwayViews[motorwayId] = motorwayView;
				_viewClient.AddView(motorwayView);
				RecalculateDefaultMotorwaySortOrder();
				if (FeatureToggle.IsFeatureDisabled(Feature.BringMotorwaysToTopWhenEdited))
				{
					ResortMotorwaysOnNextTick();
				}
				return motorwayView;
			}
			return null;
		}

		private MotorwayView CreateMotorwayView(int motorwayId, int motorwayNumber, int replacedMotorwayId)
		{
			MotorwayView replacedMotorwayView = null;
			RoadState roadState = RoadState.Planned;
			if (replacedMotorwayId != -1)
			{
				replacedMotorwayView = GetMotorwayView(replacedMotorwayId);
				Motorway motorway = GetMotorway(replacedMotorwayId);
				if (Diagnostics.Verify(motorway != null, "Replaced motorway should not be null"))
				{
					roadState = motorway.State;
				}
			}
			return CreateMotorwayView(motorwayId, motorwayNumber, roadState, replacedMotorwayView);
		}

		private MotorwayView CreateMotorwayViewForModel(MotorwayModel model)
		{
			return CreateMotorwayView(model.Id, model.Number, model.State);
		}

		public Tile GetTile(Vector2Int coordinates)
		{
			return GetTileView(coordinates)?.Tile;
		}

		public Tile GetOrCreateTile(Vector2Int coordinates)
		{
			return GetOrCreateTileView(coordinates)?.Tile;
		}

		public TileView GetTileView(Vector2Int coordinates)
		{
			if (_tileViews.TryGetValue(coordinates, out var value))
			{
				return value;
			}
			return null;
		}

		public TileView GetOrCreateTileView(Vector2Int coordinates)
		{
			TileView tileView = GetTileView(coordinates);
			if (tileView == null)
			{
				tileView = _scope.Get<TileView>();
				tileView.Initialize(this, coordinates);
				_tileViews[coordinates] = tileView;
				_viewClient.AddView(tileView);
			}
			return tileView;
		}

		public Vector2Int GetMouseTilePosition()
		{
			return GetTileCoordinatesFromWorldPosition(GetMouseWorldPosition());
		}

		public Vector2 GetMouseWorldPosition()
		{
			return GetWorldPositionFromScreenPosition(_inputState.Mouse.Position);
		}

		public Vector2Int GetTouchTilePosition(int touchIndex)
		{
			return GetTileCoordinatesFromWorldPosition(GetTouchWorldPosition(touchIndex));
		}

		public Vector2 GetTouchWorldPosition(int touchIndex)
		{
			if (_inputState.TryGetTouch(touchIndex, out var result))
			{
				return _gameCamera.GetWorldFromScreen(result.Position);
			}
			return Vector2.zero;
		}

		public Vector2 GetWorldPositionFromScreenPosition(Vector2 screenPosition)
		{
			return _gameCamera.GetWorldFromScreen(screenPosition);
		}

		public Vector2 GetScreenPositionFromTileCoordinates(Vector2Int tileCoordinates)
		{
			return _gameCamera.GetScreenFromWorld(GetWorldPositionForCoordinates(tileCoordinates));
		}

		public static Vector3 GetWorldPositionForCoordinates(Vector2Int coordinates)
		{
			return (Vector3)TilemapModel.GetWorldPositionForCoordinates(coordinates);
		}

		public Vector2Int GetTileCoordinatesFromWorldPosition(Vector2 worldPosition)
		{
			return new Vector2Int(Mathf.RoundToInt(worldPosition.x / (float)TilemapModel.TileWidth), Mathf.RoundToInt(worldPosition.y / (float)TilemapModel.TileWidth));
		}

		public Vector2Int GetTileCoordinatesFromScreenPosition(Vector2 screenPosition)
		{
			return GetTileCoordinatesFromWorldPosition(GetWorldPositionFromScreenPosition(screenPosition));
		}

		private List<int> GetActiveMotorwayNumbers()
		{
			List<int> list = new List<int>();
			foreach (MotorwayView value in _motorwayViews.Values)
			{
				if ((value.Motorway.State & RoadState.VisiblyActive) != RoadState.None && value.Motorway.Number != 0)
				{
					list.Add(value.Motorway.Number);
				}
			}
			foreach (TileView value2 in _tileViews.Values)
			{
				if (value2.Tile.UnbuiltMotorwayNumber != 0)
				{
					list.Add(value2.Tile.UnbuiltMotorwayNumber);
				}
			}
			return list;
		}

		public int GetLowestAvailableMotorwayNumber()
		{
			List<int> activeMotorwayNumbers = GetActiveMotorwayNumbers();
			for (int i = 1; i <= activeMotorwayNumbers.Count + 1; i++)
			{
				if (!activeMotorwayNumbers.Contains(i))
				{
					return i;
				}
			}
			return 1;
		}

		public void OnModelAdded(ISimulation simulation, IModel model, Fix64 timestamp)
		{
			if (model is TileModel tileModel)
			{
				GetOrCreateTileView(tileModel.Coordinates).SetModel(tileModel);
			}
			else if (model is MotorwayModel motorwayModel)
			{
				MotorwayView motorwayView = GetMotorwayView(motorwayModel.Id);
				if (motorwayView == null)
				{
					motorwayView = CreateMotorwayViewForModel(motorwayModel);
				}
				motorwayView.SetModel(motorwayModel);
			}
		}

		public void OnModelRemoved(ISimulation simulation, IModel model, Fix64 timestamp)
		{
		}

		public void OnViewAdded(IClient client, IView view)
		{
		}

		public void OnViewRemoved(IClient client, IView view)
		{
			if (view is MotorwayView motorwayView)
			{
				_motorwayViews.Remove(motorwayView.Motorway.Id);
				RecalculateDefaultMotorwaySortOrder();
				ResortMotorwaysOnNextTick();
			}
		}

		public ClientTileEdit GenerateClientTileEditAndAddEditToViews(TileEdit edit, bool isDraft)
		{
			ClientTileEdit clientTileEdit = new ClientTileEdit();
			clientTileEdit.edit = edit;
			clientTileEdit.isDraft = isDraft;
			foreach (Motorway affectedMotorway in edit.GetAffectedMotorways(this))
			{
				MotorwayView motorwayView = GetMotorwayView(affectedMotorway.Id);
				if (Diagnostics.Verify(motorwayView != null, "Expected to find view for motorway {0}.", affectedMotorway.Id))
				{
					motorwayView.AddEdit(clientTileEdit);
				}
			}
			foreach (Tile affectedTile in edit.GetAffectedTiles(this))
			{
				if (!Diagnostics.Verify(affectedTile != null, "Expected tile should never be null at this point"))
				{
					continue;
				}
				TileView tileView = GetTileView(affectedTile.Coordinates);
				if (Diagnostics.Verify(tileView != null, "Expected to find view for tile at {0}.", affectedTile.Coordinates))
				{
					tileView.AddEdit(clientTileEdit);
					ObserverList<IObserver>.Enumerator enumerator3 = _observers.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						enumerator3.Current.OnClientTileChanged(affectedTile);
					}
				}
			}
			return clientTileEdit;
		}

		public void RecalculateDefaultMotorwaySortOrder()
		{
			_motorwayDefaultSortOrder.Clear();
			if (_motorwayViews.Count == 0)
			{
				return;
			}
			int[] array = new int[_motorwayViews.Count];
			for (int i = 0; i < _motorwayViews.Values.Count; i++)
			{
				MotorwayView motorwayView = _motorwayViews.Values.ElementAt(i);
				array[i] = motorwayView.Motorway.Id;
			}
			Array.Sort(array, delegate(int motorwayIdA, int motorwayIdB)
			{
				Motorway motorway = GetMotorway(motorwayIdA);
				Motorway motorway2 = GetMotorway(motorwayIdB);
				bool flag = (motorway.State & RoadState.VisiblyActive) != 0;
				bool flag2 = (motorway2.State & RoadState.VisiblyActive) != 0;
				if (!flag && !flag2)
				{
					return motorwayIdA - motorwayIdB;
				}
				if (flag && !flag2)
				{
					return 1;
				}
				return (!flag) ? (-1) : (motorway.Number - motorway2.Number);
			});
			for (int num = 0; num < array.Length; num++)
			{
				int key = array[num];
				_motorwayDefaultSortOrder[key] = num + 1;
			}
		}

		public void ResortMotorwaysOnNextTick()
		{
			_shouldResortMotorways = true;
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}
	}
}
