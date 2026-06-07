using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class BreakableObjectDamageHandlerScript : MonoBehaviour, IDamageableObject
	{
		public Rigidbody RigidBody => null;

		public event EventHandler<BreakableObjectScript.DamageReceivedEventArgs> LocalDamageReceived;

		public void OnDamageReceived(DamageType type, float damage, int? playerId, Vector3? position = null, Vector3? normal = null)
		{
			if (playerId.HasValue && Game.Instance.NetworkGameManager.IsLocalPlayer(playerId.Value))
			{
				BreakableObjectScript.DamageReceivedEventArgs e = new BreakableObjectScript.DamageReceivedEventArgs
				{
					DamageType = type,
					Damage = damage,
					PlayerId = playerId
				};
				this.LocalDamageReceived?.Invoke(this, e);
			}
		}

		public void OnExplosiveForce(float force, int? playerId, Vector3 position, Vector3? normal)
		{
			OnDamageReceived(DamageType.Explosion, force, playerId, position, normal);
		}

		public void OnStandardBulletHit(float damage, int? playerId, Vector3 hitLocation, Vector3 hitNormal)
		{
			OnDamageReceived(DamageType.StandardBullets, damage, playerId, hitLocation, hitNormal);
		}
	}
}
