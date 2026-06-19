using System;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Views
{
	public class AlertDialogWindow : AlertDialogWindowBase
	{
		public Text Title;

		public Text Message;

		public Button ConfirmButton;

		public Button NeutralButton;

		public Button CancelButton;

		public Button OutsideButton;

		public bool CanceledOnTouchOutside { get; set; }

		public override IUIView ContentView
		{
			get
			{
				return contentView;
			}
			set
			{
				if (contentView == value)
				{
					return;
				}
				if (contentView != null)
				{
					UnityEngine.Object.Destroy(contentView.Owner);
				}
				contentView = value;
				if (contentView != null && contentView.Owner != null && Content != null)
				{
					contentView.Visibility = true;
					contentView.Transform.SetParent(Content.transform, worldPositionStays: false);
					if (Message != null)
					{
						Message.gameObject.SetActive(value: false);
					}
				}
			}
		}

		protected virtual void Button_OnClick(int which)
		{
			try
			{
				viewModel.OnClick(which);
			}
			catch (Exception)
			{
			}
			finally
			{
				Dismiss();
			}
		}

		public override void Cancel()
		{
			Button_OnClick(-2);
		}

		protected override void OnCreate(IBundle bundle)
		{
			base.WindowType = WindowType.DIALOG;
		}

		protected override void OnChangeViewModel()
		{
			if (Message != null)
			{
				if (!string.IsNullOrEmpty(viewModel.Message))
				{
					Message.gameObject.SetActive(value: true);
					Message.text = viewModel.Message;
					if (contentView != null && contentView.Visibility)
					{
						contentView.Visibility = false;
					}
				}
				else
				{
					Message.gameObject.SetActive(value: false);
				}
			}
			if (Title != null)
			{
				if (!string.IsNullOrEmpty(viewModel.Title))
				{
					Title.gameObject.SetActive(value: true);
					Title.text = viewModel.Title;
				}
				else
				{
					Title.gameObject.SetActive(value: false);
				}
			}
			if (ConfirmButton != null)
			{
				if (!string.IsNullOrEmpty(viewModel.ConfirmButtonText))
				{
					ConfirmButton.gameObject.SetActive(value: true);
					ConfirmButton.onClick.AddListener(delegate
					{
						Button_OnClick(-1);
					});
					Text componentInChildren = ConfirmButton.GetComponentInChildren<Text>();
					if (componentInChildren != null)
					{
						componentInChildren.text = viewModel.ConfirmButtonText;
					}
				}
				else
				{
					ConfirmButton.gameObject.SetActive(value: false);
				}
			}
			if (CancelButton != null)
			{
				if (!string.IsNullOrEmpty(viewModel.CancelButtonText))
				{
					CancelButton.gameObject.SetActive(value: true);
					CancelButton.onClick.AddListener(delegate
					{
						Button_OnClick(-2);
					});
					Text componentInChildren2 = CancelButton.GetComponentInChildren<Text>();
					if (componentInChildren2 != null)
					{
						componentInChildren2.text = viewModel.CancelButtonText;
					}
				}
				else
				{
					CancelButton.gameObject.SetActive(value: false);
				}
			}
			if (NeutralButton != null)
			{
				if (!string.IsNullOrEmpty(viewModel.NeutralButtonText))
				{
					NeutralButton.gameObject.SetActive(value: true);
					NeutralButton.onClick.AddListener(delegate
					{
						Button_OnClick(-3);
					});
					Text componentInChildren3 = NeutralButton.GetComponentInChildren<Text>();
					if (componentInChildren3 != null)
					{
						componentInChildren3.text = viewModel.NeutralButtonText;
					}
				}
				else
				{
					NeutralButton.gameObject.SetActive(value: false);
				}
			}
			CanceledOnTouchOutside = viewModel.CanceledOnTouchOutside;
			if (OutsideButton != null && CanceledOnTouchOutside)
			{
				OutsideButton.gameObject.SetActive(value: true);
				OutsideButton.interactable = true;
				OutsideButton.onClick.AddListener(delegate
				{
					Button_OnClick(-2);
				});
			}
		}
	}
}
