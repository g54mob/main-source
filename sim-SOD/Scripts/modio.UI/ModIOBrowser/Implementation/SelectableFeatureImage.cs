using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	public class SelectableFeatureImage : MonoBehaviour, IMoveHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
	{
		public void OnMove(AxisEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}
	}
}
