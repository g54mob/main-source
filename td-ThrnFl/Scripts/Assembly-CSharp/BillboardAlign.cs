using UnityEngine;

public class BillboardAlign : MonoBehaviour
{
	public bool negativeZ = true;

	private void Start()
	{
		if (negativeZ)
		{
			base.transform.forward = Camera.main.transform.forward;
		}
		else
		{
			base.transform.forward = Camera.main.transform.forward * -1f;
		}
	}
}
