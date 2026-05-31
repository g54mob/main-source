namespace CTS.Core
{
	public interface ISpreadUpdatable
	{
		string TickKey { get; }

		void SpreadUpdate();
	}
}
