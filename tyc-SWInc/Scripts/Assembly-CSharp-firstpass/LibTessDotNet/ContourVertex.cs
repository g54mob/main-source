namespace LibTessDotNet
{
	public struct ContourVertex
	{
		public Vec3 Position;

		public object Data;

		public ContourVertex(Vec3 position, object data = null)
		{
			Position = position;
			Data = data;
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", Position, Data);
		}
	}
}
