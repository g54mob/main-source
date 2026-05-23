namespace Infrastructure.Project.Registration
{
	public class PrefabPassport<T> : PrefabID
	{
		public PrefabPassport(PrefabID id)
			: base((PrefabID)null)
		{
		}

		public PrefabPassport(string @namespace, string name)
			: base((PrefabID)null)
		{
		}

		public PrefabPassport(string id)
			: base((PrefabID)null)
		{
		}
	}
}
