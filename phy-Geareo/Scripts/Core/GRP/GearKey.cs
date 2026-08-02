namespace GRP
{
	public struct GearKey
	{
		public int teeth;

		public float height;

		public float angle;

		public GearKey(int teeth, float height, float angle)
		{
			this.teeth = 0;
			this.height = 0f;
			this.angle = 0f;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}
}
