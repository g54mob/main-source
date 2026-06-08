using System;
using System.Collections.Generic;
using System.Linq;

namespace Jobberwocky.MIConvexHull
{
	public static class VoronoiMesh
	{
		public static VoronoiMesh<TVertex, DefaultTriangulationCell<TVertex>, VoronoiEdge<TVertex, DefaultTriangulationCell<TVertex>>> Create<TVertex>(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10) where TVertex : IVertex
		{
			return VoronoiMesh<TVertex, DefaultTriangulationCell<TVertex>, VoronoiEdge<TVertex, DefaultTriangulationCell<TVertex>>>.Create(data, PlaneDistanceTolerance);
		}
	}
	public class VoronoiMesh<TVertex, TCell, TEdge> where TVertex : IVertex where TCell : TriangulationCell<TVertex, TCell>, new() where TEdge : VoronoiEdge<TVertex, TCell>, new()
	{
		private class EdgeComparer : IEqualityComparer<TEdge>
		{
			public bool Equals(TEdge x, TEdge y)
			{
				return (x.Source == y.Source && x.Target == y.Target) || (x.Source == y.Target && x.Target == y.Source);
			}

			public int GetHashCode(TEdge obj)
			{
				return obj.Source.GetHashCode() ^ obj.Target.GetHashCode();
			}
		}

		private IEnumerable<TCell> _003CVertices_003Ek__BackingField;

		private IEnumerable<TEdge> _003CEdges_003Ek__BackingField;

		private IEnumerable<TCell> Vertices
		{
			set
			{
				_003CVertices_003Ek__BackingField = value;
			}
		}

		public IEnumerable<TEdge> Edges
		{
			get
			{
				return _003CEdges_003Ek__BackingField;
			}
			private set
			{
				_003CEdges_003Ek__BackingField = value;
			}
		}

		private VoronoiMesh()
		{
		}

		public static VoronoiMesh<TVertex, TCell, TEdge> Create(IList<TVertex> data, double PlaneDistanceTolerance = 1E-10)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			DelaunayTriangulation<TVertex, TCell> delaunayTriangulation = DelaunayTriangulation<TVertex, TCell>.Create(data, PlaneDistanceTolerance);
			List<TCell> list = Enumerable.ToList(delaunayTriangulation.Cells);
			HashSet<TEdge> hashSet = new HashSet<TEdge>(new EdgeComparer());
			foreach (TCell item in list)
			{
				for (int i = 0; i < item.Adjacency.Length; i++)
				{
					TCell val = item.Adjacency[i];
					if (val != null)
					{
						hashSet.Add(new TEdge
						{
							Source = item,
							Target = val
						});
					}
				}
			}
			return new VoronoiMesh<TVertex, TCell, TEdge>
			{
				Vertices = list,
				Edges = Enumerable.ToList(hashSet)
			};
		}
	}
}
