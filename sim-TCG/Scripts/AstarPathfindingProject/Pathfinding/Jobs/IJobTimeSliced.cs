using Unity.Jobs;

namespace Pathfinding.Jobs
{
	public interface IJobTimeSliced : IJob
	{
		bool Execute(TimeSlice timeSlice);
	}
}
