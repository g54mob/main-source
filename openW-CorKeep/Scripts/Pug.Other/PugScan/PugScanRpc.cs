using Unity.Entities;
using Unity.NetCode;

namespace PugScan
{
	public struct PugScanRpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public ScanRequestCD scanRequestCD;
	}
}
