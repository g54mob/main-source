#define LOG_LEVEL_VERBOSE
using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CinematicIcon.png")]
	public class RaiseHospital : MetagameCutsceneAction
	{
		public string AnimatableId;

		public bool Unlock = true;

		public bool Immediately;

		private MetagameHospitalVisual _hospitalVisual;

		public override void OnStart()
		{
			base.OnStart();
			_hospitalVisual = base.Owner.MetagameMap.CutsceneManager.GetCutsceneAnimatable(AnimatableId);
			if (_hospitalVisual == null)
			{
				Logging.Error(LogChannels.Metagame, "RB: Currently in cutscene, trying to animate the cutscene animatable with Id = {0}, but it isn't registered with the CutsceneManager", AnimatableId);
			}
			else
			{
				_hospitalVisual.SetIsUnlocked(Unlock, Immediately);
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (_hospitalVisual == null || !_hospitalVisual.IsAnimating())
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
