using UnityEngine;

public class DroneFeelers : MonoBehaviour
{
	private Drone _drone;

	public GameObject RightFeeler { get; private set; }

	public GameObject MiddleFeeler { get; private set; }

	public GameObject LeftFeeler { get; private set; }

	private void Awake()
	{
		Transform transform = base.transform.FindChild("Right");
		if (transform != null)
		{
			RightFeeler = transform.gameObject;
		}
		transform = base.transform.FindChild("Middle");
		if (transform != null)
		{
			MiddleFeeler = transform.gameObject;
		}
		transform = base.transform.FindChild("Left");
		if (transform != null)
		{
			LeftFeeler = transform.gameObject;
		}
		if (RightFeeler == null || MiddleFeeler == null || LeftFeeler == null)
		{
			Debug.LogWarning("Missing some feels");
		}
	}

	public void SetMyDrone(Drone drone)
	{
		_drone = drone;
	}
}
