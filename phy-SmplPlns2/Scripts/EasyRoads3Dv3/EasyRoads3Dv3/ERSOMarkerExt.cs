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

		public float xPosition;

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

		public ERRoadSide side;

		public ERSOMarkerExt otherSide;

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
			xPosition = so.xPosition;
			sidewaysDistance = so.splinePosition;
			startOffset = so.defaultStartOffset;
			endOffset = so.defaultEndOffset;
			nodeList = new List<Vector2>(so.nodeList);
		}

		public void ODCCOOCCCO(ERSOMarkerExt source)
		{
			active = source.active;
			xPosition = source.xPosition;
			startOffset = source.startOffset;
			endOffset = source.endOffset;
			splineActive = source.splineActive;
			sidewaysDistance = source.sidewaysDistance;
			if (source.otherSide != null)
			{
				if (otherSide == null)
				{
					otherSide = CreateInstance(source.otherSide.sideObject, flag: true);
				}
				otherSide.active = source.otherSide.active;
				otherSide.xPosition = source.otherSide.xPosition;
				otherSide.startOffset = source.otherSide.startOffset;
				endOffset = source.otherSide.endOffset;
				otherSide.splineActive = source.otherSide.splineActive;
				otherSide.sidewaysDistance = source.otherSide.sidewaysDistance;
			}
		}

		public void Copy(ERSOMarkerExt source, bool reverse)
		{
			if (!reverse)
			{
				xPosition = source.xPosition;
			}
			else
			{
				xPosition = 0f - source.xPosition;
			}
			startOffset = source.startOffset;
			endOffset = source.endOffset;
		}

		public static ERSOMarkerExt CreateInstance(SideObject so, bool flag)
		{
			ERSOMarkerExt eRSOMarkerExt = ScriptableObject.CreateInstance<ERSOMarkerExt>();
			eRSOMarkerExt.Init(so, flag);
			return eRSOMarkerExt;
		}

		public void OCQOCDQOCO(SideObject so)
		{
			sideObject = so;
			startOffset = so.startOffset;
			endOffset = so.endOffset;
		}
	}
}
