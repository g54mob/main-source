using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class RigidBodySettings
	{
		private float _angularDrag;

		private bool _automaticCenterOfMass;

		private bool _automaticInertiaTensor;

		private Vector3 _inertiaTensor;

		private float _mass;

		private float _maxAngularVelocity;

		private int _solverIterations;

		public RigidBodySettings(Rigidbody source)
		{
			_maxAngularVelocity = source.maxAngularVelocity;
			_angularDrag = source.angularDamping;
			_mass = source.mass;
			_solverIterations = source.solverIterations;
			_automaticInertiaTensor = source.automaticInertiaTensor;
			_inertiaTensor = source.inertiaTensor;
			_automaticCenterOfMass = source.automaticCenterOfMass;
		}

		public void Restore(Rigidbody target)
		{
			target.maxAngularVelocity = _maxAngularVelocity;
			target.angularDamping = _angularDrag;
			target.mass = _mass;
			target.solverIterations = _solverIterations;
			target.automaticInertiaTensor = _automaticInertiaTensor;
			target.SetInertiaTensor(_inertiaTensor);
			target.automaticCenterOfMass = _automaticCenterOfMass;
		}
	}
}
