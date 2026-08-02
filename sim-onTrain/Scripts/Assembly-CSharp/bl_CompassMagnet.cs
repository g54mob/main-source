using UnityEngine;

public class bl_CompassMagnet : MonoBehaviour
{
	private Transform Compass;

	private Vector3 euler;

	public void SetCompass()
	{
		if (Compass == null)
		{
			GameObject gameObject = new GameObject("Compass");
			Compass = gameObject.transform;
			Compass.parent = base.transform;
			Compass.localPosition = Vector3.zero;
			Compass.localRotation = Quaternion.identity;
		}
		CompassMarkEvent.SetCompassCamera(Compass);
	}

	private void Update()
	{
		if (!(Compass == null))
		{
			euler = Compass.eulerAngles;
			euler.x = 0f;
			Compass.eulerAngles = euler;
			Debug.DrawRay(Compass.position, Compass.forward, Color.red);
		}
	}
}
