using System.Collections.Generic;
using Motorways.EdgeLoopOperator;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	public class MapVisualGroup
	{
		public MapVisualGroupType groupType;

		public Tilemap sourceTilemap;

		public Dictionary<MapMeshLayer, TileLayer> tileLayers = new Dictionary<MapMeshLayer, TileLayer>();

		public MapMeshLayer[] containedLayers;

		public Dictionary<MapMeshLayer, List<EdgeLoop>> edgeLoops = new Dictionary<MapMeshLayer, List<EdgeLoop>>();

		public Dictionary<MapMeshLayer, Mesh> generatedMeshes = new Dictionary<MapMeshLayer, Mesh>();
	}
}
