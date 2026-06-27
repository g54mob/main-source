using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Restory.Data.Base;
using Restory.Data.GUIControllerElements;
using Restory.Data.GuiElementTypes;
using Restory.Gameplay.Common;
using UnityEngine;

namespace Restory.UserInterface
{
	public class CanvasOrderService : MonoBehaviour, IDisposable
	{
		private static class Style
		{
			public const string Highest = "Current Highest Element In Order";

			public const string InteractiveElement = "Current Highest Interactive Element In Order";
		}

		private const int MODALS_ORDER_MIN = 100;

		[SerializeField]
		private GuiElementTypesCombinationRules guiCombinationRules;

		[SerializeField]
		private GuiElementsSwitchingSettings settings;

		[SerializeField]
		private GUI_CanvasElement currentHighestOrderElement;

		[SerializeField]
		private GUI_CanvasElement currentHighestOrderInteractiveElement;

		private readonly Dictionary<PriorityType, List<GUI_CanvasElement>> prioritizedElements = new Dictionary<PriorityType, List<GUI_CanvasElement>>();

		private bool prioritizedElementsInitialized;

		public GUI_CanvasElement CurrentHighestOrderInteractiveElement => currentHighestOrderInteractiveElement;

		public GuiElementsSwitchingSettings Settings => settings;

		private string CurrentHighestOrderElementType
		{
			get
			{
				if (!(currentHighestOrderElement == null))
				{
					if (!(currentHighestOrderElement.GuiElementType == null))
					{
						return currentHighestOrderElement.GuiElementType.ID;
					}
					return "NONE";
				}
				return "NONE";
			}
		}

		private string CurrentHighestOrderInteractiveElementType
		{
			get
			{
				if (!(currentHighestOrderInteractiveElement == null))
				{
					if (!(currentHighestOrderInteractiveElement.GuiElementType == null))
					{
						return currentHighestOrderInteractiveElement.GuiElementType.ID;
					}
					return "NONE";
				}
				return "NONE";
			}
		}

		private void Awake()
		{
			InitializePrioritizedElements();
		}

		public void Dispose()
		{
			currentHighestOrderInteractiveElement = null;
			currentHighestOrderElement = null;
			prioritizedElements.Clear();
		}

		private void InitializePrioritizedElements()
		{
			if (prioritizedElementsInitialized)
			{
				return;
			}
			prioritizedElementsInitialized = true;
			prioritizedElements.Clear();
			foreach (PriorityType item in from PriorityType x in Enum.GetValues(typeof(PriorityType))
				orderby x
				select x)
			{
				prioritizedElements.Add(item, new List<GUI_CanvasElement>());
			}
		}

		public void Add(GUI_CanvasElement modal)
		{
			if (modal.IsActive)
			{
				InitializePrioritizedElements();
				PriorityType priority = modal.Priority;
				if (prioritizedElements.TryGetValue(priority, out var value))
				{
					value.Remove(modal);
					value.Add(modal);
				}
				ResetSortingOrder();
				ChangeUiElementsVisibility();
			}
		}

		public void Remove(GUI_CanvasElement modal, bool killTweens = true)
		{
			PriorityType priority = modal.Priority;
			if (prioritizedElements.TryGetValue(priority, out var value) && value.RemoveAll(modal.Equals) > 0)
			{
				if (killTweens && modal.TryGetComponent<CanvasGroup>(out var component))
				{
					component.DOKill();
				}
				ResetSortingOrder();
				ChangeUiElementsVisibility();
			}
		}

		public void ResetSortingOrder()
		{
			currentHighestOrderElement = null;
			currentHighestOrderInteractiveElement = null;
			int num = 0;
			foreach (KeyValuePair<PriorityType, List<GUI_CanvasElement>> prioritizedElement in prioritizedElements)
			{
				foreach (GUI_CanvasElement item in prioritizedElement.Value)
				{
					item.SortingOrder = 100 + num;
					num++;
					if (item.GuiElementType != null)
					{
						currentHighestOrderElement = item;
						if (item.GuiElementType.RewiredLayoutRuleSet != RewiredLayoutRuleSet.None)
						{
							currentHighestOrderInteractiveElement = item;
						}
					}
				}
			}
		}

		private void ChangeUiElementsVisibility()
		{
			foreach (List<GUI_CanvasElement> value in prioritizedElements.Values)
			{
				foreach (GUI_CanvasElement item in value)
				{
					if (item == null || item.gameObject == null)
					{
						continue;
					}
					if (currentHighestOrderInteractiveElement == null || guiCombinationRules.CanBeShownTogether(currentHighestOrderInteractiveElement.GuiElementType, item.GuiElementType))
					{
						if (item.IsAffectedByUiShowHide)
						{
							item.Fade(targetActiveState: true);
						}
					}
					else if (item.IsAffectedByUiShowHide || item.IsAffectedByUiHide)
					{
						item.Fade(targetActiveState: false);
					}
				}
			}
		}
	}
}
