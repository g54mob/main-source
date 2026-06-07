using System;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage.Events
{
	public class NotableDamageReceivedEventArgs : EventArgs
	{
		public NotableDamage Damage { get; }

		public NetworkFlightObjectDamageReceiverScript Receiver { get; }

		public NotableDamageReceivedEventArgs(NetworkFlightObjectDamageReceiverScript receiver, NotableDamage damage)
		{
			Receiver = receiver;
			Damage = damage;
		}
	}
}
