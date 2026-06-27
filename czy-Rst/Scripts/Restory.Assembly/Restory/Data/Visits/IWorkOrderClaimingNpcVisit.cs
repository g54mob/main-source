using Restory.Data.NPCs;

namespace Restory.Data.Visits
{
	public interface IWorkOrderClaimingNpcVisit
	{
		INpcInfo Npc { get; }

		string NpcTextureID { get; }

		int WorkOrderID { get; }
	}
}
