using FullSerializerSave;

namespace TH20
{
	[fsObject(Converter = typeof(Bool2DArrayConverter))]
	public struct BoolArray2D
	{
		public bool[,] Values;
	}
}
