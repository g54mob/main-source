using UnityEngine;

namespace Brewery.Face
{
	public class IdleMicroFaceSource : FaceSource
	{
		[Header("Brow Drift (asymmetric)")]
		[SerializeField]
		private float browDriftAmount;

		[SerializeField]
		private float browDriftSpeed;

		[SerializeField]
		private float browAsymmetryOffset;

		[SerializeField]
		private float browRightSpeedMult;

		[Header("Breathing")]
		[SerializeField]
		private float breathAmount;

		[SerializeField]
		private float breathSpeed;

		[SerializeField]
		private float noseFlareAmount;

		[Header("Cheek Drift")]
		[SerializeField]
		private float cheekDriftAmount;

		[SerializeField]
		private float cheekDriftSpeed;

		[Header("Lip Wander (asymmetric)")]
		[SerializeField]
		private float lipSmileDriftAmount;

		[SerializeField]
		private float lipSmileDriftSpeed;

		[SerializeField]
		private float lipFrownDriftAmount;

		[SerializeField]
		private float lipFrownDriftSpeed;

		[Header("Eye Squint Drift")]
		[SerializeField]
		private float eyeSquintDriftAmount;

		[SerializeField]
		private float eyeSquintDriftSpeed;

		[Header("Jaw Micro-Drift")]
		[SerializeField]
		private float jawSideDriftAmount;

		[SerializeField]
		private float jawSideDriftSpeed;

		private float _seed;

		private int _idxBrowInUpL;

		private int _idxBrowInUpR;

		private int _idxMouthClose;

		private int _idxCheekPuffL;

		private int _idxCheekPuffR;

		private int _idxNoseSneerL;

		private int _idxNoseSneerR;

		private int _idxSmileL;

		private int _idxSmileR;

		private int _idxFrownL;

		private int _idxFrownR;

		private int _idxSquintL;

		private int _idxSquintR;

		private int _idxJawLeft;

		private int _idxJawRight;

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
