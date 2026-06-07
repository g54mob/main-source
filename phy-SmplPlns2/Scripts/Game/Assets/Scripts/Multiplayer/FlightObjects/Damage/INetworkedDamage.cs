using System.Collections.Generic;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage
{
	public interface INetworkedDamage
	{
		short Damage { get; }

		IReadOnlyList<NotableDamage> NotableDamage { get; }

		short UnsyncedDamage { get; }

		IReadOnlyList<NotableDamage> UnsyncedNotableDamage { get; }
	}
}
