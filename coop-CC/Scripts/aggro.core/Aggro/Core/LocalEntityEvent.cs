namespace Aggro.Core
{
	public delegate void LocalEntityEvent<T>(Entity entity, T ev) where T : struct, IEntityEvent;
}
