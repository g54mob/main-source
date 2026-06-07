namespace Factory.Pools
{
	public class StringPool<T> : ObjectPool<T> where T : StandaloneLocString, new()
	{
		public override void InspectEntry(object entryInstance)
		{
			base.InspectEntry(entryInstance);
		}
	}
}
