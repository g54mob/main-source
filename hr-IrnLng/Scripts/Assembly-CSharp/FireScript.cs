using UnityEngine;

public class FireScript : MonoBehaviour
{
	public float MyIntensity;

	public Light MyLight;

	private float OGIntensity;

	public FireManagerScript Manager;

	private void Start()
	{
		OGIntensity = MyLight.intensity;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		base.transform.localScale = new Vector3(MyIntensity, MyIntensity, MyIntensity);
		MyLight.intensity = OGIntensity * MyIntensity;
	}

	public void SetIntensity(float i)
	{
		MyIntensity = i;
	}

	public void Extinguish()
	{
		MyIntensity -= Manager.ExtinguishSpeed;
		if (MyIntensity < 0f)
		{
			MyIntensity = 0f;
			Manager.GrowFire = false;
		}
	}
}
