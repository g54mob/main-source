using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class GrabberPartSim : PartSim<GrabberPart>, ISimTick
	{
		public HubReceiver receiver;

		public BoxCollider grabberCollider;

		public GrabberVisual visual;

		private GrabberPartSimListener listener;

		private Vector3 startPos;

		private Rigidbody body;

		private bool ready;

		private bool lastKey;

		private bool isGrabbing;

		private Dictionary<Rigidbody, FixedJoint> joints;

		private Collider[] results;

		protected override void Setup()
		{
		}

		public void SimTick()
		{
		}

		private void ClearJoints()
		{
		}

		protected override void BodiesReady()
		{
		}

		private void OnTrigger(Collider other)
		{
		}

		private void Attach()
		{
		}

		private void CreateJoint(Rigidbody other, Rigidbody body)
		{
		}

		protected override void End()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
