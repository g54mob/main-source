using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/SFX")]
	public class PlaySFX : Action
	{
		[UsedImplicitly]
		public string AudioEventName = "";

		public override void OnStart()
		{
			base.OnStart();
			AudioManager.Instance.Play(AudioEventName);
		}
	}
}
