using PugTilemap;
using Unity.Entities;

namespace PlayerEquipment
{
	public struct EquipmentSlotConstantCD : IComponentData, IQueryTypeParameter
	{
		public BlobAssetReference<EquipmentData> equipmentData;

		public BlobAssetReference<BlobArray<Tileset>> nonDiggableGroundTilesets;

		public BlobAssetReference<BlobArray<Tileset>> hoeableGroundTilesets;

		public BlobAssetReference<BlobArray<Tileset>> seedableGroundTilesets;
	}
}
