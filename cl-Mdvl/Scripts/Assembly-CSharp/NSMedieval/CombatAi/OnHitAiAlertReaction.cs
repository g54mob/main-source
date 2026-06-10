using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval.CombatAi
{
	public class OnHitAiAlertReaction : CombatAiReaction
	{
		public OnHitAiAlertReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		public override void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			OnHit(deal, take);
		}

		public override void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			OnHit(deal, take);
		}

		private void OnHit(IDamageDealAgent deal, IDamageTakingAgent take)
		{
			if (take == base.CombatAgent && CombatUtils.IsAlive(deal) && CombatUtils.IsAlive(take) && base.CombatAi != null && !base.CombatAi.HasDisposed)
			{
				IDamageTakingAgent state = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
				if (state != null)
				{
					Alert(state);
				}
			}
		}

		private void Alert(IDamageTakingAgent alertTarget)
		{
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				if ((float)Vec3Int.DistanceSquaredY3(nPC.GetGridPosition(), base.CombatAgent.GetGridPosition()) >= 100f || nPC.HasDisposed || nPC == base.CombatAgent || !nPC.IsEnemy() || nPC.CombatAi.IsStateSet(CombatAiState.PreferedTarget) || !CombatUtils.HasCombatLos(base.CombatAgent.GetPosition(), nPC.GetPosition()))
				{
					break;
				}
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(nPC, alertTarget);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(36, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Reactions\\OnHitAiAlertReaction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.CombatAgent);
					messageBuilder.AppendLiteral(" alerted ");
					messageBuilder.AppendFormatted(nPC);
					messageBuilder.AppendLiteral(" about ");
					messageBuilder.AppendFormatted(alertTarget);
					messageBuilder.AppendLiteral(" that attacked them.");
				}
				Log.Info(messageBuilder);
			}
		}
	}
}
