using System;
using System.Collections.Generic;
using System.Linq;
using Factory;
using FixMath;
using Motorways.Utility;
using UnityEngine;

namespace Motorways
{
	[Factory.Serializable(1)]
	public class RoadTileAtlas
	{
		public enum DiagonalPathLength
		{
			Extend = 0,
			Truncate = 1
		}

		public enum PathLocationOnConnection
		{
			ThroughMedian = 0,
			AlongsideMedian = 1
		}

		public enum PathContainerType
		{
			Tile = 0,
			Corner = 1
		}

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("RoadTileAtlas");

		public static readonly Fix64 RoadScale = (Fix64)0.4f;

		private static readonly Fix64 OutlineScale = (Fix64)0.6f;

		private static readonly Fix64 EdgeExtrusion = (Fix64)1.002f;

		private static readonly Fix64 CornerHandleScale = (Fix64)0.6f;

		private static readonly Fix64 TightCornerHandleScale = (Fix64)0.2f;

		private static readonly Fix64 RoundaboutMergeHandleScale = (Fix64)0.6f;

		private static readonly Fix64 DrivewayLength = (Fix64)0.5f;

		private static readonly Fix64 RoadPointResolution = (Fix64)24L;

		private static readonly Fix64 LanePointResolution = (Fix64)10L;

		private static readonly Fix64 PathInOutOfOctagonResolution = (Fix64)5L;

		public static readonly Fix64 LaneOffsetScale = (Fix64)0.2f;

		private static readonly Fix64 EndCapMeshResolution = (Fix64)13L;

		private static readonly Fix64 EndCapLaneResolution = (Fix64)9L;

		private readonly Dictionary<RoadTileSignature, RoadTileDefinition> _signatureToDefinition = new Dictionary<RoadTileSignature, RoadTileDefinition>(new RoadTileSignature.MotorwayAgnosticEqualityComparer());

		private readonly Dictionary<RoadTileSignature, RoadTileDefinition> _signatureToCornerDefinition = new Dictionary<RoadTileSignature, RoadTileDefinition>();

		private readonly List<RoadTileDefinition> _indexToDefinition = new List<RoadTileDefinition>();

		private readonly Dictionary<RoadTileConnection, RoadTileConnectionStrokePath> _connectionToStrokePaths = new Dictionary<RoadTileConnection, RoadTileConnectionStrokePath>(new RoadTileConnection.MotorwayAgnosticEqualityComparer());

		[Dependency]
		private IScope _scope;

		public void Reset()
		{
			_signatureToDefinition.Clear();
			_signatureToCornerDefinition.Clear();
			_indexToDefinition.Clear();
			_connectionToStrokePaths.Clear();
		}

		public void Initialize()
		{
			Log.Error("RoadTileAtlas.Initialise should only be called from Editor. Try rebuilding the RoadTileAtlas asset bundle (Assets -> Asset Bundles -> Build RoadTileAtlas");
		}

		public RoadTileDefinition GetDefinitionForSignature(RoadTileSignature signature)
		{
			if (_signatureToDefinition.TryGetValue(signature, out var value))
			{
				return value;
			}
			return null;
		}

		public RoadTileDefinition GetCornerDefinitionForSignature(RoadTileSignature signature)
		{
			if (_signatureToCornerDefinition.TryGetValue(signature, out var value))
			{
				return value;
			}
			return null;
		}

		public RoadTileDefinition GetDefinitionForIndex(int index)
		{
			if (Diagnostics.Verify(index < _indexToDefinition.Count, "Invalid RoadTileDefinition index ({0}, max is {1}).", index, _indexToDefinition.Count - 1))
			{
				return _indexToDefinition[index];
			}
			return null;
		}

		public RoadTileConnectionStrokePath GetStrokePathForConnection(RoadTileConnection connection)
		{
			if (_connectionToStrokePaths.TryGetValue(connection, out var value))
			{
				return value;
			}
			return null;
		}

		public void ForEachDefinition(Action<RoadTileSignature, RoadTileDefinition> action)
		{
			foreach (KeyValuePair<RoadTileSignature, RoadTileDefinition> item in _signatureToDefinition)
			{
				action(item.Key, item.Value);
			}
		}

