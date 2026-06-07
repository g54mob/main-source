namespace Assets.Scripts.PlanetStudio.Brush.Brushes
{
	public abstract class PlanetBrush
	{
		public abstract string Name { get; }

		public PlanetBrush()
		{
		}

		public virtual void BeginBrush()
		{
		}

		public virtual void EndBrush()
		{
		}

		public abstract void UpdateBrush(BrushPixelData pixelData);
	}
}
