using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERMarker
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

		public int controlType = 0;

		public int rotations = 0;

		public float circularRadius = 1f;

		public float circularAngle = 90f;

		public int circularSegments = 10;

		public float splineStrength = 0.5f;

		public Vector3 direction;

		public Vector3 direction1;

		public bool followTerrainContours = false;

		public int startSplinePoint = 0;

		public float startDistance = 0f;

		public float startUVY = 0f;

		public float totalDistance = 0f;

		public string totalDistanceString = "";

		public string angleString = "";

		public float rotationCenter = 0.5f;

		public List<ERSOMarker> soData = new List<ERSOMarker>();

		public ERMarkerControlType controllerType;

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

		public List<Vector2> roadShape = new List<Vector2>();

		public List<Vector3> roadShapeVecsGlobal = new List<Vector3>();

		public Vector3 perpDir = Vector3.zero;

		public Vector3 perpDirRotated = Vector3.zero;

		public ERMarker(Vector3 pos, ERModularRoad scr, int element)
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
			soData = new List<ERSOMarker>();
			for (int i = 0; i < scr.soData.Count; i++)
			{
				if (scr.soData[i].active)
				{
					soData.Add(new ERSOMarker(scr.soData[i].sideObject, flag: true));
					if (element != 0)
					{
						soData[soData.Count - 1].OQODQCOCDD(scr.markersExt[element - 1].soData[soData.Count - 1]);
					}
				}
			}
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
	}
}
