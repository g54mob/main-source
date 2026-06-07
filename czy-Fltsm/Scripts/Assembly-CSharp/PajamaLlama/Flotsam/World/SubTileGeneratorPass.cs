using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.World
{
	[CreateAssetMenu(fileName = "SubTileGenerator Pass", menuName = "Flotsam/Procedural Generation/SubTileGenerator Pass", order = 10)]
	public class SubTileGeneratorPass : TileGeneratorPass, IWorldTile
	{
		[SerializeField]
		[FormerlySerializedAs("_handmadeGenerator")]
		private TileGeneratorBase _subTileGenerator;

		private TileGenerator _generator;

		public TileGeneratorBase TileGenerator => _subTileGenerator;

		public void OverrideSubTileGenerator(TileGeneratorBase subTileGenerator)
		{
			if (subTileGenerator != null)
			{
				_subTileGenerator = subTileGenerator;
			}
		}

		public override IEnumerator Run(TileGenerator generator, IRegion dataRegion)
		{
			if ((bool)_subTileGenerator)
			{
				_generator = generator;
				_generator.Scale = _subTileGenerator.Scale;
				yield return _subTileGenerator.Generate(this);
			}
		}

		public override void Restore(IWorldTile worldTile)
		{
			_subTileGenerator?.Restore(worldTile);
		}

		void IWorldTile.AddRegion(IWorldRegion worldRegion)
		{
			_generator.AddRegion(worldRegion);
		}

		void IWorldTile.AddRoadSpawner(RoadSpawner roadSpawner)
		{
			_generator.AddRoad(roadSpawner);
		}

		void IWorldTile.AddLandmarkSpawner(LandmarkSpawner landmarkSpawner)
		{
			if (base.GeneratedNodes == null)
			{
				base.GeneratedNodes = new List<TileGeneratorNode>();
			}
			else
			{
				base.GeneratedNodes.Clear();
			}
			TileGeneratorNode tileGeneratorNode = new TileGeneratorNode(landmarkSpawner.TilePosition);
			tileGeneratorNode.SetSpawner(landmarkSpawner);
			_generator.AddNode(tileGeneratorNode, addToRegion: true);
			base.GeneratedNodes.Add(tileGeneratorNode);
		}

		void IWorldTile.AddPointOfInterestSpawner(PointOfInterestSpawner pointOfInterestSpawner)
		{
			Debug.LogException(new NotImplementedException());
		}

		void IWorldTile.PopulateRegionNeighbors()
		{
			_generator.PopulateRegionNeighbors();
		}

		public override bool TryReturnBounds(out Rect bounds)
		{
			bounds = _subTileGenerator.MinimumBounds;
			return true;
		}
	}
}
