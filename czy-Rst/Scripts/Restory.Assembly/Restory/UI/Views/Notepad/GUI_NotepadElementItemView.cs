using System;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.Localization;
using Restory.Gameplay.Elements;
using Restory.ObjectPools;
using Restory.UI.Presenters.Notepad;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.Notepad
{
	public sealed class GUI_NotepadElementItemView : MonoBehaviour, ICleanableComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image elementImage;

		[SerializeField]
		private Image elementStateImage;

		[SerializeField]
		private TMP_Text elementName;

		[SerializeField]
		private TMP_Text perfectElementCountInInventory;

		[SerializeField]
		private TMP_Text workingElementCountInInventory;

		[SerializeField]
		private GameObject criticalElement;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		[SerializeField]
		private PresetName unknownPreset = PresetName.Unknown;

		[SerializeField]
		private PresetName warningPreset = PresetName.Warning;

		[SerializeField]
		private string UnknownElementLocalizationKey;

		private LocalizationSystem localizationSystem;

		public bool IsElementMissed => criticalElement.activeSelf;

		public event Action OnSelected;

		public event Action OnDeselected;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

		public void Clean()
		{
			elementImage.sprite = null;
			elementStateImage.sprite = null;
			elementName.text = string.Empty;
			perfectElementCountInInventory.text = string.Empty;
			workingElementCountInInventory.text = string.Empty;
			criticalElement.SetActive(value: false);
		}

		public void SetElementMainInfo(ElementInfo elementInfo, ElementData elementData, ElementItemStatus elementItemStatus)
		{
			elementImage.sprite = elementInfo.Icon;
			if (elementData == null)
			{
				elementName.text = localizationSystem.GetTranslation(elementInfo.NameLocalizationKey);
				presetSwitcher.ActivatePreset(disabledPreset);
				return;
			}
			if (!elementData.IsInspected)
			{
				elementName.text = localizationSystem.GetTranslation(UnknownElementLocalizationKey);
				presetSwitcher.ActivatePreset(unknownPreset);
				return;
			}
			elementName.text = localizationSystem.GetTranslation(elementInfo.NameLocalizationKey);
			criticalElement.SetActive(value: false);
			presetSwitcher.ActivatePreset((elementItemStatus == ElementItemStatus.InstalledElement && elementData.Condition is DamagedElementCondition && elementInfo.IsCriticalElement) ? warningPreset : normalPreset);
			elementStateImage.sprite = elementData.Condition.Icon;
			elementStateImage.enabled = !(elementData.Condition is PerfectElementCondition);
		}

		public void MarkAsEmptySocketWithoutReplacementOnSurface()
		{
			criticalElement.SetActive(value: true);
		}

		public void SetElementsInInventoryInfo(int wholeElementsCount, int damagedElementsCount)
		{
			perfectElementCountInInventory.text = wholeElementsCount.ToString();
			workingElementCountInInventory.text = damagedElementsCount.ToString();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.OnSelected?.Invoke();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			this.OnDeselected?.Invoke();
		}
	}
}
