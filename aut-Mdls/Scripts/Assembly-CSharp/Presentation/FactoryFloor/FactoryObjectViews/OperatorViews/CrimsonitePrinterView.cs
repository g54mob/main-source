using Data.FactoryFloor.FactoryObjectBehaviours;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class CrimsonitePrinterView : FactoryResourceHolderView<CrimsonitePrinterBehaviour>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
		}

		private void ResetView()
		{
			if (_behaviour != null)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
		}

		protected override void ResetFactoryObject()
		{
			ResetView();
			base.ResetFactoryObject();
		}
	}
}
