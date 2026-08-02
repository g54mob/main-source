using System;
using UnityEngine;

namespace GRP
{
	public class CylinderPartSim : PartSim<CylinderPart>, ICameraAttach
	{
		public CircularPrismVisual visual;

		public MeshGroupShape shape;

		public override Type GetPartType()
		{
			return null;
		}

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		public void CenterOfMass(out Vector3 centerOfMass, out float totalVolume)
		{
			centerOfMass = default(Vector3);
			totalVolume = default(float);
		}

		public void CameraAttach(OrbitCameraController camera, WorldPointerScan target, Vector3 relativePosition)
		{
		}
	}
}
