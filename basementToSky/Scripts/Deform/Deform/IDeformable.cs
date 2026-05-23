using Unity.Jobs;

namespace Deform
{
	public interface IDeformable
	{
		UpdateFrequency UpdateFrequency { get; }

		void PreSchedule();

		JobHandle Schedule(JobHandle dependency = default(JobHandle));

		void Complete();

		void ApplyData();

		void ForceImmediateUpdate();

		bool CanUpdate();
	}
}
