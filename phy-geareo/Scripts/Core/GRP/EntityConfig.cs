using Rhizomatic;

namespace GRP
{
	public abstract class EntityConfig : Config, IThingCreator
	{
		public string key;

		public abstract Thing CreateThing();
	}
}
