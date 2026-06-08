using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[MessagePackObject(false)]
	public struct CLocationPopupRequest : IManagedPopupData, IComponentData
	{
		[Key(0)]
		public CLocationChoice Location;
	}
}
