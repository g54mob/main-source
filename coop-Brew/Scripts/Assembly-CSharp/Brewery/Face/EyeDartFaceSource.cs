using UnityEngine;

namespace Brewery.Face
{
	public class EyeDartFaceSource : FaceSource
	{
		[Header("Saccade Timing")]
		[SerializeField]
		private float minHoldTime;

		[SerializeField]
		private float maxHoldTime;

		[SerializeField]
		private float saccadeDuration;

		[SerializeField]
		private float settleDuration;

		[Header("Saccade Range")]
		[SerializeField]
		private float horizontalRange;

		[SerializeField]
		private float verticalRange;

		[Tooltip("Chance (0..1) of a bigger 'attention' glance per saccade.")]
		[SerializeField]
		private float bigGlanceChance;

		[SerializeField]
		private float bigGlanceMultiplier;

		private float _currentH;

		private float _currentV;

		private float _targetH;

		private float _targetV;

		private float _previousH;

		private float _previousV;

		private float _nextSaccadeTime;

		private float _saccadeStartTime;

		private bool _inSaccade;

		private int _idxLookInL;

		private int _idxLookInR;

		private int _idxLookOutL;

		private int _idxLookOutR;

		private int _idxLookUpL;

		private int _idxLookUpR;

		private int _idxLookDownL;

		private int _idxLookDownR;

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
