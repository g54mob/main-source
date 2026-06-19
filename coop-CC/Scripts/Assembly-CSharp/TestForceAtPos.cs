using Aggro.Core;
using UnityEngine;

public class TestForceAtPos : MonoBehaviour
{
	public Rigidbody rb;

	public Transform pos;

	public float force;

	private bool _checkForce;

	private void Start()
	{
		Physics.simulationMode = SimulationMode.Script;
	}

	private void DoTest()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.drag = 0f;
		rb.angularDrag = 0f;
		rb.AddForceAtPosition(force * pos.forward, pos.position, ForceMode.VelocityChange);
		Debug.Log($"Accum Force: {rb.GetAccumulatedForce()} Accum Torque: {rb.GetAccumulatedTorque()}");
		Vector3 forceVelocity = PhysicsUtil.GetForceVelocity(force * pos.forward, rb.mass, ForceMode.VelocityChange);
		Vector3 forceTorque = PhysicsUtil.GetForceTorque(force * pos.forward, pos.position, rb.worldCenterOfMass, rb.rotation, rb.mass, rb.inertiaTensor, ForceMode.VelocityChange);
		Physics.Simulate(1f / 60f);
		Debug.Log($"Velocity: {rb.velocity} Ang Velocity: {rb.angularVelocity} | MyV: {forceVelocity} MyAng: {forceTorque}");
	}

	public Vector3 ForceToTorque(Vector3 force, Vector3 position, ForceMode forceMode = ForceMode.Force)
	{
		Vector3 torque = Vector3.Cross(position - rb.worldCenterOfMass, force);
		ToDeltaTorque(ref torque, forceMode);
		return torque;
	}

	private void ToDeltaTorque(ref Vector3 torque, ForceMode forceMode)
	{
		bool num = forceMode == ForceMode.Force || forceMode == ForceMode.Acceleration;
		bool useMass = forceMode == ForceMode.Force || forceMode == ForceMode.Impulse;
		if (num)
		{
			torque *= 1f / 60f;
		}
		ApplyInertiaTensor(ref torque, useMass);
	}

	private void ApplyInertiaTensor(ref Vector3 v, bool useMass)
	{
		Vector3 v2 = (useMass ? rb.inertiaTensor : (rb.inertiaTensor / rb.mass));
		v = rb.rotation * Div(Quaternion.Inverse(rb.rotation) * v, v2);
	}

	private static Vector3 Div(Vector3 v, Vector3 v2)
	{
		return new Vector3(v.x / v2.x, v.y / v2.y, v.z / v2.z);
	}
}
