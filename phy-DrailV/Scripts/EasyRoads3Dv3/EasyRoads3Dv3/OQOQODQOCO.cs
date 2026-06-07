using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OQOQODQOCO : MonoBehaviour
	{
		public static void OCODQQCQQO(ERCrossingPrefabs scr, Vector3[] meshVecs, ref Vector3[] surfaceMeshVecs)
		{
			scr.surfaceSurroundingInts.Clear();
			List<int> list = new List<int>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector3> list4 = new List<Vector3>();
			List<int> list5 = new List<int>();
			list2.Add(Vector3.zero);
			list3.Add(new Vector2(0f, 1f));
			for (int i = 0; i < scr.roundaboutScript.connections.Count; i++)
			{
				if (i == 0)
				{
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftIndent = list2.Count;
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftIndentV3 = scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftIndentvecs[0];
					list2.AddRange(scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftIndentvecs);
					for (int j = 0; j < scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftIndentvecs.Count; j++)
					{
						list3.Add(new Vector2(0f, 1f));
					}
				}
				else
				{
					scr.crossingElements[i - 1].leftIndent = list2.Count;
					scr.crossingElements[i - 1].leftIndentV3 = scr.roundaboutScript.connections[i - 1].leftIndentvecs[0];
					list2.AddRange(scr.roundaboutScript.connections[i - 1].leftIndentvecs);
					for (int j = 0; j < scr.roundaboutScript.connections[i - 1].leftIndentvecs.Count; j++)
					{
						list3.Add(new Vector2(0f, 1f));
					}
				}
				list4.Clear();
				list4.AddRange(scr.roundaboutScript.connections[i].rightIndentvecs);
				list4.Reverse();
				list2.AddRange(list4);
				for (int j = 0; j < list4.Count; j++)
				{
					list3.Add(new Vector2(0f, 1f));
				}
				scr.crossingElements[i].rightIndent = list2.Count - 1;
				scr.crossingElements[i].rightIndentV3 = list2[list2.Count - 1];
			}
			for (int i = 1; i < list2.Count - 1; i++)
			{
				list.Add(0);
				list.Add(i);
				list.Add(i + 1);
			}
			list.Add(0);
			list.Add(list2.Count - 1);
			list.Add(1);
			int num = 1;
			int num2 = 0;
			for (int i = 0; i < scr.roundaboutScript.connections.Count; i++)
			{
				num2 = list2.Count;
				if (i == 0)
				{
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftSurrounding = list2.Count;
					scr.crossingElements[scr.roundaboutScript.connections.Count - 1].leftSurroundingV3 = scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftSurroundingvecs[0];
					list2.AddRange(scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftSurroundingvecs);
					for (int j = 0; j < scr.roundaboutScript.connections[scr.roundaboutScript.connections.Count - 1].leftSurroundingvecs.Count; j++)
					{
						list3.Add(new Vector2(0f, 0f));
					}
				}
				else
				{
					scr.crossingElements[i - 1].leftSurrounding = list2.Count;
					scr.crossingElements[i - 1].leftSurroundingV3 = scr.roundaboutScript.connections[i - 1].leftSurroundingvecs[0];
					list2.AddRange(scr.roundaboutScript.connections[i - 1].leftSurroundingvecs);
					for (int j = 0; j < scr.roundaboutScript.connections[i - 1].leftSurroundingvecs.Count; j++)
					{
						list3.Add(new Vector2(0f, 0f));
					}
				}
				list4.Clear();
				list4.AddRange(scr.roundaboutScript.connections[i].rightSurroundingvecs);
				list4.Reverse();
				list2.AddRange(list4);
				for (int j = 0; j < list4.Count; j++)
				{
					list3.Add(new Vector2(0f, 0f));
				}
				scr.crossingElements[i].rightSurrounding = list2.Count - 1;
				scr.crossingElements[i].rightSurroundingV3 = list2[list2.Count - 1];
				int num3 = list2.Count - num2;
				for (int j = 0; j < num3; j++)
				{
					scr.surfaceSurroundingInts.Add(num2 + j);
				}
				for (int j = 0; j < num3 - 1; j++)
				{
					list.Add(num + j);
					list.Add(num2 + j);
					list.Add(num + j + 1);
					list.Add(num + j + 1);
					list.Add(num2 + j);
					list.Add(num2 + j + 1);
				}
				num += num3;
			}
			scr.surfaceMeshVecs = list2.ToArray();
			if (scr.surfaceObject == null)
			{
				if ((bool)scr.transform.Find("surface"))
				{
					scr.surfaceObject = scr.transform.Find("surface").gameObject;
				}
				else
				{
					scr.surfaceObject = new GameObject("surface");
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
					scr.surfaceObject.transform.position = scr.transform.position;
					scr.surfaceObject.transform.rotation = scr.transform.rotation;
					scr.surfaceObject.transform.parent = scr.transform;
					scr.surfaceObject.layer = 31;
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
				scr.surfaceObject.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load("Materials/surfaceMaterial") as Material;
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
			scr.surfaceObject.layer = 31;
			mesh.Clear();
			if (scr.roundaboutScript.connections.Count != 0)
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
