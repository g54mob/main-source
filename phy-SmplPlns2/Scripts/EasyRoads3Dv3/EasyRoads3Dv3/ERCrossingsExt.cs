using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERCrossingsExt : MonoBehaviour
	{
		[HideInInspector]
		public bool ODOCCQCQDOs;

		[HideInInspector]
		public bool skew;

		[HideInInspector]
		public bool exits;

		[HideInInspector]
		public int road1ExitLanes;

		[HideInInspector]
		public int road2ExitLanes;

		[HideInInspector]
		public int road3ExitLanes;

		[HideInInspector]
		public int road4ExitLanes;

		[HideInInspector]
		public float bottomIslandSize = 3f;

		[HideInInspector]
		public float leftIslandSize = 3f;

		[HideInInspector]
		public float topIslandSize = 3f;

		[HideInInspector]
		public float rightIslandSize = 3f;

		[HideInInspector]
		public bool preserveRoadDirection13 = false;

		[HideInInspector]
		public bool preserveRoadDirection24 = false;

		[HideInInspector]
		public bool[] parallelRoads = new bool[4];

		[HideInInspector]
		public bool[] oppositeRoadSplineControl = new bool[4] { true, true, true, true };

		[HideInInspector]
		public bool[] isRoadConnected = new bool[4];

		[HideInInspector]
		public bool[] ramps = new bool[4];

		[HideInInspector]
		public float[] rampRadius = new float[4] { 25f, 25f, 25f, 25f };

		[HideInInspector]
		public float[] islandSize = new float[4] { 3f, 3f, 3f, 3f };

		[HideInInspector]
		public int[] rampLaneInset = new int[4];

		[HideInInspector]
		public float[] cornerRadius = new float[4] { 5f, 5f, 5f, 5f };

		[HideInInspector]
		public int[] cornerSegments = new int[4] { 8, 8, 8, 8 };

		[HideInInspector]
		public float[] medianInset = new float[4] { 5f, 5f, 5f, 5f };

		private Vector3[] _3ssss = new Vector3[12];

		[HideInInspector]
		public float defaultIntersectionSize = 15f;

		private float _4ssst = 15f;

		[HideInInspector]
		public Vector3 innerHandles;

		[HideInInspector]
		public Vector3 outerHandles;

		private ERCrossingPrefabs ttsss = null;

		public List<QDQDOOQQDQODD> roadTypesDynamic = new List<QDQDOOQQDQODD>();

		public static List<Vector3> ll1 = new List<Vector3>();

		public static List<Vector3> ll2 = new List<Vector3>();

		public static List<Vector3> ll3 = new List<Vector3>();

		public static List<Vector3> ll4 = new List<Vector3>();

		public static List<Vector3> ll5 = new List<Vector3>();

		[HideInInspector]
		public Vector3 tp1;

		[HideInInspector]
		public Vector3 tp2;

		[HideInInspector]
		public Vector3 tp3;

		[HideInInspector]
		public Vector3 tp4;

		public float uvRatio = 10f;

		public List<Vector3> parallelPoints = new List<Vector3>();

		public int defaultRoadWidth = 8;

		public float minConnectionDistance = 5f;

		public void ResetConnector()
		{
			if (ttsss == null)
			{
				ttsss = GetComponent<ERCrossingPrefabs>();
			}
			ttsss.crossingElements.Clear();
			ttsss.siblings.Clear();
		}

		public void ODDDQDQOOD()
		{
			parallelPoints.Clear();
			tp1 = (tp2 = (tp3 = (tp4 = Vector3.zero)));
			if (ttsss == null)
			{
				ttsss = GetComponent<ERCrossingPrefabs>();
			}
			if (roadTypesDynamic.Count == 0)
			{
				roadTypesDynamic = QDDDQODDQDQDQDD.OOCQOQDDOQ(ttsss.baseScript.roadTypes, all: true);
			}
			ttsss.isERCrossingExt = true;
			if (ttsss.crossingElements.Count != 12)
			{
				if (defaultIntersectionSize < 10f)
				{
					defaultIntersectionSize = 10f;
				}
				ttsss.crossingElements.Clear();
				ttsss.siblings.Clear();
				Vector3 zero = Vector3.zero;
				zero.z -= 0.5f * defaultIntersectionSize;
				zero.x += 0.33f * defaultIntersectionSize;
				QDOODOQQDQODD qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Right;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Center;
				zero.x = 0f;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Left;
				zero.x -= 0.33f * defaultIntersectionSize;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				zero = Vector3.zero;
				zero.x -= 0.5f * defaultIntersectionSize;
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Right;
				zero.z -= 0.33f * defaultIntersectionSize;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Center;
				zero.z = 0f;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Left;
				zero.z += 0.33f * defaultIntersectionSize;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				zero = Vector3.zero;
				zero.z += 0.5f * defaultIntersectionSize;
				qDOODOQQDQODD = new QDOODOQQDQODD();
				zero.x -= 0.33f * defaultIntersectionSize;
				qDOODOQQDQODD.connectionPosition = ERPosition.Right;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Center;
				zero.x = 0f;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Left;
				zero.x += 0.33f * defaultIntersectionSize;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				zero = Vector3.zero;
				zero.x = 0.5f * defaultIntersectionSize;
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Right;
				zero.z += 0.33f * defaultIntersectionSize;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Center;
				zero.z = 0f;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
				qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.connectionPosition = ERPosition.Left;
				zero.z -= 0.33f * defaultIntersectionSize;
				qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = zero);
				ttsss.crossingElements.Add(qDOODOQQDQODD);
			}
			if (_4ssst != defaultIntersectionSize)
			{
			}
			if (ttsss.siblings.Count == 0)
			{
				for (int i = 0; i < 12; i++)
				{
					ttsss.siblings.Add(ERConnectionSibling.CreateInstance(null, 0f, Vector3.zero, null, null));
					ttsss.siblings[i].roadType = ttsss.crossingElements[i].rt;
					ttsss.siblings[i].roadTypeIndex = 0;
				}
			}
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < ttsss.siblings.Count; j++)
			{
				ttsss.siblings[j].name = "Road " + (j + 1);
				if (ttsss.siblings[j].roadTypeIndex == 0)
				{
					if (ttsss.crossingElements.Count > j)
					{
						if (ttsss.crossingElements[j].connectedRoad != null)
						{
							ttsss.siblings[j].OCOQDOCCOO(ttsss.crossingElements[j].connectedRoad.roadType, roadTypesDynamic);
							ttsss.siblings[j].roadType = ttsss.crossingElements[j].connectedRoad.rt;
						}
						else
						{
							ttsss.siblings[j].OCOQDOCCOO(ttsss.crossingElements[j].roadType, roadTypesDynamic);
						}
					}
					if (ttsss.siblings[j].roadTypeIndex == 0)
					{
						ttsss.siblings[j].roadTypeIndex = 1;
					}
					if (ttsss.siblings[j].roadType == null)
					{
						ttsss.siblings[j].roadType = (ttsss.crossingElements[j].rt = QDQDOOQQDQODD.GetRoadTypeElByID(ttsss.baseScript.roadTypes, ttsss.baseScript.roadTypes[1].id, clone: true));
					}
				}
				ttsss.siblings[j].angle = 360f - QDDDQODDQDQDQDD.OCCQDDQQCD(ttsss.siblings[j].angleControlPoint, Vector3.forward, Vector3.up);
				ttsss.siblings[j].Clear();
				if (parallelRoads[num])
				{
					if (num2 == 1 && ttsss.crossingElements[3 * num + 1].connectedRoad != null)
					{
						if (ttsss.crossingElements[3 * num + 1].connectedMarker == 0)
						{
							ttsss.crossingElements[3 * num + 1].connectedRoad.startPrefabScript = null;
						}
						else
						{
							ttsss.crossingElements[3 * num + 1].connectedRoad.endPrefabScript = null;
						}
						ttsss.crossingElements[3 * num + 1].connectedRoad = null;
					}
				}
				else if ((num2 == 0 || num2 == 2) && ttsss.crossingElements[3 * num + num2].connectedRoad != null)
				{
					if (ttsss.crossingElements[3 * num + num2].connectedMarker == 0)
					{
						ttsss.crossingElements[3 * num + num2].connectedRoad.startPrefabScript = null;
					}
					else
					{
						ttsss.crossingElements[3 * num + num2].connectedRoad.endPrefabScript = null;
					}
					ttsss.crossingElements[3 * num + num2].connectedRoad = null;
				}
				if (ttsss.crossingElements[j].connectedRoad != null)
				{
					isRoadConnected[num] = true;
				}
				num2++;
				if (num2 == 3)
				{
					num2 = 0;
					num++;
				}
			}
			_2ssst(out var tssss, out var ussss, out var num3, out var wssss);
			Vector3 vector2;
			Vector3 vector3;
			Vector3 zero2;
			Vector3 vector = (vector2 = (vector3 = (zero2 = Vector3.zero)));
			Vector3 forward = Vector3.forward;
			Vector3 vector4 = -Vector3.forward;
			Vector3 right = Vector3.right;
			Vector3 left = Vector3.left;
			float num4 = ((ussss < wssss) ? wssss : ussss);
			float num5 = ((tssss < num3) ? num3 : tssss);
			islandSize = new float[4] { bottomIslandSize, leftIslandSize, topIslandSize, rightIslandSize };
			_3ssss = new Vector3[12];
			float num6 = defaultRoadWidth;
			float num7 = defaultRoadWidth;
			float num8 = defaultRoadWidth;
			if (ttsss.crossingElements[0].connectedRoad != null)
			{
				num8 = ttsss.crossingElements[0].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[1].connectedRoad != null)
			{
				num7 = ttsss.crossingElements[1].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[2].connectedRoad != null)
			{
				num6 = ttsss.crossingElements[2].connectedRoad.roadWidth;
			}
			float num9 = defaultRoadWidth;
			float num10 = defaultRoadWidth;
			float num11 = defaultRoadWidth;
			if (ttsss.crossingElements[3].connectedRoad != null)
			{
				num11 = ttsss.crossingElements[3].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[4].connectedRoad != null)
			{
				num10 = ttsss.crossingElements[4].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[5].connectedRoad != null)
			{
				num9 = ttsss.crossingElements[5].connectedRoad.roadWidth;
			}
			float num12 = defaultRoadWidth;
			float num13 = defaultRoadWidth;
			float num14 = defaultRoadWidth;
			if (ttsss.crossingElements[6].connectedRoad != null)
			{
				num14 = ttsss.crossingElements[6].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[7].connectedRoad != null)
			{
				num13 = ttsss.crossingElements[7].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[8].connectedRoad != null)
			{
				num12 = ttsss.crossingElements[8].connectedRoad.roadWidth;
			}
			float num15 = defaultRoadWidth;
			float num16 = defaultRoadWidth;
			float num17 = defaultRoadWidth;
			if (ttsss.crossingElements[9].connectedRoad != null)
			{
				num17 = ttsss.crossingElements[9].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[10].connectedRoad != null)
			{
				num16 = ttsss.crossingElements[10].connectedRoad.roadWidth;
			}
			if (ttsss.crossingElements[11].connectedRoad != null)
			{
				num15 = ttsss.crossingElements[11].connectedRoad.roadWidth;
			}
			_3ssss[0].z = (_3ssss[1].z = (_3ssss[2].z = (0f - num4) * 0.5f));
			_3ssss[0].x += 0.5f * islandSize[0] + 0.5f * num8;
			_3ssss[2].x -= 0.5f * islandSize[0] + 0.5f * num6;
			float x = _3ssss[0].x;
			float num18 = 0f - _3ssss[2].x;
			_3ssss[3].x = (_3ssss[4].x = (_3ssss[5].x = (0f - num5) * 0.5f));
			_3ssss[3].z -= 0.5f * islandSize[1] + 0.5f * num11;
			_3ssss[5].z += 0.5f * islandSize[1] + 0.5f * num9;
			float z = _3ssss[3].z;
			float num19 = 0f - _3ssss[5].z;
			_3ssss[6].z = (_3ssss[7].z = (_3ssss[8].z = num4 * 0.5f));
			_3ssss[6].x -= 0.5f * islandSize[2] + 0.5f * num14;
			_3ssss[8].x += 0.5f * islandSize[2] + 0.5f * num12;
			float num20 = 0f - _3ssss[6].x;
			float x2 = _3ssss[8].x;
			_3ssss[9].x = (_3ssss[10].x = (_3ssss[11].x = num5 * 0.5f));
			_3ssss[9].z += 0.5f * islandSize[3] + 0.5f * num17;
			_3ssss[11].z -= 0.5f * islandSize[3] + 0.5f * num15;
			float z2 = _3ssss[9].z;
			float num21 = 0f - _3ssss[11].z;
			vector.z = (0f - num4) * 0.5f;
			vector.x -= 0.5f * num5;
			zero2 = vector + Vector3.right * num5;
			vector2 = vector + Vector3.forward * num4;
			vector3 = zero2 + Vector3.forward * num4;
			vector = base.transform.TransformPoint(vector);
			vector2 = base.transform.TransformPoint(vector2);
			vector3 = base.transform.TransformPoint(vector3);
			zero2 = base.transform.TransformPoint(zero2);
			num = 0;
			num2 = 0;
			int[] array = new int[12]
			{
				8, 7, 6, 11, 10, 9, 2, 1, 0, 5,
				4, 3
			};
			for (int k = 0; k < 12; k++)
			{
				float num22 = 0f;
				Vector3 ussss2 = vector;
				switch (num)
				{
				case 0:
					ussss2 = vector;
					break;
				case 1:
					ussss2 = vector2;
					break;
				case 2:
					ussss2 = vector3;
					break;
				case 3:
					ussss2 = zero2;
					break;
				}
				num22 = 3f;
				int num23 = num + 1;
				if (num == 3)
				{
					num23 = 0;
				}
				float num24 = 0f;
				bool flag = false;
				if (ramps[num23])
				{
					num24 = rampRadius[num23];
					flag = true;
				}
				else
				{
					num24 = cornerRadius[num23];
				}
				if (ramps[num])
				{
					flag = true;
					if (ramps[num] && rampRadius[num] > num24)
					{
						num24 = rampRadius[num];
					}
					if (num24 > num22)
					{
						num22 += num24;
					}
				}
				else
				{
					if (cornerRadius[num] > num24)
					{
						num24 = cornerRadius[num];
					}
					if (num24 > num22)
					{
						num22 += num24;
					}
				}
				float num25 = 0f;
				float num26 = 0f;
				if (num == 0)
				{
					num25 = 0f - _3ssss[k].z;
				}
				if (num == 1)
				{
					num25 = 0f - _3ssss[k].x;
				}
				if (num == 2)
				{
					num25 = _3ssss[k].z;
				}
				if (num == 3)
				{
					num25 = ((!parallelRoads[0]) ? (num7 * 0.5f) : (_3ssss[0].x * 2f));
					num26 = ((!parallelRoads[2]) ? (num13 * 0.5f) : (_3ssss[8].x * 2f));
					if (num26 > num25)
					{
						num25 = num26;
					}
					num25 -= _3ssss[k].x;
					num25 += num24;
					num25 = _3ssss[k].x;
				}
				num22 += num25;
				Vector3 direction = -Vector3.forward;
				Vector3 perpDir = Vector3.right;
				float perpDistance = 0f;
				switch (num)
				{
				case 0:
					perpDistance = ((k != 0) ? (0f - num18) : x);
					break;
				case 1:
					direction = -Vector3.right;
					perpDir = -Vector3.forward;
					perpDistance = ((k != 3) ? num19 : (0f - z));
					break;
				case 2:
					direction = Vector3.forward;
					perpDir = -Vector3.right;
					perpDistance = ((k != 6) ? (0f - x2) : num20);
					break;
				case 3:
					direction = Vector3.right;
					perpDir = Vector3.forward;
					perpDistance = ((k != 9) ? (0f - num21) : z2);
					break;
				}
				if (ttsss.crossingElements[k].connectedRoad != null)
				{
					if (num22 < minConnectionDistance)
					{
						num22 = minConnectionDistance;
					}
					ttsss.siblings[k].splinePoints = OCCQQDQODQ(k, array[k], num22, num, perpDir, perpDistance);
					ussst(k, ussss2);
				}
				else if ((parallelRoads[num] && (num2 == 0 || num2 == 2)) || (!parallelRoads[num] && num2 == 1))
				{
					if (num22 < minConnectionDistance)
					{
						num22 = minConnectionDistance;
					}
					Vector3 dir = base.transform.TransformDirection(direction);
					ttsss.siblings[k].splinePoints = GetPlaceHolderSplinePoints(k, array[k], _3ssss[k], num22, 0, dir);
					ussst(k, ussss2);
				}
				num2++;
				if (num2 == 3)
				{
					num2 = 0;
					num++;
				}
			}
			List<Vector3> list = null;
			List<Vector3> list2 = null;
			list = (parallelRoads[0] ? ttsss.siblings[2].leftRoundingPoints : ttsss.siblings[1].leftRoundingPoints);
			list2 = ((!parallelRoads[1]) ? ttsss.siblings[4].rightRoundingPoints : ttsss.siblings[3].rightRoundingPoints);
			if (list != null && list2 != null)
			{
				vector = GetCornerCrosspoint(ref list, ref list2);
			}
			else if ((list != null || list2 != null) && list != null)
			{
			}
			list = null;
			list2 = null;
			list = (parallelRoads[1] ? ttsss.siblings[5].leftRoundingPoints : ttsss.siblings[4].leftRoundingPoints);
			list2 = ((!parallelRoads[2]) ? ttsss.siblings[7].rightRoundingPoints : ttsss.siblings[6].rightRoundingPoints);
			if (list != null && list2 != null)
			{
				vector2 = GetCornerCrosspoint(ref list, ref list2);
			}
			list = null;
			list2 = null;
			list = (parallelRoads[2] ? ttsss.siblings[8].leftRoundingPoints : ttsss.siblings[7].leftRoundingPoints);
			list2 = ((!parallelRoads[3]) ? ttsss.siblings[10].rightRoundingPoints : ttsss.siblings[9].rightRoundingPoints);
			if (list != null && list2 != null)
			{
				vector3 = GetCornerCrosspoint(ref list, ref list2);
			}
			list = null;
			list2 = null;
			list = (parallelRoads[3] ? ttsss.siblings[11].leftRoundingPoints : ttsss.siblings[10].leftRoundingPoints);
			list2 = ((!parallelRoads[0]) ? ttsss.siblings[1].rightRoundingPoints : ttsss.siblings[0].rightRoundingPoints);
			if (list != null && list2 != null)
			{
				zero2 = GetCornerCrosspoint(ref list, ref list2, debug: true);
			}
			int num27 = -1;
			int num28 = -1;
			if ((bool)ttsss.crossingElements[0].connectedRoad)
			{
				num27 = 0;
			}
			else if ((bool)ttsss.crossingElements[1].connectedRoad)
			{
				num27 = 1;
			}
			if ((bool)ttsss.crossingElements[10].connectedRoad)
			{
				num28 = 10;
			}
			else if ((bool)ttsss.crossingElements[11].connectedRoad)
			{
				num28 = 11;
			}
			if (num27 == -1)
			{
				num27 = ((!parallelRoads[0]) ? 1 : 0);
			}
			if (num28 == -1)
			{
				num28 = ((!parallelRoads[3]) ? 10 : 11);
			}
			if (ramps[0])
			{
				wssst(num27, num28, rampRadius[0], zero2);
			}
			else
			{
				xssss(num27, num28, cornerRadius[0], cornerSegments[0], zero2);
			}
			num27 = -1;
			num28 = -1;
			if ((bool)ttsss.crossingElements[3].connectedRoad)
			{
				num27 = 3;
			}
			else if ((bool)ttsss.crossingElements[4].connectedRoad)
			{
				num27 = 4;
			}
			if ((bool)ttsss.crossingElements[1].connectedRoad)
			{
				num28 = 1;
			}
			else if ((bool)ttsss.crossingElements[2].connectedRoad)
			{
				num28 = 2;
			}
			if (num27 == -1)
			{
				num27 = ((!parallelRoads[1]) ? 4 : 3);
			}
			if (num28 == -1)
			{
				num28 = ((!parallelRoads[0]) ? 1 : 2);
			}
			if (ramps[1])
			{
				wssst(num27, num28, rampRadius[1], vector);
			}
			else
			{
				xssss(num27, num28, cornerRadius[1], cornerSegments[1], vector);
			}
			num27 = -1;
			num28 = -1;
			if ((bool)ttsss.crossingElements[6].connectedRoad)
			{
				num27 = 6;
			}
			else if ((bool)ttsss.crossingElements[6].connectedRoad)
			{
				num27 = 7;
			}
			if ((bool)ttsss.crossingElements[4].connectedRoad)
			{
				num28 = 4;
			}
			else if ((bool)ttsss.crossingElements[5].connectedRoad)
			{
				num28 = 5;
			}
			if (num27 == -1)
			{
				num27 = ((!parallelRoads[2]) ? 7 : 6);
			}
			if (num28 == -1)
			{
				num28 = ((!parallelRoads[1]) ? 4 : 5);
			}
			if (ramps[2])
			{
				wssst(num27, num28, rampRadius[2], vector2);
			}
			else
			{
				xssss(num27, num28, cornerRadius[2], cornerSegments[2], vector2);
			}
			num27 = -1;
			num28 = -1;
			if ((bool)ttsss.crossingElements[9].connectedRoad)
			{
				num27 = 9;
			}
			else if ((bool)ttsss.crossingElements[10].connectedRoad)
			{
				num27 = 10;
			}
			if ((bool)ttsss.crossingElements[7].connectedRoad)
			{
				num28 = 7;
			}
			else if ((bool)ttsss.crossingElements[8].connectedRoad)
			{
				num28 = 8;
			}
			if (num27 == -1)
			{
				num27 = ((!parallelRoads[3]) ? 10 : 9);
			}
			if (num28 == -1)
			{
				num28 = ((!parallelRoads[2]) ? 7 : 8);
			}
			if (ramps[3])
			{
				wssst(num27, num28, rampRadius[3], vector3);
			}
			else
			{
				xssss(num27, num28, cornerRadius[3], cornerSegments[3], vector3);
			}
			List<Vector3> wssss2 = new List<Vector3>();
			List<Vector2> list3 = new List<Vector2>();
			List<int> yssss = new List<int>();
			wssss2.Add(base.transform.InverseTransformPoint(vector));
			wssss2.Add(base.transform.InverseTransformPoint(vector2));
			wssss2.Add(base.transform.InverseTransformPoint(vector3));
			wssss2.Add(base.transform.InverseTransformPoint(zero2));
			list3.Add(Vector2.zero);
			list3.Add(Vector2.zero);
			list3.Add(Vector2.zero);
			list3.Add(Vector2.zero);
			ll5.Clear();
			yssst(0, 1, 2, ref wssss2, ref list3, ref yssss, zero2, vector, 0, _3ssss[1]);
			yssst(3, 4, 5, ref wssss2, ref list3, ref yssss, vector, vector2, 1, _3ssss[4]);
			yssst(6, 7, 8, ref wssss2, ref list3, ref yssss, vector2, vector3, 2, _3ssss[7]);
			yssst(9, 10, 11, ref wssss2, ref list3, ref yssss, vector3, zero2, 3, _3ssss[10]);
			Mesh mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			if (mesh == null)
			{
				mesh = new Mesh();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			mesh.Clear();
			mesh.vertices = wssss2.ToArray();
			mesh.SetTriangles(yssss.ToArray(), 0);
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			mesh.RecalculateBounds();
			float x3 = mesh.bounds.size.x;
			float z3 = mesh.bounds.size.z;
			float x4 = mesh.bounds.min.x;
			float z4 = mesh.bounds.min.z;
			for (int l = 0; l < wssss2.Count; l++)
			{
				list3[l] = new Vector2((wssss2[l].x - x4) / x3 * uvRatio, (wssss2[l].z - z4) / z3 * uvRatio);
			}
			mesh.uv = list3.ToArray();
			ttsss.meshVecs = mesh.vertices;
			ttsss.tmpMeshVecs = ttsss.meshVecs;
			ttsss.tmpFullMeshVecs = ttsss.meshVecs;
			for (int m = 0; m < ttsss.crossingElements.Count; m++)
			{
				if (ttsss.crossingElements[m].isHandleActive)
				{
					OOOQCCODDC(ttsss.crossingElements[m], ttsss.siblings[m], m, ttsss.crossingElements.Count);
					ttsss.crossingElements[m].rightIndent = ttsss.siblings[m].rightIndent;
					ttsss.crossingElements[m].rightIndentV3 = ttsss.siblings[m].rightIndentV3;
					ttsss.crossingElements[m].leftIndent = ttsss.siblings[m].leftIndent;
					ttsss.crossingElements[m].leftIndentV3 = ttsss.siblings[m].leftIndentV3;
					ttsss.crossingElements[m].rightSurrounding = ttsss.siblings[m].rightSurrounding;
					ttsss.crossingElements[m].rightSurroundingV3 = ttsss.siblings[m].rightSurroundingV3;
					ttsss.crossingElements[m].leftSurrounding = ttsss.siblings[m].leftSurrounding;
					ttsss.crossingElements[m].leftSurroundingV3 = ttsss.siblings[m].leftSurroundingV3;
					ttsss.crossingElements[m].direction = ttsss.siblings[m].forward.normalized;
					ttsss.crossingElements[m].includeLeftSidewalk = false;
					ttsss.crossingElements[m].includeRightSidewalk = false;
					ttsss.crossingElements[m].centerCornerDirectionLeft = (ttsss.crossingElements[m].centerCornerDirectionRight = Vector3.zero);
					ttsss.crossingElements[m].leftRoundingPoints = new List<Vector3>(ttsss.siblings[m].leftRoundingPoints);
					ttsss.crossingElements[m].rightRoundingPoints = new List<Vector3>(ttsss.siblings[m].rightRoundingPoints);
				}
			}
			ttsss.isFlexUpdating = true;
			ttsss.ODOQCOOOCC(ignorePriority: true, null);
			ttsss.isFlexUpdating = false;
		}

		private List<Vector3> OCCQQDQODQ(int connIndex, int otherConnIndex, float distance, int connSide, Vector3 perpDir, float perpDistance)
		{
			Vector3 vector3;
			Vector3 vector2;
			Vector3 vector = (vector2 = (vector3 = Vector3.zero));
			Vector3 item;
			if (ttsss.crossingElements[connIndex].connectedMarker == 0)
			{
				item = ((ttsss.crossingElements[connIndex].connectedRoad.markersExt.Count < 3) ? ttsss.crossingElements[connIndex].connectedRoad.markersExt[1].position : ttsss.crossingElements[connIndex].connectedRoad.markersExt[2].position);
				vector = ttsss.crossingElements[connIndex].connectedRoad.markersExt[1].position;
			}
			else
			{
				item = ((ttsss.crossingElements[connIndex].connectedRoad.markersExt.Count < 3) ? ttsss.crossingElements[connIndex].connectedRoad.markersExt[ttsss.crossingElements[connIndex].connectedRoad.markersExt.Count - 2].position : ttsss.crossingElements[connIndex].connectedRoad.markersExt[ttsss.crossingElements[connIndex].connectedRoad.markersExt.Count - 3].position);
				vector = ttsss.crossingElements[connIndex].connectedRoad.markersExt[ttsss.crossingElements[connIndex].connectedRoad.markersExt.Count - 2].position;
			}
			vector2 = (parallelRoads[connSide] ? (base.transform.position + perpDir * perpDistance) : base.transform.position);
			if (ttsss.crossingElements[otherConnIndex].connectedRoad != null)
			{
				if (ttsss.crossingElements[otherConnIndex].connectedMarker == 0)
				{
					if (ttsss.crossingElements[otherConnIndex].connectedRoad.markersExt.Count >= 2)
					{
						vector3 = ttsss.crossingElements[otherConnIndex].connectedRoad.markersExt[1].position;
					}
				}
				else
				{
					vector3 = ttsss.crossingElements[otherConnIndex].connectedRoad.markersExt[ttsss.crossingElements[otherConnIndex].connectedRoad.markersExt.Count - 2].position;
				}
				if (!oppositeRoadSplineControl[connSide])
				{
					vector3 = vector2;
				}
			}
			else
			{
				vector3 = vector2;
			}
			List<Vector3> list = new List<Vector3>();
			list.Add(vector3);
			list.Add(vector2);
			list.Add(vector);
			list.Add(item);
			ttsss.crossingElements[connIndex].endSplinePoint = vector2;
			ttsss.crossingElements[connIndex].endControlPoint = vector3;
			List<Vector3> list2 = OQQOCDQCQD.OOQOOCCQOQ(list, 0.5f, 1f, addFirstControlPoint: false, distance);
			return OQQOCDQCQD.OOQOOCCQOQ(list, 0.5f, 1f, addFirstControlPoint: false, distance);
		}

		private List<Vector3> GetPlaceHolderSplinePoints(int connIndex, int otherConnIndex, Vector3 startPosition, float distance, int connSide, Vector3 dir)
		{
			Vector3 vector2;
			Vector3 zero;
			Vector3 vector = (vector2 = (zero = Vector3.zero));
			startPosition = base.transform.TransformPoint(startPosition);
			float num = Mathf.Round(distance / 2f);
			if (num < 5f)
			{
				num = 5f;
			}
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; (float)i < num; i++)
			{
				list.Add(startPosition + dir * 2f * i);
			}
			list[0] -= dir * 5f;
			return list;
		}

		private void ussst(int tssss, Vector3 ussss)
		{
			List<Vector2> list = new List<Vector2>();
			List<float> list2 = new List<float>();
			if (ttsss.crossingElements[tssss].connectedRoad != null)
			{
				list = new List<Vector2>(ttsss.crossingElements[tssss].connectedRoad.markersExt[ttsss.crossingElements[tssss].connectedMarker].roadShape);
				list = new List<Vector2>(ttsss.crossingElements[tssss].connectedRoad.roadShape);
				list2 = ttsss.crossingElements[tssss].connectedRoad.roadShapeUVs;
				if (list.Count == 0)
				{
					list = new List<Vector2>(ttsss.crossingElements[tssss].connectedRoad.roadShape);
				}
			}
			if (list.Count == 0)
			{
				list.Add(new Vector3(0.5f * (float)defaultRoadWidth, 0f));
				list.Add(new Vector3(-0.5f * (float)defaultRoadWidth, 0f));
				list2.Add(0f);
				list2.Add(1f);
			}
			ttsss.siblings[tssss].roadShape = new List<Vector2>(list);
			ttsss.siblings[tssss].roadShapeUVs = new List<float>(list2);
			int index = list.Count - 1;
			float num = 1f;
			if (ttsss.crossingElements[tssss].connectedRoad != null && ttsss.crossingElements[tssss].connectedMarker == 0)
			{
				num = -1f;
			}
			float num2 = 0f;
			float num3 = 0f;
			List<Vector3> splinePoints = ttsss.siblings[tssss].splinePoints;
			Vector3 a = Vector3.zero;
			Vector3 a2 = Vector3.zero;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			for (int i = 0; i < splinePoints.Count; i++)
			{
				Vector3 vector = ((i == 0) ? (splinePoints[1] - splinePoints[0]) : ((i != splinePoints.Count - 1) ? (splinePoints[i + 1] - splinePoints[i - 1]) : (splinePoints[i] - splinePoints[i - 1])));
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized * num;
				Vector3 vector2 = splinePoints[i] + vector * list[0].x;
				Vector3 a3 = splinePoints[i] + vector * list[index].x;
				if (i == 0)
				{
					if (!OQQOCDQCQD.OOCQODQDQD(splinePoints[1], splinePoints[0], vector2))
					{
						list.Reverse();
						vector2 = splinePoints[i] + vector * list[0].x;
						a3 = splinePoints[i] + vector * list[index].x;
					}
					if (!(Vector3.Distance(vector2, ussss) < Vector3.Distance(a3, ussss)))
					{
					}
				}
				zero = splinePoints[i] + vector * list[0].x;
				zero2 = splinePoints[i] + vector * list[index].x;
				ttsss.siblings[tssss].leftRoundingPoints.Add(zero);
				ttsss.siblings[tssss].rightRoundingPoints.Add(zero2);
				if (i > 0)
				{
					num2 += Vector3.Distance(a, zero);
					num3 += Vector3.Distance(a2, zero2);
				}
				a = zero;
				a2 = zero2;
			}
			ttsss.siblings[tssss].leftRoundingPointsDistance = num2;
			ttsss.siblings[tssss].rightRoundingPointsDistance = num3;
		}

		private Vector3 GetCornerCrosspoint(ref List<Vector3> leftPoints, ref List<Vector3> rightPoints, bool debug = false)
		{
			Vector3 zero = Vector3.zero;
			List<Vector3> list = leftPoints;
			List<Vector3> list2 = rightPoints;
			int index = 0;
			int index2 = 0;
			for (int i = 1; i < list.Count - 2; i++)
			{
				if (list2.Count <= i + 1)
				{
					continue;
				}
				zero = OQQOCDQCQD.OCDCQCDDCC(list[i], list[i + 1], list2[i - 1], list2[i], flag: false);
				if (zero == Vector3.zero)
				{
					zero = OQQOCDQCQD.OCDCQCDDCC(list[i - 1], list[i], list2[i], list2[i + 1], flag: false);
					if (zero == Vector3.zero)
					{
						zero = OQQOCDQCQD.OCDCQCDDCC(list[i + 1], list[i], list2[i], list2[i + 1], flag: false);
						if (zero != Vector3.zero)
						{
							index = i + 1;
							index2 = i + 1;
						}
					}
					else
					{
						index = i;
						index2 = i + 1;
					}
				}
				else
				{
					index = i + 1;
					index2 = i;
				}
				if (!(zero != Vector3.zero))
				{
					continue;
				}
				float num = 0f;
				float num2 = 0f;
				for (int j = 0; j < list.Count - 1; j++)
				{
					num = Vector3.Distance(list[j], zero);
					num2 = Vector3.Distance(list[j], list[j + 1]);
					if (num < num2)
					{
						index = j + 1;
						break;
					}
				}
				num = 0f;
				num2 = 0f;
				for (int k = 0; k < list2.Count - 1; k++)
				{
					num = Vector3.Distance(list2[k], zero);
					num2 = Vector3.Distance(list2[k], list2[k + 1]);
					if (num < num2)
					{
						index2 = k + 1;
						break;
					}
				}
				list.Insert(index, zero);
				list2.Insert(index2, zero);
				leftPoints = list;
				rightPoints = list2;
				return zero;
			}
			return Vector3.zero;
		}

		private void vssss(int tssss, int ussss, int vssss, int wssss, int xssss, int yssss, int Assss)
		{
			float num = 0f;
			if (parallelRoads[yssss] || ttsss.crossingElements[tssss].connectedRoad != null || ttsss.crossingElements[vssss].connectedRoad != null)
			{
				num = medianInset[yssss];
			}
			if (ramps[yssss] && rampRadius[yssss] > num)
			{
				num = rampRadius[yssss];
			}
			if (ramps[Assss] && rampRadius[Assss] > num)
			{
				num = rampRadius[Assss];
			}
			if (num < minConnectionDistance)
			{
				num = minConnectionDistance;
			}
			if (parallelRoads[yssss] || ttsss.crossingElements[tssss].connectedRoad != null)
			{
				OpimizeSplinePointArrays(ref ttsss.siblings[tssss].leftRoundingPoints, ref ttsss.siblings[tssss].rightRoundingPoints, num);
			}
			if (!parallelRoads[yssss] || ttsss.crossingElements[ussss].connectedRoad != null)
			{
				OpimizeSplinePointArrays(ref ttsss.siblings[ussss].leftRoundingPoints, ref ttsss.siblings[ussss].rightRoundingPoints, num);
			}
			if (parallelRoads[yssss] || ttsss.crossingElements[vssss].connectedRoad != null)
			{
				OpimizeSplinePointArrays(ref ttsss.siblings[vssss].leftRoundingPoints, ref ttsss.siblings[vssss].rightRoundingPoints, num);
			}
		}

		private void OpimizeSplinePointArrays(ref List<Vector3> leftPoints, ref List<Vector3> rightPoints, float distance)
		{
			float num = 0f;
			float num2 = 0f;
			leftPoints.Reverse();
			rightPoints.Reverse();
			for (int i = 1; i < leftPoints.Count; i++)
			{
				num2 += Vector3.Distance(leftPoints[i - 1], leftPoints[i]);
				if (num + num2 > distance)
				{
					float num3 = distance - num;
					Vector3 normalized = (leftPoints[i] - leftPoints[i - 1]).normalized;
					leftPoints[i] = leftPoints[i - 1] + normalized * num3;
					rightPoints[i] = rightPoints[i - 1] + normalized * num3;
					leftPoints.RemoveRange(i + 1, leftPoints.Count - i - 1);
					rightPoints.RemoveRange(i + 1, rightPoints.Count - i - 1);
				}
			}
			leftPoints.Reverse();
			rightPoints.Reverse();
		}

		private void wssst(int tssss, int ussss, float vssss, Vector3 wssss)
		{
			ttsss.siblings[tssss].rampVecs.Add(new List<Vector3>());
			List<Vector3> list = new List<Vector3>(ttsss.siblings[tssss].rightRoundingPoints);
			List<Vector3> list2 = new List<Vector3>(ttsss.siblings[ussss].leftRoundingPoints);
			float num = vssss;
			float num2 = 0f;
			float num3 = 0f;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			Vector3 vector4 = Vector3.zero;
			int num4 = 0;
			bool flag = false;
			for (int i = 0; i < list2.Count - 1; i++)
			{
				num3 = Vector3.Distance(list2[i], list2[i + 1]);
				if (flag && (num2 + num3 > num || i == list2.Count - 2))
				{
					vector = (list2[i] - list2[i + 1]).normalized;
					float num5 = num - num2;
					vector3 = list2[i] + -vector * num5;
					num4 = i + 1;
					break;
				}
				num2 += num3;
				if (list2[i] == wssss)
				{
					if (ttsss.siblings[ussss].leftRoundingPointsDistance - num2 < num)
					{
						num = ttsss.siblings[ussss].leftRoundingPointsDistance - num2 - 2f;
					}
					num2 = 0f;
					flag = true;
				}
			}
			if (vector3 == Vector3.zero)
			{
				vector3 = list2[list2.Count - 1];
				num4 = list2.Count - 1;
			}
			num = vssss;
			num2 = (num3 = 0f);
			int num6 = 0;
			flag = false;
			for (int j = 0; j < list.Count - 1; j++)
			{
				num3 = Vector3.Distance(list[j], list[j + 1]);
				if (flag && (num2 + num3 > num || j == list.Count - 2))
				{
					vector2 = (list[j] - list[j + 1]).normalized;
					float num7 = num - num2;
					vector4 = list[j] + -vector2 * num7;
					num6 = j + 1;
					break;
				}
				num2 += num3;
				if (list[j] == wssss)
				{
					if (ttsss.siblings[tssss].rightRoundingPointsDistance - num2 < num)
					{
						num = ttsss.siblings[tssss].rightRoundingPointsDistance - num2 - 2f;
					}
					num2 = 0f;
					flag = true;
				}
			}
			if (vector4 == Vector3.zero)
			{
				vector4 = Vector3.Lerp(list[list.Count - 3], list[list.Count - 2], 0.5f);
				num6 = list.Count - 2;
			}
			Vector3 b = vector;
			Vector3 normalized = (vector4 - vector3).normalized;
			Vector3 a = vector2;
			Vector3 normalized2 = (vector3 - vector4).normalized;
			Vector3 vector5 = vector4;
			Vector3 vector6 = vector3;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = vssss * 0.5f;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			Vector3 zero4 = Vector3.zero;
			for (int k = 0; (float)k <= num12; k++)
			{
				Vector3 vector7 = Vector3.Lerp(normalized, b, (float)k * 1f / (num12 * 1f));
				zero = vector6 - vector7 * 100f;
				zero2 = vector6 + vector7 * 100f;
				ll1.Add(zero);
				ll2.Add(zero2);
				vector7 = Vector3.Lerp(a, normalized2, (float)k * 1f / (num12 * 1f));
				zero3 = vector5 - vector7 * 10f;
				zero4 = vector5 + vector7 * 10f;
				ll3.Add(zero3);
				ll4.Add(zero4);
				zero = OQQOCDQCQD.OCDCQCDDCC(zero, zero2, zero3, zero4, flag: false);
				zero.y = Mathf.Lerp(vector4.y, vector3.y, (float)k * 1f / (num12 * 1f));
				ttsss.siblings[tssss].rampVecs[0].Add(zero);
			}
			ttsss.siblings[tssss].rampVecs.Add(new List<Vector3>());
			float num13 = 5f;
			if (ttsss.siblings[tssss].rampRoadType != null)
			{
				num13 = ttsss.siblings[tssss].rampRoadType.roadWidth;
			}
			if (num13 == 0f)
			{
				num13 = 5f;
			}
			for (int l = 0; l < ttsss.siblings[tssss].rampVecs[0].Count; l++)
			{
				Vector3 vector7 = ((l != 0) ? ((l != ttsss.siblings[tssss].rampVecs[0].Count - 1) ? (ttsss.siblings[tssss].rampVecs[0][l + 1] - ttsss.siblings[tssss].rampVecs[0][l - 1]) : (ttsss.siblings[tssss].rampVecs[0][ttsss.siblings[tssss].rampVecs[0].Count - 1] - ttsss.siblings[tssss].rampVecs[0][ttsss.siblings[tssss].rampVecs[0].Count - 2])) : (ttsss.siblings[tssss].rampVecs[0][1] - ttsss.siblings[tssss].rampVecs[0][0]));
				vector7 = new Vector3(vector7.z, 0f, 0f - vector7.x).normalized;
				ttsss.siblings[tssss].rampVecs[1].Add(ttsss.siblings[tssss].rampVecs[0][l] + -vector7 * num13);
			}
			Vector3 cp = Vector3.zero;
			int index = 0;
			int index2 = 0;
			flag = OQQOCDQCQD.TwoListsPointOCDCQCDDCC(ttsss.siblings[tssss].rightRoundingPoints, ttsss.siblings[tssss].rampVecs[1], ref cp, ref index, ref index2);
			if (cp != Vector3.zero)
			{
				for (int m = 0; m <= index2; m++)
				{
					ttsss.siblings[tssss].rampVecs[1].RemoveAt(0);
				}
				ttsss.siblings[tssss].rampVecs[1].Insert(0, cp);
				ttsss.siblings[tssss].rampStartStartRoundingIndex = index + 1;
				ttsss.siblings[tssss].rightRoundingPoints.Insert(index + 1, cp);
				num6++;
			}
			else
			{
				ttsss.siblings[tssss].rampStartStartRoundingIndex = 0;
				ttsss.siblings[tssss].rampVecs[1].Clear();
			}
			ttsss.siblings[tssss].rampStartEndRoundingIndex = num6;
			ttsss.siblings[tssss].rightRoundingPoints.Insert(num6, vector4);
			if (cp != Vector3.zero)
			{
				cp = Vector3.zero;
				index = 0;
				index2 = 0;
				flag = OQQOCDQCQD.TwoListsPointOCDCQCDDCC(ttsss.siblings[ussss].leftRoundingPoints, ttsss.siblings[tssss].rampVecs[1], ref cp, ref index, ref index2);
			}
			if (cp != Vector3.zero)
			{
				for (int num14 = ttsss.siblings[tssss].rampVecs[1].Count - 1; num14 > index2; num14--)
				{
					ttsss.siblings[tssss].rampVecs[1].RemoveAt(num14);
				}
				int count = ttsss.siblings[tssss].rampVecs[1].Count;
				int index3 = count / 2;
				for (int n = 1; n < count; n++)
				{
					zero = ttsss.siblings[tssss].rampVecs[1][n];
					zero.y = Mathf.Lerp(ttsss.siblings[tssss].rampVecs[1][0].y, cp.y, (float)n * 1f / ((float)count * 1f));
					ttsss.siblings[tssss].rampVecs[1][n] = zero;
				}
				int num15 = ttsss.siblings[tssss].rampVecs[0].Count - 1;
				int num16 = ttsss.siblings[tssss].rampVecs[0].Count / 2;
				float y = ttsss.siblings[tssss].rampVecs[1][index3].y;
				for (int num17 = 1; num17 <= num16; num17++)
				{
					zero = ttsss.siblings[tssss].rampVecs[0][num17];
					zero.y = Mathf.Lerp(ttsss.siblings[tssss].rampVecs[0][0].y, y, (float)num17 * 1f / ((float)num16 * 1f));
					ttsss.siblings[tssss].rampVecs[0][num17] = zero;
				}
				int num18 = num15 - num16;
				int num19 = 0;
				for (int num20 = num16 + 1; num20 <= num15; num20++)
				{
					zero = ttsss.siblings[tssss].rampVecs[0][num20];
					zero.y = Mathf.Lerp(y, ttsss.siblings[tssss].rampVecs[0][num15].y, (float)num19 * 1f / ((float)num18 * 1f));
					ttsss.siblings[tssss].rampVecs[0][num20] = zero;
					num19++;
				}
				ttsss.siblings[tssss].rampVecs[1].Add(cp);
				ttsss.siblings[ussss].rampEndStartRoundingIndex = index + 1;
				ttsss.siblings[ussss].leftRoundingPoints.Insert(index + 1, cp);
				num4++;
			}
			else
			{
				ttsss.siblings[ussss].rampEndStartRoundingIndex = 0;
			}
			ttsss.siblings[ussss].rampEndEndRoundingIndex = num4;
			ttsss.siblings[ussss].leftRoundingPoints.Insert(num4, vector3);
			if (0 == 0)
			{
			}
		}

		private void xssss(int tssss, int ussss, float vssss, float wssss, Vector3 xssss)
		{
			ttsss.siblings[tssss].rampVecs.Add(new List<Vector3>());
			List<Vector3> list = new List<Vector3>(ttsss.siblings[tssss].rightRoundingPoints);
			List<Vector3> list2 = new List<Vector3>(ttsss.siblings[ussss].leftRoundingPoints);
			if (tssss == 0)
			{
				parallelPoints = list2;
			}
			float num = 0f;
			float num2 = 0f;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			Vector3 vector4 = Vector3.zero;
			int num3 = 0;
			bool flag = false;
			for (int i = 0; i < list2.Count - 1; i++)
			{
				if (flag)
				{
					num2 = Vector3.Distance(list2[i], list2[i + 1]);
					if (num + num2 > vssss)
					{
						vector = (list2[i] - list2[i + 1]).normalized;
						float num4 = vssss - num;
						vector3 = list2[i] + -vector * num4;
						num3 = i + 1;
						break;
					}
					num += num2;
				}
				if (list2[i] == xssss)
				{
					flag = true;
				}
			}
			if (vector3 == Vector3.zero)
			{
				vector = (list2[list2.Count - 2] - list2[list2.Count - 1]).normalized;
				vector3 = list2[list2.Count - 1] + -vector * (vssss - num);
				num3 = list2.Count;
			}
			num = (num2 = 0f);
			int num5 = 0;
			flag = false;
			for (int j = 0; j < list.Count - 1; j++)
			{
				if (flag)
				{
					num2 = Vector3.Distance(list[j], list[j + 1]);
					if (num + num2 > vssss)
					{
						vector2 = (list[j] - list[j + 1]).normalized;
						float num6 = vssss - num;
						vector4 = list[j] + -vector2 * num6;
						num5 = j + 1;
						break;
					}
					num += num2;
				}
				if (list[j] == xssss)
				{
					flag = true;
				}
			}
			if (vector4 == Vector3.zero)
			{
				vector2 = (list[list.Count - 2] - list[list.Count - 1]).normalized;
				vector4 = list[list.Count - 1] + -vector2 * (vssss - num);
				num5 = list.Count;
			}
			if (tssss == 0)
			{
				parallelPoints = list2;
			}
			Vector3 b = vector;
			Vector3 normalized = (vector4 - vector3).normalized;
			Vector3 a = vector2;
			Vector3 normalized2 = (vector3 - vector4).normalized;
			Vector3 vector5 = vector4;
			Vector3 vector6 = vector3;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			Vector3 zero4 = Vector3.zero;
			List<Vector3> list3 = new List<Vector3>();
			List<Vector3> list4 = new List<Vector3>();
			int num11 = Mathf.RoundToInt(0.5f * wssss);
			for (int k = 0; (float)k <= wssss; k++)
			{
				Vector3 vector7 = Vector3.Lerp(normalized, b, (float)k * 1f / (wssss * 1f));
				zero = vector6 - vector7 * 15f;
				zero2 = vector6 + vector7 * 15f;
				ll1.Add(zero);
				ll2.Add(zero2);
				vector7 = Vector3.Lerp(a, normalized2, (float)k * 1f / (wssss * 1f));
				zero3 = vector5 - vector7 * 15f;
				zero4 = vector5 + vector7 * 15f;
				ll3.Add(zero3);
				ll4.Add(zero4);
				if (tssss == 0 && k == 0)
				{
					tp1 = zero;
					tp2 = zero2;
					tp3 = zero3;
					tp4 = zero4;
				}
				zero = OQQOCDQCQD.OCDCQCDDCC(zero, zero2, zero3, zero4, flag: false);
				zero.y = Mathf.Lerp(vector4.y, vector3.y, (float)k * 1f / (wssss * 1f));
				ttsss.siblings[tssss].rampVecs[0].Add(zero);
				if (k <= num11)
				{
					list3.Add(zero);
				}
				if (k >= num11)
				{
					list4.Add(zero);
				}
			}
			list3.Reverse();
			if (num5 > 0)
			{
				ttsss.siblings[tssss].rightRoundingPoints.RemoveRange(0, num5 - 1);
			}
			else if (num5 >= 0)
			{
				ttsss.siblings[tssss].rightRoundingPoints.RemoveRange(0, num5);
			}
			ttsss.siblings[tssss].rightRoundingPoints.InsertRange(0, list3);
			if (num3 > 0)
			{
				ttsss.siblings[ussss].leftRoundingPoints.RemoveRange(0, num3 - 1);
			}
			else if (num3 >= 0)
			{
				ttsss.siblings[ussss].leftRoundingPoints.RemoveRange(0, num3);
			}
			ttsss.siblings[ussss].leftRoundingPoints.InsertRange(0, list4);
			if (tssss == -1)
			{
				parallelPoints.AddRange(ttsss.siblings[ussss].leftRoundingPoints);
			}
		}

		private void TriangulateCenter(ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<int> tris)
		{
			vecs.Add(Vector3.zero);
			uvs.Add(Vector2.zero);
			if (!parallelRoads[0])
			{
				vecs.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[1].leftRoundingPoints[0]));
				uvs.Add(Vector2.zero);
			}
			else
			{
				vecs.Add(ttsss.siblings[2].leftRoundingPoints[0]);
				uvs.Add(Vector2.zero);
			}
			if (!parallelRoads[1])
			{
				vecs.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[4].leftRoundingPoints[0]));
				uvs.Add(Vector2.zero);
			}
			else
			{
				vecs.Add(ttsss.siblings[5].leftRoundingPoints[0]);
				uvs.Add(Vector2.zero);
			}
			if (!parallelRoads[2])
			{
				vecs.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[7].leftRoundingPoints[0]));
				uvs.Add(Vector2.zero);
			}
			else
			{
				vecs.Add(ttsss.siblings[8].leftRoundingPoints[0]);
				uvs.Add(Vector2.zero);
			}
			if (!parallelRoads[3])
			{
				vecs.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[10].leftRoundingPoints[0]));
				uvs.Add(Vector2.zero);
			}
			else
			{
				vecs.Add(ttsss.siblings[11].leftRoundingPoints[0]);
				uvs.Add(Vector2.zero);
			}
			List<Vector3> list = new List<Vector3>(vecs);
			list.RemoveAt(0);
			tris = Triangulate(vecs, list);
		}

		private void yssst(int tssss, int ussss, int vssss, ref List<Vector3> wssss, ref List<Vector2> xssss, ref List<int> yssss, Vector3 Assss, Vector3 _0ssss, int _1ssss, Vector3 _2ssss)
		{
			List<Vector3> ussss2 = new List<Vector3>();
			List<Vector2> wssss2 = new List<Vector2>();
			List<int> list = new List<int>();
			if (parallelRoads[_1ssss])
			{
				_0ssst(tssss, vssss, ref ussss2, ref wssss2, ttsss.siblings[tssss].leftRoundingPoints, ttsss.siblings[tssss].rightRoundingPoints, ttsss.siblings[vssss].leftRoundingPoints, ttsss.siblings[vssss].rightRoundingPoints, Assss, _0ssss, ref ttsss.siblings[tssss].connectionVecInts, ref ttsss.siblings[vssss].connectionVecInts, wssss.Count, _2ssss, _1ssss);
			}
			if (!parallelRoads[_1ssss])
			{
				this.Assss(ussss, ref ussss2, ref wssss2, ttsss.siblings[ussss].leftRoundingPoints, ttsss.siblings[ussss].rightRoundingPoints, Assss, _0ssss, ref ttsss.siblings[ussss].connectionVecInts, wssss.Count, _1ssss);
			}
			int count = wssss.Count;
			if (ussss2.Count < 3)
			{
				if (!parallelRoads[_1ssss])
				{
					return;
				}
			}
			else
			{
				list = Triangulate(ussss2, ussss2);
				for (int i = 0; i < list.Count; i++)
				{
					list[i] += count;
				}
				wssss.AddRange(ussss2);
				xssss.AddRange(wssss2);
				yssss.AddRange(list);
			}
			if (!ramps[_1ssss])
			{
				return;
			}
			ussss2.Clear();
			wssss2.Clear();
			list.Clear();
			int num = 0;
			if (parallelRoads[_1ssss])
			{
				num = tssss;
			}
			if (!parallelRoads[_1ssss])
			{
				num = ussss;
			}
			if (ttsss.crossingElements[vssss].connectedRoad != null)
			{
			}
			int num2 = 0;
			int num3 = _1ssss - 1;
			if (num3 == -1)
			{
				num3 = 3;
			}
			switch (num3)
			{
			case 0:
				num2 = 2;
				break;
			case 1:
				num2 = 5;
				break;
			case 2:
				num2 = 8;
				break;
			case 3:
				num2 = 11;
				break;
			}
			if (!parallelRoads[num3])
			{
				num2--;
			}
			this._1ssss(num, num2, ref ussss2, ref wssss2, ttsss.siblings[num].rightRoundingPoints, ttsss.siblings[num].rampVecs, ttsss.siblings[num2].leftRoundingPoints);
			if (ussss2.Count >= 3)
			{
				list = Triangulate(ussss2, ussss2);
				count = wssss.Count;
				for (int j = 0; j < list.Count; j++)
				{
					list[j] += count;
				}
				wssss.AddRange(ussss2);
				xssss.AddRange(wssss2);
				yssss.AddRange(list);
			}
		}

		private void Assss(int tssss, ref List<Vector3> ussss, ref List<Vector2> vssss, List<Vector3> wssss, List<Vector3> xssss, Vector3 yssss, Vector3 Assss, ref List<int> _0ssss, int _1ssss, int _2ssss)
		{
			_0ssss.Clear();
			List<Vector3> list = new List<Vector3>(wssss);
			int num = _2ssss + 1;
			if (num >= 4)
			{
				num = 0;
			}
			if (ramps[num])
			{
				int num2 = 0;
				while (num2 < list.Count && list[num2] != Assss)
				{
					list.RemoveAt(num2);
					num2--;
					num2++;
				}
			}
			List<Vector3> list2 = new List<Vector3>(xssss);
			if (ramps[_2ssss])
			{
				int num3 = 0;
				while (num3 < list2.Count && list2[num3] != yssss)
				{
					list2.RemoveAt(num3);
					num3--;
					num3++;
				}
			}
			list2.Reverse();
			ussss.Add(Vector3.zero);
			vssss.Add(Vector2.zero);
			for (int i = 0; i < list.Count; i++)
			{
				ussss.Add(ttsss.transform.InverseTransformPoint(list[i]));
				vssss.Add(Vector2.zero);
			}
			_0ssss.Add(_1ssss + ussss.Count - 1);
			if (ttsss.siblings[tssss].roadShape.Count > 2)
			{
				Vector3 position = Vector3.Lerp(list[list.Count - 1], list2[0], 0.5f);
				ussss.Add(ttsss.transform.InverseTransformPoint(position));
				vssss.Add(Vector2.zero);
				_0ssss.Add(_1ssss + ussss.Count - 1);
			}
			_0ssss.Add(_1ssss + ussss.Count);
			for (int j = 0; j < list2.Count; j++)
			{
				ussss.Add(ttsss.transform.InverseTransformPoint(list2[j]));
				vssss.Add(Vector2.zero);
			}
			if (tssss == -1)
			{
				for (int k = 0; k < ussss.Count; k++)
				{
					parallelPoints.Add(ussss[k]);
				}
			}
		}

		private void _0ssst(int tssss, int ussss, ref List<Vector3> vssss, ref List<Vector2> wssss, List<Vector3> xssss, List<Vector3> yssss, List<Vector3> Assss, List<Vector3> _0ssss, Vector3 _1ssss, Vector3 _2ssss, ref List<int> _3ssss, ref List<int> _4ssss, int ttsss, Vector3 utsss, int vtsss)
		{
			_3ssss.Clear();
			_4ssss.Clear();
			List<Vector3> list = new List<Vector3>(xssss);
			List<Vector3> list2 = new List<Vector3>(Assss);
			List<Vector3> list3 = new List<Vector3>(yssss);
			List<Vector3> list4 = new List<Vector3>(_0ssss);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = vtsss + 1;
			if (num5 >= 4)
			{
				num5 = 0;
			}
			if (ramps[num5])
			{
				int num6 = 0;
				while (num6 < list2.Count)
				{
					if (list2[num6] != _2ssss)
					{
						list2.RemoveAt(num6);
						num6--;
						num4++;
						num6++;
						continue;
					}
					num3 = num6;
					list4.RemoveRange(0, num4 - 1);
					break;
				}
			}
			if (this.ttsss.siblings[tssss].road != null)
			{
				list4.RemoveAt(0);
				list4.RemoveAt(0);
			}
			num4 = 0;
			if (ramps[vtsss])
			{
				int num7 = 0;
				while (num7 < list3.Count)
				{
					if (list3[num7] != _1ssss)
					{
						list3.RemoveAt(num7);
						num7--;
						num4++;
						num7++;
						continue;
					}
					num3 = num7;
					list.RemoveRange(0, num4 - 1);
					break;
				}
			}
			if (this.ttsss.siblings[tssss].road != null)
			{
				list.RemoveAt(0);
				list.RemoveAt(0);
			}
			float num8 = Vector3.Distance(list3[0], base.transform.position);
			float num9 = Vector3.Distance(list2[0], base.transform.position);
			float num10 = ((num8 < num9) ? num9 : num8);
			num8 = Vector3.Distance(list[0], base.transform.position);
			int num11 = 0;
			while (num11 < list.Count - 1 && num8 < num10 && list.Count > 3)
			{
				list.RemoveAt(num11);
				num8 += Vector3.Distance(list[num11], list[num11 + 1]);
				num11--;
				num11++;
			}
			num8 = Vector3.Distance(list4[0], base.transform.position);
			int num12 = 0;
			while (num12 < list4.Count - 1 && num8 < num10 && list4.Count > 3)
			{
				list4.RemoveAt(num12);
				num8 += Vector3.Distance(list4[num12], list4[num12 + 1]);
				num12--;
				num12++;
			}
			num8 = Vector3.Distance(this.ttsss.transform.position, list[0]);
			num9 = Vector3.Distance(this.ttsss.transform.position, list4[0]);
			if (num8 > num9)
			{
				list[0] += (list[0] - list[1]).normalized * 50f;
				list[0] = OQQOCDQCQD.OCOOQOQCDC(list[0], list[1], list4[0]);
				list.Insert(1, Vector3.Lerp(list[0], list[1], 0.5f));
			}
			else
			{
				list4[0] += (list4[0] - list4[1]).normalized * 50f;
				list4[0] = OQQOCDQCQD.OCOOQOQCDC(list4[0], list4[1], list[0]);
				list4.Insert(1, Vector3.Lerp(list4[0], list4[1], 0.5f));
			}
			vssss.Add(Vector3.zero);
			wssss.Add(Vector2.zero);
			for (int i = 0; i < list2.Count; i++)
			{
				vssss.Add(this.ttsss.transform.InverseTransformPoint(list2[i]));
				wssss.Add(Vector2.zero);
			}
			_4ssss.Add(ttsss + vssss.Count - 1);
			if (this.ttsss.siblings[ussss].roadShape.Count > 2)
			{
				Vector3 position = Vector3.Lerp(list2[list2.Count - 1], list4[list4.Count - 1], 0.5f);
				vssss.Add(this.ttsss.transform.InverseTransformPoint(position));
				wssss.Add(Vector2.zero);
				_4ssss.Add(ttsss + vssss.Count - 1);
			}
			_4ssss.Add(ttsss + vssss.Count);
			list4.Reverse();
			for (int j = 0; j < list4.Count; j++)
			{
				vssss.Add(this.ttsss.transform.InverseTransformPoint(list4[j]));
				wssss.Add(Vector2.zero);
			}
			for (int k = 0; k < list.Count; k++)
			{
				vssss.Add(this.ttsss.transform.InverseTransformPoint(list[k]));
				wssss.Add(Vector2.zero);
			}
			_3ssss.Add(ttsss + vssss.Count - 1);
			if (this.ttsss.siblings[tssss].roadShape.Count > 2)
			{
				Vector3 position2 = Vector3.Lerp(list[list.Count - 1], list3[list3.Count - 1], 0.5f);
				vssss.Add(this.ttsss.transform.InverseTransformPoint(position2));
				wssss.Add(Vector2.zero);
				_3ssss.Add(ttsss + vssss.Count - 1);
			}
			_3ssss.Add(ttsss + vssss.Count);
			list3.Reverse();
			vssss.Add(this.ttsss.transform.InverseTransformPoint(list3[0]));
			wssss.Add(Vector2.zero);
			for (int l = 0; l < list3.Count; l++)
			{
				vssss.Add(this.ttsss.transform.InverseTransformPoint(list3[l]));
				wssss.Add(Vector2.zero);
			}
			if (tssss == -1)
			{
				for (int m = 0; m < vssss.Count; m++)
				{
					parallelPoints.Add(vssss[m]);
				}
			}
		}

		private void _1ssss(int tssss, int ussss, ref List<Vector3> vssss, ref List<Vector2> wssss, List<Vector3> xssss, List<List<Vector3>> yssss, List<Vector3> Assss)
		{
			if (ttsss.siblings[tssss].rampStartStartRoundingIndex != 0 && ttsss.siblings[tssss].rampStartEndRoundingIndex < ttsss.siblings[tssss].rightRoundingPoints.Count)
			{
				for (int i = ttsss.siblings[tssss].rampStartStartRoundingIndex; i <= ttsss.siblings[tssss].rampStartEndRoundingIndex; i++)
				{
					vssss.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[tssss].rightRoundingPoints[i]));
					wssss.Add(Vector3.zero);
				}
				vssss.Reverse();
				wssss.Reverse();
				if (vssss[0] == vssss[1])
				{
					vssss.RemoveAt(0);
					wssss.RemoveAt(0);
				}
			}
			for (int j = 0; j < ttsss.siblings[tssss].rampVecs[1].Count; j++)
			{
				vssss.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[tssss].rampVecs[1][j]));
				wssss.Add(Vector3.zero);
			}
			if (ttsss.siblings[ussss].rampEndStartRoundingIndex != 0 && ttsss.siblings[ussss].rampEndEndRoundingIndex < ttsss.siblings[ussss].leftRoundingPoints.Count)
			{
				for (int k = ttsss.siblings[ussss].rampEndStartRoundingIndex; k <= ttsss.siblings[ussss].rampEndEndRoundingIndex; k++)
				{
					vssss.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[ussss].leftRoundingPoints[k]));
					wssss.Add(Vector3.zero);
				}
				if (vssss[vssss.Count - 1] == vssss[vssss.Count - 2])
				{
					vssss.RemoveAt(vssss.Count - 1);
					wssss.RemoveAt(vssss.Count - 1);
				}
			}
			for (int num = ttsss.siblings[tssss].rampVecs[0].Count - 1; num >= 0; num--)
			{
				vssss.Add(ttsss.transform.InverseTransformPoint(ttsss.siblings[tssss].rampVecs[0][num]));
				wssss.Add(Vector3.zero);
			}
			if (vssss[vssss.Count - 1] == vssss[0])
			{
				vssss.RemoveAt(vssss.Count - 1);
				wssss.RemoveAt(vssss.Count - 1);
			}
		}

		private void _2ssst(out float tssss, out float ussss, out float vssss, out float wssss)
		{
			int[] array = new int[6] { 0, 1, 2, 6, 7, 8 };
			tssss = 0f;
			if (!parallelRoads[0])
			{
				if (ttsss.crossingElements[1].connectedRoad != null)
				{
					tssss = ttsss.crossingElements[1].connectedRoad.roadWidth;
				}
				else
				{
					tssss = defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[0].connectedRoad != null)
			{
				tssss = ttsss.crossingElements[0].connectedRoad.roadWidth;
				tssss += bottomIslandSize;
				if (ttsss.crossingElements[2].connectedRoad != null)
				{
					tssss += ttsss.crossingElements[2].connectedRoad.roadWidth;
				}
				else
				{
					tssss += defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[2].connectedRoad != null)
			{
				tssss = ttsss.crossingElements[2].connectedRoad.roadWidth;
				tssss += bottomIslandSize + (float)defaultRoadWidth;
			}
			else
			{
				tssss = (float)(2 * defaultRoadWidth) + bottomIslandSize;
			}
			if (tssss == 0f)
			{
				tssss = defaultIntersectionSize;
			}
			ussss = 0f;
			if (!parallelRoads[1])
			{
				if (ttsss.crossingElements[4].connectedRoad != null)
				{
					ussss = ttsss.crossingElements[4].connectedRoad.roadWidth;
				}
				else
				{
					ussss = defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[3].connectedRoad != null)
			{
				ussss = ttsss.crossingElements[3].connectedRoad.roadWidth;
				ussss += leftIslandSize;
				if (ttsss.crossingElements[5].connectedRoad != null)
				{
					ussss += ttsss.crossingElements[5].connectedRoad.roadWidth;
				}
				else
				{
					ussss += defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[5].connectedRoad != null)
			{
				ussss = ttsss.crossingElements[5].connectedRoad.roadWidth;
				ussss += leftIslandSize + (float)defaultRoadWidth;
			}
			else
			{
				ussss = (float)(2 * defaultRoadWidth) + leftIslandSize;
			}
			if (ussss == 0f)
			{
				ussss = defaultIntersectionSize;
			}
			vssss = 0f;
			if (!parallelRoads[2])
			{
				if (ttsss.crossingElements[7].connectedRoad != null)
				{
					vssss = ttsss.crossingElements[7].connectedRoad.roadWidth;
				}
				else
				{
					vssss = defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[6].connectedRoad != null)
			{
				vssss = ttsss.crossingElements[6].connectedRoad.roadWidth;
				vssss += leftIslandSize;
				if (ttsss.crossingElements[8].connectedRoad != null)
				{
					vssss += ttsss.crossingElements[8].connectedRoad.roadWidth;
				}
				else
				{
					vssss += defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[8].connectedRoad != null)
			{
				vssss = ttsss.crossingElements[8].connectedRoad.roadWidth;
				vssss += leftIslandSize + (float)defaultRoadWidth;
			}
			else
			{
				vssss = (float)(2 * defaultRoadWidth) + leftIslandSize;
			}
			if (vssss == 0f)
			{
				vssss = defaultIntersectionSize;
			}
			wssss = 0f;
			if (!parallelRoads[3])
			{
				if (ttsss.crossingElements[10].connectedRoad != null)
				{
					wssss = ttsss.crossingElements[10].connectedRoad.roadWidth;
				}
				else
				{
					wssss = defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[9].connectedRoad != null)
			{
				wssss = ttsss.crossingElements[9].connectedRoad.roadWidth;
				wssss += leftIslandSize;
				if (ttsss.crossingElements[11].connectedRoad != null)
				{
					wssss += ttsss.crossingElements[11].connectedRoad.roadWidth;
				}
				else
				{
					wssss += defaultRoadWidth;
				}
			}
			else if (ttsss.crossingElements[11].connectedRoad != null)
			{
				wssss = ttsss.crossingElements[11].connectedRoad.roadWidth;
				wssss += leftIslandSize + (float)defaultRoadWidth;
			}
			else
			{
				wssss = (float)(2 * defaultRoadWidth) + leftIslandSize;
			}
			if (wssss == 0f)
			{
				wssss = defaultIntersectionSize;
			}
		}

		public static void GetOCCDOCDDCQ(Vector3 cp, float radius, int cornerSegments, Vector3 leftPoint, Vector3 rightPoint, ref List<Vector3> leftpoints, ref List<Vector3> rightpoints, bool flag, ERConnectionSibling sibling)
		{
		}

		public void OOOQCCODDC(QDOODOQQDQODD connection, ERConnectionSibling sibling, int index, int total)
		{
			if (sibling == null)
			{
				return;
			}
			ERConnectionSibling eRConnectionSibling = null;
			ERConnectionSibling eRConnectionSibling2 = null;
			if (sibling.leftRoundingPoints.Count <= 1)
			{
				return;
			}
			connection.centerPoint = (connection.tmpCenterPoint = ttsss.transform.InverseTransformPoint(Vector3.Lerp(sibling.leftRoundingPoints[sibling.leftRoundingPoints.Count - 1], sibling.rightRoundingPoints[sibling.rightRoundingPoints.Count - 1], 0.5f)));
			Vector3 normalized = new Vector3(sibling.forward.x, 0f, sibling.forward.z).normalized;
			sibling.controlPoint = (connection.controlPointV3 = connection.centerPoint + normalized * 25f);
			connection.controlPointV3 = ttsss.transform.InverseTransformPoint(connection.endControlPoint);
			connection.controlPoint = new Vector3(connection.controlPointV3.x, connection.controlPointV3.z);
			connection.rotationPriority = false;
			normalized = (sibling.controlPoint - connection.centerPoint).normalized;
			connection.alignmentHandleVec = connection.centerPoint + normalized * 2f;
			if (sibling.roadType != null)
			{
				connection.roadType = sibling.roadType.id;
			}
			connection.connectionVecInts.Clear();
			connection.blendCornerPointInts.Clear();
			connection.blendCornerPointWeights.Clear();
			connection.roadShapeUVY.Clear();
			QDOQDSQOOQDDD qDOQDSQOOQDDD = null;
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			connection.connectionVecInts = new List<int>(sibling.connectionVecInts);
			connection.roadShapeUVY.Clear();
			for (int i = 0; i < sibling.roadShape.Count; i++)
			{
				connection.roadShapeUVY.Add(sibling.roadShapeUVs[i]);
			}
			connection.sidewalkRightUVY.Clear();
			connection.sidewalkRightConnectionVecInts.Clear();
			if (connection.includeRightSidewalk)
			{
			}
			connection.fullConnectionVecInts = new List<int>(connection.connectionVecInts);
			connection.leftInt = 0;
			connection.leftIntFull = 0;
			connection.rightInt = connection.connectionVecInts.Count - 1;
			connection.rightIntFull = connection.fullConnectionVecInts.Count - 1;
			connection.roadShapeVecs.Clear();
			connection.sidewalkLeftVecs.Clear();
			connection.sidewalkRightVecs.Clear();
			Vector3 b;
			Vector3 a;
			Vector3 b2;
			Vector3 vector = (b = (a = (b2 = Vector3.zero)));
			if (sibling.leftSidewalk != null && sibling.leftSidewalkVecs.Count > 0)
			{
				a = sibling.leftSidewalkVecs[0][0];
			}
			else if (sibling.leftRoundingPoints.Count > 0)
			{
				a = ttsss.transform.TransformPoint(sibling.leftRoundingPoints[sibling.leftRoundingPoints.Count - 1]);
			}
			if (sibling.rightSidewalk != null && sibling.rightSidewalkVecs.Count > 0)
			{
				b2 = sibling.rightSidewalkVecs[sibling.rightSidewalkVecs.Count - 1][0];
			}
			else if (sibling.rightRoundingPoints.Count > 0)
			{
				b2 = ttsss.transform.TransformPoint(sibling.rightRoundingPoints[sibling.rightRoundingPoints.Count - 1]);
			}
			Vector3 centerPoint = connection.centerPoint;
			float num = Vector3.Distance(a, b2) * 0.5f;
			for (int j = 0; j < connection.connectionVecInts.Count - 1; j++)
			{
			}
			List<Vector2> list = new List<Vector2>();
			if (connection.includeLeftSidewalk && sibling.leftSidewalkVecs.Count > 0)
			{
				list.AddRange(connection.sidewalkLeftVecs);
				Debug.Log("check if we have to reverse with new sidwalk code!!!");
				connection.roadShapeVecs.AddRange(list);
			}
			list.Clear();
			list.AddRange(sibling.roadShape);
			if (sibling.leftRoundingPoints.Count > 0)
			{
				if (vector == Vector3.zero)
				{
					vector = ttsss.transform.TransformPoint(sibling.leftRoundingPoints[sibling.leftRoundingPoints.Count - 1]);
				}
				b = ttsss.transform.TransformPoint(sibling.rightRoundingPoints[sibling.rightRoundingPoints.Count - 1]);
			}
			connection.roadShapeVecs.AddRange(list);
			if (connection.includeRightSidewalk && sibling.rightSidewalkVecs.Count > 0)
			{
				Debug.Log("check if we have to reverse with new sidwalk code!!!");
				list.Clear();
				list.AddRange(connection.sidewalkRightVecs);
				connection.roadShapeVecs.AddRange(list);
			}
			vector.y = 0f;
			b.y = 0f;
			float num2 = Vector3.Distance(vector, b);
			connection.centerPointPercentage = num / num2;
			connection.roadShapeVecsString = ERCrossings.GetRoadShapeVecString(connection.roadShapeVecs, connection.sidewalkLeftVecs, connection.sidewalkRightVecs, ref connection.roadShapeMatchCount);
			QDOODOQQDQODD qDOODOQQDQODD = ttsss.crossingElements[index];
			if (sibling.roadType != null)
			{
				connection.roadMaterial = sibling.roadType.roadMaterial;
			}
			else if (connection.rt != null)
			{
				connection.roadMaterial = connection.rt.roadMaterial;
			}
			List<Material> list2 = new List<Material>();
			List<int> list3 = new List<int>();
			list2.Add(connection.roadMaterial);
			int num3 = 0;
			for (int k = 0; k < sibling.roadType.roadShape.Count; k++)
			{
				list3.Add(0);
			}
			int num4 = 0;
			connection.roadMaterials = list2.ToArray();
			connection.roadShapeMaterialInts.Clear();
			connection.roadShapeMaterialInts.AddRange(list3);
			connection.roadMaterial = sibling.roadType.roadMaterial;
			List<bool> list4 = new List<bool>();
			if (connection.rt != null)
			{
				list4 = new List<bool>(connection.rt.doConnectionTri);
			}
			else
			{
				list4.Add(item: true);
				list4.Add(item: true);
			}
			List<bool> list5 = new List<bool>();
			if (connection.rt != null)
			{
				list5 = new List<bool>(connection.rt.hardEdge);
			}
			else
			{
				list5.Add(item: true);
				list5.Add(item: true);
			}
			connection.doConnectionTri.Clear();
			connection.doConnectionTri = new List<bool>(list4);
			connection.hardEdge.Clear();
			connection.hardEdge = new List<bool>(list5);
			if (connection.rt != null)
			{
				connection.roadTypeTimestamp = connection.rt.timestamp;
			}
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
