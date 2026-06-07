using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERRoundabouts : MonoBehaviour
	{
		public float roundAboutRadius = 10f;

		public float prevRoundAboutRadius = 10f;

		public float roundAboutResolution = 1f;

		public float prevRoundAboutResolution = 1f;

		public float rDist = 0f;

		public Vector3 raStartPos;

		public float roundaboutWidth = 5f;

		public float prevRoundaboutWidth = 5f;

		public int roadTypeInt = 0;

		public int prevRoadTypeInt = 0;

		public float roadWidth = 5f;

		public float prevRoadWidth = 5f;

		public bool lockLeftRightRoundingRadius = true;

		public float leftRoundingRadius = 2f;

		public float prevLeftRoundingRadius = 2f;

		public float rightRoundingRadius = 2f;

		public float prevRightRoundingRadius = 2f;

		public int roundingSegments = 5;

		public float connectionLength = 5f;

		public float maxRoadWidth = 0f;

		public float maxRoundingRadius = 0f;

		public List<Vector3> meshVecs = new List<Vector3>();

		public List<Vector3> mainRightPoints = new List<Vector3>();

		public List<Vector3> mainCenterPoints = new List<Vector3>();

		public List<Vector3> mainLeftPoints = new List<Vector3>();

		public List<Vector3> OQCDCOQDQQ = new List<Vector3>();

		public List<Vector2> mainRightPointsUVs = new List<Vector2>();

		public List<Vector2> mainCenterPointsUVs = new List<Vector2>();

		public List<Vector2> mainLeftPointsUVs = new List<Vector2>();

		public List<Vector2> OQCDCOQDQQUVs = new List<Vector2>();

		public List<Vector3> innerRoundaboutSidewalkV3 = new List<Vector3>();

		public List<Vector2> innerRoundaboutSidewalUV = new List<Vector2>();

		public List<int> innerRoundaboutSidewalTris = new List<int>();

		public Material innerRoundaboutSidewalkMaterial;

		public List<int> innerRoundaboutSidewalkIntsStart = new List<int>();

		public List<int> innerRoundaboutSidewalkIntsEnd = new List<int>();

		public int innerSidewalkSegments = 0;

		public Vector3 leftPoint;

		public Vector3 leftPoint1;

		public Vector3 rightPoint;

		public Vector3 rightPoint1;

		public Vector3 centerOnLine;

		public Vector3 leftOuterPoint;

		public Vector3 rightOuterPoint;

		public Vector3 pl;

		public Vector3 pr;

		public List<Vector3> edgePoints = new List<Vector3>();

		public int newSegmentInt = -1;

		public int prevNewSegmentInt = -1;

		public List<ERRoundaboutElement> connections = new List<ERRoundaboutElement>();

		public string[] QDOOOQOOQQQQD;

		public int selectedConnection = 0;

		public int activeConnection = 0;

		public int tmpSelectedConnection = 0;

		public int minStartInt = 1;

		public int maxEndInt = 0;

		public int centerInt = 0;

		public int leftOuterInt = 0;

		public int rightOuterInt = 0;

		public List<Vector3> leftOuterSegments = new List<Vector3>();

		public List<Vector3> leftInnerSegments = new List<Vector3>();

		public List<Vector3> rightOuterSegments = new List<Vector3>();

		public List<Vector3> rightInnerSegments = new List<Vector3>();

		public List<Vector2> leftOuterSegmentsUVs = new List<Vector2>();

		public List<Vector2> leftInnerSegmentsUVs = new List<Vector2>();

		public List<Vector2> rightOuterSegmentsUVs = new List<Vector2>();

		public List<Vector2> rightInnerSegmentsUVs = new List<Vector2>();

		public Vector3 outerCenterPoint;

		public bool blendFlag = false;

		public Material mainRoadMaterial;

		public Material roadMaterial;

		public Material connectionMaterial;

		public Material defaultConnectionMaterial;

		public double roadType = 0.0;

		public double roadTypeTimestamp = 0.0;

		public List<Vector3> innerRoundaboutPoints = new List<Vector3>();

		public List<Vector2> innerRoundaboutUVs = new List<Vector2>();

		public float innerSegmentDistance = 0.5f;

		public float innerSidewalkWidth1 = 1.5f;

		public float innerSidewalkWidth2 = 1.5f;

		public float innerCurbHeight = 0.25f;

		public float innerCurbDepth = 0.25f;

		public bool innerBeveledCurb = false;

		public float innerBeveledHeight = 0f;

		public float innerBeveledDepth = 0f;

		public bool innerOuterCurb = false;

		public bool innerRoadSideCurbUVControl = false;

		public bool innerOuterSideCurbUVControl = false;

		public Material innerSidewalkMaterial;

		public List<float> innerSidewalkUVs = new List<float>();

		public List<float> innerCurbUVs = new List<float>();

		public int selectedCorner = 0;

		public int selectedCornerPreset = 0;

		public int selectedSidewalkPreset = 0;

		public string sidewalkPresetName = "";

		public int innerRoundaboutPreset = 0;

		public bool leftFlag = true;

		public bool rightFlag = true;

		private bool ᙃ = false;

		public ERCrossingPrefabs prefabScript;

		public QDOODOQQDQODD connectionElement;

		public ERModularBase baseScript;

		public bool isSceneObject = true;

		public bool guiChanged = true;

		public string crossingName = "";

		public bool activeSidewalks = true;

		public Vector3 testIndentMiddlePoint = Vector3.zero;

		public List<QDQDOOQQDQODD> roadTypesDynamic = new List<QDQDOOQQDQODD>();

		private void Start()
		{
		}

		public bool UpdateToRoadType(QDQDOOQQDQODD sourcePreset)
		{
			if (prefabScript == null)
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: Missing ER Crossing Prefabs script on: " + base.gameObject.name);
				return false;
			}
			bool flag = false;
			List<int> list = new List<int>();
			for (int i = 0; i < connections.Count; i++)
			{
				if (connections[i].roadType == sourcePreset.id && connections[i].roadType != 0.0)
				{
					flag = true;
					prefabScript.crossingElements[i].roadTypeTimestamp = sourcePreset.timestamp;
					if (sourcePreset.roadWidth < maxRoadWidth)
					{
						connections[i].roadWidth = sourcePreset.roadWidth;
					}
					else
					{
						Debug.LogError("EasyRoads3Dv3 Alert: The '" + sourcePreset.roadTypeName + "' road width is too wide for roundabout: " + base.gameObject.name);
					}
					connections[i].roadMaterial = sourcePreset.roadMaterial;
					connections[i].connectionMaterial = sourcePreset.connectionMaterial;
					if (selectedConnection == i && sourcePreset.roadWidth < maxRoadWidth)
					{
						roadWidth = sourcePreset.roadWidth;
						connectionMaterial = sourcePreset.connectionMaterial;
					}
					if (prefabScript.crossingElements[i].connectedRoad != null && prefabScript.crossingElements[i].connectedRoad.roadType == prefabScript.crossingElements[i].roadType)
					{
						list.Add(i);
					}
				}
			}
			if (flag)
			{
				OCCQCOQODO();
				OOCDCDDOQQ();
				if (leftFlag && rightFlag)
				{
					OODOQQQCDD();
					OQCDOOOQDQ();
				}
				else
				{
					Debug.LogError("EasyRoads3Dv3 Alert: The '" + sourcePreset.roadTypeName + "' road width is too wide for roundabout: " + base.gameObject.name);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				ERModularRoad connectedRoad = prefabScript.crossingElements[list[i]].connectedRoad;
				if ((bool)connectedRoad.startPrefabScript && (bool)connectedRoad.endPrefabScript)
				{
					if (connectedRoad.startPrefabScript == prefabScript)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
						if (connectedRoad.roadShape[0].x < 0f)
						{
							connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
						}
					}
				}
				else if (prefabScript.crossingElements[list[i]].connectedMarker == 0)
				{
					connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
					}
				}
				else
				{
					connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
					}
				}
				connectedRoad.OCCCCCCDCC(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			return flag;
		}

		public void ResetData()
		{
			roundAboutRadius = prevRoundAboutRadius;
			roundAboutResolution = prevRoundAboutResolution;
			roundaboutWidth = prevRoundaboutWidth;
			newSegmentInt = prevNewSegmentInt;
			roadWidth = prevRoadWidth;
			leftRoundingRadius = prevLeftRoundingRadius;
			rightRoundingRadius = prevRightRoundingRadius;
			roadTypeInt = prevRoadTypeInt;
			if (connections.Count > 0 && selectedConnection >= 0 && connections.Count > selectedConnection)
			{
				connections[selectedConnection].roadWidth = connections[selectedConnection].prevRoadWidth;
				connections[selectedConnection].centerInt = connections[selectedConnection].prevCenterInt;
				connections[selectedConnection].leftRoundingRadius = connections[selectedConnection].prevLeftRoundingRadius;
				connections[selectedConnection].rightRoundingRadius = connections[selectedConnection].prevRightRoundingRadius;
				connections[selectedConnection].roadType = connections[selectedConnection].prevRoadType;
				connections[selectedConnection].roadTypeTimestamp = connections[selectedConnection].prevTimestamp;
			}
		}

		public void ODCQQCCDCC()
		{
			connections.Add(new ERRoundaboutElement());
			selectedConnection = (selectedCorner = connections.Count - 1);
			QDOOOQOOQQQQD = (prefabScript.QDOOOQOOQQQQD = new string[connections.Count]);
			int num = 0;
			for (int i = 0; i < connections.Count; i++)
			{
				QDOOOQOOQQQQD[i] = (prefabScript.QDOOOQOOQQQQD[i] = "Connection " + (i + 1));
				if (connections[i].rightOuterInt > num)
				{
					num = connections[i].rightOuterInt;
				}
			}
			if (selectedConnection == 0)
			{
				num = 5;
			}
			prefabScript.crossingElements.Add(new QDOODOQQDQODD());
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[prefabScript.crossingElements.Count - 1];
			prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
			connections[selectedConnection].prefabElement = prefabScript.crossingElements.Count - 1;
			connections[selectedConnection].connectionMaterial = defaultConnectionMaterial;
			if (roadMaterial == null)
			{
				roadMaterial = Resources.Load("Materials/roads/road material") as Material;
			}
			connections[selectedConnection].roadMaterial = roadMaterial;
			newSegmentInt = (connections[selectedConnection].centerInt = num + Mathf.RoundToInt((float)(mainCenterPoints.Count - num) / 2f));
			connections[selectedConnection].positionPercentage = (float)newSegmentInt * 1f / ((float)mainLeftPoints.Count * 1f);
			GetConnectionData();
		}

		public void OQCDOOOQDQ()
		{
			if (connections.Count != 0)
			{
				connections[selectedConnection].roadWidth = roadWidth;
				connections[selectedConnection].roundingSegments = roundingSegments;
				connections[selectedConnection].lockLeftRightRoundingRadius = lockLeftRightRoundingRadius;
				connections[selectedConnection].leftRoundingRadius = leftRoundingRadius;
				connections[selectedConnection].rightRoundingRadius = rightRoundingRadius;
				connections[selectedConnection].connectionLength = connectionLength;
				connections[selectedConnection].centerInt = centerInt;
				connections[selectedConnection].outerCenterPoint = outerCenterPoint;
				connections[selectedConnection].leftOuterSegments = leftOuterSegments;
				connections[selectedConnection].leftInnerSegments = leftInnerSegments;
				connections[selectedConnection].rightOuterSegments = rightOuterSegments;
				connections[selectedConnection].rightInnerSegments = rightInnerSegments;
				connections[selectedConnection].leftFlag = leftFlag;
				connections[selectedConnection].rightFlag = rightFlag;
				connections[selectedConnection].blendFlag = blendFlag;
				connections[selectedConnection].connectionMaterial = connectionMaterial;
			}
		}

		public void GetConnectionData()
		{
			roadWidth = connections[selectedConnection].roadWidth;
			roundingSegments = connections[selectedConnection].roundingSegments;
			lockLeftRightRoundingRadius = connections[selectedConnection].lockLeftRightRoundingRadius;
			leftRoundingRadius = connections[selectedConnection].leftRoundingRadius;
			rightRoundingRadius = connections[selectedConnection].rightRoundingRadius;
			centerInt = connections[selectedConnection].centerInt;
			outerCenterPoint = connections[selectedConnection].outerCenterPoint;
			connectionLength = connections[selectedConnection].connectionLength;
			centerInt = connections[selectedConnection].centerInt;
			leftOuterSegments = connections[selectedConnection].leftOuterSegments;
			leftInnerSegments = connections[selectedConnection].leftInnerSegments;
			rightOuterSegments = connections[selectedConnection].rightOuterSegments;
			rightInnerSegments = connections[selectedConnection].rightInnerSegments;
			leftFlag = connections[selectedConnection].leftFlag;
			rightFlag = connections[selectedConnection].rightFlag;
			blendFlag = connections[selectedConnection].blendFlag;
			roadMaterial = connections[selectedConnection].roadMaterial;
			connectionMaterial = connections[selectedConnection].connectionMaterial;
			roadType = connections[selectedConnection].roadType;
			roadTypeInt = GetRoadPresetInt(roadType);
			roadTypeTimestamp = connections[selectedConnection].roadTypeTimestamp;
			newSegmentInt = centerInt;
			UpdateMinMaxInts();
		}

		public void UpdateMinMaxInts()
		{
			if (selectedConnection == 0)
			{
				minStartInt = 0;
			}
			else
			{
				minStartInt = connections[selectedConnection - 1].rightOuterInt;
			}
			if (minStartInt < 0 || minStartInt > mainLeftPoints.Count)
			{
				minStartInt = 0;
			}
			if (selectedConnection == connections.Count - 1)
			{
				maxEndInt = mainLeftPoints.Count - 2;
			}
			else
			{
				maxEndInt = connections[selectedConnection + 1].leftOuterInt;
			}
			if (maxEndInt < 0 || maxEndInt > mainLeftPoints.Count - 1)
			{
				maxEndInt = mainLeftPoints.Count - 1;
			}
			leftOuterInt = connections[selectedConnection].leftOuterInt;
			rightOuterInt = connections[selectedConnection].rightOuterInt;
		}

		public void ChecknewSegmentInt()
		{
			if (newSegmentInt - connections[selectedConnection].intsFromCenter < minStartInt)
			{
				newSegmentInt = minStartInt + connections[selectedConnection].intsFromCenter;
			}
			if (newSegmentInt + connections[selectedConnection].intsFromCenter > maxEndInt)
			{
				newSegmentInt = maxEndInt - connections[selectedConnection].intsFromCenter;
			}
		}

		public int GetRoadPresetInt(double id)
		{
			string text = "";
			int result = 0;
			for (int i = 0; i < baseScript.roadTypes.Count; i++)
			{
				if (baseScript.roadTypes[i].id == id)
				{
					text = baseScript.roadTypes[i].roadTypeName;
					break;
				}
			}
			for (int i = 0; i < roadTypesDynamic.Count; i++)
			{
				if (roadTypesDynamic[i].id == id)
				{
					result = i + 1;
					break;
				}
			}
			return result;
		}

		public void OQQOCQQOOD()
		{
			ERCrossingPrefabs component = base.gameObject.GetComponent<ERCrossingPrefabs>();
			QDOODOQQDQODD qDOODOQQDQODD = component.crossingElements[connections[selectedConnection].prefabElement];
		}

		public void OQOOOCDQQO(ERModularBase scr, int el)
		{
			selectedSidewalkPreset = el;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth1 = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth1;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth2 = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth2;
			prefabScript.sidewalkControlElements[selectedCorner].curbHeight = scr.sidewalkPresets[selectedSidewalkPreset - 1].curbHeight;
			prefabScript.sidewalkControlElements[selectedCorner].curbDepth = scr.sidewalkPresets[selectedSidewalkPreset - 1].curbDepth;
			prefabScript.sidewalkControlElements[selectedCorner].beveledCurb = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledCurb;
			prefabScript.sidewalkControlElements[selectedCorner].beveledHeight = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledHeight;
			prefabScript.sidewalkControlElements[selectedCorner].beveledDepth = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledDepth;
			prefabScript.sidewalkControlElements[selectedCorner].outerCurb = scr.sidewalkPresets[selectedSidewalkPreset - 1].outerCurb;
			prefabScript.sidewalkControlElements[selectedCorner].roadSideCurbUVControl = scr.sidewalkPresets[selectedSidewalkPreset - 1].roadSideCurbUVControl;
			prefabScript.sidewalkControlElements[selectedCorner].outerSideCurbUVControl = scr.sidewalkPresets[selectedSidewalkPreset - 1].outerSideCurbUVControl;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkMaterial = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkMaterial;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkUVs.Clear();
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkUVs.AddRange(scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkUVs);
			prefabScript.sidewalkControlElements[selectedCorner].curbUVs.Clear();
			prefabScript.sidewalkControlElements[selectedCorner].curbUVs.AddRange(scr.sidewalkPresets[selectedSidewalkPreset - 1].curbUVs);
			prefabScript.sidewalkControlElements[selectedCorner].lockUVs = scr.sidewalkPresets[selectedSidewalkPreset - 1].lockUVs;
		}

		public void OCCQCOQODO()
		{
			ᙃ = false;
			if (QDOOOQOOQQQQD.Length != connections.Count)
			{
				QDOOOQOOQQQQD = new string[connections.Count];
				prefabScript.QDOOOQOOQQQQD = new string[connections.Count];
				for (int i = 0; i < connections.Count; i++)
				{
					QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
					prefabScript.QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
				}
				selectedConnection = 0;
			}
			if (selectedConnection >= connections.Count)
			{
				selectedConnection = 0;
			}
			int count = mainLeftPoints.Count;
			mainRightPoints.Clear();
			mainCenterPoints.Clear();
			mainLeftPoints.Clear();
			OQCDCOQDQQ.Clear();
			mainRightPointsUVs.Clear();
			mainCenterPointsUVs.Clear();
			mainLeftPointsUVs.Clear();
			OQCDCOQDQQUVs.Clear();
			innerRoundaboutPoints.Clear();
			int num = Mathf.RoundToInt(2f * roundAboutRadius * (float)Math.PI);
			float num2 = 360f / ((float)num * 1f) * roundAboutResolution;
			Vector3 position = base.transform.position;
			rDist = 0f;
			float num3 = 0f;
			Vector3 zero = Vector3.zero;
			int num4 = 0;
			float num5 = 0f;
			Vector3 zero2;
			Vector3 a = (zero2 = Vector3.zero);
			float num6 = roundaboutWidth * 0.5f;
			while (num3 < 360f + num5)
			{
				zero.x = roundAboutRadius * Mathf.Cos((0f - num3 + num5) * ((float)Math.PI / 180f));
				zero.z = roundAboutRadius * Mathf.Sin((0f - num3 + num5) * ((float)Math.PI / 180f));
				Vector3 normalized = (zero - Vector3.zero).normalized;
				mainLeftPoints.Add(zero + normalized * num6);
				mainRightPoints.Add(zero + -normalized * num6);
				mainCenterPoints.Add(zero);
				mainLeftPointsUVs.Add(new Vector2(0f, num3 * 0.01f));
				mainCenterPointsUVs.Add(new Vector2(0.5f, num3 * 0.01f));
				mainRightPointsUVs.Add(new Vector2(1f, num3 * 0.01f));
				num3 += num2;
				if (num4 == 0)
				{
					zero2 = (raStartPos = zero);
				}
				else
				{
					rDist += Vector3.Distance(a, zero);
				}
				num4++;
				a = zero;
			}
			if (mainLeftPoints[0] != mainLeftPoints[mainLeftPoints.Count - 1])
			{
				mainLeftPoints.Add(mainLeftPoints[0]);
				mainRightPoints.Add(mainRightPoints[0]);
				mainCenterPoints.Add(mainCenterPoints[0]);
				mainLeftPointsUVs.Add(new Vector2(0f, num3 * 0.01f));
				mainCenterPointsUVs.Add(new Vector2(0.5f, num3 * 0.01f));
				mainRightPointsUVs.Add(new Vector2(1f, num3 * 0.01f));
			}
			float num7 = Vector3.Distance(mainLeftPoints[0], Vector3.zero) * 2f;
			maxRoadWidth = 0.5f * num7;
			maxRoundingRadius = (num7 - roadWidth) / 4f;
			if (count != 0 && mainLeftPoints.Count != count)
			{
				float num8 = (float)mainLeftPoints.Count * 1f / ((float)count * 1f);
				for (int i = 0; i < connections.Count; i++)
				{
					if (connections[i].positionPercentage == 0f)
					{
						connections[i].positionPercentage = (float)connections[i].centerInt * 1f / ((float)count * 1f);
					}
					connections[i].centerInt = Mathf.RoundToInt(connections[i].positionPercentage * (float)mainLeftPoints.Count);
					if (i == selectedConnection)
					{
						newSegmentInt = connections[i].centerInt;
					}
				}
			}
			innerRoundaboutSidewalkV3.Clear();
			innerRoundaboutSidewalUV.Clear();
			innerRoundaboutSidewalTris.Clear();
			innerRoundaboutSidewalkIntsStart.Clear();
			innerRoundaboutSidewalkIntsEnd.Clear();
			if (innerRoundaboutPreset != 0)
			{
				ERRoundaboutsFunctions.BuildInnerRoundaboutSidewalkData(this, baseScript, mainRightPoints, ref innerRoundaboutSidewalkV3, ref innerRoundaboutSidewalUV, ref innerRoundaboutSidewalTris, ref innerSidewalkSegments);
			}
		}

		public void OOCDCDDOQQ()
		{
			if (QDOOOQOOQQQQD.Length != connections.Count)
			{
				QDOOOQOOQQQQD = new string[connections.Count];
				prefabScript.QDOOOQOOQQQQD = new string[connections.Count];
				for (int i = 0; i < connections.Count; i++)
				{
					QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
					prefabScript.QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
				}
				selectedConnection = 0;
			}
			if (selectedConnection >= connections.Count)
			{
				selectedConnection = 0;
			}
			centerInt = newSegmentInt;
			OQCDOOOQDQ();
			activeConnection = selectedConnection;
			leftFlag = (rightFlag = true);
			for (int j = 0; j < connections.Count; j++)
			{
				if (connections[j].roadMaterial == null)
				{
				}
				OQOQQCDODO(j);
				if (!connections[j].leftFlag)
				{
					leftFlag = false;
				}
				if (!connections[j].rightFlag)
				{
					rightFlag = false;
				}
			}
			if (leftFlag && rightFlag)
			{
				ERRoundaboutsFunctions.OCQCDODODO(this);
			}
		}

		public void OQOQQCDODO(int currentIndex)
		{
			if (connections.Count == 0)
			{
				return;
			}
			connections[currentIndex].leftSidewalkV3.Clear();
			connections[currentIndex].rightSidewalkV3.Clear();
			connections[currentIndex].leftSidewalkUV.Clear();
			connections[currentIndex].rightSidewalkUV.Clear();
			connections[currentIndex].leftSidewalkTris.Clear();
			connections[currentIndex].rightSidewalkTris.Clear();
			connections[currentIndex].roadConnectionTris.Clear();
			connections[currentIndex].leftSidewalkSourceVecs.Clear();
			connections[currentIndex].rightSidewalkSourceVecs.Clear();
			connections[currentIndex].rightIndentvecs.Clear();
			connections[currentIndex].rightSurroundingvecs.Clear();
			connections[currentIndex].leftIndentvecs.Clear();
			connections[currentIndex].leftSurroundingvecs.Clear();
			connections[currentIndex].innerRoundaboutPoints.Clear();
			connections[currentIndex].leftFlag = true;
			connections[currentIndex].rightFlag = true;
			int num = connections[currentIndex].centerInt;
			int num2 = connections[currentIndex].leftOuterInt;
			int num3 = connections[currentIndex].rightOuterInt;
			if (prefabScript.sidewalkControlElements.Count < connections.Count)
			{
				for (int i = prefabScript.sidewalkControlElements.Count; i < connections.Count; i++)
				{
					prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
				}
			}
			float num4 = connections[currentIndex].roadWidth + 2f * connections[currentIndex].leftRoundingRadius;
			float num5 = 0f;
			int num6 = 1;
			bool flag = true;
			while (num5 < num4)
			{
				if (connections[currentIndex].centerInt - num6 < 0)
				{
					rightFlag = (connections[currentIndex].rightFlag = false);
					flag = false;
					return;
				}
				if (connections[currentIndex].centerInt + num6 >= mainLeftPoints.Count)
				{
					leftFlag = (connections[currentIndex].leftFlag = false);
					flag = false;
					return;
				}
				leftOuterPoint = mainLeftPoints[connections[currentIndex].centerInt - num6];
				rightOuterPoint = mainLeftPoints[connections[currentIndex].centerInt + num6];
				num5 = Vector3.Distance(leftOuterPoint, rightOuterPoint);
				if (num5 > num4)
				{
					break;
				}
				num6++;
				if (connections[currentIndex].centerInt - num6 <= 0)
				{
					leftFlag = (connections[currentIndex].leftFlag = false);
					Debug.Log("connection " + currentIndex + " cannot be updated, move the position forward");
					flag = false;
					ResetData();
					break;
				}
				if (newSegmentInt + num6 >= mainLeftPoints.Count - 1)
				{
					rightFlag = (connections[currentIndex].rightFlag = false);
					Debug.Log("connection " + currentIndex + " cannot be updated, move the position backwards");
					flag = false;
					ResetData();
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			centerOnLine = Vector3.Lerp(leftOuterPoint, rightOuterPoint, 0.5f);
			Vector3 normalized = (rightOuterPoint - leftOuterPoint).normalized;
			leftPoint = centerOnLine - normalized * 0.5f * num4;
			rightPoint = centerOnLine + normalized * 0.5f * num4;
			normalized = (mainLeftPoints[connections[currentIndex].centerInt] - mainCenterPoints[connections[currentIndex].centerInt]).normalized;
			pl = leftPoint + normalized * 15f;
			pr = rightPoint + normalized * 15f;
			Vector3 p = mainLeftPoints[connections[currentIndex].centerInt - num6];
			Vector3 p2 = mainLeftPoints[connections[currentIndex].centerInt - num6 + 1];
			leftPoint1 = OCDCDCDCQD(leftPoint, pl, p, p2);
			Vector3 p3 = mainLeftPoints[connections[currentIndex].centerInt + num6];
			Vector3 p4 = mainLeftPoints[connections[currentIndex].centerInt + num6 - 1];
			rightPoint1 = OCDCDCDCQD(rightPoint, pr, p3, p4);
			if (currentIndex == activeConnection)
			{
				edgePoints.Clear();
				edgePoints.Add(leftPoint1);
				edgePoints.Add(rightPoint1);
			}
			connections[currentIndex].centerInt = connections[currentIndex].centerInt;
			connections[currentIndex].leftOuterInt = connections[currentIndex].centerInt - num6;
			connections[currentIndex].rightOuterInt = connections[currentIndex].centerInt + num6;
			connections[currentIndex].intsFromCenter = num6;
			if (selectedConnection == currentIndex && connections[currentIndex].centerInt != connections[currentIndex].prevCenterInt)
			{
				connections[currentIndex].positionPercentage = (float)connections[currentIndex].centerInt * 1f / ((float)mainLeftPoints.Count * 1f);
			}
			connections[currentIndex].outerCenterPoint = mainLeftPoints[connections[currentIndex].centerInt];
			for (int i = 0; i < connections.Count; i++)
			{
				if (i != currentIndex)
				{
					if (connections[currentIndex].leftOuterInt < connections[i].rightOuterInt + 1 && connections[currentIndex].leftOuterInt >= connections[i].leftOuterInt)
					{
						connections[currentIndex].leftFlag = false;
					}
					if (connections[currentIndex].rightOuterInt <= connections[i].rightOuterInt && connections[currentIndex].rightOuterInt >= connections[i].leftOuterInt)
					{
						connections[currentIndex].rightFlag = false;
					}
				}
			}
			if (connections[currentIndex].leftOuterInt < 0)
			{
				leftFlag = (connections[currentIndex].leftFlag = false);
			}
			if (connections[currentIndex].rightOuterInt >= mainLeftPoints.Count)
			{
				rightFlag = (connections[currentIndex].rightFlag = false);
			}
			for (int i = connections[currentIndex].leftOuterInt + 1; i < connections[currentIndex].rightOuterInt; i++)
			{
				connections[currentIndex].innerRoundaboutPoints.Add(mainLeftPoints[i]);
			}
			if (!connections[currentIndex].leftFlag || !connections[currentIndex].rightFlag)
			{
				if (currentIndex == selectedConnection)
				{
					newSegmentInt = num;
				}
				connections[currentIndex].centerInt = num;
				connections[currentIndex].leftOuterInt = num2;
				connections[currentIndex].rightOuterInt = num3;
				return;
			}
			ODDDQDOCOD(ref connections[currentIndex].leftOuterSegments, ref connections[currentIndex].leftInnerSegments, -1, connections[currentIndex].centerInt - num6, leftPoint1, rightPoint1, normalized, currentIndex);
			ODDDQDOCOD(ref connections[currentIndex].rightOuterSegments, ref connections[currentIndex].rightInnerSegments, 1, connections[currentIndex].centerInt + num6, leftPoint1, rightPoint1, normalized, currentIndex);
			ERRoundaboutsFunctions.OOODCQOQOQ(this, currentIndex);
			ODDDODDCQC(currentIndex);
			ERRoundaboutsFunctions.OCCDCCDCOO(this, currentIndex);
			connections[currentIndex].sceneSelectionV3 = Vector3.Lerp(connections[currentIndex].leftOuterSegments[connections[currentIndex].leftOuterSegments.Count - 1], connections[currentIndex].rightOuterSegments[connections[currentIndex].rightOuterSegments.Count - 1], 0.5f);
			float num7 = Vector3.Angle(Vector3.forward, mainLeftPoints[connections[currentIndex].centerInt]);
			if (OCQCDQCQOQ.OCQDCQCOQQ(Vector3.forward, mainLeftPoints[connections[currentIndex].centerInt], Vector3.up) == -1f)
			{
				num7 = 360f - num7;
			}
			prefabScript.crossingElements[currentIndex].connectionAngle = num7;
		}

		public void ODDDQDOCOD(ref List<Vector3> OQCDCOQDQQ, ref List<Vector3> innerSegmentPoints, int leftRight, int startElement, Vector3 leftPoint, Vector3 rightPoint, Vector3 forward, int currentIndex)
		{
			OQCDCOQDQQ.Clear();
			innerSegmentPoints.Clear();
			float num = roundAboutRadius + 0.5f * roundaboutWidth;
			Vector3 vector = mainLeftPoints[startElement];
			Vector3 vector2 = mainLeftPoints[startElement + leftRight * -1];
			Vector3 normalized = (vector2 - vector).normalized;
			if (leftRight == 1)
			{
				normalized = (vector - vector2).normalized;
			}
			Vector3 normalized2 = (rightPoint - leftPoint).normalized;
			float num2 = Vector3.Angle(normalized, normalized2);
			float num3 = 90f / ((float)connections[currentIndex].roundingSegments * 1f);
			float num4 = (90f - num2) / ((float)connections[currentIndex].roundingSegments * 1f);
			num4 = num3;
			if (leftRight == 1)
			{
				num4 *= -1f;
			}
			float num5 = connections[currentIndex].leftRoundingRadius * (num2 / 90f + 1f);
			centerOnLine = Vector3.Lerp(rightPoint, leftPoint, 0.5f);
			Vector3 vector3 = centerOnLine - normalized2 * (0.5f * connections[currentIndex].roadWidth + num5);
			if (leftRight == 1)
			{
				vector3 = centerOnLine + normalized2 * (0.5f * connections[currentIndex].roadWidth + num5);
			}
			Vector3 pivot = vector3 + forward * num5;
			vector3 = centerOnLine - normalized2 * 0.5f * connections[currentIndex].roadWidth;
			if (leftRight == 1)
			{
				vector3 = centerOnLine + normalized2 * 0.5f * connections[currentIndex].roadWidth;
			}
			Vector3 vector4 = vector3 + forward * num5;
			OQCDCOQDQQ.Add(vector4);
			float num6 = 10000f;
			float num7 = 10000f;
			Vector3 vector5;
			for (int i = 1; i < connections[currentIndex].roundingSegments - 1; i++)
			{
				vector5 = OCQDOQQQOD(vector4, pivot, Quaternion.Euler(0f, num4 * (float)i, 0f));
				num6 = Vector3.Distance(Vector3.zero, vector5);
				if (num6 > num7)
				{
					break;
				}
				num7 = num6;
				OQCDCOQDQQ.Add(vector5);
				if (num6 < num)
				{
					break;
				}
			}
			Vector3 normalized3 = OQCDCOQDQQ[OQCDCOQDQQ.Count - 1].normalized;
			vector5 = Vector3.zero + normalized3 * num;
			OQCDCOQDQQ[OQCDCOQDQQ.Count - 1] = vector5;
			int num8 = connections[currentIndex].leftOuterInt - 2;
			if (num8 < 0)
			{
				num8 = 0;
			}
			for (int j = num8; j < mainLeftPoints.Count - 1; j++)
			{
				num6 = Vector3.Distance(mainLeftPoints[j], mainLeftPoints[j + 1]);
				num7 = Vector3.Distance(mainLeftPoints[j], vector5);
				if (num7 < num6)
				{
					if (leftRight == -1)
					{
						connections[currentIndex].leftOuterInt = j;
					}
					else
					{
						connections[currentIndex].rightOuterInt = j + 1;
					}
					break;
				}
			}
			if (leftRight == -1)
			{
				OQCDCOQDQQ.Reverse();
			}
			else
			{
				OQCDCOQDQQ.Reverse();
			}
			Vector3 normalized4 = (leftPoint - mainLeftPoints[startElement]).normalized;
			if (leftRight == 1)
			{
				normalized4 = (rightPoint - mainLeftPoints[startElement]).normalized;
			}
			normalized4 = new Vector3(normalized4.z, 0f, 0f - normalized4.x);
			if (leftRight == -1)
			{
				innerSegmentPoints.Add(leftPoint + normalized4 * innerSegmentDistance);
			}
			else
			{
				innerSegmentPoints.Add(rightPoint + -normalized4 * innerSegmentDistance);
			}
			for (int i = 1; i < OQCDCOQDQQ.Count - 1; i++)
			{
				normalized4 = (OQCDCOQDQQ[i] - OQCDCOQDQQ[i - 1]).normalized;
				normalized4 = new Vector3(normalized4.z, 0f, 0f - normalized4.x);
				if (leftRight == -1)
				{
					innerSegmentPoints.Add(OQCDCOQDQQ[i] + normalized4 * innerSegmentDistance);
				}
				else
				{
					innerSegmentPoints.Add(OQCDCOQDQQ[i] + -normalized4 * innerSegmentDistance);
				}
			}
			vector5 = OQCDCOQDQQ[OQCDCOQDQQ.Count - 1];
			vector4 = vector5 + forward * roundAboutResolution;
			normalized4 = (vector4 - OQCDCOQDQQ[OQCDCOQDQQ.Count - 1]).normalized;
			normalized4 = new Vector3(normalized4.z, 0f, 0f - normalized4.x);
			if (leftRight == -1)
			{
				innerSegmentPoints.Add(OQCDCOQDQQ[OQCDCOQDQQ.Count - 1] + normalized4 * innerSegmentDistance);
			}
			else
			{
				innerSegmentPoints.Add(OQCDCOQDQQ[OQCDCOQDQQ.Count - 1] + -normalized4 * innerSegmentDistance);
			}
			OQCDCOQDQQ.Add(vector4);
			innerSegmentPoints.Add(Vector3.zero);
		}

		public void ODDDODDCQC(int currentIndex)
		{
			connections[currentIndex].leftOuterSegmentsUVs.Clear();
			connections[currentIndex].rightOuterSegmentsUVs.Clear();
			connections[currentIndex].innerRoundaboutUVs.Clear();
			Vector3 vA = connections[currentIndex].leftOuterSegments[connections[currentIndex].leftOuterSegments.Count - 1];
			Vector3 vB = connections[currentIndex].rightOuterSegments[connections[currentIndex].rightOuterSegments.Count - 1];
			Vector3 a = OOCDOQCOCD.OQQQDCODQD(vA, vB, connections[currentIndex].leftOuterSegments[0]);
			float num = Vector3.Distance(a, connections[currentIndex].leftOuterSegments[0]);
			Vector3 vector = connections[currentIndex].rightOuterSegments[0];
			Vector3 vector2 = connections[currentIndex].leftOuterSegments[0];
			float num2 = Vector3.Distance(vector, vector2);
			for (int i = 0; i < connections[currentIndex].leftOuterSegments.Count; i++)
			{
				a = OOCDOQCOCD.OQQQDCODQD(vA, vB, connections[currentIndex].leftOuterSegments[i]);
				float y = Vector3.Distance(a, connections[currentIndex].leftOuterSegments[i]) / num;
				a = OOCDOQCOCD.OQQQDCODQD(vector, vector2, connections[currentIndex].leftOuterSegments[i]);
				float num3 = Vector3.Distance(a, connections[currentIndex].leftOuterSegments[i]) / num2;
				connections[currentIndex].leftOuterSegmentsUVs.Add(new Vector2(1f, y));
			}
			for (int i = 0; i < connections[currentIndex].rightOuterSegments.Count; i++)
			{
				a = OOCDOQCOCD.OQQQDCODQD(vA, vB, connections[currentIndex].rightOuterSegments[i]);
				float y = Vector3.Distance(a, connections[currentIndex].rightOuterSegments[i]) / num;
				a = OOCDOQCOCD.OQQQDCODQD(vector, vector2, connections[currentIndex].rightOuterSegments[i]);
				float num3 = Vector3.Distance(a, connections[currentIndex].rightOuterSegments[i]) / num2;
				connections[currentIndex].rightOuterSegmentsUVs.Add(new Vector2(0f, y));
			}
			for (int i = 0; i < connections[currentIndex].innerRoundaboutPoints.Count; i++)
			{
				a = OOCDOQCOCD.OQQQDCODQD(vA, vB, connections[currentIndex].innerRoundaboutPoints[i]);
				float y = Vector3.Distance(a, connections[currentIndex].innerRoundaboutPoints[i]) / num;
				a = OOCDOQCOCD.OQQQDCODQD(vector, vector2, connections[currentIndex].innerRoundaboutPoints[i]);
				float num3 = Vector3.Distance(a, vector) / num2;
				connections[currentIndex].innerRoundaboutUVs.Add(new Vector2(num3, y));
			}
		}

		public void OODOQQQCDD()
		{
			if (base.gameObject.GetComponent<MeshFilter>() == null)
			{
				base.gameObject.AddComponent<MeshFilter>();
			}
			if (base.gameObject.GetComponent<MeshRenderer>() == null)
			{
				base.gameObject.AddComponent<MeshRenderer>();
			}
			if (base.gameObject.GetComponent<MeshCollider>() == null)
			{
				base.gameObject.AddComponent<MeshCollider>();
			}
			Mesh mesh;
			if (base.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (base.gameObject.GetComponent<MeshRenderer>().sharedMaterial == null)
			{
				if (mainRoadMaterial == null)
				{
					mainRoadMaterial = Resources.Load("Materials/roundabouts/roundabout 2 lane") as Material;
				}
				base.gameObject.GetComponent<MeshRenderer>().sharedMaterial = mainRoadMaterial;
			}
			if (defaultConnectionMaterial == null)
			{
				defaultConnectionMaterial = Resources.Load("Materials/roads/road material") as Material;
			}
			meshVecs = new List<Vector3>();
			List<Vector2> meshUVs = new List<Vector2>();
			for (int i = 0; i < mainRightPoints.Count; i++)
			{
				meshVecs.Add(mainLeftPoints[i]);
				meshVecs.Add(mainCenterPoints[i]);
				meshVecs.Add(mainRightPoints[i]);
				meshUVs.Add(mainLeftPointsUVs[i]);
				meshUVs.Add(mainCenterPointsUVs[i]);
				meshUVs.Add(mainRightPointsUVs[i]);
			}
			List<int> fullTris = new List<int>();
			List<Vector3> connectionVecs = new List<Vector3>();
			List<Vector2> connectionUVs = new List<Vector2>();
			List<int> connectionTris = new List<int>();
			List<List<int>> triList = new List<List<int>>();
			List<Material> materialList = new List<Material>();
			materialList.Add(mainRoadMaterial);
			OOCDOQCOCD.OQCOCOQQCO(connections, mainLeftPoints, ref meshVecs, ref meshUVs, ref fullTris);
			triList.Add(fullTris);
			if (connections.Count > 0)
			{
				OOCDOQCOCD.OCODDQQQQC(connections, meshVecs, meshVecs.Count, ref connectionVecs, ref connectionUVs, ref connectionTris, ref triList, ref materialList);
			}
			meshUVs.AddRange(connectionUVs);
			ODQQCQQQQD.OQOQOCQOCD(this, ref meshVecs, ref meshUVs, ref triList, ref materialList);
			if (innerRoundaboutPreset != 0)
			{
				ODQQCQQQQD.ODOCQDDQDQ(this, innerRoundaboutSidewalkV3, innerRoundaboutSidewalUV, innerRoundaboutSidewalTris, ref meshVecs, ref meshUVs, ref triList, ref materialList);
			}
			mesh.Clear();
			mesh.subMeshCount = triList.Count;
			mesh.vertices = meshVecs.ToArray();
			mesh.uv = meshUVs.ToArray();
			mesh.uv2 = meshUVs.ToArray();
			mesh.tangents = new Vector4[mesh.vertices.Length];
			for (int i = 0; i < triList.Count; i++)
			{
				mesh.SetTriangles(triList[i].ToArray(), i);
			}
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			mesh.normals = ERSideWalkVecs.ODDODCQQCC(this, mesh.normals);
			OCQQDQQCQQ.OOCCQOQQQC(mesh);
			base.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
			base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = materialList.ToArray();
			prefabScript.isRoundabout = true;
			prefabScript.roundaboutScript = this;
			prefabScript.meshVecs = (prefabScript.tmpMeshVecs = (prefabScript.tmpFullMeshVecs = (prefabScript.fullMeshVecs = meshVecs.ToArray())));
			for (int i = 0; i < connections.Count; i++)
			{
				if (connections[i].leftFlag && connections[i].rightFlag)
				{
					if (prefabScript.crossingElements.Count < i + 1)
					{
						prefabScript.crossingElements.Add(new QDOODOQQDQODD());
						connections[i].prefabElement = prefabScript.crossingElements.Count - 1;
					}
					if (prefabScript.sidewalkControlElements.Count < i + 1)
					{
						prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
					}
					QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[i];
					qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = connections[i].centerPoint);
					qDOODOQQDQODD.controlPointV3 = connections[i].outerCenterPoint;
					ODQDCQOQQC(i, connections[i].connectionVecInts, connections[i].roadShapeUVY, connections[i].leftSidewalkTris, connections[i].rightSidewalkTris, 0);
					OQDQDQOQDO(meshVecs, prefabScript.crossingElements[i].connectionVecInts, ref prefabScript.crossingElements[i].roadShapeVecs, connections[i].roadShapeVecs, connections[i].leftSidewalkV3, connections[i].rightSidewalkV3, i, 0);
					prefabScript.crossingElements[i].roadShapeVecsString = ERCrossings.GetRoadShapeVecString(prefabScript.crossingElements[i].roadShapeVecs, prefabScript.crossingElements[i].sidewalkLeftVecs, prefabScript.crossingElements[i].sidewalkRightVecs, ref prefabScript.crossingElements[i].roadShapeMatchCount);
					OQCQCQDDCD(i, connections[i].roadMaterial, connections[i].leftSidewalkV3.Count, connections[i].rightSidewalkV3.Count);
					qDOODOQQDQODD.roadMaterial = connections[i].roadMaterial;
					qDOODOQQDQODD.blendCornerPointInts = connections[i].blendCornerPointInts;
					qDOODOQQDQODD.blendCornerPointWeights = connections[i].blendCornerPointWeights;
					qDOODOQQDQODD.alignmentHandleVecRotationGizmo = mainLeftPoints[connections[i].centerInt];
					qDOODOQQDQODD.roadType = connections[i].roadType;
					qDOODOQQDQODD.roadTypeTimestamp = connections[i].roadTypeTimestamp;
					OOCCQDOQQC(i);
					prefabScript.sidewalkControlElements[i].crossingElementRightIndex = i;
					if (i == 0)
					{
						prefabScript.sidewalkControlElements[i].crossingElementLeftIndex = connections.Count - 1;
					}
					else
					{
						prefabScript.sidewalkControlElements[i].crossingElementLeftIndex = i - 1;
					}
				}
			}
			OQQCQCQOCC();
			prefabScript.OCODQQCQQO();
			prevRoundAboutRadius = roundAboutRadius;
			prevRoundAboutResolution = roundAboutResolution;
			prevRoundaboutWidth = roundaboutWidth;
			prevNewSegmentInt = newSegmentInt;
			prevRoadWidth = roadWidth;
			prevLeftRoundingRadius = leftRoundingRadius;
			prevRightRoundingRadius = rightRoundingRadius;
			prevRoadTypeInt = roadTypeInt;
			if (connections.Count > 0 && selectedConnection >= 0 && connections.Count > selectedConnection)
			{
				connections[selectedConnection].prevRoadWidth = connections[selectedConnection].roadWidth;
				connections[selectedConnection].prevCenterInt = connections[selectedConnection].centerInt;
				connections[selectedConnection].prevLeftRoundingRadius = connections[selectedConnection].leftRoundingRadius;
				connections[selectedConnection].prevRightRoundingRadius = connections[selectedConnection].rightRoundingRadius;
				connections[selectedConnection].prevRoadType = connections[selectedConnection].roadType;
			}
			UpdateMinMaxInts();
		}

		public void ODQDCQOQQC(int el, List<int> trIntArray, List<float> uvArray, List<List<int>> leftSidewalkIntArray, List<List<int>> rightSidewalkIntArray, int startend)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			qDOODOQQDQODD.connectionVecInts.Clear();
			qDOODOQQDQODD.blendCornerPointInts.Clear();
			qDOODOQQDQODD.blendCornerPointWeights.Clear();
			qDOODOQQDQODD.roadShapeUVY.Clear();
			QDOQDSQOOQDDD qDOQDSQOOQDDD = null;
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[el];
			qDOQDSQOOQDDD = ((el >= connections.Count - 1) ? prefabScript.sidewalkControlElements[0] : prefabScript.sidewalkControlElements[el + 1]);
			qDOODOQQDQODD.sidewalkLeftUVY.Clear();
			qDOODOQQDQODD.sidewalkLeftConnectionVecInts.Clear();
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				for (int i = 0; i < leftSidewalkIntArray.Count; i++)
				{
					qDOODOQQDQODD.sidewalkLeftConnectionVecInts.Add(leftSidewalkIntArray[i][0]);
				}
				qDOODOQQDQODD.sidewalkLeftConnectionVecInts.Reverse();
				qDOODOQQDQODD.sidewalkLeftUVY.AddRange(qDOQDSQOOQDDD.sidewalkUVs);
				qDOODOQQDQODD.sidewalkLeftUVY.Reverse();
			}
			qDOODOQQDQODD.connectionVecInts.Add(trIntArray[0]);
			qDOODOQQDQODD.connectionVecInts.Add(trIntArray[trIntArray.Count - 1]);
			qDOODOQQDQODD.roadShapeUVY.Add(uvArray[0]);
			qDOODOQQDQODD.roadShapeUVY.Add(uvArray[uvArray.Count - 1]);
			qDOODOQQDQODD.sidewalkRightUVY.Clear();
			qDOODOQQDQODD.sidewalkRightConnectionVecInts.Clear();
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				for (int i = 0; i < rightSidewalkIntArray.Count; i++)
				{
					qDOODOQQDQODD.sidewalkRightConnectionVecInts.Add(rightSidewalkIntArray[i][0]);
				}
				qDOODOQQDQODD.sidewalkRightUVY.AddRange(qDOQDSQOOQDDD2.sidewalkUVs);
			}
			qDOODOQQDQODD.connectionVecInts.InsertRange(0, qDOODOQQDQODD.sidewalkLeftConnectionVecInts);
			qDOODOQQDQODD.connectionVecInts.AddRange(qDOODOQQDQODD.sidewalkRightConnectionVecInts);
			qDOODOQQDQODD.fullConnectionVecInts = new List<int>(qDOODOQQDQODD.connectionVecInts);
			qDOODOQQDQODD.leftInt = 0;
			qDOODOQQDQODD.leftIntFull = 0;
			qDOODOQQDQODD.rightInt = qDOODOQQDQODD.connectionVecInts.Count - 1;
			qDOODOQQDQODD.rightIntFull = qDOODOQQDQODD.fullConnectionVecInts.Count - 1;
		}

		public void OQDQDQOQDO(List<Vector3> meshVecs, List<int> connectionVecInts, ref List<Vector2> roadShapeVecs, List<Vector2> vecArrays, List<List<Vector3>> leftSidewalkArray, List<List<Vector3>> rightSidewalkArray, int connectionElement, int startend)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[connectionElement];
			roadShapeVecs.Clear();
			qDOODOQQDQODD.sidewalkLeftVecs.Clear();
			qDOODOQQDQODD.sidewalkRightVecs.Clear();
			Vector3 zero;
			Vector3 vector = (zero = Vector3.zero);
			Vector3 vector2 = leftSidewalkArray[0][0];
			Vector3 centerPoint = connections[connectionElement].centerPoint;
			float num = Vector3.Distance(leftSidewalkArray[0][0], rightSidewalkArray[0][0]) * 0.5f;
			for (int i = 0; i < connectionVecInts.Count - 1; i++)
			{
			}
			List<Vector3> list = new List<Vector3>();
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				for (int i = 0; i < leftSidewalkArray.Count; i++)
				{
					list.Add(leftSidewalkArray[i][0]);
				}
				list.Reverse();
				vector = list[0];
				vector2 = vector;
				vector2.y = 0f;
				num = Vector3.Distance(vector2, centerPoint);
				ERCrossings.OCCCQDQOOD(list, ref qDOODOQQDQODD.sidewalkLeftVecs, centerPoint, vector2, num);
			}
			list.Clear();
			list.Add(leftSidewalkArray[0][0]);
			list.Add(rightSidewalkArray[0][0]);
			if (vector == Vector3.zero)
			{
				vector = list[0];
			}
			zero = list[list.Count - 1];
			ERCrossings.OCCCQDQOOD(list, ref roadShapeVecs, centerPoint, vector2, num);
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				list.Clear();
				for (int i = 0; i < rightSidewalkArray.Count; i++)
				{
					list.Add(rightSidewalkArray[i][0]);
				}
				zero = list[list.Count - 1];
				ERCrossings.OCCCQDQOOD(list, ref qDOODOQQDQODD.sidewalkRightVecs, centerPoint, vector2, num);
			}
			vector.y = 0f;
			zero.y = 0f;
			float num2 = Vector3.Distance(vector, zero);
			qDOODOQQDQODD.centerPointPercentage = num / num2;
		}

		public void OQCQCQDDCD(int el, Material roadMaterial, int leftVecCount, int rightVecCount)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			qDOQDSQOOQDDD2 = ((el >= connections.Count - 1) ? prefabScript.sidewalkControlElements[0] : prefabScript.sidewalkControlElements[el + 1]);
			qDOODOQQDQODD.roadMaterial = roadMaterial;
			List<Material> list = new List<Material>();
			List<int> list2 = new List<int>();
			list.Add(roadMaterial);
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				if (list[0] != qDOQDSQOOQDDD2.sidewalkMaterial)
				{
					list.Add(qDOQDSQOOQDDD2.sidewalkMaterial);
					for (int i = 0; i < leftVecCount; i++)
					{
						list2.Add(1);
					}
				}
				else
				{
					for (int i = 0; i < leftVecCount; i++)
					{
						list2.Add(0);
					}
				}
			}
			list2.Add(0);
			list2.Add(0);
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				if (list[0] != qDOQDSQOOQDDD.sidewalkMaterial && qDOQDSQOOQDDD2.sidewalkMaterial != qDOQDSQOOQDDD.sidewalkMaterial && qDOODOQQDQODD.includeLeftSidewalk)
				{
					list.Add(qDOQDSQOOQDDD.sidewalkMaterial);
					for (int i = 0; i < rightVecCount; i++)
					{
						list2.Add(2);
					}
				}
				else if (list[0] == qDOQDSQOOQDDD.sidewalkMaterial)
				{
					for (int i = 0; i < rightVecCount; i++)
					{
						list2.Add(0);
					}
				}
				else if (qDOQDSQOOQDDD2.sidewalkMaterial == qDOQDSQOOQDDD.sidewalkMaterial || !qDOODOQQDQODD.includeLeftSidewalk)
				{
					if (!qDOODOQQDQODD.includeLeftSidewalk)
					{
						list.Add(qDOQDSQOOQDDD.sidewalkMaterial);
					}
					for (int i = 0; i < rightVecCount; i++)
					{
						list2.Add(1);
					}
				}
			}
			qDOODOQQDQODD.roadMaterials = list.ToArray();
			qDOODOQQDQODD.roadShapeMaterialInts.Clear();
			qDOODOQQDQODD.roadShapeMaterialInts.AddRange(list2);
		}

		public void OQQCQCQOCC()
		{
		}

		public void OOCCQDOQQC(int el)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			qDOQDSQOOQDDD2 = ((el >= connections.Count - 1) ? prefabScript.sidewalkControlElements[0] : prefabScript.sidewalkControlElements[el + 1]);
			float num = roundAboutRadius + 0.5f * roundaboutWidth;
			float num2 = 0f;
			Vector3 prevVec = Vector3.zero;
			Vector3 firstIndent = Vector3.zero;
			Vector3 vector = Vector3.zero;
			List<Vector3> list = new List<Vector3>();
			if (baseScript == null)
			{
				baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			}
			float num3 = num + baseScript.minIndent;
			float num4 = num3 + baseScript.minSurrounding;
			float num5 = baseScript.minIndent;
			Vector3 vector2 = connections[el].leftSidewalkV3[0][connections[el].leftSidewalkV3[0].Count - 1];
			Vector3 vector3 = connections[el].rightSidewalkV3[0][connections[el].rightSidewalkV3[0].Count - 1];
			if (el == 0 || el == connections.Count - 1)
			{
				int num6 = connections[0].leftOuterInt;
				int num7 = mainLeftPoints.Count - connections[connections.Count - 1].rightOuterInt;
				int num8 = Mathf.RoundToInt((float)(num6 + num7) * 0.5f);
				num8 = ((num8 >= num6) ? (mainLeftPoints.Count - (num8 - num6)) : (num6 - num8));
				if (num8 >= mainLeftPoints.Count)
				{
					num8 = mainLeftPoints.Count - 1;
				}
				if (el == 0)
				{
					vector3 = mainLeftPoints[num8];
				}
				else
				{
					vector2 = mainLeftPoints[num8];
				}
			}
			if (qDOQDSQOOQDDD.renderFlag)
			{
				num3 += qDOQDSQOOQDDD.sidewalkWidth1;
				num2 = qDOQDSQOOQDDD.sidewalkWidth1;
				num5 += qDOQDSQOOQDDD.sidewalkWidth1;
			}
			num4 = num3 + baseScript.minSurrounding;
			list.AddRange(connections[el].rightSidewalkV3[0]);
			connections[el].rightIndentBorderInt = -1;
			for (int i = 0; i < list.Count; i++)
			{
				Vector3 vector4 = ((i == 0) ? (list[i + 1] - list[i]).normalized : ((i >= list.Count - 1) ? (list[i] - list[i - 1]).normalized : (list[i + 1] - list[i - 1]).normalized));
				vector4 = new Vector3(vector4.z, 0f, 0f - vector4.x).normalized;
				Vector3 vec = list[i] + vector4 * num5;
				if (OOOCCOQDCO(i, num3, prevVec, boolCheck: true, ref vec, ref connections[el].rightIndentBorderInt))
				{
					if (i == 0 && connections[el].rightIndentBorderInt == 0)
					{
						vec = list[i].normalized * num3;
						vec += vector4 * num5;
					}
					connections[el].rightIndentvecs.Add(vec);
					prevVec = vec;
					if (i == 0)
					{
						firstIndent = vec;
					}
					vec += vector4 * baseScript.minSurrounding;
					vec = OCDCCCQDCC.GetTerrainPos(base.transform, vec, baseScript);
					if (connections[el].rightIndentBorderInt <= 0 && vector3 != list[i])
					{
						OCQCQCOODC(num4, vector3, list[i], boolCheck: true, ref vec);
					}
					if (vector != Vector3.zero)
					{
						CheckAgainstFirstSurroundingVec(firstIndent, vector, boolCheck: true, ref vec);
					}
					connections[el].rightSurroundingvecs.Add(vec);
					if (i == 0)
					{
						vector = vec;
					}
				}
			}
			num3 = num + baseScript.minIndent;
			num4 = num3 + baseScript.minSurrounding;
			num5 = baseScript.minIndent;
			prevVec = Vector3.zero;
			firstIndent = Vector3.zero;
			vector = Vector3.zero;
			if (qDOQDSQOOQDDD2.renderFlag)
			{
				num3 += qDOQDSQOOQDDD2.sidewalkWidth1;
				num2 = qDOQDSQOOQDDD2.sidewalkWidth1;
				num5 += qDOQDSQOOQDDD2.sidewalkWidth1;
			}
			num4 = num3 + baseScript.minSurrounding;
			list.Clear();
			list.AddRange(connections[el].leftSidewalkV3[0]);
			connections[el].leftIndentBorderInt = -1;
			for (int i = 0; i < list.Count; i++)
			{
				Vector3 vector4 = ((i == 0) ? (list[i + 1] - list[i]).normalized : ((i >= list.Count - 1) ? (list[i] - list[i - 1]).normalized : (list[i + 1] - list[i - 1]).normalized));
				vector4 = new Vector3(vector4.z, 0f, 0f - vector4.x).normalized * -1f;
				Vector3 vec = list[i] + vector4 * num5;
				if (OOOCCOQDCO(i, num3, prevVec, boolCheck: false, ref vec, ref connections[el].leftIndentBorderInt))
				{
					if (i == 0 && connections[el].leftIndentBorderInt == 0)
					{
						vec = list[i].normalized * num3;
						vec += vector4 * num5;
					}
					connections[el].leftIndentvecs.Add(vec);
					prevVec = vec;
					if (i == 0)
					{
						firstIndent = vec;
					}
					vec += vector4 * baseScript.minSurrounding;
					vec = OCDCCCQDCC.GetTerrainPos(base.transform, vec, baseScript);
					if (connections[el].leftIndentBorderInt <= 0 && vector2 != list[i])
					{
						OCQCQCOODC(num4, vector2, list[i], boolCheck: false, ref vec);
					}
					if (vector != Vector3.zero)
					{
						CheckAgainstFirstSurroundingVec(firstIndent, vector, boolCheck: false, ref vec);
					}
					connections[el].leftSurroundingvecs.Add(vec);
					if (i == 0)
					{
						vector = vec;
					}
				}
			}
		}

		public static bool OOOCCOQDCO(int el, float roundaboutIndent, Vector3 prevVec, bool boolCheck, ref Vector3 vec, ref int indentBorderInt)
		{
			float num = Vector3.Distance(vec, Vector3.zero) + 0.2f;
			if (num < roundaboutIndent)
			{
				if (indentBorderInt == -1)
				{
					indentBorderInt = el - 1;
				}
				if (indentBorderInt == -1)
				{
					indentBorderInt = 0;
					Vector3 normalized = vec.normalized;
					vec += normalized * (roundaboutIndent - num);
					return true;
				}
				return false;
			}
			if (prevVec != Vector3.zero)
			{
				if (OCQCDQCQOQ.OOOOCDQQOC(vec, Vector3.zero, prevVec) == boolCheck)
				{
					return true;
				}
				return false;
			}
			return true;
		}

		public void OCQCQCOODC(float minSurrounding, Vector3 middleVec, Vector3 origVec, bool boolCheck, ref Vector3 vec)
		{
			float num = Vector3.Distance(vec, Vector3.zero);
			if (num < minSurrounding)
			{
				Vector3 normalized = vec.normalized;
				vec = normalized * minSurrounding;
				vec = OCDCCCQDCC.GetTerrainPos(base.transform, vec, baseScript);
			}
			if (OCQCDQCQOQ.OOOOCDQQOC(middleVec, Vector3.zero, vec) != boolCheck && OCQCDQCQOQ.OOOOCDQQOC(middleVec, Vector3.zero, origVec) == boolCheck)
			{
				vec = OCQCDQCQOQ.OCDCDCDCQD(Vector3.zero, middleVec, origVec, vec);
				vec = OCDCCCQDCC.GetTerrainPos(base.transform, vec, baseScript);
			}
		}

		public void CheckAgainstFirstSurroundingVec(Vector3 firstIndent, Vector3 firstSurrounding, bool boolCheck, ref Vector3 vec)
		{
			if (OCQCDQCQOQ.OOOOCDQQOC(firstSurrounding, firstIndent, vec) == boolCheck)
			{
				vec = firstSurrounding;
			}
		}

		public static Vector3 OCDCDCDCQD(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
		{
			float num = p1.x - p3.x;
			float num2 = p1.z - p3.z;
			float num3 = p2.z - p1.z;
			float num4 = p2.x - p1.x;
			float num5 = num3 * p1.x + num4 * p1.z;
			float num6 = p4.z - p3.z;
			float num7 = p4.x - p3.x;
			float num8 = num6 * p3.x + num7 * p3.z;
			float num9 = num3 * num7 - num6 * num4;
			if (num9 == 0f)
			{
				return Vector3.zero;
			}
			float num10 = num6 * num4 - num7 * num3;
			float num11 = (num7 * num2 - num6 * num) / num10;
			float num12 = (num4 * num2 - num3 * num) / num10;
			float x = p1.x + num11 * num4;
			float z = p1.z + num11 * num3;
			return new Vector3(x, p1.y, z);
		}

		public static Vector3 OCQDOQQQOD(Vector3 point, Vector3 pivot, Quaternion angle)
		{
			Vector3 vector = point - pivot;
			vector = angle * vector;
			return vector + pivot;
		}
	}
}
