using UnityEngine;

namespace Assets.Scripts.DebugScripts
{
	public class RigidBodyDebugScript : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _angularVelocity = Vector3.zero;

		[SerializeField]
		private float _angularVelocityMagnitude;

		[SerializeField]
		private Vector3 _com = Vector3.zero;

		[SerializeField]
		private Vector3 _inertiaTensor = Vector3.zero;

		[SerializeField]
		private float _inertiaTensorMagnitude;

		[SerializeField]
		private float _inertiaTensorMagnitudeOverride;

		[SerializeField]
		private bool _inertiaTensorMagnitudeSet;

		[SerializeField]
		private int _solverIterations;

		[SerializeField]
		private int _solverVelocityIterations;

		[SerializeField]
		private Vector3 _velocity = Vector3.zero;

		[SerializeField]
		private float _velocityMagnitude;

		public override string ToString()
		{
			return string.Format("Velocity: {0} ({1} m/s). Angular Velocity: {2} ({3} rad/s). CoM: {4}. Inertia Tensor: {5} ({6} length}, Solver Iterations: {7}, Solver Velocity Iterations: {8}", _velocity, _velocityMagnitude, _angularVelocity, _angularVelocityMagnitude, _com, _inertiaTensor, _inertiaTensorMagnitude, _solverIterations, _solverVelocityIterations);
		}

		protected virtual void Awake()
		{
			UpdateInformation();
		}

		protected virtual void Update()
		{
			UpdateInformation();
			if (_inertiaTensorMagnitudeSet)
			{
				Rigidbody componentInParent = GetComponentInParent<Rigidbody>();
				componentInParent.inertiaTensor = componentInParent.inertiaTensor.normalized * _inertiaTensorMagnitudeOverride;
				_inertiaTensorMagnitudeSet = false;
				Debug.Log("Override Inertia Tensor");
			}
		}

		private void UpdateInformation()
		{
			Rigidbody componentInParent = GetComponentInParent<Rigidbody>();
			_velocity = componentInParent.velocity;
			_velocityMagnitude = componentInParent.velocity.magnitude;
			_angularVelocity = componentInParent.angularVelocity;
			_angularVelocityMagnitude = componentInParent.angularVelocity.magnitude;
			_com = componentInParent.centerOfMass;
			_inertiaTensor = componentInParent.inertiaTensor;
			_inertiaTensorMagnitude = componentInParent.inertiaTensor.magnitude;
			_solverIterations = componentInParent.solverIterations;
			_solverVelocityIterations = componentInParent.solverVelocityIterations;
		}
	}
}
