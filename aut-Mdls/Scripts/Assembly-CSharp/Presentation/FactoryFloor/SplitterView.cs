using Data.FactoryFloor.Behaviours;

namespace Presentation.FactoryFloor
{
	public class SplitterView : FactoryResourceHolderView<SplitterBehavior>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
		}

		protected override void ResetFactoryObject()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
			base.ResetFactoryObject();
		}
	}
}
