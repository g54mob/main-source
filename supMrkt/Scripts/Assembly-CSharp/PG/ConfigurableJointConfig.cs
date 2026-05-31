using System;
using UnityEngine;

namespace PG
{
	[Serializable]
	public struct ConfigurableJointConfig
	{
		public Vector3 Axis;

		public ConfigurableJointMotion XMotion;

		public ConfigurableJointMotion YMotion;

		public ConfigurableJointMotion ZMotion;

		public ConfigurableJointMotion AngularXMotion;

		public ConfigurableJointMotion AngularYMotion;

		public ConfigurableJointMotion AngularZMotion;

		public float HighAngularXLimit;

		public float LowAngularXLimit;

		public float AngularYLimit;

		public float AngularZLimit;

		public float BrakeForce;

		public float BreakTorque;
	}
}
