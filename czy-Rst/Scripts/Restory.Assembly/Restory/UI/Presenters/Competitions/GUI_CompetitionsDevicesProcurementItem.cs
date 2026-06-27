using System;
using System.Collections;
using Restory.Data.Devices;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Licenses;
using Restory.ObjectPools;
using Restory.UI.Views.Competitions;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Competitions
{
	public sealed class GUI_CompetitionsDevicesProcurementItem : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_CompetitionsDevicesProcurementItemView view;

		[SerializeField]
		[Min(0.1f)]
		private float competitionRequestProgressDurationSeconds = 2f;

		private DeviceInfo device;

		private float requestProgressTimer;

		private Coroutine requestProgressCoroutine;

		private CompetitionsApp competitionsApp;

		public DeviceInfo Device => device;

		[Inject]
		private void Construct(CompetitionsApp competitionsApp)
		{
			this.competitionsApp = competitionsApp;
			if (base.isActiveAndEnabled)
			{
				CompetitionsAppSubscribe();
			}
		}

		private void OnEnable()
		{
			view.OnSubmitRequestButtonDowned += ResolveOnSubmitRequestButtonDowned;
			view.OnSubmitRequestButtonUpped += ResolveOnSubmitRequestButtonUpped;
			CompetitionsAppSubscribe();
		}

		private void OnDisable()
		{
			view.OnSubmitRequestButtonDowned -= ResolveOnSubmitRequestButtonDowned;
			view.OnSubmitRequestButtonUpped -= ResolveOnSubmitRequestButtonUpped;
			CompetitionsAppUnsubscribe();
		}

		private void CompetitionsAppSubscribe()
		{
			CompetitionsAppUnsubscribe();
			if (competitionsApp != null)
			{
				if (competitionsApp.Wallet != null)
				{
					competitionsApp.Wallet.OnMoneyAmountChanged += ResolveMoneyAmountChanged;
				}
				if (competitionsApp.LicensesService != null)
				{
					competitionsApp.LicensesService.OnLicensesChanged += ResolveLicensesChanged;
				}
				competitionsApp.OnCompetitionRequestsChanged += ResolveCompetitionRequirementsChanged;
			}
		}

		private void CompetitionsAppUnsubscribe()
		{
			if (competitionsApp != null)
			{
				if (competitionsApp.Wallet != null)
				{
					competitionsApp.Wallet.OnMoneyAmountChanged -= ResolveMoneyAmountChanged;
				}
				if (competitionsApp.LicensesService != null)
				{
					competitionsApp.LicensesService.OnLicensesChanged -= ResolveLicensesChanged;
				}
				competitionsApp.OnCompetitionRequestsChanged -= ResolveCompetitionRequirementsChanged;
			}
		}

		public void Init(DeviceInfo device)
		{
			this.device = device;
			TimeSpan bestTime = TimeSpan.Zero;
			if (GetBestTimeForDevice(device, out var bestTime2))
			{
				bestTime = TimeSpan.FromSeconds(bestTime2);
			}
			view.Init(device.Icon, device.NameLocalizationKey, device.CompetitionParticipationPrice, device.CompetitionReward, bestTime);
			UpdateState();
		}

		public void Clean()
		{
			device = null;
		}

		private void UpdateState()
		{
			if (!(device == null) && !(competitionsApp == null))
			{
				if (!ContainsLicense(device))
				{
					view.SetState(GUI_CompetitionsDevicesProcurementItemView.ItemState.LicenseRequired);
				}
				else if (!EnoughFunds(device))
				{
					view.SetState(GUI_CompetitionsDevicesProcurementItemView.ItemState.InsufficientFunds);
				}
				else if (requestProgressCoroutine != null)
				{
					view.SetState(GUI_CompetitionsDevicesProcurementItemView.ItemState.Requested);
					view.SetRequestProgress(requestProgressTimer);
				}
				else
				{
					view.SetState(GUI_CompetitionsDevicesProcurementItemView.ItemState.Normal);
				}
			}
		}

		private bool GetBestTimeForDevice(DeviceInfo device, out float bestTime)
		{
			return competitionsApp.ResultsTrackingService.TryGetBestTimeForDevice(device, out bestTime);
		}

		private bool ContainsLicense(DeviceInfo device)
		{
			if (!(device.License == null))
			{
				return competitionsApp.LicensesService.Contains(device.License);
			}
			return true;
		}

		private bool EnoughFunds(DeviceInfo device)
		{
			return competitionsApp.Wallet.MoneyAvailable >= device.CompetitionParticipationPrice;
		}

		private void ResolveCompetitionRequirementsChanged(CompetitionsApp app, DeviceInfo device)
		{
			if (!(this.device != device))
			{
				UpdateState();
			}
		}

		private void ResolveLicensesChanged(LicensesService licensesService)
		{
			UpdateState();
		}

		private void ResolveMoneyAmountChanged()
		{
			UpdateState();
		}

		private IEnumerator UpdateProgress()
		{
			while (true)
			{
				requestProgressTimer += Time.deltaTime / competitionRequestProgressDurationSeconds;
				view.SetRequestProgress(requestProgressTimer);
				if (requestProgressTimer > 1f)
				{
					break;
				}
				yield return null;
			}
			requestProgressTimer = 0f;
			requestProgressCoroutine = null;
			UpdateState();
			if (competitionsApp == null)
			{
				Debug.LogWarning("[GUI_CompetitionsDevicesProcurementItem] CompetitionsApp reference is null. Cannot submit a request for competitions.");
			}
			else
			{
				competitionsApp.TryCompleteRequestAndSubmitDevice(device);
			}
		}

		private void ResolveOnSubmitRequestButtonDowned()
		{
			requestProgressTimer = 0f;
			if (requestProgressCoroutine == null)
			{
				requestProgressCoroutine = StartCoroutine(UpdateProgress());
			}
			UpdateState();
		}

		private void ResolveOnSubmitRequestButtonUpped()
		{
			if (requestProgressCoroutine != null)
			{
				StopCoroutine(requestProgressCoroutine);
				requestProgressCoroutine = null;
			}
			UpdateState();
		}
	}
}
