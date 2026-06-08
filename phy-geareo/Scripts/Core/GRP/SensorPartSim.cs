using UnityEngine;

namespace GRP
{
	public class SensorPartSim : PartSim<SensorPart>, ISimTick
	{
		public LayerMask layer;

		public HubTransmitter transmitter;

		public Transform lineTransform;

		public Renderer lineRenderer;

		public SensorVisual visual;

		public Color onColor;

		public Color offColor;

		private MaterialPropertyBlock lineMaterialBlock;

		protected override void Setup()
		{
		}

		public void SimTick()
		{
		}
	}
}
