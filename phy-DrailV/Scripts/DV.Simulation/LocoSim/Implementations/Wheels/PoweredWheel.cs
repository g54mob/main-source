using System;
using UnityEngine;

namespace LocoSim.Implementations.Wheels
{
	public class PoweredWheel : MonoBehaviour
	{
		public enum State : byte
		{
			IS_POWERED = 0,
			CUT_OUT = 1,
			BROKEN = 2
		}

		public Transform wheelTransform;

		public Vector3 localRotationAxis = Vector3.right;

		[NonSerialized]
		public byte index;

		[NonSerialized]
		public State state;

		public bool IsBroken => state == State.BROKEN;

		public bool IsPowered => state == State.IS_POWERED;
	}
}
