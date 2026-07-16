using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
	private float length;

	private float startpos;

	public float parallexEffect;

	private void Start()
	{
		startpos = base.transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	private void FixedUpdate()
	{
		float num = base.transform.position.x - Train.Instance.SpeedCurrent * Time.deltaTime * parallexEffect;
		base.transform.position = new Vector3(startpos + num, base.transform.position.y, base.transform.position.z);
		if (base.transform.position.x <= startpos - length)
		{
			base.transform.position = new Vector3(startpos, base.transform.position.y, base.transform.position.z);
		}
	}
}
