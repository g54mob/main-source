namespace Coherence.Core
{
	public struct InteropSceneIndexChange
	{
		public InteropEntity EntityId;

		public int SceneIndex;

		public SceneIndexChanged Into()
		{
			return default(SceneIndexChanged);
		}
	}
}
