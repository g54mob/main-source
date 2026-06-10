using NSMedieval.UI;

namespace NSMedieval.State
{
	public interface INegotiator : ITrader
	{
		public delegate void InteractedWithHandler(HumanoidInstance workerInstance);

		bool WantsToNegotiate { get; set; }

		int? WontNegotiateWithWorkerId { get; set; }

		string WontNegotiateWithWorkerBBTTextKey { get; set; }

		HumanoidInstance Humanoid { get; }

		event InteractedWithHandler InteractedWithEvent;

		void OnInteractedWith(HumanoidInstance worker);

		string GetLocalizedMenuItemText();
	}
}
