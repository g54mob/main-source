using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using UnityEngine;

namespace Motorways
{
	[Serializable(1)]
	public class RoadTilePath : IReleasedFromScopeHandler, IReusable
	{
		[Serializable(1)]
		public class Piece : IReusable
		{
			public List<Vector2Fixed> visualPoints;

			public List<Vector2Fixed> logicalPoints;

			public static Piece Create(IScope scope, List<Vector2Fixed> logicalPoints)
			{
				Piece piece = scope.Get<Piece>();
				piece.visualPoints = null;
				piece.logicalPoints = logicalPoints;
				return piece;
			}

			public static Piece Create(IScope scope, List<Vector2Fixed> visualPoints, List<Vector2Fixed> logicalPoints)
			{
				Piece piece = scope.Get<Piece>();
				piece.visualPoints = visualPoints;
				piece.logicalPoints = logicalPoints;
				return piece;
			}

			public void Reset()
			{
				visualPoints = null;
				logicalPoints = null;
			}

			public Piece GetRotatedPiece(IScope scope, RoadTileRotation rotation)
			{
				List<Vector2Fixed> list = null;
				if (visualPoints != null)
				{
					list = new List<Vector2Fixed>();
					foreach (Vector2Fixed visualPoint in visualPoints)
					{
						list.Add(TileUtilities.GetRotatedVector(visualPoint, rotation));
					}
				}
				List<Vector2Fixed> list2 = new List<Vector2Fixed>();
				foreach (Vector2Fixed logicalPoint in logicalPoints)
				{
					list2.Add(TileUtilities.GetRotatedVector(logicalPoint, rotation));
				}
				return Create(scope, list, list2);
			}
		}

		public readonly List<Piece> pathPieces = new List<Piece>();

		[Serialize(false, null)]
		private Fix64 _length = -Fix64.One;

		[Dependency]
		private IScope _scope;

		public Fix64 Length
		{
			get
			{
				if (_length < Fix64.Zero)
				{
					_length = Fix64.Zero;
					foreach (Piece pathPiece in pathPieces)
					{
						List<Vector2Fixed> logicalPoints = pathPiece.logicalPoints;
						for (int i = 0; i < logicalPoints.Count - 1; i++)
						{
							_length += Vector2Fixed.Distance(logicalPoints[i], logicalPoints[i + 1]);
						}
					}
				}
				return _length;
			}
		}

		public List<Vector2Fixed> GetVisualPoints()
		{
			return GetVisualPoints(Vector2Fixed.zero);
		}

		public List<Vector2Fixed> GetVisualPoints(Vector2Fixed offset)
		{
			List<Vector2Fixed> list = new List<Vector2Fixed>();
			foreach (Piece pathPiece in pathPieces)
			{
				if (pathPiece.visualPoints == null)
				{
					continue;
				}
				foreach (Vector2Fixed visualPoint in pathPiece.visualPoints)
				{
					list.Add(visualPoint + offset);
				}
			}
			return list;
		}

		public List<Vector2Fixed> GetLogicalPoints()
		{
			return GetLogicalPoints(Vector2Fixed.zero);
		}

		public List<Vector2Fixed> GetLogicalPoints(Vector2Fixed offset)
		{
			List<Vector2Fixed> list = new List<Vector2Fixed>();
			foreach (Piece pathPiece in pathPieces)
			{
				foreach (Vector2Fixed logicalPoint in pathPiece.logicalPoints)
				{
					list.Add(logicalPoint + offset);
				}
			}
			return list;
		}

		public List<Vector2> ConstructPointsForPolygon(float roadScale, bool roundEnds, float edgePointScale)
		{
			List<Vector2> list = new List<Vector2>();
			List<Vector2Fixed> visualPoints = GetVisualPoints();
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < visualPoints.Count; j++)
				{
					Vector2 vector = new Vector2((float)visualPoints[j].x, (float)visualPoints[j].y) * ((j == 0 || j == visualPoints.Count - 1) ? edgePointScale : 1f);
					Vector2 vector2 = Vector2.zero;
					if (!roundEnds && j == 0)
					{
						vector2 = TileUtilities.GetVectorForDirection(TileUtilities.GetClosestDirection((Vector2)(-visualPoints[0])));
					}
					else if (!roundEnds && j == visualPoints.Count - 1)
					{
						vector2 = TileUtilities.GetVectorForDirection(TileUtilities.GetClosestDirection((Vector2)visualPoints[visualPoints.Count - 1]));
					}
					else
					{
						if (j < visualPoints.Count - 1)
						{
							Vector2 vector3 = new Vector2((float)visualPoints[j + 1].x, (float)visualPoints[j + 1].y);
							vector2 += vector3 - vector;
						}
						if (j > 0)
						{
							Vector2 vector4 = new Vector2((float)visualPoints[j - 1].x, (float)visualPoints[j - 1].y);
							vector2 += vector - vector4;
						}
					}
					vector2.Normalize();
					Vector2 vector5 = new Vector2(0f - vector2.y, vector2.x);
					list.Add(vector + vector5 * roadScale);
					Vector2 vector6 = vector;
					if (j == visualPoints.Count - 1 && roundEnds && i == 0)
					{
						float num = 15f;
						for (int k = 1; k <= 12; k++)
						{
							Vector2 vector7 = Quaternion.Euler(0f, 0f, (0f - num) * (float)k) * vector5;
							list.Add(vector6 + vector7 * roadScale);
						}
					}
				}
				visualPoints.Reverse();
			}
			list.Add(list[0]);
			return list;
		}

		public RoadTilePath CreateRotatedPath(RoadTileRotation rotation)
		{
			RoadTilePath roadTilePath = _scope.Get<RoadTilePath>();
			foreach (Piece pathPiece in pathPieces)
			{
				Piece rotatedPiece = pathPiece.GetRotatedPiece(_scope, rotation);
				roadTilePath.pathPieces.Add(rotatedPiece);
			}
			return roadTilePath;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (Piece pathPiece in pathPieces)
			{
				scope.Release(pathPiece);
			}
			pathPieces.Clear();
		}

		public void Reset()
		{
			_length = -Fix64.One;
			pathPieces.Clear();
		}
	}
}
