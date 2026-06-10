namespace Aura2API
{
	public struct VolumeDynamicNoiseData
	{
		public int enable;

		public MatrixFloats transform;

		public float speed;

		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += 4;
					_byteSize += MatrixFloats.Size;
					_byteSize += 4;
				}
				return _byteSize;
			}
		}
	}
}
