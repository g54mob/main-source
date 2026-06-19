namespace Aggro.Core
{
	public struct ComponentQueryResult<T> where T : struct, IEntityStruct
	{
		public EntityKey key;

		public T component;
	}
}
