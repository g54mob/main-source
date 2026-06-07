#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Shapes;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;
using Utils;

namespace Data.Shapes
{
	[CreateAssetMenu(fileName = "ShapeMeshLibrary", menuName = "Factory/Shapes/ShapeMeshLibrary")]
	public class ShapeMeshLibrary : ScriptableObject
	{
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ShapeDataSO[] _defaultShapeDataSO = new ShapeDataSO[0];

		private readonly Dictionary<ShapeHashPair, Mesh> _meshes = new Dictionary<ShapeHashPair, Mesh>();

		private void OnEnable()
		{
			ShapeDataSO[] defaultShapeDataSO = _defaultShapeDataSO;
			foreach (ShapeDataSO shapeDataSO in defaultShapeDataSO)
			{
				if (shapeDataSO.Mesh != null)
				{
					_meshes.TryAdd(shapeDataSO.GetShapeHash(), shapeDataSO.Mesh);
				}
			}
		}

		public Mesh GetOrCreate(in ShapeHashPair shapeHashPair)
		{
			if (!_meshes.TryGetValue(shapeHashPair, out var value))
			{
				value = CreateMesh(in shapeHashPair);
				_meshes.Add(shapeHashPair, value);
			}
			return value;
		}

		public Mesh GetOrCreate(ShapeData shapeData)
		{
			ShapeHashPair shapeHash = shapeData.GetShapeHash();
			if (!_meshes.TryGetValue(shapeHash, out var value))
			{
				value = CreateMesh(Shape.Create(shapeData));
				_meshes.Add(shapeHash, value);
			}
			return value;
		}

		public Mesh GetOrCreate(Shape shape)
		{
			ShapeHashPair shapeHash = shape.GetShapeHash();
			if (!_meshes.TryGetValue(shapeHash, out var value))
			{
				value = CreateMesh(shape);
				_meshes.Add(shapeHash, value);
			}
			return value;
		}

		private Mesh CreateMesh(in ShapeHashPair shapeHashPair)
		{
			if (!_shapesDatabase.TryGetShapeData(shapeHashPair, out var shapeData))
			{
				this.DevException(string.Format("{0} wasn't found in the {1}, add it first before trying to get the a mesh", shapeHashPair, "ShapesDatabase"), "CreateMesh", 68);
				return _meshes.Values.FirstOrDefault();
			}
			return CreateMesh(Shape.Create(shapeData));
		}

		public static Mesh CreateMesh(Shape shape)
		{
			List<Voxel> list = CollectionPool<List<Voxel>, Voxel>.Get();
			for (int i = 0; i < shape.OccupiedVoxels.Count; i++)
			{
				if (IsVoxelExposed(shape.OccupiedVoxels[i].Position, shape.Voxels, shape.GetBounds()))
				{
					list.Add(shape.OccupiedVoxels[i]);
				}
			}
			CombineInstance[] array = new CombineInstance[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				Mesh mesh = new Mesh();
				Color[] array2 = new Color[ShapeMeshData.CUBE_VERTICES.Length];
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = list[j].Color;
				}
				mesh.SetVertices(ShapeMeshData.CUBE_VERTICES);
				mesh.SetTriangles(GetTrianglesForVoxel(shape, list[j]), 0);
				mesh.SetNormals(ShapeMeshData.CUBE_NORMALS);
				mesh.SetUVs(0, GetUVSForVoxel(shape, list[j]));
				mesh.SetUVs(1, ShapeMeshData.CUBE_UVS);
				mesh.SetColors(array2);
				array[j].mesh = mesh;
				array[j].transform = Matrix4x4.Translate((Vector3)list[j].Position * 0.1f + Vector3.one * 0.05f - new Vector3(0.1f * (float)shape.GetBounds().x / 2f, 0f, 0.1f * (float)shape.GetBounds().z / 2f));
			}
			CollectionPool<List<Voxel>, Voxel>.Release(list);
			Mesh mesh2 = new Mesh
			{
				indexFormat = IndexFormat.UInt32
			};
			mesh2.CombineMeshes(array);
			if (ApplicationUtils.IsApplicationPlaying)
			{
				CombineInstance[] array3 = array;
				foreach (CombineInstance combineInstance in array3)
				{
					UnityEngine.Object.DestroyImmediate(combineInstance.mesh);
				}
			}
			return mesh2;
		}

		private static bool IsVoxelExposed(Vector3Int voxelIndex, Voxel[,,] voxels, Vector3Int bounds)
		{
			if (voxelIndex.x == 0 || voxelIndex.y == 0 || voxelIndex.z == 0 || voxelIndex.x == bounds.x - 1 || voxelIndex.y == bounds.y - 1 || voxelIndex.z == bounds.z - 1)
			{
				return true;
			}
			try
			{
				if (!voxels[voxelIndex.x + 1, voxelIndex.y, voxelIndex.z].IsOccupied || !voxels[voxelIndex.x - 1, voxelIndex.y, voxelIndex.z].IsOccupied || !voxels[voxelIndex.x, voxelIndex.y + 1, voxelIndex.z].IsOccupied || !voxels[voxelIndex.x, voxelIndex.y - 1, voxelIndex.z].IsOccupied || !voxels[voxelIndex.x, voxelIndex.y, voxelIndex.z + 1].IsOccupied || !voxels[voxelIndex.x, voxelIndex.y, voxelIndex.z - 1].IsOccupied)
				{
					return true;
				}
			}
			catch (Exception)
			{
				typeof(ShapeMeshLibrary).Log($"{voxels.GetLength(0)}, {voxels.GetLength(1)}, {voxels.GetLength(2)}", "IsVoxelExposed", 156);
				typeof(ShapeMeshLibrary).Log(voxelIndex.ToString(), "IsVoxelExposed", 157);
				typeof(ShapeMeshLibrary).Log(voxels[voxelIndex.x, voxelIndex.y, voxelIndex.z].Position.ToString(), "IsVoxelExposed", 158);
			}
			return false;
		}

