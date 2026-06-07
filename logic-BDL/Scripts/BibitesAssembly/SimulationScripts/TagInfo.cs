namespace SimulationScripts
{
	public struct TagInfo
	{
		public int count;

		public float totalEnergy;

		private TagInfo(int c, float e)
		{
			count = c;
			totalEnergy = e;
		}
	}
}
