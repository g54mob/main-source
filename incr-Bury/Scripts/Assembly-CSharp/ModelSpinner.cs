using UnityEngine;

public class ModelSpinner : MonoBehaviour
{
	[SerializeField]
	private bool inWorldSpace;

	[SerializeField]
	private Vector3 spinDir;

	private void Update()
	{
		if (inWorldSpace)
		{
			base.transform.Rotate(spinDir * Time.deltaTime, Space.World);
		}
		else
		{
			base.transform.Rotate(spinDir * Time.deltaTime, Space.Self);
		}
	}
}
