using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Demo")]
public class SCC_Demo : MonoBehaviour
{
	public GameObject[] spawnableCars;

	public Transform defaultSpawnPoint;

	public bool destroyAllCars = true;

	public void SpawnCar(int selectedCar)
	{
		if (destroyAllCars)
		{
			SCC_Drivetrain[] array = Object.FindObjectsOfType<SCC_Drivetrain>();
			for (int i = 0; i < array.Length; i++)
			{
				Object.Destroy(array[i].gameObject);
			}
		}
		SCC_Camera sCC_Camera = Object.FindObjectOfType<SCC_Camera>();
		SCC_Dashboard sCC_Dashboard = Object.FindObjectOfType<SCC_Dashboard>();
		Vector3 position;
		Quaternion rotation;
		if ((bool)sCC_Camera)
		{
			position = sCC_Camera.transform.position;
			rotation = sCC_Camera.transform.rotation;
			position += sCC_Camera.transform.forward * sCC_Camera.distance;
		}
		else if ((bool)defaultSpawnPoint)
		{
			position = defaultSpawnPoint.position;
			rotation = defaultSpawnPoint.rotation;
		}
		else
		{
			position = Vector3.zero;
			rotation = Quaternion.identity;
		}
		GameObject gameObject = Object.Instantiate(spawnableCars[selectedCar], position, rotation);
		if ((bool)sCC_Camera)
		{
			sCC_Camera.playerCar = gameObject.GetComponent<SCC_Drivetrain>().transform;
		}
		if ((bool)sCC_Dashboard)
		{
			sCC_Dashboard.car = gameObject.GetComponent<SCC_Drivetrain>();
		}
	}
}
