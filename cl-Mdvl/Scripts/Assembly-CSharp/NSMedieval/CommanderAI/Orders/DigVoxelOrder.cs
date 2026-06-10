namespace NSMedieval.CommanderAI.Orders
{
	public class DigVoxelOrder : OrderBase
	{
		public readonly Vec3Int StandingPosition;

		public readonly Vec3Int VoxelPosition;

		public DigVoxelOrder(Vec3Int standingPosition, Vec3Int voxelPosition)
		{
			StandingPosition = standingPosition;
			VoxelPosition = voxelPosition;
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}: {2}, {3}: {4}", "DigVoxelOrder", "StandingPosition", StandingPosition, "VoxelPosition", VoxelPosition);
		}

		public override bool Equals(OrderBase order)
		{
			if (!(order is DigVoxelOrder digVoxelOrder))
			{
				return false;
			}
			if (StandingPosition == digVoxelOrder.StandingPosition)
			{
				return VoxelPosition == digVoxelOrder.VoxelPosition;
			}
			return false;
		}
	}
}
