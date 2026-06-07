using System;
using System.Collections.Generic;
using System.Net;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;

namespace Coherence.Transport
{
	public class TransportConditioner : ITransport
	{
		public class Configuration
		{
			public bool HoldOutgoingPackets { get; set; }

			public bool CanSend { get; set; }

			public bool DropNextOutPacket { get; set; }

			public Action OnNextOutPacketDropped { get; set; }

			public Action OnNextPacketSentOneShot { get; set; }

			public Condition Conditions { get; set; }

			public IRandom Random { get; set; }
		}

		protected struct DelayedPacket<T>
		{
			public T Data;

			public DateTime DeliveryTime;

			public bool ReadyForDelivery(DateTime time)
			{
				return false;
			}
		}

		protected readonly IDateTimeProvider dateTimeProvider;

		protected readonly Logger logger;

		private readonly ITransport transport;

		private readonly Queue<IOutOctetStream> heldOutgoingPackets;

		private readonly Queue<DelayedPacket<IOutOctetStream>> delayedOutgoingPackets;

		private readonly Queue<DelayedPacket<(IInOctetStream stream, IPEndPoint from)>> delayedIncomingPackets;

		private DateTime lastDuplicateSendTime;

		private IOutOctetStream dataToSendDuplicate;

		public TransportState State => default(TransportState);

		public bool IsReliable => false;

		public Configuration Config { get; protected set; }

		public bool CanSend => false;

		public int HeaderSize => 0;

		public string Description => null;

		protected Condition Conditions => default(Condition);

		protected IRandom Random => null;

		public event Action OnOpen
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<ConnectionException> OnError
		{
			add
			{
			}
			remove
			{
			}
		}

		public TransportConditioner(ITransport transport, IDateTimeProvider dateTimeProvider, Logger logger)
		{
		}

		public void Open(EndpointData endpoint, ConnectionSettings settings)
		{
		}

		public void Close()
		{
		}

		public void PrepareDisconnect()
		{
		}

		public void SetConfiguration(Configuration configuration)
		{
		}

		public void Send(IOutOctetStream data)
		{
		}

		public void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
		{
		}

		public void ReleaseAllHeldOutgoingPackets()
		{
		}

		protected bool ShouldDropOutgoingPacket()
		{
			return false;
		}

		protected bool ShouldTamper()
		{
			return false;
		}

		protected bool ShouldDelayOutgoingPacket()
		{
			return false;
		}

		protected void NotifyOnNextPacketSent()
		{
		}

		protected virtual void FlushDelayedOutgoingPackets()
		{
		}

		protected virtual void ProcessDelayedOutgoingPackets(DateTime now)
		{
		}

		private void ProcessDelayedIncomingPackets(List<(IInOctetStream, IPEndPoint)> buffer, DateTime now)
		{
		}

		private bool ShouldDelayIncomingPacket()
		{
			return false;
		}

		private bool ShouldDropIncomingPacket()
		{
			return false;
		}

		private void Tamper(IOutOctetStream packet)
		{
		}
	}
}
