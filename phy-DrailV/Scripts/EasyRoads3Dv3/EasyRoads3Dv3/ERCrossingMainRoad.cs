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

		public void OCCCCCCDCC()
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
				for (int i = 0; (float)i <= num4; i++)
				{
					if (list3[i].z > num6 + num7 && !flag)
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
					if (list3[i].z > 0f - num6 - num7 && !flag2)
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
						Vector3 value = list3[i];
						value.x -= indent1;
						list3[i] = value;
						Vector2 value2 = list4[i];
						value2.x = x;
						list4[i] = value2;
					}
					if (indent1 > 0f || !flag || (flag && flag2))
					{
						rightOuter1.Add(list3[i]);
						rightOuterUV1.Add(list4[i]);
					}
				}
			}
			if (roadTypeInt3 != 0)
			{
				float num7 = (roadWidth1 - roadWidth3) * 0.5f;
				float num8 = (roadWidth1 - roadWidth3 - 2f * leftInnerStretch) * 0.5f;
				bool flag = false;
				bool flag2 = false;
				float x = indent2 / roadWidth1;
				float num9 = num7 / roadWidth1;
				bottomuvInner3 = num8 / roadWidth1;
				float y = 1f - num9;
				topuvInner3 = 1f - bottomuvInner3;
				innerHeight3 = 0f - num6 - num7 + leftInnerStretch - (num6 + num7 - leftInnerStretch);
				outerHeight3 = 0f - num6 - num7 - (num6 + num7);
				bottom3 = num6 + num7;
				bottom3Inner = num6 + num7 - leftInnerStretch;
				top3 = 0f - num6 - num7;
				top3Inner = 0f - num6 - num7 + leftInnerStretch;
				left3 = -0.5f * roadWidth1;
				right3 = -0.5f * roadWidth1 + indent2;
				int num10 = 0;
				for (int i = 0; (float)i <= num4; i++)
				{
					if (list[i].z > num6 + num7 && !flag)
					{
						leftOuter1.Add(new Vector3(-0.5f * roadWidth1, 0f, num6 + num7));
						if (indent2 > 0f)
						{
							leftOuter1.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, num6 + num7 - leftInnerStretch));
						}
						leftOuterUV1.Add(new Vector2(0f, num9));
						if (indent2 > 0f)
						{
							leftOuterUV1.Add(new Vector2(x, bottomuvInner3));
						}
						if (indent2 > 0f)
						{
							rightOuter3.Add(new Vector3(-0.5f * roadWidth1, 0f, num6 + num7));
						}
						if (indent2 > 0f)
						{
							rightOuter3.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, num6 + num7 - leftInnerStretch));
						}
						flag = true;
					}
					if (list[i].z > 0f - num6 - num7 && !flag2)
					{
						if (indent2 > 0f)
						{
							leftOuter1.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, 0f - num6 - num7 + leftInnerStretch));
						}
						leftOuter1.Add(new Vector3(-0.5f * roadWidth1, 0f, 0f - num6 - num7));
						if (indent2 > 0f)
						{
							leftOuterUV1.Add(new Vector2(x, topuvInner3));
						}
						leftOuterUV1.Add(new Vector2(0f, y));
						if (indent2 > 0f)
						{
							leftOuter3.Add(new Vector3(-0.5f * roadWidth1, 0f, 0f - num6 - num7));
						}
						if (indent2 > 0f)
						{
							leftOuter3.Add(new Vector3(-0.5f * roadWidth1 + indent2, 0f, 0f - num6 - num7 + leftInnerStretch));
						}
						flag2 = true;
					}
					if (flag && !flag2)
					{
						Vector3 value = list[i];
						value.x += indent2;
						list[i] = value;
						Vector2 value2 = list2[i];
						value2.x = x;
						list2[i] = value2;
					}
					if (indent2 > 0f || !flag || (flag && flag2))
					{
						leftOuter1.Add(list[i]);
						leftOuterUV1.Add(list2[i]);
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
			OCQQDQQCQQ.OOCCQOQQQC(mesh);
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
			for (int i = 0; i < edges.Count; i++)
			{
				Vector3 vector = edges[i];
				list.Add(new Vector2(vector.x, vector.z));
			}
			List<TriangleER> list3 = delaunayER.Triangulate(list2);
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			for (int i = 0; i < list3.Count; i++)
			{
				list4.Add(delaunayER.FindVertice(new Vector3(list3[i].Vertex1.x, list3[i].Vertex1.z, list3[i].Vertex1.y), vecs));
				list4.Add(delaunayER.FindVertice(new Vector3(list3[i].Vertex3.x, list3[i].Vertex3.z, list3[i].Vertex3.y), vecs));
				list4.Add(delaunayER.FindVertice(new Vector3(list3[i].Vertex2.x, list3[i].Vertex2.z, list3[i].Vertex2.y), vecs));
			}
			for (int i = 0; i < list4.Count; i += 3)
			{
				if (list.Count == 0)
				{
					list5.Add(list4[i]);
					list5.Add(list4[i + 1]);
					list5.Add(list4[i + 2]);
					continue;
				}
				Vector3 vector2 = (vecs[list4[i]] + vecs[list4[i + 1]] + vecs[list4[i + 2]]) / 3f;
				if (OOCDOQCOCD.OCCOQDODDD(list.Count, list, vector2.x, vector2.z))
				{
					list5.Add(list4[i]);
					list5.Add(list4[i + 1]);
					list5.Add(list4[i + 2]);
				}
			}
			return list5;
		}
	}
}
