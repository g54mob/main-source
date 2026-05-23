using UnityEngine;
using UnityEngine.Events;

public class TriggerOnHealthLoss : MonoBehaviour
{
	[SerializeField]
	private Hp healthToMonitor;

	[SerializeField]
	private int healthSegments;

	public UnityEvent onHealthSegmentLost;

	private float healthSegmentSize;

	private int previousSegments;

	private void Start()
	{
		healthSegmentSize = healthToMonitor.maxHp / (float)healthSegments;
		previousSegments = Mathf.CeilToInt(healthToMonitor.HpValue / healthSegmentSize);
	}

	private void Update()
	{
		int num = Mathf.CeilToInt(healthToMonitor.HpValue / healthSegmentSize);
		if (num < previousSegments)
		{
			int num2 = previousSegments - num;
			for (int i = 0; i < num2; i++)
			{
				onHealthSegmentLost.Invoke();
			}
			previousSegments = num;
		}
	}
}
