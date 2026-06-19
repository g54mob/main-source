using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using Services.Missions;
using Zenject;

namespace UI.Sites.SkyHigh
{
	internal class SkyHighViewModel : ViewModelBase
	{
		private InteractionRequest<Notification> _openOrderPopupRequest;

		[Inject]
		private MissionEventBus _missionEventBus;

		public IInteractionRequest OpenOrderPopupRequest => _openOrderPopupRequest;

		public SkyHighViewModel()
		{
			_openOrderPopupRequest = new InteractionRequest<Notification>(this);
		}

		public void NewOrderCommand()
		{
			_missionEventBus.Emit("interact", "createOrder");
			_openOrderPopupRequest.Raise(new Notification("Oper Order Popup"));
		}

		public void GetJobCommand()
		{
		}
	}
}
