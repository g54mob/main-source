using UnityEngine;

namespace Gadd420
{
	public class Input_Manager : MonoBehaviour
	{
		public bool combineLeanAndSteering;

		public bool combineBrakeInputs;

		public float inputSmoothingTime;

		private float vInputTime;

		private float hzInputTime;

		protected float hzInput;

		protected float vInput;

		protected float leanInput;

		protected float wheelieInput;

		protected float frontBreakInput;

		public float HzInput => 0f;

		public float VInput => 0f;

		public float LeanInput => 0f;

		public float WheelieInput => 0f;

		public float FrontBreakInput => 0f;

		private void Start()
		{
		}

		private void Update()
		{
		}

		protected virtual void VerticalInput()
		{
		}

		protected virtual void HZInput()
		{
		}

		protected virtual void GetLeanValue()
		{
		}

		protected virtual void GetLeanBackValue()
		{
		}

		protected virtual void FrontBreak()
		{
		}
	}
}
