using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class DisplayView : FactoryResourceHolderView<DisplayBehaviour>
	{
		[SerializeField]
		private ResourceProjectorWidgetView _resourceProjectorWidgetView;

		protected override void Init()
		{
			_behaviour.OnStoredResourceChanged.RegisterMainThread(HandleStoredResourceChanged);
			HandleStoredResourceChanged(_behaviour.StoredResource);
			base.Init();
		}

		private void HandleStoredResourceChanged(Resource storedResource)
		{
			_resourceProjectorWidgetView.ShowResource(storedResource);
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
			_resourceProjectorWidgetView.ShowResource(null);
			if (_behaviour != null)
			{
				_behaviour.OnStoredResourceChanged.UnRegisterMainThread(HandleStoredResourceChanged);
			}
		}
	}
}
