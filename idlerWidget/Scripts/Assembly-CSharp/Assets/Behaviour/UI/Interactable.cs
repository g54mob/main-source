using UnityEngine;

namespace Assets.Behaviour.UI
{
	public class Interactable : MonoBehaviour
	{
		private void OnMouseOver()
		{
			GameUI.MouseOverInteractable(this);
		}
	}
}
