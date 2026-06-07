using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	public readonly struct ActiveRegion
	{
		public static readonly ActiveRegion INACTIVE = new ActiveRegion(Rect.zero, Matrix4x4.zero, VPMatrixCache.Index.INVALID);

		public readonly Rect rect;

		public readonly Matrix4x4 localToWorld;

		public readonly VPMatrixCache.Index vpMatrixCacheIndex;

		public bool IsWorldSpace => vpMatrixCacheIndex.IsValid();

		public ActiveRegion(Rect rect, Matrix4x4 localToWorld, VPMatrixCache.Index vpMatrixCacheIndex)
		{
			this.rect = rect;
			this.localToWorld = localToWorld;
			this.vpMatrixCacheIndex = vpMatrixCacheIndex;
		}
	}
}
