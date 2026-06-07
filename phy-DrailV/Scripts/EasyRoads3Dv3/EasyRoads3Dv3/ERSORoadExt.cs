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

		public float xPosition = 0f;

		public float yPosition = 0f;

		public Vector3 randomRotation = Vector3.zero;

		public float randomMinRotation = 0f;

		public float randomMaxRotation = 0f;

		public float minRandomRotationDistance = 0f;

		public float maxRandomRotationDistance = 0f;

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

		public void Init(SideObject so)
		{
			sideObject = so;
			id = so.id;
		}

		public static ERSORoadExt CreateInstance(SideObject so)
		{
			ERSORoadExt eRSORoadExt = ScriptableObject.CreateInstance<ERSORoadExt>();
			eRSORoadExt.Init(so);
			return eRSORoadExt;
		}
	}
}
