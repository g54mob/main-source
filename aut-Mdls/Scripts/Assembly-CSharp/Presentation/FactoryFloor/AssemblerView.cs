using Data.FactoryFloor.Behaviours;

namespace Presentation.FactoryFloor
{
	public class AssemblerView : FactoryResourceHolderView<AssemblerBehaviour>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
		}

		protected override void ResetFactoryObject()
		{
			ResetAssemblerView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetAssemblerView();
			base.OnDestroy();
		}

		private void ResetAssemblerView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
		}
	}
}
