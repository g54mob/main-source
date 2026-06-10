using System;
using NSMedieval.CombatAi;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IDamageDealAgent : IDamageCommonAgent, IGoapTargetable, IGameDisposable, IDisposable
	{
		bool ForbidWeapon { get; set; }

		CombatAiAgent CombatAi { get; }

		int CurrentAttackStream { get; set; }

		bool IsOnFire { get; }

		bool FlammableProjectilesAllowed { get; }

		float GetBaseDamageOverride(DamageTakingAgentType targetType);

		DamageTakingAgentType CanAttackTypes();

		IDamageTakingAgent GetTarget();

		void SetTarget(IDamageTakingAgent target);

		void FaceTarget();

		void FaceObject(Vector3 position);

		void SetWeaponVisibility(bool isVisible);

		Transform GetWeaponTransform(int slot);

		bool IsNextRoundFlammable();

		void SetNextRoundFlammable(bool isNextFlammable, bool ignoreAllowed = false);

		bool ConsumeFlammableRound();

		void ToggleWeaponMode(EquipmentInstance weapon = null)
		{
		}
	}
}
