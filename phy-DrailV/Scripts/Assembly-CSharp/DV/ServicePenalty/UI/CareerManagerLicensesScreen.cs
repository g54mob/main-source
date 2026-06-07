using System;
using System.Collections.Generic;
using System.Linq;
using DV.Booklets;
using DV.Localization;
using DV.Printers;
using DV.ThingTypes;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerLicensesScreen : ScrollableDisplayScreen
	{
		[Serializable]
		private class LicenseEntry
		{
			public TextMeshPro name;

			public TextMeshPro status;

			public bool IsAcquired { get; set; }

			public bool IsObtainable { get; set; }

			public JobLicenseType_v2 JobLicense { get; private set; }

			public GeneralLicenseType_v2 GeneralLicense { get; private set; }

			public bool IsJobLicenseSet => JobLicense != null;

			public bool IsGeneralLicenseSet => GeneralLicense != null;

			public LicenseEntry(TextMeshPro id, TextMeshPro value)
			{
				name = id;
				status = value;
			}

			public void Clear()
			{
				name.text = string.Empty;
				status.text = string.Empty;
				JobLicense = null;
				GeneralLicense = null;
				IsAcquired = false;
				IsObtainable = false;
			}

			public void UpdateJobLicenseData(JobLicenseType_v2 jobLicenseToSet)
			{
				LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
				bool flag = instance.IsJobLicenseAcquired(jobLicenseToSet);
				name.text = LocalizationAPI.L(jobLicenseToSet.localizationKey);
				status.text = (flag ? CareerManagerLocalization.OWNED : ("$" + jobLicenseToSet.price.ToString("N2", LocalizationAPI.CC)));
				IsAcquired = flag;
				IsObtainable = instance.IsJobLicenseObtainable(jobLicenseToSet);
				JobLicense = jobLicenseToSet;
				GeneralLicense = null;
			}

			public void UpdateGeneralLicenseData(GeneralLicenseType_v2 generalLicenseToSet)
			{
				LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
				bool flag = instance.IsGeneralLicenseAcquired(generalLicenseToSet);
				name.text = LocalizationAPI.L(generalLicenseToSet.localizationKey);
				status.text = (flag ? CareerManagerLocalization.OWNED : ("$" + generalLicenseToSet.price.ToString("N2", LocalizationAPI.CC)));
				IsAcquired = flag;
				IsObtainable = instance.IsGeneralLicenseObtainable(generalLicenseToSet);
				GeneralLicense = generalLicenseToSet;
				JobLicense = null;
			}
		}

		[Serializable]
		private class GeneralOrJobLicense
		{
			public JobLicenseType_v2 jobLicense;

			public GeneralLicenseType_v2 generalLicense;
		}

		public DisplayScreenSwitcher screenSwitcher;

		public CareerManagerMainScreen mainScreen;

		public CareerManagerLicensePayingScreen licensePayScreen;

		public CareerManagerInfoScreen infoScreen;

		public PrinterController licensePrinter;

		public TextMeshPro title1;

		public TextMeshPro pressPrintInfo;

		[SerializeField]
		private List<GeneralOrJobLicense> licensesDisplayOrder;

		[SerializeField]
		private List<LicenseEntry> licenseEntries;

		protected override int TotalSlotCount => SingletonBehaviour<LicenseManager>.Instance.AllLicensesCount;

		private void Awake()
		{
			if (screenSwitcher == null)
			{
				Debug.LogError("screenSwitcher reference isn't set! Screen can't function!");
				return;
			}
			if (licensePrinter == null)
			{
				Debug.LogError("licensePrinter reference isn't set! Screen can't function!");
				return;
			}
			activeSlotCount = licenseEntries.Count;
			int allLicensesCount = SingletonBehaviour<LicenseManager>.Instance.AllLicensesCount;
			if (activeSlotCount > allLicensesCount)
			{
				Debug.LogError($"Unexpected state: Expected {allLicensesCount} entries, got {activeSlotCount}. Screen can't function correctly");
				return;
			}
			if (licensesDisplayOrder.Any((GeneralOrJobLicense l) => (l.jobLicense != null && l.generalLicense != null) || (l.jobLicense == null && l.generalLicense == null)))
			{
				Debug.LogError("Unexpected state: licensesDisplayOrder entries need to have either job or general license set!");
			}
			selector = new IntIterator(0, activeSlotCount, isWrappable: true);
		}

		public override void Activate(IDisplayScreen previousScreen)
		{
			title1.text = CareerManagerLocalization.LICENSES;
			if (previousScreen == mainScreen)
			{
				selector.Reset();
				base.IndexOfFirstDisplayedEntry = 0;
			}
			Scroll(base.IndexOfFirstDisplayedEntry, selector.Current);
			pressPrintInfo.text = CareerManagerLocalization.PRESS_PRINT_FOR_DETAILS;
		}

		public override void Disable()
		{
			TextMeshPro textMeshPro = title1;
			string text = (pressPrintInfo.text = string.Empty);
			textMeshPro.text = text;
			foreach (LicenseEntry licenseEntry in licenseEntries)
			{
				licenseEntry.Clear();
			}
			base.Disable();
		}

		public override void HandleInputAction(InputAction input)
		{
			switch (input)
			{
			case InputAction.Up:
				ScrollUp();
				break;
			case InputAction.Down:
				ScrollDown();
				break;
			case InputAction.Cancel:
				screenSwitcher.SetActiveDisplay(mainScreen);
				break;
			case InputAction.Confirm:
			{
				int current = selector.Current;
				LicenseEntry licenseEntry2 = licenseEntries[current];
				if (!licenseEntry2.IsGeneralLicenseSet && !licenseEntry2.IsJobLicenseSet)
				{
					Debug.LogError(string.Format("Invalid state of {0}[{1}]! Ignoring request", "licenseEntries", current));
				}
				else
				{
					if (licenseEntry2.IsAcquired)
					{
						break;
					}
					if (!licenseEntry2.IsObtainable)
					{
						GeneralLicenseType_v2 requiredGeneralLicense;
						JobLicenseType_v2 requiredJobLicense;
						if (licenseEntry2.IsGeneralLicenseSet)
						{
							GeneralLicenseType_v2 generalLicense = licenseEntry2.GeneralLicense;
							requiredGeneralLicense = generalLicense.requiredGeneralLicense;
							requiredJobLicense = generalLicense.requiredJobLicense;
						}
						else
						{
							JobLicenseType_v2 jobLicense = licenseEntry2.JobLicense;
							requiredGeneralLicense = jobLicense.requiredGeneralLicense;
							requiredJobLicense = jobLicense.requiredJobLicense;
						}
						string data = string.Empty;
						if (requiredGeneralLicense != null)
						{
							data = LocalizationAPI.L(requiredGeneralLicense.localizationKey);
						}
						else if (requiredJobLicense != null)
						{
							data = LocalizationAPI.L(requiredJobLicense.localizationKey);
						}
						else
						{
							Debug.LogError("Unexpected state, IsObtainable is false, but doesn't have required licenses set!");
						}
						infoScreen.SetInfoData(this, CareerManagerInfoScreen.Preset.MissingLicense, data);
						screenSwitcher.SetActiveDisplay(infoScreen);
						break;
					}
					SingletonBehaviour<CareerManagerDebtController>.Instance.RefreshExistingDebtsState();
					if (SingletonBehaviour<CareerManagerDebtController>.Instance.NumberOfNonZeroPricedDebts > 0)
					{
						infoScreen.SetInfoData(this, CareerManagerInfoScreen.Preset.Fees);
						screenSwitcher.SetActiveDisplay(infoScreen);
						break;
					}
					if (licenseEntry2.IsGeneralLicenseSet)
					{
						licensePayScreen.SetGeneralLicenseToBuy(licenseEntry2.GeneralLicense);
					}
					else if (licenseEntry2.IsJobLicenseSet)
					{
						licensePayScreen.SetJobLicenseToBuy(licenseEntry2.JobLicense);
					}
					screenSwitcher.SetActiveDisplay(licensePayScreen);
				}
				break;
			}
			case InputAction.PrintInfo:
			{
				if (licensePrinter.IsOnCooldown)
				{
					licensePrinter.PlayErrorSound();
					break;
				}
				LicenseEntry licenseEntry = licenseEntries[selector.Current];
				Vector3 position = licensePrinter.spawnAnchor.position;
				Quaternion rotation = licensePrinter.spawnAnchor.rotation;
				Transform originShiftParent = WorldMover.OriginShiftParent;
				if (licenseEntry.IsJobLicenseSet)
				{
					BookletCreator.CreateLicenseInfo(licenseEntry.JobLicense, position, rotation, originShiftParent);
				}
				else
				{
					if (!licenseEntry.IsGeneralLicenseSet)
					{
						Debug.LogError("InvalidState: license to buy is not set!");
						break;
					}
					BookletCreator.CreateLicenseInfo(licenseEntry.GeneralLicense, position, rotation, originShiftParent);
				}
				licensePrinter.Print();
				break;
			}
			}
		}

		public override void PopulateTextsFromIndex(int startingIndex)
		{
			base.PopulateTextsFromIndex(startingIndex);
			int num = 0;
			for (int i = 0; i < licensesDisplayOrder.Count; i++)
			{
				if (i >= startingIndex)
				{
					if (num == activeSlotCount)
					{
						break;
					}
					GeneralOrJobLicense generalOrJobLicense = licensesDisplayOrder[i];
					if (generalOrJobLicense.generalLicense != null)
					{
						licenseEntries[num++].UpdateGeneralLicenseData(generalOrJobLicense.generalLicense);
					}
					else if (generalOrJobLicense.jobLicense != null)
					{
						licenseEntries[num++].UpdateJobLicenseData(generalOrJobLicense.jobLicense);
					}
					else
					{
						Debug.LogError("licensesDisplayOrder is not initialized properly!");
					}
				}
			}
		}

		public override void HighlightSelected(int newHighlight, int prevHighlighted = -1)
		{
			if (prevHighlighted != -1 && prevHighlighted != newHighlight)
			{
				licenseEntries[prevHighlighted].name.color = screenSwitcher.REGULAR_COLOR;
				licenseEntries[prevHighlighted].status.color = screenSwitcher.REGULAR_COLOR;
			}
			if (newHighlight != -1)
			{
				licenseEntries[newHighlight].name.color = screenSwitcher.HIGHLIGHTED_COLOR;
				licenseEntries[newHighlight].status.color = screenSwitcher.HIGHLIGHTED_COLOR;
			}
		}
	}
}
