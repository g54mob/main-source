namespace Assets.Scripts.Terrain.Pooling
{
	public enum QuadSpherePoolItemState : byte
	{
		Uninitialized = 0,
		Ready = 1,
		PendingDestruction = 2
	}
}
