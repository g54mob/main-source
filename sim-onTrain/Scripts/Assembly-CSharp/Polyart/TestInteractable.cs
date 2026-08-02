using UnityEngine;

namespace Polyart
{
	public class TestInteractable : Interactable_Dreamscape
	{
		public override void OnFocus()
		{
			MonoBehaviour.print("Looking at " + base.gameObject.name);
		}

		public override void OnInteract()
		{
			MonoBehaviour.print("Interacted with " + base.gameObject.name);
		}

		public override void OnLoseFocus()
		{
			MonoBehaviour.print("Stopped Looking at " + base.gameObject.name);
		}
	}
}
