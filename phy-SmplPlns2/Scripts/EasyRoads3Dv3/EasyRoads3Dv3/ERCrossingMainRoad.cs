using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERCrossingMainRoad : MonoBehaviour
	{
		public ERModularBase baseScript;

		public double roadType1;

		public int roadTypeInt1 = 0;

		public double roadType2;

		public int roadTypeInt2 = 0;

		public double roadType3;

		public int roadTypeInt3 = 0;

		public float indent1 = 0f;

		public float indent2 = 0f;

		public float roadWidth1 = 8f;

		public float roadWidth2 = 6f;

		public float roadWidth3 = 5f;

		public bool tCrossing = true;

		public List<Vector3> leftOuter1 = new List<Vector3>();

		public List<Vector3> rightOuter1 = new List<Vector3>();

		public List<Vector2> leftOuterUV1 = new List<Vector2>();

		public List<Vector2> rightOuterUV1 = new List<Vector2>();

		public List<Vector3> leftOuter2 = new List<Vector3>();

		public List<Vector3> rightOuter2 = new List<Vector3>();

		public List<Vector2> leftOuterUV2 = new List<Vector2>();

		public List<Vector2> rightOuterUV2 = new List<Vector2>();

		public List<Vector3> leftOuter3 = new List<Vector3>();

		public List<Vector3> rightOuter3 = new List<Vector3>();

		public List<Vector2> leftOuterUV3 = new List<Vector2>();

		public List<Vector2> rightOuterUV3 = new List<Vector2>();

		public Material sourceMaterial;

		public Material sourceMaterial1;

		public Material targetMaterial;

		public float bottom2 = 0f;

		public float bottom2Inner = 0f;

		public float bottom3 = 0f;

		public float bottom3Inner = 0f;

		public float top2 = 0f;

		public float top2Inner = 0f;

		public float top3 = 0f;

		public float top3Inner = 0f;

		public float left2 = 0f;

		public float left3 = 0f;

		public float right2 = 0f;

		public float right3 = 0f;

		public int vec2Count = 0;

		public int vec3Count = 0;

		public float uvStart1 = 0f;

		public float uvEnd1 = 0f;

		public float uvStart2 = 0f;

		public float uvEnd2 = 0f;

		public Vector2 rightTopL;

		public Vector2 rightTopR;

		public Vector2 rightBottomL;

		public Vector2 rightBottomR;

		public Vector2 leftTopL;

		public Vector2 leftTopR;

		public Vector2 leftBottomL;

		public Vector2 leftBottomR;

		public float rightLeftUV;

		public float rightRightUV;

		public float leftLeftUV;

		public float leftRightUV;

		public float bottomuvInner2 = 0f;

		public float topuvInner2 = 0f;

		public float innerHeight2 = 0f;

		public float outerHeight2 = 0f;

		public float bottomuvInner3 = 0f;

		public float topuvInner3 = 0f;

		public float innerHeight3 = 0f;

		public float outerHeight3 = 0f;

		public float rightInnerStretch = 0.25f;

		public float leftInnerStretch = 0.25f;

		public Material mat1;

		public Material mat2;

		public Material mat3;

		public new string name = "";

		public void ODDDQDQOOD()
		{
			Clear();
			if (roadTypeInt1 > 0)
			{
				roadType1 = baseScript.roadTypes[roadTypeInt1 - 1].id;
			}
			if (roadTypeInt2 > 0)
			{
				roadType2 = baseScript.roadTypes[roadTypeInt2 - 1].id;
			}
			if (roadTypeInt3 > 0)
			{
				roadType3 = baseScript.roadTypes[roadTypeInt3 - 1].id;
			}
			if (roadTypeInt1 == 0)
			{
				return;
			}
			mat1 = (mat2 = (mat3 = null));
			if (roadTypeInt1 > 0)
			{
				mat1 = baseScript.roadTypes[roadTypeInt1 - 1].roadMaterial;
			}
			if (roadTypeInt2 > 0)
			{
				mat2 = baseScript.roadTypes[roadTypeInt2 - 1].roadMaterial;
			}
			if (roadTypeInt3 > 0)
			{
				mat3 = baseScript.roadTypes[roadTypeInt3 - 1].roadMaterial;
			}
			if (roadTypeInt1 > 0)
			{
				roadWidth1 = baseScript.roadTypes[roadTypeInt1 - 1].roadWidth;
			}
			if (roadTypeInt2 > 0)
			{
				roadWidth2 = baseScript.roadTypes[roadTypeInt2 - 1].roadWidth;
			}
			if (roadTypeInt3 > 0)
			{
				roadWidth3 = baseScript.roadTypes[roadTypeInt3 - 1].roadWidth;
			}
			float faceDistance = baseScript.roadTypes[roadTypeInt1 - 1].faceDistance;
			float num = 1f;
			float num2 = 1f;
			float num3 = 1f;
			if (base.gameObject.GetComponent<MeshFilter>() == null)
			{
				base.gameObject.AddComponent<MeshFilter>();
			}
			if (base.gameObject.GetComponent<MeshRenderer>() == null)
			{
				base.gameObject.AddComponent<MeshRenderer>();
			}
			float num4 = Mathf.Ceil(roadWidth1 / faceDistance);
			float num5 = roadWidth1 / num4;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector2> list4 = new List<Vector2>();
			float num6 = -0.5f * roadWidth1;
			for (int i = 0; (float)i <= num4; i++)
			{
				list.Add(new Vector3(-0.5f * roadWidth1, 0f, num6 + (float)i * num5));
				list2.Add(new Vector2(0f, (float)i / num4));
				list3.Add(new Vector3(0.5f * roadWidth1, 0f, num6 + (float)i * num5));
				list4.Add(new Vector2(1f, (float)i / num4));
			}
			if (roadTypeInt2 != 0)
			{
				float num7 = (roadWidth1 - roadWidth2) * 0.5f;
				float num8 = (roadWidth1 - roadWidth2 - 2f * rightInnerStretch) * 0.5f;
				bool flag = false;
				bool flag2 = false;
				float x = 1f - indent1 / roadWidth1;
				float num9 = num7 / roadWidth1;
				bottomuvInner2 = num8 / roadWidth1;
				float y = 1f - num9;
				topuvInner2 = 1f - bottomuvInner2;
				innerHeight2 = 0f - num6 - num7 + rightInnerStretch - (num6 + num7 - rightInnerStretch);
				outerHeight2 = 0f - num6 - num7 - (num6 + num7);
				bottom2 = num6 + num7;
				bottom2Inner = num6 + num7 - rightInnerStretch;
				top2 = 0f - num6 - num7;
				top2Inner = 0f - num6 - num7 + rightInnerStretch;
				left2 = 0.5f * roadWidth1 - indent1;
				right2 = 0.5f * roadWidth1;
				int num10 = 0;
				for (int j = 0; (float)j <= num4; j++)
				{
					if (list3[j].z > num6 + num7 && !flag)
					{
						rightOuter1.Add(new Vector3(0.5f * roadWidth1, 0f, num6 + num7));
						if (indent1 > 0f)
						{
							rightOuter1.Add(new Vector3(0.5f * roadWidth1 - indent1, 0f, num6 + num7 - rightInnerStretch));
						}
						rightOuterUV1.Add(new Vector2(1f, num9));
						if (indent1 > 0f)
						{
							rightOuterUV1.Add(new Vector2(x, bottomuvInner2));
						}
						if (indent1 > 0f)
						{
							leftOuter2.Add(new Vector3(0.5f * roadWidth1, 0f, num6 + num7));
						}
						if (indent1 > 0f)
						{
							leftOuter2.Add(new Vector3(0.5f * roadWidth1 - indent1, 0f, num6 + num7 - rightInnerStretch));
						}
						flag = true;
					}
					if (list3[j].z > 0f - num6 - num7 && !flag2)
					{
						if (indent1 > 0f)
						{
							rightOuter1.Add(new Vector3(0.5f * roadWidth1 - indent1, 0f, 0f - num6 - num7 + rightInnerStretch));
						}
						rightOuter1.Add(new Vector3(0.5f * roadWidth1, 0f, 0f - num6 - num7));
						if (indent1 > 0f)
						{
							rightOuterUV1.Add(new Vector2(x, topuvInner2));
						}
						rightOuterUV1.Add(new Vector2(1f, y));
						if (indent1 > 0f)
						{
							rightOuter2.Add(new Vector3(0.5f * roadWidth1, 0f, 0f - num6 - num7));
						}
						if (indent1 > 0f)
						{
							rightOuter2.Add(new Vector3(0.5f * roadWidth1 - indent1, 0f, 0f - num6 - num7 + rightInnerStretch));
						}
						flag2 = true;
					}
					if (flag && !flag2)
					{
						Vector3 value = list3[j];
						value.x -= indent1;
						list3[j] = value;
						Vector2 value2 = list4[j];
						value2.x = x;
						list4[j] = value2;
					}
					if (indent1 > 0f || !flag || (flag && flag2))
					{
						rightOuter1.Add(list3[j]);
						rightOuterUV1.Add(list4[j]);
					}
				}
			}
			if (roadTypeInt3 != 0)
			{
				float num11 = (roadWidth1 - roadWidth3) * 0.5f;
				float num12 = (roadWidth1 - roadWidth3 - 2f * leftInnerStretch) * 0.5f;
				bool flag3 = false;
				bool flag4 = false;
				float x2 = indent2 / roadWidth1;
				float num13 = num11 / roadWidth1;
				bottomuvInner3 = num12 / roadWidth1;
				float y2 = 1f - num13;
				topuvInner3 = 1f - bottomuvInner3;
				innerHeight3 = 0f - num6 - num11 + leftInnerStretch - (num6 + num11 - leftInnerStretch);
				outerHeight3 = 0f - num6 - num11 - (num6 + num11);
				bottom3 = num6 + num11;
				bottom3Inner = num6 + num11 - leftInnerStretch;
				top3 = 0f - num6 - num11;
				top3Inner = 0f - num6 - num11 + leftInnerStretch;
				left3 = -0.5f * roadWidth1;
				right3 = -0.5f * roadWidth1 + indent2;
				int num14 = 0;
				for (int k = 0; (float)k <= num4; k++)
				{
					if (list[k].z > num6 + num11 && !flag3)
					{
						leftOuter1.Add(new Vector3(-0.5f * roadWidth1, 0f, num6 + num11));
						if (indent2 > 0f)
						{
							leftOuter1.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, num6 + num11 - leftInnerStretch));
						}
						leftOuterUV1.Add(new Vector2(0f, num13));
						if (indent2 > 0f)
						{
							leftOuterUV1.Add(new Vector2(x2, bottomuvInner3));
						}
						if (indent2 > 0f)
						{
							rightOuter3.Add(new Vector3(-0.5f * roadWidth1, 0f, num6 + num11));
						}
						if (indent2 > 0f)
						{
							rightOuter3.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, num6 + num11 - leftInnerStretch));
						}
						flag3 = true;
					}
					if (list[k].z > 0f - num6 - num11 && !flag4)
					{
						if (indent2 > 0f)
						{
							leftOuter1.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, 0f - num6 - num11 + leftInnerStretch));
						}
						leftOuter1.Add(new Vector3(-0.5f * roadWidth1, 0f, 0f - num6 - num11));
						if (indent2 > 0f)
						{
							leftOuterUV1.Add(new Vector2(x2, topuvInner3));
						}
						leftOuterUV1.Add(new Vector2(0f, y2));
						if (indent2 > 0f)
						{
							leftOuter3.Add(new Vector3(-0.5f * roadWidth1, 0f, 0f - num6 - num11));
						}
						if (indent2 > 0f)
						{
							leftOuter3.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, 0f - num6 - num11 + leftInnerStretch));
						}
						flag4 = true;
					}
					if (flag3 && !flag4)
					{
						Vector3 value3 = list[k];
						value3.x += indent2;
						list[k] = value3;
						Vector2 value4 = list2[k];
						value4.x = x2;
						list2[k] = value4;
					}
					if (indent2 > 0f || !flag3 || (flag3 && flag4))
					{
						leftOuter1.Add(list[k]);
						leftOuterUV1.Add(list2[k]);
					}
				}
			}
			if (roadTypeInt2 == 0)
			{
				rightOuter1 = new List<Vector3>(list3);
				rightOuterUV1 = new List<Vector2>(list4);
			}
			if (roadTypeInt3 == 0)
			{
				leftOuter1 = new List<Vector3>(list);
				leftOuterUV1 = new List<Vector2>(list2);
			}
			List<Vector3> list5 = new List<Vector3>();
			list5.AddRange(leftOuter1);
			list5.Reverse();
			list5.AddRange(rightOuter1);
			List<Vector2> list6 = new List<Vector2>();
			list6.AddRange(leftOuterUV1);
			list6.Reverse();
			list6.AddRange(rightOuterUV1);
			List<int> list7 = Triangulate(list5, list5);
			List<int> list8 = new List<int>();
			List<int> list9 = new List<int>();
			vec2Count = 0;
			vec3Count = 0;
			vec2Count = list5.Count;
			if (indent1 > 0f && roadTypeInt2 != 0)
			{
				leftOuterUV2.Add(new Vector2(0f, 1f));
				leftOuterUV2.Add(new Vector2(0f, 1f + indent1 / roadWidth2));
				rightOuterUV2.Add(new Vector2(1f, 1f));
				rightOuterUV2.Add(new Vector2(1f, 1f + indent1 / roadWidth2));
				list5.AddRange(leftOuter2);
				list5.AddRange(rightOuter2);
				list6.AddRange(leftOuterUV2);
				list6.AddRange(rightOuterUV2);
				list8.Add(vec2Count);
				list8.Add(vec2Count + 1);
				list8.Add(vec2Count + 3);
				list8.Add(vec2Count);
				list8.Add(vec2Count + 3);
				list8.Add(vec2Count + 2);
			}
			vec3Count = list5.Count;
			if (indent2 > 0f)
			{
				leftOuterUV3.Add(new Vector2(0f, 1f));
				leftOuterUV3.Add(new Vector2(0f, 1f + indent2 / roadWidth3));
				rightOuterUV3.Add(new Vector2(1f, 1f));
				rightOuterUV3.Add(new Vector2(1f, 1f + indent2 / roadWidth3));
				list5.AddRange(leftOuter3);
				list5.AddRange(rightOuter3);
				list6.AddRange(leftOuterUV3);
				list6.AddRange(rightOuterUV3);
				list9.Add(vec3Count);
				list9.Add(vec3Count + 1);
				list9.Add(vec3Count + 3);
				list9.Add(vec3Count);
				list9.Add(vec3Count + 3);
				list9.Add(vec3Count + 2);
			}
			Mesh mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			if (mesh == null)
			{
				mesh = new Mesh();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			mesh.Clear();
			if (indent2 > 0f && indent1 > 0f && roadTypeInt2 != 0 && roadTypeInt3 != 0)
			{
				mesh.subMeshCount = 3;
			}
			else if (indent2 > 0f && roadTypeInt3 != 0)
			{
				mesh.subMeshCount = 2;
			}
			else if (indent1 > 0f && roadTypeInt2 != 0)
			{
				mesh.subMeshCount = 2;
			}
			else
			{
				mesh.subMeshCount = 1;
			}
			mesh.vertices = list5.ToArray();
			mesh.uv = list6.ToArray();
			mesh.SetTriangles(list7.ToArray(), 0);
			if (indent1 > 0f && roadTypeInt2 != 0)
			{
				mesh.SetTriangles(list8.ToArray(), 1);
			}
			if (indent2 > 0f && indent1 > 0f && roadTypeInt2 != 0 && roadTypeInt3 != 0)
			{
				mesh.SetTriangles(list9.ToArray(), 2);
			}
			else if (indent2 > 0f && roadTypeInt3 != 0)
			{
				mesh.SetTriangles(list9.ToArray(), 1);
			}
			List<Material> list10 = new List<Material>();
			list10.Add(mat1);
			if (indent1 > 0f && roadTypeInt2 != 0)
			{
				list10.Add(targetMaterial);
			}
			if (indent2 > 0f && roadTypeInt3 != 0)
			{
				list10.Add(targetMaterial);
			}
			base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = list10.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
		}

		public void Clear()
		{
			leftOuter1.Clear();
			rightOuter1.Clear();
			leftOuterUV1.Clear();
			rightOuterUV1.Clear();
			leftOuter2.Clear();
			rightOuter2.Clear();
			leftOuterUV2.Clear();
			rightOuterUV2.Clear();
			leftOuter3.Clear();
			rightOuter3.Clear();
			leftOuterUV3.Clear();
			rightOuterUV3.Clear();
		}

		private List<int> Triangulate(List<Vector3> vecs, List<Vector3> edges)
		{
			List<Vector2> list = new List<Vector2>();
			List<PointER> list2 = new List<PointER>();
			for (int i = 0; i < vecs.Count; i++)
			{
				Vector3 vector = vecs[i];
				list2.Add(new PointER(vector.x, vector.z, 0f));
			}
			for (int j = 0; j < edges.Count; j++)
			{
				Vector3 vector = edges[j];
				list.Add(new Vector2(vector.x, vector.z));
			}
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<TriangleER> list5 = delaunayER.Triangulate(list2);
			for (int k = 0; k < list5.Count; k++)
			{
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex1.x, list5[k].Vertex1.z, list5[k].Vertex1.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex3.x, list5[k].Vertex3.z, list5[k].Vertex3.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex2.x, list5[k].Vertex2.z, list5[k].Vertex2.y), vecs));
			}
			for (int l = 0; l < list3.Count; l += 3)
			{
				if (list.Count == 0)
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
					continue;
				}
				Vector3 vector2 = (vecs[list3[l]] + vecs[list3[l + 1]] + vecs[list3[l + 2]]) / 3f;
				if (OQOQOOCDCC.OCDCDOCQCQ(list.Count, list, vector2.x, vector2.z))
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
				}
			}
			return list4;
		}
	}
}