		private static List<int> GetTrianglesForVoxel(Shape shape, Voxel voxel)
		{
			List<int> list = new List<int>();
			if (!shape.IsVoxelPosWithinBounds(voxel.Position + new Vector3Int(0, 0, 1), out var voxel2) || !voxel2.IsOccupied)
			{
				int[] cUBE_TRIANGLES_FWD = ShapeMeshData.CUBE_TRIANGLES_FWD;
				foreach (int item in cUBE_TRIANGLES_FWD)
				{
					list.Add(item);
				}
			}
			if (!shape.IsVoxelPosWithinBounds(voxel.Position + new Vector3Int(0, 0, -1), out var voxel3) || !voxel3.IsOccupied)
			{
				int[] cUBE_TRIANGLES_FWD = ShapeMeshData.CUBE_TRIANGLES_BACK;
				foreach (int item2 in cUBE_TRIANGLES_FWD)
				{
					list.Add(item2);
				}
			}
			if (!shape.IsVoxelPosWithinBounds(voxel.Position + new Vector3Int(0, 1, 0), out var voxel4) || !voxel4.IsOccupied)
			{
				int[] cUBE_TRIANGLES_FWD = ShapeMeshData.CUBE_TRIANGLES_UP;
				foreach (int item3 in cUBE_TRIANGLES_FWD)
				{
					list.Add(item3);
				}
			}
			if (!shape.IsVoxelPosWithinBounds(voxel.Position + new Vector3Int(0, -1, 0), out var voxel5) || !voxel5.IsOccupied)
			{
				int[] cUBE_TRIANGLES_FWD = ShapeMeshData.CUBE_TRIANGLES_DOWN;
				foreach (int item4 in cUBE_TRIANGLES_FWD)
				{
					list.Add(item4);
				}
			}
			if (!shape.IsVoxelPosWithinBounds(voxel.Position + new Vector3Int(-1, 0, 0), out var voxel6) || !voxel6.IsOccupied)
			{
				int[] cUBE_TRIANGLES_FWD = ShapeMeshData.CUBE_TRIANGLES_LEFT;
				foreach (int item5 in cUBE_TRIANGLES_FWD)
				{
					list.Add(item5);
				}
			}
			if (!shape.IsVoxelPosWithinBounds(voxel.Position + new Vector3Int(1, 0, 0), out var voxel7) || !voxel7.IsOccupied)
			{
				int[] cUBE_TRIANGLES_FWD = ShapeMeshData.CUBE_TRIANGLES_RIGHT;
				foreach (int item6 in cUBE_TRIANGLES_FWD)
				{
					list.Add(item6);
				}
			}
			return list;
		}

		private static Vector2[] GetUVSForVoxel(Shape shape, Voxel voxel)
		{
			bool flag = shape.IsLastVoxelInLine(voxel, Shape.Direction.Left);
			bool flag2 = shape.IsLastVoxelInLine(voxel, Shape.Direction.Right);
			bool num = shape.IsLastVoxelInLine(voxel, Shape.Direction.Backward);
			bool flag3 = shape.IsLastVoxelInLine(voxel, Shape.Direction.Forward);
			bool num2 = shape.IsLastVoxelInLine(voxel, Shape.Direction.Up);
			bool flag4 = shape.IsLastVoxelInLine(voxel, Shape.Direction.Down);
			float x = (flag ? 0f : 0.5f);
			float x2 = (flag2 ? 1f : 0.5f);
			float num3 = (num2 ? 1f : 0.5f);
			float num4 = (flag4 ? 0f : 0.5f);
			float y = (num ? 0f : 0.5f);
			float y2 = (flag3 ? 1f : 0.5f);
			return new Vector2[24]
			{
				new Vector2(x2, num4),
				new Vector2(x, num4),
				new Vector2(x2, num3),
				new Vector2(x, num3),
				new Vector2(x2, num3),
				new Vector2(x, num3),
				new Vector2(x2, num4),
				new Vector2(x, num4),
				new Vector2(x2, y2),
				new Vector2(x, y2),
				new Vector2(x2, y),
				new Vector2(x, y),
				new Vector2(x2, y),
				new Vector2(x2, y2),
				new Vector2(x, y2),
				new Vector2(x, y),
				new Vector2(num4, y2),
				new Vector2(num3, y2),
				new Vector2(num3, y),
				new Vector2(num4, y),
				new Vector2(num4, y),
				new Vector2(num3, y),
				new Vector2(num3, y2),
				new Vector2(num4, y2)
			};
		}
	}
}
