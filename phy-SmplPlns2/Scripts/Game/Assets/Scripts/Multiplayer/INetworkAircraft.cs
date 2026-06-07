using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Explosions;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public interface INetworkAircraft
	{
		XElement CraftXml { get; }

		bool IsInitialized { get; }

		bool IsOwner { get; }

		bool IsUnloaded { get; }

		int OwnerId { get; }

		FlightScenePlayer Player { get; }

		int PlayerId { get; }

		void CreateDamageEffect(PartDamageEffects.DamageEffectType effectType, int partId, Vector3? localPosition, Vector3? localDirection);

		void CreateTargetedExplosion(string explosionPrefabName, Vector3 position, float explosionScale, Vector3? blastDirection, AircraftScript aircraft, Rigidbody responsibleBody, Vector3? impactDirection, ExplosiveWeaponImpactType impactType);

		void DamagePart(int? attackerPlayerId, PartScript part, float damage, Vector3 hitPosition, Vector3 hitNormal);

		void NotifyTargetAlert(TargetAlertType alert);

		void OnCraftRepositioned();

		void OnPlayerLeaving();

		void RequestDespawn();

		void SendPartNetworkMessage(byte messageType, PartData part, Action<PooledWriter> createMessageAction, Channel channel = Channel.Reliable);

		void SetRemotePlayerEnteredState(bool entered);
	}
}
