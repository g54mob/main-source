using System;
using System.Collections.Generic;
using PajamaLlama.Generic;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;

namespace PajamaLlama.Flotsam.Landmarks
{
	public class LandmarkBase : MonoBehaviour, IPolygonProvider
	{
		[Serializable]
		private class WorldPolygons : InspectorHidableArrayBase<Polygon>
		{
			[SerializeField]
			private Polygon[] _polygons;

			public override Polygon[] Array => _polygons;
		}

		[SerializeField]
		private LandmarkBasePolygonMode _polygonMode;

		[SerializeField]
		private Polygon _polygon;

		[SerializeField]
		[ConditionalEnumHide("_polygonMode", 1, true)]
		private WorldPolygons _pathfindingPolygons;

		[SerializeField]
		[MinMaxRangeFloat(0f, 10f)]
		public RangedFloat InactiveYOffsetRange;

		public LandmarkBasePolygonMode PolygonMode => _polygonMode;

		public Polygon Polygon => _polygon;

		public Polygon[] PathfindingPolygons => _pathfindingPolygons.Array;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.white;
			_polygon.DrawGizmos();
			if (_polygonMode != LandmarkBasePolygonMode.Multiple)
			{
				return;
			}
			Gizmos.color = Color.yellow;
			foreach (Polygon pathfindingPolygon in _pathfindingPolygons)
			{
				pathfindingPolygon.DrawGizmos();
			}
		}

		public Polygon ReturnPolygon(int index)
		{
			if (_polygonMode == LandmarkBasePolygonMode.Single || index == 0)
			{
				return _polygon;
			}
			return _pathfindingPolygons.Array[index - 1];
		}

		public ListPool<Polygon>.List ReturnPolygons()
		{
			ListPool<Polygon>.List list = ListPool<Polygon>.Get();
			list.Add(Polygon);
			if (_polygonMode == LandmarkBasePolygonMode.Single || _pathfindingPolygons.IsEmpty())
			{
				return list;
			}
			list.AddRange(_pathfindingPolygons.Array);
			return list;
		}

		public bool TryGetPathfindingPolygons(out Polygon[] pathfindingPolygons)
		{
			if (_polygonMode == LandmarkBasePolygonMode.Single && _pathfindingPolygons.IsEmpty())
			{
				pathfindingPolygons = null;
				return false;
			}
			pathfindingPolygons = _pathfindingPolygons.Array;
			return true;
		}

		public Vector2[] ReturnVertexPositions()
		{
			List<Transform> list = Polygon.ReturnVertices();
			Vector2[] array = new Vector2[list.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = list[i].localPosition.Vector2TopDown();
			}
			return array;
		}
	}
}
