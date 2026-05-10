using UnityEngine;

namespace Gadd420
{
	public class PlayerLeaning : MonoBehaviour
	{
		public float maxLeanForward;

		public float maxLeanBack;

		public float maxLeanSide;

		public float forwardLeanSmoothTime;

		public float rightLeanSmoothTime;

		private Input_Manager inputs;

		private float forwardPos;

		private float rightPos;

		private float forwardInput;

		private float rightInput;

		private float forwardT;

		private float rightT;

		private bool firstLeanFinished;

		private float updateCount;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
