using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views.Trains
{
	public class RailView : MonoBehaviour, IView, RailTileModel.IObserver, IReusable, IReleasedFromScopeHandler
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				RailView railView = client.Scope.Get<RailView>();
				railView.Initialize(model as RailTileModel);
				client.AddView(railView);
			}
		}

		private RailTileModel _tileModel;

		private readonly List<LineSegment> _lineSegments = new List<LineSegment>();

		[Dependency]
		private RailTileAtlas _railTileAtlas;

		[Dependency]
		private ViewIndex _viewIndex;

		[Dependency]
		private City _city;

		[SerializeField]
		private BridgeSpouts _bridgeSpouts;

		[SerializeField]
		private GameObject _centerVisual;

		[SerializeField]
		private GameObject _firstOutline;

		[SerializeField]
		private GameObject _secondOutline;

		public int LineSegmentCount => _lineSegments.Count;

		public List<LineSegment> LineSegments => _lineSegments;

		public RailTileModel Model => _tileModel;

		public BridgeSpouts BridgeSpouts => _bridgeSpouts;

		private void Initialize(RailTileModel railTileModel)
		{
			_tileModel = railTileModel;
			_tileModel.Subscribe(this);
			DisableBridgeVisuals();
			Vector2Fixed worldPositionForCoordinates = TilemapModel.GetWorldPositionForCoordinates(_tileModel.Coordinates);
			base.transform.position = (Vector3)worldPositionForCoordinates;
			RailTileDefinition definition = _railTileAtlas.GetDefinition(_tileModel.TileModel.Tile.RailConnection);
			if (Diagnostics.Verify(definition != null))
			{
				List<Vector2Fixed> logicalPoints = definition.path.GetLogicalPoints(worldPositionForCoordinates);
				for (int i = 0; i < logicalPoints.Count - 1; i++)
				{
					_lineSegments.Add(new LineSegment((Vector2)logicalPoints[i], (Vector2)logicalPoints[i + 1]));
				}
			}
			if (_city.Definition.TileIsOverWater(_tileModel.Coordinates))
			{
				if (_tileModel.PreviousRailModel != null && !_city.Definition.TileIsOverWater(_tileModel.PreviousRailModel.Coordinates))
				{
					TileDirection input = _tileModel.TileModel.Tile.RailConnection.input;
					_bridgeSpouts.SetSpoutActiveInDirection(input, UpgradeType.Bridge);
				}
				SetBridgeActive();
			}
			else if (_tileModel.PreviousRailModel != null && _city.Definition.TileIsOverWater(_tileModel.PreviousRailModel.Coordinates))
			{
				RailView railView = _viewIndex.GetRailView(_tileModel.PreviousRailModel);
				TileDirection output = _tileModel.TileModel.Tile.RailConnection.output;
				railView.BridgeSpouts.SetSpoutActiveInDirection(output, UpgradeType.Bridge);
			}
			_viewIndex.AddRailView(this);
		}

		private void SetBridgeActive()
		{
			_centerVisual.gameObject.SetActive(value: true);
			_firstOutline.gameObject.SetActive(value: true);
			_secondOutline.gameObject.SetActive(value: true);
			switch (_tileModel.TileModel.Tile.RailConnection.input)
			{
			case TileDirection.North:
			case TileDirection.South:
				_centerVisual.transform.rotation = Quaternion.Euler(0f, 90f, -90f);
				break;
			case TileDirection.NorthEast:
			case TileDirection.SouthWest:
				_centerVisual.transform.rotation = Quaternion.Euler(225f, 90f, -90f);
				break;
			case TileDirection.East:
			case TileDirection.West:
				_centerVisual.transform.rotation = Quaternion.Euler(270f, 90f, -90f);
				break;
			case TileDirection.SouthEast:
			case TileDirection.NorthWest:
				_centerVisual.transform.rotation = Quaternion.Euler(45f, 90f, -90f);
				break;
			case TileDirection.None:
				break;
			}
		}

		private void DisableBridgeVisuals()
		{
			_centerVisual.gameObject.SetActive(value: false);
			_firstOutline.gameObject.SetActive(value: false);
			_secondOutline.gameObject.SetActive(value: false);
			_bridgeSpouts.DisableAllSpouts();
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void OnDrawGizmosSelected()
		{
			if (_lineSegments != null && _lineSegments.Count > 0)
			{
				Gizmos.color = Color.magenta;
				Gizmos.DrawCube(_lineSegments[0].Start, new Vector3(0.2f, 0.2f, 0.2f));
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.magenta;
			foreach (LineSegment lineSegment in _lineSegments)
			{
				Gizmos.DrawLine(lineSegment.Start, lineSegment.End);
			}
			if (_tileModel != null)
			{
				Gizmos.color = ((_tileModel.SignalState == TrainSignalState.Open) ? Color.green : Color.red);
				Gizmos.DrawCube((Vector3)_tileModel.TileModel.WorldPosition, new Vector3(0.2f, 0.2f, 0.2f));
			}
		}

		public void Reset()
		{
			_tileModel = null;
			_lineSegments.Clear();
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			DisableBridgeVisuals();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_viewIndex.RemoveRailView(this);
		}
	}
}