		private List<List<TileDirection>> GetAllTwoLaneCombinations(List<TileDirection> inputDirections)
		{
			List<List<TileDirection>> result = new List<List<TileDirection>>();
			result.Add(new List<TileDirection>());
			result.Last().Add(inputDirections[0]);
			if (inputDirections.Count == 1)
			{
				return result;
			}
			GetAllTwoLaneCombinations(inputDirections.Skip(1).ToList()).ForEach(delegate(List<TileDirection> combo)
			{
				result.Add(new List<TileDirection>(combo));
				combo.Add(inputDirections[0]);
				result.Add(new List<TileDirection>(combo));
			});
			return result;
		}

		private bool ContainsDefinition(RoadTileSignature signature)
		{
			return _signatureToDefinition.ContainsKey(signature);
		}

		private void AddDefinitionForSignature(RoadTileSignature signature, RoadTileDefinition definition)
		{
			if (Diagnostics.Verify(!_signatureToDefinition.TryGetValue(signature, out var value), "Tried to add definition {0} for signature {1} but _signatureToDefinition already contains a definition {2}", definition, signature, value))
			{
				_signatureToDefinition.Add(signature, definition);
				AddDefinitionToIndex(definition);
			}
		}

		private void AddDefinitionForCornerSignature(RoadTileSignature cornerSignature, RoadTileDefinition definition)
		{
			if (Diagnostics.Verify(!_signatureToCornerDefinition.TryGetValue(cornerSignature, out var value), "Tried to add definition {0} for corner signature {1} but _signatureToCornerDefinition already contains a definition {2}!", definition, cornerSignature, value))
			{
				_signatureToCornerDefinition.Add(cornerSignature, definition);
				AddDefinitionToIndex(definition);
			}
		}

		private void AddDefinitionToIndex(RoadTileDefinition definition)
		{
			if (Diagnostics.Verify(definition.index == -1, "Tried to add RoadTileDefinition {0} to index, but it already has index {1}", definition, definition.index))
			{
				definition.index = _indexToDefinition.Count;
				_indexToDefinition.Add(definition);
			}
		}

		private void GenerateStrokePathForConnection(RoadTileConnection connection)
		{
			if (!_connectionToStrokePaths.ContainsKey(connection))
			{
				Spline.BezierSplineFixed pathSpline;
				RoadTilePath roadTilePath = ((!connection.IsUTurn) ? ConstructPathFromConnection(connection, out pathSpline, DiagonalPathLength.Extend, PathLocationOnConnection.ThroughMedian) : ConstructStubFromConnection(connection, out pathSpline, DiagonalPathLength.Extend));
				RoadTileConnectionStrokePath roadTileConnectionStrokePath = _scope.Get<RoadTileConnectionStrokePath>();
				roadTileConnectionStrokePath.pathPoints.AddRange(from point in roadTilePath.GetVisualPoints(Vector2Fixed.zero)
					select (Vector2)point);
				if (pathSpline != null)
				{
					roadTileConnectionStrokePath.pathSpline = new Spline.BezierSpline((Vector2)pathSpline.inPoint, (Vector2)pathSpline.inHandle, (Vector2)pathSpline.outHandle, (Vector2)pathSpline.outPoint);
				}
				_connectionToStrokePaths.Add(connection, roadTileConnectionStrokePath);
				_scope.Release(roadTilePath);
			}
		}

