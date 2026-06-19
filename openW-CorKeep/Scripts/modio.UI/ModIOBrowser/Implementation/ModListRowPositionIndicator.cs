using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	public class ModListRowPositionIndicator : MonoBehaviour, IMoveHandler, IEventSystemHandler
	{
		public void OnMove(AxisEventData eventData)
		{
			ModListRow.currentSelectedPosition = base.transform.position;
		}
	}
}
