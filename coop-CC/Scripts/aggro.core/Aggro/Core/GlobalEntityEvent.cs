namespace Aggro.Core
{
	public delegate void GlobalEntityEvent<T>(T ev) where T : struct, IEntityEvent;
}
