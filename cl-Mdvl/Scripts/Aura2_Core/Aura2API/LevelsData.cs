namespace Aura2API
{
	public struct LevelsData
	{
		public float levelLowThreshold;

		public float levelHiThreshold;

		public float outputLowValue;

		public float outputHiValue;

		public float contrast;

		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
				}
				return _byteSize;
			}
		}
	}
}
