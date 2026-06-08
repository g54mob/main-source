using System;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct UpdateViewPositionData : IViewData, IViewResponseData, IViewData.ICheckForChanges<UpdateViewPositionData>, IRollUpCombine, IRollUp
	{
		[Key(0)]
		public Vector3 Position;

		[Key(1)]
		public Quaternion Rotation;

		[Key(2)]
		public bool Force;

		[Key(3)]
		public ViewMode Mode;

		[Key(4)]
		public float GameTime;

		public bool IsChangedFrom(UpdateViewPositionData check)
		{
			if (Force == check.Force && !((check.Position - Position).Chebyshev() > 0.001f))
			{
				return IsRotationChanged(check.Rotation);
			}
			return true;
		}

		private bool IsRotationChanged(Quaternion other)
		{
			return Rotation.IsChangedFrom(other);
		}

		public bool CombineWith(IRollUp previous_update)
		{
			if (Force)
			{
				return true;
			}
			UpdateViewPositionData updateViewPositionData = (UpdateViewPositionData)(object)previous_update;
			if (updateViewPositionData.Force)
			{
				Position = updateViewPositionData.Position;
				Rotation = updateViewPositionData.Rotation;
				GameTime = updateViewPositionData.GameTime;
			}
			return true;
		}
	}
}
