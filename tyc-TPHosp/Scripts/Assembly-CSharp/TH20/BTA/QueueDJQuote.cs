using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Radio")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/RadioIcon.png")]
	public class QueueDJQuote : Action
	{
		[UsedImplicitly]
		public RadioDJQuote DJQuote;

		[UsedImplicitly]
		public bool InterruptSong;

		public override void OnStart()
		{
			base.OnStart();
			Radio.OnQueueDJQuoteRequest.InvokeSafe(DJQuote, InterruptSong);
		}
	}
}
