using Assets.Scripts.Flight.Damage;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage.Events
{
	public class LocalDamageReceivedEventArgs : DamageReceivedEventArgs
	{
		public Vector3? Normal { get; }

		public int? PlayerId { get; }

		public Vector3? Position { get; }

		public DamageType Type { get; }

		public LocalDamageReceivedEventArgs(NetworkFlightObjectDamageReceiverScript receiver, short damageReceived, short totalDamage, DamageType? type = null, int? playerId = null, Vector3? position = null, Vector3? normal = null)
			: base(receiver, damageReceived, totalDamage)
		{
			Type = type.GetValueOrDefault();
			PlayerId = playerId;
			Position = position;
			Normal = normal;
		}
	}
}
