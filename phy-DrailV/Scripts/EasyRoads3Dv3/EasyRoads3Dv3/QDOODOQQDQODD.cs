using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class QDOODOQQDQODD
	{
		public Vector3 centerPoint = Vector3.zero;

		public Vector3 tmpCenterPoint = Vector3.zero;

		public Vector3 stageCenterPoint = Vector3.zero;

		public Vector3 tmpStageCenterPoint = Vector3.zero;

		public List<ERBlendVecs> blendData = new List<ERBlendVecs>();

		public Vector3 controlPointV3 = Vector3.zero;

		public Vector2 controlPoint = Vector2.zero;

		public float blendDistance = 0f;

		public float extendBounds = 0f;

		public List<Vector3> blendCornerPoints = new List<Vector3>();

		public List<int> blendCornerPointInts = new List<int>();

		public List<float> blendCornerPointWeights = new List<float>();

		public List<Vector3> blendCornerPointsTransformed = new List<Vector3>();

		public float blendRatio = 1f;

		public float curveStrength = 0f;

		public List<Vector2> roadShapeVecs = new List<Vector2>();

		public string roadShapeVecsString = "";

		public int roadShapeMatchCount = 0;

		public List<float> roadShapeUVY = new List<float>();

		public List<float> roadShapeUVY2 = new List<float>();

		public List<bool> hardEdge = new List<bool>();

		public List<int> roadShapeMaterialInts = new List<int>();

		public List<Vector2> sidewalkLeftVecs = new List<Vector2>();

		public List<float> sidewalkLeftUVY = new List<float>();

		public List<int> sidewalkLeftMaterialInts = new List<int>();

		public List<Vector2> sidewalkRightVecs = new List<Vector2>();

		public List<float> sidewalkRightUVY = new List<float>();

		public List<int> sidewalkRightMaterialInts = new List<int>();

		public List<ERConnectionVecs> connectionVecs = new List<ERConnectionVecs>();

		public List<int> connectionVecInts = new List<int>();

		public List<int> fullConnectionVecInts = new List<int>();

		public List<int> sidewalkLeftConnectionVecInts = new List<int>();

		public List<int> sidewalkRightConnectionVecInts = new List<int>();

		public List<bool> doConnectionTri = new List<bool>();

		public List<int> outerVecInts = new List<int>();

		public bool rotationPriority = false;

		public float centerPointAngle = 1000f;

		public ERModularRoad connectedRoad = null;

		public int connectedMarker = -1;

		public GameObject connectedRoadGO = null;

		public bool includeLeftSidewalk = true;

		public bool includeRightSidewalk = true;

		public Material roadMaterial;

		public Material[] roadMaterials;

		public float centerPointPercentage = 0.5f;

		private float ᙃ = 0f;

		public int leftIndent = -1;

		public int rightIndent = -1;

		public int leftSurrounding = -1;

		public int rightSurrounding = -1;

		public Vector3 leftIndentV3;

		public Vector3 leftSurroundingV3;

		public Vector3 rightIndentV3;

		public Vector3 rightSurroundingV3;

		public int leftCornerInt = -1;

		public int rightCornerInt = -1;

		public int leftIndentInt = 0;

		public int rightIndentInt = 0;

		public int leftInt = 0;

		public int rightInt = 0;

		public int leftIntFull = 0;

		public int rightIntFull = 0;

		public Vector3 alignmentHandleVec;

		public float additionalIndentDistance = 0f;

		public float connectionAngle = 0f;

		public Vector3 alignmentHandleVecRotationGizmo = Vector3.zero;

		public double roadType = 0.0;

		public double roadTypeTimestamp = 0.0;
	}
}
