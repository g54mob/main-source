using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;

namespace Presentation.FactoryFloor
{
	public class FurnaceView : FactoryResourceHolderView<FurnaceBehaviour>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(OnOutput);
		}

		protected override void ResetFactoryObject()
		{
			ResetView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetView();
			base.OnDestroy();
		}

		private void ResetView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(OnOutput);
			}
		}

		private void OnOutput(Resource resource, int i)
		{
			PassResource(resource, i);
		}
	}
}
