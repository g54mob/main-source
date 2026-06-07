using Coherence.Connection;
using Coherence.Entities;

namespace Coherence.ProtocolDef
{
	public interface IAuthorityManagement
	{
		bool TryGetAuthorityRequestCommand(IEntityCommand entityCommand, out ClientID requester, out AuthorityType authType);

		bool TryGetAuthorityTransferCommand(IEntityCommand entityCommand, out ClientID newAuthority, out bool transferAccepted, out AuthorityType authType);

		IEntityCommand CreateAuthorityRequest(Entity entity, ClientID requester, AuthorityType authorityType);

		IEntityCommand CreateAuthorityTransfer(Entity entity, ClientID newAuthority, bool accepted, AuthorityType authorityType);

		IEntityCommand CreateAdoptOrphanCommand();
	}
}
