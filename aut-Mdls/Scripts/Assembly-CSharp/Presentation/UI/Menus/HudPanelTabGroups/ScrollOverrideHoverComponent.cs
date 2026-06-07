using Data.Variables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public class ScrollOverrideHoverComponent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private BoolVariableSO _isHoveringOverScrollComponent;

		public void OnPointerEnter(PointerEventData eventData)
		{
			_isHoveringOverScrollComponent.SetValue(value: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_isHoveringOverScrollComponent.SetValue(value: false);
		}

		private void OnDisable()
		{
			_isHoveringOverScrollComponent.SetValue(value: false);
		}
	}
}
