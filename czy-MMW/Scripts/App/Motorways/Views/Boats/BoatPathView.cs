using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views.Boats
{
	public class BoatPathView : MonoBehaviour, IView, BoatPathTileModel.IObserver, IReusable, IReleasedFromScopeHandler
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				BoatPathView boatPathView = client.Scope.Get<BoatPathView>();
				boatPathView.Initialize(model as BoatPathTileModel);
				client.AddView(boatPathView);
			}
		}

		private BoatPathTileModel _tileModel;

		private readonly List<LineSegment> _lineSegments = new List<LineSegment>();

		[Dependency]
		private BoatPathTileAtlas _boatPathTileAtlas;

		[Dependency]
		private ViewIndex _viewIndex;

		public int LineSegmentCount => _lineSegments.Count;

		public List<LineSegment> LineSegments => _lineSegments;

		public BoatPathTileModel Model => _tileModel;

		private void Initialize(BoatPathTileModel boatPathModel)
		{
			_tileModel = boatPathModel;
			_tileModel.Subscribe(this);
			Vector2Fixed worldPositionForCoordinates = TilemapModel.GetWorldPositionForCoordinates(_tileModel.Coordinates);
			base.transform.position = (Vector3)worldPositionForCoordinates;
			BoatPathTileDefinition definition = _boatPathTileAtlas.GetDefinition(_tileModel.TileModel.Tile.BoatPathConnection);
			if (Diagnostics.Verify(definition != null))
			{
				List<Vector2Fixed> logicalPoints = definition.path.GetLogicalPoints(worldPositionForCoordinates);
				for (int i = 0; i < logicalPoints.Count - 1; i++)
				{
					_lineSegments.Add(new LineSegment((Vector2)logicalPoints[i], (Vector2)logicalPoints[i + 1]));
				}
			}
			_viewIndex.AddBoatPathView(this);
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Reset()
		{
			_tileModel = null;
			_lineSegments.Clear();
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_viewIndex.RemoveBoatPathView(this);
		}
	}
}
