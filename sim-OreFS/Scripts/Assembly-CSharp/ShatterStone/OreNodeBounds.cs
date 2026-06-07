namespace ShatterStone
{
	public struct OreNodeBounds
	{
		public float minX;

		public float maxX;

		public float minZ;

		public float maxZ;

		public float centerY;

		public OreNodeBounds(float minX, float maxX, float minZ, float maxZ, float centerY)
		{
			this.minX = minX;
			this.maxX = maxX;
			this.minZ = minZ;
			this.maxZ = maxZ;
			this.centerY = centerY;
		}
	}
}
