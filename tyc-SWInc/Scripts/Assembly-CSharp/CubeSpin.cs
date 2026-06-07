using UnityEngine;

public class CubeSpin : MonoBehaviour
{
	private Quaternion target;

	private float countDown;

	private void Start()
	{
		target = Quaternion.LookRotation(Random.onUnitSphere);
		countDown = Random.Range(1f, 4f);
	}

	private void Update()
	{
		if (GameSettings.GameSpeed > 0f)
		{
			countDown -= Time.deltaTime * GameSettings.GameSpeed;
			if (countDown <= 0f)
			{
				target = Quaternion.LookRotation(Random.onUnitSphere);
				countDown = Random.Range(1f, 4f);
			}
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, target, Time.deltaTime * GameSettings.GameSpeed);
		}
	}
}
