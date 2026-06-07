using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Rigid Stabilizer")]
[RequireComponent(typeof(Rigidbody))]
public class SCC_RigidStabilizer : MonoBehaviour
{
	private Rigidbody rigid;

	private SCC_Wheel[] wheels;

	public float reflection = 100f;

	public float stability = 0.5f;

	private Rigidbody Rigid
	{
		get
		{
			if (rigid == null)
			{
				rigid = GetComponent<Rigidbody>();
			}
			return rigid;
		}
	}

	private void Start()
	{
		wheels = GetComponentsInChildren<SCC_Wheel>();
	}

	private void FixedUpdate()
	{
		if (!Rigid)
		{
			base.enabled = false;
			return;
		}
		Vector3 vector = Vector3.Cross(Quaternion.AngleAxis(Rigid.linearVelocity.magnitude * 57.29578f * stability / reflection, Rigid.angularVelocity) * base.transform.up, Vector3.up);
		bool flag = false;
		for (int i = 0; i < wheels.Length; i++)
		{
			if (wheels[i].isGrounded)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			Rigid.AddTorque(vector * reflection * reflection);
		}
	}
}
