using System;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage.Events
{
	public class DamageReceivedEventArgs : EventArgs
	{
		public short DamageReceived { get; }

		public NetworkFlightObjectDamageReceiverScript Receiver { get; }

		public short TotalDamage { get; }

		public DamageReceivedEventArgs(NetworkFlightObjectDamageReceiverScript receiver, short damageReceived, short totalDamage)
		{
			Receiver = receiver;
			DamageReceived = damageReceived;
			TotalDamage = totalDamage;
		}
	}
}
