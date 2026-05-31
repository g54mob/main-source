using UnityEngine;

public class N_AlwaysFacing : MonoBehaviour
{
	public GameObject cam;

	private void Start()
	{
		if (cam == null)
		{
			GameObject.FindGameObjectWithTag("MainCamera");
		}
	}

	private void Update()
	{
		if (cam != null)
		{
			GetComponent<Transform>().LookAt(cam.transform);
		}
	}
}
