using UnityEngine;

namespace Assets.Behaviour.UI
{
	public class Interactable : MonoBehaviour
	{
		private void OnMouseOver()
		{
			if (base.enabled)
			{
				GameUI.MouseOverInteractable(this);
			}
		}
	}
}
