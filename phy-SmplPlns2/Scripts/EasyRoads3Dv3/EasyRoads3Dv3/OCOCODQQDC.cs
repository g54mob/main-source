using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OCOCODQQDC : MonoBehaviour
	{
		public static void OCDDDCQOQQ(ERCrossingPrefabs scr, Vector3[] meshVecs, ref Vector3[] surfaceMeshVecs)
		{
			if (scr.baseScript == null && scr.transform.parent != null && scr.transform.parent.parent != null)
			{
				scr.baseScript = scr.transform.parent.parent.GetComponent<ERModularBase>();
			}
			if (scr.baseScript == null)
			{
				return;
			}
			if (scr.surfaceMeshVecs == null)
			{
				scr.surfaceMeshVecs = new Vector3[17];
			}
			if (scr.surfaceMeshVecs.Length != 17)
			{
				scr.surfaceMeshVecs = new Vector3[17];
			}
			int num = 0;
			if (scr.tCrossing)
			{
				num = scr.surfaceInts.Length - 16;
				scr.surfaceMeshVecs = new Vector3[17 + 2 * num];
			}
			Vector2[] array = new Vector2[scr.surfaceMeshVecs.Length];
			scr.surfaceMeshVecs[0] = Vector3.zero;
			array[0] = new Vector2(0f, 1f);
			scr.surfaceSurroundingInts.Clear();
			scr.surfaceSurroundingInts.Add(9);
			scr.surfaceSurroundingInts.Add(10);
			scr.surfaceSurroundingInts.Add(11);
			scr.surfaceSurroundingInts.Add(12);
			scr.surfaceSurroundingInts.Add(13);
			scr.surfaceSurroundingInts.Add(14);
			scr.surfaceSurroundingInts.Add(15);
			scr.surfaceSurroundingInts.Add(16);
			Vector3 connectedSurrounding;
			Vector3 mainSurrounding = (connectedSurrounding = Vector3.zero);
			float angle = 0f;
			scr.mainCorner = scr.meshVecs[scr.surfaceInts[2]];
			scr.connectedCorner = scr.meshVecs[scr.surfaceInts[12]];
			scr.mainVecOuter = scr.meshVecs[scr.surfaceInts[3]];
			scr.connectionVecOuter = scr.meshVecs[scr.surfaceInts[13]];
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				OCODQOOOCC(scr, angle, 1, leftrightFlag: true);
			}
			else
			{
				OCCDODCOOO(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[1]], ref mainSurrounding, ref connectedSurrounding);
			}
			scr.surfaceMeshVecs[1] = scr.mainIndent;
			array[1] = new Vector2(0f, 1f);
			scr.surfaceMeshVecs[8] = scr.connectionIndent;
			array[8] = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				OOOCCOCDQD(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, -1);
			}
			scr.surfaceMeshVecs[9] = mainSurrounding;
			array[9] = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[16] = connectedSurrounding;
			array[16] = new Vector2(0f, 0f);
			scr.mainCorner = scr.meshVecs[scr.surfaceInts[0]];
			scr.connectedCorner = scr.meshVecs[scr.surfaceInts[10]];
			scr.mainVecOuter = scr.meshVecs[scr.surfaceInts[1]];
			scr.connectionVecOuter = scr.meshVecs[scr.surfaceInts[11]];
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				OCODQOOOCC(scr, 270f + scr.sAngle, -1, leftrightFlag: false);
			}
			else
			{
				OCCDODCOOO(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[3]], ref mainSurrounding, ref connectedSurrounding);
			}
			scr.surfaceMeshVecs[2] = scr.mainIndent;
			array[2] = new Vector2(0f, 1f);
			scr.surfaceMeshVecs[3] = scr.connectionIndent;
			array[3] = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				OOOCCOCDQD(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, 1);
			}
			scr.surfaceMeshVecs[10] = mainSurrounding;
			array[10] = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[11] = connectedSurrounding;
			array[11] = new Vector2(0f, 0f);
			scr.mainCorner = scr.meshVecs[scr.surfaceInts[4]];
			scr.connectedCorner = scr.meshVecs[scr.surfaceInts[8]];
			scr.mainVecOuter = scr.meshVecs[scr.surfaceInts[5]];
			scr.connectionVecOuter = scr.meshVecs[scr.surfaceInts[9]];
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				OCODQOOOCC(scr, 90f - scr.sAngle, 1, leftrightFlag: true);
			}
			else
			{
				OCCDODCOOO(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[7]], ref mainSurrounding, ref connectedSurrounding);
			}
			scr.surfaceMeshVecs[5] = scr.mainIndent;
			array[5] = new Vector2(0f, 1f);
			scr.surfaceMeshVecs[4] = scr.connectionIndent;
			array[4] = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				OOOCCOCDQD(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, -1);
			}
			scr.surfaceMeshVecs[12] = mainSurrounding;
			array[12] = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[13] = connectedSurrounding;
			array[13] = new Vector2(0f, 0f);
			scr.mainCorner = scr.meshVecs[scr.surfaceInts[6]];
			scr.connectedCorner = scr.meshVecs[scr.surfaceInts[14]];
			scr.mainVecOuter = scr.meshVecs[scr.surfaceInts[7]];
			scr.connectionVecOuter = scr.meshVecs[scr.surfaceInts[15]];
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				OCODQOOOCC(scr, 270f + scr.sAngle, -1, leftrightFlag: false);
			}
			else
			{
				OCCDODCOOO(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[5]], ref mainSurrounding, ref connectedSurrounding);
			}
			scr.surfaceMeshVecs[6] = scr.mainIndent;
			array[6] = new Vector2(0f, 1f);
			scr.surfaceMeshVecs[7] = scr.connectionIndent;
			array[7] = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				OOOCCOCDQD(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, 1);
			}
			scr.surfaceMeshVecs[14] = mainSurrounding;
			array[14] = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[15] = connectedSurrounding;
			array[15] = new Vector2(0f, 0f);
			bool flag = true;
			OQOQOOODQO(scr, 0, scr.surfaceMeshVecs[2], scr.surfaceMeshVecs[10], scr.surfaceMeshVecs[1], scr.surfaceMeshVecs[9]);
			OCOCOQCCOD(scr, 0, 2, 10, 1, 9);
			OQOQOOODQO(scr, 1, scr.surfaceMeshVecs[6], scr.surfaceMeshVecs[14], scr.surfaceMeshVecs[5], scr.surfaceMeshVecs[13]);
			OCOCOQCCOD(scr, 1, 6, 14, 5, 13);
			OQOQOOODQO(scr, 2, scr.surfaceMeshVecs[4], scr.surfaceMeshVecs[12], scr.surfaceMeshVecs[3], scr.surfaceMeshVecs[10]);
			OCOCOQCCOD(scr, 3, 4, 12, 3, 10);
			OQOQOOODQO(scr, 3, scr.surfaceMeshVecs[8], scr.surfaceMeshVecs[16], scr.surfaceMeshVecs[7], scr.surfaceMeshVecs[15]);
			OCOCOQCCOD(scr, 3, 8, 16, 7, 15);
			OCOCDOOCCC(scr, 0, scr.meshVecs[scr.surfaceInts[3]], scr.meshVecs[scr.surfaceInts[2]]);
			OCOCDOOCCC(scr, 1, scr.meshVecs[scr.surfaceInts[5]], scr.meshVecs[scr.surfaceInts[4]]);
			OCOCDOOCCC(scr, 2, scr.meshVecs[scr.surfaceInts[9]], scr.meshVecs[scr.surfaceInts[8]]);
			OCOCDOOCCC(scr, 3, scr.meshVecs[scr.surfaceInts[13]], scr.meshVecs[scr.surfaceInts[12]]);
			List<int> list = new List<int>();
			if (scr.crossingElements[0].triangulateLeft || scr.crossingElements[0].triangulateRight)
			{
				list.Add(0);
				list.Add(1);
				list.Add(2);
				Vector3 vector = OQQOCDQCQD.OCOOQOQCDC(surfaceMeshVecs[2], surfaceMeshVecs[1], scr.crossingElements[0].centerPoint);
				if (!scr.crossingElements[0].triangulateLeft)
				{
					surfaceMeshVecs[2] = vector;
				}
				if (!scr.crossingElements[0].triangulateRight)
				{
					surfaceMeshVecs[1] = vector;
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				if (scr.crossingElements[0].triangulateLeft)
				{
					list.Add(0);
					list.Add(2);
					list.Add(3);
				}
				Vector3 vector = OQQOCDQCQD.OCOOQOQCDC(surfaceMeshVecs[3], surfaceMeshVecs[4], scr.crossingElements[2].centerPoint);
				if (!scr.crossingElements[2].triangulateRight)
				{
					surfaceMeshVecs[3] = vector;
				}
				if (scr.crossingElements[2].triangulateLeft || scr.crossingElements[2].triangulateRight)
				{
					list.Add(0);
					list.Add(3);
					list.Add(4);
				}
				if (scr.crossingElements[2].triangulateLeft)
				{
					list.Add(0);
					list.Add(4);
					list.Add(5);
				}
				else
				{
					surfaceMeshVecs[4] = vector;
				}
			}
			if (scr.crossingElements[1].triangulateLeft || scr.crossingElements[1].triangulateRight)
			{
				list.Add(0);
				list.Add(5);
				list.Add(6);
				Vector3 vector = OQQOCDQCQD.OCOOQOQCDC(surfaceMeshVecs[5], surfaceMeshVecs[6], scr.crossingElements[1].centerPoint);
				if (!scr.crossingElements[1].triangulateLeft)
				{
					surfaceMeshVecs[6] = vector;
				}
				if (!scr.crossingElements[1].triangulateRight)
				{
					surfaceMeshVecs[5] = vector;
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				if (scr.crossingElements[1].triangulateLeft)
				{
					list.Add(0);
					list.Add(6);
					list.Add(7);
				}
				Vector3 vector = OQQOCDQCQD.OCOOQOQCDC(surfaceMeshVecs[7], surfaceMeshVecs[8], scr.crossingElements[3].centerPoint);
				if (!scr.crossingElements[3].triangulateRight)
				{
					surfaceMeshVecs[7] = vector;
				}
				if (scr.crossingElements[3].triangulateLeft || scr.crossingElements[3].triangulateRight)
				{
					list.Add(0);
					list.Add(7);
					list.Add(8);
				}
				if (scr.crossingElements[0].triangulateRight)
				{
					list.Add(0);
					list.Add(8);
					list.Add(1);
				}
				else
				{
					surfaceMeshVecs[8] = vector;
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				if (scr.crossingElements[0].triangulateRight)
				{
					list.Add(1);
					list.Add(8);
					list.Add(16);
					list.Add(1);
					list.Add(16);
					list.Add(9);
				}
				if (scr.crossingElements[1].triangulateLeft)
				{
					list.Add(6);
					list.Add(14);
					list.Add(7);
					list.Add(7);
					list.Add(14);
					list.Add(15);
				}
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				if (scr.crossingElements[0].triangulateLeft)
				{
					list.Add(2);
					list.Add(10);
					list.Add(11);
					list.Add(2);
					list.Add(11);
					list.Add(3);
				}
				if (scr.crossingElements[1].triangulateRight)
				{
					list.Add(4);
					list.Add(12);
					list.Add(13);
					list.Add(4);
					list.Add(13);
					list.Add(5);
				}
			}
			if (scr.tCrossing)
			{
				int num2 = 17;
				int num3 = 17 + num;
				Vector3 vector2 = Vector3.left;
				if (scr.tCrossingLeftRight == 0)
				{
					vector2 = Vector3.right;
				}
				for (int i = 0; i < num; i++)
				{
					scr.surfaceMeshVecs[num2 + i] = scr.meshVecs[scr.surfaceInts[num2 + i - 1]] + vector2 * scr.baseScript.minIndent;
					array[num2 + i] = new Vector2(0f, 1f);
					scr.surfaceMeshVecs[num2 + i].y = 0f;
					Vector3 position = scr.meshVecs[scr.surfaceInts[num2 + i - 1]] + vector2 * (scr.baseScript.minIndent + scr.baseScript.minSurrounding);
					Vector3 pos = scr.transform.TransformPoint(position);
					scr.baseScript.OQCCDQOQOO(ref pos);
					position = scr.transform.InverseTransformPoint(pos);
					scr.surfaceMeshVecs[num3 + i] = position;
					array[num3 + i] = new Vector2(0f, 0f);
					scr.surfaceSurroundingInts.Add(num3 + i);
					if (i >= 0 && i < num - 1)
					{
						if (scr.tCrossingLeftRight == 1 && scr.crossingElements[0].triangulateLeft)
						{
							list.Add(num2 + i);
							list.Add(num3 + i);
							list.Add(num2 + i + 1);
							list.Add(num2 + i + 1);
							list.Add(num3 + i);
							list.Add(num3 + i + 1);
							list.Add(0);
							list.Add(num2 + i);
							list.Add(num2 + i + 1);
						}
						else if (scr.tCrossingLeftRight == 0 && scr.crossingElements[0].triangulateRight)
						{
							list.Add(num2 + i);
							list.Add(num2 + i + 1);
							list.Add(num3 + i);
							list.Add(num2 + i + 1);
							list.Add(num3 + i + 1);
							list.Add(num3 + i);
							list.Add(0);
							list.Add(num2 + i + 1);
							list.Add(num2 + i);
						}
					}
					if (i == num - 1 && scr.tCrossingLeftRight == 1)
					{
						scr.surfaceMeshVecs[13] = (scr.crossingElements[1].rightSurroundingV3 = position);
					}
				}
				scr.tp1 = scr.surfaceMeshVecs[num2];
				scr.tp2 = scr.surfaceMeshVecs[num3];
			}
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
			mesh.vertices = scr.surfaceMeshVecs;
			mesh.uv = array;
			mesh.tangents = new Vector4[scr.surfaceMeshVecs.Length];
			mesh.triangles = list.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = null;
			scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			if (scr.baseScript.hideSurfaces)
			{
				scr.surfaceObject.GetComponent<MeshRenderer>().enabled = false;
				scr.surfaceObject.GetComponent<MeshCollider>().enabled = false;
			}
			scr.tmpSurfaceMeshVecs = new Vector3[scr.surfaceMeshVecs.Length];
			Array.Copy(scr.surfaceMeshVecs, scr.tmpSurfaceMeshVecs, scr.surfaceMeshVecs.Length);
		}

		public static void OCODQOOOCC(ERCrossingPrefabs scr, float angle, int dirInt, bool leftrightFlag)
		{
			ODQDDCQDCQ(scr.mainCorner, ref scr.mainVecOuter, scr.baseScript.minIndent);
			ODQDDCQDCQ(scr.connectedCorner, ref scr.connectionVecOuter, scr.baseScript.minIndent);
			Vector3 mainCorner = scr.mainCorner;
			Vector3 mainVecOuter = scr.mainVecOuter;
			Vector3 connectedCorner = scr.connectedCorner;
			Vector3 connectionVecOuter = scr.connectionVecOuter;
			scr.cornerPos = OQQOCDQCQD.OCDCQCDDCC(scr.mainCorner, scr.mainVecOuter, scr.connectedCorner, scr.connectionVecOuter, flag: false);
			Vector3 dir = Vector3.zero;
			scr.connectionIndent = ODDOOODDQO(connectedCorner, scr.baseScript.minIndent, scr.connectionVecOuter, ref dir);
			scr.connectionIndent += new Vector3(dir.z, 0f, 0f - dir.x) * dirInt * scr.baseScript.minIndent;
			Vector3 dir2 = Vector3.zero;
			scr.mainIndent = ODDOOODDQO(mainCorner, scr.baseScript.minIndent, scr.mainVecOuter, ref dir2);
			scr.mainIndent += new Vector3(dir2.z, 0f, 0f - dir2.x) * -dirInt * scr.baseScript.minIndent;
			CheckIndentOOCQODQDQD(dir, dir2, scr.cornerPos, scr.mainVecOuter, ref scr.mainIndent, ref scr.connectionIndent, scr.sAngle, scr.baseScript.minIndent, leftrightFlag);
			scr.connectionIndent.y = -0.02f;
			scr.mainIndent.y = -0.02f;
			if ((double)Vector3.Distance(scr.connectionIndent, scr.mainIndent) < 0.5)
			{
				scr.connectionIndent = scr.mainIndent;
			}
		}

		public static Vector3 ODDOOODDQO(Vector3 cornerPos, float indent, Vector3 outerPos, ref Vector3 dir)
		{
			dir = (outerPos - cornerPos).normalized;
			float num = Vector3.Distance(cornerPos, outerPos);
			if (num < indent)
			{
				return cornerPos + dir * indent;
			}
			return outerPos;
		}

		public static void OCCDODCOOO(ERCrossingPrefabs scr, Vector3 vecOuter1, Vector3 vecOuter2, ref Vector3 mainSurrounding, ref Vector3 connectedSurrounding)
		{
			vecOuter1.y = (vecOuter2.y = 0f);
			Vector3 normalized = (vecOuter1 - vecOuter2).normalized;
			scr.mainIndent = vecOuter1 + normalized * scr.baseScript.minIndent;
			mainSurrounding = vecOuter1 + normalized * (scr.baseScript.minIndent + scr.baseScript.minSurrounding);
			scr.connectionIndent = Vector3.zero;
			connectedSurrounding = Vector3.zero;
		}

		public static void CheckIndentOOCQODQDQD(Vector3 dir1, Vector3 dir2, Vector3 cornerPos, Vector3 outer2, ref Vector3 indent2, ref Vector3 indent1, float angle, float minIndent, bool leftrightFlag)
		{
			if (ERCrossingPrefabs.OOCQODQDQD(outer2, indent2, indent1) != leftrightFlag)
			{
				float num = minIndent / Mathf.Sin(angle * 0.5f * (MathF.PI / 180f));
				Vector3 normalized = Vector3.Lerp(dir1, dir2, 0.5f).normalized;
				indent1 = (indent2 = cornerPos + normalized * num);
				float num2 = Mathf.Cos(angle * 0.5f * (MathF.PI / 180f)) * num;
			}
		}

		public static void OOOCCOCDQD(ERCrossingPrefabs scr, Vector3 corner, Vector3 indentMain, Vector3 indentConnection, ref Vector3 mainSurrounding, ref Vector3 connectedSurrounding, int dirInt)
		{
			if (indentMain != indentConnection)
			{
				Vector3 normalized = (indentMain - indentConnection).normalized;
				Vector3 vector = Vector3.Lerp(indentMain, indentConnection, 0.5f) + new Vector3(normalized.z, 0f, 0f - normalized.x) * dirInt * scr.baseScript.minSurrounding;
				mainSurrounding = (connectedSurrounding = vector);
			}
			else
			{
				Vector3 normalized2 = (indentMain - corner).normalized;
				Vector3 vector2 = indentMain + normalized2 * scr.baseScript.minSurrounding;
				mainSurrounding = (connectedSurrounding = vector2);
			}
			Vector3 pos = scr.transform.TransformPoint(mainSurrounding);
			if (Terrain.activeTerrain != null)
			{
				scr.baseScript.OQCCDQOQOO(ref pos);
				mainSurrounding = (connectedSurrounding = scr.transform.InverseTransformPoint(pos));
			}
			else if (scr.baseScript.meshSurface != null)
			{
				scr.baseScript.OQCCDQOQOO(ref pos);
				mainSurrounding = (connectedSurrounding = scr.transform.InverseTransformPoint(pos));
			}
		}

		public static void OQOQOOODQO(ERCrossingPrefabs scr, int connection, Vector3 leftIndent, Vector3 leftSurrounding, Vector3 rightIndent, Vector3 rightSurrounding)
		{
			scr.crossingElements[connection].leftIndentV3 = leftIndent;
			scr.crossingElements[connection].leftSurroundingV3 = leftSurrounding;
			scr.crossingElements[connection].rightIndentV3 = rightIndent;
			scr.crossingElements[connection].rightSurroundingV3 = rightSurrounding;
		}

		public static void OCOCOQCCOD(ERCrossingPrefabs scr, int connection, int leftIndent, int leftSurrounding, int rightIndent, int rightSurrounding)
		{
			scr.crossingElements[connection].leftIndent = leftIndent;
			scr.crossingElements[connection].leftSurrounding = leftSurrounding;
			scr.crossingElements[connection].rightIndent = rightIndent;
			scr.crossingElements[connection].rightSurrounding = rightSurrounding;
		}

		public static void OCOCDOOCCC(ERCrossingPrefabs scr, int connection, Vector3 outerPoint, Vector3 crosspoint)
		{
			Vector3 a = OQQOCDQCQD.OCDCQCDDCC(scr.crossingElements[connection].leftIndentV3, scr.crossingElements[connection].rightIndentV3, outerPoint, crosspoint, flag: false);
			float additionalIndentDistance = Vector3.Distance(a, outerPoint);
			scr.crossingElements[connection].additionalIndentDistance = additionalIndentDistance;
		}

		public static float OCCQDDQQCD(Vector3 v11, Vector3 v12, Vector3 v21, Vector3 v22)
		{
			Vector3 normalized = (v11 - v12).normalized;
			Vector3 normalized2 = (v21 - v22).normalized;
			return Vector3.Angle(normalized, normalized2);
		}

		public static void ODQDDCQDCQ(Vector3 inner, ref Vector3 outer, float minDist)
		{
			if (Vector3.Distance(inner, outer) < minDist)
			{
				outer = inner + (outer - inner).normalized * minDist;
			}
		}

		public static void OQOOCCCCDQ(ERCrossingPrefabs scr, Vector3[] meshVecs)
		{
			if (scr.baseScript == null)
			{
				scr.baseScript = scr.transform.parent.parent.GetComponent<ERModularBase>();
			}
			float num = 8f;
			scr.rightBottomCorner = new Vector3(3f, 0f, -3f);
			scr.bottomVec = new Vector3(3f, 0f, -3f - num);
			scr.rightVec = new Vector3(3f + num, 0f, -3f);
			float y = 90f - scr.sAngle;
			scr.rightVec = ERRoundabouts.OOQOCODQOO(scr.rightVec, scr.rightBottomCorner, Quaternion.Euler(0f, y, 0f));
			Vector3 dir = Vector3.zero;
			scr.rightIndent = ODDOOODDQO(scr.rightBottomCorner, scr.baseScript.minIndent, scr.rightVec, ref dir);
			scr.rightIndent += new Vector3(dir.z, 0f, 0f - dir.x) * scr.baseScript.minIndent;
			Vector3 dir2 = Vector3.zero;
			scr.bottomIndent = ODDOOODDQO(scr.rightBottomCorner, scr.baseScript.minIndent, scr.bottomVec, ref dir2);
			scr.bottomIndent += new Vector3(dir2.z, 0f, 0f - dir2.x) * -1f * scr.baseScript.minIndent;
			CheckIndentOOCQODQDQD(dir, dir2, scr.rightBottomCorner, scr.bottomVec, ref scr.bottomIndent, ref scr.rightIndent, scr.sAngle, scr.baseScript.minIndent, leftrightFlag: false);
		}

		public static void OQCODOOQOO(ERCrossingPrefabs scr, int connection)
		{
			if (connection == 0)
			{
				if (scr.tCrossingLeftRight == 0)
				{
					ODOQCDDOQC(scr, scr.crossingElements[0], scr.crossingElements[2], 1);
					scr.crossingElements[1].rightIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].rightIndent];
					scr.crossingElements[1].rightSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].rightSurrounding];
				}
				else
				{
					ODOQCDDOQC(scr, scr.crossingElements[3], scr.crossingElements[0], 1);
					scr.crossingElements[1].leftIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].leftIndent];
					scr.crossingElements[1].leftSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].leftSurrounding];
				}
			}
			else if (scr.tCrossingLeftRight == 0)
			{
				ODOQCDDOQC(scr, scr.crossingElements[2], scr.crossingElements[1], 0);
				scr.crossingElements[0].rightIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].rightIndent];
				scr.crossingElements[0].rightSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].rightSurrounding];
			}
			else
			{
				ODOQCDDOQC(scr, scr.crossingElements[1], scr.crossingElements[3], 0);
				scr.crossingElements[0].leftIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].leftIndent];
				scr.crossingElements[0].leftSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].leftSurrounding];
			}
		}

		public static void ODOQCDDOQC(ERCrossingPrefabs scr, QDOODOQQDQODD el1, QDOODOQQDQODD el2, int leftright)
		{
			float minIndent = scr.baseScript.minIndent;
			float minSurrounding = scr.baseScript.minSurrounding;
			Vector3 vector = scr.tmpFullMeshVecs[el1.connectionVecInts[0]];
			Vector3 vector2 = scr.tmpFullMeshVecs[el1.connectionVecInts[el1.connectionVecInts.Count - 1]];
			Vector3 vector3 = scr.tmpFullMeshVecs[el2.connectionVecInts[0]];
			Vector3 vector4 = scr.tmpFullMeshVecs[el2.connectionVecInts[el2.connectionVecInts.Count - 1]];
			vector.y = (vector2.y = (vector3.y = (vector4.y = 0f)));
			Vector3 normalized = (vector - vector2).normalized;
			Vector3 normalized2 = (vector4 - vector3).normalized;
			Vector3 normalized3 = ((normalized + normalized2) * 0.5f).normalized;
			float num = 180f - Vector3.Angle(normalized, normalized2);
			Vector3 b = OQQOCDQCQD.OCDCQCDDCC(vector, vector2, vector3, vector4, flag: false);
			float num2 = Vector3.Distance(vector, b);
			float num3 = Vector3.Distance(vector4, b);
			if (num2 < minIndent || num3 < minIndent)
			{
				Vector3 vector5 = new Vector3(normalized.z, 0f, 0f - normalized.x);
				Vector3 p = vector + vector5 * 1f;
				vector5 = new Vector3(normalized2.z, 0f, 0f - normalized2.x);
				Vector3 p2 = vector4 + vector5 * 1f;
				Vector3 vector6 = OQQOCDQCQD.OCDCQCDDCC(vector, p, vector4, p2, flag: false);
				float num4 = minIndent / Mathf.Sin(num * 0.5f * (MathF.PI / 180f));
				Vector3 vector7 = vector6 + normalized3 * num4;
				if (el1.leftIndent != -1)
				{
					scr.tmpSurfaceMeshVecs[el1.leftIndent] = vector7;
				}
				el1.leftIndentV3 = vector7;
				if (el2.rightIndent != -1)
				{
					scr.tmpSurfaceMeshVecs[el2.rightIndent] = vector7;
				}
				el2.rightIndentV3 = vector7;
				vector7 += normalized3 * minSurrounding;
				if (el1.leftSurrounding != -1)
				{
					scr.tmpSurfaceMeshVecs[el1.leftSurrounding] = vector7;
				}
				el1.leftSurroundingV3 = vector7;
				if (el2.rightSurrounding != -1)
				{
					scr.tmpSurfaceMeshVecs[el2.rightSurrounding] = vector7;
				}
				el2.rightSurroundingV3 = vector7;
			}
			else
			{
				Vector3 vector8 = vector + normalized * minIndent;
				if (el1.leftIndent != -1)
				{
					scr.tmpSurfaceMeshVecs[el1.leftIndent] = vector8;
				}
				el1.leftIndentV3 = vector8;
				vector8 += normalized3 * minSurrounding;
				if (el1.leftSurrounding != -1)
				{
					scr.tmpSurfaceMeshVecs[el1.leftSurrounding] = vector8;
				}
				el1.leftSurroundingV3 = vector8;
				vector8 = vector4 + normalized2 * minIndent;
				if (el2.rightIndent != -1)
				{
					scr.tmpSurfaceMeshVecs[el2.rightIndent] = vector8;
				}
				el2.rightIndentV3 = vector8;
				vector8 += normalized3 * minSurrounding;
				if (el2.rightSurrounding != -1)
				{
					scr.tmpSurfaceMeshVecs[el2.rightSurrounding] = vector8;
				}
				el2.rightSurroundingV3 = vector8;
			}
			if (leftright == 0)
			{
				if (el1.rightIndent != -1)
				{
					el1.rightIndentV3 = scr.tmpSurfaceMeshVecs[el1.rightIndent];
				}
				if (el1.rightSurrounding != -1)
				{
					el1.rightSurroundingV3 = scr.tmpSurfaceMeshVecs[el1.rightSurrounding];
				}
			}
			else
			{
				if (el2.leftIndent != -1)
				{
					el2.leftIndentV3 = scr.tmpSurfaceMeshVecs[el2.leftIndent];
				}
				if (el2.leftSurrounding != -1)
				{
					el2.leftSurroundingV3 = scr.tmpSurfaceMeshVecs[el2.leftSurrounding];
				}
			}
		}

		public static void OQOOOCDQQD(ERCrossingPrefabs scr)
		{
			if (scr.surfaceObject == null)
			{
				return;
			}
			Mesh sharedMesh;
			if (scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				sharedMesh = scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh;
				Vector3[] array = new Vector3[scr.tmpSurfaceMeshVecs.Length];
				Array.Copy(scr.tmpSurfaceMeshVecs, array, scr.tmpSurfaceMeshVecs.Length);
				if (sharedMesh.vertices.Length == 0)
				{
					return;
				}
				int[] triangles = sharedMesh.triangles;
				for (int i = 0; i < scr.surfaceSurroundingInts.Count; i++)
				{
					if (scr.tmpSurfaceMeshVecs.Length > scr.surfaceSurroundingInts[i])
					{
						Vector3 pos = scr.surfaceObject.transform.TransformPoint(scr.tmpSurfaceMeshVecs[scr.surfaceSurroundingInts[i]]);
						scr.baseScript.OQCCDQOQOO(ref pos);
						pos = scr.surfaceObject.transform.InverseTransformPoint(pos);
						array[scr.surfaceSurroundingInts[i]] = pos;
					}
				}
				sharedMesh.vertices = array;
				sharedMesh.RecalculateNormals();
				sharedMesh.RecalculateBounds();
				scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
				scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = null;
				scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
				if (scr.baseScript.hideSurfaces)
				{
					scr.surfaceObject.GetComponent<MeshCollider>().enabled = false;
					scr.surfaceObject.SetActive(value: false);
					scr.surfaceObject.SetActive(value: true);
				}
				for (int j = 0; j < scr.crossingElements.Count; j++)
				{
					if (scr.crossingElements[j].leftSurrounding < array.Length && scr.crossingElements[j].leftSurrounding >= 0)
					{
						scr.crossingElements[j].leftSurroundingV3 = array[scr.crossingElements[j].leftSurrounding];
					}
					if (scr.crossingElements[j].rightSurrounding < array.Length && scr.crossingElements[j].rightSurrounding >= 0)
					{
						scr.crossingElements[j].rightSurroundingV3 = array[scr.crossingElements[j].rightSurrounding];
					}
				}
				return;
			}
			sharedMesh = new Mesh();
			sharedMesh.name = "surface";
			scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
			if (scr.isRoundabout)
			{
				scr.roundaboutScript.OOODQQDOOD();
				scr.roundaboutScript.OCODQOOOCQ();
				scr.roundaboutScript.OCOCDCDDOD();
				return;
			}
			ERCrossings component = scr.gameObject.GetComponent<ERCrossings>();
			if (component != null)
			{
				component.OQDCCQOCCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
			}
		}

		public static Vector3 OQOOOCQDDO(Transform transform, Vector3 pos, ERModularBase scr)
		{
			pos = transform.TransformPoint(pos);
			scr.OQCCDQOQOO(ref pos);
			return transform.InverseTransformPoint(pos);
		}
	}
}
