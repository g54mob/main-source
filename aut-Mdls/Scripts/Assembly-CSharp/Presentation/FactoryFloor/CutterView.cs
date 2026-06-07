using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;

namespace Presentation.FactoryFloor
{
	public class CutterView : FactoryResourceHolderView<CutterBehaviour>
	{
		protected override void Init()
		{
			base.Init();
			_behaviour.OnNewCutShapePassed.RegisterMainThread(PassNewCutShape);
		}

		protected override void ResetFactoryObject()
		{
			ResetCutterView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetCutterView();
			base.OnDestroy();
		}

		private void ResetCutterView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnNewCutShapePassed.UnRegisterMainThread(PassNewCutShape);
			}
		}

		private void PassNewCutShape(Resource resource, int shapeOutputIndex)
		{
			PassResource(resource, 0);
		}
	}
}
