using UnityEngine;

public class StuckUnderGroundSafeguard : MonoBehaviour
{
	private void FixedUpdate()
	{
		if (base.transform.position.y < -11f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 5f, base.transform.position.z);
			try
			{
				Rigidbody component = GetComponent<Rigidbody>();
				component.linearVelocity = Vector3.zero;
				component.AddForce(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f), ForceMode.VelocityChange);
			}
			catch
			{
			}
		}
	}
}
