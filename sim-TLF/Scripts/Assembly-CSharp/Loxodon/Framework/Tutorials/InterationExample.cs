using System;
using System.Collections.Generic;
using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Services;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.InteractionActions;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class InterationExample : WindowView
	{
		public Button openAlert;

		public Button asyncOpenAlert;

		public Button showToast;

		public Button showLoading;

		public Button hideLoading;

		private List<Loading> list = new List<Loading>();

		private LoadingInteractionAction loadingInteractionAction;

		private ToastInteractionAction toastInteractionAction;

		private AsyncDialogInteractionAction dialogInteractionAction;

		protected override void Awake()
		{
			ApplicationContext applicationContext = Context.GetApplicationContext();
			new BindingServiceBundle(applicationContext.GetContainer()).Start();
			IServiceContainer container = applicationContext.GetContainer();
			container.Register((IUIViewLocator)new DefaultUIViewLocator());
			CultureInfo cultureInfo = Locale.GetCultureInfo();
			Localization current = Localization.Current;
			current.CultureInfo = cultureInfo;
			current.AddDataProvider(new DefaultDataProvider("LocalizationTutorials", new XmlDocumentParser()));
			container.Register(current);
		}

		protected override void Start()
		{
			loadingInteractionAction = new LoadingInteractionAction();
			toastInteractionAction = new ToastInteractionAction(this);
			dialogInteractionAction = new AsyncDialogInteractionAction("UI/AlertDialog");
			InterationViewModel dataContext = new InterationViewModel();
			this.SetDataContext(dataContext);
			BindingSet<InterationExample, InterationViewModel> bindingSet = this.CreateBindingSet<InterationExample, InterationViewModel>();
			bindingSet.Bind().For((InterationExample v) => v.OnOpenAlert).To((InterationViewModel vm) => vm.AlertDialogRequest);
			bindingSet.Bind().For((InterationExample v) => v.dialogInteractionAction).To((InterationViewModel vm) => vm.AsyncAlertDialogRequest);
			bindingSet.Bind().For((InterationExample v) => v.toastInteractionAction).To((InterationViewModel vm) => vm.ToastRequest);
			bindingSet.Bind().For((InterationExample v) => v.loadingInteractionAction).To((InterationViewModel vm) => vm.LoadingRequest);
			bindingSet.Bind(openAlert).For((Button v) => v.onClick).To((InterationViewModel vm) => vm.OpenAlertDialog);
			bindingSet.Bind(asyncOpenAlert).For((Button v) => v.onClick).To((InterationViewModel vm) => vm.AsyncOpenAlertDialog);
			bindingSet.Bind(showToast).For((Button v) => v.onClick).To((InterationViewModel vm) => vm.ShowToast);
			bindingSet.Bind(showLoading).For((Button v) => v.onClick).To((InterationViewModel vm) => vm.ShowLoading);
			bindingSet.Bind(hideLoading).For((Button v) => v.onClick).To((InterationViewModel vm) => vm.HideLoading);
			bindingSet.Build();
		}

		private void OnOpenAlert(object sender, InteractionEventArgs args)
		{
			DialogNotification notification = args.Context as DialogNotification;
			Action callback = args.Callback;
			if (notification != null)
			{
				AlertDialog.ShowMessage(notification.Message, notification.Title, notification.ConfirmButtonText, null, notification.CancelButtonText, notification.CanceledOnTouchOutside, delegate(int result)
				{
					notification.DialogResult = result;
					callback?.Invoke();
				});
			}
		}

		private void OnShowToast(object sender, InteractionEventArgs args)
		{
			if (args.Context is ToastNotification toastNotification)
			{
				Toast.Show(this, toastNotification.Message, toastNotification.Duration);
			}
		}

		private void OnShowOrHideLoading(object sender, InteractionEventArgs args)
		{
			if (args.Context is VisibilityNotification visibilityNotification)
			{
				if (visibilityNotification.Visible)
				{
					list.Add(Loading.Show());
				}
				else if (list.Count > 0)
				{
					list[0].Dispose();
					list.RemoveAt(0);
				}
			}
		}
	}
}
