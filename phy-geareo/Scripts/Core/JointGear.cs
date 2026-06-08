using UnityEngine;

public class JointGear : MonoBehaviour
{
	public int teeth;

	public float toothWidth;

	public ConfigurableJoint joint;

	public JointGear other;

	public float radius => 0f;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
