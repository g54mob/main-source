using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class GroundTarget : Target
	{
		private bool _dead;

		private Rigidbody _rigidBody;

		private float _signatureInfrared = 100f;

		private float _signatureRadar = 50f;

		private float _signatureRadiation = 250f;

		private Transform _transform;

		public override bool IsDead
		{
			get
			{
				if (!_dead)
				{
					return _transform == null;
				}
				return true;
			}
		}

		public override Vector3 Position => _transform.position;

		public override TargetType TargetType => TargetType.Ground;

		public override Vector3 Velocity
		{
			get
			{
				if (!(_rigidBody != null))
				{
					return Vector3.zero;
				}
				return _rigidBody.linearVelocity;
			}
		}

		public GroundTarget(string name, Transform transform, ushort teamId)
			: base(teamId)
		{
			base.Name = name;
			_transform = transform;
			_rigidBody = transform.GetComponentInParent<Rigidbody>();
		}

		public GroundTarget(string name, Transform transform, float maxVisibleRange, ushort teamId)
			: base(teamId)
		{
			base.Name = name;
			base.MaxVisibleRange = maxVisibleRange;
			_transform = transform;
			_rigidBody = transform.GetComponentInParent<Rigidbody>();
		}

		public override float GetSignature(SignatureType signatureType)
		{
			return signatureType switch
			{
				SignatureType.Infrared => _signatureInfrared, 
				SignatureType.Radar => _signatureRadar, 
				SignatureType.Radiation => _signatureRadiation, 
				_ => throw new ArgumentOutOfRangeException("signatureType"), 
			};
		}

		public void MarkAsDead()
		{
			_dead = true;
		}

		public void SetSeekerSignatures(float signatureRadiation = 0f, float signatureInfrared = 0f, float signatureRadar = 0f)
		{
			_signatureRadiation = signatureRadiation;
			_signatureInfrared = signatureInfrared;
			_signatureRadar = signatureRadar;
		}
	}
}
