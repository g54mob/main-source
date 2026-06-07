using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERMarkerExt : ScriptableObject
	{
		public bool activeSplineNode = true;

		public float leftIndent = 5f;

		public int leftIndentAlignment = 0;

		public float rightIndent = 5f;

		public int rightIndentAlignment = 0;

		public float leftSurrounding = 5f;

		public float rightSurrounding = 5f;

		public bool bridgeObject = false;

		public float bridgeStartLevelDistance = 0f;

		public float bridgeEndLevelDistance = 0f;

		public float rotation = 0f;

		public Vector3 position = Vector3.zero;

		public Vector3 oldPosition = Vector3.zero;

		public Vector3 positionTmp = Vector3.zero;

		public int controlType = 0;

		public int controlTypeTmp = 0;

		public int rotations = 0;

		public float circularRadius = 1f;

		public float circularAngle = 90f;

		public int circularSegments = 10;

		public float splineStrength = 0.5f;

		public Vector3 direction;

		public Vector3 direction1;

		public Vector3 rl;

		public Vector3 rr;

		public bool followTerrainContours = false;

		public int startSplinePoint = 0;

		public float startDistance = 0f;

		public float startUVY = 0f;

		public float totalDistance = 0f;

		public string totalDistanceString = "";

		public string angleString = "";

		public string gradeString = "";

		public float rotationCenter = 0.5f;

		public List<ERSOMarkerExt> soData = new List<ERSOMarkerExt>();

		public ERMarkerControlType controllerType;

		public float randomYPosition = 0f;

		public float randomMinYPosition = -0.02f;

		public float randomMaxYPosition = 0.02f;

		public float minRandomYPositionDistance = 15f;

		public float maxRandomYPositionDistance = 35f;

		public float randomMinRotation = -1f;

		public float randomMaxRotation = 1f;

		public float minRandomRotationDistance = 15f;

		public float maxRandomRotationDistance = 35f;

		public float prevLeftIndent = 0f;

		public float prevRightIndent = 0f;

		public float prevLeftSurrounding = 0f;

		public float prevRightSurrounding = 0f;

		public int prevControlType = 0;

		public bool attachExit = false;

		public int exitType = 0;

		public int exitGeometryType;

		public int startExitInt = 0;

		public int endExitInt = 0;

		public float startExitOffset = 0f;

		public float extrusionDistance = 10f;

		public int extrusionType = 0;

		public float fixedDistance = 10f;

		public float connectionAngle = 10f;

		public float connectionRadius = 5f;

		public Material exitMaterial;

		public Material connectionMaterial;

		public int exitRoadType = 0;

		public int connectionRoadType = 0;

		public List<List<Vector3>> exitOuterVerticesExtrusion = new List<List<Vector3>>();

		public List<List<Vector3>> exitOuterVerticesFixed = new List<List<Vector3>>();

		public List<List<Vector3>> exitOuterVerticesCurve = new List<List<Vector3>>();

		public List<Vector3> exitInnerVertices = new List<Vector3>();

		public Color customColor = Color.red;

		public List<Vector2> roadShape = new List<Vector2>();

		public List<Vector3> roadShapeVecsGlobal = new List<Vector3>();

		public float roadShapeDistanceMin = 0f;

		public float roadShapeDistanceMax = 1f;

		public Vector3 perpDir = Vector3.zero;

		public Vector3 perpDirRotated = Vector3.zero;

		public void Init(Vector3 pos, ERModularRoad scr, int element)
		{
			position = pos;
			splineStrength = 0.5f;
			followTerrainContours = scr.followTerrainContours;
			leftIndent = scr.indent;
			rightIndent = scr.indent;
			leftSurrounding = scr.surrounding;
			rightSurrounding = scr.surrounding;
			if (scr.markersExt.Count == 0)
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
			soData = new List<ERSOMarkerExt>();
			for (int i = 0; i < scr.soDataExt.Count; i++)
			{
				if (scr.soDataExt[i].active)
				{
					soData.Add(ERSOMarkerExt.CreateInstance(scr.soDataExt[i].sideObject, flag: true));
					if (element != 0)
					{
						soData[soData.Count - 1].OQODQCOCDD(scr.markersExt[element - 1].soData[soData.Count - 1]);
					}
					else if (scr.markersExt.Count > 0)
					{
						soData[soData.Count - 1].OQODQCOCDD(scr.markersExt[0].soData[soData.Count - 1]);
					}
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

		public string[] SoNames()
		{
			List<string> list = new List<string>();
			if (soData.Count > 0)
			{
				int num = 1;
				for (int i = 0; i < soData.Count; i++)
				{
					list.Add(num + ".  " + soData[i].sideObject.name);
					num++;
				}
			}
			else
			{
				list.Add("No Side Objects Active");
			}
			return list.ToArray();
		}
	}
}
