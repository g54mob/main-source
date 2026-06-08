using System;
using Dorfromantik.UI.MainMenu;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiSelectable : Selectable, ISubmitHandler, IEventSystemHandler
	{
		[SerializeField]
		protected bool shouldNotLookForUpNeighbor;

		[SerializeField]
		protected bool shouldNotLookForDownNeighbor;

		[SerializeField]
		protected bool shouldNotLookForRightNeighbor;

		[SerializeField]
		protected bool shouldNotLookForLeftNeighbor;

		[SerializeField]
		protected SaveGameUi parentSaveGameUi;

		private bool _003CIsSelected_003Ek__BackingField;

		public bool IsSelected
		{
			get
			{
				return _003CIsSelected_003Ek__BackingField;
			}
			private set
			{
				_003CIsSelected_003Ek__BackingField = value;
			}
		}

		public event Action OnSelected;

		public event Action OnDeselected;

		public event Action OnSubmitted;

		protected override void Awake()
		{
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			if ((bool)parentSaveGameUi)
			{
				parentSaveGameUi.OnSelect(eventData);
			}
			IsSelected = true;
			this.OnSelected?.Invoke();
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			if ((bool)parentSaveGameUi)
			{
				parentSaveGameUi.OnDeselect(eventData);
			}
			IsSelected = false;
			this.OnDeselected?.Invoke();
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if ((bool)parentSaveGameUi)
			{
				parentSaveGameUi.OnSubmit(eventData);
			}
			this.OnSubmitted?.Invoke();
		}

		private void GetUiSelectableNeighbors()
		{
			Navigation navigation = base.navigation;
			if (!shouldNotLookForUpNeighbor)
			{
				navigation.selectOnUp = FindUiSelectableOnUp();
			}
			if (!shouldNotLookForDownNeighbor)
			{
				navigation.selectOnDown = FindUiSelectableOnDown();
			}
			if (!shouldNotLookForRightNeighbor)
			{
				navigation.selectOnRight = FindUiSelectableOnRight();
			}
			if (!shouldNotLookForLeftNeighbor)
			{
				navigation.selectOnLeft = FindUiSelectableOnLeft();
			}
			base.navigation = navigation;
		}

		private UiSelectable FindUiSelectableOnUp()
		{
			UiSelectable component = FindSelectableOnUp().GetComponent<UiSelectable>();
			if (!component)
			{
				return null;
			}
			return component;
		}

		private UiSelectable FindUiSelectableOnDown()
		{
			UiSelectable component = FindSelectableOnDown().GetComponent<UiSelectable>();
			if (!component)
			{
				return null;
			}
			return component;
		}

		private UiSelectable FindUiSelectableOnRight()
		{
			UiSelectable component = FindSelectableOnRight().GetComponent<UiSelectable>();
			if (!component)
			{
				return null;
			}
			return component;
		}

		private UiSelectable FindUiSelectableOnLeft()
		{
			UiSelectable component = FindSelectableOnLeft().GetComponent<UiSelectable>();
			if (!component)
			{
				return null;
			}
			return component;
		}
	}
}
