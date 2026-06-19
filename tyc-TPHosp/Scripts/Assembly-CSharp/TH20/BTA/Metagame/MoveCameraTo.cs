#define LOG_LEVEL_VERBOSE
using System;
using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CameraIcon.png")]
	public class MoveCameraTo : MetagameCutsceneAction
	{
		public string LocationId;

		public float MaxSpeed = 350f;

		public bool WaitForFinish = true;

		private bool _finished;

		private CutsceneLogic _logic;

		public override void OnStart()
		{
			base.OnStart();
			if (WaitForFinish)
			{
				CutsceneCameraLogic cutsceneCamera = base.Owner.CutsceneCamera;
				cutsceneCamera.OnCutsceneSectionFinished = (Action<CutsceneLogic>)Delegate.Combine(cutsceneCamera.OnCutsceneSectionFinished, new Action<CutsceneLogic>(OnCutsceneSectionFinish));
			}
			MetagameCutsceneLocation cutsceneLocation = base.Owner.MetagameMap.CutsceneManager.GetCutsceneLocation(LocationId);
			if (cutsceneLocation == null)
			{
				Logging.Error(LogChannels.Metagame, "RB: Currently in cutscene, trying to move to LocationId = {0} but it's not registered with the CutsceneManager", LocationId);
				_finished = true;
				return;
			}
			_logic = base.Owner.CutsceneCamera.SetModeMoveToLocation(cutsceneLocation, MaxSpeed);
			if (_logic == null)
			{
				Logging.Error(LogChannels.Metagame, "RB: Currently in cutscene, trying to move to LocationId = {0} but the cutscene logic item was not created!", LocationId);
				_finished = true;
			}
			else
			{
				_finished = !WaitForFinish;
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

		public override void OnEnd()
		{
			if (WaitForFinish)
			{
				CutsceneCameraLogic cutsceneCamera = base.Owner.CutsceneCamera;
				cutsceneCamera.OnCutsceneSectionFinished = (Action<CutsceneLogic>)Delegate.Remove(cutsceneCamera.OnCutsceneSectionFinished, new Action<CutsceneLogic>(OnCutsceneSectionFinish));
			}
			base.OnEnd();
		}

		private void OnCutsceneSectionFinish(CutsceneLogic logic)
		{
			if (logic == _logic)
			{
				_finished = true;
			}
		}
	}
}
