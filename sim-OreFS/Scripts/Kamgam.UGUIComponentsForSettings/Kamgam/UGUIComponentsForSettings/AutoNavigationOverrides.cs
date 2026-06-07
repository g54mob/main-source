using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	[RequireComponent(typeof(Selectable))]
	public class AutoNavigationOverrides : MonoBehaviour, ISelectHandler, IEventSystemHandler, IUpdateSelectedHandler
	{
		protected Selectable selectable;

		public bool DisableOnAwakeIfNotNeeded = true;

		[Tooltip("Defines which element to navigate to.<br />If left empty then the default navigatoin will be used.")]
		public Selectable SelectOnUpOverride;

		[Tooltip("Defines which element to navigate to.<br />If left empty then the default navigatoin will be used.")]
		public Selectable SelectOnDownOverride;

		[Tooltip("Defines which element to navigate to.<br />If left empty then the default navigatoin will be used.")]
		public Selectable SelectOnLeftOverride;

		[Tooltip("Defines which element to navigate to.<br />If left empty then the default navigatoin will be used.")]
		public Selectable SelectOnRightOverride;

		public bool BlockUp;

		public bool BlockDown;

		public bool BlockLeft;

		public bool BlockRight;

		public Selectable Selectable
		{
			get
			{
				if (selectable == null)
				{
					selectable = GetComponent<Selectable>();
				}
				return selectable;
			}
		}

		public bool IsBlockingAnyDirection
		{
			get
			{
				if (!BlockUp && !BlockDown && !BlockLeft)
				{
					return BlockRight;
				}
				return true;
			}
		}

		public void Awake()
		{
			if (Selectable != null && Selectable.navigation.mode == Navigation.Mode.Explicit)
			{
				base.enabled = false;
			}
			if (DisableOnAwakeIfNotNeeded && !HasOverrides() && !IsBlockingAnyDirection)
			{
				base.enabled = false;
			}
		}

		public bool HasOverrides()
		{
			if (!(SelectOnUpOverride != null) && !(SelectOnDownOverride != null) && !(SelectOnLeftOverride != null))
			{
				return SelectOnRightOverride != null;
			}
			return true;
		}

		public bool HasActiveOverrides()
		{
			if ((!(SelectOnUpOverride != null) || !SelectOnUpOverride.isActiveAndEnabled) && (!(SelectOnDownOverride != null) || !SelectOnDownOverride.isActiveAndEnabled) && (!(SelectOnLeftOverride != null) || !SelectOnLeftOverride.isActiveAndEnabled))
			{
				if (SelectOnRightOverride != null)
				{
					return SelectOnRightOverride.isActiveAndEnabled;
				}
				return false;
			}
			return true;
		}

		public void OnUpdateSelected(BaseEventData eventData)
		{
			ApplyOverrides();
		}

		public void ApplyOverrides()
		{
			if (Selectable == null)
			{
				return;
			}
			Navigation navigation;
			if (!HasActiveOverrides() && !IsBlockingAnyDirection)
			{
				navigation = Selectable.navigation;
				navigation.mode = Navigation.Mode.Automatic;
				Selectable.navigation = navigation;
				return;
			}
			navigation = Selectable.navigation;
			navigation.mode = Navigation.Mode.Automatic;
			Selectable.navigation = navigation;
			Selectable selectOnUp = Selectable.FindSelectableOnUp();
			Selectable selectOnDown = Selectable.FindSelectableOnDown();
			Selectable selectOnLeft = Selectable.FindSelectableOnLeft();
			Selectable selectOnRight = Selectable.FindSelectableOnRight();
			navigation = Selectable.navigation;
			navigation.mode = Navigation.Mode.Explicit;
			navigation.selectOnUp = selectOnUp;
			navigation.selectOnDown = selectOnDown;
			navigation.selectOnLeft = selectOnLeft;
			navigation.selectOnRight = selectOnRight;
			if (HasOverrides())
			{
				if (SelectOnUpOverride != null && SelectOnUpOverride.interactable)
				{
					navigation.selectOnUp = SelectOnUpOverride;
				}
				if (SelectOnDownOverride != null && SelectOnDownOverride.interactable)
				{
					navigation.selectOnDown = SelectOnDownOverride;
				}
				if (SelectOnLeftOverride != null && SelectOnLeftOverride.interactable)
				{
					navigation.selectOnLeft = SelectOnLeftOverride;
				}
				if (SelectOnRightOverride != null && SelectOnRightOverride.interactable)
				{
					navigation.selectOnRight = SelectOnRightOverride;
				}
			}
			if (BlockUp)
			{
				navigation.selectOnUp = null;
			}
			if (BlockDown)
			{
				navigation.selectOnDown = null;
			}
			if (BlockLeft)
			{
				navigation.selectOnLeft = null;
			}
			if (BlockRight)
			{
				navigation.selectOnRight = null;
			}
			Selectable.navigation = navigation;
		}

		public void OnSelect(BaseEventData eventData)
		{
			ApplyOverrides();
		}
	}
}
