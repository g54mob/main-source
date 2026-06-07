using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface ISelectableMoveHandler
{
	void OnMove(Selectable selectable, AxisEventData eventData);
}
