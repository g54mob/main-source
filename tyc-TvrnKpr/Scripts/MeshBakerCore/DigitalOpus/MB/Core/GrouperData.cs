using System;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class GrouperData
	{
		public bool clusterOnLMIndex;

		public bool clusterByLODLevel;

		public Vector3 origin;

		public Vector3 cellSize;

		public int pieNumSegments;

		public Vector3 pieAxis;

		public float ringSpacing;

		public bool combineSegmentsInInnermostRing;

		public bool includeCellsWithOnlyOneRenderer;

		public MB3_AgglomerativeClustering cluster;

		public float maxDistBetweenClusters;

		public float _lastMaxDistBetweenClusters;

		public float _ObjsExtents;

		public float _minDistBetweenClusters;

		public List<MB3_AgglomerativeClustering.ClusterNode> _clustersToDraw;

		public float[] _radii;
	}
}
