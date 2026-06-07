using Jundroo.Common.Physics;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class WindmillScript : MonoBehaviour
	{
		public Rigidbody Blades;

		public Rigidbody Hub;

		public Joint Joint;

		public float PercentToActivate = 0.33f;

		private Collider[] _colliders;

		protected virtual void Start()
		{
			_colliders = GetComponentsInChildren<Collider>();
			for (int i = 0; i < _colliders.Length; i++)
			{
				_colliders[i].gameObject.AddComponent<CollisionNotifier>().CollisionEnter.AddListener(CollisionEnter);
			}
			float num = Random.Range(0, 100);
			Vector3 localEulerAngles = Blades.transform.localEulerAngles;
			Blades.transform.localEulerAngles = new Vector3(num, localEulerAngles.y, localEulerAngles.z);
			HingeJoint componentInChildren = GetComponentInChildren<HingeJoint>();
			if (num > PercentToActivate)
			{
				componentInChildren.useMotor = false;
				Blades.Sleep();
				Hub.Sleep();
			}
			else
			{
				bool flag = Random.Range(0, 100) > 50;
				JointMotor motor = componentInChildren.motor;
				motor.targetVelocity *= 1f + 0.5f * (float)((!flag) ? 1 : (-1));
				componentInChildren.motor = motor;
			}
		}

		private void CollisionEnter(Collision collision)
		{
			if (Joint != null)
			{
				Object.Destroy(Joint);
			}
			for (int i = 0; i < _colliders.Length; i++)
			{
				Collider collider = _colliders[i];
				Rigidbody component = collider.GetComponent<Rigidbody>();
				collider.gameObject.isStatic = false;
				if (component == null)
				{
					Rigidbody rigidbody = collider.gameObject.AddComponent<Rigidbody>();
					rigidbody.mass = 10f;
					rigidbody.angularDamping = 1f;
					rigidbody.linearDamping = 0.15f;
					rigidbody.sleepThreshold = 0.05f;
					Transform transform = collider.transform.Find("CenterOfMass");
					if (transform != null)
					{
						rigidbody.centerOfMass = transform.localPosition;
					}
				}
				else
				{
					component.constraints = RigidbodyConstraints.None;
				}
			}
		}
	}
}
