using Rhizomatic.Utility;

namespace GRP
{
	public class Item : Entity
	{
		[JsonData]
		public string key;
	}
	public abstract class Item<TConfig> : Item where TConfig : ItemConfig
	{
		public new TConfig config => null;
	}
}
