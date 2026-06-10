using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager.RaidPointsFactors;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Utils.TimeHelpers;

namespace NSMedieval.Manager.RaidEndConditions
{
	[FVSerializableKey("NoDamageTimeoutEndCondition", "")]
	public class NoDamageTimeoutEndCondition : RaidEndCondition
	{
		private Cooldown gracePeriod;

		private Cooldown noDamageCooldown;

		public override bool ShouldEnd
		{
			get
			{
				if (!gracePeriod.HasEnded)
				{
					return false;
				}
				return noDamageCooldown.HasEnded;
			}
		}

		public NoDamageTimeoutEndCondition(ActiveRaidInfo raid)
			: base(raid)
		{
			gracePeriod = new Cooldown(raid.StartTime + raid.Blueprint.DelayBeforeAttack + SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.NoDamageTimerGracePeriodMinutes, TutorialManager.IsTutorialActive);
			noDamageCooldown = new Cooldown(gracePeriod.TimeEndMinutes + SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.NoDamageTimerMinutes, TutorialManager.IsTutorialActive);
			Subscribe();
		}

		public override void InitAfterLoad()
		{
			Subscribe();
		}

		private void Subscribe()
		{
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
			}
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitinfo)
		{
			if (gracePeriod.HasEnded)
			{
				noDamageCooldown = Cooldown.FromNowMinutes(SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.NoDamageTimerMinutes, TutorialManager.IsTutorialActive);
			}
		}

		public override void Dispose()
		{
			Unsubscribe();
			base.Dispose();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("noDamageCooldown", noDamageCooldown);
			serializer.Write("gracePeriod", gracePeriod);
		}

		public NoDamageTimeoutEndCondition(FVDeserializer deserializer)
			: base(deserializer)
		{
			noDamageCooldown = deserializer.ReadObject<Cooldown>("noDamageCooldown");
			gracePeriod = deserializer.ReadObject<Cooldown>("gracePeriod");
		}
	}
}
