using UnityEngine;
using UnityEngine.EventSystems;

public class CompanyChartScrollBar : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	public CompanyChart chart;

	public void OnScroll(PointerEventData d)
	{
		chart.OnScroll(d);
	}
}
