using Events.UI;
using Events.UI.BarInfo;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BlueprintBarInfoContent : BaseBarInfoContent, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private ShowBlueprintBarInfoEvent _showBarInfoEvent;

		private BlueprintUIData _blueprintUIData;

		protected override void OnHover(bool hasBinding, string bindingString)
		{
			if (!hasBinding)
			{
				_showBarInfoEvent.Fire(new BlueprintBarInfoDto(_blueprintUIData));
				return;
			}
			_showBarInfoEvent.Fire(new BlueprintBarInfoDto(_blueprintUIData, bindingString));
		}

		public void SetBarInfo(BlueprintUIData blueprintUIData)
		{
			_blueprintUIData = blueprintUIData;
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnDisable()
		{
			_hideBarInfoEvent.Fire();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			_hideBarInfoEvent.Fire();
		}
	}
}
