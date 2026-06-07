using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERMarkerExt : ScriptableObject
	{
		[HideInInspector]
		public long OSMNodeID = 0L;

		public bool activeSplineNode = true;

		public float leftIndent = 5f;

		public int leftIndentAlignment = 0;

		public float rightIndent = 5f;

		public int rightIndentAlignment = 0;

		public float leftSurrounding = 5f;

		public float rightSurrounding = 5f;

		public float leftSurroundingAdjusted = 5f;

		public float rightSurroundingAdjusted = 5f;

		public float radius = 0f;

		[HideInInspector]
		public bool bridgeObject = false;

		[HideInInspector]
		public float bridgeStartLevelDistance = 0f;

		[HideInInspector]
		public float bridgeEndLevelDistance = 0f;

		public float rotation = 0f;

		[HideInInspector]
		public Vector3 position = Vector3.zero;

		[HideInInspector]
		public Vector3 oldPosition = Vector3.zero;

		[HideInInspector]
		public Vector3 positionTmp = Vector3.zero;

		[HideInInspector]
		public int controlType = 0;

		[HideInInspector]
		public int controlTypeTmp = 0;

		[HideInInspector]
		public int rotations = 0;

		[HideInInspector]
		public float circularRadius = 1f;

		[HideInInspector]
		public float circularAngle = 90f;

		[HideInInspector]
		public int circularSegments = 10;

		[HideInInspector]
		public float splineStrength = 0.5f;

		[HideInInspector]
		public Vector3 direction;

		[HideInInspector]
		public Vector3 direction1;

		[HideInInspector]
		public Vector3 rl;

		[HideInInspector]
		public Vector3 rr;

		public bool followTerrainContours = false;

		[HideInInspector]
		public int startSplinePoint = 0;

		[HideInInspector]
		public float startDistance = 0f;

		[HideInInspector]
		public float startUVY = 0f;

		public float totalDistance = 0f;

		[HideInInspector]
		public string totalDistanceString = "";

		public float slopeAngle = 0f;

		[HideInInspector]
		public string angleString = "";

		[HideInInspector]
		public string gradeString = "";

		[HideInInspector]
		public float rotationCenter = 0.5f;

		[HideInInspector]
		public List<ERSOMarkerExt> soData = new List<ERSOMarkerExt>();

		[HideInInspector]
		public ERMarkerControlType controllerType;

		[HideInInspector]
		public float randomYPosition = 0f;

		[HideInInspector]
		public float randomMinYPosition = -0.02f;

		[HideInInspector]
		public float randomMaxYPosition = 0.02f;

		[HideInInspector]
		public float minRandomYPositionDistance = 15f;

		[HideInInspector]
		public float maxRandomYPositionDistance = 35f;

		[HideInInspector]
		public float randomMinRotation = -1f;

		[HideInInspector]
		public float randomMaxRotation = 1f;

		[HideInInspector]
		public float minRandomRotationDistance = 15f;

		[HideInInspector]
		public float maxRandomRotationDistance = 35f;

		[HideInInspector]
		public float prevLeftIndent = 0f;

		[HideInInspector]
		public float prevRightIndent = 0f;

		[HideInInspector]
		public float prevLeftSurrounding = 0f;

		[HideInInspector]
		public float prevRightSurrounding = 0f;

		[HideInInspector]
		public int prevControlType = 0;

		[HideInInspector]
		public bool snappedMarker = false;

		[HideInInspector]
		public bool attachExit = false;

		[HideInInspector]
		public int exitType = 0;

		[HideInInspector]
		public int exitGeometryType;

		[HideInInspector]
		public int startExitInt = 0;

		[HideInInspector]
		public int endExitInt = 0;

		public float startExitOffset = 0f;

		[HideInInspector]
		public float extrusionDistance = 10f;

		[HideInInspector]
		public int extrusionType = 0;

		[HideInInspector]
		public float fixedDistance = 10f;

		[HideInInspector]
		public float connectionAngle = 10f;

		[HideInInspector]
		public float connectionRadius = 5f;

		[HideInInspector]
		public Material exitMaterial;

		[HideInInspector]
		public Material connectionMaterial;

		[HideInInspector]
		public int exitRoadType = 0;

		[HideInInspector]
		public int connectionRoadType = 0;

		[HideInInspector]
		public List<List<Vector3>> exitOuterVerticesExtrusion = new List<List<Vector3>>();

		[HideInInspector]
		public List<List<Vector3>> exitOuterVerticesFixed = new List<List<Vector3>>();

		[HideInInspector]
		public List<List<Vector3>> exitOuterVerticesCurve = new List<List<Vector3>>();

		[HideInInspector]
		public List<Vector3> exitInnerVertices = new List<Vector3>();

		[HideInInspector]
		public Color customColor = Color.red;

		[HideInInspector]
		public float roadMarkerWidth = 0f;

		[HideInInspector]
		public List<Vector2> roadShape = new List<Vector2>();

		[HideInInspector]
		public List<Vector3> roadShapeVecsGlobal = new List<Vector3>();

		[HideInInspector]
		public float roadShapeDistanceMin = 0f;

		[HideInInspector]
		public float roadShapeDistanceMax = 1f;

		[HideInInspector]
		public Vector3 perpDir = Vector3.zero;

		[HideInInspector]
		public Vector3 perpDirRotated = Vector3.zero;

		[HideInInspector]
		public float markerStartUVY = 0f;

		[HideInInspector]
		public List<Vector3> customPoints = new List<Vector3>();

		[HideInInspector]
		public GameObject handleObject = null;

		public void Init(Vector3 pos, ERModularRoad scr, int element)
		{
			position = pos;
			splineStrength = 0.5f;
			followTerrainContours = scr.followTerrainContours;
			controlType = scr.defaultControlType;
			customColor = scr.vertexColor;
			leftIndent = scr.indent;
			rightIndent = scr.indent;
			leftSurrounding = scr.surrounding;
			rightSurrounding = scr.surrounding;
			if (scr.markersExt.Count == 0 || element - 1 < 0)
			{
				roadShape = new List<Vector2>(scr.roadShape);
			}
			else if (element == 0)
			{
				roadShape = new List<Vector2>(scr.markersExt[0].roadShape);
			}
			else
			{
				roadShape = new List<Vector2>(scr.markersExt[element - 1].roadShape);
			}
			randomMinYPosition = scr.randomMinYPosition;
			randomMaxYPosition = scr.randomMaxYPosition;
			minRandomYPositionDistance = scr.minRandomYPositionDistance;
			maxRandomYPositionDistance = scr.maxRandomYPositionDistance;
			randomMinRotation = scr.randomMinRotation;
			randomMaxRotation = scr.randomMaxRotation;
			minRandomRotationDistance = scr.minRandomRotationDistance;
			maxRandomRotationDistance = scr.maxRandomRotationDistance;
			QDQDOOQQDQODD qDQDOOQQDQODD = null;
			if (scr.markersExt.Count == 0 && scr.roadType != 0.0)
			{
				if (scr.baseScript == null)
				{
					if ((bool)scr.transform.parent.parent.gameObject.GetComponent<ERModularBase>())
					{
						scr.baseScript = scr.transform.parent.parent.gameObject.GetComponent<ERModularBase>();
					}
					else if ((bool)scr.transform.parent.parent.parent.gameObject.GetComponent<ERModularBase>())
					{
						scr.baseScript = scr.transform.parent.parent.parent.gameObject.GetComponent<ERModularBase>();
					}
					else if ((bool)scr.transform.parent.parent.parent.parent.gameObject.GetComponent<ERModularBase>())
					{
						scr.baseScript = scr.transform.parent.parent.parent.parent.gameObject.GetComponent<ERModularBase>();
					}
				}
				if (scr.baseScript != null)
				{
					qDQDOOQQDQODD = QDQDOOQQDQODD.GetRoadTypeElByID(scr.baseScript.roadTypes, scr.roadType);
				}
			}
			soData = new List<ERSOMarkerExt>();
			for (int i = 0; i < scr.soDataExt.Count; i++)
			{
				if (!scr.soDataExt[i].active)
				{
					continue;
				}
				soData.Add(ERSOMarkerExt.CreateInstance(scr.soDataExt[i].sideObject, flag: true));
				if (qDQDOOQQDQODD != null)
				{
					for (int j = 0; j < qDQDOOQQDQODD.soDataExt.Count; j++)
					{
						if (qDQDOOQQDQODD.soDataExt[j].id == soData[soData.Count - 1].id && qDQDOOQQDQODD.soDataExt[j].active)
						{
							soData[soData.Count - 1].active = qDQDOOQQDQODD.soDataExt[j].markerActive;
							soData[soData.Count - 1].xPosition = qDQDOOQQDQODD.soDataExt[j].xPosition;
						}
					}
				}
				if (scr.soDataExt[i].sideObject.dualSided)
				{
					soData[soData.Count - 1].otherSide = ERSOMarkerExt.CreateInstance(scr.soDataExt[i].sideObject, flag: true);
					soData[soData.Count - 1].otherSide.active = soData[soData.Count - 1].active;
					soData[soData.Count - 1].otherSide.splineActive = soData[soData.Count - 1].splineActive;
					soData[soData.Count - 1].otherSide.xPosition = 0f - soData[soData.Count - 1].xPosition;
					soData[soData.Count - 1].otherSide.sidewaysDistance = soData[soData.Count - 1].sidewaysDistance;
					soData[soData.Count - 1].otherSide.startOffset = soData[soData.Count - 1].startOffset;
					soData[soData.Count - 1].otherSide.endOffset = soData[soData.Count - 1].endOffset;
				}
				if (element > 0)
				{
					if (scr.markersExt[element - 1].soData.Count >= soData.Count)
					{
						soData[soData.Count - 1].ODCCOOCCCO(scr.markersExt[element - 1].soData[soData.Count - 1]);
					}
				}
				else if (scr.markersExt.Count > 0 && scr.markersExt[scr.markersExt.Count - 1].soData.Count >= soData.Count)
				{
					soData[soData.Count - 1].ODCCOOCCCO(scr.markersExt[0].soData[soData.Count - 1]);
				}
				if (scr.markersExt.Count == 0 && scr.isSideObject)
				{
					soData[soData.Count - 1].active = true;
				}
			}
		}

		public static ERMarkerExt CreateInstance(Vector3 pos, ERModularRoad scr, int element)
		{
			ERMarkerExt eRMarkerExt = ScriptableObject.CreateInstance<ERMarkerExt>();
			eRMarkerExt.Init(pos, scr, element);
			return eRMarkerExt;
		}

		public void SetControlType(ERMarkerControlType type)
		{
			switch (type)
			{
			case ERMarkerControlType.Spline:
				controlType = 0;
				break;
			case ERMarkerControlType.StraightXZ:
				controlType = 1;
				break;
			case ERMarkerControlType.StraightXZY:
				controlType = 2;
				break;
			case ERMarkerControlType.Circular:
				controlType = 3;
				break;
			}
			controllerType = type;
		}

		public ERMarkerControlType GetControlType()
		{
			if (controlType == 0)
			{
				return ERMarkerControlType.Spline;
			}
			if (controlType == 1)
			{
				return ERMarkerControlType.StraightXZ;
			}
			if (controlType == 2)
			{
				return ERMarkerControlType.StraightXZY;
			}
			if (controlType == 3)
			{
				return ERMarkerControlType.Circular;
			}
			return ERMarkerControlType.Spline;
		}

		public string[] SoNames()
		{
			List<string> list = new List<string>();
			if (soData.Count > 0)
			{
				int num = 1;
				for (int i = 0; i < soData.Count; i++)
				{
					if (soData[i] != null)
					{
						list.Add(num + ".  " + soData[i].sideObject.name);
						num++;
					}
					else
					{
						soData.RemoveAt(i);
						i--;
					}
				}
			}
			else
			{
				list.Add("No Side Objects Active");
			}
			return list.ToArray();
		}

		public static void OQDCDQDCCQ(ERMarkerExt source, ERMarkerExt target, string name)
		{
			for (int i = 0; i < source.soData.Count; i++)
			{
				if (target.soData.Count < i + 1)
				{
					target.soData.Add(ERSOMarkerExt.CreateInstance(source.soData[i].sideObject, flag: true));
					target.soData[i].ODCCOOCCCO(source.soData[i]);
				}
				else if (source.soData[i].sideObject != target.soData[i].sideObject)
				{
					target.soData[i].ODCCOOCCCO(source.soData[i]);
				}
			}
			for (int j = source.soData.Count; j < target.soData.Count; j++)
			{
				target.soData.RemoveAt(j);
			}
			Debug.Log("EasyRoads3Dv3: The side object marker data for road '" + name + "' was out of synch. This has been repaired");
		}
	}
}
