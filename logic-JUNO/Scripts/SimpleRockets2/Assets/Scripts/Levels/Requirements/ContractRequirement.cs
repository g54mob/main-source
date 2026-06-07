using System.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.State;
using ModApi.Levels;
using ModApi.Levels.Requirements;

namespace Assets.Scripts.Levels.Requirements
{
	public class ContractRequirement : LevelRequirement
	{
		public Contract Contract { get; private set; }

		public string ContractId { get; private set; }

		public ContractRequirement(ILevel level, string contractId)
			: base(level)
		{
			ContractId = contractId;
			CareerState career = Game.Instance.GameState.Career;
			Contract = career.Contracts.Active.First((Contract x) => x.Id == ContractId);
			career.Contracts.ContractCompleted += OnContractCompleted;
			base.Name = "Complete Contract: " + Contract.Name;
		}

		private void OnContractCompleted(Contract contract)
		{
			if (contract == Contract)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
		}
	}
}
