using CTS.BBT.AI;

namespace CTS.BBT
{
	public interface IPerformable<in T> where T : Agent
	{
		bool CanBePerformedBy(T obj);
	}
}
