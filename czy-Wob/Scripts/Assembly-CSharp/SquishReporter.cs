using UnityEngine;

public class SquishReporter : MonoBehaviour
{
	public Growable growableRef;

	private void OnTriggerStay(Collider other)
	{
		growableRef.ReportSquish();
	}
}
