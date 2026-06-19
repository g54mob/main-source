using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class HospitalPlotFootprintMesh : MustCallDestroy
	{
		private Mesh _mesh;

		private static float WallHeight = 1f;

		public Mesh Mesh => _mesh;

		public HospitalPlotFootprintMesh(FloorPlan floorPlan)
		{
			int num = floorPlan.Width();
			int num2 = floorPlan.Height();
			bool[,] array = new bool[num, num2];
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (floorPlan[j, i])
					{
						bool flag = i > 0 && floorPlan[j, i - 1];
						bool flag2 = j < num - 1 && floorPlan[j + 1, i];
						bool flag3 = i < num2 - 1 && floorPlan[j, i + 1];
						bool flag4 = j > 0 && floorPlan[j - 1, i];
						array[j, i] = flag && flag2 && flag3 && flag4;
					}
				}
			}
			GridCoord anchor = floorPlan.Anchor;
			List<Vector3> vertices = new List<Vector3>();
			List<Vector3> normals = new List<Vector3>();
			List<int> list = new List<int>();
			for (int k = 0; k < num2; k++)
			{
				for (int l = 0; l < num; l++)
				{
					if (array[l, k])
					{
						bool num3 = k > 0 && array[l, k - 1];
						bool flag5 = l < num - 1 && array[l + 1, k];
						bool flag6 = k < num2 - 1 && array[l, k + 1];
						bool flag7 = l > 0 && array[l - 1, k];
						GridCoord worldPos = new GridCoord(l, k) + anchor;
						if (!num3)
						{
							AddWall(GridDirection.NegY, worldPos, vertices, normals, list, flip: false);
						}
						if (!flag5)
						{
							AddWall(GridDirection.PosX, worldPos, vertices, normals, list, flip: true);
						}
						if (!flag6)
						{
							AddWall(GridDirection.PosY, worldPos, vertices, normals, list, flip: false);
						}
						if (!flag7)
						{
							AddWall(GridDirection.NegX, worldPos, vertices, normals, list, flip: true);
						}
					}
				}
			}
			_mesh = new Mesh();
			_mesh.SetVertices(vertices);
			_mesh.SetTriangles(list, 0);
			_mesh.SetNormals(normals);
		}

		private void AddWall(GridDirection rotation, GridCoord worldPos, List<Vector3> vertices, List<Vector3> normals, List<int> tri, bool flip)
		{
			int count = vertices.Count;
			Vector3 vector = rotation.DirectionVector();
			Vector3 item = rotation.DirectionVector();
			Vector3 vector2 = worldPos.ToWorldPosition() + vector;
			if (flip)
			{
				vector = -vector;
			}
			Vector3 item2 = new Vector3(vector2.x - vector.z, 0f, vector2.z - vector.x);
			Vector3 item3 = new Vector3(vector2.x + vector.z, 0f, vector2.z + vector.x);
			Vector3 item4 = new Vector3(vector2.x - vector.z, WallHeight, vector2.z - vector.x);
			Vector3 item5 = new Vector3(vector2.x + vector.z, WallHeight, vector2.z + vector.x);
			vertices.Add(item2);
			vertices.Add(item3);
			vertices.Add(item4);
			vertices.Add(item5);
			normals.Add(item);
			normals.Add(item);
			normals.Add(item);
			normals.Add(item);
			tri.Add(count);
			tri.Add(count + 1);
			tri.Add(count + 2);
			tri.Add(count + 1);
			tri.Add(count + 3);
			tri.Add(count + 2);
		}

		public override void Destroy()
		{
			Object.Destroy(_mesh);
			_mesh = null;
			base.Destroy();
		}
	}
}
