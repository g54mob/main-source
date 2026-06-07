using AK.Wwise;
using UnityEngine;

namespace Gh
{
	public class SimpleSoundPlayer : BaseSoundPlayer
	{
		private Vector3 _lastPosition;

		[Header("Large/Multi Position Mode")]
		public bool useLargeMode;

		public AkAmbientLargeModePositioner[] LargeModePositions;

		public (Transform positioner, SoundOcclusionChecker occlusionChecker)[] LargeModePositionsWithOcclusionCheckers;

		private bool _largeModeInitialized;

		public SoundOcclusionChecker SoundOcclusionChecker { get; set; }

		[field: Tooltip("Auto set to false in the UI as it is never required")]
		[field: SerializeField]
		public bool IsSoundOcclusionCheckerRequired { get; set; }

		public override GameObject SoundTarget => null;

		public bool IsGlobalMode => false;

		protected override void Awake()
		{
		}

		protected override void UpdateSoundTarget()
		{
		}

		protected override void UpdatePlayState()
		{
		}

		protected override void PlaySound(AK.Wwise.Event soundEvent)
		{
		}

		protected override void StopSound(AK.Wwise.Event soundEvent)
		{
		}

		protected void UpdatePosition()
		{
		}

		private void Update()
		{
		}

		protected virtual void OnEnable()
		{
		}

		private void InitLargeMode()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected override void UpdateLargeMode()
		{
		}
	}
}
