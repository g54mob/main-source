using DV.CabControls;
using DV.Highlighting;
using DV.InventorySystem;
using DV.UIFramework;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Items
{
	public class ItemContainerAccessPoint : MonoBehaviour
	{
		public enum AccessPointHighlightType
		{
			None = 0,
			Neutral = 1,
			Good = 2,
			Bad = 3
		}

		private ButtonBase button;

		[SerializeField]
		private AItemContainer container;

		private HighlightTag highlightTag;

		private VRTK_InteractableObject_DV interactableObject;

		public AItemContainer Container => container;

		private void Start()
		{
			if (container == null)
			{
				Debug.LogError("ItemContainerAccessPoint: No AItemContainer component found. Item container will be inaccessible.", this);
				return;
			}
			button = GetComponent<ButtonBase>();
			if (button == null)
			{
				Debug.LogError("ItemContainerAccessPoint: No ButtonBase component found on " + base.name + ". Item container will be inaccessible.", this);
				return;
			}
			highlightTag = GetComponentInChildren<HighlightTag>();
			button.Used += OnButtonUsed;
			if (VRManager.IsVREnabled())
			{
				interactableObject = base.gameObject.GetComponent<VRTK_InteractableObject_DV>();
				if (interactableObject == null)
				{
					Debug.LogError("ItemContainerAccessPoint: No VRTK_InteractableObject_DV component found on " + base.name + ". Hover highlight will not work.", this);
					return;
				}
				interactableObject.InteractableObjectTouched += OnInteractableObjectTouched;
				interactableObject.InteractableObjectUntouched += OnInteractableObjectUntouched;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				if (button != null)
				{
					button.Used -= OnButtonUsed;
				}
				if (interactableObject != null)
				{
					interactableObject.InteractableObjectTouched -= OnInteractableObjectTouched;
					interactableObject.InteractableObjectUntouched -= OnInteractableObjectUntouched;
				}
			}
		}

		private void OnInteractableObjectTouched(object _, InteractableObjectEventArgs __)
		{
			ForceHighlight(AccessPointHighlightType.Neutral);
		}

		private void OnInteractableObjectUntouched(object _, InteractableObjectEventArgs __)
		{
			if (!interactableObject.IsTouched())
			{
				ForceHighlight(AccessPointHighlightType.None);
			}
		}

		private void OnButtonUsed()
		{
			container.ToggleContainerAccess();
		}

		public void ForceHighlight(AccessPointHighlightType highlightType)
		{
			if (!(highlightTag == null))
			{
				switch (highlightType)
				{
				case AccessPointHighlightType.None:
					SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: false, highlightTag, AGeneralHighlighter.HighlightType.Control, useObstructedMaterial: false, forced: true);
					break;
				case AccessPointHighlightType.Neutral:
					SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: true, highlightTag, AGeneralHighlighter.HighlightType.Control, useObstructedMaterial: false, forced: true);
					break;
				case AccessPointHighlightType.Good:
				{
					Color rED = UIColors.GREEN;
					SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: true, highlightTag, AGeneralHighlighter.HighlightType.Control, useObstructedMaterial: false, rED, forced: true);
					break;
				}
				case AccessPointHighlightType.Bad:
				{
					Color rED = UIColors.RED;
					SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: true, highlightTag, AGeneralHighlighter.HighlightType.Control, useObstructedMaterial: false, rED, forced: true);
					break;
				}
				default:
					Debug.LogError(string.Format("{0}: Unknown highlight type {1} for {2}.", "ItemContainerAccessPoint", highlightType, base.name), this);
					break;
				}
			}
		}
	}
}
