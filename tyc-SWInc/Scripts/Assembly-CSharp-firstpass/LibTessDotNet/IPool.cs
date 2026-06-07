namespace LibTessDotNet
{
	public abstract class IPool
	{
		public IPool()
		{
			Register<MeshUtils.Vertex>(new DefaultTypePool<MeshUtils.Vertex>());
			Register<MeshUtils.Face>(new DefaultTypePool<MeshUtils.Face>());
			Register<MeshUtils.Edge>(new DefaultTypePool<MeshUtils.Edge>());
			Register<Tess.ActiveRegion>(new DefaultTypePool<Tess.ActiveRegion>());
		}

		public abstract void Register<T>(ITypePool typePool) where T : class, Pooled<T>, new();

		public abstract T Get<T>() where T : class, Pooled<T>, new();

		public abstract void Return<T>(T obj) where T : class, Pooled<T>, new();
	}
}
