using UnityEngine;

namespace Restory.Data.Disassemble.StateMachine
{
	[CreateAssetMenu(menuName = "Restory/Disassemble/StateMachine/CheckDeviceDisassembleState", fileName = "CheckDeviceConfig")]
	public class CheckDeviceConfig : ScriptableObject
	{
		private const string PUNCH_GROUP = "Punch";

		private const string SHAKE_GROUP = "Shake";

		[SerializeField]
		[Min(0f)]
		private float punchScale = 0.1f;

		[SerializeField]
		[Min(0f)]
		private float punchDuration = 1f;

		[SerializeField]
		[Min(0f)]
		private int punchVibrato = 2;

		[SerializeField]
		[Min(0f)]
		private float punchElasticity = 0.5f;

		[SerializeField]
		[Min(0f)]
		private float shakeDuration = 0.5f;

		[SerializeField]
		[Min(0f)]
		private Vector3 shakeStrength = new Vector3(0f, 10f, 0f);

		[SerializeField]
		[Min(0f)]
		private int shakeVibrato = 15;

		[SerializeField]
		[Min(0f)]
		private float shakeRandomness;

		[SerializeField]
		private bool shakeFadeOut = true;

		[SerializeField]
		[Min(0f)]
		private float delayUI = 2f;

		[SerializeField]
		[Min(0f)]
		private float rotationDuration = 1f;

		public float PunchScale => punchScale;

		public float PunchDuration => punchDuration;

		public int PunchVibrato => punchVibrato;

		public float PunchElasticity => punchElasticity;

		public float ShakeDuration => shakeDuration;

		public Vector3 ShakeStrength => shakeStrength;

		public int ShakeVibrato => shakeVibrato;

		public float ShakeRandomness => shakeRandomness;

		public bool ShakeFadeOut => shakeFadeOut;

		public float DelayUI => delayUI;

		public float RotationDuration => rotationDuration;
	}
}
