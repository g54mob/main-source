using DV.Booklets;
using DV.CashRegister;
using DV.Localization;
using DV.Printers;
using DV.ThingTypes;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerLicensePayingScreen : DisplayScreen
	{
		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerLicensesScreen licensesScreen;

		public CashRegisterCareerManager cashReg;

		public PrinterController licensePrinter;

		public TextMeshPro title1;

		public TextMeshPro title2;

		public TextMeshPro licenseNameText;

		public TextMeshPro licensePriceText;

		public TextMeshPro insertWallet;

		public TextMeshPro depositedText;

		public TextMeshPro depositedValue;

		private JobLicenseType_v2 jobLicenseToBuy;

		private GeneralLicenseType_v2 generalLicenseToBuy;

		private bool IsJobLicense => jobLicenseToBuy != null;

		private bool IsGeneralLicense => generalLicenseToBuy != null;

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
			}
			else if (cashReg == null)
			{
				Debug.LogError("cashReg reference isn't set! Screen can't function!");
			}
			else if (licensePrinter == null)
			{
				Debug.LogError("licensePrinter reference isn't set! Screen can't function!");
			}
			else
			{
				ClearLicenseToBuy();
			}
		}

		public void SetJobLicenseToBuy(JobLicenseType_v2 jobLicenseToBuy)
		{
			this.jobLicenseToBuy = jobLicenseToBuy;
			generalLicenseToBuy = null;
		}

		public void SetGeneralLicenseToBuy(GeneralLicenseType_v2 generalLicenseToBuy)
		{
			this.generalLicenseToBuy = generalLicenseToBuy;
			jobLicenseToBuy = null;
		}

		public override void Activate(IDisplayScreen _)
		{
			if (!IsJobLicense && !IsGeneralLicense)
			{
				Debug.LogError("Both jobLicenseToBuy and generalLicenseToBuy wasn't set! Activating licenses screen.");
				screenSwitcher.SetActiveDisplay(licensesScreen);
			}
			float price;
			string text;
			if (IsGeneralLicense)
			{
				price = generalLicenseToBuy.price;
				text = LocalizationAPI.L(generalLicenseToBuy.localizationKey);
			}
			else
			{
				price = jobLicenseToBuy.price;
				text = LocalizationAPI.L(jobLicenseToBuy.localizationKey);
			}
			cashReg.SetTotalCost(price);
			cashReg.CashAdded += OnCashAdded;
			title1.text = CareerManagerLocalization.LICENSES;
			title2.text = CareerManagerLocalization.LICENSE_COLON;
			licenseNameText.text = text;
			licensePriceText.text = "$" + price.ToString("N2", LocalizationAPI.CC);
			insertWallet.text = CareerManagerLocalization.INSERT_WALLET_TO_PAY;
			depositedText.text = CareerManagerLocalization.DEPOSITED;
			depositedValue.text = "$" + cashReg.DepositedCash.ToString("N2", LocalizationAPI.CC);
		}

		public override void Disable()
		{
			ClearLicenseToBuy();
			cashReg.ClearCurrentTransaction();
			cashReg.CashAdded -= OnCashAdded;
			TextMeshPro textMeshPro = title1;
			TextMeshPro textMeshPro2 = title2;
			TextMeshPro textMeshPro3 = licenseNameText;
			TextMeshPro textMeshPro4 = licensePriceText;
			TextMeshPro textMeshPro5 = insertWallet;
			TextMeshPro textMeshPro6 = depositedText;
			string text = (depositedValue.text = string.Empty);
			string text2 = (textMeshPro6.text = text);
			string text4 = (textMeshPro5.text = text2);
			string text6 = (textMeshPro4.text = text4);
			string text8 = (textMeshPro3.text = text6);
			string text10 = (textMeshPro2.text = text8);
			textMeshPro.text = text10;
		}

		public override void HandleInputAction(InputAction input)
		{
			Vector3 position = licensePrinter.spawnAnchor.position;
			Quaternion rotation = licensePrinter.spawnAnchor.rotation;
			Transform originShiftParent = WorldMover.OriginShiftParent;
			switch (input)
			{
			case InputAction.Cancel:
				screenSwitcher.SetActiveDisplay(licensesScreen);
				break;
			case InputAction.Confirm:
			{
				if (!cashReg.Buy())
				{
					break;
				}
				LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
				if (IsJobLicense)
				{
					instance.AcquireJobLicense(jobLicenseToBuy);
					BookletCreator.CreateLicense(jobLicenseToBuy, position, rotation, originShiftParent);
				}
				else
				{
					if (!IsGeneralLicense)
					{
						Debug.LogError("InvalidState: license to buy is not set!");
						break;
					}
					instance.AcquireGeneralLicense(generalLicenseToBuy);
					BookletCreator.CreateLicense(generalLicenseToBuy, position, rotation, originShiftParent);
				}
				licensePrinter.Print(ignoreCooldown: true);
				screenSwitcher.SetActiveDisplay(licensesScreen);
				break;
			}
			case InputAction.PrintInfo:
				if (licensePrinter.IsOnCooldown)
				{
					licensePrinter.PlayErrorSound();
					break;
				}
				if (IsJobLicense)
				{
					BookletCreator.CreateLicenseInfo(jobLicenseToBuy, position, rotation, originShiftParent);
				}
				else
				{
					if (!IsGeneralLicense)
					{
						Debug.LogError("InvalidState: license to buy is not set!");
						break;
					}
					BookletCreator.CreateLicenseInfo(generalLicenseToBuy, position, rotation, originShiftParent);
				}
				licensePrinter.Print();
				break;
			}
		}

		private void ClearLicenseToBuy()
		{
			generalLicenseToBuy = null;
			jobLicenseToBuy = null;
		}

		private void OnCashAdded()
		{
			depositedValue.text = "$" + cashReg.DepositedCash.ToString("N2", LocalizationAPI.CC);
		}
	}
}
