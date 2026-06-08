using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CPopupSpeedrunCompleted : IManagedPopupData, IComponentData
	{
		[Key(0)]
		public int ThisRunMilliseconds;

		[Key(1)]
		public int PreviousBestMilliseconds;
	}
}
