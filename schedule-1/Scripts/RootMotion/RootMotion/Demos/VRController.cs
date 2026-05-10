using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class VRController : MonoBehaviour
	{
		[Serializable]
		public enum InputMode
		{
			Input = 0,
			WASDOnly = 1
		}

		public InputMode inputMode;

		public VRIK ik;

		public Transform centerEyeAnchor;

		public float walkSpeed;

		public float runSpeed;

		public float walkForwardSpeedMlp;

		public float runForwardSpeedMlp;

		private Vector3 smoothInput;

		private Vector3 smoothInputV;

		private void Update()
		{
		}

		private Vector3 GetInput()
		{
			return default(Vector3);
		}
	}
}
