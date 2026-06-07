using UnityEngine;

namespace VRTK
{
	public struct InteractObjectAppearanceEventArgs
	{
		public GameObject affectingObject;

		public GameObject objectToIgnore;

		public VRTK_InteractableObject monitoringObject;

		public VRTK_InteractableObject.InteractionType interactionType;
	}
}
