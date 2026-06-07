using System;
using GAudio.Attributes;
using UnityEngine;

namespace GAudio
{
	public class LFOFilterParam : MonoBehaviour, GATPlayer.IPlayerWillMixHandler
	{
		public GATPlayer player;

		public bool isTrackFilter = true;

		[BindedIntProperty("TrackNb", typeof(LFOFilterParam), "isTrackFilter")]
		[SerializeField]
		private int _trackNb;

		public int filterSlot;

		public string paramName;

		public float min;

		public float max;

		[BindedFloatProperty("Frequency", typeof(LFOFilterParam), null)]
		[SerializeField]
		private float _frequency = 1f;

		private GATFilterParam _filterParam;

		private float _phase;

		private float _phaseIncrement;

		public int TrackNb
		{
			get
			{
				return _trackNb;
			}
			set
			{
				_trackNb = value;
			}
		}

		public float Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_phaseIncrement = (float)Math.PI * 2f * value / (float)GATInfo.OutputSampleRate;
				_frequency = value;
			}
		}

		private void OnEnable()
		{
			Frequency = _frequency;
			if (player == null)
			{
				player = GATManager.DefaultPlayer;
			}
			if (isTrackFilter)
			{
				_filterParam = new GATFilterParam(_trackNb, filterSlot, paramName, player);
			}
			else
			{
				_filterParam = new GATFilterParam(filterSlot, paramName, player);
			}
			player.OnPlayerWillMix_Subscribe(this);
		}

		private void OnDisable()
		{
			player.OnPlayerWillMix_Unsubscribe(this);
		}

		public void OnPlayerWillMix()
		{
			float t = (Mathf.Sin(_phase) + 1f) / 2f;
			float paramValue = Mathf.Lerp(min, max, t);
			_filterParam.ParamValue = paramValue;
			_phase += _phaseIncrement * (float)GATInfo.AudioBufferSizePerChannel;
			if (_phase > (float)Math.PI * 2f)
			{
				_phase -= (float)Math.PI * 2f;
			}
		}
	}
}
