using Rhizomatic.Reactive;

namespace GRP
{
	public interface IWithTransmitter
	{
		State<TransmitterState> GetTransmitterState();
	}
}
