using Unity.Jobs;

namespace Deform
{
	public interface IDeformer<TData> where TData : IData
	{
		void PreProcess();

		JobHandle Process(TData data, JobHandle dependency = default(JobHandle));

		bool CanProcess();
	}
}
