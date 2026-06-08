using Unity.Entities;

namespace Kitchen
{
	public interface ISendTransfers
	{
		void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx);

		void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx);

		void Tidy(EntityContext ctx, CItemTransferProposal proposal);
	}
}
