using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
	public static class AudioMixing
	{
		private const string DesignerSnapshotName = "InDesigner";

		private const string InCockpitSnapshotName = "InCockpit";

		private const string OutCockpitSnapshotName = "OutCockpit";

		private const string UnderwaterSnapshotName = "Underwater";

		private const float TransitionTime = 0.25f;

		private static readonly AudioMixerSnapshot Designer = AudioStore.AudioMixer.FindSnapshot("InDesigner");

		private static readonly AudioMixerSnapshot InCockpit = AudioStore.AudioMixer.FindSnapshot("InCockpit");

		private static readonly AudioMixerSnapshot OutCockpit = AudioStore.AudioMixer.FindSnapshot("OutCockpit");

		private static readonly AudioMixerSnapshot UnderWater = AudioStore.AudioMixer.FindSnapshot("Underwater");

		private static float _blend = 0f;

		private static bool _isInCockpit = false;

		private static bool _isInDesigner = false;

		private static bool _isUnderwater = false;

		public static float IsInCockpit
		{
			get
			{
				return _blend;
			}
			set
			{
				_isInCockpit = value > 0f;
				if (_blend != value)
				{
					UpdateAudioState(1f - Mathf.Pow(1f - value, 3f));
				}
				_blend = value;
			}
		}

		public static bool IsUnderwater
		{
			get
			{
				return _isUnderwater;
			}
			set
			{
				if (_isUnderwater != value)
				{
					_isUnderwater = value;
					UpdateAudioState();
				}
			}
		}

		public static bool IsInDesigner
		{
			get
			{
				return _isInDesigner;
			}
			set
			{
				if (_isInDesigner != value)
				{
					_isInDesigner = value;
					UpdateAudioState();
				}
			}
		}

		private static void UpdateAudioState(float blend = 1f)
		{
			if (_isInDesigner)
			{
				Designer.TransitionTo(0f);
			}
			else if (_isUnderwater)
			{
				UnderWater.TransitionTo(0.5f);
			}
			else if (_isInCockpit)
			{
				AudioStore.AudioMixer.TransitionToSnapshots(new AudioMixerSnapshot[2] { InCockpit, OutCockpit }, new float[2]
				{
					blend,
					1f - blend
				}, 0f);
			}
			else
			{
				OutCockpit.TransitionTo(0.25f);
			}
		}
	}
}
