using UnityEngine;

public class StayInCenter : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(0f, 0f, 0f);
	}
}
