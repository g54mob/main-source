using Unity.Entities;

namespace PugScan
{
	public struct PugScanCD : IComponentData, IQueryTypeParameter
	{
		public ObjectDataCD objectToScan;
	}
}
