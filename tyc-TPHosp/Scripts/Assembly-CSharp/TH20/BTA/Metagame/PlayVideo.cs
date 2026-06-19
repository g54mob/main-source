using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.Video;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CinematicIcon.png")]
	public class PlayVideo : MetagameCutsceneAction
	{
		public VideoClip Clip;

		public bool WaitTillFinished;

		public bool FadeIn;

		public bool FadeOut;

		private bool _finished;

		public override void OnStart()
		{
			base.OnStart();
			FullScreenVideoMenu fullScreenVideoMenu = base.Owner.Metagame.App.FullScreenVideoMenu;
			FullScreenVideoMenu.VideoContext next = new FullScreenVideoMenu.VideoContext
			{
				Clip = Clip,
				Volume = 0.3f,
				FadeIn = FadeIn,
				FadeOut = FadeOut
			};
			_finished = !WaitTillFinished;
			if (WaitTillFinished)
			{
				fullScreenVideoMenu.PlayVideo(next, OnVideoPlayCompleted, OnVideoPlayError);
			}
			else
			{
				fullScreenVideoMenu.PlayVideo(next, null, null);
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (_finished)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		private void OnVideoPlayError()
		{
			_finished = true;
		}

		private void OnVideoPlayCompleted()
		{
			_finished = true;
		}
	}
}
