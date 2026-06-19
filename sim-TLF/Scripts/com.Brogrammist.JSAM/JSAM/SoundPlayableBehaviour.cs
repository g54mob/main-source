using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;

namespace JSAM
{
	public class SoundPlayableBehaviour : BaseJSAMPlayableBehaviour<SoundFileObject>
	{
		protected override BaseAudioChannelHelper<SoundFileObject> Helper
		{
			get
			{
				if (!helper)
				{
					helper = base.Helper;
					if ((bool)JSAMSettings.Settings)
					{
						AudioMixerGroup soundGroup = JSAMSettings.Settings.SoundGroup;
						helper.Init(soundGroup);
					}
				}
				return helper as SoundChannelHelper;
			}
		}

		protected override void InitAudioHelper()
		{
			if (!helperObject.TryForComponent<BaseAudioChannelHelper<SoundFileObject>>(out helper))
			{
				helper = helperObject.AddComponent<SoundChannelHelper>();
			}
		}

		public override void OnGraphStart(Playable playable)
		{
			base.OnGraphStart(playable);
		}

		public override void OnGraphStop(Playable playable)
		{
			base.OnGraphStop(playable);
		}

		public override void OnPlayableDestroy(Playable playable)
		{
			base.OnPlayableDestroy(playable);
			Object.DestroyImmediate(helperObject);
			BaseJSAMPlayableBehaviour<SoundFileObject>.SOURCES--;
		}

		public override void OnBehaviourPlay(Playable playable, FrameData info)
		{
			base.OnBehaviourPlay(playable, info);
			if ((bool)Helper && (bool)helperSource.clip)
			{
				helperSource.time = Mathf.Min((float)playable.GetTime(), helperSource.clip.length - 1E-06f);
			}
		}

		public override void OnBehaviourPause(Playable playable, FrameData info)
		{
			base.OnBehaviourPause(playable, info);
			switch (info.effectivePlayState)
			{
			case PlayState.Paused:
				Helper.AudioSource.Pause();
				break;
			case PlayState.Playing:
				Helper.AudioSource.Pause();
				break;
			case PlayState.Delayed:
				break;
			}
		}

		public override void OnPlayableCreate(Playable playable)
		{
			base.OnPlayableCreate(playable);
		}

		public override void PrepareData(Playable playable, FrameData info)
		{
			base.PrepareData(playable, info);
			_ = Application.isPlaying;
		}

		public override void PrepareFrame(Playable playable, FrameData info)
		{
			base.PrepareFrame(playable, info);
			if ((bool)Helper && !playable.GetGraph().IsPlaying() && (bool)helperSource.clip)
			{
				if (helperSource.isPlaying)
				{
					helperSource.Pause();
				}
				helperSource.time = Mathf.Min((float)playable.GetTime(), helperSource.clip.length - 1E-06f);
			}
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			base.ProcessFrame(playable, info, playerData);
			if (!Application.isPlaying && playable.GetGraph().IsPlaying() && helperSource.clip != Audio.Files[0])
			{
				helperSource.clip = Audio.Files[0];
				helperSource.time = Mathf.Min((float)playable.GetTime(), helperSource.clip.length - 1E-06f);
			}
			Helper.AudioSource.volume = Volume;
		}
	}
}
