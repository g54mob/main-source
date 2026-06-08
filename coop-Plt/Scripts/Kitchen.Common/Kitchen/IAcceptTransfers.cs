using Unity.Entities;

namespace Kitchen
{
	public interface IAcceptTransfers
	{
		void AcceptTransfer(Entity proposal, Entity acceptance, EntityContext ctx, out Entity return_item);
	}
}
