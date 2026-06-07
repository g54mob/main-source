using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class QDOQDSQOOQDDD
	{
		public int crossingElementLeftIndex = 0;

		public int crossingElementRightIndex = 0;

		public Vector3 centerHandleV3;

		public Vector3 centerHandleV3_2;

		public Vector3 leftHandleV3;

		public Vector3 rightHandleV3;

		public bool renderFlag = true;

		public bool leftConnectionHandle = true;

		public bool rightConnectionHandle = true;

		public float sidewalkWidth1 = 1.5f;

		public float sidewalkWidth2 = 1.5f;

		public float curbHeight = 0.25f;

		public float curbDepth = 0.25f;

		public bool beveledCurb = false;

		public float beveledHeight = 0f;

		public float beveledDepth = 0f;

		public bool outerCurb = false;

		public bool roadSideCurbUVControl = false;

		public bool outerSideCurbUVControl = false;

		public Material sidewalkMaterial;

		public List<float> sidewalkUVs = new List<float>();

		public List<float> curbUVs = new List<float>();

		public bool lockUVs = false;

		public float cornerRadius = 1f;

		public int cornerSegments = 5;

		public float innerSegmentDistance = 0.5f;

		public float startAngle = 0f;

		public QDOQDSQOOQDDD(ERModularBase scr)
		{
			if (scr != null)
			{
				sidewalkMaterial = scr.sidewalkMaterial;
			}
		}

		public void CopyFromSidewalk(ERSideWalk sw)
		{
			sidewalkWidth1 = sw.sidewalkWidth;
			sidewalkWidth2 = sw.sidewalkWidth;
			curbHeight = sw.curbHeight;
			curbDepth = sw.curbDepth;
			beveledCurb = sw.beveledCurb;
			beveledHeight = sw.beveledHeight;
			beveledDepth = sw.beveledDepth;
			outerCurb = sw.outerCurb;
			roadSideCurbUVControl = sw.roadSideCurbUVControl;
			outerSideCurbUVControl = sw.outerSideCurbUVControl;
			sidewalkMaterial = sw.material;
			sidewalkUVs = new List<float>(sw.sidewalkUVs);
		}

		public static bool ERSidewalkMatch(QDOQDSQOOQDDD sw1, QDOQDSQOOQDDD sw2)
		{
			bool result = true;
			if (sw1.beveledHeight != sw2.beveledHeight)
			{
				result = false;
			}
			if (sw1.beveledDepth != sw2.beveledDepth)
			{
				result = false;
			}
			if (sw1.outerCurb != sw2.outerCurb)
			{
				result = false;
			}
			return result;
		}
	}
}
