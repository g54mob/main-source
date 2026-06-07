using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OCDDOODQDQ : MonoBehaviour
	{
		public static void ODDDOQCCCD(ERCrossingPrefabs scr, Vector3[] meshVecs, ref Vector3[] surfaceMeshVecs)
		{
			scr.surfaceSurroundingInts.Clear();
			List<bool> list = new List<bool>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			List<Vector3> list4 = new List<Vector3>();
			List<Vector2> list5 = new List<Vector2>();
			List<Vector3> list6 = new List<Vector3>();
			List<int> list7 = new List<int>();
			list4.Add(Vector3.zero);
			list5.Add(new Vector2(0f, 1f));
			if (scr.baseScript == null)
			{
				if (scr.transform.parent == null || scr.transform.parent.parent == null)
				{
					return;
				}
				if ((bool)scr.transform.parent.parent.gameObject.GetComponent<ERModularBase>())
				{
					scr.baseScript = scr.transform.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
				else if (scr.baseScript == null)
				{
					scr.baseScript = scr.transform.parent.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
			}
			for (int i = 0; i < scr.roundaboutScript.connections.Count; i++)
			{
				if (i == 0)
				{
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftIndent = list4.Count;
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftIndentV3 = scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftIndentvecs[0];
					if (scr.crossingElements[i].triangulateRight)
					{
						list4.AddRange(scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftIndentvecs);
						for (int j = 0; j < scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftIndentvecs.Count; j++)
						{
							list5.Add(new Vector2(0f, 1f));
						}
					}
					else
					{
						QDOODOQQDQODD.SetLeftInnerIndentPoints(scr.roundaboutScript.connections.Count - 1, scr);
						list4.AddRange(scr.crossingElements[scr.crossingElements.Count - 1].leftInnerIndentPoints);
						for (int k = 0; k < scr.crossingElements[scr.crossingElements.Count - 1].leftInnerIndentPoints.Count; k++)
						{
							list5.Add(new Vector2(0f, 1f));
						}
					}
				}
				else
				{
					scr.crossingElements[i - 1].leftIndent = list4.Count;
					scr.crossingElements[i - 1].leftIndentV3 = scr.roundaboutScript.connections[i - 1].leftIndentvecs[0];
					if (scr.crossingElements[i].triangulateRight)
					{
						list4.AddRange(scr.roundaboutScript.connections[i - 1].leftIndentvecs);
						for (int l = 0; l < scr.roundaboutScript.connections[i - 1].leftIndentvecs.Count; l++)
						{
							list5.Add(new Vector2(0f, 1f));
						}
					}
					else
					{
						QDOODOQQDQODD.SetLeftInnerIndentPoints(i - 1, scr);
						list4.AddRange(scr.crossingElements[i - 1].leftInnerIndentPoints);
						for (int m = 0; m < scr.crossingElements[i - 1].leftInnerIndentPoints.Count; m++)
						{
							list5.Add(new Vector2(0f, 1f));
						}
					}
				}
				list2.Add(list4.Count - 1);
				list6.Clear();
				if (scr.crossingElements[i].triangulateRight)
				{
					list6.AddRange(scr.roundaboutScript.connections[i].rightIndentvecs);
				}
				else
				{
					QDOODOQQDQODD.SetRightInnerIndentPoints(i, scr);
					list6.AddRange(scr.crossingElements[i].rightInnerIndentPoints);
				}
				list6.Reverse();
				list4.AddRange(list6);
				for (int n = 0; n < list6.Count; n++)
				{
					list5.Add(new Vector2(0f, 1f));
				}
				scr.crossingElements[i].rightIndent = list4.Count - 1;
				scr.crossingElements[i].rightIndentV3 = list4[list4.Count - 1];
			}
			int num = 0;
			int num2 = 1;
			for (int num3 = 1; num3 < list4.Count - 1; num3++)
			{
				list3.Add(0);
				list3.Add(num3);
				list3.Add(num3 + 1);
			}
			list3.Add(0);
			list3.Add(list4.Count - 1);
			list3.Add(1);
			int num4 = 1;
			int num5 = 0;
			for (int num6 = 0; num6 < scr.roundaboutScript.connections.Count; num6++)
			{
				num5 = list4.Count;
				if (num6 == 0)
				{
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftSurrounding = list4.Count;
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftSurroundingV3 = scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftSurroundingvecs[0];
					list4.AddRange(scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftSurroundingvecs);
					for (int num7 = 0; num7 < scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftSurroundingvecs.Count; num7++)
					{
						list5.Add(new Vector2(0f, 0f));
					}
				}
				else
				{
					scr.crossingElements[num6 - 1].leftSurrounding = list4.Count;
					scr.crossingElements[num6 - 1].leftSurroundingV3 = scr.roundaboutScript.connections[num6 - 1].leftSurroundingvecs[0];
					list4.AddRange(scr.roundaboutScript.connections[num6 - 1].leftSurroundingvecs);
					for (int num8 = 0; num8 < scr.roundaboutScript.connections[num6 - 1].leftSurroundingvecs.Count; num8++)
					{
						list5.Add(new Vector2(0f, 0f));
					}
				}
				list6.Clear();
				list6.AddRange(scr.roundaboutScript.connections[num6].rightSurroundingvecs);
				list6.Reverse();
				list4.AddRange(list6);
				for (int num9 = 0; num9 < list6.Count; num9++)
				{
					list5.Add(new Vector2(0f, 0f));
				}
				scr.crossingElements[num6].rightSurrounding = list4.Count - 1;
				scr.crossingElements[num6].rightSurroundingV3 = list4[list4.Count - 1];
				int num10 = list4.Count - num5;
				for (int num11 = 0; num11 < num10; num11++)
				{
					scr.surfaceSurroundingInts.Add(num5 + num11);
				}
				for (int num12 = 0; num12 < num10 - 1; num12++)
				{
					if (scr.crossingElements[num6].triangulateRight)
					{
						list3.Add(num4 + num12);
						list3.Add(num5 + num12);
						list3.Add(num4 + num12 + 1);
						list3.Add(num4 + num12 + 1);
						list3.Add(num5 + num12);
						list3.Add(num5 + num12 + 1);
					}
				}
				num4 += num10;
			}
			scr.surfaceMeshVecs = list4.ToArray();
			if (scr.surfaceObject == null)
			{
				if ((bool)scr.transform.Find("surface"))
				{
					scr.surfaceObject = scr.transform.Find("surface").gameObject;
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
				}
				else
				{
					scr.surfaceObject = new GameObject("surface");
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
					scr.surfaceObject.transform.position = scr.transform.position;
					scr.surfaceObject.transform.rotation = scr.transform.rotation;
					scr.surfaceObject.transform.parent = scr.transform;
					if (scr.baseScript != null)
					{
						scr.surfaceObject.layer = scr.baseScript.sLayer;
					}
					scr.surfaceObject.AddComponent<ERSurfaceScript>();
				}
			}
			if (scr.surfaceObject.GetComponent<MeshFilter>() == null)
			{
				scr.surfaceObject.AddComponent<MeshFilter>();
			}
			if (scr.surfaceObject.GetComponent<MeshRenderer>() == null)
			{
				scr.surfaceObject.AddComponent<MeshRenderer>();
				scr.surfaceObject.GetComponent<MeshRenderer>().sharedMaterial = scr.baseScript.surfaceMaterial;
			}
			if (scr.surfaceObject.GetComponent<MeshCollider>() == null)
			{
				scr.surfaceObject.AddComponent<MeshCollider>();
			}
			if (scr.surfaceObject.GetComponent<ERSurfaceScript>() == null)
			{
				scr.surfaceObject.AddComponent<ERSurfaceScript>();
			}
			Mesh mesh;
			if (scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				mesh.name = "surface";
				scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			if (scr.baseScript != null)
			{
				scr.surfaceObject.layer = scr.baseScript.sLayer;
			}
			mesh.Clear();
			if (scr.roundaboutScript.connections.Count != 0)
			{
				mesh.vertices = scr.surfaceMeshVecs;
				mesh.uv = list5.ToArray();
				mesh.tangents = new Vector4[scr.surfaceMeshVecs.Length];
				mesh.triangles = list3.ToArray();
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = null;
				scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = mesh;
				if (scr.baseScript != null && scr.baseScript.hideSurfaces)
				{
					scr.surfaceObject.GetComponent<MeshRenderer>().enabled = false;
					scr.surfaceObject.GetComponent<MeshCollider>().enabled = false;
					scr.surfaceObject.SetActive(value: false);
					scr.surfaceObject.SetActive(value: true);
				}
				scr.tmpSurfaceMeshVecs = new Vector3[scr.surfaceMeshVecs.Length];
				Array.Copy(scr.surfaceMeshVecs, scr.tmpSurfaceMeshVecs, scr.surfaceMeshVecs.Length);
			}
		}

		public static void UpdateYCrossingSurfaces(ERCrossingPrefabs scr, Vector3[] meshVecs, List<ERConnectionSibling> siblings, ref Vector3[] surfaceMeshVecs)
		{
			scr.surfaceSurroundingInts.Clear();
			List<int> list = new List<int>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector3> list4 = new List<Vector3>();
			List<int> list5 = new List<int>();
			List<bool> list6 = new List<bool>();
			bool[] array = new bool[siblings.Count * 2];
			List<int> list7 = new List<int>();
			list2.Add(Vector3.zero);
			list3.Add(new Vector2(0f, 1f));
			for (int i = 0; i < siblings.Count; i++)
			{
				if (siblings[i].roadType == null)
				{
					if (siblings[i].rightSidewalkGO != null)
					{
						UnityEngine.Object.DestroyImmediate(siblings[i].rightSidewalkGO);
					}
					if (siblings[i].leftSidewalkGO != null)
					{
						UnityEngine.Object.DestroyImmediate(siblings[i].leftSidewalkGO);
					}
					siblings.RemoveAt(i);
					i--;
				}
			}
			bool flag = true;
			bool flag2 = true;
			List<bool> list8 = new List<bool>();
			int num = 0;
			int num2 = 0;
			bool flag3 = false;
			bool flag4 = false;
			for (int j = 0; j < siblings.Count; j++)
			{
				flag4 = siblings[j].bridgeSection;
				list7.Add(list2.Count - 1);
				if (siblings[j].bridgeSection)
				{
					num2 = QDOODOQQDQODD.GetConnectionIndex(scr, siblings[j]);
				}
				if (j == 0)
				{
					siblings[siblings.Count - 1].leftIndent = list2.Count;
					flag3 = siblings[siblings.Count - 1].bridgeSection;
					if (siblings[siblings.Count - 1].leftIndentvecs.Count > 0)
					{
						siblings[siblings.Count - 1].leftIndentV3 = siblings[siblings.Count - 1].leftIndentvecs[0];
					}
					num = QDOODOQQDQODD.GetConnectionIndex(scr, siblings[siblings.Count - 1]);
					flag = scr.crossingElements[num].triangulateLeft;
					if (scr.crossingElements[num].triangulateLeft)
					{
						list2.AddRange(siblings[siblings.Count - 1].leftIndentvecs);
					}
					else
					{
						QDOODOQQDQODD.SetLeftInnerIndentPoints(num, scr);
						list2.AddRange(scr.crossingElements[num].leftInnerIndentPoints);
					}
					for (int k = 0; k < siblings[siblings.Count - 1].leftIndentvecs.Count; k++)
					{
						list3.Add(new Vector2(0f, 1f));
					}
				}
				else
				{
					siblings[j - 1].leftIndent = list2.Count;
					flag3 = siblings[j - 1].bridgeSection;
					if (siblings[j - 1].leftIndentvecs.Count > 0)
					{
						siblings[j - 1].leftIndentV3 = siblings[j - 1].leftIndentvecs[0];
					}
					num = QDOODOQQDQODD.GetConnectionIndex(scr, siblings[j - 1]);
					flag = scr.crossingElements[num].triangulateLeft;
					if (scr.crossingElements[num].triangulateLeft)
					{
						list2.AddRange(siblings[j - 1].leftIndentvecs);
					}
					else
					{
						QDOODOQQDQODD.SetLeftInnerIndentPoints(num, scr);
						list2.AddRange(scr.crossingElements[num].leftInnerIndentPoints);
					}
					for (int l = 0; l < siblings[j - 1].leftIndentvecs.Count; l++)
					{
						list3.Add(new Vector2(0f, 1f));
					}
				}
				list6.Add(item: true);
				if (flag3 && flag4)
				{
					array[j * 2] = true;
				}
				list8.Add(flag);
				list7.Add(list2.Count - 1);
				int connectionIndex = QDOODOQQDQODD.GetConnectionIndex(scr, siblings[j]);
				flag2 = scr.crossingElements[connectionIndex].triangulateRight;
				list6.Add(item: true);
				if (flag3 && flag4)
				{
					array[j * 2 + 1] = true;
				}
				list4.Clear();
				if (scr.crossingElements[connectionIndex].triangulateRight)
				{
					list4.AddRange(siblings[j].rightIndentvecs);
				}
				else
				{
					QDOODOQQDQODD.SetRightInnerIndentPoints(connectionIndex, scr);
					list4.AddRange(scr.crossingElements[connectionIndex].rightInnerIndentPoints);
				}
				list4.Reverse();
				list2.AddRange(list4);
				for (int m = 0; m < list4.Count; m++)
				{
					list3.Add(new Vector2(0f, 1f));
				}
				list2.Add(Vector3.Lerp(siblings[j].leftIndentV3, siblings[j].rightIndentV3, 0.5f));
				list3.Add(new Vector2(0f, 1f));
				siblings[j].rightIndent = list2.Count - 2;
				siblings[j].rightIndentV3 = list2[list2.Count - 2];
			}
			int num3 = 0;
			int num4 = 1;
			for (int n = 1; n < list2.Count - 1; n++)
			{
				if (n == list7[num4] && num4 + 1 < list7.Count)
				{
					num3++;
					num4++;
				}
				if (list6[num3] && !array[num3])
				{
					list.Add(0);
					list.Add(n);
					list.Add(n + 1);
				}
			}
			if (list6[0] && !array[0])
			{
				list.Add(0);
				list.Add(list2.Count - 1);
				list.Add(1);
			}
			int num5 = 1;
			int num6 = 0;
			int count = list2.Count;
			int num7 = 0;
			for (int num8 = 0; num8 < siblings.Count; num8++)
			{
				num6 = list2.Count;
				if (num8 == 0)
				{
					siblings[siblings.Count - 1].leftSurrounding = list2.Count;
					if (siblings[siblings.Count - 1].leftSurroundingvecs.Count > 0)
					{
						siblings[siblings.Count - 1].leftSurroundingV3 = siblings[siblings.Count - 1].leftSurroundingvecs[0];
					}
					list2.AddRange(siblings[siblings.Count - 1].leftSurroundingvecs);
					for (int num9 = 0; num9 < siblings[siblings.Count - 1].leftSurroundingvecs.Count; num9++)
					{
						list3.Add(new Vector2(0f, 0f));
					}
				}
				else
				{
					siblings[num8 - 1].leftSurrounding = list2.Count;
					if (siblings[num8 - 1].leftSurroundingvecs.Count > 0)
					{
						siblings[num8 - 1].leftSurroundingV3 = siblings[num8 - 1].leftSurroundingvecs[0];
					}
					list2.AddRange(siblings[num8 - 1].leftSurroundingvecs);
					for (int num10 = 0; num10 < siblings[num8 - 1].leftSurroundingvecs.Count; num10++)
					{
						list3.Add(new Vector2(0f, 0f));
					}
				}
				list4.Clear();
				list4.AddRange(siblings[num8].rightSurroundingvecs);
				list4.Reverse();
				list2.AddRange(list4);
				for (int num11 = 0; num11 < list4.Count; num11++)
				{
					list3.Add(new Vector2(0f, 0f));
				}
				siblings[num8].rightSurrounding = list2.Count - 1;
				siblings[num8].rightSurroundingV3 = list2[list2.Count - 1];
				int num12 = list2.Count - num6;
				for (int num13 = 0; num13 < num12; num13++)
				{
					scr.surfaceSurroundingInts.Add(num6 + num13);
					Vector3 pos = scr.transform.TransformPoint(list2[num6 + num13]);
					scr.baseScript.OQCCDQOQOO(ref pos);
					list2[num6 + num13] = scr.transform.InverseTransformPoint(pos);
				}
				num7 = num8 * 2;
				if (list8[num8] && !array[num7])
				{
					for (int num14 = 0; num14 < num12 - 1; num14++)
					{
						list.Add(num5 + num14);
						list.Add(num6 + num14);
						list.Add(num5 + num14 + 1);
						list.Add(num5 + num14 + 1);
						list.Add(num6 + num14);
						list.Add(num6 + num14 + 1);
					}
				}
				num5 += num12 + 1;
			}
			scr.surfaceMeshVecs = list2.ToArray();
			if (scr.surfaceObject == null)
			{
				if ((bool)scr.transform.Find("surface"))
				{
					scr.surfaceObject = scr.transform.Find("surface").gameObject;
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
				}
				else
				{
					scr.surfaceObject = new GameObject("surface");
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
					scr.surfaceObject.transform.position = scr.transform.position;
					scr.surfaceObject.transform.rotation = scr.transform.rotation;
					scr.surfaceObject.transform.parent = scr.transform;
					scr.surfaceObject.layer = scr.baseScript.sLayer;
					scr.surfaceObject.AddComponent<ERSurfaceScript>();
				}
			}
			if (scr.surfaceObject.GetComponent<MeshFilter>() == null)
			{
				scr.surfaceObject.AddComponent<MeshFilter>();
			}
			if (scr.surfaceObject.GetComponent<MeshRenderer>() == null)
			{
				scr.surfaceObject.AddComponent<MeshRenderer>();
				scr.surfaceObject.GetComponent<MeshRenderer>().sharedMaterial = scr.baseScript.surfaceMaterial;
			}
			if (scr.surfaceObject.GetComponent<MeshCollider>() == null)
			{
				scr.surfaceObject.AddComponent<MeshCollider>();
			}
			if (scr.surfaceObject.GetComponent<ERSurfaceScript>() == null)
			{
				scr.surfaceObject.AddComponent<ERSurfaceScript>();
			}
			scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
			Mesh mesh;
			if (scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				mesh.name = "surface";
				scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			scr.surfaceObject.layer = scr.baseScript.sLayer;
			mesh.Clear();
			if (siblings.Count != 0)
			{
				mesh.vertices = scr.surfaceMeshVecs;
				mesh.uv = list3.ToArray();
				mesh.tangents = new Vector4[scr.surfaceMeshVecs.Length];
				mesh.triangles = list.ToArray();
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = null;
				scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = mesh;
				if (scr.baseScript != null && scr.baseScript.hideSurfaces)
				{
					scr.surfaceObject.GetComponent<MeshRenderer>().enabled = false;
					scr.surfaceObject.GetComponent<MeshCollider>().enabled = false;
					scr.surfaceObject.SetActive(value: false);
					scr.surfaceObject.SetActive(value: true);
				}
				scr.tmpSurfaceMeshVecs = new Vector3[scr.surfaceMeshVecs.Length];
				Array.Copy(scr.surfaceMeshVecs, scr.tmpSurfaceMeshVecs, scr.surfaceMeshVecs.Length);
			}
		}
	}
}
