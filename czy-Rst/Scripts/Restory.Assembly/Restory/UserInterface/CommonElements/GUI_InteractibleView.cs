using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_InteractibleView : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName defaultPreset;

		[SerializeField]
		private PresetName pointerEnterPreset;

		[SerializeField]
		private PresetName pointerExitPreset;

		[SerializeField]
		private PresetName pointerDownPreset;

		[SerializeField]
		private PresetName pointerUpPreset;

		protected virtual void OnEnable()
		{
			ActivatePreset(defaultPreset);
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			ActivatePreset(pointerEnterPreset);
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			ActivatePreset(pointerExitPreset);
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
			ActivatePreset(pointerUpPreset);
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			ActivatePreset(pointerDownPreset);
		}

		protected void ActivatePreset(PresetName preset)
		{
			if ((bool)presetSwitcher && preset != PresetName.None)
			{
				presetSwitcher.ActivatePreset(preset);
			}
		}

		protected void ActivateDefaultPreset()
		{
			if ((bool)presetSwitcher)
			{
				presetSwitcher.ActivatePreset(defaultPreset);
			}
		}
	}
}
