using Timberborn.BaseComponentSystem;

namespace Timberborn.Rendering
{
	internal class LightingEnabler : BaseComponent, IStartableComponent
	{
		private readonly MaterialColorer _materialColorer;

		public LightingEnabler(MaterialColorer materialColorer)
		{
			_materialColorer = materialColorer;
		}

		public void Start()
		{
			_materialColorer.EnableLighting(this);
		}
	}
}
