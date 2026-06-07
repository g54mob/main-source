using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Flight.Simulation.CustomWheelCollider
{
	public class SphereWheelCollider : MonoBehaviour
	{
		private float _radius;

		private Rigidbody _rigidBody;

		public float Brake { get; set; }

		public bool IsGrounded { get; set; }

		public float Rpm { get; set; }

		public float SteerAngle
		{
			get
			{
				return base.transform.localRotation.y;
			}
			set
			{
				Quaternion localRotation = base.transform.localRotation;
				localRotation.y = value;
				base.transform.localRotation = localRotation;
			}
		}

		protected virtual void FixedUpdate()
		{
			if (PauseManager.Paused || !_rigidBody)
			{
				return;
			}
			IsGrounded = Physics.Raycast(base.transform.position, -Vector3.up, _radius + 0.1f, 9441280);
			if (IsGrounded)
			{
				float magnitude = _rigidBody.linearVelocity.magnitude;
				float num = Vector3.Dot(_rigidBody.linearVelocity.normalized, base.transform.right);
				float num2 = 1f - num;
				if (Brake > 0f)
				{
					GetComponent<SphereCollider>().material.dynamicFriction = 0.65f * Brake + 0.05f;
				}
				else
				{
					GetComponent<SphereCollider>().material.dynamicFriction = 0.05f;
				}
				float num3 = magnitude * num2;
				Rpm = num3 / (_radius * MathF.PI * 2f) * 60f;
				float value = 2500f * magnitude;
				value = Mathf.Clamp(value, 0f, 25000f);
				Vector3 vector = base.transform.right * ((0f - num) * value);
				_rigidBody.AddForceAtPosition(vector * 0.01f, base.transform.position);
			}
		}

		protected virtual void Start()
		{
			if (GetComponentInParent<PartScript>().LoadContext == CraftLoadContext.Flight)
			{
				_rigidBody = base.transform.GetComponentInParent<Rigidbody>(includeInactive: true);
				_radius = GetComponent<SphereCollider>().radius;
			}
		}
	}
}
