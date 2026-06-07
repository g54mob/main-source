using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERRoundaboutElement
	{
		public float roadWidth = 5f;

		public float prevRoadWidth = 5f;

		public int roundingSegments = 10;

		public bool lockLeftRightRoundingRadius = true;

		public float leftRoundingRadius = 3f;

		public float prevLeftRoundingRadius = 3f;

		public float rightRoundingRadius = 3f;

		public float prevRightRoundingRadius = 3f;

		public float connectionLength = 5f;

		public int centerInt = 0;

		public int prevCenterInt = 0;

		public float positionPercentage = 0f;

		public int leftOuterInt = 0;

		public int rightOuterInt = 0;

		public int intsFromCenter = 0;

		public List<Vector3> leftOuterSegments = new List<Vector3>();

		public List<Vector3> leftInnerSegments = new List<Vector3>();

		public List<Vector3> rightOuterSegments = new List<Vector3>();

		public List<Vector3> rightInnerSegments = new List<Vector3>();

		public List<Vector2> leftOuterSegmentsUVs = new List<Vector2>();

		public List<Vector2> leftInnerSegmentsUVs = new List<Vector2>();

		public List<Vector2> rightOuterSegmentsUVs = new List<Vector2>();

		public List<Vector2> rightInnerSegmentsUVs = new List<Vector2>();

		public List<List<Vector3>> leftSidewalkV3 = new List<List<Vector3>>();

		public List<List<Vector3>> rightSidewalkV3 = new List<List<Vector3>>();

		public List<List<Vector2>> leftSidewalkUV = new List<List<Vector2>>();

		public List<List<Vector2>> rightSidewalkUV = new List<List<Vector2>>();

		public List<List<int>> leftSidewalkTris = new List<List<int>>();

		public List<List<int>> rightSidewalkTris = new List<List<int>>();

		public List<int> leftSidewalkNormalsStart = new List<int>();

		public List<int> leftSidewalkNormalsEnd = new List<int>();

		public List<int> rightSidewalkNormalsStart = new List<int>();

		public List<int> rightSidewalkNormalsEnd = new List<int>();

		public List<List<int>> roadConnectionTris = new List<List<int>>();

		public List<Vector3> leftSidewalkSourceVecs = new List<Vector3>();

		public List<Vector3> rightSidewalkSourceVecs = new List<Vector3>();

		public int leftSidewalkIndex = 0;

		public int rightSidewalkIndex = 0;

		public double leftSidewalkid = 0.0;

		public double rightSidewalkid = 0.0;

		public GameObject leftSidewalkGO = null;

		public GameObject rightSidewalkGO = null;

		public ERSideWalk leftSidewalk = null;

		public ERSideWalk rightSidewalk = null;

		public bool leftSidewalkActive = false;

		public bool leftCrosswalkActive = false;

		public bool rightSidewalkActive = false;

		public bool rightCrosswalkActive = false;

		public Vector3 outerCenterPoint;

		public List<Vector3> innerRoundaboutPoints = new List<Vector3>();

		public List<Vector2> innerRoundaboutUVs = new List<Vector2>();

		public bool leftFlag = true;

		public bool rightFlag = true;

		public bool blendFlag = false;

		public Material roadMaterial;

		public Material connectionMaterial;

		public int prefabElement = 0;

		public List<int> connectionVecInts = new List<int>();

		public List<int> fullConnectionVecInts = new List<int>();

		public Vector3 centerPoint;

		public Vector3 controlPointV3;

		public List<Vector2> roadShapeVecs = new List<Vector2>();

		public string roadShapeVecsString = "";

		public List<float> roadShapeUVY = new List<float>();

		public List<int> blendCornerPointInts = new List<int>();

		public List<float> blendCornerPointWeights = new List<float>();

		public Vector3 sceneSelectionV3 = Vector3.zero;

		public Vector3 sceneSelectionV3Global = Vector3.zero;

		public List<Vector3> rightIndentvecs = new List<Vector3>();

		public List<Vector3> rightSurroundingvecs = new List<Vector3>();

		public List<Vector3> leftIndentvecs = new List<Vector3>();

		public List<Vector3> leftSurroundingvecs = new List<Vector3>();

		public int rightIndentBorderInt = 0;

		public int leftIndentBorderInt = 0;

		public double roadType = 0.0;

		public double prevRoadType = 0.0;

		public double roadTypeTimestamp = 0.0;

		public double prevTimestamp = 0.0;

		public QDQDOOQQDQODD rt = null;
	}
}
