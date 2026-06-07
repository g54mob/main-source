using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OCDCCCQDCC : MonoBehaviour
	{
		public static void ODOODDQDOD(ERCrossingPrefabs scr, Vector3[] meshVecs, ref Vector3[] surfaceMeshVecs)
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
			ref Vector3 reference = ref scr.surfaceMeshVecs[0];
			reference = Vector3.zero;
			ref Vector2 reference2 = ref array[0];
			reference2 = new Vector2(0f, 1f);
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
				ODDDCCOOCD(scr, angle, 1, leftrightFlag: true);
			}
			else
			{
				OOCDOCQODC(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[1]], ref mainSurrounding, ref connectedSurrounding);
			}
			ref Vector3 reference3 = ref scr.surfaceMeshVecs[1];
			reference3 = scr.mainIndent;
			ref Vector2 reference4 = ref array[1];
			reference4 = new Vector2(0f, 1f);
			ref Vector3 reference5 = ref scr.surfaceMeshVecs[8];
			reference5 = scr.connectionIndent;
			ref Vector2 reference6 = ref array[8];
			reference6 = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				OQODDDQOOC(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, -1);
			}
			scr.surfaceMeshVecs[9] = mainSurrounding;
			ref Vector2 reference7 = ref array[9];
			reference7 = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[16] = connectedSurrounding;
			ref Vector2 reference8 = ref array[16];
			reference8 = new Vector2(0f, 0f);
			scr.mainCorner = scr.meshVecs[scr.surfaceInts[0]];
			scr.connectedCorner = scr.meshVecs[scr.surfaceInts[10]];
			scr.mainVecOuter = scr.meshVecs[scr.surfaceInts[1]];
			scr.connectionVecOuter = scr.meshVecs[scr.surfaceInts[11]];
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				ODDDCCOOCD(scr, 270f + scr.sAngle, -1, leftrightFlag: false);
			}
			else
			{
				OOCDOCQODC(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[3]], ref mainSurrounding, ref connectedSurrounding);
			}
			ref Vector3 reference9 = ref scr.surfaceMeshVecs[2];
			reference9 = scr.mainIndent;
			ref Vector2 reference10 = ref array[2];
			reference10 = new Vector2(0f, 1f);
			ref Vector3 reference11 = ref scr.surfaceMeshVecs[3];
			reference11 = scr.connectionIndent;
			ref Vector2 reference12 = ref array[3];
			reference12 = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				OQODDDQOOC(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, 1);
			}
			scr.surfaceMeshVecs[10] = mainSurrounding;
			ref Vector2 reference13 = ref array[10];
			reference13 = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[11] = connectedSurrounding;
			ref Vector2 reference14 = ref array[11];
			reference14 = new Vector2(0f, 0f);
			scr.mainCorner = scr.meshVecs[scr.surfaceInts[4]];
			scr.connectedCorner = scr.meshVecs[scr.surfaceInts[8]];
			scr.mainVecOuter = scr.meshVecs[scr.surfaceInts[5]];
			scr.connectionVecOuter = scr.meshVecs[scr.surfaceInts[9]];
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				ODDDCCOOCD(scr, 90f - scr.sAngle, 1, leftrightFlag: true);
			}
			else
			{
				OOCDOCQODC(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[7]], ref mainSurrounding, ref connectedSurrounding);
			}
			ref Vector3 reference15 = ref scr.surfaceMeshVecs[5];
			reference15 = scr.mainIndent;
			ref Vector2 reference16 = ref array[5];
			reference16 = new Vector2(0f, 1f);
			ref Vector3 reference17 = ref scr.surfaceMeshVecs[4];
			reference17 = scr.connectionIndent;
			ref Vector2 reference18 = ref array[4];
			reference18 = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				OQODDDQOOC(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, -1);
			}
			scr.surfaceMeshVecs[12] = mainSurrounding;
			ref Vector2 reference19 = ref array[12];
			reference19 = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[13] = connectedSurrounding;
			ref Vector2 reference20 = ref array[13];
			reference20 = new Vector2(0f, 0f);
			scr.mainCorner = scr.meshVecs[scr.surfaceInts[6]];
			scr.connectedCorner = scr.meshVecs[scr.surfaceInts[14]];
			scr.mainVecOuter = scr.meshVecs[scr.surfaceInts[7]];
			scr.connectionVecOuter = scr.meshVecs[scr.surfaceInts[15]];
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				ODDDCCOOCD(scr, 270f + scr.sAngle, -1, leftrightFlag: false);
			}
			else
			{
				OOCDOCQODC(scr, scr.mainVecOuter, scr.meshVecs[scr.surfaceInts[5]], ref mainSurrounding, ref connectedSurrounding);
			}
			ref Vector3 reference21 = ref scr.surfaceMeshVecs[6];
			reference21 = scr.mainIndent;
			ref Vector2 reference22 = ref array[6];
			reference22 = new Vector2(0f, 1f);
			ref Vector3 reference23 = ref scr.surfaceMeshVecs[7];
			reference23 = scr.connectionIndent;
			ref Vector2 reference24 = ref array[7];
			reference24 = new Vector2(0f, 1f);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				OQODDDQOOC(scr, scr.mainCorner, scr.mainIndent, scr.connectionIndent, ref mainSurrounding, ref connectedSurrounding, 1);
			}
			scr.surfaceMeshVecs[14] = mainSurrounding;
			ref Vector2 reference25 = ref array[14];
			reference25 = new Vector2(0f, 0f);
			scr.surfaceMeshVecs[15] = connectedSurrounding;
			ref Vector2 reference26 = ref array[15];
			reference26 = new Vector2(0f, 0f);
			bool flag = true;
			OQDCDQOCQQ(scr, 0, scr.surfaceMeshVecs[2], scr.surfaceMeshVecs[10], scr.surfaceMeshVecs[1], scr.surfaceMeshVecs[9]);
			OOCCDCQQCC(scr, 0, 2, 10, 1, 9);
			OQDCDQOCQQ(scr, 1, scr.surfaceMeshVecs[6], scr.surfaceMeshVecs[14], scr.surfaceMeshVecs[5], scr.surfaceMeshVecs[13]);
			OOCCDCQQCC(scr, 1, 6, 14, 5, 13);
			OQDCDQOCQQ(scr, 2, scr.surfaceMeshVecs[4], scr.surfaceMeshVecs[12], scr.surfaceMeshVecs[2], scr.surfaceMeshVecs[10]);
			OOCCDCQQCC(scr, 2, 4, 12, 2, 10);
			OQDCDQOCQQ(scr, 3, scr.surfaceMeshVecs[8], scr.surfaceMeshVecs[16], scr.surfaceMeshVecs[7], scr.surfaceMeshVecs[15]);
			OOCCDCQQCC(scr, 3, 8, 16, 7, 15);
			OOODCDCOQC(scr, 0, scr.meshVecs[scr.surfaceInts[3]], scr.meshVecs[scr.surfaceInts[2]]);
			OOODCDCOQC(scr, 1, scr.meshVecs[scr.surfaceInts[5]], scr.meshVecs[scr.surfaceInts[4]]);
			OOODCDCOQC(scr, 2, scr.meshVecs[scr.surfaceInts[9]], scr.meshVecs[scr.surfaceInts[8]]);
			OOODCDCOQC(scr, 3, scr.meshVecs[scr.surfaceInts[13]], scr.meshVecs[scr.surfaceInts[12]]);
			List<int> list = new List<int>();
			list.Add(0);
			list.Add(1);
			list.Add(2);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				list.Add(0);
				list.Add(2);
				list.Add(3);
				list.Add(0);
				list.Add(3);
				list.Add(4);
				list.Add(0);
				list.Add(4);
				list.Add(5);
			}
			list.Add(0);
			list.Add(5);
			list.Add(6);
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				list.Add(0);
				list.Add(6);
				list.Add(7);
				list.Add(0);
				list.Add(7);
				list.Add(8);
				list.Add(0);
				list.Add(8);
				list.Add(1);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 1)
			{
				list.Add(1);
				list.Add(8);
				list.Add(16);
				list.Add(1);
				list.Add(16);
				list.Add(9);
				list.Add(6);
				list.Add(14);
				list.Add(7);
				list.Add(7);
				list.Add(14);
				list.Add(15);
			}
			if (!scr.tCrossing || scr.tCrossingLeftRight == 0)
			{
				list.Add(2);
				list.Add(10);
				list.Add(11);
				list.Add(2);
				list.Add(11);
				list.Add(3);
				list.Add(4);
				list.Add(12);
				list.Add(13);
				list.Add(4);
				list.Add(13);
				list.Add(5);
			}
			if (scr.tCrossing)
			{
				Vector3 vector = Vector3.left;
				if (scr.tCrossingLeftRight == 0)
				{
					vector = Vector3.right;
				}
				int num2 = 17;
				int num3 = 17 + num;
				for (int i = 0; i < num; i++)
				{
					ref Vector3 reference27 = ref scr.surfaceMeshVecs[num2 + i];
					reference27 = scr.meshVecs[scr.surfaceInts[num2 + i - 1]] + vector * scr.baseScript.minIndent;
					ref Vector2 reference28 = ref array[num2 + i];
					reference28 = new Vector2(0f, 1f);
					scr.surfaceMeshVecs[num2 + i].y = 0f;
					Vector3 position = scr.meshVecs[scr.surfaceInts[num2 + i - 1]] + vector * (scr.baseScript.minIndent + scr.baseScript.minSurrounding);
					Vector3 pos = scr.transform.TransformPoint(position);
					scr.baseScript.OCCDCQCOQC(ref pos);
					position = scr.transform.InverseTransformPoint(pos);
					scr.surfaceMeshVecs[num3 + i] = position;
					ref Vector2 reference29 = ref array[num3 + i];
					reference29 = new Vector2(0f, 0f);
					scr.surfaceSurroundingInts.Add(num3 + i);
					if (i >= 0 && i < num - 1)
					{
						if (scr.tCrossingLeftRight == 1)
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
						else
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
						ref Vector3 reference30 = ref scr.surfaceMeshVecs[13];
						reference30 = (scr.crossingElements[1].rightSurroundingV3 = position);
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

		public static void ODDDCCOOCD(ERCrossingPrefabs scr, float angle, int dirInt, bool leftrightFlag)
		{
			OQOODQQCDD(scr.mainCorner, ref scr.mainVecOuter, scr.baseScript.minIndent);
			OQOODQQCDD(scr.connectedCorner, ref scr.connectionVecOuter, scr.baseScript.minIndent);
			Vector3 mainCorner = scr.mainCorner;
			Vector3 mainVecOuter = scr.mainVecOuter;
			Vector3 connectedCorner = scr.connectedCorner;
			Vector3 connectionVecOuter = scr.connectionVecOuter;
			scr.cornerPos = OCQCDQCQOQ.OCDCDCDCQD(scr.mainCorner, scr.mainVecOuter, scr.connectedCorner, scr.connectionVecOuter);
			Vector3 dir = Vector3.zero;
			scr.connectionIndent = ODCODQOOOD(connectedCorner, scr.baseScript.minIndent, scr.connectionVecOuter, ref dir);
			scr.connectionIndent += new Vector3(dir.z, 0f, 0f - dir.x) * dirInt * scr.baseScript.minIndent;
			Vector3 dir2 = Vector3.zero;
			scr.mainIndent = ODCODQOOOD(mainCorner, scr.baseScript.minIndent, scr.mainVecOuter, ref dir2);
			scr.mainIndent += new Vector3(dir2.z, 0f, 0f - dir2.x) * -dirInt * scr.baseScript.minIndent;
			CheckIndentOOOOCDQQOC(dir, dir2, scr.cornerPos, scr.mainVecOuter, ref scr.mainIndent, ref scr.connectionIndent, scr.sAngle, scr.baseScript.minIndent, leftrightFlag);
			scr.connectionIndent.y = -0.02f;
			scr.mainIndent.y = -0.02f;
			if ((double)Vector3.Distance(scr.connectionIndent, scr.mainIndent) < 0.5)
			{
				scr.connectionIndent = scr.mainIndent;
			}
		}

		public static Vector3 ODCODQOOOD(Vector3 cornerPos, float indent, Vector3 outerPos, ref Vector3 dir)
		{
			dir = (outerPos - cornerPos).normalized;
			float num = Vector3.Distance(cornerPos, outerPos);
			if (num < indent)
			{
				return cornerPos + dir * indent;
			}
			return outerPos;
		}

		public static void OOCDOCQODC(ERCrossingPrefabs scr, Vector3 vecOuter1, Vector3 vecOuter2, ref Vector3 mainSurrounding, ref Vector3 connectedSurrounding)
		{
			vecOuter1.y = (vecOuter2.y = 0f);
			Vector3 normalized = (vecOuter1 - vecOuter2).normalized;
			scr.mainIndent = vecOuter1 + normalized * scr.baseScript.minIndent;
			mainSurrounding = vecOuter1 + normalized * (scr.baseScript.minIndent + scr.baseScript.minSurrounding);
			scr.connectionIndent = Vector3.zero;
			connectedSurrounding = Vector3.zero;
		}

		public static void CheckIndentOOOOCDQQOC(Vector3 dir1, Vector3 dir2, Vector3 cornerPos, Vector3 outer2, ref Vector3 indent2, ref Vector3 indent1, float angle, float minIndent, bool leftrightFlag)
		{
			if (ERCrossingPrefabs.OOOOCDQQOC(outer2, indent2, indent1) != leftrightFlag)
			{
				float num = minIndent / Mathf.Sin(angle * 0.5f * ((float)Math.PI / 180f));
				Vector3 normalized = Vector3.Lerp(dir1, dir2, 0.5f).normalized;
				indent1 = (indent2 = cornerPos + normalized * num);
				float num2 = Mathf.Cos(angle * 0.5f * ((float)Math.PI / 180f)) * num;
			}
		}

		public static void OQODDDQOOC(ERCrossingPrefabs scr, Vector3 corner, Vector3 indentMain, Vector3 indentConnection, ref Vector3 mainSurrounding, ref Vector3 connectedSurrounding, int dirInt)
		{
			if (indentMain != indentConnection)
			{
				Vector3 normalized = (indentMain - indentConnection).normalized;
				Vector3 vector = Vector3.Lerp(indentMain, indentConnection, 0.5f) + new Vector3(normalized.z, 0f, 0f - normalized.x) * dirInt * scr.baseScript.minSurrounding;
				mainSurrounding = (connectedSurrounding = vector);
			}
			else
			{
				Vector3 normalized = (indentMain - corner).normalized;
				Vector3 vector = indentMain + normalized * scr.baseScript.minSurrounding;
				mainSurrounding = (connectedSurrounding = vector);
			}
			Vector3 pos = scr.transform.TransformPoint(mainSurrounding);
			if (Terrain.activeTerrain != null)
			{
				scr.baseScript.OCCDCQCOQC(ref pos);
				mainSurrounding = (connectedSurrounding = scr.transform.InverseTransformPoint(pos));
			}
			else
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: The active terrain is still null");
			}
		}

		public static void OQDCDQOCQQ(ERCrossingPrefabs scr, int connection, Vector3 leftIndent, Vector3 leftSurrounding, Vector3 rightIndent, Vector3 rightSurrounding)
		{
			scr.crossingElements[connection].leftIndentV3 = leftIndent;
			scr.crossingElements[connection].leftSurroundingV3 = leftSurrounding;
			scr.crossingElements[connection].rightIndentV3 = rightIndent;
			scr.crossingElements[connection].rightSurroundingV3 = rightSurrounding;
		}

		public static void OOCCDCQQCC(ERCrossingPrefabs scr, int connection, int leftIndent, int leftSurrounding, int rightIndent, int rightSurrounding)
		{
			scr.crossingElements[connection].leftIndent = leftIndent;
			scr.crossingElements[connection].leftSurrounding = leftSurrounding;
			scr.crossingElements[connection].rightIndent = rightIndent;
			scr.crossingElements[connection].rightSurrounding = rightSurrounding;
		}

		public static void OOODCDCOQC(ERCrossingPrefabs scr, int connection, Vector3 outerPoint, Vector3 crosspoint)
		{
			Vector3 a = OCQCDQCQOQ.OCDCDCDCQD(scr.crossingElements[connection].leftIndentV3, scr.crossingElements[connection].rightIndentV3, outerPoint, crosspoint);
			float additionalIndentDistance = Vector3.Distance(a, outerPoint);
			scr.crossingElements[connection].additionalIndentDistance = additionalIndentDistance;
		}

		public static float OQOCQQCDDQ(Vector3 v11, Vector3 v12, Vector3 v21, Vector3 v22)
		{
			Vector3 normalized = (v11 - v12).normalized;
			Vector3 normalized2 = (v21 - v22).normalized;
			return Vector3.Angle(normalized, normalized2);
		}

		public static void OQOODQQCDD(Vector3 inner, ref Vector3 outer, float minDist)
		{
			if (Vector3.Distance(inner, outer) < minDist)
			{
				outer = inner + (outer - inner).normalized * minDist;
			}
		}

		public static void ODDCOCQQCD(ERCrossingPrefabs scr, Vector3[] meshVecs)
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
			scr.rightVec = ERRoundabouts.OCQDOQQQOD(scr.rightVec, scr.rightBottomCorner, Quaternion.Euler(0f, y, 0f));
			Vector3 dir = Vector3.zero;
			scr.rightIndent = ODCODQOOOD(scr.rightBottomCorner, scr.baseScript.minIndent, scr.rightVec, ref dir);
			scr.rightIndent += new Vector3(dir.z, 0f, 0f - dir.x) * scr.baseScript.minIndent;
			Vector3 dir2 = Vector3.zero;
			scr.bottomIndent = ODCODQOOOD(scr.rightBottomCorner, scr.baseScript.minIndent, scr.bottomVec, ref dir2);
			scr.bottomIndent += new Vector3(dir2.z, 0f, 0f - dir2.x) * -1f * scr.baseScript.minIndent;
			CheckIndentOOOOCDQQOC(dir, dir2, scr.rightBottomCorner, scr.bottomVec, ref scr.bottomIndent, ref scr.rightIndent, scr.sAngle, scr.baseScript.minIndent, leftrightFlag: false);
		}

		public static void OCQQOQCCDC(ERCrossingPrefabs scr, int connection)
		{
			if (connection == 0)
			{
				if (scr.tCrossingLeftRight == 0)
				{
					OCQDDQOQQO(scr, scr.crossingElements[0], scr.crossingElements[2], 1);
					scr.crossingElements[1].rightIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].rightIndent];
					scr.crossingElements[1].rightSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].rightSurrounding];
				}
				else
				{
					OCQDDQOQQO(scr, scr.crossingElements[3], scr.crossingElements[0], 1);
					scr.crossingElements[1].leftIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].leftIndent];
					scr.crossingElements[1].leftSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[1].leftSurrounding];
				}
			}
			else if (scr.tCrossingLeftRight == 0)
			{
				OCQDDQOQQO(scr, scr.crossingElements[2], scr.crossingElements[1], 0);
				scr.crossingElements[0].rightIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].rightIndent];
				scr.crossingElements[0].rightSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].rightSurrounding];
			}
			else
			{
				OCQDDQOQQO(scr, scr.crossingElements[1], scr.crossingElements[3], 0);
				scr.crossingElements[0].leftIndentV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].leftIndent];
				scr.crossingElements[0].leftSurroundingV3 = scr.tmpSurfaceMeshVecs[scr.crossingElements[0].leftSurrounding];
			}
		}

		public static void OCQDDQOQQO(ERCrossingPrefabs scr, QDOODOQQDQODD el1, QDOODOQQDQODD el2, int leftright)
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
			Vector3 b = OCQCDQCQOQ.OCDCDCDCQD(vector, vector2, vector3, vector4);
			float num2 = Vector3.Distance(vector, b);
			float num3 = Vector3.Distance(vector4, b);
			if (num2 < minIndent || num3 < minIndent)
			{
				Vector3 vector5 = new Vector3(normalized.z, 0f, 0f - normalized.x);
				Vector3 p = vector + vector5 * 1f;
				vector5 = new Vector3(normalized2.z, 0f, 0f - normalized2.x);
				Vector3 p2 = vector4 + vector5 * 1f;
				Vector3 vector6 = OCQCDQCQOQ.OCDCDCDCQD(vector, p, vector4, p2);
				float num4 = minIndent / Mathf.Sin(num * 0.5f * ((float)Math.PI / 180f));
				Vector3 vector7 = vector6 + normalized3 * num4;
				scr.tmpSurfaceMeshVecs[el1.leftIndent] = vector7;
				el1.leftIndentV3 = vector7;
				scr.tmpSurfaceMeshVecs[el2.rightIndent] = vector7;
				el2.rightIndentV3 = vector7;
				vector7 += normalized3 * minSurrounding;
				scr.tmpSurfaceMeshVecs[el1.leftSurrounding] = vector7;
				el1.leftSurroundingV3 = vector7;
				scr.tmpSurfaceMeshVecs[el2.rightSurrounding] = vector7;
				el2.rightSurroundingV3 = vector7;
			}
			else
			{
				Vector3 vector7 = vector + normalized * minIndent;
				scr.tmpSurfaceMeshVecs[el1.leftIndent] = vector7;
				el1.leftIndentV3 = vector7;
				vector7 += normalized3 * minSurrounding;
				scr.tmpSurfaceMeshVecs[el1.leftSurrounding] = vector7;
				el1.leftSurroundingV3 = vector7;
				vector7 = vector4 + normalized2 * minIndent;
				scr.tmpSurfaceMeshVecs[el2.rightIndent] = vector7;
				el2.rightIndentV3 = vector7;
				vector7 += normalized3 * minSurrounding;
				scr.tmpSurfaceMeshVecs[el2.rightSurrounding] = vector7;
				el2.rightSurroundingV3 = vector7;
			}
			if (leftright == 0)
			{
				el1.rightIndentV3 = scr.tmpSurfaceMeshVecs[el1.rightIndent];
				el1.rightSurroundingV3 = scr.tmpSurfaceMeshVecs[el1.rightSurrounding];
			}
			else
			{
				el2.leftIndentV3 = scr.tmpSurfaceMeshVecs[el2.leftIndent];
				el2.leftSurroundingV3 = scr.tmpSurfaceMeshVecs[el2.leftSurrounding];
			}
		}

		public static void ODQQOODCDQ(ERCrossingPrefabs scr)
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
						scr.baseScript.OCCDCQCOQC(ref pos);
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
				for (int i = 0; i < scr.crossingElements.Count; i++)
				{
					scr.crossingElements[i].leftSurroundingV3 = array[scr.crossingElements[i].leftSurrounding];
					scr.crossingElements[i].rightSurroundingV3 = array[scr.crossingElements[i].rightSurrounding];
				}
				return;
			}
			sharedMesh = new Mesh();
			sharedMesh.name = "surface";
			scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
			if (scr.isRoundabout)
			{
				scr.roundaboutScript.OCCQCOQODO();
				scr.roundaboutScript.OOCDCDDOQQ();
				scr.roundaboutScript.OODOQQQCDD();
				return;
			}
			ERCrossings component = scr.gameObject.GetComponent<ERCrossings>();
			if (component != null)
			{
				component.OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
			}
		}

		public static Vector3 GetTerrainPos(Transform transform, Vector3 pos, ERModularBase scr)
		{
			pos = transform.TransformPoint(pos);
			scr.OCCDCQCOQC(ref pos);
			return transform.InverseTransformPoint(pos);
		}
	}
}
