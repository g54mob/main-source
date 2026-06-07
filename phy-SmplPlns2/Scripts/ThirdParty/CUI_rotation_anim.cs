using UnityEngine;

public class CUI_rotation_anim : MonoBehaviour
{
	public Vector3 Rotation;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.RotateAround(base.transform.position, base.transform.up, Rotation.y * Time.deltaTime);
		base.transform.RotateAround(base.transform.position, base.transform.right, Rotation.x * Time.deltaTime);
		base.transform.RotateAround(base.transform.position, base.transform.forward, Rotation.z * Time.deltaTime);
	}
}
