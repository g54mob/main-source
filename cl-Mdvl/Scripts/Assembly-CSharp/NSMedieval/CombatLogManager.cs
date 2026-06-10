using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval
{
	public class CombatLogManager : MonoBehaviour
	{
		private void DoLog(LifeEventLogStruct log, CreatureBase takeAgent, CreatureBase dealAgent)
		{
			takeAgent.LogLifeEvent(log);
			dealAgent.LogLifeEvent(log);
		}

		private void LogFatalHit(CreatureBase takeAgent, CreatureBase dealAgent)
		{
		}

		private void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType misstype)
		{
			CreatureBase takeAgent = take as CreatureBase;
			if (takeAgent == null)
			{
				return;
			}
			CreatureBase dealAgent = deal as CreatureBase;
			if (dealAgent != null)
			{
				switch (misstype)
				{
				case CombatMissType.Miss:
					HandleMissed();
					break;
				case CombatMissType.Evade:
					DoLog(LifeEventUtils.GetCombatEvadeEventLog(takeAgent, dealAgent), takeAgent, dealAgent);
					break;
				default:
					throw new ArgumentOutOfRangeException("misstype", misstype, null);
				case CombatMissType.None:
				case CombatMissType.LineOfSight:
				case CombatMissType.Other:
					break;
				}
			}
			void HandleMissed()
			{
				DoLog(LifeEventUtils.GetCombatMissEventLog(takeAgent, dealAgent), takeAgent, dealAgent);
				if (dealAgent is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					humanoidInstance.WorkerBehaviour.WorkerInteraction.FireWeaponMissEvent();
				}
			}
		}

		private void OnEnable()
		{
			MonoSingleton<CombatController>.Instance.HitMissedEvent += OnHitMissed;
			MonoSingleton<CombatController>.Instance.HitBlockedEvent += OnHitBlocked;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
		}

		private void OnDisable()
		{
			MonoSingleton<CombatController>.Instance.HitMissedEvent -= OnHitMissed;
			MonoSingleton<CombatController>.Instance.HitBlockedEvent -= OnHitBlocked;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitinfo)
		{
			if (take is CreatureBase creatureBase && deal is CreatureBase creatureBase2)
			{
				DoLog(LifeEventUtils.GetCombatHitEventLog(creatureBase, creatureBase2), creatureBase, creatureBase2);
				if (creatureBase2 is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					humanoidInstance.WorkerBehaviour.WorkerInteraction.FireWeaponHitEvent();
				}
				if (creatureBase is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance2)
				{
					humanoidInstance2.WorkerBehaviour.WorkerInteraction.FireArmourEvent();
				}
			}
		}

		private void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (take is CreatureBase creatureBase && deal is CreatureBase dealAgent)
			{
				DoLog(LifeEventUtils.GetCombatBlockEventLog(creatureBase, dealAgent), creatureBase, dealAgent);
				if (creatureBase is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					humanoidInstance.WorkerBehaviour.WorkerInteraction.FireShieldBlockEvent();
				}
			}
		}
	}
}
