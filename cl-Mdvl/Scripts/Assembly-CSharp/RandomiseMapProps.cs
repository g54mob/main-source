using UnityEngine;

public class RandomiseMapProps : MonoBehaviour
{
	[SerializeField]
	private float scaleRange;

	[SerializeField]
	private float scaleRangeHight;

	[SerializeField]
	private float rotationRange;

	[SerializeField]
	private GameObject prop;

	[SerializeField]
	[Range(0f, 2f)]
	private int rotationRightAngle;

	public void AssignProp(GameObject prop)
	{
		this.prop = prop;
		Initialize();
	}

	private void Start()
	{
		if (!(prop == null))
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		Vector3 localScale = base.transform.localScale;
		float num = Random.Range(-1f * scaleRangeHight / 100f, scaleRangeHight / 100f);
		float num2 = Random.Range(localScale.x - scaleRange / 100f, localScale.x + scaleRange / 100f);
		prop.transform.localScale = new Vector3(num2, num2 + num, num2);
		Vector3 localEulerAngles = base.transform.localEulerAngles;
		int num3 = Random.Range(0, rotationRightAngle) * 90;
		float y = Random.Range(localEulerAngles.y - rotationRange, localEulerAngles.y + rotationRange) + (float)num3;
		Vector3 localEulerAngles2 = prop.gameObject.transform.localEulerAngles;
		prop.transform.localEulerAngles = new Vector3(localEulerAngles2.x, y, localEulerAngles2.z);
	}
}
