using System;
using Data.FactoryFloor.FactoryObjectBehaviours;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.Skyline
{
	public class SkylineOutView : FactoryResourceHolderView<SkylineOutBehaviour>
	{
		[SerializeField]
		private FactoryObjectViewCullingController _factoryObjectViewCullingController;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			SkylineOutBehaviour behaviour = _behaviour;
			behaviour.OnSkylineInFound = (Action<int>)Delegate.Combine(behaviour.OnSkylineInFound, new Action<int>(SkylineInFound));
		}

		protected override void ResetFactoryObject()
		{
			ResetSkylineOutView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetSkylineOutView();
			base.OnDestroy();
		}

		private void ResetSkylineOutView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
		}

		private void SkylineInFound(int skylineLength)
		{
			if (_behaviour != null)
			{
				SkylineOutBehaviour behaviour = _behaviour;
				behaviour.OnSkylineInFound = (Action<int>)Delegate.Remove(behaviour.OnSkylineInFound, new Action<int>(SkylineInFound));
			}
			Vector3 cullingBoundsOverride = new Vector3((float)skylineLength * 2f, 2f, (float)skylineLength * 2f);
			_factoryObjectViewCullingController.SetCullingBoundsOverride(cullingBoundsOverride);
			_factoryObjectViewCullingController.RefreshCullingPosition();
		}

		public override void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true)
		{
		}
	}
}
