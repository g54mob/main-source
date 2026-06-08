using System.Collections;
using UnityEngine;

public class levitateMe : MonoBehaviour
{
	private Vector3 origin;

	private Vector3 target;

	public float levRange = 1f;

	public float levSpeed = 1f;

	private bool nextHover;

	private bool startHovering;

	private void Start()
	{
		origin = base.transform.localPosition;
		target = new Vector3(origin.x, origin.y, origin.z + levRange);
		nextHover = true;
		startHovering = false;
		StartCoroutine("randomStartTime");
	}

	private void Update()
	{
		if (startHovering)
		{
			if (Vector3.Distance(base.transform.localPosition, origin) < 0.05f || nextHover)
			{
				base.transform.localPosition = Vector3.Slerp(base.transform.localPosition, target, levSpeed * Time.deltaTime);
				nextHover = true;
			}
			if (Vector3.Distance(base.transform.localPosition, target) < 0.05f || !nextHover)
			{
				base.transform.localPosition = Vector3.Slerp(base.transform.localPosition, origin, levSpeed * Time.deltaTime);
				nextHover = false;
			}
		}
	}

	private IEnumerator levitating()
	{
		Debug.Log("starting levitation");
		base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, target, levSpeed * Time.deltaTime);
		yield return null;
		Debug.Log("Levitation Next Step");
		base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, origin, levSpeed * Time.deltaTime);
		yield return null;
		nextHover = true;
	}

	private IEnumerator randomStartTime()
	{
		yield return new WaitForSeconds(Random.Range(0f, levSpeed));
		startHovering = true;
	}
}
