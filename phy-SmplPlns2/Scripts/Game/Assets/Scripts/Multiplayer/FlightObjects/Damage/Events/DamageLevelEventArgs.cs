using System;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage.Events
{
	public class DamageLevelEventArgs : EventArgs
	{
		public DamageLevel NewLevel { get; }

		public DamageLevel PreviousLevel { get; }

		public NetworkFlightObjectDamageReceiverScript Receiver { get; }

		public DamageLevelEventArgs(NetworkFlightObjectDamageReceiverScript receiver, DamageLevel previousLevel, DamageLevel newLevel)
		{
			Receiver = receiver;
			PreviousLevel = previousLevel;
			NewLevel = newLevel;
		}
	}
}
