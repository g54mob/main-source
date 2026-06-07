using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Client;
using Factory;
using Factory.Pools;
using Motorways.Models;
using UnityEngine;

namespace Motorways.Views
{
	public class TileView : MonoBehaviour, IView, IViewLateTick, TileModel.IObserver, Tile.IObserver, IReleasedFromScopeHandler, IReusable
	{
		public interface IObserver
		{
			void OnTileViewChanged(TileView changedTile);
		}

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("View.Tile");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private City _city;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private ClientUpgradeDatabase _clientUpgradeDatabase;

		[Dependency]
		private InputState _inputState;

		[Dependency]
		private TilemapView _tilemapView;

		[Dependency]
		private RoadTileAtlas _roadTileAtlas;

		[Dependency]
		private PermanenceTextureMappingDatabase _permanenceTextureMappingDatabase;

		[Dependency]
		public VisualConstantsData _visualConstants;

		private readonly TileViewNode[] _nodes = new TileViewNode[8];

		private bool _animateNewConnections;

		private readonly List<AnimatedRoadTileConnectionView> _animatingConnections = new List<AnimatedRoadTileConnectionView>();

		private bool _isCenterOfVisiblyActiveRoundabout;

		private RoadTileConnection _visiblyActiveRoundaboutConnection = RoadTileConnection.InvalidConnection;

		private bool _isVisiblyActiveRoundaboutPlaced;

		private RoadTileConnection _mothballedRoundaboutConnection = RoadTileConnection.InvalidConnection;

		private readonly List<AnimatedRoadTileConnectionView> _animatingRoundaboutConnections = new List<AnimatedRoadTileConnectionView>();

		private Tile _tile;

		private TileModel _model;

		private readonly List<ClientTileEdit> _clientTileEdits = new List<ClientTileEdit>();

		private bool _rebuildTile;

		private bool _rebuildRoadViews;

		private bool _changeHighlightView;

		private bool _isHighlighted;

		private RoadTileSignature _activeSignature;

		private RoadView _activeRoadView;

		private TileDirectionBitfield _activeConnectionDirections;

		private TileDirectionBitfield _previouslyActiveConnectionDirections;

		private RoadTileSignature _completeSignature;

		private RoadView _completeRoadView;

		private TileSelectedView _highlightView;

		private TrafficLightView _trafficLightView;

		private UnbuiltMotorwayView _unbuiltMotorwayView;

		private RoundaboutView _roundaboutView;

		private bool _isTicking;

		private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		public TileViewPermanenceZoneUpdater tileViewPermanenceZoneUpdater;

		public TileDirectionBitfield ActiveConnectionDirections => _activeConnectionDirections;

		public TileDirectionBitfield PreviouslyActiveConnectionDirections => _previouslyActiveConnectionDirections;

		public TilemapView TilemapView => _tilemapView;

		public TileModel Model => _model;

		public bool IsHighlighted
		{
			get
			{
				return _isHighlighted;
			}
			set
			{
				_changeHighlightView = value != _isHighlighted;
				_isHighlighted = value;
			}
		}

		public Vector2Int Coordinates => _tile.Coordinates;

		public Tile Tile
		{
			get
			{
				if (_rebuildTile)
				{
					RebuildTile();
				}
				return _tile;
			}
		}

		public Vector2 InteractionCircleOffset { get; private set; } = Vector2.zero;

		public Vector2[] TrafficLightOffsets { get; private set; }

		public DeadEndRoadView ActiveDeadEnd
		{
			get
			{
				TileViewNode[] nodes = _nodes;
				foreach (TileViewNode tileViewNode in nodes)
				{
					if (tileViewNode.deadEndRoad != null && tileViewNode.deadEndRoad.RoadState == RoadState.Active)
					{
						return tileViewNode.deadEndRoad;
					}
				}
				return null;
			}
		}

		public bool CanAnimateNewConnections => _animateNewConnections;

		private bool ContainsCarparkOrHouse
		{
			get
			{
				if (Tile.ContentType != TileContentType.Carpark)
				{
					return Tile.ContentType == TileContentType.House;
				}
				return true;
			}
		}

		public TileView()
		{
			for (int i = 0; i < 8; i++)
			{
				_nodes[i] = new TileViewNode();
			}
		}

		public void Initialize(TilemapView tilemap, Vector2Int coordinates)
		{
			base.transform.localPosition = TilemapView.GetWorldPositionForCoordinates(coordinates);
			_tile = _scope.Get<Tile>();
			_tile.Initialize(tilemap, coordinates, TileContentType.None);
			_tile.Subscribe(this);
			if (FeatureToggle.IsFeatureDisabled(Feature.RoadDrawingAnimations))
			{
				_animateNewConnections = false;
			}
			else
			{
				_animateNewConnections = _city.Rules.DoRoadsAnimation && !_city.Definition.TileIsOverWater(coordinates) && !_city.Definition.TileIsUnderAMountain(coordinates);
			}
			if (_city.Rules.RoadsBecomePermanentOverTime)
			{
				tileViewPermanenceZoneUpdater = new TileViewPermanenceZoneUpdater(this, _visualConstants, _permanenceTextureMappingDatabase, _viewClient);
			}
			_isTicking = true;
		}

