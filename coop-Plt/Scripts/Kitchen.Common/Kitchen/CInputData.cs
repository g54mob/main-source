using System;
using Controllers;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CInputData : IComponentData, IViewData.ICheckForChanges<CInputData>
	{
		[Key(1)]
		public InputState State;

		[Key(2)]
		public bool IsCaptured;

		[Key(3)]
		public bool IsDisconnected;

		public static CInputData Captured => new CInputData
		{
			IsCaptured = true
		};

		public static CInputData Disconnected => new CInputData
		{
			IsDisconnected = true
		};

		public bool IsChangedFrom(CInputData check)
		{
			if (!(State != check.State) && IsCaptured == check.IsCaptured)
			{
				return IsDisconnected != check.IsDisconnected;
			}
			return true;
		}
	}
}
