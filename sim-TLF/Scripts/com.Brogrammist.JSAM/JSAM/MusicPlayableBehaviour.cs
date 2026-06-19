using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;

namespace JSAM
{
	public class MusicPlayableBehaviour : BaseJSAMPlayableBehaviour<MusicFileObject>
	{
		protected override BaseAudioChannelHelper<MusicFileObject> Helper
		{
			get
			{
				if (!helper)
				{
					helper = base.Helper;
					if ((bool)JSAMSettings.Settings)
					{
						AudioMixerGroup musicGroup = JSAMSettings.Settings.MusicGroup;
						helper.Init(musicGroup);
					}
				}
				return helper as MusicChannelHelper;
			}
		}

		protected override void InitAudioHelper()
		{
			if (!helperObject.TryForComponent<BaseAudioChannelHelper<MusicFileObject>>(out helper))
			{
				helper = helperObject.AddComponent<MusicChannelHelper>();
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
			BaseJSAMPlayableBehaviour<MusicFileObject>.SOURCES--;
		}

		public override void OnBehaviourPlay(Playable playable, FrameData info)
		{
			base.OnBehaviourPlay(playable, info);
			if ((bool)Helper && (bool)helperSource.clip)
			{
				UpdateTime(playable);
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
				UpdateTime(playable);
			}
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			base.ProcessFrame(playable, info, playerData);
			if (!Application.isPlaying && playable.GetGraph().IsPlaying() && helperSource.clip != Audio.Files[0])
			{
				helperSource.clip = Audio.Files[0];
				UpdateTime(playable);
			}
			Helper.AudioSource.volume = Volume;
		}
	}
}
