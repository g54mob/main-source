using System;
using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Elements;
using Restory.ObjectPools;
using Restory.UI.Views.Notepad;
using UnityEngine;

namespace Restory.UI.Presenters.Notepad
{
	public sealed class GUI_NotepadElementItem : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		public ElementConditionBase perfectElementCondition;

		[SerializeField]
		public ElementConditionBase dirtyElementCondition;

		[SerializeField]
		private GUI_NotepadElementItemView view;

		private ElementInfo elementInfo;

		private ElementData elementData;

		public GUI_NotepadElementItemView View => view;

		public ElementInfo Info => elementInfo;

		public ElementData ElementData => elementData;

		public event Action<GUI_NotepadElementItem> OnSelected;

		public event Action<GUI_NotepadElementItem> OnDeselected;

		private void OnEnable()
		{
			view.OnSelected += ResolveOnSelected;
			view.OnDeselected += ResolveOnDeselected;
		}

		private void OnDisable()
		{
			view.OnSelected -= ResolveOnSelected;
			view.OnDeselected -= ResolveOnDeselected;
		}

		public void Init(ElementInfo elementInfo, ElementData elementData, ElementItemStatus elementItemStatus)
		{
			this.elementInfo = elementInfo;
			this.elementData = elementData;
			view.SetElementMainInfo(elementInfo, elementData, elementItemStatus);
		}

		public void Clean()
		{
			elementInfo = null;
		}

		public void UpdateElementsInInventoryInfo(IReadOnlyDictionary<ElementConditionBase, int> correspondingElementsInInventory)
		{
			view.SetElementsInInventoryInfo(correspondingElementsInInventory.GetValueOrDefault(perfectElementCondition, 0), correspondingElementsInInventory.GetValueOrDefault(dirtyElementCondition, 0));
		}

		private void ResolveOnSelected()
		{
			this.OnSelected?.Invoke(this);
		}

		private void ResolveOnDeselected()
		{
			this.OnDeselected?.Invoke(this);
		}
	}
}
