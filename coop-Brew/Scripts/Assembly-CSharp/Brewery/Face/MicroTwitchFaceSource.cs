using UnityEngine;

namespace Brewery.Face
{
	public class MicroTwitchFaceSource : FaceSource
	{
		[Header("Twitch Timing")]
		[SerializeField]
		private float minInterval;

		[SerializeField]
		private float maxInterval;

		[SerializeField]
		private float minDuration;

		[SerializeField]
		private float maxDuration;

		[Range(0f, 1f)]
		[SerializeField]
		private float doubleTwitchChance;

		[SerializeField]
		private float doubleTwitchGap;

		private float _nextTwitchTime;

		private int _doubleTwitchesLeft;

		private int _twitchType;

		private float _twitchStart;

		private float _twitchDuration;

		private float _twitchPeak;

		private int _idxSmileL;

		private int _idxSmileR;

		private int _idxBrowInUpL;

		private int _idxBrowInUpR;

		private int _idxNoseSneerL;

		private int _idxNoseSneerR;

		private int _idxCheekSquintL;

		private int _idxCheekSquintR;

		private int _idxMouthPressL;

		private int _idxMouthPressR;

		private int _idxJawForward;

		private const int TwitchTypeCount = 6;

		public override string DebugName => null;

		private void OnEnable()
		{
		}

		private void InvalidateIndices()
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
