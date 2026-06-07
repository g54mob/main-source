using System;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_Rotator : MonoBehaviour
	{
		public Vector3 RotationSpeed = Vector3.zero;

		private Rigidbody rig;

		private void Start()
		{
			rig = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			if (!(rig != null))
			{
				base.transform.Rotate(RotationSpeed * Time.deltaTime);
			}
		}

		private void FixedUpdate()
		{
			if (!(rig == null))
			{
				if (rig.isKinematic)
				{
					rig.rotation *= Quaternion.Euler(RotationSpeed * (MathF.PI / 180f));
				}
				else
				{
					rig.angularVelocity = RotationSpeed * (MathF.PI / 180f);
				}
			}
		}
	}
}
