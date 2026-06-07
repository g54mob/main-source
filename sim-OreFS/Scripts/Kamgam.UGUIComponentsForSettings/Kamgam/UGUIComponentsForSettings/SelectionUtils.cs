using UnityEngine;
using UnityEngine.EventSystems;

namespace Kamgam.UGUIComponentsForSettings
{
	public static class SelectionUtils
	{
		public static void SetSelected(GameObject go, bool triggerOnReselect = true)
		{
			if (EventSystem.current != null && go != null && !EventSystem.current.alreadySelecting)
			{
				bool num = EventSystem.current.currentSelectedGameObject == go;
				EventSystem.current.SetSelectedGameObject(go);
				if (num && triggerOnReselect)
				{
					ExecuteEvents.ExecuteHierarchy(go, new BaseEventData(EventSystem.current), ExecuteEvents.selectHandler);
				}
			}
		}
	}
}
