using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Views
{
	public abstract class AlertDialogWindowBase : Window
	{
		public GameObject Content;

		protected IUIView contentView;

		protected AlertDialogViewModel viewModel;

		public virtual IUIView ContentView
		{
			get
			{
				return contentView;
			}
			set
			{
				if (contentView != value)
				{
					if (contentView != null)
					{
						Object.Destroy(contentView.Owner);
					}
					contentView = value;
					if (contentView != null && contentView.Owner != null && Content != null)
					{
						contentView.Visibility = true;
						contentView.Transform.SetParent(Content.transform, worldPositionStays: false);
					}
				}
			}
		}

		public virtual AlertDialogViewModel ViewModel
		{
			get
			{
				return viewModel;
			}
			set
			{
				if (viewModel != value)
				{
					viewModel = value;
					OnChangeViewModel();
				}
			}
		}

		protected override void OnCreate(IBundle bundle)
		{
			base.WindowType = WindowType.DIALOG;
		}

		protected abstract void OnChangeViewModel();

		public abstract void Cancel();
	}
}