		public void Reset()
		{
			_isCenterOfVisiblyActiveRoundabout = false;
			_isVisiblyActiveRoundaboutPlaced = false;
			_visiblyActiveRoundaboutConnection = RoadTileConnection.InvalidConnection;
			_mothballedRoundaboutConnection = RoadTileConnection.InvalidConnection;
			_isHighlighted = false;
			_activeRoadView = null;
			_completeRoadView = null;
			_trafficLightView = null;
			_unbuiltMotorwayView = null;
			_roundaboutView = null;
			_clientTileEdits.Clear();
			base.transform.localPosition = Vector3.zero;
			_animateNewConnections = false;
			InteractionCircleOffset = default(Vector2);
			TrafficLightOffsets = null;
			_isTicking = false;
			_activeConnectionDirections = TileDirectionBitfield.None;
			_previouslyActiveConnectionDirections = TileDirectionBitfield.None;
			tileViewPermanenceZoneUpdater = null;
			TileViewNode[] nodes = _nodes;
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].Reset();
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_model != null)
			{
				_model.Unsubscribe(this);
				_model = null;
			}
			if (_tile != null)
			{
				_tile.Unsubscribe(this);
				scope.Release(_tile);
				_tile = null;
			}
			if (_activeSignature != null)
			{
				scope.Release(_activeSignature);
				_activeSignature = null;
			}
			if (_completeSignature != null)
			{
				scope.Release(_completeSignature);
				_completeSignature = null;
			}
			TileViewNode[] nodes = _nodes;
			foreach (TileViewNode tileViewNode in nodes)
			{
				if (tileViewNode.deadEndRoad != null)
				{
					_scope.Release(tileViewNode.deadEndRoad);
					tileViewNode.deadEndRoad = null;
				}
			}
			foreach (AnimatedRoadTileConnectionView animatingConnection in _animatingConnections)
			{
				_scope.Release(animatingConnection);
			}
			_animatingConnections.Clear();
			foreach (AnimatedRoadTileConnectionView animatingRoundaboutConnection in _animatingRoundaboutConnections)
			{
				_scope.Release(animatingRoundaboutConnection);
			}
			_animatingRoundaboutConnections.Clear();
		}

		public void SetModel(TileModel tileModel)
		{
			_model = tileModel;
			_model.Subscribe(this);
			_rebuildTile = true;
			ResumeTicking();
		}

		public void AddEdit(ClientTileEdit edit)
		{
			if (!_clientTileEdits.Contains(edit))
			{
				_clientTileEdits.Add(edit);
				_rebuildTile = true;
				ResumeTicking();
			}
		}

		public void RemoveEdit(ClientTileEdit edit)
		{
			if (_clientTileEdits.Remove(edit))
			{
				RebuildTile();
			}
		}

		public void OnTileChanged(Tile changedTile)
		{
			_rebuildRoadViews = true;
			ResumeTicking();
		}

		public void OnTileModelChanged(TileModel changedTileModel)
		{
			if (changedTileModel != Model)
			{
				return;
			}
			int num = 0;
			while (num < _clientTileEdits.Count)
			{
				if (_clientTileEdits[num].isScheduledOnSimulation)
				{
					_clientUpgradeDatabase.RemoveTileEdit(_clientTileEdits[num]);
					_clientTileEdits.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			_rebuildTile = true;
			ResumeTicking();
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_rebuildTile)
			{
				RebuildTile();
			}
			bool flag = false;
			RoadTileSignature roadTileSignature = null;
			RoadTileSignature roadTileSignature2 = null;
			if (_rebuildRoadViews)
			{
				roadTileSignature = _tile.CreateSignature(RoadState.VisiblyActive);
				roadTileSignature2 = _tile.CreateSignature(RoadState.VisiblyActive | RoadState.Mothballed);
				UpdateInteractionCircle(roadTileSignature, roadTileSignature2);
				NotifyTileViewChanged();
				_rebuildRoadViews = false;
				flag = true;
				UpdateActiveConnectionDirections(roadTileSignature);
				RebuildDynamicRoads(roadTileSignature, roadTileSignature2);
				for (int i = 0; i < 8; i++)
				{
					if (_nodes[i].isDynamic)
					{
						TileDirection direction = (TileDirection)i;
						CreateViewsForStaticConnections(roadTileSignature.GetConnectionsToDirection(direction), RoadState.Active);
						CreateViewsForStaticConnections(roadTileSignature2.GetConnectionsToDirection(direction), RoadState.Mothballed);
					}
				}
			}
			bool flag2 = false;
			foreach (AnimatedRoadTileConnectionView animatingConnection in _animatingConnections)
			{
				animatingConnection.Tick(timeInterval);
				flag2 |= animatingConnection.IsComplete;
			}
			int num = 0;
			while (num < _animatingRoundaboutConnections.Count)
			{
				AnimatedRoadTileConnectionView animatedRoadTileConnectionView = _animatingRoundaboutConnections[num];
				animatedRoadTileConnectionView.Tick(timeInterval);
				if (animatedRoadTileConnectionView.IsComplete)
				{
					_animatingRoundaboutConnections.RemoveAt(num);
					_scope.Release(animatedRoadTileConnectionView);
				}
				else
				{
					num++;
				}
			}
			if (flag2)
			{
				for (int j = 0; j < 8; j++)
				{
					TileViewNode tileViewNode = _nodes[j];
					if (tileViewNode.isDynamic && _animatingConnections.TrueForAll((AnimatedRoadTileConnectionView connection) => connection.IsComplete || connection.AnimationDirection == RoadAnimationDirection.AnimatingOut))
					{
						tileViewNode.isDynamic = false;
						flag = true;
					}
				}
				int num2 = 0;
				while (num2 < _animatingConnections.Count)
				{
					AnimatedRoadTileConnectionView animatedRoadTileConnectionView2 = _animatingConnections[num2];
					if (CanReleaseAnimation(animatedRoadTileConnectionView2))
					{
						_animatingConnections.RemoveAt(num2);
						_scope.Release(animatedRoadTileConnectionView2);
					}
					else
					{
						num2++;
					}
				}
			}
			if (flag)
			{
				if (roadTileSignature == null)
				{
					roadTileSignature = _tile.CreateSignature(RoadState.VisiblyActive);
				}
				if (roadTileSignature2 == null)
				{
					roadTileSignature2 = _tile.CreateSignature(RoadState.VisiblyActive | RoadState.Mothballed);
				}
				RebuildStaticRoads(roadTileSignature, roadTileSignature2);
			}
			_isTicking = _animatingConnections.Count > 0 || _animatingRoundaboutConnections.Count > 0;
			TileViewNode[] nodes = _nodes;
			foreach (TileViewNode tileViewNode2 in nodes)
			{
				if (tileViewNode2.deadEndRoad != null)
				{
					TickResult tickResult = tileViewNode2.deadEndRoad.Tick(timeInterval, stepAlpha);
					if ((tileViewNode2.deadEndRoad.RoadState == RoadState.None || tileViewNode2.deadEndRoad.IsBeingReplaced) && !tileViewNode2.deadEndRoad.IsDynamic)
					{
						_scope.Release(tileViewNode2.deadEndRoad);
						tileViewNode2.deadEndRoad = null;
					}
					_isTicking |= tickResult == TickResult.ContinueTicking;
				}
			}
			if (_changeHighlightView)
			{
				if (_isHighlighted)
				{
					if (_highlightView == null)
					{
						_highlightView = TileSelectedView.Create(_viewClient, this);
					}
					if (_scope.Get<City>().IsTileInPlayableArea(time: _scope.Get<ClockModel>().ExpansionTime, coordinates: Coordinates))
					{
						_highlightView.Appear();
					}
				}
				else
				{
					if (_highlightView != null)
					{
						_highlightView.Disappear();
					}
					_highlightView = null;
				}
				_changeHighlightView = false;
			}
			if (tileViewPermanenceZoneUpdater != null)
			{
				tileViewPermanenceZoneUpdater.Tick(timeInterval.Delta);
				_isTicking = true;
			}
			if (!_isTicking)
			{
				return TickResult.StopTicking;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			TileViewNode[] nodes = _nodes;
			foreach (TileViewNode tileViewNode in nodes)
			{
				if (tileViewNode.deadEndRoad != null)
				{
					tileViewNode.deadEndRoad.SetGameobjectActive(isActive);
				}
			}
			base.gameObject.SetActive(isActive);
		}

		public void LateTick(TimeInterval tickTime, float stepAlpha)
		{
			tileViewPermanenceZoneUpdater?.LateTick(tickTime.Delta);
		}

		public void ResumeTicking()
		{
			if (!_isTicking)
			{
				_isTicking = true;
				_viewClient.ResumeTickingView(this);
			}
		}

		public void ReconfigurePermanenceVisibility()
		{
			if (_city.Rules.RoadsBecomePermanentOverTime)
			{
				if (tileViewPermanenceZoneUpdater == null)
				{
					tileViewPermanenceZoneUpdater = new TileViewPermanenceZoneUpdater(this, _visualConstants, _permanenceTextureMappingDatabase, _viewClient);
				}
			}
			else
			{
				tileViewPermanenceZoneUpdater = null;
			}
			TileViewNode[] nodes = _nodes;
			foreach (TileViewNode tileViewNode in nodes)
			{
				if (tileViewNode.deadEndRoad != null)
				{
					tileViewNode.deadEndRoad.ReconfigurePermanenceVisibility();
				}
			}
			foreach (AnimatedRoadTileConnectionView animatingConnection in _animatingConnections)
			{
				animatingConnection.SetPermanenceVisibility(_city.Rules.RoadsBecomePermanentOverTime);
			}
			if (_activeRoadView != null)
			{
				_activeRoadView.ReconfigurePermanenceVisibility();
			}
			if (_completeRoadView != null)
			{
				_completeRoadView.ReconfigurePermanenceVisibility();
			}
		}

		private bool CanReleaseAnimation(AnimatedRoadTileConnectionView animatingConnection)
		{
			if (!animatingConnection.IsComplete)
			{
				return false;
			}
			if (animatingConnection.AnimationDirection == RoadAnimationDirection.AnimatingOut)
			{
				return true;
			}
			if (!_nodes[(int)animatingConnection.Connection.input.direction].isDynamic)
			{
				return !_nodes[(int)animatingConnection.Connection.output.direction].isDynamic;
			}
			return false;
		}

		private void CreateViewsForStaticConnections(IEnumerable<RoadTileConnection> connections, RoadState roadState)
		{
			foreach (RoadTileConnection connection in connections)
			{
				bool flag = false;
				if (roadState == RoadState.Mothballed && _completeSignature != null && _activeSignature != null)
				{
					flag = _completeSignature.HasConnection(connection) && !_activeSignature.HasConnection(connection);
				}
				if (!connection.IsUTurn)
				{
					AnimatedRoadTileConnectionView animationForConnection = GetAnimationForConnection(connection);
					if (animationForConnection == null || (flag && animationForConnection.RoadState != RoadState.Mothballed))
					{
						animationForConnection = AnimatedRoadTileConnectionView.CreateStaticAnimation(_scope, this, connection, roadState);
						_animatingConnections.Add(animationForConnection);
					}
				}
			}
		}

		private void RebuildTile()
		{
			_rebuildTile = false;
			if (Model != null)
			{
				Model.Tile.CloneInto(Tile);
			}
			else
			{
				Tile.Clear();
			}
			foreach (ClientTileEdit clientTileEdit in _clientTileEdits)
			{
				clientTileEdit.edit.ApplyToAffectedTile(Tile);
			}
			if (Tile.HasTrafficLight)
			{
				if (_trafficLightView == null)
				{
					_trafficLightView = _scope.Get<TrafficLightView>();
					_trafficLightView.transform.localPosition = base.transform.localPosition;
					_viewClient.AddView(_trafficLightView);
					_trafficLightView.InitialiseInteractionCirclePosition(this);
				}
				else
				{
					_trafficLightView.gameObject.SetActive(value: true);
				}
				if (_trafficLightView.Model == null && Model?.roadChunk.TrafficLight != null)
				{
					_trafficLightView.SetModel(Model.roadChunk.TrafficLight);
				}
			}
			else if (_trafficLightView != null)
			{
				_viewClient.MarkViewForRemoval(_trafficLightView);
				_trafficLightView = null;
			}
			if (Tile.IsCenterOfRoundabout)
			{
				if (_roundaboutView == null)
				{
					_roundaboutView = _scope.Get<RoundaboutView>();
					_roundaboutView.transform.localPosition = base.transform.localPosition;
					_viewClient.AddView(_roundaboutView);
					_roundaboutView.Initialize(this);
				}
			}
			else if (_roundaboutView != null)
			{
				_viewClient.MarkViewForRemoval(_roundaboutView);
				_roundaboutView = null;
			}
			if (Tile.UnbuiltMotorwayId != -1)
			{
				if (_unbuiltMotorwayView == null)
				{
					_unbuiltMotorwayView = _scope.Get<UnbuiltMotorwayView>();
					_unbuiltMotorwayView.Initialize(this, base.transform.localPosition, InteractionCircleOffset, Tile.UnbuiltMotorwayNumber);
					_viewClient.AddView(_unbuiltMotorwayView);
				}
				else
				{
					_unbuiltMotorwayView.gameObject.SetActive(value: true);
				}
			}
			else if (_unbuiltMotorwayView != null)
			{
				_viewClient.MarkViewForRemoval(_unbuiltMotorwayView);
				_unbuiltMotorwayView = null;
			}
		}

		private void RebuildDynamicRoads(RoadTileSignature newActiveSignature, RoadTileSignature newCompleteSignature)
		{
			bool flag = _inputState.CurrentDeviceInputType != DeviceInputType.Remote;
			TransitionStyle transitionStyle = ((!(!_viewClient.OnFirstFrame && _animateNewConnections && flag)) ? TransitionStyle.Snap : TransitionStyle.Tween);
			bool isCenterOfRoundabout = _tile.IsCenterOfRoundabout;
			RoadTileConnection roundaboutConnection = _tile.GetRoundaboutConnection(RoadState.Planned | RoadState.Active);
			RoadTileConnection roundaboutConnection2 = _tile.GetRoundaboutConnection(RoadState.Mothballed);
			if (roundaboutConnection != _visiblyActiveRoundaboutConnection)
			{
				if (_visiblyActiveRoundaboutConnection == RoadTileConnection.InvalidConnection)
				{
					transitionStyle = TransitionStyle.Snap;
				}
				else if (roundaboutConnection == RoadTileConnection.InvalidConnection)
				{
					if (!_isVisiblyActiveRoundaboutPlaced)
					{
						transitionStyle = TransitionStyle.Snap;
					}
				}
				else
				{
					transitionStyle = TransitionStyle.Snap;
				}
			}
			else if (isCenterOfRoundabout != _isCenterOfVisiblyActiveRoundabout && !_isVisiblyActiveRoundaboutPlaced)
			{
				transitionStyle = TransitionStyle.Snap;
			}
			if (transitionStyle == TransitionStyle.Tween)
			{
				if (_mothballedRoundaboutConnection != RoadTileConnection.InvalidConnection && roundaboutConnection2 != _mothballedRoundaboutConnection && roundaboutConnection != _mothballedRoundaboutConnection)
				{
					AnimatedRoadTileConnectionView item = AnimatedRoadTileConnectionView.CreateAnimationOut(_scope, this, _mothballedRoundaboutConnection);
					_animatingRoundaboutConnections.Add(item);
				}
				if (_visiblyActiveRoundaboutConnection != RoadTileConnection.InvalidConnection && _isVisiblyActiveRoundaboutPlaced && roundaboutConnection != _visiblyActiveRoundaboutConnection && roundaboutConnection2 != _visiblyActiveRoundaboutConnection)
				{
					AnimatedRoadTileConnectionView item2 = AnimatedRoadTileConnectionView.CreateAnimationOut(_scope, this, _visiblyActiveRoundaboutConnection);
					_animatingRoundaboutConnections.Add(item2);
				}
			}
			_isCenterOfVisiblyActiveRoundabout = isCenterOfRoundabout;
			_visiblyActiveRoundaboutConnection = roundaboutConnection;
			_mothballedRoundaboutConnection = roundaboutConnection2;
			Tile tile = Model?.Tile;
			if (_isCenterOfVisiblyActiveRoundabout)
			{
				_isVisiblyActiveRoundaboutPlaced = tile?.IsCenterOfRoundabout ?? false;
			}
			else
			{
				_isVisiblyActiveRoundaboutPlaced = tile?.HasRoundabout(RoadState.Planned | RoadState.Active) ?? false;
			}
			for (int i = 0; i < 8; i++)
			{
				TileViewNode tileViewNode = _nodes[i];
				RoadState twoLaneRoadStateInDirection = _tile.GetTwoLaneRoadStateInDirection((TileDirection)i);
				if (twoLaneRoadStateInDirection != tileViewNode.roadState)
				{
					SetNodeState(i, twoLaneRoadStateInDirection, newActiveSignature, newCompleteSignature, transitionStyle);
				}
			}
			TileDirection tileDirection = (newActiveSignature.IsDeadEnd ? newActiveSignature.Connections.First().input.direction : TileDirection.None);
			TileDirectionBitfield tileDirectionBitfield = default(TileDirectionBitfield);
			if (newCompleteSignature.IsDeadEnd)
			{
				tileDirectionBitfield[newCompleteSignature.Connections.First().input.direction] = true;
			}
			if (_tile.ContentType == TileContentType.House && _model != null)
			{
				foreach (LaneModel lane in _model.roadChunk.lanes)
				{
					if (lane.state == RoadState.Mothballed && lane.connection.IsUTurn)
					{
						tileDirectionBitfield[lane.connection.input.direction] = true;
					}
				}
			}
			for (int j = 0; j < 8; j++)
			{
				TileViewNode tileViewNode2 = _nodes[j];
				if (tileDirection == (TileDirection)j)
				{
					ShowDeadEnd(j, RoadState.Active, transitionStyle, _activeSignature?.Connections, newActiveSignature.Connections);
				}
				else if (tileDirectionBitfield[(TileDirection)j])
				{
					ShowDeadEnd(j, RoadState.Mothballed, transitionStyle, _completeSignature?.Connections, newCompleteSignature.Connections);
				}
				else if (tileViewNode2.deadEndRoad != null)
				{
					RoadTileSignature roadTileSignature;
					RoadTileSignature roadTileSignature2;
					RoadTileSignature roadTileSignature3;
					if (tileViewNode2.deadEndRoad.RoadState == RoadState.Mothballed)
					{
						roadTileSignature = _completeSignature;
						roadTileSignature2 = newCompleteSignature;
						roadTileSignature3 = newActiveSignature;
					}
					else
					{
						roadTileSignature = _activeSignature;
						roadTileSignature2 = newActiveSignature;
						roadTileSignature3 = null;
					}
					HideDeadEnd(j, transitionStyle, roadTileSignature?.Connections, roadTileSignature2.Connections, roadTileSignature3?.Connections);
				}
			}
		}

		private void RebuildStaticRoads(RoadTileSignature newActiveSignature, RoadTileSignature newCompleteSignature)
		{
			using RoadTileSignature staticActiveSignature = CreateStaticSignature(newActiveSignature);
			SetStaticActiveSignature(staticActiveSignature);
			_activeSignature?.Dispose();
			_activeSignature = newActiveSignature;
			using RoadTileSignature staticCompleteSignature = CreateStaticSignature(newCompleteSignature);
			SetStaticCompleteSignature(staticCompleteSignature);
			_completeSignature?.Dispose();
			_completeSignature = newCompleteSignature;
			if (_completeRoadView != null)
			{
				_completeRoadView.gameObject.SetActive(!_activeSignature.Equals(_completeSignature));
			}
		}

		private RoadTileSignature CreateStaticSignature(RoadTileSignature fullSignature)
		{
			RoadTileSignature roadTileSignature = _scope.Get<RoadTileSignature>();
			foreach (RoadTileConnection connection in fullSignature.Connections)
			{
				if (!connection.IsUTurn && (connection.IsRoundabout || ((!_nodes[(int)connection.input.direction].isDynamic || connection.input.type == RoadType.Roundabout) && (!_nodes[(int)connection.output.direction].isDynamic || connection.output.type == RoadType.Roundabout))))
				{
					roadTileSignature.AddConnection(connection);
				}
			}
			return roadTileSignature;
		}

		private void UpdateActiveConnectionDirections(RoadTileSignature signature)
		{
			if (tileViewPermanenceZoneUpdater != null && !(_activeConnectionDirections == signature.ConnectionDirections))
			{
				_previouslyActiveConnectionDirections = _activeConnectionDirections;
				_activeConnectionDirections = signature.ConnectionDirections;
				TileDirectionBitfield.Enumerator enumerator = _activeConnectionDirections.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					_previouslyActiveConnectionDirections[current] = false;
				}
				tileViewPermanenceZoneUpdater.UpdateSolidZonePermanenceSources();
			}
		}

		private void SetStaticActiveSignature(RoadTileSignature staticSignature)
		{
			if (staticSignature.IsEmpty)
			{
				if (_activeRoadView != null)
				{
					_activeRoadView.SetSignature(staticSignature);
				}
				return;
			}
			if (_activeRoadView == null)
			{
				_activeRoadView = _scope.Get<RoadView>();
				_activeRoadView.transform.localPosition = base.transform.localPosition;
				_viewClient.AddView(_activeRoadView);
				_activeRoadView.tileView = this;
			}
			_activeRoadView.SetSignature(staticSignature);
		}

		private void SetStaticCompleteSignature(RoadTileSignature staticSignature)
		{
			if (staticSignature.IsEmpty)
			{
				if (_completeRoadView != null)
				{
					_completeRoadView.SetSignature(staticSignature);
				}
				return;
			}
			if (_completeRoadView == null)
			{
				_completeRoadView = _scope.Get<RoadView>();
				_completeRoadView.transform.localPosition = base.transform.localPosition;
				_viewClient.AddView(_completeRoadView);
				_completeRoadView.tileView = this;
			}
			_completeRoadView.SetSignature(staticSignature);
			_completeRoadView.GetComponent<MeshRenderer>().sharedMaterial = _completeRoadView.mothballedMaterial;
		}

		private void SetNodeState(int nodeIndex, RoadState newRoadState, RoadTileSignature newActiveSignature, RoadTileSignature newCompleteSignature, TransitionStyle transitionStyle)
		{
			TileViewNode tileViewNode = _nodes[nodeIndex];
			if (tileViewNode.roadState == newRoadState)
			{
				return;
			}
			RoadState roadState = tileViewNode.roadState;
			tileViewNode.roadState = newRoadState;
			if (transitionStyle == TransitionStyle.Snap)
			{
				return;
			}
			if ((newRoadState & RoadState.VisiblyActive) != RoadState.None)
			{
				if ((roadState & RoadState.VisiblyActive) != RoadState.None)
				{
					return;
				}
				foreach (RoadTileConnection item in newActiveSignature.GetConnectionsToDirection((TileDirection)nodeIndex))
				{
					if (!item.IsUTurn)
					{
						AnimateConnectionIn(item, RoadState.Active, roadState);
						tileViewNode.isDynamic = true;
					}
				}
				{
					foreach (RoadTileConnection item2 in newCompleteSignature.GetConnectionsToDirection((TileDirection)nodeIndex))
					{
						if (!newActiveSignature.HasConnection(item2) && !_completeSignature.HasConnection(item2) && !item2.IsUTurn)
						{
							AnimateConnectionIn(item2, RoadState.Mothballed, roadState);
							tileViewNode.isDynamic = true;
						}
					}
					return;
				}
			}
			if (newRoadState == RoadState.Mothballed)
			{
				foreach (AnimatedRoadTileConnectionView animatingConnection in _animatingConnections)
				{
					if (animatingConnection.IsConnectedToDirection((TileDirection)nodeIndex))
					{
						animatingConnection.RoadState = RoadState.Mothballed;
					}
				}
				if (tileViewNode.deadEndRoad != null)
				{
					tileViewNode.deadEndRoad.SetRoadState(RoadState.Mothballed);
				}
				return;
			}
			foreach (RoadTileConnection item3 in _activeSignature.GetConnectionsToDirection((TileDirection)nodeIndex))
			{
				if (!item3.IsUTurn)
				{
					AnimateConnectionOut(item3, RoadState.Active);
				}
			}
			foreach (RoadTileConnection item4 in _completeSignature.GetConnectionsToDirection((TileDirection)nodeIndex))
			{
				if (!_activeSignature.HasConnection(item4) && !item4.IsUTurn)
				{
					AnimateConnectionOut(item4, RoadState.Mothballed);
				}
			}
		}

		private void AnimateConnectionIn(RoadTileConnection connection, RoadState roadState, RoadState previousRoadState)
		{
			AnimatedRoadTileConnectionView animationForConnection = GetAnimationForConnection(connection);
			if (animationForConnection != null)
			{
				animationForConnection.AnimationDirection = RoadAnimationDirection.AnimatingIn;
				animationForConnection.RoadState = roadState;
			}
			else
			{
				animationForConnection = AnimatedRoadTileConnectionView.CreateAnimationIn(_scope, this, connection, roadState, previousRoadState);
				_animatingConnections.Add(animationForConnection);
			}
			TileViewNode tileViewNode = _nodes[(int)connection.input.direction];
			if (tileViewNode.deadEndRoad != null && (tileViewNode.deadEndRoad.RoadState == RoadState.Mothballed || roadState == RoadState.Active))
			{
				tileViewNode.deadEndRoad.ReplaceWithConnection(connection);
			}
			TileViewNode tileViewNode2 = _nodes[(int)connection.output.direction];
			if (tileViewNode2.deadEndRoad != null && (tileViewNode2.deadEndRoad.RoadState == RoadState.Mothballed || roadState == RoadState.Active))
			{
				tileViewNode2.deadEndRoad.ReplaceWithConnection(connection);
			}
		}

		private void AnimateConnectionOut(RoadTileConnection connection, RoadState roadState)
		{
			AnimatedRoadTileConnectionView animationForConnection = GetAnimationForConnection(connection);
			if (animationForConnection != null)
			{
				if (animationForConnection.AnimationDirection == RoadAnimationDirection.AnimatingIn)
				{
					animationForConnection.AnimationDirection = RoadAnimationDirection.AnimatingOut;
				}
			}
			else
			{
				AnimatedRoadTileConnectionView item = AnimatedRoadTileConnectionView.CreateAnimationOut(_scope, this, connection, roadState);
				_animatingConnections.Add(item);
			}
		}

		private AnimatedRoadTileConnectionView GetAnimationForConnection(RoadTileConnection connection)
		{
			RoadTileConnection reflectedConnection = connection.GetReflectedConnection();
			foreach (AnimatedRoadTileConnectionView animatingConnection in _animatingConnections)
			{
				if (animatingConnection.Connection == connection || animatingConnection.Connection == reflectedConnection)
				{
					return animatingConnection;
				}
			}
			return null;
		}

		private void ShowDeadEnd(int nodeIndex, RoadState newDeadEndState, TransitionStyle transitionStyle, IEnumerable<RoadTileConnection> previousConnections = null, IEnumerable<RoadTileConnection> newConnections = null, IEnumerable<RoadTileConnection> ignoredConnections = null)
		{
			TileViewNode tileViewNode = _nodes[nodeIndex];
			tileViewNode.isDeadEndConnectedToMotorway = false;
			tileViewNode.isDeadEndConnectedToEditingMotorway = false;
			if (tileViewNode.deadEndRoad == null)
			{
				tileViewNode.deadEndRoad = _scope.Get<DeadEndRoadView>();
				tileViewNode.deadEndRoad.transform.localPosition = TilemapView.GetWorldPositionForCoordinates(Coordinates);
				tileViewNode.deadEndRoad.Initialize(this, (TileDirection)nodeIndex);
			}
			if (newDeadEndState == RoadState.Active)
			{
				int motorwayInDirection = _tile.GetMotorwayInDirection((TileDirection)nodeIndex, RoadState.VisiblyActive);
				if (motorwayInDirection != -1)
				{
					MotorwayView motorwayView = _tilemapView.GetMotorwayView(motorwayInDirection);
					if (motorwayView != null && motorwayView.IsBeingEdited)
					{
						transitionStyle = TransitionStyle.Snap;
						tileViewNode.isDeadEndConnectedToEditingMotorway = true;
					}
				}
			}
			tileViewNode.isDeadEndConnectedToMotorway = _tile.GetMotorwayInDirection((TileDirection)nodeIndex, RoadState.VisiblyActive | RoadState.Mothballed) != -1;
			if (!tileViewNode.deadEndRoad.IsReplacing && transitionStyle == TransitionStyle.Tween && previousConnections != null)
			{
				RoadTileConnection roadTileConnection = RoadTileConnection.InvalidConnection;
				foreach (RoadTileConnection previousConnection in previousConnections)
				{
					if (previousConnection.input.direction == (TileDirection)nodeIndex && !previousConnection.IsUTurn && (newConnections == null || !newConnections.Contains(previousConnection)) && (roadTileConnection.output.direction == TileDirection.None || TileUtilities.GetDistanceBetweenDirections(roadTileConnection.input.direction, roadTileConnection.output.direction) < TileUtilities.GetDistanceBetweenDirections(previousConnection.input.direction, previousConnection.output.direction)))
					{
						roadTileConnection = previousConnection;
					}
				}
				if (roadTileConnection.output.direction != TileDirection.None)
				{
					float widthFactor = 1f;
					AnimatedRoadTileConnectionView animationForConnection = GetAnimationForConnection(roadTileConnection);
					if (animationForConnection != null)
					{
						widthFactor = animationForConnection.OutlineWidthFactor;
					}
					tileViewNode.deadEndRoad.AppearFromConnection(roadTileConnection, widthFactor);
				}
			}
			tileViewNode.deadEndRoad.SetRoadState(newDeadEndState, transitionStyle);
		}

		private void HideDeadEnd(int nodeIndex, TransitionStyle transitionStyle, IEnumerable<RoadTileConnection> previousConnections = null, IEnumerable<RoadTileConnection> newConnections = null, IEnumerable<RoadTileConnection> ignoredConnections = null)
		{
			TileViewNode tileViewNode = _nodes[nodeIndex];
			if (tileViewNode.isDeadEndConnectedToEditingMotorway)
			{
				transitionStyle = TransitionStyle.Snap;
				tileViewNode.isDeadEndConnectedToEditingMotorway = false;
			}
			if (tileViewNode.deadEndRoad != null)
			{
				RoadTileConnection roadTileConnection = RoadTileConnection.InvalidConnection;
				if (transitionStyle == TransitionStyle.Tween)
				{
					if (tileViewNode.deadEndRoad.IsBeingReplaced)
					{
						roadTileConnection = new RoadTileConnection(new RoadTileNode(tileViewNode.deadEndRoad.Direction), new RoadTileNode(tileViewNode.deadEndRoad.AutoDistortionTarget));
					}
					else if (newConnections != null)
					{
						foreach (RoadTileConnection newConnection in newConnections)
						{
							if (newConnection.input.direction == (TileDirection)nodeIndex && !newConnection.IsUTurn && (previousConnections == null || !previousConnections.Contains(newConnection)) && (roadTileConnection.output.direction == TileDirection.None || TileUtilities.GetDistanceBetweenDirections(roadTileConnection.input.direction, roadTileConnection.output.direction) < TileUtilities.GetDistanceBetweenDirections(newConnection.input.direction, newConnection.output.direction)))
							{
								roadTileConnection = newConnection;
							}
						}
					}
				}
				bool flag;
				if (roadTileConnection.output.direction != TileDirection.None)
				{
					AnimatedRoadTileConnectionView animationForConnection = GetAnimationForConnection(roadTileConnection);
					flag = animationForConnection != null && animationForConnection.AnimationDirection == RoadAnimationDirection.AnimatingOut;
					tileViewNode.deadEndRoad.ReplaceWithConnection(roadTileConnection);
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					tileViewNode.deadEndRoad.SetRoadState(RoadState.None, tileViewNode.isDeadEndConnectedToMotorway ? TransitionStyle.Snap : transitionStyle);
				}
			}
			tileViewNode.isDeadEndConnectedToMotorway = false;
		}

		private void UpdateInteractionCircle(RoadTileSignature activeSignature, RoadTileSignature completeSignature)
		{
			RoadTileSignature roadTileSignature = activeSignature;
			if (Tile.HasTrafficLight || activeSignature.IsEmpty || (activeSignature.IsDeadEnd && _tile.GetTwoLaneRoadCount(RoadState.Mothballed) > 1))
			{
				roadTileSignature = completeSignature;
			}
			RoadTileDefinition definitionForSignature = _roadTileAtlas.GetDefinitionForSignature(roadTileSignature);
			if (Diagnostics.Verify(definitionForSignature != null, "Could not find an interaction circle definition for the signature {0}.", roadTileSignature))
			{
				InteractionCircleOffset = definitionForSignature.interactionCircleOffset;
				TrafficLightOffsets = definitionForSignature.trafficLightOffsets;
			}
		}

		public bool ShouldDisplayDirectionAsPermanent(TileDirection direction)
		{
			if (ContainsCarparkOrHouse)
			{
				return true;
			}
			TileView tileView = _tilemapView.GetTileView(TileUtilities.GetAdjacentCoordinates(Coordinates, direction));
			if (tileView != null && tileView.ContainsCarparkOrHouse)
			{
				return true;
			}
			return false;
		}

		public float GetVisualNodePermanenceProgress(TileDirection direction)
		{
			float time = (float)Tile.GetNodePermanenceProgress(direction);
			RoadTileConnection roundaboutConnection = Tile.GetRoundaboutConnection(RoadState.VisiblyActive);
			if (roundaboutConnection.input.direction == direction || roundaboutConnection.output.direction == direction)
			{
				Tile tile = _tilemapView.GetTile(Tile.Coordinates - Roundabout.GetCoordinatesOffsetForConnection(roundaboutConnection));
				if (tile != null)
				{
					time = (float)tile.RoundaboutPermanenceProgress;
				}
			}
			return _visualConstants.DryingRoadFalloff.Evaluate(time);
		}

		public TileView GetTileViewInDirection(TileDirection direction)
		{
			if (direction == TileDirection.None)
			{
				return this;
			}
			return TilemapView.GetTileView(TileUtilities.GetAdjacentCoordinates(Coordinates, direction));
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.black;
			if (_scope != null && _scope.Get<TilemapView>() != null)
			{
				Vector3 worldPositionForCoordinates = TilemapView.GetWorldPositionForCoordinates(_tile.Coordinates);
				Gizmos.DrawLine(worldPositionForCoordinates + new Vector3((float)(-TilemapModel.HalfTileWidth), (float)(-TilemapModel.HalfTileWidth), 0f), worldPositionForCoordinates + new Vector3((float)TilemapModel.HalfTileWidth, (float)(-TilemapModel.HalfTileWidth), 0f));
				Gizmos.DrawLine(worldPositionForCoordinates + new Vector3((float)TilemapModel.HalfTileWidth, (float)(-TilemapModel.HalfTileWidth), 0f), worldPositionForCoordinates + new Vector3((float)TilemapModel.HalfTileWidth, (float)TilemapModel.HalfTileWidth, 0f));
				Gizmos.DrawLine(worldPositionForCoordinates + new Vector3((float)TilemapModel.HalfTileWidth, (float)TilemapModel.HalfTileWidth, 0f), worldPositionForCoordinates + new Vector3((float)(-TilemapModel.HalfTileWidth), (float)TilemapModel.HalfTileWidth, 0f));
				Gizmos.DrawLine(worldPositionForCoordinates + new Vector3((float)(-TilemapModel.HalfTileWidth), (float)TilemapModel.HalfTileWidth, 0f), worldPositionForCoordinates + new Vector3((float)(-TilemapModel.HalfTileWidth), (float)(-TilemapModel.HalfTileWidth), 0f));
			}
		}

		[Conditional("UNITY_EDITOR")]
		private void ResetEditorFields()
		{
		}

		[Conditional("UNITY_EDITOR")]
		private void UpdateEditorFields()
		{
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		private void NotifyTileViewChanged()
		{
			ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnTileViewChanged(this);
			}
		}
	}
}
