using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	public readonly struct ActiveRegion
	{
		public static readonly ActiveRegion INACTIVE;

		public readonly Rect rect;

		public readonly Matrix4x4 localToWorld;

		public readonly VPMatrixCache.Index vpMatrixCacheIndex;

		public bool IsWorldSpace => false;

		public ActiveRegion(Rect rect, Matrix4x4 localToWorld, VPMatrixCache.Index vpMatrixCacheIndex)
		{
			this.rect = default(Rect);
			this.localToWorld = default(Matrix4x4);
			this.vpMatrixCacheIndex = default(VPMatrixCache.Index);
		}
	}
}
