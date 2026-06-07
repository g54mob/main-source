using Data.FactoryFloor.FactoryObjectBehaviours;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class IconBlockView : FactoryBehaviorView<IconBlockBehaviour>
	{
		[SerializeField]
		private Image _icon;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnConfigurationChanged.RegisterMainThread(RebuildUI);
			RebuildUI(_behaviour.Configuration);
		}

		protected override void ResetFactoryObject()
		{
			if (_behaviour != null)
			{
				_behaviour.OnConfigurationChanged.UnRegisterMainThread(RebuildUI);
			}
			base.ResetFactoryObject();
			_icon.sprite = null;
		}

		private void RebuildUI(IconBlockBehaviourConfigurationDto config)
		{
			_icon.sprite = _behaviour.DisplayIcons[config.IconIndex];
		}
	}
}
