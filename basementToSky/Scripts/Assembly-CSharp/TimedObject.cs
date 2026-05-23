using UnityEngine;

public class TimedObject : MonoBehaviour
{
	[SerializeField]
	private float time;

	private float timer;

	private void Start()
	{
		timer = 0f;
	}

	private void Update()
	{
		if (timer > time)
		{
			Object.DestroyImmediate(base.gameObject);
		}
		timer += Time.deltaTime;
	}
}
