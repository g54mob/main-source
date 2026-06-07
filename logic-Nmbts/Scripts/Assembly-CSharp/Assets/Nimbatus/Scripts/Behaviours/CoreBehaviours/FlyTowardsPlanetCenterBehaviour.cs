using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class FlyTowardsPlanetCenterBehaviour : CoreBehaviour
	{
		public float ForwardForce = 5f;

		public float RotationSpeed;

		public bool UpIsForward;

		protected override void OnInit()
		{
		}

		protected override void OnRelease()
		{
		}

		protected override void OnFixedUpdate()
		{
			Quaternion rotation = GetRotation();
			OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Lerp(OwnWorldObject.Rigidbody.rotation, rotation, Time.fixedDeltaTime * RotationSpeed));
			Vector3 vector = (UpIsForward ? OwnWorldObject.transform.up : OwnWorldObject.transform.right);
			OwnWorldObject.Rigidbody.AddForce(vector * ForwardForce, ForceMode.VelocityChange);
		}

		private Quaternion GetRotation()
		{
			int num = (UpIsForward ? (-90) : 0);
			Vector3 vector = -OwnWorldObject.transform.position;
			return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f + (float)num, Vector3.forward);
		}
	}
}
