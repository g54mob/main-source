namespace Coherence.RSL.EntityManager.Commands
{
	public enum CommandStatus
	{
		OK = 0,
		EntityNotFound = 1,
		AuthorityTransferred = 2,
		InvalidInputAuthority = 3,
		NotAllowed = 4,
		AuthorityTransferRejected = 5,
		ClientNotFound = 6
	}
}
