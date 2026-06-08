using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class HubTransmitter : MonoBehaviour
	{
		public List<HubReceiver> exclude;

		public TransmitterMode mode;

		public LayerMask layer;

		public float range;

		public float offset;

		public static Collider[] cols;

		private HubSim hub;

		public void Setup(HubSim hub, TransmitterState state)
		{
		}

		public void Transmit(ChannelId channelId, Key key, float value)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
