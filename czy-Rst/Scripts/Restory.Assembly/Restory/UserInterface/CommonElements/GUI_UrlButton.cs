using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	[RequireComponent(typeof(Button))]
	public class GUI_UrlButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ISubmitHandler
	{
		public string urlString = "";

		public void OnPointerClick(PointerEventData eventData)
		{
			Application.OpenURL(urlString);
		}

		public void OnSubmit(BaseEventData eventData)
		{
			Application.OpenURL(urlString);
		}
	}
}
