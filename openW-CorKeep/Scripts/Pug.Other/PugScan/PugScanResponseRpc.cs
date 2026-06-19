using Unity.Entities;
using Unity.NetCode;

namespace PugScan
{
	public struct PugScanResponseRpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public PugScanReturnCode code;
	}
}
