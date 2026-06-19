using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;

namespace UI.Inventory
{
	public class InventoryViewModel : ViewModelBase
	{
		public InteractionRequest CloseRequest = new InteractionRequest();

		public InteractionRequest HideRequest = new InteractionRequest();

		public void HideInventoryCommand()
		{
			HideRequest?.Raise();
		}

		public void MinimizeInventoryCommand()
		{
		}

		public void CloseInventoryCommand()
		{
			CloseRequest?.Raise();
		}
	}
}
