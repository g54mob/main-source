using System;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Antiroll")]
public class SCC_AntiRoll : MonoBehaviour
{
	[Serializable]
	public class Wheels
	{
		public SCC_Wheel leftWheel;

		public SCC_Wheel rightWheel;

		public float force = 1000f;
	}

	private Rigidbody rigid;

	public Wheels[] wheels;

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

	private void FixedUpdate()
	{
		for (int i = 0; i < wheels.Length; i++)
		{
			if ((bool)wheels[i].leftWheel && (bool)wheels[i].rightWheel)
			{
				float num = 1f;
				float num2 = 1f;
				WheelHit hit;
				bool groundHit = wheels[i].leftWheel.WheelCollider.GetGroundHit(out hit);
				if (groundHit)
				{
					num = (0f - wheels[i].leftWheel.transform.InverseTransformPoint(hit.point).y - wheels[i].leftWheel.WheelCollider.radius) / wheels[i].leftWheel.WheelCollider.suspensionDistance;
				}
				bool groundHit2 = wheels[i].rightWheel.WheelCollider.GetGroundHit(out hit);
				if (groundHit2)
				{
					num2 = (0f - wheels[i].rightWheel.transform.InverseTransformPoint(hit.point).y - wheels[i].rightWheel.WheelCollider.radius) / wheels[i].rightWheel.WheelCollider.suspensionDistance;
				}
				float num3 = (num - num2) * wheels[i].force;
				if (groundHit)
				{
					Rigid.AddForceAtPosition(wheels[i].leftWheel.transform.up * (0f - num3), wheels[i].leftWheel.transform.position);
				}
				if (groundHit2)
				{
					Rigid.AddForceAtPosition(wheels[i].rightWheel.transform.up * num3, wheels[i].rightWheel.transform.position);
				}
			}
		}
	}
}
