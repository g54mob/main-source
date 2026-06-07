using System.Collections.Generic;
using UnityEngine.EventSystems;

public abstract class DrifterPanelBase : Panel, IMoveHandler, IEventSystemHandler
{
	public abstract void UpdateDrifters(List<Agent> drifters);

	public abstract void SetSelectedDrifter(Agent drifter);

	public abstract void OnMove(AxisEventData axisEventData);
}
