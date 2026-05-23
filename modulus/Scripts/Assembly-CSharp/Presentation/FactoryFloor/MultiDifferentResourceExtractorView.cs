using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;

namespace Presentation.FactoryFloor
{
	public class MultiDifferentResourceExtractorView : FactoryResourceHolderView<MultiDifferentResourceExtractorBehaviour>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(OnOutputResource);
		}

		protected override void ResetFactoryObject()
		{
			ResetOilRigView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetOilRigView();
			base.OnDestroy();
		}

		private void ResetOilRigView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(OnOutputResource);
			}
		}

		private void OnOutputResource(Resource resource, int outputIndex)
		{
			PassResource(resource, outputIndex);
		}
	}
}
