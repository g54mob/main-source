using Data.FactoryFloor.Behaviours;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public abstract class OpenUIOnClick : FactoryBehaviorView<FactoryObjectBehaviour>
	{
		public abstract void FireOpenUIEvent();
	}
}
