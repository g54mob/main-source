using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public struct SEndgameStats : IComponentData
	{
		public bool IsExpGrant;

		public bool IsFranchiseScrap;

		public int DayReached;

		public int ExpGrant;

		public bool IsFranchiseCreation;

		public int FranchiseTier;

		public FixedString32 Name;
	}
}
