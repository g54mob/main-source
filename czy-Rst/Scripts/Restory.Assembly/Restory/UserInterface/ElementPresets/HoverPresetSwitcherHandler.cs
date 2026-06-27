using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface.ElementPresets
{
	public class HoverPresetSwitcherHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private GUI_ElementPresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName hoveredPreset = PresetName.Hovered;

		private void Start()
		{
			presetSwitcher.ActivatePreset(normalPreset);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			presetSwitcher.ActivatePreset(hoveredPreset);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			presetSwitcher.ActivatePreset(normalPreset);
		}
	}
}
