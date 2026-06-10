namespace Aura2API
{
	public struct TextureMaskData
	{
		public MatrixFloats transform;

		public int index;

		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += MatrixFloats.Size;
					_byteSize += 4;
				}
				return _byteSize;
			}
		}
	}
}
