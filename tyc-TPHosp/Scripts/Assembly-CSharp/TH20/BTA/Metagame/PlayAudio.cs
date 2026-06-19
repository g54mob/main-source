using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CinematicIcon.png")]
	public class PlayAudio : MetagameCutsceneAction
	{
		public AudioClip Clip;

		public string ClipVOTag;

		public bool WaitTillFinished;

		public bool WaitTillSecondsBeforeEnd;

		public float Seconds;

		private AudioSource _source;

		public override void OnStart()
		{
			base.OnStart();
			AudioClip clip = Clip;
			if (!ClipVOTag.IsNullOrEmpty())
			{
				clip = AudioManager.VOManager.GetLocalizedVO(ClipVOTag);
			}
			_source = base.Owner.MetagameMap.CutsceneAudioPlayer.Source;
			base.Owner.MetagameMap.CutsceneAudioPlayer.PlayAudio(clip);
		}

		public override TaskStatus OnUpdate()
		{
			if (!WaitTillFinished && !WaitTillSecondsBeforeEnd)
			{
				return TaskStatus.Success;
			}
			if (_source == null || _source.clip == null)
			{
				return TaskStatus.Success;
			}
			if (WaitTillFinished && !_source.isPlaying)
			{
				return TaskStatus.Success;
			}
			if (WaitTillSecondsBeforeEnd && (_source.clip.length - _source.time <= Seconds || !_source.isPlaying))
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
