using System;
using System.Collections.Generic;
using Pathfinding.ClipperLib;
using Pathfinding.Graphs.Navmesh.Voxelization;
using Pathfinding.Graphs.Util;
using Pathfinding.Poly2Tri;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public class TileHandler
	{
		public class TileType
		{
			private Int3[] verts;

			private int[] tris;

			private uint[] tags;

			private Int3 offset;

			private int lastYOffset;

			private int lastRotation;

			private int width;

			private int depth;

			private static readonly int[] Rotations = new int[16]
			{
				1, 0, 0, 1, 0, 1, -1, 0, -1, 0,
				0, -1, 0, -1, 1, 0
			};

			public int Width => width;

			public int Depth => depth;

			public TileType(UnsafeSpan<Int3> sourceVerts, UnsafeSpan<int> sourceTris, uint[] tags, Int3 tileSize, Int3 centerOffset, int width = 1, int depth = 1)
			{
				tris = sourceTris.ToArray();
				this.tags = tags;
				verts = new Int3[sourceVerts.Length];
				offset = tileSize / 2f;
				offset.x *= width;
				offset.z *= depth;
				offset.y = 0;
				offset += centerOffset;
				for (int i = 0; i < sourceVerts.Length; i++)
				{
					verts[i] = sourceVerts[i] + offset;
				}
				lastRotation = 0;
				lastYOffset = 0;
				this.width = width;
				this.depth = depth;
			}

			public TileType(Mesh source, Int3 tileSize, Int3 centerOffset, int width = 1, int depth = 1)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				Vector3[] vertices = source.vertices;
				tris = source.triangles;
				verts = new Int3[vertices.Length];
				tags = null;
				for (int i = 0; i < vertices.Length; i++)
				{
					verts[i] = (Int3)vertices[i] + centerOffset;
				}
				offset = tileSize / 2f;
				offset.x *= width;
				offset.z *= depth;
				offset.y = 0;
				for (int j = 0; j < vertices.Length; j++)
				{
					verts[j] += offset;
				}
				lastRotation = 0;
				lastYOffset = 0;
				this.width = width;
				this.depth = depth;
			}

			public void Load(out Int3[] verts, out int[] tris, out uint[] tags, int rotation, int yoffset)
			{
				rotation = (rotation % 4 + 4) % 4;
				int num = rotation;
				rotation = (rotation - lastRotation % 4 + 4) % 4;
				lastRotation = num;
				verts = this.verts;
				int num2 = yoffset - lastYOffset;
				lastYOffset = yoffset;
				if (rotation != 0 || num2 != 0)
				{
					for (int i = 0; i < verts.Length; i++)
					{
						Int3 int5 = verts[i] - offset;
						Int3 int6 = int5;
						int6.y += num2;
						int6.x = int5.x * Rotations[rotation * 4] + int5.z * Rotations[rotation * 4 + 1];
						int6.z = int5.x * Rotations[rotation * 4 + 2] + int5.z * Rotations[rotation * 4 + 3];
						verts[i] = int6 + offset;
					}
				}
				tris = this.tris;
				tags = this.tags;
			}
		}

		[Flags]
		public enum CutMode
		{
			CutAll = 1,
			CutDual = 2,
			CutExtra = 4
		}

		private class Cut
		{
			public IntRect bounds;

			public Int2 boundsY;

			public bool isDual;

			public bool cutsAddedGeom;

			public List<IntPoint> contour;
		}

		private struct CuttingResult
		{
			public Int3[] verts;

			public int[] tris;

			public uint[] tags;
		}

		public readonly NavmeshBase graph;

		private int tileXCount;

		private int tileZCount;

		private readonly Clipper clipper = new Clipper();

		private readonly Dictionary<Int2, int> cached_Int2_int_dict = new Dictionary<Int2, int>();

		private TileType[] activeTileTypes;

		private int[] activeTileRotations;

		private int[] activeTileOffsets;

		private bool[] reloadedInBatch;

		public readonly GridLookup<NavmeshClipper> cuts;

		private int batchDepth;

		private Int3PolygonClipper simpleClipper;

		private bool isBatching => batchDepth > 0;

		public bool isValid
		{
			get
			{
				if (graph != null && graph.exists && tileXCount == graph.tileXCount)
				{
					return tileZCount == graph.tileZCount;
				}
				return false;
			}
		}

		public TileHandler(NavmeshBase graph)
		{
			if (graph == null)
			{
				throw new ArgumentNullException("graph");
			}
			if (graph.GetTiles() == null)
			{
				Debug.LogWarning("Creating a TileHandler for a graph with no tiles. Please scan the graph before creating a TileHandler");
			}
			tileXCount = graph.tileXCount;
			tileZCount = graph.tileZCount;
			activeTileTypes = new TileType[tileXCount * tileZCount];
			activeTileRotations = new int[activeTileTypes.Length];
			activeTileOffsets = new int[activeTileTypes.Length];
			reloadedInBatch = new bool[activeTileTypes.Length];
			cuts = new GridLookup<NavmeshClipper>(new Int2(tileXCount, tileZCount));
			this.graph = graph;
		}

		public void Resize(IntRect newTileBounds)
		{
			TileType[] array = new TileType[newTileBounds.Area];
			int[] array2 = new int[array.Length];
			int[] array3 = new int[array.Length];
			bool[] array4 = new bool[array.Length];
			for (int i = 0; i < tileZCount; i++)
			{
				for (int j = 0; j < tileXCount; j++)
				{
					if (newTileBounds.Contains(j, i))
					{
						int num = j + i * tileXCount;
						int num2 = j - newTileBounds.xmin + (i - newTileBounds.ymin) * newTileBounds.Width;
						array[num2] = activeTileTypes[num];
						array2[num2] = activeTileRotations[num];
						array3[num2] = activeTileOffsets[num];
					}
				}
			}
			tileXCount = newTileBounds.Width;
			tileZCount = newTileBounds.Height;
			activeTileTypes = array;
			activeTileRotations = array2;
			activeTileOffsets = array3;
			reloadedInBatch = array4;
			for (int k = 0; k < tileZCount; k++)
			{
				for (int l = 0; l < tileXCount; l++)
				{
					int num3 = l + k * tileXCount;
					if (activeTileTypes[num3] == null)
					{
						UpdateTileType(graph.GetTile(l, k));
					}
				}
			}
			cuts.Resize(newTileBounds);
		}

		public void OnRecalculatedTiles(NavmeshTile[] recalculatedTiles)
		{
			for (int i = 0; i < recalculatedTiles.Length; i++)
			{
				UpdateTileType(recalculatedTiles[i]);
			}
			StartBatchLoad();
			for (int j = 0; j < recalculatedTiles.Length; j++)
			{
				ReloadTile(recalculatedTiles[j].x, recalculatedTiles[j].z);
			}
			EndBatchLoad();
		}

		public void GetSourceTileData(int x, int z, out Int3[] verts, out int[] tris, out uint[] tags)
		{
			int num = x + z * tileXCount;
			activeTileTypes[num].Load(out verts, out tris, out tags, activeTileRotations[num], activeTileOffsets[num]);
		}

		public TileType RegisterTileType(Mesh source, Int3 centerOffset, int width = 1, int depth = 1)
		{
			return new TileType(source, (Int3)new Vector3(graph.TileWorldSizeX, 0f, graph.TileWorldSizeZ), centerOffset, width, depth);
		}

		public void CreateTileTypesFromGraph()
		{
			NavmeshTile[] tiles = graph.GetTiles();
			if (tiles == null)
			{
				return;
			}
			if (!isValid)
			{
				throw new InvalidOperationException("Graph tiles are invalid (number of tiles is not equal to width*depth of the graph). You need to create a new tile handler if you have changed the graph.");
			}
			for (int i = 0; i < tileZCount; i++)
			{
				for (int j = 0; j < tileXCount; j++)
				{
					NavmeshTile tile = tiles[j + i * tileXCount];
					UpdateTileType(tile);
				}
			}
		}

		private void UpdateTileType(NavmeshTile tile)
		{
			int x = tile.x;
			int z = tile.z;
			Int3 tileSize = (Int3)new Vector3(graph.TileWorldSizeX, 0f, graph.TileWorldSizeZ);
			Int3 centerOffset = -((Int3)graph.GetTileBoundsInGraphSpace(x, z).min + new Int3(tileSize.x * tile.w / 2, 0, tileSize.z * tile.d / 2));
			uint[] array = new uint[tile.nodes.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = tile.nodes[i].Tag;
			}
			TileType tileType = new TileType(tile.vertsInGraphSpace, tile.tris, array, tileSize, centerOffset, tile.w, tile.d);
			int num = x + z * tileXCount;
			activeTileTypes[num] = tileType;
			activeTileRotations[num] = 0;
			activeTileOffsets[num] = 0;
		}

		public void StartBatchLoad()
		{
			batchDepth++;
			if (batchDepth <= 1)
			{
				AstarPath.active.AddWorkItem(new AstarWorkItem((Func<bool, bool>)delegate
				{
					graph.StartBatchTileUpdate();
					return true;
				}));
			}
		}

		public void EndBatchLoad()
		{
			if (batchDepth <= 0)
			{
				throw new Exception("Ending batching when batching has not been started");
			}
			batchDepth--;
			for (int i = 0; i < reloadedInBatch.Length; i++)
			{
				reloadedInBatch[i] = false;
			}
			AstarPath.active.AddWorkItem(new AstarWorkItem((Func<IWorkItemContext, bool, bool>)delegate
			{
				graph.EndBatchTileUpdate();
				return true;
			}));
		}

		private CuttingResult CutPoly(Int3[] verts, int[] tris, uint[] tags, Int3[] extraShape, GraphTransform graphTransform, IntRect tiles, CutMode mode = CutMode.CutAll | CutMode.CutDual, int perturbate = -1)
		{
			List<NavmeshAdd> list = cuts.QueryRect<NavmeshAdd>(tiles);
			if ((verts.Length == 0 || tris.Length == 0) && list.Count == 0)
			{
				return new CuttingResult
				{
					verts = ArrayPool<Int3>.Claim(0),
					tris = ArrayPool<int>.Claim(0),
					tags = ArrayPool<uint>.Claim(0)
				};
			}
			if (perturbate > 10)
			{
				Debug.LogError("Too many perturbations aborting.\nThis may cause a tile in the navmesh to become empty. Try to see see if any of your NavmeshCut or NavmeshAdd components use invalid custom meshes.");
				return new CuttingResult
				{
					verts = verts,
					tris = tris,
					tags = tags
				};
			}
			List<IntPoint> list2 = null;
			if (extraShape == null && (mode & CutMode.CutExtra) != 0)
			{
				throw new Exception("extraShape is null and the CutMode specifies that it should be used. Cannot use null shape.");
			}
			Bounds tileBoundsInGraphSpace = graph.GetTileBoundsInGraphSpace(tiles);
			Vector3 min = tileBoundsInGraphSpace.min;
			GraphTransform graphTransform2 = graphTransform * Matrix4x4.TRS(min, Quaternion.identity, Vector3.one);
			Vector2 vector = new Vector2(tileBoundsInGraphSpace.size.x, tileBoundsInGraphSpace.size.z);
			float navmeshCuttingCharacterRadius = graph.NavmeshCuttingCharacterRadius;
			if ((mode & CutMode.CutExtra) != 0)
			{
				list2 = ListPool<IntPoint>.Claim(extraShape.Length);
				for (int i = 0; i < extraShape.Length; i++)
				{
					Int3 int5 = graphTransform2.InverseTransform(extraShape[i]);
					list2.Add(new IntPoint(int5.x, int5.z));
				}
			}
			List<NavmeshCut> list3 = ((mode != CutMode.CutExtra) ? cuts.QueryRect<NavmeshCut>(tiles) : ListPool<NavmeshCut>.Claim());
			List<int> list4 = ListPool<int>.Claim();
			List<Cut> list5 = PrepareNavmeshCutsForCutting(list3, graphTransform2, perturbate, navmeshCuttingCharacterRadius);
			List<Int3> list6 = ListPool<Int3>.Claim(verts.Length * 2);
			List<int> list7 = ListPool<int>.Claim(tris.Length);
			List<uint> list8 = ListPool<uint>.Claim(tags.Length);
			if (list3.Count == 0 && list.Count == 0 && (mode & ~(CutMode.CutAll | CutMode.CutDual)) == 0 && (mode & CutMode.CutAll) != 0)
			{
				CopyMesh(verts, tris, tags, list6, list7, list8);
			}
			else
			{
				List<IntPoint> list9 = ListPool<IntPoint>.Claim();
				Dictionary<TriangulationPoint, int> dictionary = new Dictionary<TriangulationPoint, int>();
				List<PolygonPoint> list10 = ListPool<PolygonPoint>.Claim();
				PolyTree polyTree = new PolyTree();
				List<List<IntPoint>> list11 = ListPool<List<IntPoint>>.Claim();
				Stack<Pathfinding.Poly2Tri.Polygon> stack = StackPool<Pathfinding.Poly2Tri.Polygon>.Claim();
				clipper.StrictlySimple = perturbate > -1;
				clipper.ReverseSolution = true;
				Int3[] array = null;
				Int3[] clipOut = null;
				Int2 size = default(Int2);
				if (list.Count > 0)
				{
					array = new Int3[7];
					clipOut = new Int3[7];
					size = new Int2(((Int3)vector).x, ((Int3)vector).y);
				}
				Int3[] vbuffer = null;
				for (int j = -1; j < list.Count; j++)
				{
					Int3[] array2;
					int[] tbuffer;
					uint[] array3;
					if (j == -1)
					{
						array2 = verts;
						tbuffer = tris;
						array3 = tags;
					}
					else
					{
						list[j].GetMesh(ref vbuffer, out tbuffer, graphTransform2);
						array2 = vbuffer;
						array3 = null;
					}
					for (int k = 0; k < tbuffer.Length; k += 3)
					{
						Int3 int6 = array2[tbuffer[k]];
						Int3 int7 = array2[tbuffer[k + 1]];
						Int3 int8 = array2[tbuffer[k + 2]];
						uint item = ((array3 != null) ? array3[k / 3] : 0u);
						if (VectorMath.IsColinearXZ(int6, int7, int8))
						{
							Debug.LogWarning("Skipping degenerate triangle.");
							continue;
						}
						IntRect a = new IntRect(int6.x, int6.z, int6.x, int6.z).ExpandToContain(int7.x, int7.z).ExpandToContain(int8.x, int8.z);
						int num = Math.Min(int6.y, Math.Min(int7.y, int8.y));
						int num2 = Math.Max(int6.y, Math.Max(int7.y, int8.y));
						list4.Clear();
						bool flag = false;
						for (int l = 0; l < list5.Count; l++)
						{
							int x = list5[l].boundsY.x;
							int y = list5[l].boundsY.y;
							if (IntRect.Intersects(a, list5[l].bounds) && y >= num && x <= num2 && (list5[l].cutsAddedGeom || j == -1))
							{
								Int3 int9 = int6;
								int9.y = x;
								Int3 int10 = int6;
								int10.y = y;
								list4.Add(l);
								flag |= list5[l].isDual;
							}
						}
						if (list4.Count == 0 && (mode & CutMode.CutExtra) == 0 && (mode & CutMode.CutAll) != 0 && j == -1)
						{
							list7.Add(list6.Count);
							list7.Add(list6.Count + 1);
							list7.Add(list6.Count + 2);
							list6.Add(int6);
							list6.Add(int7);
							list6.Add(int8);
							list8.Add(item);
							continue;
						}
						list9.Clear();
						if (j == -1)
						{
							list9.Add(new IntPoint(int6.x, int6.z));
							list9.Add(new IntPoint(int7.x, int7.z));
							list9.Add(new IntPoint(int8.x, int8.z));
						}
						else
						{
							array[0] = int6;
							array[1] = int7;
							array[2] = int8;
							int num3 = ClipAgainstRectangle(array, clipOut, size);
							if (num3 == 0)
							{
								continue;
							}
							for (int m = 0; m < num3; m++)
							{
								list9.Add(new IntPoint(array[m].x, array[m].z));
							}
						}
						dictionary.Clear();
						for (int n = 0; n < 4; n++)
						{
							if ((((int)mode >> n) & 1) == 0)
							{
								continue;
							}
							if (1 << n == 1)
							{
								CutAll(list9, list4, list5, polyTree);
							}
							else if (1 << n == 2)
							{
								if (!flag)
								{
									continue;
								}
								CutDual(list9, list4, list5, flag, list11, polyTree);
							}
							else if (1 << n == 4)
							{
								CutExtra(list9, list2, polyTree);
							}
							for (int num4 = 0; num4 < polyTree.ChildCount; num4++)
							{
								PolyNode polyNode = polyTree.Childs[num4];
								List<IntPoint> contour = polyNode.Contour;
								List<PolyNode> childs = polyNode.Childs;
								if (childs.Count == 0 && contour.Count == 3 && j == -1)
								{
									for (int num5 = 0; num5 < 3; num5++)
									{
										Int3 int11 = new Int3((int)contour[num5].X, 0, (int)contour[num5].Y);
										int11.y = Polygon.SampleYCoordinateInTriangle(int6, int7, int8, int11);
										list7.Add(list6.Count);
										list6.Add(int11);
									}
									list8.Add(item);
									continue;
								}
								Pathfinding.Poly2Tri.Polygon polygon = null;
								int num6 = -1;
								for (List<IntPoint> list12 = contour; list12 != null; list12 = ((num6 < childs.Count) ? childs[num6].Contour : null))
								{
									list10.Clear();
									for (int num7 = 0; num7 < list12.Count; num7++)
									{
										PolygonPoint polygonPoint = new PolygonPoint(list12[num7].X, list12[num7].Y);
										list10.Add(polygonPoint);
										Int3 int12 = new Int3((int)list12[num7].X, 0, (int)list12[num7].Y);
										int12.y = Polygon.SampleYCoordinateInTriangle(int6, int7, int8, int12);
										dictionary[polygonPoint] = list6.Count;
										list6.Add(int12);
									}
									Pathfinding.Poly2Tri.Polygon polygon2 = null;
									if (stack.Count > 0)
									{
										polygon2 = stack.Pop();
										polygon2.AddPoints(list10);
									}
									else
									{
										polygon2 = new Pathfinding.Poly2Tri.Polygon(list10);
									}
									if (num6 == -1)
									{
										polygon = polygon2;
									}
									else
									{
										polygon.AddHole(polygon2);
									}
									num6++;
								}
								try
								{
									P2T.Triangulate(polygon);
								}
								catch (PointOnEdgeException)
								{
									Debug.LogWarning("PointOnEdgeException, perturbating vertices slightly.\nThis is usually fine. It happens sometimes because of rounding errors. Cutting will be retried a few more times.");
									return CutPoly(verts, tris, tags, extraShape, graphTransform, tiles, mode, perturbate + 1);
								}
								try
								{
									for (int num8 = 0; num8 < polygon.Triangles.Count; num8++)
									{
										DelaunayTriangle delaunayTriangle = polygon.Triangles[num8];
										list7.Add(dictionary[delaunayTriangle.Points._0]);
										list7.Add(dictionary[delaunayTriangle.Points._1]);
										list7.Add(dictionary[delaunayTriangle.Points._2]);
										list8.Add(item);
									}
								}
								catch (KeyNotFoundException)
								{
									Debug.LogWarning("KeyNotFoundException, perturbating vertices slightly.\nThis is usually fine. It happens sometimes because of rounding errors. Cutting will be retried a few more times.");
									return CutPoly(verts, tris, tags, extraShape, graphTransform, tiles, mode, perturbate + 1);
								}
								PoolPolygon(polygon, stack);
							}
						}
					}
				}
				if (vbuffer != null)
				{
					ArrayPool<Int3>.Release(ref vbuffer);
				}
				StackPool<Pathfinding.Poly2Tri.Polygon>.Release(stack);
				ListPool<List<IntPoint>>.Release(ref list11);
				ListPool<IntPoint>.Release(ref list9);
				ListPool<PolygonPoint>.Release(ref list10);
			}
			CuttingResult result = default(CuttingResult);
			Polygon.CompressMesh(list6, list7, list8, out result.verts, out result.tris, out result.tags);
			for (int num9 = 0; num9 < list3.Count; num9++)
			{
				list3[num9].UsedForCut();
			}
			ListPool<Int3>.Release(ref list6);
			ListPool<int>.Release(ref list7);
			ListPool<uint>.Release(ref list8);
			ListPool<int>.Release(ref list4);
			for (int num10 = 0; num10 < list5.Count; num10++)
			{
				ListPool<IntPoint>.Release(list5[num10].contour);
			}
			ListPool<Cut>.Release(ref list5);
			ListPool<NavmeshCut>.Release(ref list3);
			return result;
		}

		private unsafe static List<Cut> PrepareNavmeshCutsForCutting(List<NavmeshCut> navmeshCuts, GraphTransform transform, int perturbate, float characterRadius)
		{
			System.Random random = null;
			if (perturbate > 0)
			{
				random = new System.Random();
			}
			UnsafeList<float2> unsafeList = new UnsafeList<float2>(0, Allocator.Temp);
			UnsafeList<NavmeshCut.ContourBurst> unsafeList2 = new UnsafeList<NavmeshCut.ContourBurst>(0, Allocator.Temp);
			List<Cut> list = ListPool<Cut>.Claim();
			for (int i = 0; i < navmeshCuts.Count; i++)
			{
				Int2 int5 = new Int2(0, 0);
				if (perturbate > 0)
				{
					int5.x = random.Next() % 6 * perturbate - 3 * perturbate;
					if (int5.x >= 0)
					{
						int5.x++;
					}
					int5.y = random.Next() % 6 * perturbate - 3 * perturbate;
					if (int5.y >= 0)
					{
						int5.y++;
					}
				}
				navmeshCuts[i].GetContourBurst(&unsafeList, &unsafeList2, transform.inverseMatrix, characterRadius);
				for (int j = 0; j < unsafeList2.Length; j++)
				{
					NavmeshCut.ContourBurst contourBurst = unsafeList2[j];
					if (contourBurst.endIndex <= contourBurst.startIndex)
					{
						Debug.LogError("A NavmeshCut component had a zero length contour. Ignoring that contour.");
						continue;
					}
					List<IntPoint> list2 = ListPool<IntPoint>.Claim(contourBurst.endIndex - contourBurst.startIndex);
					for (int k = contourBurst.startIndex; k < contourBurst.endIndex; k++)
					{
						float2 float5 = unsafeList[k] * 1000f;
						IntPoint item = new IntPoint((long)float5.x, (long)float5.y);
						if (perturbate > 0)
						{
							item.X += int5.x;
							item.Y += int5.y;
						}
						list2.Add(item);
					}
					IntRect bounds = new IntRect((int)list2[0].X, (int)list2[0].Y, (int)list2[0].X, (int)list2[0].Y);
					for (int l = 0; l < list2.Count; l++)
					{
						IntPoint intPoint = list2[l];
						bounds = bounds.ExpandToContain((int)intPoint.X, (int)intPoint.Y);
					}
					Cut cut = new Cut();
					cut.boundsY = new Int2((int)(contourBurst.ymin * 1000f), (int)(contourBurst.ymax * 1000f));
					cut.bounds = bounds;
					cut.isDual = navmeshCuts[i].isDual;
					cut.cutsAddedGeom = navmeshCuts[i].cutsAddedGeom;
					cut.contour = list2;
					list.Add(cut);
				}
				unsafeList2.Clear();
				unsafeList.Clear();
			}
			unsafeList2.Dispose();
			unsafeList.Dispose();
			return list;
		}

		private static void PoolPolygon(Pathfinding.Poly2Tri.Polygon polygon, Stack<Pathfinding.Poly2Tri.Polygon> pool)
		{
			if (polygon.Holes != null)
			{
				for (int i = 0; i < polygon.Holes.Count; i++)
				{
					polygon.Holes[i].Points.Clear();
					polygon.Holes[i].ClearTriangles();
					if (polygon.Holes[i].Holes != null)
					{
						polygon.Holes[i].Holes.Clear();
					}
					pool.Push(polygon.Holes[i]);
				}
			}
			polygon.ClearTriangles();
			if (polygon.Holes != null)
			{
				polygon.Holes.Clear();
			}
			polygon.Points.Clear();
			pool.Push(polygon);
		}

		private void CutAll(List<IntPoint> poly, List<int> intersectingCutIndices, List<Cut> cuts, PolyTree result)
		{
			clipper.Clear();
			clipper.AddPolygon(poly, PolyType.ptSubject);
			for (int i = 0; i < intersectingCutIndices.Count; i++)
			{
				clipper.AddPolygon(cuts[intersectingCutIndices[i]].contour, PolyType.ptClip);
			}
			result.Clear();
			clipper.Execute(ClipType.ctDifference, result, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		}

		private void CutDual(List<IntPoint> poly, List<int> tmpIntersectingCuts, List<Cut> cuts, bool hasDual, List<List<IntPoint>> intermediateResult, PolyTree result)
		{
			clipper.Clear();
			clipper.AddPolygon(poly, PolyType.ptSubject);
			for (int i = 0; i < tmpIntersectingCuts.Count; i++)
			{
				if (cuts[tmpIntersectingCuts[i]].isDual)
				{
					clipper.AddPolygon(cuts[tmpIntersectingCuts[i]].contour, PolyType.ptClip);
				}
			}
			clipper.Execute(ClipType.ctIntersection, intermediateResult, PolyFillType.pftEvenOdd, PolyFillType.pftNonZero);
			clipper.Clear();
			if (intermediateResult != null)
			{
				for (int j = 0; j < intermediateResult.Count; j++)
				{
					clipper.AddPolygon(intermediateResult[j], Clipper.Orientation(intermediateResult[j]) ? PolyType.ptClip : PolyType.ptSubject);
				}
			}
			for (int k = 0; k < tmpIntersectingCuts.Count; k++)
			{
				if (!cuts[tmpIntersectingCuts[k]].isDual)
				{
					clipper.AddPolygon(cuts[tmpIntersectingCuts[k]].contour, PolyType.ptClip);
				}
			}
			result.Clear();
			clipper.Execute(ClipType.ctDifference, result, PolyFillType.pftEvenOdd, PolyFillType.pftNonZero);
		}

		private void CutExtra(List<IntPoint> poly, List<IntPoint> extraClipShape, PolyTree result)
		{
			clipper.Clear();
			clipper.AddPolygon(poly, PolyType.ptSubject);
			clipper.AddPolygon(extraClipShape, PolyType.ptClip);
			result.Clear();
			clipper.Execute(ClipType.ctIntersection, result, PolyFillType.pftEvenOdd, PolyFillType.pftNonZero);
		}

		private int ClipAgainstRectangle(Int3[] clipIn, Int3[] clipOut, Int2 size)
		{
			int num = simpleClipper.ClipPolygon(clipIn, 3, clipOut, 1, 0, 0);
			if (num == 0)
			{
				return num;
			}
			num = simpleClipper.ClipPolygon(clipOut, num, clipIn, -1, size.x, 0);
			if (num == 0)
			{
				return num;
			}
			num = simpleClipper.ClipPolygon(clipIn, num, clipOut, 1, 0, 2);
			if (num == 0)
			{
				return num;
			}
			return simpleClipper.ClipPolygon(clipOut, num, clipIn, -1, size.y, 2);
		}

		private static void CopyMesh(Int3[] vertices, int[] triangles, uint[] tags, List<Int3> outVertices, List<int> outTriangles, List<uint> outTags)
		{
			outTriangles.Capacity = Math.Max(outTriangles.Capacity, triangles.Length);
			outVertices.Capacity = Math.Max(outVertices.Capacity, vertices.Length);
			outTags.Capacity = Math.Max(outTags.Capacity, tags.Length);
			for (int i = 0; i < vertices.Length; i++)
			{
				outVertices.Add(vertices[i]);
			}
			for (int j = 0; j < triangles.Length; j++)
			{
				outTriangles.Add(triangles[j]);
			}
			for (int k = 0; k < tags.Length; k++)
			{
				outTags.Add(tags[k]);
			}
		}

		private void DelaunayRefinement(Int3[] verts, int[] tris, uint[] tags, ref int tCount, bool delaunay, bool colinear)
		{
			if (tCount % 3 != 0)
			{
				throw new ArgumentException("Triangle array length must be a multiple of 3");
			}
			if (tags != null && tags.Length != tCount / 3)
			{
				throw new ArgumentException("There must be exactly 1 tag per 3 triangle indices");
			}
			Dictionary<Int2, int> dictionary = cached_Int2_int_dict;
			dictionary.Clear();
			for (int i = 0; i < tCount; i += 3)
			{
				if (!VectorMath.IsClockwiseXZ(verts[tris[i]], verts[tris[i + 1]], verts[tris[i + 2]]))
				{
					int num = tris[i];
					tris[i] = tris[i + 2];
					tris[i + 2] = num;
				}
				dictionary[new Int2(tris[i], tris[i + 1])] = i + 2;
				dictionary[new Int2(tris[i + 1], tris[i + 2])] = i;
				dictionary[new Int2(tris[i + 2], tris[i])] = i + 1;
			}
			for (int j = 0; j < tCount; j += 3)
			{
				uint num2 = ((tags != null) ? tags[j / 3] : 0u);
				for (int k = 0; k < 3; k++)
				{
					if (!dictionary.TryGetValue(new Int2(tris[j + (k + 1) % 3], tris[j + k % 3]), out var value))
					{
						continue;
					}
					Int3 int5 = verts[tris[j + (k + 2) % 3]];
					Int3 int6 = verts[tris[j + (k + 1) % 3]];
					Int3 int7 = verts[tris[j + (k + 3) % 3]];
					Int3 int8 = verts[tris[value]];
					uint num3 = ((tags != null) ? tags[value / 3] : 0u);
					if (num2 != num3)
					{
						continue;
					}
					int5.y = 0;
					int6.y = 0;
					int7.y = 0;
					int8.y = 0;
					bool flag = false;
					if (!VectorMath.RightOrColinearXZ(int5, int7, int8) || VectorMath.RightXZ(int5, int6, int8))
					{
						if (!colinear)
						{
							continue;
						}
						flag = true;
					}
					if (colinear && VectorMath.SqrDistancePointSegmentApproximate(int5, int8, int6) < 9f && !dictionary.ContainsKey(new Int2(tris[j + (k + 2) % 3], tris[j + (k + 1) % 3])) && !dictionary.ContainsKey(new Int2(tris[j + (k + 1) % 3], tris[value])))
					{
						tCount -= 3;
						int num4 = value / 3 * 3;
						tris[j + (k + 1) % 3] = tris[value];
						if (num4 != tCount)
						{
							tris[num4] = tris[tCount];
							tris[num4 + 1] = tris[tCount + 1];
							tris[num4 + 2] = tris[tCount + 2];
							tags[num4 / 3] = tags[tCount / 3];
							dictionary[new Int2(tris[num4], tris[num4 + 1])] = num4 + 2;
							dictionary[new Int2(tris[num4 + 1], tris[num4 + 2])] = num4;
							dictionary[new Int2(tris[num4 + 2], tris[num4])] = num4 + 1;
							tris[tCount] = 0;
							tris[tCount + 1] = 0;
							tris[tCount + 2] = 0;
						}
						dictionary[new Int2(tris[j], tris[j + 1])] = j + 2;
						dictionary[new Int2(tris[j + 1], tris[j + 2])] = j;
						dictionary[new Int2(tris[j + 2], tris[j])] = j + 1;
					}
					else if (delaunay && !flag)
					{
						float num5 = Int3.Angle(int6 - int5, int7 - int5);
						if (Int3.Angle(int6 - int8, int7 - int8) > MathF.PI * 2f - 2f * num5)
						{
							tris[j + (k + 1) % 3] = tris[value];
							int num6 = value / 3 * 3;
							int num7 = value - num6;
							tris[num6 + (num7 - 1 + 3) % 3] = tris[j + (k + 2) % 3];
							dictionary[new Int2(tris[j], tris[j + 1])] = j + 2;
							dictionary[new Int2(tris[j + 1], tris[j + 2])] = j;
							dictionary[new Int2(tris[j + 2], tris[j])] = j + 1;
							dictionary[new Int2(tris[num6], tris[num6 + 1])] = num6 + 2;
							dictionary[new Int2(tris[num6 + 1], tris[num6 + 2])] = num6;
							dictionary[new Int2(tris[num6 + 2], tris[num6])] = num6 + 1;
						}
					}
				}
			}
		}

		public void ClearTile(int x, int z)
		{
			if (AstarPath.active == null || x < 0 || z < 0 || x >= tileXCount || z >= tileZCount)
			{
				return;
			}
			AstarPath.active.AddWorkItem(new AstarWorkItem(delegate(IWorkItemContext context, bool force)
			{
				graph.ReplaceTile(x, z, new Int3[0], new int[0]);
				activeTileTypes[x + z * tileXCount] = null;
				if (!isBatching)
				{
					context.SetGraphDirty(graph);
				}
				return true;
			}));
		}

		public void ReloadInBounds(Bounds bounds)
		{
			ReloadInBounds(graph.GetTouchingTiles(bounds));
		}

		public void ReloadInBounds(IntRect tiles)
		{
			tiles = IntRect.Intersection(tiles, new IntRect(0, 0, tileXCount - 1, tileZCount - 1));
			if (!tiles.IsValid())
			{
				return;
			}
			for (int i = tiles.ymin; i <= tiles.ymax; i++)
			{
				for (int j = tiles.xmin; j <= tiles.xmax; j++)
				{
					ReloadTile(j, i);
				}
			}
		}

		public void ReloadTile(int x, int z)
		{
			if (x >= 0 && z >= 0 && x < tileXCount && z < tileZCount)
			{
				int num = x + z * tileXCount;
				if (activeTileTypes[num] != null)
				{
					LoadTile(activeTileTypes[num], x, z, activeTileRotations[num], activeTileOffsets[num]);
				}
			}
		}

		public void LoadTile(TileType tile, int x, int z, int rotation, int yoffset)
		{
			if (tile == null)
			{
				throw new ArgumentNullException("tile");
			}
			if (AstarPath.active == null)
			{
				return;
			}
			int index = x + z * tileXCount;
			rotation %= 4;
			if (isBatching && reloadedInBatch[index] && activeTileOffsets[index] == yoffset && activeTileRotations[index] == rotation && activeTileTypes[index] == tile)
			{
				return;
			}
			reloadedInBatch[index] |= isBatching;
			activeTileOffsets[index] = yoffset;
			activeTileRotations[index] = rotation;
			activeTileTypes[index] = tile;
			Int2 originalSize = new Int2(tileXCount, tileZCount);
			AstarPath.active.AddWorkItem(new AstarWorkItem(delegate(IWorkItemContext context, bool force)
			{
				if (activeTileOffsets[index] != yoffset || activeTileRotations[index] != rotation || activeTileTypes[index] != tile)
				{
					return true;
				}
				if (originalSize != new Int2(tileXCount, tileZCount))
				{
					return true;
				}
				context.PreUpdate();
				tile.Load(out var verts, out var tris, out var tags, rotation, yoffset);
				IntRect tiles = new IntRect(x, z, x + tile.Width - 1, z + tile.Depth - 1);
				CuttingResult cuttingResult = CutPoly(verts, tris, tags, null, graph.transform, tiles);
				int tCount = cuttingResult.tris.Length;
				DelaunayRefinement(cuttingResult.verts, cuttingResult.tris, cuttingResult.tags, ref tCount, delaunay: true, colinear: true);
				if (tCount != cuttingResult.tris.Length)
				{
					cuttingResult.tris = Memory.ShrinkArray(cuttingResult.tris, tCount);
					cuttingResult.tags = Memory.ShrinkArray(cuttingResult.tags, tCount / 3);
				}
				int num = ((rotation % 2 == 0) ? tile.Width : tile.Depth);
				int num2 = ((rotation % 2 == 0) ? tile.Depth : tile.Width);
				if (num != 1 || num2 != 1)
				{
					throw new Exception("Only tiles of width = depth = 1 are supported at this time");
				}
				graph.ReplaceTile(x, z, cuttingResult.verts, cuttingResult.tris, cuttingResult.tags);
				return true;
			}));
		}
	}
}
