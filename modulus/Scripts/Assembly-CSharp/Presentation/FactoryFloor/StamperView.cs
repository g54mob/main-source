using Data.FactoryFloor.Behaviours;

namespace Presentation.FactoryFloor
{
	public class StamperView : FactoryResourceHolderView<StamperBehaviour>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
		}

		protected override void ResetFactoryObject()
		{
			ResetStamperView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetStamperView();
			base.OnDestroy();
		}

		private void ResetStamperView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
		}
	}
}
