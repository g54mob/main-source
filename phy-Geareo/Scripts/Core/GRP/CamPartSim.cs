using UnityEngine;

namespace GRP
{
	public class CamPartSim : PartSim<CamPart>
	{
		public CamPartVisual visual;

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
