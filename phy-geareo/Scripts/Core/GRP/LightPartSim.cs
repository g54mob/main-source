using UnityEngine;

namespace GRP
{
	public class LightPartSim : PartSim<LightPart>, ISimTick
	{
		public LightVisual visual;

		public BoxCollider receiverCollider;

		public HubReceiver receiver;

		protected override void Setup()
		{
		}

		public void SimTick()
		{
		}
	}
}
