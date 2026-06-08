using Timberborn.BaseComponentSystem;

namespace Timberborn.Rendering
{
	public class StartableMarkerPositionUpdater : BaseComponent, IStartableComponent
	{
		public void Start()
		{
			GetComponent<MarkerPosition>().UpdatePosition();
		}
	}
}
