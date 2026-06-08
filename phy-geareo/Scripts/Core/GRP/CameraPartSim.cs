using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public class CameraPartSim : PartSim<CameraPart>, ISimTick, ISimPostPhysicsUpdate
	{
		public UhCamera cam;

		public AnimationCurve smoothCurve;

		public HubReceiver receiver;

		public GuidePointable guidePointable;

		private bool lastKeyDown;

		private float smooth;

		public void SimTick()
		{
		}

		protected override void Setup()
		{
		}

		protected override void BodiesReady()
		{
		}

		public void SimPostPhysicsUpdate()
		{
		}
	}
}