		public RoadTileDefinition ConstructDefinitionFromSignature(RoadTileSignature signature)
		{
			if (ContainsDefinition(signature))
			{
				return GetDefinitionForSignature(signature);
			}
			for (int i = 1; i <= 3; i++)
			{
				RoadTileRotation roadTileRotation = (RoadTileRotation)i;
				RoadTileSignature roadTileSignature = signature.CreateRotatedSignature(roadTileRotation, _scope);
				RoadTileDefinition roadTileDefinition = null;
				if (ContainsDefinition(roadTileSignature))
				{
					RoadTileDefinition definitionForSignature = GetDefinitionForSignature(roadTileSignature);
					roadTileDefinition = definitionForSignature.CreateRotatedDefinition(newRotation: TileUtilities.SubtractRotation(definitionForSignature.rotation, roadTileRotation), scope: _scope);
				}
				_scope.Release(roadTileSignature);
				if (roadTileDefinition != null)
				{
					return roadTileDefinition;
				}
			}
			RoadTileDefinition roadTileDefinition2 = _scope.Get<RoadTileDefinition>();
			roadTileDefinition2.rotation = RoadTileRotation.None;
			foreach (RoadTileConnection connection in signature.Connections)
			{
				Spline.BezierSplineFixed pathSpline;
				RoadTilePath value = ConstructPathFromConnection(connection, out pathSpline, DiagonalPathLength.Truncate, PathLocationOnConnection.AlongsideMedian, PathContainerType.Tile, signature.IsRoundaboutCorner);
				roadTileDefinition2.connectionToPath.Add(connection, value);
			}
			RoadTileMesh mesh = ConstructMeshFromDefinition(roadTileDefinition2, signature.IsRoundaboutCorner);
			roadTileDefinition2.mesh = mesh;
			return roadTileDefinition2;
		}

		public RoadTileDefinition ConstructCornerDefinitionFromSignature(RoadTileSignature signature)
		{
			if (_signatureToCornerDefinition.ContainsKey(signature))
			{
				return _signatureToCornerDefinition[signature];
			}
			RoadTileDefinition roadTileDefinition = _scope.Get<RoadTileDefinition>();
			roadTileDefinition.rotation = RoadTileRotation.None;
			foreach (RoadTileConnection connection in signature.Connections)
			{
				Spline.BezierSplineFixed pathSpline;
				RoadTilePath value = ConstructPathFromConnection(connection, out pathSpline, DiagonalPathLength.Truncate, PathLocationOnConnection.AlongsideMedian, PathContainerType.Corner);
				roadTileDefinition.connectionToPath.Add(connection, value);
			}
			roadTileDefinition.mesh = null;
			return roadTileDefinition;
		}

