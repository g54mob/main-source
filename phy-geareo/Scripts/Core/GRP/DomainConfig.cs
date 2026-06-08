using Rhizomatic;
using Rhizomatic.Utility;

namespace GRP
{
	public abstract class DomainConfig : Config, IThingCreator
	{
		public string key;

		public Realm realm;

		public abstract Thing CreateThing();
	}
}
