using UnityEngine;

public class StabilizerGlobePositioner : MonoBehaviour
{
	private Stabilizer stabilizer;

	private GameObject globeObject;

	private float angForceX;

	private float angForceY;

	private float angForceZ;

	private float currentXVelocity;

	private float currentYVelocity;

	private float currentZVelocity;

	private void Awake()
	{
		stabilizer = GetComponent<Stabilizer>();
		globeObject = base.transform.Find("Globe").gameObject;
		currentXVelocity = (currentYVelocity = (currentZVelocity = 0f));
	}

	private void Update()
	{
		Vector3 vector = base.transform.InverseTransformVector(stabilizer.AngForceVector * 10f);
		angForceX = Mathf.SmoothDamp(angForceX, vector.x, ref currentXVelocity, 0.2f);
		angForceY = Mathf.SmoothDamp(angForceY, vector.y, ref currentYVelocity, 0.2f);
		angForceZ = Mathf.SmoothDamp(angForceZ, vector.z, ref currentZVelocity, 0.2f);
		globeObject.transform.localEulerAngles = new Vector3(angForceX, angForceY, angForceZ);
	}
}
