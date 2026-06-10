using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Tutorial;
using NSMedieval.Utils.TimeHelpers;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("PrisonerBehaviour", "")]
	public class PrisonerBehaviour : CaptiveNpcBehaviour
	{
		private const int MinHoursBetweenRecruitAttempts = 23;

		[SerializeField]
		private bool hasBeenPrisoner;

		[SerializeField]
		private Cooldown recruitAttemptCooldown = new Cooldown(TutorialManager.IsTutorialActive);

		[SerializeField]
		private bool lastAttemptSuccessful;

		private uint lastTimeVisitedByWarden;

		public override BehaviourType BehaviourType => BehaviourType.Prisoner;

		protected override string HumanTypeId => "prisoner";

		public uint LastTimeVisitedByWarden => lastTimeVisitedByWarden;

		public uint RecruitAttemptCooldownHoursLeft => recruitAttemptCooldown.HoursLeft;

		public PrisonerBehaviour()
		{
		}

		public bool GetLastAttemptSuccessful()
		{
			return lastAttemptSuccessful;
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			string id = (base.Humanoid.IsLeaving ? "enemy_friendly" : base.HumanType.WalkableModelFriendlyBlueprintId);
			base.Humanoid.SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID(id));
			base.Humanoid.SetCombatAiAgent("BlankNPCAgent");
			if (!hasBeenPrisoner)
			{
				OnBecomePrisoner();
				hasBeenPrisoner = true;
			}
		}

		protected override void OnDeactivate()
		{
			base.OnDeactivate();
			MonoSingleton<GlobalWarningMessagesManager>.Instance.RefreshPrisonerEscapingMessage();
		}

		public void OnBecomePrisoner()
		{
			List<string> becomePrisonerEffectors = base.HumanType.BecomePrisonerEffectors;
			if (becomePrisonerEffectors != null && becomePrisonerEffectors.Count > 0)
			{
				base.Humanoid.Stats.StartEffectors(becomePrisonerEffectors);
				recruitAttemptCooldown = Cooldown.FromNowHours(23, TutorialManager.IsTutorialActive);
			}
		}

		protected override Agent CreateGoapAgent()
		{
			return new PrisonerGoapAgent(base.Humanoid);
		}

		public bool CanTryRecruiting()
		{
			if (base.MarkedForRecruiting && recruitAttemptCooldown.HasEnded)
			{
				return !base.Humanoid.IsLeaving;
			}
			return false;
		}

		public void RecruitAttemptCompleted(bool success)
		{
			lastAttemptSuccessful = success;
			recruitAttemptCooldown = Cooldown.FromNowHours(23, TutorialManager.IsTutorialActive);
			string effectorId = (success ? "RecruitSuccessful" : "RecruitFailed");
			base.Humanoid.Stats.StartEffector(effectorId);
		}

		public override string GetMultiselectName()
		{
			return "prisoner";
		}

		public override string GetGoapAgentId()
		{
			return "prisoner";
		}

		protected override ProximityBehaviour GetProximityBehaviour()
		{
			return new HumanoidProximityBehaviour(base.Humanoid);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("lastAttemptSuccessful", lastAttemptSuccessful);
			serializer.Write("hasBeenPrisoner", hasBeenPrisoner);
			serializer.Write("recruitAttemptCooldown", recruitAttemptCooldown);
		}

		public PrisonerBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			lastAttemptSuccessful = deserializer.ReadBool("lastAttemptSuccessful", defaultValue: true);
			hasBeenPrisoner = deserializer.ReadBool("hasBeenPrisoner", defaultValue: true);
			recruitAttemptCooldown = deserializer.ReadObject<Cooldown>("recruitAttemptCooldown");
		}
	}
}
