namespace Assets.Scripts.Terrain.Pooling
{
	public interface IQuadSpherePool
	{
		int Size { get; }

		int TargetSize { get; }

		void Grow(int count);

		void Resize(int targetSize);

		void Resize(int targetSize, int minimumSize);

		void Shrink(int count);
	}
}
