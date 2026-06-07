using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERSOMarkerExt : ScriptableObject
	{
		public SideObject sideObject;

		public double id;

		public bool active;

		public float startOffset = 0f;

		public float endOffset = 0f;

		public bool splineActive;

		public float sidewaysDistance;

		public Vector3 startOffsetV3 = Vector3.zero;

		public Vector3 endOffsetV3 = Vector3.zero;

		public Vector3 startOffsetDir = Vector3.zero;

		public Vector3 endOffsetDir = Vector3.zero;

		public Vector3 startOffsetV3nb = Vector3.zero;

		public Vector3 endOffsetV3nb = Vector3.zero;

		public int curStartInt = -1;

		public int curEndInt = -1;

		public bool startOffsetActive = false;

		public bool endOffsetActive = false;

		public List<Vector2> nodeList = new List<Vector2>();

		public List<Vector3> nodeShapeVecsGlobal = new List<Vector3>();

		public int shapeTransitionType = 0;

		public Vector3 rotation = Vector3.zero;

		public float rotationAngle = 0f;

		public float rotationDistance = 0f;

		public float rotationCenter = 0f;

		public void Init(SideObject so, bool flag)
		{
			sideObject = so;
			id = so.id;
			if (!flag)
			{
				active = false;
			}
			else
			{
				active = so.markerActive;
			}
			splineActive = true;
			sidewaysDistance = so.splinePosition;
			startOffset = so.defaultStartOffset;
			endOffset = so.defaultEndOffset;
			nodeList = new List<Vector2>(so.nodeList);
		}

		public void OQODQCOCDD(ERSOMarkerExt source)
		{
			active = source.active;
			startOffset = source.startOffset;
			endOffset = source.endOffset;
			splineActive = source.splineActive;
			sidewaysDistance = source.sidewaysDistance;
		}

		public static ERSOMarkerExt CreateInstance(SideObject so, bool flag)
		{
			ERSOMarkerExt eRSOMarkerExt = ScriptableObject.CreateInstance<ERSOMarkerExt>();
			eRSOMarkerExt.Init(so, flag);
			return eRSOMarkerExt;
		}
	}
}
