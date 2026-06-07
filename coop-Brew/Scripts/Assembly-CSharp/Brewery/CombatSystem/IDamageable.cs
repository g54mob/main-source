using Unity.Netcode;
using UnityEngine;

namespace Brewery.CombatSystem
{
	public interface IDamageable
	{
		void TakeDamage(float damage, Vector3 attackerPosition, ulong attackerNetworkId);

		NetworkObject GetNetworkObject();
	}
}
