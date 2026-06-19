using System;
using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class InterationViewModel : ViewModelBase
	{
		public readonly InteractionRequest<DialogNotification> AlertDialogRequest = new InteractionRequest<DialogNotification>();

		public readonly AsyncInteractionRequest<DialogNotification> AsyncAlertDialogRequest = new AsyncInteractionRequest<DialogNotification>();

		public readonly InteractionRequest<ToastNotification> ToastRequest = new InteractionRequest<ToastNotification>();

		public readonly InteractionRequest<VisibilityNotification> LoadingRequest = new InteractionRequest<VisibilityNotification>();

		public SimpleCommand OpenAlertDialog { get; }

		public SimpleCommand AsyncOpenAlertDialog { get; }

		public SimpleCommand ShowToast { get; }

		public SimpleCommand ShowLoading { get; }

		public SimpleCommand HideLoading { get; }

		public InterationViewModel()
		{
			OpenAlertDialog = new SimpleCommand(delegate
			{
				OpenAlertDialog.Enabled = false;
				DialogNotification context = new DialogNotification("Interation Example", "This is a dialog test.", "Yes", "No");
				Action<DialogNotification> callback = delegate(DialogNotification n)
				{
					OpenAlertDialog.Enabled = true;
					if (n.DialogResult == -1)
					{
						Debug.LogFormat("Click: Yes");
					}
					else if (n.DialogResult == -2)
					{
						Debug.LogFormat("Click: No");
					}
				};
				AlertDialogRequest.Raise(context, callback);
			});
			AsyncOpenAlertDialog = new SimpleCommand(async delegate
			{
				AsyncOpenAlertDialog.Enabled = false;
				DialogNotification notification = new DialogNotification("Interation Example", "This is a dialog test.", "Yes", "No");
				await AsyncAlertDialogRequest.Raise(notification);
				AsyncOpenAlertDialog.Enabled = true;
				if (notification.DialogResult == -1)
				{
					Debug.LogFormat("Click: Yes");
				}
				else if (notification.DialogResult == -2)
				{
					Debug.LogFormat("Click: No");
				}
			});
			ShowToast = new SimpleCommand(delegate
			{
				ToastNotification context = new ToastNotification("This is a toast test.", 2f);
				ToastRequest.Raise(context);
			});
			ShowLoading = new SimpleCommand(delegate
			{
				VisibilityNotification context = new VisibilityNotification(visible: true);
				LoadingRequest.Raise(context);
			});
			HideLoading = new SimpleCommand(delegate
			{
				VisibilityNotification context = new VisibilityNotification(visible: false);
				LoadingRequest.Raise(context);
			});
		}
	}
}
