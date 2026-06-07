using Data.FactoryFloor.Behaviours;

namespace Presentation.FactoryFloor
{
	public class RecipeOperatorView : FactoryResourceHolderView<RecipeOperatorBehaviour>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
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

		protected virtual void ResetView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
		}
	}
}
