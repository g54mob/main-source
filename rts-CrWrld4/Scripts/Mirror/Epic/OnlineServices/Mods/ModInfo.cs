namespace Epic.OnlineServices.Mods
{
	public class ModInfo : ISettable
	{
		public ModIdentifier[] Mods { get; set; }

		public ModEnumerationType Type { get; set; }

		internal void Set(ModInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
