using DV.VRTK_Extensions;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public class GadgetTouchedHighlighter : MonoBehaviour
	{
		private GadgetBase gadget;

		private VRTK_InteractableObject_DV grab;

		private void Awake()
		{
			gadget = GetComponent<GadgetBase>();
			grab = GetComponent<VRTK_InteractableObject_DV>();
			grab.InteractableObjectTouched += delegate
			{
				Refresh();
			};
			grab.InteractableObjectUntouched += delegate
			{
				Refresh();
			};
			Refresh();
		}

		private void Refresh()
		{
			base.enabled = grab.IsTouched() && grab.InteractionAllowed && gadget.GetValidRemovalMethods().HasAnyFlag(GadgetBase.GadgetRemovalMethod.EmptyHand);
		}

		private void LateUpdate()
		{
			gadget.DrawHighlight(GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
		}
	}
}
