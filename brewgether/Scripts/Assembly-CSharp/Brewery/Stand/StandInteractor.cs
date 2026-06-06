using Brewery.NPC.Simple;

namespace Brewery.Stand
{
	internal class StandInteractor
	{
		private readonly NPCContext ctx;

		private readonly INPCMotor motor;

		private readonly SimpleNPCController controller;

		private StandLocation _currentStand;

		private bool _shouldLeave;

		private string _leaveReason;

		private float _patienceStartTime;

		private bool _hasCleanedUp;

		private float _patienceMultiplier;

		public StandInteractor(NPCContext context, INPCMotor agentMotor)
		{
		}

		public void JoinStand(StandLocation stand, SimpleNPCController npc)
		{
		}

		private void RegisterForServing(StandLocation stand)
		{
		}

		public void TickPatience()
		{
		}

		public void OnPaymentCollected()
		{
		}

		public void OnDrinkServed(bool correctDrink)
		{
		}

		public bool ShouldLeaveStand()
		{
			return false;
		}

		public string GetLeaveReason()
		{
			return null;
		}

		public void LeaveStand(string reason)
		{
		}

		public void CleanupStandPresence(string reason)
		{
		}

		public void SetPatienceMultiplier(float multiplier)
		{
		}
	}
}
