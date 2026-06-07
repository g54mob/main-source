using System.Collections.Generic;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class RigidbodyModifier : MonoBehaviour
	{
		private enum AddMode
		{
			AddForce = 0,
			Accelerate = 1,
			AddVelocity = 2
		}

		[SerializeField]
		private AddMode mode;

		[SerializeField]
		private Vector3 localAddVector = Vector3.zero;

		[Min(0.01f)]
		[SerializeField]
		private float dragMultiplier = 1f;

		[Min(0.01f)]
		[SerializeField]
		private float massMultiplier = 1f;

		private Vector3 worldAddVector;

		private Dictionary<Transform, Rigidbody> rigidbodies = new Dictionary<Transform, Rigidbody>();

		private void OnTriggerEnter(Collider otherCollider)
		{
			Rigidbody orRegisterValue = rigidbodies.GetOrRegisterValue(otherCollider.transform);
			if (!(orRegisterValue == null))
			{
				orRegisterValue.mass *= massMultiplier;
				orRegisterValue.linearDamping *= dragMultiplier;
			}
		}

		private void OnTriggerExit(Collider otherCollider)
		{
			rigidbodies.TryGetValue(otherCollider.transform, out var value);
			if (!(value == null))
			{
				value.mass /= massMultiplier;
				value.linearDamping /= dragMultiplier;
				rigidbodies.Remove(otherCollider.transform);
			}
		}

		private void Start()
		{
			worldAddVector = base.transform.TransformDirection(localAddVector);
		}

		private void FixedUpdate()
		{
			foreach (KeyValuePair<Transform, Rigidbody> rigidbody in rigidbodies)
			{
				switch (mode)
				{
				case AddMode.AddForce:
					rigidbody.Value.AddForce(worldAddVector);
					break;
				case AddMode.Accelerate:
					rigidbody.Value.linearVelocity += worldAddVector * Time.deltaTime;
					break;
				case AddMode.AddVelocity:
					rigidbody.Value.linearVelocity += worldAddVector;
					break;
				}
			}
		}
	}
}
