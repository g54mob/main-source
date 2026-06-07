using System;
using UnityEngine;

namespace Logic.Audio
{
	public class AmbientAudioEmitter
	{
		private int[] _trackImpacts;

		private Vector3 _worldPosition;

		public Vector3 WorldPosition => _worldPosition;

		public int[] TrackImpacts => _trackImpacts;

		public bool AllWeightsAreZero
		{
			get
			{
				int num = 0;
				int[] trackImpacts = _trackImpacts;
				foreach (int num2 in trackImpacts)
				{
					num += num2;
				}
				return num == 0;
			}
		}

		public AmbientAudioEmitter(Vector3 worldPosition)
		{
			_worldPosition = worldPosition;
		}

		public float GetVolumeForTrack(AmbientTrackType trackType)
		{
			if (_trackImpacts == null)
			{
				return 0f;
			}
			return (float)Mathf.Clamp(_trackImpacts[(int)trackType], 0, 10) / 10f;
		}

		public void AddWeight(AmbientTrackType trackType)
		{
			if (_trackImpacts == null)
			{
				int length = Enum.GetValues(typeof(AmbientTrackType)).Length;
				_trackImpacts = new int[length];
			}
			_trackImpacts[(int)trackType]++;
		}

		public void RemoveWeight(AmbientTrackType trackType)
		{
			if (_trackImpacts != null)
			{
				_trackImpacts[(int)trackType] = Mathf.Max(_trackImpacts[(int)trackType] - 1, 0);
			}
		}
	}
}
