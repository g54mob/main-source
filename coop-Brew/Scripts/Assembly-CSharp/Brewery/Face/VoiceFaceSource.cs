using Brewery.Voice;
using UnityEngine;

namespace Brewery.Face
{
	public class VoiceFaceSource : FaceSource
	{
		[Header("Voice Source")]
		[SerializeField]
		private VivoxPlayerTracker tracker;

		[Tooltip("If true, the LOCAL player drives mouth animation from the system microphone amplitude — works regardless of Vivox connection, channel, or mute. Remote players still use Vivox networked state.")]
		[SerializeField]
		private bool useLocalMicForOwner;

		[Tooltip("Mic amplitude (0..1) below this is treated as silence — prevents idle hiss from flapping the mouth.")]
		[SerializeField]
		private float micSilenceThreshold;

		[Header("Jaw Flap")]
		[SerializeField]
		private float jawFlapAmount;

		[SerializeField]
		private float syllableFreq;

		[SerializeField]
		private float chatterFreq;

		[SerializeField]
		private float chatterMix;

		[SerializeField]
		private float openBias;

		[SerializeField]
		private float shaping;

		[Header("Mouth Shape Variety")]
		[SerializeField]
		private float mouthFunnelAmount;

		[SerializeField]
		private float mouthStretchAmount;

		[SerializeField]
		private float mouthPuckerAmount;

		[SerializeField]
		private float mouthShrugAmount;

		[SerializeField]
		private float mouthSmileWhileTalking;

		[SerializeField]
		private float lipShapeChangeFreq;

		[Header("Brow / Eye / Cheek Emphasis (Disney-style)")]
		[SerializeField]
		private float browRaiseOnEmphasis;

		[SerializeField]
		private float browFrownBetween;

		[SerializeField]
		private float browEmphasisFreq;

		[SerializeField]
		private float eyeWideOnEmphasis;

		[SerializeField]
		private float eyeSquintBetween;

		[SerializeField]
		private float cheekSquintWhileTalking;

		[SerializeField]
		private float noseFlareWhileTalking;

		[Header("Positive Warmth (Disney charm)")]
		[Tooltip("Occasional warm smile flash while talking.")]
		[SerializeField]
		private float warmSmileAmount;

		[Tooltip("Cheek puff on warm moments (cheeky/cute).")]
		[SerializeField]
		private float warmCheekPuff;

		private float _seed;

		private float _nextPuckerCheck;

		private float _puckerUntil;

		private float _nextBrowPunch;

		private float _browPunchUntil;

		private float _browPunchPeak;

		private float _nextWarmFlash;

		private float _warmFlashUntil;

		private float _warmFlashPeak;

		private float _eyeLookH;

		private float _eyeLookV;

		private float _eyeLookTargetH;

		private float _eyeLookTargetV;

		private float _nextEyeShiftTime;

		private int _idxJawOpen;

		private int _idxMouthFunnel;

		private int _idxMouthStretchL;

		private int _idxMouthStretchR;

		private int _idxMouthPucker;

		private int _idxMouthShrugUpper;

		private int _idxMouthShrugLower;

		private int _idxSmileL;

		private int _idxSmileR;

		private int _idxBrowInUpL;

		private int _idxBrowInUpR;

		private int _idxBrowFrownL;

		private int _idxBrowFrownR;

		private int _idxCheekSquintL;

		private int _idxCheekSquintR;

		private int _idxCheekPuffL;

		private int _idxCheekPuffR;

		private int _idxNoseSneerL;

		private int _idxNoseSneerR;

		private int _idxMouthUpperUpL;

		private int _idxMouthUpperUpR;

		private int _idxEyeWideUpL;

		private int _idxEyeWideUpR;

		private int _idxEyeSquintL;

		private int _idxEyeSquintR;

		private int _idxBrowRaiseL;

		private int _idxBrowRaiseR;

		private int _idxBrowOuterUpL;

		private int _idxBrowOuterUpR;

		private int _idxLookUpL;

		private int _idxLookUpR;

		private int _idxLookDownL;

		private int _idxLookDownR;

		private int _idxLookInL;

		private int _idxLookInR;

		private int _idxLookOutL;

		private int _idxLookOutR;

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
