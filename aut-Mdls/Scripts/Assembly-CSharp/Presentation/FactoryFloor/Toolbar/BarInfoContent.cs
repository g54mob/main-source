using Data.FactoryFloor.Behaviours;
using Data.Operator;
using Events.UI;
using Events.UI.BarInfo;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BarInfoContent : BaseBarInfoContent
	{
		[SerializeField]
		private bool _isVerticalBarInfo;

		[SerializeField]
		private ShowBarInfoEvent _showBarInfoEvent;

		[Header("Content")]
		[SerializeField]
		private FactoryObjectUIData _factoryObjectUIData;

		private FactoryObjectData _factoryObjectData;

		[SerializeField]
		[HideIf("HasFactoryObjectUIData")]
		[LocaKey]
		private string _localizationTitleId;

		[SerializeField]
		[HideIf("HasFactoryObjectUIData")]
		[LocaKey]
		private string _localizationTextId;

		[SerializeField]
		[HideIf("HasFactoryObjectUIData")]
		private Sprite _toolImage;

		[SerializeField]
		[HideIf("HasFactoryObjectUIData")]
		private FactoryObjectBehaviour _factoryObjectBehaviour;

		private bool HasFactoryObjectUIData => _factoryObjectUIData != null;

		protected override void OnHover(bool hasBinding, string bindingString)
		{
			if (HasFactoryObjectUIData)
			{
				if (!hasBinding)
				{
					_showBarInfoEvent.Fire(new BarInfoDto(_isVerticalBarInfo, _factoryObjectUIData, base.transform as RectTransform));
					return;
				}
				_showBarInfoEvent.Fire(new BarInfoDto(_isVerticalBarInfo, _factoryObjectUIData, base.transform as RectTransform, bindingString));
			}
			else if (!hasBinding)
			{
				_showBarInfoEvent.Fire(new BarInfoDto(_isVerticalBarInfo, _toolImage, _localizationTitleId, _localizationTextId, _factoryObjectBehaviour, _factoryObjectData, base.transform as RectTransform));
			}
			else
			{
				_showBarInfoEvent.Fire(new BarInfoDto(_isVerticalBarInfo, _toolImage, _localizationTitleId, _localizationTextId, _factoryObjectBehaviour, _factoryObjectData, base.transform as RectTransform, bindingString));
			}
		}

		public void SetBarInfoView(BarInfoView barInfoView)
		{
			_isVerticalBarInfo = false;
		}

		public void SetBarInfo(FactoryObjectUIData factoryObjectUIData)
		{
			_factoryObjectUIData = factoryObjectUIData;
			_factoryObjectData = _factoryObjectUIData.FactoryObject;
		}

		public void SetBarInfo(string locationTitleId, string locationTextId, Sprite toolImage, FactoryObjectBehaviour factoryObjectBehaviour = null)
		{
			_factoryObjectUIData = null;
			_localizationTitleId = locationTitleId;
			_localizationTextId = locationTextId;
			_toolImage = toolImage;
			_factoryObjectBehaviour = factoryObjectBehaviour;
		}
	}
}
