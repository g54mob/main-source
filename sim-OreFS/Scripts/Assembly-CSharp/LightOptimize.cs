using UnityEngine;

public class LightOptimize : MonoBehaviour
{
	public float availableDistance;

	private float Distance;

	private Light Lightcomponent;

	private GameObject Player;

	private void Start()
	{
		Lightcomponent = base.gameObject.GetComponent<Light>();
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			Player = GameObject.FindGameObjectWithTag("Player");
		}
		else
		{
			Object.Destroy(GetComponent("LightOptimize"));
		}
	}

	private void Update()
	{
		Distance = Vector3.Distance(Player.transform.position, base.transform.position);
		if (Distance < availableDistance)
		{
			Lightcomponent.enabled = true;
		}
		if (Distance > availableDistance)
		{
			Lightcomponent.enabled = false;
		}
	}
}
