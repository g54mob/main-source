using System;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;

namespace Gh
{
	public abstract class BaseSoundPlayer : MonoBehaviour
	{
		protected bool _isWorldMapSound;

		public AK.Wwise.Event EventData;

		private uint _currentPlayingID;

		protected bool _isSoundTargetDirty;

		[Tooltip("Auto set to false if on the worldmap as we dont respect the timescale")]
		public bool pauseWithTimeScale;

		public AkMultiPositionType multiPositionType;

		protected bool _isPositionDirty;

		protected bool _isOcclusionDirty;

		private AkGameObj _soundTargetAkGameObj;

		public virtual GameObject SoundTarget { get; set; }

		protected virtual void Awake()
		{
		}

		public virtual AK.Wwise.Event GetCurrentEvent()
		{
			return null;
		}

		public void SetCurrentEvent(AK.Wwise.Event currentEvent)
		{
		}

		protected virtual void UpdateSoundTarget()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected virtual bool ShouldSoundPlay()
		{
			return false;
		}

		protected virtual void UpdatePlayState()
		{
		}

		private void UpdatePauseState()
		{
		}

		protected void PlaySound()
		{
		}

		protected virtual void PlaySound(AK.Wwise.Event soundEvent)
		{
		}

		private void OnTimeSettingChanged(object sender, EventArgs e)
		{
		}

		public bool IsPlaying()
		{
			return false;
		}

		protected void StopSound()
		{
		}

		protected virtual void StopSound(AK.Wwise.Event soundEvent)
		{
		}

		protected void PauseSound()
		{
		}

		protected void PauseSound(uint playingId)
		{
		}

		protected void ResumeSound()
		{
		}

		protected void ResumeSound(uint playingId)
		{
		}

		public void MarkPositionDirty(object sender, EventArgs e)
		{
		}

		public void MarkOcclusionDirty(object sender, EventArgs e)
		{
		}

		public void MarkPositionDirty()
		{
		}

		protected abstract void UpdateLargeMode();

		protected void UpdateObstructionAndOcclusion(List<SoundOcclusionChecker> occlusionCheckers)
		{
		}

		private void EnsureSoundTargetAkGameObj()
		{
		}

		protected AkObstructionOcclusionValuesArray BuildObstructionOcclusionArray(List<SoundOcclusionChecker> occlusionCheckers)
		{
			return null;
		}

		protected void UpdatePositions(List<Transform> positions)
		{
		}

		private AkPositionArray BuildAkPositionArray(List<Transform> positions)
		{
			return null;
		}
	}
}
