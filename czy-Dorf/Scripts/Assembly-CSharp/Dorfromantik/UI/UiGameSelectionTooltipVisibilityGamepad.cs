using Dorfromantik.UI.Components;
using UnityEngine;

namespace Dorfromantik.UI
{
	public class UiGameSelectionTooltipVisibilityGamepad : MonoBehaviour
	{
		[SerializeField]
		private UiSelectable uiSelectableReference;

		[SerializeField]
		private UiButton uiButtonReference;

		[SerializeField]
		private GameObject uiSelectableParentReference;

		[SerializeField]
		private bool shouldAutomaticallyPickCorrectChildComponent = true;

		[SerializeField]
		private bool shouldHideOnAwake;

		[SerializeField]
		private bool shouldShowWhenReferenceIsSelected = true;

		[SerializeField]
		private bool shouldHideWhenReferenceIsSelected;

		[SerializeField]
		private bool shouldShowWhenReferenceIsDeselected;

		[SerializeField]
		private bool shouldHideWhenReferenceIsDeselected = true;

		[SerializeField]
		private GameObject gameObjectToChangeVisibility;

		private void OnValidate()
		{
			if (shouldHideWhenReferenceIsSelected && shouldShowWhenReferenceIsSelected)
			{
				Debug.LogError("Can not have both options! Only one should be picked (shouldHideWhenReferenceIsSelected or shouldHideWhenReferenceIsDeselected");
			}
			if (shouldShowWhenReferenceIsDeselected && shouldHideWhenReferenceIsDeselected)
			{
				Debug.LogError("Can not have both options! Only one should be picked (shouldShowWhenReferenceIsDeselected or shouldHideWhenReferenceIsDeselected");
			}
			if ((bool)uiSelectableParentReference && shouldAutomaticallyPickCorrectChildComponent)
			{
				UiSelectable componentInChildren = uiSelectableParentReference.GetComponentInChildren<UiSelectable>();
				UiButton componentInChildren2 = uiSelectableParentReference.GetComponentInChildren<UiButton>();
				if (componentInChildren == null && componentInChildren2 == null)
				{
					Debug.LogError("No component of the type " + componentInChildren.name + " or " + componentInChildren2.name + "  attached to this GameObject or its children were found.");
				}
				else if ((bool)componentInChildren)
				{
					uiSelectableReference = componentInChildren;
				}
				else if ((bool)componentInChildren2)
				{
					uiButtonReference = componentInChildren2;
				}
			}
		}

		private void Awake()
		{
			if (gameObjectToChangeVisibility == null)
			{
				gameObjectToChangeVisibility = base.gameObject;
			}
			if ((bool)uiSelectableParentReference && uiSelectableReference == null)
			{
				uiSelectableReference = uiSelectableParentReference.GetComponentInChildren<UiSelectable>();
				if (uiSelectableReference == null)
				{
					uiButtonReference = uiSelectableParentReference.GetComponentInChildren<UiButton>();
				}
			}
			if (shouldHideOnAwake)
			{
				Hide();
			}
			else
			{
				Show();
			}
			SubscribeToEvents();
		}

		private void OnDestroy()
		{
			if ((bool)uiSelectableReference)
			{
				UnsubscribeToEvents();
			}
		}

		private void Show()
		{
			gameObjectToChangeVisibility.SetActive(value: true);
		}

		private void Hide()
		{
			gameObjectToChangeVisibility.SetActive(value: false);
		}

		private void SubscribeToEvents()
		{
			if ((bool)uiSelectableReference)
			{
				if (shouldShowWhenReferenceIsSelected)
				{
					uiSelectableReference.OnSelected += Show;
				}
				else if (shouldHideWhenReferenceIsSelected)
				{
					uiSelectableReference.OnSelected += Hide;
				}
				if (shouldShowWhenReferenceIsDeselected)
				{
					uiSelectableReference.OnDeselected += Show;
				}
				else if (shouldHideWhenReferenceIsDeselected)
				{
					uiSelectableReference.OnDeselected += Hide;
				}
			}
			else if ((bool)uiButtonReference)
			{
				if (shouldShowWhenReferenceIsSelected)
				{
					uiButtonReference.OnSelected += Show;
				}
				else if (shouldHideWhenReferenceIsSelected)
				{
					uiButtonReference.OnSelected += Hide;
				}
				if (shouldShowWhenReferenceIsDeselected)
				{
					uiButtonReference.OnDeselected += Show;
				}
				else if (shouldHideWhenReferenceIsDeselected)
				{
					uiButtonReference.OnDeselected += Hide;
				}
			}
		}

		private void UnsubscribeToEvents()
		{
			if ((bool)uiSelectableReference)
			{
				if (shouldShowWhenReferenceIsSelected)
				{
					uiSelectableReference.OnSelected -= Show;
				}
				else if (shouldHideWhenReferenceIsSelected)
				{
					uiSelectableReference.OnSelected -= Hide;
				}
				if (shouldShowWhenReferenceIsDeselected)
				{
					uiSelectableReference.OnDeselected -= Show;
				}
				else if (shouldHideWhenReferenceIsDeselected)
				{
					uiSelectableReference.OnDeselected -= Hide;
				}
			}
			else if ((bool)uiButtonReference)
			{
				if (shouldShowWhenReferenceIsSelected)
				{
					uiButtonReference.OnSelected -= Show;
				}
				else if (shouldHideWhenReferenceIsSelected)
				{
					uiButtonReference.OnSelected -= Hide;
				}
				if (shouldShowWhenReferenceIsDeselected)
				{
					uiButtonReference.OnDeselected -= Show;
				}
				else if (shouldHideWhenReferenceIsDeselected)
				{
					uiButtonReference.OnDeselected -= Hide;
				}
			}
		}
	}
}
