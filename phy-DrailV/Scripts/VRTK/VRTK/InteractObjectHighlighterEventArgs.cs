using UnityEngine;

namespace VRTK
{
	public struct InteractObjectHighlighterEventArgs
	{
		public VRTK_InteractableObject.InteractionType interactionType;

		public Color highlightColor;

		public GameObject affectingObject;

		public VRTK_InteractableObject objectToMonitor;

		public GameObject affectedObject;
	}
}
