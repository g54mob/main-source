using UnityEngine;

public class wftryaska : MonoBehaviour
{
	public float rand;

	public float randm;

	public Transform cam;

	private void Update()
	{
		base.transform.LookAt(cam.position);
		base.transform.eulerAngles += new Vector3(Random.RandomRange(rand, randm), Random.RandomRange(rand, randm), Random.RandomRange(rand, randm));
	}
}
