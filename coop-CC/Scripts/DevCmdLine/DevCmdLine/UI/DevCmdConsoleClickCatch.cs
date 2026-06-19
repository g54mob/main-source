using UnityEngine;
using UnityEngine.EventSystems;

namespace DevCmdLine.UI
{
	internal class DevCmdConsoleClickCatch : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public void OnPointerClick(PointerEventData eventData)
		{
			DevCmdConsole.CloseConsoleWithCallback();
		}
	}
}
