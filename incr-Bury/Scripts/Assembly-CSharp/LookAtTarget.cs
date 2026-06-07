using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
	[Header("Target")]
	[SerializeField]
	private Transform target;

	private void Update()
	{
		if ((bool)target)
		{
			base.transform.LookAt(target.position);
		}
	}
}
