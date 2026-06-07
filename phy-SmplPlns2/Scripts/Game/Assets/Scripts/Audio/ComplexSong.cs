using System;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	[CreateAssetMenu(fileName = "New Song", menuName = "SimplePlanes 2/Complex Song")]
	public class ComplexSong : Song
	{
		[Serializable]
		public struct Layer
		{
			public AudioClip Clip;

			public SongTags Tags;
		}

		private SongTags _allTags;

		[SerializeField]
		private Layer[] _layers;

		public Layer[] Layers
		{
			get
			{
				return _layers;
			}
			internal set
			{
				_layers = value;
			}
		}

		public override SongTags SupportedTags => _allTags;

		public override AudioDataLoadState GetLoadState()
		{
			AudioDataLoadState audioDataLoadState = base.GetLoadState();
			Layer[] layers = _layers;
			for (int i = 0; i < layers.Length; i++)
			{
				Layer layer = layers[i];
				audioDataLoadState = Worst(audioDataLoadState, layer.Clip.loadState);
			}
			return audioDataLoadState;
			static AudioDataLoadState Worst(AudioDataLoadState a, AudioDataLoadState b)
			{
				if (a == AudioDataLoadState.Failed || b == AudioDataLoadState.Failed)
				{
					return AudioDataLoadState.Failed;
				}
				if (a == AudioDataLoadState.Unloaded || b == AudioDataLoadState.Unloaded)
				{
					return AudioDataLoadState.Unloaded;
				}
				if (a == AudioDataLoadState.Loading || b == AudioDataLoadState.Loading)
				{
					return AudioDataLoadState.Loading;
				}
				if (a == AudioDataLoadState.Unloaded || b == AudioDataLoadState.Unloaded)
				{
					return AudioDataLoadState.Unloaded;
				}
				return a;
			}
		}

		public override void LoadAudioData()
		{
			base.LoadAudioData();
			Layer[] layers = _layers;
			for (int i = 0; i < layers.Length; i++)
			{
				layers[i].Clip.LoadAudioData();
			}
		}

		public override void UnloadAudioData()
		{
			base.UnloadAudioData();
			Layer[] layers = _layers;
			for (int i = 0; i < layers.Length; i++)
			{
				layers[i].Clip.UnloadAudioData();
			}
		}

		protected void Awake()
		{
			SongTags songTags = base.Tags;
			Layer[] layers = Layers;
			for (int i = 0; i < layers.Length; i++)
			{
				Layer layer = layers[i];
				songTags |= layer.Tags;
			}
			_allTags = songTags;
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			if (base.MainClip == null || Layers == null || Layers.Length == 0)
			{
				return;
			}
			int samples = base.MainClip.samples;
			int frequency = base.MainClip.frequency;
			for (int i = 0; i < Layers.Length; i++)
			{
				Layer layer = Layers[i];
				if (!(layer.Clip == null))
				{
					if (layer.Clip.preloadAudioData)
					{
						Debug.LogWarning($"Song layer {i} is set to preload audio data, turn this off for songs to let the music player load/unload the audio data at will!", layer.Clip);
					}
					if (!layer.Clip.loadInBackground)
					{
						Debug.LogWarning($"Song layer {i} is not set to load in background! This may cause lags when starting the song.", layer.Clip);
					}
					if (layer.Clip.samples != samples)
					{
						Debug.LogError($"song layer {i} has a different sample count to the main layer", this);
					}
					if (layer.Clip.frequency != frequency)
					{
						Debug.LogError($"song layer {i} has a different frequency to the main layer", this);
					}
				}
			}
		}
	}
}
