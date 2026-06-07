using UnityEngine;
using UnityEngine.EventSystems;

namespace Utility.DeveloperMode
{
	public class DeveloperModeToggle : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private PanelDeveloperModeMaster panel;

		public void OnPointerClick(PointerEventData eventData)
		{
			if (Input.GetKey(KeyCode.LeftControl))
			{
				panel.ToggleDeveloperMode();
			}
		}
	}
}
