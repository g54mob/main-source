using UnityEngine;

public class DemoFinishPoint : MonoBehaviour
{
	private bool triggered;

	private void OnTriggerEnter(Collider other)
	{
		if (!triggered)
		{
			TrainController componentInParent = other.GetComponentInParent<TrainController>();
			if (!(componentInParent == null))
			{
				triggered = true;
				Debug.Log("[DemoFinishPoint] Tren demo bitiş noktasına ulaştı!");
				componentInParent.SetDemoFinished();
			}
		}
	}
}
