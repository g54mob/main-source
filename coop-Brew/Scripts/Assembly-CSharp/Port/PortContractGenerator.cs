using System;
using System.Collections.Generic;

namespace Port
{
	public static class PortContractGenerator
	{
		public enum ContractType
		{
			CatalystOnly = 0,
			DrinkCatalyzed = 1,
			Mixed = 2,
			MultiCatalyst = 3
		}

		public static List<PortContract> GenerateContracts(PortConfig config, int shipId, int deadlineDay, float deadlineHour, int tier, ref int nextContractId, int seed)
		{
			return null;
		}

		private static ContractType RollContractType(Random rng, int tier)
		{
			return default(ContractType);
		}

		private static PortContract GenerateContract(PortConfig config, ContractType type, int shipId, int deadlineDay, float deadlineHour, int tier, int contractId, Random rng)
		{
			return default(PortContract);
		}

		private static void FillDrinkRequirement(ref PortContract contract, PortConfig config, int tier, Random rng)
		{
		}

		private static void FillCatalystRequirement(ref PortContract contract, PortConfig config, int tier, Random rng, int slot)
		{
		}

		private static int CalculateReward(PortConfig config, ContractType type, int tier, PortContract contract, Random rng)
		{
			return 0;
		}

		private static int CountSetBits(int value)
		{
			return 0;
		}
	}
}
