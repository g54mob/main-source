using UnityEngine;

namespace Brewery.Face
{
	public class BlinkFaceSource : FaceSource
	{
		[Header("Blink Timing")]
		[SerializeField]
		private float minInterval;

		[SerializeField]
		private float maxInterval;

		[SerializeField]
		private float blinkDuration;

		[Range(0f, 1f)]
		[SerializeField]
		private float doubleBlinkChance;

		[SerializeField]
		private float doubleBlinkGap;

		private float _nextBlinkTime;

		private float _blinkPhase;

		private int _doubleBlinksLeft;

		private int _idxUpL;

		private int _idxUpR;

		private int _idxLoL;

		private int _idxLoR;

		public override string DebugName => null;

		private void OnEnable()
		{
		}

		protected override void OnDriverCacheRefreshed()
		{
		}

		protected override float ComputeTargetWeight(float dt)
		{
			return 0f;
		}

		protected override void Sample(FaceFrame frame, float dt, float sourceFade)
		{
		}
	}
}
