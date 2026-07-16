using UnityEngine;

public class CoalArrowEvent : MonoBehaviour
{
	public void Start()
	{
		UIManager.Instance.HUD.ShowCoalGauge(show: true);
	}
}
