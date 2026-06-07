using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompassNavigatorPro
{
	[AddComponentMenu("")]
	public class CompassBarMeshModifier : BaseMeshEffect
	{
		public override void ModifyMesh(VertexHelper vh)
		{
			if (!IsActive() || vh == null || vh.currentVertCount < 1)
			{
				return;
			}
			Mesh mesh = new Mesh();
			vh.FillMesh(mesh);
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			List<Vector2> list3 = new List<Vector2>();
			mesh.GetVertices(list);
			mesh.GetTriangles(list2, 0);
			mesh.GetUVs(0, list3);
			List<Vector3> list4 = new List<Vector3>();
			List<int> list5 = new List<int>();
			List<Vector2> list6 = new List<Vector2>();
			int count = list2.Count;
			int num = 0;
			for (int i = 0; i < count; i += 6)
			{
				int index = list2[i];
				int index2 = list2[i + 1];
				int index3 = list2[i + 2];
				int index4 = list2[i + 4];
				Vector3 item = list[index];
				Vector3 item2 = list[index2];
				Vector3 item3 = list[index3];
				Vector3 item4 = list[index4];
				if (item.x != item4.x && item.y != item2.y)
				{
					Vector2 item5 = list3[index];
					Vector2 item6 = list3[index2];
					Vector2 item7 = list3[index3];
					Vector2 item8 = list3[index4];
					float num2 = item4.x - item.x;
					float num3 = item8.x - item5.x;
					int num4 = (int)(num2 / 50f);
					float num5 = num2 / (float)(num4 + 1);
					float num6 = num3 / (float)(num4 + 1);
					for (int j = 0; j < num4; j++)
					{
						float x = item.x + num5;
						float x2 = item5.x + num6;
						Vector3 vector = new Vector3(x, item2.y, 0f);
						Vector2 vector2 = new Vector2(x2, item6.y);
						Vector3 vector3 = new Vector3(x, item.y, 0f);
						Vector2 vector4 = new Vector2(x2, item5.y);
						list4.Add(item);
						list4.Add(item2);
						list4.Add(vector);
						list4.Add(vector3);
						list6.Add(item5);
						list6.Add(item6);
						list6.Add(vector2);
						list6.Add(vector4);
						list5.Add(num);
						list5.Add(num + 1);
						list5.Add(num + 2);
						list5.Add(num);
						list5.Add(num + 2);
						list5.Add(num + 3);
						num += 4;
						item = vector3;
						item2 = vector;
						item5 = vector4;
						item6 = vector2;
					}
					list4.Add(item);
					list4.Add(item2);
					list4.Add(item3);
					list4.Add(item4);
					list6.Add(item5);
					list6.Add(item6);
					list6.Add(item7);
					list6.Add(item8);
					list5.Add(num);
					list5.Add(num + 1);
					list5.Add(num + 2);
					list5.Add(num);
					list5.Add(num + 2);
					list5.Add(num + 3);
					num += 4;
				}
			}
			int count2 = list4.Count;
			List<UIVertex> list7 = new List<UIVertex>(count2);
			UIVertex vertex = default(UIVertex);
			vh.PopulateUIVertex(ref vertex, 0);
			for (int k = 0; k < count2; k++)
			{
				vertex.position = list4[k];
				vertex.uv0 = list6[k];
				list7.Add(vertex);
			}
			vh.Clear();
			vh.AddUIVertexStream(list7, list5);
		}
	}
}
