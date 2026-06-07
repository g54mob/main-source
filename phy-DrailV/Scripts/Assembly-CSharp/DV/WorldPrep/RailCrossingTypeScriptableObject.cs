using DV.PointSet.MeshUtils;
using UnityEngine;

namespace DV.WorldPrep
{
	[CreateAssetMenu(menuName = "DV/Rail/Rail Crossing Type")]
	public class RailCrossingTypeScriptableObject : ScriptableObject
	{
		public Mesh straightCrossing;

		public Mesh straightCap;

		public Mesh junctionCrossing;

		public Vector3 junctionPosAdjust;

		public float junctionRotationAdjust;

		public NativeMeshProfile.UVDirection uvDirection;

		public Material material;

		public float loopsPerMeter;

		public float uvRepeatPerMeter;
	}
}
