using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class DialogServiceExampleViewModel : ViewModelBase
	{
		private SimpleCommand openAlertDialog;

		private SimpleCommand openAlertDialog2;

		private IDialogService dialogService;

		public ICommand OpenAlertDialog => openAlertDialog;

		public ICommand OpenAlertDialog2 => openAlertDialog2;

		public DialogServiceExampleViewModel(IDialogService dialogService)
		{
			this.dialogService = dialogService;
			openAlertDialog = new SimpleCommand(delegate
			{
				openAlertDialog.Enabled = false;
				this.dialogService.ShowDialog("Dialog Service Example", "This is a dialog test.", "Yes", "No", null, canceledOnTouchOutside: true).Callbackable().OnCallback(delegate(IAsyncResult<int> r)
				{
					if (r.Result == -1)
					{
						Debug.LogFormat("Click: Yes");
					}
					else if (r.Result == -2)
					{
						Debug.LogFormat("Click: No");
					}
					openAlertDialog.Enabled = true;
				});
			});
			openAlertDialog2 = new SimpleCommand(delegate
			{
				openAlertDialog2.Enabled = false;
				AlertDialogViewModel viewModel = new AlertDialogViewModel
				{
					Title = "Dialog Service Example",
					Message = "This is a dialog test.",
					ConfirmButtonText = "OK"
				};
				this.dialogService.ShowDialog("UI/AlertDialog", viewModel).Callbackable().OnCallback(delegate(IAsyncResult<AlertDialogViewModel> r)
				{
					if (r.Result.Result == -1)
					{
						Debug.LogFormat("Click: OK");
					}
					openAlertDialog2.Enabled = true;
				});
			});
		}
	}
}
