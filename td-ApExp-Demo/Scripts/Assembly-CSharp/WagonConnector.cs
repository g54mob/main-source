using UnityEngine;

public class WagonConnector : MonoBehaviour
{
	public Wagon ahead;

	public Wagon behind;

	public float aheadHalfWidth;

	public float behindHalfWidth;

	private void Start()
	{
		if (!ahead || !behind)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		aheadHalfWidth = ahead.GetComponent<BoxCollider2D>().size.x / 2f;
		behindHalfWidth = behind.GetComponent<BoxCollider2D>().size.x / 2f;
	}

	private void Update()
	{
		if (!ahead || !behind)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Vector3 vector = ahead.transform.position - ahead.transform.rotation * new Vector3(aheadHalfWidth, 0f);
		Vector3 vector2 = behind.transform.position + behind.transform.rotation * new Vector3(behindHalfWidth, 0f);
		base.transform.position = (vector + vector2) / 2f;
		Vector3 vector3 = vector - base.transform.position;
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, vector3 / 2f) * Quaternion.Euler(0f, 0f, 90f);
	}
}
