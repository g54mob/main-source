using UnityEngine;

public class LogoLightScript : MonoBehaviour
{
	private float time;

	private float time2;

	private float next;

	public Color c1;

	public Color c2;

	public Color c3;

	public bool isc1 = true;

	private void Start()
	{
		time = Time.timeSinceLevelLoad;
		time2 = Time.timeSinceLevelLoad;
		GetComponent<Renderer>().material.color = c1;
		next = 2f;
	}

	private void Update()
	{
		if (Time.timeSinceLevelLoad - time2 < 2f)
		{
			GetComponent<Renderer>().material.color = c1;
			return;
		}
		if (Time.timeSinceLevelLoad - time > next)
		{
			isc1 = !isc1;
			time = Time.timeSinceLevelLoad;
			next = Random.Range(1f, 3f);
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane plane = new Plane(base.transform.parent.rotation * Vector3.left, base.transform.parent.position);
		float enter = 0f;
		plane.Raycast(ray, out enter);
		Vector3 point = ray.GetPoint(enter);
		if ((base.transform.position - point).magnitude < 0.1f)
		{
			GetComponent<Renderer>().material.color = c3;
			isc1 = false;
		}
		else
		{
			GetComponent<Renderer>().material.color = (isc1 ? c1 : c2);
		}
	}
}
