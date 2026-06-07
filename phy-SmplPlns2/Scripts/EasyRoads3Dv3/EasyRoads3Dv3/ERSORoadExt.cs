using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERSORoadExt : ScriptableObject
	{
		public SideObject sideObject;

		public double id;

		public bool active = false;

		public List<Vector3> vecPositions = new List<Vector3>();

		public bool toggleActive = false;

		public bool autoGenerate = false;

		public bool markerActive = true;

		public float m_distance = 0f;

		public float xPosition = 0f;

		[HideInInspector]
		public float oldXPosition = 0f;

		public float yPosition = 0f;

		public Vector3 randomRotation = Vector3.zero;

		public float randomMinRotation = 0f;

		public float randomMaxRotation = 0f;

		public float minRandomRotationDistance = 0f;

		public float maxRandomRotationDistance = 0f;

		public bool distanceChange = false;

		public bool xPosChange = false;

		public bool yPosChange = false;

		public bool rotationAngleChange = false;

		public bool rotationDistanceChange = false;

		public bool lockRandomRotations = false;

		public bool randomXPositionChange = false;

		public bool randomYPositionChange = false;

		public bool xPositionDistanceChange = false;

		public float randomXPosition = 0f;

		public float randomMinXPosition = 0f;

		public float randomMaxXPosition = 0f;

		public float minRandomXPositionDistance = 0f;

		public float maxRandomXPositionDistance = 0f;

		public Vector3 boxColliderScale = new Vector3(1f, 1f, 1f);

		public bool yPositionDistanceChange = false;

		public float randomYPosition = 0f;

		public float randomMinYPosition = 0f;

		public float randomMaxYPosition = 0f;

		public float minRandomYPositionDistance = 0f;

		public float maxRandomYPositionDistance = 0f;

		public GameObject sourceObject;

		public List<ERSOSection> sections = new List<ERSOSection>();

		public List<GameObject> objects = new List<GameObject>();

		public List<GameObject> runtimeObjects = new List<GameObject>();

		public bool interpolateOnConnection = false;

		public Vector3 lastEndPosition;

		public bool clampToMarkers = false;

		public ERCrossingPrefabs instance;

		public List<int> snapIntsStartSide1;

		public List<int> snapIntsEndSide1;

		public List<int> snapIntsStartSide2;

		public List<int> snapIntsEndSide2;

		public Mesh snapMeshSide1;

		public Mesh snapMeshSide2;

		public ERModularRoad otherRoadStartLeft;

		public ERModularRoad otherRoadStartRight;

		public ERModularRoad otherRoadEndLeft;

		public ERModularRoad otherRoadEndRight;

		public ERSORoadExt otherSoDataStartLeft;

		public ERSORoadExt otherSoDataStartRight;

		public ERSORoadExt otherSoDataEndLeft;

		public ERSORoadExt otherSoDataEndRight;

		public List<List<Vector3>> mainTriangulateVecs = new List<List<Vector3>>();

		public List<List<Vector3>> mirroredTriangulateVecs = new List<List<Vector3>>();

		public List<int> startSplinePointIndexes = new List<int>();

		public List<int> endSplinePointIndexes = new List<int>();

		public List<int> startSplinePointIndexesMirrored = new List<int>();

		public List<int> endSplinePointIndexesMirrored = new List<int>();

		public void Init(SideObject so)
		{
			if (so != null)
			{
				id = so.id;
			}
			else
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: A side object that is auto activated for this road type does not exist in the scene. Make sure to import all side objects that are auto activated for a road type used in this scene.");
			}
			sideObject = so;
		}

		public static ERSORoadExt CreateInstance(SideObject so)
		{
			ERSORoadExt eRSORoadExt = ScriptableObject.CreateInstance<ERSORoadExt>();
			eRSORoadExt.Init(so);
			return eRSORoadExt;
		}

		public static void Copy(ERSORoadExt source, ERSORoadExt target)
		{
			target.m_distance = source.m_distance;
			target.xPosition = source.xPosition;
			target.yPosition = source.yPosition;
			target.randomRotation = source.randomRotation;
			target.randomMinRotation = source.randomMinRotation;
			target.randomMaxRotation = source.randomMaxRotation;
			target.minRandomRotationDistance = source.minRandomRotationDistance;
			target.maxRandomRotationDistance = source.maxRandomRotationDistance;
			target.randomXPosition = source.randomXPosition;
			target.randomMinXPosition = source.randomMinXPosition;
			target.randomMaxXPosition = source.randomMaxXPosition;
			target.minRandomXPositionDistance = source.minRandomXPositionDistance;
			target.maxRandomXPositionDistance = source.maxRandomXPositionDistance;
			target.randomYPosition = source.randomYPosition;
			target.randomMinYPosition = source.randomMinYPosition;
			target.randomMaxYPosition = source.randomMaxYPosition;
			target.minRandomYPositionDistance = source.minRandomYPositionDistance;
			target.maxRandomYPositionDistance = source.maxRandomYPositionDistance;
			target.sourceObject = source.sourceObject;
			target.markerActive = source.markerActive;
			target.autoGenerate = source.autoGenerate;
		}

		public static ERSORoadExt GetERSORoadExt(List<ERSORoadExt> lst, double id)
		{
			foreach (ERSORoadExt item in lst)
			{
				if (item.id == id)
				{
					return item;
				}
			}
			return null;
		}
	}
}
