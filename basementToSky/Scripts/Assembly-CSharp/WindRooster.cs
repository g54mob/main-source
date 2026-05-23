using UnityEngine;

public class WindRooster : Furniture
{
	[SerializeField]
	private Transform roosterGO;

	[SerializeField]
	private float rotateSpeed = 5f;

	private void OnEnable()
	{
		GameManager.S.isWindRooksterInstalled = true;
	}

	private void OnDisable()
	{
		GameManager.S.isWindRooksterInstalled = false;
	}

	private void Update()
	{
		if (GameManager.S.windManager != null)
		{
			Vector3 wind = GameManager.S.windManager.wind;
			Vector3 vector = new Vector3(wind.x, 0f, wind.z);
			if (vector != Vector3.zero)
			{
				Quaternion b = Quaternion.LookRotation(vector);
				roosterGO.rotation = Quaternion.Slerp(roosterGO.rotation, b, Time.deltaTime * rotateSpeed);
			}
		}
	}
}
