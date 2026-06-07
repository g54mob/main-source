using UnityEngine;

public class BarPositioner : MonoBehaviour
{
	public GameObject topObject;

	public GameObject bottomObject;

	public float defaultDistance;

	private void Awake()
	{
		if (bottomObject != null && topObject != null)
		{
			defaultDistance = Vector3.Distance(bottomObject.transform.position, topObject.transform.position);
		}
	}

	public void Initialize(GameObject bottomObject, GameObject topObject)
	{
		this.topObject = topObject;
		this.bottomObject = bottomObject;
		defaultDistance = Vector3.Distance(bottomObject.transform.position, topObject.transform.position);
	}

	private void Update()
	{
		float y = Vector3.Distance(bottomObject.transform.position, topObject.transform.position) / defaultDistance;
		base.transform.SetLocalScaleY(y);
	}
}
