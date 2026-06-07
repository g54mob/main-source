namespace Presentation.FactoryFloor
{
	public class OutputTunnelView : FactoryResourceHolderView<OutputTunnelBehavior>
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

		protected override void OnDestroy()
		{
			ResetFactoryObject();
			base.OnDestroy();
		}
	}
}
