using Unity.Entities;

namespace Kitchen
{
	public struct CApplyingProcess : IComponentData
	{
		public int Process;

		public bool IsBad;

		public float Progress;

		public static implicit operator CApplyingProcess(CItemUndergoingProcess item)
		{
			return new CApplyingProcess
			{
				Process = item.Process,
				IsBad = item.IsBad,
				Progress = item.Progress
			};
		}
	}
}
