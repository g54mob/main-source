using System.Linq;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FrontPageTemplatePaper : TemplatePaper
	{
		private const float INITIAL_TRACK_OFFSET = -41f;

		private const float CAR_LENGTH_OFFSET = 112f;

		private const float CAR_HEIGHT_OFFSET = 27f;

		private const float CAR_X_SCALE_FACTOR = 0.67f;

		private const float CAR_Y_SCALE_FACTOR = 0.67f;

		private const int CARS_PER_TRACK = 10;

		private const int MAX_DISPLAYED_CARS = 20;

		private const int NUM_OF_DIFFERENT_LICENSES = 5;

		public bool displayCarIds = true;

		public FrontPageTemplatePaperData data;

		public GameObject car;

		public TextMeshProUGUI jobType;

		public TextMeshProUGUI jobSubtype;

		public TextMeshProUGUI jobId;

		public Image jobTypeBgColor;

		public Image cargoIcon1;

		public Image cargoIcon2;

		public TextMeshProUGUI jobDescription;

		public TextMeshProUGUI singleStationName;

		public TextMeshProUGUI singleStationType;

		public Image singleStationBgColor;

		public TextMeshProUGUI startStationName;

		public TextMeshProUGUI startStationType;

		public Image startStationBgColor;

		public TextMeshProUGUI endStationName;

		public TextMeshProUGUI endStationType;

		public Image endStationBgColor;

		public Image trackLineTop;

		public Image trackLineBot;

		public TextMeshProUGUI trainLength;

		public TextMeshProUGUI trainMass;

		public TextMeshProUGUI trainValue;

		public TextMeshProUGUI timeBonus;

		public Image[] requiredLicenseSlots;

		public TextMeshProUGUI payment;

		public Text pageNumber;

		public override void CleanUp()
		{
			for (int i = 0; i < dynamicallyCreatedObjects.Count; i++)
			{
				Object.Destroy(dynamicallyCreatedObjects[i]);
			}
			dynamicallyCreatedObjects.Clear();
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for front page, but data was not set!", this);
				return;
			}
			jobType.text = data.jobType;
			jobSubtype.text = data.jobSubtype;
			jobId.text = data.jobId;
			jobTypeBgColor.color = data.jobTypeColor;
			jobDescription.text = data.jobDescription;
			cargoIcon1?.gameObject.SetActive(value: false);
			cargoIcon2?.gameObject.SetActive(value: false);
			singleStationName.text = data.singleStationName;
			singleStationType.text = data.singleStationType;
			singleStationBgColor.color = data.singleStationBgColor;
			startStationType.text = data.startStationType;
			startStationName.text = data.startStationName;
			startStationBgColor.color = data.startStationBgColor;
			endStationType.text = data.endStationType;
			endStationName.text = data.endStationName;
			endStationBgColor.color = data.endStationBgColor;
			if (singleStationName.text == "")
			{
				singleStationName.transform.parent.gameObject.SetActive(value: false);
				startStationName.transform.parent.gameObject.SetActive(value: true);
				endStationName.transform.parent.gameObject.SetActive(value: true);
			}
			else
			{
				startStationName.transform.parent.gameObject.SetActive(value: false);
				endStationName.transform.parent.gameObject.SetActive(value: false);
				singleStationName.transform.parent.gameObject.SetActive(value: true);
			}
			trainLength.text = data.trainLength;
			trainMass.text = data.trainMass;
			trainValue.text = data.trainValue;
			timeBonus.text = data.timeBonus;
			DisplayRequiredLicenses(data.requiredLicenses);
			payment.text = "+$" + data.payment;
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
			bool flag = data.cargoTypePerCar != null;
			if (flag && data.cargoTypePerCar.Count != data.cars.Count)
			{
				flag = false;
				Debug.LogError("Different number of cargoTypePerCar and cars! This shouldn't happen ever! Will treat it like there is no cargo!");
			}
			int num = Mathf.Min(data.cars.Count, 20);
			bool flag2 = num <= 10;
			trackLineBot.gameObject.SetActive(value: true);
			trackLineTop.gameObject.SetActive(!flag2);
			for (int i = 0; i < num; i++)
			{
				int num2 = i % 10;
				GameObject gameObject = Object.Instantiate(car, new Vector3(-41f + 112f * (float)num2, 27f, 0f), Quaternion.identity);
				gameObject.transform.localScale = new Vector3(0.67f, 0.67f, 1f);
				Image image = ((flag2 || i >= 10) ? trackLineBot : trackLineTop);
				gameObject.transform.SetParent(image.transform, worldPositionStays: false);
				TrainCarLivery type = data.cars[i].type;
				Sprite icon = type.icon;
				if (icon != null)
				{
					gameObject.GetComponent<Image>().sprite = icon;
				}
				gameObject.GetComponentInChildren<TextMeshProUGUI>().text = (displayCarIds ? data.cars[i].ID : "");
				if (flag)
				{
					CargoType_v2 cargoType_v = data.cargoTypePerCar[i].ToV2();
					if (cargoType_v.HasVisibleModelForCarType(type.parentType))
					{
						Sprite icon2 = cargoType_v.icon;
						if (icon2 != null)
						{
							Transform transform = gameObject.transform.Find("[cargo icon]");
							if ((bool)transform)
							{
								Image component = transform.GetComponent<Image>();
								component.sprite = icon2;
								component.color = Color.white;
							}
							else
							{
								Debug.LogError("Couldn't find cargo icon GO with name [cargo icon]! Skipping cargo icon placement");
							}
						}
					}
				}
				dynamicallyCreatedObjects.Add(gameObject);
			}
		}

		private void DisplayRequiredLicenses(JobLicenses requiredLicenses)
		{
			if (requiredLicenseSlots == null || requiredLicenseSlots.Length < 5)
			{
				Debug.LogError(string.Format("Need {0} {1} initialized! Required licenses will be wrong! Update prefab!", 5, "requiredLicenseSlots"), this);
				return;
			}
			Image[] array = requiredLicenseSlots;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(value: false);
			}
			if (requiredLicenses == JobLicenses.Basic)
			{
				return;
			}
			int num = 0;
			foreach (JobLicenseType_v2 item in Globals.G.Types.jobLicenses.Skip(1))
			{
				if (requiredLicenses.HasIntFlag(item.v1))
				{
					if (num == requiredLicenseSlots.Length)
					{
						Debug.LogError("Can't fit all required licenses!");
						break;
					}
					requiredLicenseSlots[num++].sprite = item.icon;
				}
			}
			for (int j = 0; j < num; j++)
			{
				requiredLicenseSlots[j].gameObject.SetActive(value: true);
			}
		}
	}
}
