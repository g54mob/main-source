using NSEipix.Repository;
using NSMedieval.Model.MapNew;

namespace NSMedieval
{
	public class VoxelTypeRepository : DynamicJsonRepository<VoxelTypeRepository, VoxelType>
	{
		private VoxelType[] voxelTypeByByteId;

		public static VoxelTypeRepository FastInstance { get; private set; }

		public VoxelType GetByByteId(byte byteId)
		{
			return voxelTypeByByteId[byteId];
		}

		protected override void Refresh()
		{
			base.Refresh();
			Init();
		}

		protected override void Initialize()
		{
			base.Initialize();
			Init();
			FastInstance = this;
		}

		private void Init()
		{
			byte b = 0;
			foreach (VoxelType allItem in GetAllItems())
			{
				if (b < allItem.ByteId)
				{
					b = allItem.ByteId;
				}
			}
			voxelTypeByByteId = new VoxelType[b + 1];
			foreach (VoxelType allItem2 in GetAllItems())
			{
				voxelTypeByByteId[allItem2.ByteId] = allItem2;
				allItem2.Initialize();
			}
		}

		protected override string JsonFile()
		{
			return "Map/VoxelTypes.json";
		}
	}
}
