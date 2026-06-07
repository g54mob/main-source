using UnityEngine;

public class Rotater : MonoBehaviour
{
	public bool Random;

	public float RandomBase;

	public Vector3 direction;

	private void Start()
	{
		if (Random)
		{
			direction = UnityUtils.GetRandomVector3(RandomBase);
		}
	}

	private void Update()
	{
		base.transform.Rotate(direction * Time.smoothDeltaTime);
	}
}
