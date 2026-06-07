using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class TouchButtonCouldNotLoadLibraryPopup : Selectable
	{
		private const string SupportURL = "https://dinopoloclub.com/support/mini-motorways/";

		public override void OnPointerDown(PointerEventData eventData)
		{
			Application.OpenURL("https://dinopoloclub.com/support/mini-motorways/");
			Application.Quit();
			base.OnPointerDown(eventData);
		}
	}
}
