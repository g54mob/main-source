namespace Factory.Pools
{
	public class StringKeyPool<T> : ObjectPool<T> where T : StringKey, new()
	{
		public override void InspectEntry(object entryInstance)
		{
			base.InspectEntry(entryInstance);
		}
	}
}
