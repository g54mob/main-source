using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class MissingLicensesPageTemplatePaper : TemplatePaper
	{
		[Serializable]
		private class LicenseEntry
		{
			public GameObject parentObject;

			public TextMeshProUGUI licenseName;

			public Image licenseIcon;

			public Image licenseAcquiredIcon;

			public Image licenseMissingIcon;

			public LicenseEntry(TextMeshProUGUI licenseName, Image licenseIcon, Image licenseAcquiredIcon, Image licenseMissingIcon)
			{
				this.licenseName = licenseName;
				this.licenseIcon = licenseIcon;
				this.licenseAcquiredIcon = licenseAcquiredIcon;
				this.licenseMissingIcon = licenseMissingIcon;
			}

			public void Set(string name, Sprite icon, bool acquired)
			{
				parentObject.SetActive(value: true);
				licenseName.text = name;
				licenseIcon.sprite = icon;
				licenseAcquiredIcon.gameObject.SetActive(acquired);
				licenseMissingIcon.gameObject.SetActive(!acquired);
			}

			public void Clear()
			{
				parentObject.SetActive(value: false);
			}
		}

		public MissingLicensesPageTemplatePaperData data;

		public TextMeshProUGUI jobType;

		public TextMeshProUGUI jobSubtype;

		public TextMeshProUGUI jobId;

		public Image jobTypeBgColor;

		[SerializeField]
		private List<LicenseEntry> licenseEntries;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for missing license page, but data was not set!", this);
				return;
			}
			jobType.text = data.jobType;
			jobSubtype.text = data.jobSubtype;
			jobId.text = data.jobId;
			jobTypeBgColor.color = data.jobTypeColor;
			List<MissingLicensesPageTemplatePaperData.LicensePrintData> licensesData = data.licensesData;
			int count = licenseEntries.Count;
			int num = 0;
			foreach (MissingLicensesPageTemplatePaperData.LicensePrintData item in licensesData)
			{
				if (num == count)
				{
					Debug.LogError("No more space for license icons!");
					break;
				}
				licenseEntries[num++].Set(item.licenseName, item.licenseIcon, item.isAcquired);
			}
			for (int i = num; i < count; i++)
			{
				licenseEntries[i].Clear();
			}
		}
	}
}
