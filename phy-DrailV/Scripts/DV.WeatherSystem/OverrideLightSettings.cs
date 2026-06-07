using UnityEngine;

public class OverrideLightSettings : MonoBehaviour
{
	private const float SLAVE_THRESHOLD = 0.5f;

	public Light master;

	public Light slave;

	private void LateUpdate()
	{
		if (master.intensity > slave.intensity && slave.intensity < 0.5f)
		{
			slave.intensity = master.intensity;
			slave.transform.position = master.transform.position;
			slave.transform.rotation = master.transform.rotation;
			slave.color = master.color;
		}
	}
}
