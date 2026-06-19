namespace Aggro.Core
{
	public delegate void LocalEntityKeyEvent<T>(EntityKey key, T ev) where T : struct, IEntityEvent;
}
