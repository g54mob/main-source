using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class SidewalkPresetClass
	{
		public string presetName = "";

		public double id;

		public double timestamp;

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

		public List<Vector2> shape = new List<Vector2>();

		public List<float> sidewalkUVs = new List<float>();

		public List<float> curbUVs = new List<float>();

		public bool lockUVs = false;

		public SidewalkPresetClass(QDOQDSQOOQDDD corner, string name)
		{
			presetName = name;
			sidewalkWidth1 = corner.sidewalkWidth1;
			sidewalkWidth2 = corner.sidewalkWidth2;
			curbHeight = corner.curbHeight;
			curbDepth = corner.curbDepth;
			beveledCurb = corner.beveledCurb;
			beveledHeight = corner.beveledHeight;
			beveledDepth = corner.beveledDepth;
			outerCurb = corner.outerCurb;
			roadSideCurbUVControl = corner.roadSideCurbUVControl;
			outerSideCurbUVControl = outerSideCurbUVControl;
			sidewalkMaterial = corner.sidewalkMaterial;
			sidewalkUVs.AddRange(corner.sidewalkUVs);
			curbUVs.AddRange(corner.curbUVs);
			lockUVs = corner.lockUVs;
		}
	}
}
