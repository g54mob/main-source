using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class WorkerXPManager : MonoSingleton<WorkerXPManager>
	{
		protected override void OnSingletonDestroy()
		{
			AgentActionPlayer.OnCompleted -= OnActionCompleted;
			AgentActionSuckBlood.SuckedBlood -= OnSuckedBlood;
		}

		protected override void SingletonAwake()
		{
			AgentActionPlayer.OnCompleted += OnActionCompleted;
			AgentActionSuckBlood.SuckedBlood += OnSuckedBlood;
		}

		private void OnSuckedBlood(Agent agent, Customer victim)
		{
			if (agent is Worker worker)
			{
				worker.Level.AddBloodSuctionExperience(victim.BloodQuality);
			}
		}

		private void OnActionCompleted(Agent agent, AgentAction action)
		{
			if (agent is Worker worker && (action is WorkerChoreDiscardJunk || action is WorkerChoreClean || action is AgentActionTakeOrder || action is WorkerChoreDrinkPreparation || action is WorkerChoreDrinkDelivery || action is WorkerActionWipeMemory || action is WorkerActionHypnotize || action is AgentActionUseMachine))
			{
				worker.Level.AddChoreAchievementExperience();
			}
		}
	}
}
