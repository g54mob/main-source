#define LOG_LEVEL_VERBOSE
using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CinematicIcon.png")]
	public class RunDirector : MetagameCutsceneAction
	{
		public string DirectorId;

		private MetagameCutscenePlayableDirector _director;

		public override void OnStart()
		{
			base.OnStart();
			_director = base.Owner.MetagameMap.CutsceneManager.GetCutscenePlayableDirector(DirectorId);
			if (_director == null)
			{
				Logging.Error(LogChannels.Metagame, "RB: Currently in cutscene, trying to run a playable director with Id = {0}, but it isn't registered with the CutsceneManager", DirectorId);
			}
			else
			{
				_director.Play();
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (_director == null || _director.IsFinished())
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		public override void OnEnd()
		{
			if (_director != null)
			{
				_director.Stop();
			}
		}
	}
}
