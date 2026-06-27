using System;
using Restory.Data.Analytics;
using Restory.UI.Views.ConfirmationDialog;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.ConfirmationDialog
{
	public class GUI_DataCollectionNoticeNotification : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private GUI_ConfirmationDialogView view;

		[SerializeField]
		private GameObject curtain;

		[SerializeField]
		private GUI_PanelStack panelStack;

		private bool isShown;

		private AnalyticsConsentCheckingService analyticsConsentCheckingService;

		[Inject]
		private void Construct(AnalyticsConsentCheckingService analyticsConsentCheckingService)
		{
			this.analyticsConsentCheckingService = analyticsConsentCheckingService;
		}

		private void Awake()
		{
			curtain.SetActive(value: true);
		}

		private void OnEnable()
		{
			view.OnPositiveClicked += ResolveOnPositiveClicked;
			view.OnNegativeClicked += ResolveOnNegativeClicked;
		}

		private void OnDisable()
		{
			view.OnPositiveClicked -= ResolveOnPositiveClicked;
			view.OnNegativeClicked -= ResolveOnNegativeClicked;
		}

		public void Initialize()
		{
			if (analyticsConsentCheckingService.IsDataLoadingCompleted)
			{
				ResolveConsentStatusLoaded();
				return;
			}
			analyticsConsentCheckingService.OnDataLoadingCompleted -= ResolveConsentStatusLoaded;
			analyticsConsentCheckingService.OnDataLoadingCompleted += ResolveConsentStatusLoaded;
		}

		public void Dispose()
		{
			if (analyticsConsentCheckingService != null)
			{
				analyticsConsentCheckingService.OnDataLoadingCompleted -= ResolveConsentStatusLoaded;
			}
		}

		private void ShowConfirmationDialog()
		{
			if (!isShown)
			{
				isShown = true;
				panelStack.AddPanel(base.gameObject);
				view.Show();
			}
		}

		private void HideConfirmationDialog()
		{
			if (isShown)
			{
				isShown = false;
				panelStack.RemovePanel(base.gameObject);
				view.Hide();
			}
		}

		private void ResolveConsentStatusLoaded()
		{
			analyticsConsentCheckingService.OnDataLoadingCompleted -= ResolveConsentStatusLoaded;
			if (analyticsConsentCheckingService.State == AnalyticsConsentState.Unknown)
			{
				ShowConfirmationDialog();
			}
			else
			{
				curtain.SetActive(value: false);
			}
		}

		private void ResolveOnPositiveClicked()
		{
			analyticsConsentCheckingService.State = AnalyticsConsentState.Confirmed;
			analyticsConsentCheckingService.Save();
			curtain.SetActive(value: false);
			HideConfirmationDialog();
		}

		private void ResolveOnNegativeClicked()
		{
			analyticsConsentCheckingService.State = AnalyticsConsentState.Canceled;
			analyticsConsentCheckingService.Save();
			curtain.SetActive(value: false);
			HideConfirmationDialog();
		}
	}
}
