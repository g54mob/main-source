using Rhizomatic;

namespace GRP
{
	public abstract class ToolConfig : Config, IThingCreator
	{
		public abstract Thing CreateThing();
	}
}
