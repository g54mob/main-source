namespace EasyRoads3Dv3
{
	public struct EROQDCQOCDDC
	{
		public ERModularRoad road1;

		public int marker1;

		public ERModularRoad road2;

		public int marker2;

		public ERModularRoad road3;

		public int marker3;

		public ERModularRoad road4;

		public int marker4;

		public EROQDCQOCDDC(ERModularRoad scr, int marker)
		{
			road1 = scr;
			marker1 = marker;
			road2 = null;
			marker2 = -1;
			road3 = null;
			marker3 = -1;
			road4 = null;
			marker4 = -1;
		}
	}
}
