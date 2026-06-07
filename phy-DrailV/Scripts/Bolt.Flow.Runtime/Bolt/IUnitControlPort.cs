using Ludiq;

namespace Bolt
{
	public interface IUnitControlPort : IUnitPort, IGraphItem
	{
		bool isPredictable { get; }

		bool couldBeEntered { get; }
	}
}
