using System.Runtime.CompilerServices;

namespace Assets.Scripts.Craft.Decals
{
	public static class DecalLayers
	{
		public const int DecalLayersEnd = 23;

		public const int DecalLayersStart = 8;

		public const int DefaultRenderingLayer = 1;

		public static readonly float DefaultRenderingLayerFloat = UintToFloat(1u);

		public static float DecalTargetIdToFloat(uint decalTargetId)
		{
			return UintToFloat((decalTargetId << 8) | 1);
		}

		public static uint DecalTargetIdToLayerMask(uint decalTargetId)
		{
			return (decalTargetId << 8) | 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static float UintToFloat(uint value)
		{
			return *(float*)(&value);
		}
	}
}
