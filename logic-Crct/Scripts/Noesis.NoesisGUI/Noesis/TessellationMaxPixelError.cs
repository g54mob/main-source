namespace Noesis
{
	public struct TessellationMaxPixelError
	{
		public float Error { get; private set; }

		public static TessellationMaxPixelError LowQuality => default(TessellationMaxPixelError);

		public static TessellationMaxPixelError MediumQuality => default(TessellationMaxPixelError);

		public static TessellationMaxPixelError HighQuality => default(TessellationMaxPixelError);

		public static implicit operator TessellationMaxPixelError(float error)
		{
			return default(TessellationMaxPixelError);
		}
	}
}
