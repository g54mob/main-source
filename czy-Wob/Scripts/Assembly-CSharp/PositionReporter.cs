using UnityEngine;

public class PositionReporter : MonoBehaviour
{
	private void Update()
	{
		MonoBehaviour.print(base.transform.localPosition.y);
	}
}
