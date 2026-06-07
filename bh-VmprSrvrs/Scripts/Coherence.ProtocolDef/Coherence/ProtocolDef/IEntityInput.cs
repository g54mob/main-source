namespace Coherence.ProtocolDef
{
	public interface IEntityInput : IEntityMessage, IBaseRequest
	{
		long Frame { get; }
	}
}