		public RoadTilePath ConstructPathFromConnection(RoadTileConnection connection, out Spline.BezierSplineFixed pathSpline, DiagonalPathLength diagonalPathLength = DiagonalPathLength.Truncate, PathLocationOnConnection pathLocation = PathLocationOnConnection.AlongsideMedian, PathContainerType containerType = PathContainerType.Tile, bool isRoundaboutCorner = false)
		{
			pathSpline = null;
			Fix64 fix = Fix64Consts.One;
			if (containerType == PathContainerType.Corner)
			{
				fix = Fix64.Sqrt(Fix64Consts.Two) - Fix64Consts.One;
			}
			TileDirection direction = connection.input.direction;
			TileDirection direction2 = connection.output.direction;
			RoadTilePath roadTilePath = _scope.Get<RoadTilePath>();
			Fix64 fix2 = ((pathLocation == PathLocationOnConnection.ThroughMedian && direction != direction2) ? Fix64.Zero : LaneOffsetScale);
			Fix64 fix3 = ((connection.input.type == RoadType.Roundabout) ? Fix64.Zero : fix2);
			Fix64 fix4 = ((connection.output.type == RoadType.Roundabout) ? Fix64.Zero : fix2);
			_ = -Fix64Consts.Two + Fix64.Sqrt((Fix64)3L);
			_ = Fix64.Sqrt((Fix64)3L) * Fix64Consts.OneHalf;
			Vector2Fixed vector2Fixed = new Vector2Fixed(TileUtilities.DirectionToTileAdjacencyOffset[(int)direction]) * fix;
			Vector2Fixed normalized = new Vector2Fixed(vector2Fixed.y, -vector2Fixed.x).normalized;
			Vector2Fixed vector2Fixed2 = vector2Fixed - normalized * fix3;
			Vector2Fixed vector2Fixed3 = vector2Fixed.normalized * fix;
			Vector2Fixed vector2Fixed4 = vector2Fixed3 - new Vector2Fixed(vector2Fixed3.y, -vector2Fixed3.x).normalized * fix3;
			Vector2Fixed vector2Fixed5 = new Vector2Fixed(TileUtilities.DirectionToTileAdjacencyOffset[(int)direction2]) * fix;
			Vector2Fixed normalized2 = new Vector2Fixed(vector2Fixed5.y, -vector2Fixed5.x).normalized;
			Vector2Fixed vector2Fixed6 = vector2Fixed5 + normalized2 * fix4;
			Vector2Fixed vector2Fixed7 = vector2Fixed5.normalized * fix;
			Vector2Fixed vector2Fixed8 = vector2Fixed7 + new Vector2Fixed(vector2Fixed7.y, -vector2Fixed7.x).normalized * fix4;
			bool flag = (connection.input.type == RoadType.Roundabout) ^ (connection.output.type == RoadType.Roundabout);
			int distanceBetweenDirections = TileUtilities.GetDistanceBetweenDirections(connection.output.direction, TileUtilities.GetRotatedDirection(connection.input.direction, 5));
			bool flag2 = flag && distanceBetweenDirections <= 1;
			if (diagonalPathLength == DiagonalPathLength.Extend && TileUtilities.IsDirectionDiagonal(direction) && (!flag || connection.input.type != RoadType.Roundabout))
			{
				List<Vector2Fixed> list = new List<Vector2Fixed>();
				if (connection.input.type == RoadType.Roundabout)
				{
					Vector2Fixed roundaboutCenterForConnection = GetRoundaboutCenterForConnection(connection, containerType);
					Vector2Fixed vector2Fixed9 = vector2Fixed4 - roundaboutCenterForConnection;
					Vector2Fixed vector2Fixed10 = (vector2Fixed2 - roundaboutCenterForConnection).normalized * vector2Fixed9.magnitude;
					Fix64 fix5 = Vector2Fixed.Angle(vector2Fixed10, vector2Fixed9) / PathInOutOfOctagonResolution;
					for (int i = 0; i <= (int)(long)PathInOutOfOctagonResolution; i++)
					{
						Vector2 vector2Float = Vector3.RotateTowards((Vector3)vector2Fixed10, (Vector3)vector2Fixed9, (float)i * (float)fix5, 0f);
						Vector2Fixed item = roundaboutCenterForConnection + new Vector2Fixed(vector2Float);
						list.Add(item);
					}
				}
				else if (connection.input.type != RoadType.Roundabout)
				{
					list.Add(vector2Fixed2);
					list.Add(vector2Fixed4);
				}
				if (list.Count > 0)
				{
					RoadTilePath.Piece item2 = RoadTilePath.Piece.Create(_scope, list, list);
					roadTilePath.pathPieces.Add(item2);
				}
			}
			List<Vector2Fixed> list2 = new List<Vector2Fixed>();
			List<Vector2Fixed> list3 = new List<Vector2Fixed>();
			if (direction != direction2)
			{
				Fix64 fix6 = CornerHandleScale;
				Fix64 fix7 = CornerHandleScale;
				if (TileUtilities.GetDistanceBetweenDirections(direction, direction2) == 1)
				{
					if (Vector2Fixed.Dot(vector2Fixed6 - vector2Fixed2, normalized) < Fix64.Zero && diagonalPathLength == DiagonalPathLength.Truncate)
					{
						fix6 = TightCornerHandleScale;
						fix7 = TightCornerHandleScale;
					}
					if (flag)
					{
						if (connection.input.type == RoadType.Roundabout)
						{
							fix6 *= (Fix64)1.5f;
						}
						else
						{
							fix7 *= (Fix64)1.5f;
						}
					}
				}
				if (flag && containerType == PathContainerType.Corner)
				{
					if (connection.input.type != RoadType.Roundabout)
					{
						fix6 *= (Fix64)0.4f;
					}
					else
					{
						fix7 *= (Fix64)0.4f;
					}
				}
				Vector2Fixed vector2Fixed11 = vector2Fixed4;
				Vector2Fixed vector2Fixed12 = vector2Fixed8;
				Vector2Fixed vector2Fixed13 = vector2Fixed4 - vector2Fixed3 * fix6;
				Vector2Fixed vector2Fixed14 = vector2Fixed8 - vector2Fixed7 * fix7;
				if (flag)
				{
					if (flag2)
					{
						if (distanceBetweenDirections == 0)
						{
							Fix64 fix8 = (Fix64)0.3f;
							if (direction2 == TileDirection.North)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed8.x, vector2Fixed4.y + fix8);
							}
							else if (direction == TileDirection.North)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed4.x, vector2Fixed8.y + fix8);
							}
							else if (direction2 == TileDirection.South)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed8.x, vector2Fixed4.y - fix8);
							}
							else if (direction == TileDirection.South)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed4.x, vector2Fixed8.y - fix8);
							}
							else if (direction2 == TileDirection.East)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed4.x + fix8, vector2Fixed8.y);
							}
							else if (direction == TileDirection.East)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed8.x + fix8, vector2Fixed4.y);
							}
							else if (direction2 == TileDirection.West)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed4.x - fix8, vector2Fixed8.y);
							}
							else if (direction == TileDirection.West)
							{
								vector2Fixed13 = new Vector2Fixed(vector2Fixed8.x - fix8, vector2Fixed4.y);
							}
							vector2Fixed14 = vector2Fixed13;
						}
						else if (containerType == PathContainerType.Tile)
						{
							Vector2Fixed roundaboutCenterForConnection2 = GetRoundaboutCenterForConnection(connection, containerType);
							if (connection.input.type == RoadType.Roundabout)
							{
								Vector2Fixed tangent = (vector2Fixed4 - roundaboutCenterForConnection2).normalized.tangent;
								vector2Fixed13 = vector2Fixed4 + tangent * fix6;
							}
							else
							{
								Vector2Fixed tangent2 = (vector2Fixed8 - roundaboutCenterForConnection2).normalized.tangent;
								vector2Fixed14 = vector2Fixed8 - tangent2 * fix6;
							}
						}
					}
					else if (diagonalPathLength == DiagonalPathLength.Extend)
					{
						Vector2Fixed roundaboutCenterForConnection3 = GetRoundaboutCenterForConnection(connection, containerType);
						if (connection.input.type == RoadType.Roundabout)
						{
							Vector2Fixed vector2Fixed15 = vector2Fixed4 - roundaboutCenterForConnection3;
							Vector2Fixed vector2Fixed16 = (vector2Fixed2 - roundaboutCenterForConnection3).normalized * vector2Fixed15.magnitude;
							vector2Fixed11 = roundaboutCenterForConnection3 + vector2Fixed16;
							vector2Fixed13 = vector2Fixed11 - vector2Fixed3 * fix6;
						}
						else
						{
							Vector2Fixed vector2Fixed17 = vector2Fixed8 - roundaboutCenterForConnection3;
							Vector2Fixed vector2Fixed18 = (vector2Fixed6 - roundaboutCenterForConnection3).normalized * vector2Fixed17.magnitude;
							vector2Fixed12 = roundaboutCenterForConnection3 + vector2Fixed18;
							vector2Fixed14 = vector2Fixed12 - vector2Fixed7 * fix7;
						}
					}
				}
				if (connection.IsRoundabout)
				{
					Vector2Fixed roundaboutCenterForConnection4 = GetRoundaboutCenterForConnection(connection, containerType);
					Vector2Fixed vector2Fixed19 = vector2Fixed11 - roundaboutCenterForConnection4;
					Vector2Fixed vector2Fixed20 = vector2Fixed12 - roundaboutCenterForConnection4;
					Fix64 fix9 = Vector2Fixed.Angle(vector2Fixed19, vector2Fixed20);
					Fix64 fix10 = fix9 / RoadPointResolution;
					Fix64 fix11 = fix9 / LanePointResolution;
					for (int j = 0; j <= (int)(long)RoadPointResolution; j++)
					{
						Vector2Fixed vector2Fixed21 = (Vector2Fixed)Vector3.RotateTowards((Vector3)vector2Fixed19, (Vector3)vector2Fixed20, (float)j * (float)fix10, 0f);
						Vector2Fixed item3 = roundaboutCenterForConnection4 + vector2Fixed21;
						list2.Add(item3);
					}
					for (int k = 0; k <= (int)(long)LanePointResolution; k++)
					{
						Vector2 vector2Float2 = Vector3.RotateTowards((Vector3)vector2Fixed19, (Vector3)vector2Fixed20, (float)k * (float)fix11, 0f);
						Vector2Fixed vector2Fixed22 = roundaboutCenterForConnection4 + new Vector2Fixed(vector2Float2);
						list3.Add(new Vector2Fixed(vector2Fixed22));
					}
				}
				else
				{
					if (flag2 && containerType == PathContainerType.Tile)
					{
						Vector2Fixed roundaboutCenterForConnection5 = GetRoundaboutCenterForConnection(connection, containerType);
						Fix64 fix12 = ((connection.input.type == RoadType.Roundabout) ? (roundaboutCenterForConnection5 - vector2Fixed11).magnitude : (roundaboutCenterForConnection5 - vector2Fixed12).magnitude);
						Vector2Fixed normalized3 = roundaboutCenterForConnection5.normalized;
						Vector2Fixed vector2Fixed23 = roundaboutCenterForConnection5 - normalized3 * fix12;
						Vector2Fixed vector2Fixed24 = -normalized3;
						Vector2Fixed vector2Fixed25;
						Vector2Fixed vector2Fixed26;
						Vector2Fixed vector2Fixed27;
						Vector2Fixed vector2Fixed28;
						if (connection.input.type == RoadType.Roundabout)
						{
							vector2Fixed25 = vector2Fixed23;
							vector2Fixed26 = vector2Fixed23 + vector2Fixed24 * RoundaboutMergeHandleScale;
							vector2Fixed27 = vector2Fixed12;
							vector2Fixed28 = vector2Fixed12 - vector2Fixed7 * fix7;
						}
						else
						{
							vector2Fixed25 = vector2Fixed11;
							vector2Fixed26 = vector2Fixed11 - vector2Fixed3 * fix6;
							vector2Fixed27 = vector2Fixed23;
							vector2Fixed28 = vector2Fixed23 + vector2Fixed24 * RoundaboutMergeHandleScale;
						}
						for (Fix64 zero = Fix64.Zero; zero <= RoadPointResolution; zero += Fix64Consts.One)
						{
							Vector2Fixed item4 = Spline.EvaluateBezier(zero / RoadPointResolution, vector2Fixed25, vector2Fixed26, vector2Fixed28, vector2Fixed27);
							list2.Add(item4);
						}
						pathSpline = new Spline.BezierSplineFixed(vector2Fixed25, vector2Fixed26, vector2Fixed28, vector2Fixed27);
					}
					else
					{
						for (Fix64 zero2 = Fix64.Zero; zero2 <= RoadPointResolution; zero2 += Fix64Consts.One)
						{
							Vector2Fixed item5 = Spline.EvaluateBezier(zero2 / RoadPointResolution, vector2Fixed11, vector2Fixed13, vector2Fixed14, vector2Fixed12);
							list2.Add(item5);
						}
						pathSpline = new Spline.BezierSplineFixed(vector2Fixed11, vector2Fixed13, vector2Fixed14, vector2Fixed12);
					}
					for (Fix64 zero3 = Fix64.Zero; zero3 <= LanePointResolution; zero3 += Fix64Consts.One)
					{
						Vector2Fixed item6 = Spline.EvaluateBezier(zero3 / LanePointResolution, vector2Fixed11, vector2Fixed13, vector2Fixed14, vector2Fixed12);
						list3.Add(item6);
					}
				}
			}
			else
			{
				list2.Add(new Vector2Fixed(vector2Fixed4));
				list3.Add(new Vector2Fixed(vector2Fixed4));
				Vector2Fixed vector2Fixed29 = (vector2Fixed4 + vector2Fixed8) / Fix64Consts.Two;
				Fix64 fix13 = fix2;
				if (connection.input.type == RoadType.Driveway)
				{
					fix13 += DrivewayLength;
				}
				vector2Fixed29 -= vector2Fixed3.normalized * fix13;
				Fix64 fix14 = Fix64.Pi / EndCapMeshResolution;
				Vector2Fixed vector2Fixed30 = new Vector2Fixed(vector2Fixed3.y, -vector2Fixed3.x).normalized * -fix2;
				for (Fix64 zero4 = Fix64.Zero; zero4 <= EndCapMeshResolution; zero4 += Fix64Consts.One)
				{
					Fix64 fix15 = Fix64.Cos(fix14 * zero4);
					Fix64 fix16 = Fix64.Sin(fix14 * zero4);
					Fix64 x = vector2Fixed30.x * fix15 - vector2Fixed30.y * fix16;
					Fix64 y = vector2Fixed30.x * fix16 + vector2Fixed30.y * fix15;
					Vector2Fixed item7 = new Vector2Fixed(x, y) + vector2Fixed29;
					list2.Add(item7);
				}
				fix14 = Fix64.Pi / EndCapLaneResolution;
				for (Fix64 zero5 = Fix64.Zero; zero5 <= EndCapLaneResolution; zero5 += Fix64Consts.One)
				{
					Fix64 fix17 = Fix64.Cos(fix14 * zero5);
					Fix64 fix18 = Fix64.Sin(fix14 * zero5);
					Fix64 x2 = vector2Fixed30.x * fix17 - vector2Fixed30.y * fix18;
					Fix64 y2 = vector2Fixed30.x * fix18 + vector2Fixed30.y * fix17;
					Vector2Fixed item8 = new Vector2Fixed(x2, y2) + vector2Fixed29;
					list3.Add(item8);
				}
				list2.Add(new Vector2Fixed(vector2Fixed8));
				list3.Add(new Vector2Fixed(vector2Fixed8));
				pathSpline = new Spline.BezierSplineFixed(vector2Fixed4, Vector2Fixed.Lerp(vector2Fixed4, vector2Fixed8, Fix64.One / (Fix64)3L), Vector2Fixed.Lerp(vector2Fixed4, vector2Fixed8, Fix64Consts.Two / (Fix64)3L), vector2Fixed8);
			}
			RoadTilePath.Piece item9 = RoadTilePath.Piece.Create(_scope, list2, list3);
			roadTilePath.pathPieces.Add(item9);
			if (diagonalPathLength == DiagonalPathLength.Extend && TileUtilities.IsDirectionDiagonal(direction2) && (!flag || connection.output.type != RoadType.Roundabout))
			{
				List<Vector2Fixed> list4 = new List<Vector2Fixed>();
				if (connection.output.type == RoadType.Roundabout)
				{
					Vector2Fixed roundaboutCenterForConnection6 = GetRoundaboutCenterForConnection(connection, containerType);
					Vector2Fixed vector2Fixed31 = vector2Fixed8 - roundaboutCenterForConnection6;
					Vector2Fixed vector2Fixed32 = (vector2Fixed6 - roundaboutCenterForConnection6).normalized * vector2Fixed31.magnitude;
					Fix64 fix19 = Vector2Fixed.Angle(vector2Fixed31, vector2Fixed32) / PathInOutOfOctagonResolution;
					for (int l = 0; l <= (int)(long)PathInOutOfOctagonResolution; l++)
					{
						Vector2 vector2Float3 = Vector3.RotateTowards((Vector3)vector2Fixed31, (Vector3)vector2Fixed32, (float)l * (float)fix19, 0f);
						Vector2Fixed item10 = roundaboutCenterForConnection6 + new Vector2Fixed(vector2Float3);
						list4.Add(item10);
					}
				}
				else if (connection.output.type != RoadType.Roundabout)
				{
					list4.Add(vector2Fixed8);
					list4.Add(vector2Fixed6);
				}
				if (list4.Count > 0)
				{
					RoadTilePath.Piece item11 = RoadTilePath.Piece.Create(_scope, list4, list4);
					roadTilePath.pathPieces.Add(item11);
				}
			}
			return roadTilePath;
		}

		private static Vector2Fixed GetRoundaboutCenterForConnection(RoadTileConnection connection, PathContainerType containerType)
		{
			switch (containerType)
			{
			case PathContainerType.Tile:
				if (connection.input.type == RoadType.Roundabout)
				{
					switch (connection.input.direction)
					{
					case TileDirection.NorthEast:
						return new Vector2Fixed(2f, 0f);
					case TileDirection.NorthWest:
						return new Vector2Fixed(0f, 2f);
					case TileDirection.SouthWest:
						return new Vector2Fixed(-2f, 0f);
					case TileDirection.SouthEast:
						return new Vector2Fixed(0f, -2f);
					}
				}
				else if (connection.output.type == RoadType.Roundabout)
				{
					switch (connection.output.direction)
					{
					case TileDirection.SouthEast:
						return new Vector2Fixed(2f, 0f);
					case TileDirection.NorthEast:
						return new Vector2Fixed(0f, 2f);
					case TileDirection.NorthWest:
						return new Vector2Fixed(-2f, 0f);
					case TileDirection.SouthWest:
						return new Vector2Fixed(0f, -2f);
					}
				}
				break;
			case PathContainerType.Corner:
				if (connection.input.type == RoadType.Roundabout)
				{
					switch (connection.input.direction)
					{
					case TileDirection.SouthWest:
						return new Vector2Fixed(-1f, 1f);
					case TileDirection.SouthEast:
						return new Vector2Fixed(-1f, -1f);
					case TileDirection.NorthEast:
						return new Vector2Fixed(1f, -1f);
					case TileDirection.NorthWest:
						return new Vector2Fixed(1f, 1f);
					}
				}
				else if (connection.input.type == RoadType.Roundabout)
				{
					switch (connection.output.direction)
					{
					case TileDirection.NorthEast:
						return new Vector2Fixed(-1f, 1f);
					case TileDirection.NorthWest:
						return new Vector2Fixed(-1f, -1f);
					case TileDirection.SouthWest:
						return new Vector2Fixed(1f, -1f);
					case TileDirection.SouthEast:
						return new Vector2Fixed(1f, 1f);
					}
				}
				break;
			}
			return Vector2Fixed.zero;
		}

		private RoadTilePath ConstructStubFromConnection(RoadTileConnection connection, out Spline.BezierSplineFixed stubSpline, DiagonalPathLength diagonalPathLength = DiagonalPathLength.Truncate)
		{
			if (connection.input.direction != connection.output.direction)
			{
				return ConstructPathFromConnection(connection, out stubSpline, diagonalPathLength, PathLocationOnConnection.ThroughMedian);
			}
			TileDirection direction = connection.input.direction;
			RoadTilePath roadTilePath = _scope.Get<RoadTilePath>();
			Vector2Fixed item = new Vector2Fixed(TileUtilities.DirectionToTileAdjacencyOffset[(int)direction]);
			Vector2Fixed normalized = item.normalized;
			Vector2Fixed zero = Vector2Fixed.zero;
			if (diagonalPathLength == DiagonalPathLength.Extend && TileUtilities.IsDirectionDiagonal(direction))
			{
				List<Vector2Fixed> list = new List<Vector2Fixed>();
				list.Add(item);
				list.Add(normalized);
				RoadTilePath.Piece item2 = RoadTilePath.Piece.Create(_scope, list, list);
				roadTilePath.pathPieces.Add(item2);
			}
			List<Vector2Fixed> list2 = new List<Vector2Fixed>();
			list2.Add(normalized);
			list2.Add(zero);
			RoadTilePath.Piece item3 = RoadTilePath.Piece.Create(_scope, list2, list2);
			roadTilePath.pathPieces.Add(item3);
			Vector2Fixed vector2Fixed = zero - normalized;
			stubSpline = new Spline.BezierSplineFixed(normalized, normalized + vector2Fixed * (Fix64.One / (Fix64)3L), normalized + vector2Fixed * (Fix64Consts.Two / (Fix64)3L), zero);
			return roadTilePath;
		}

		private RoadTileMesh ConstructMeshFromDefinition(RoadTileDefinition definition, bool isRoundaboutCorner)
		{
			return null;
		}

		public void ApplyMeshOverrides(RoadTileMeshOverride meshOverride)
		{
			foreach (RoadTileMeshOverrideDefinition meshOverride2 in meshOverride.meshOverrides)
			{
				RoadTileSignature roadTileSignature = _scope.Get<RoadTileSignature>();
				TileDirectionBitfield.Enumerator enumerator2 = new TileDirectionBitfield(meshOverride2.directions).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					TileDirection current2 = enumerator2.Current;
					roadTileSignature.AddNode(new RoadTileNode(current2));
				}
				_signatureToDefinition[roadTileSignature].mesh.ApplyMeshOverrides(meshOverride2.meshes);
			}
		}
	}
}
