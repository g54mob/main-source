using MessagePack;

namespace Kitchen
{
	[AutoUnion]
	public interface INetworkData
	{
		bool GetRollUp(out MessageIdentifier identifier, out IRollUp roll_up);

		void SetRollUp(IRollUp roll_up);
	}
}
