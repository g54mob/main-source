using UnityEngine;

namespace GRP
{
	public class SlopePartSim : PartSim<SlopePart>
	{
		public SlopeVisual visual;

		public MeshGroupShape shape;

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		public void CenterOfMass(out Vector3 centerOfMass, out float volume)
		{
			centerOfMass = default(Vector3);
			volume = default(float);
		}
	}
}
