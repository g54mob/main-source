using DV.Localization;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class TaskTemplatePaper : TemplatePaper
	{
		private const float INITIAL_TRACK_OFFSET = -56f;

		private const float CAR_LENGTH_OFFSET = 166f;

		private const float CAR_HEIGHT_OFFSET = 40f;

		private const int CARS_PER_TRACK = 6;

		public TaskTemplatePaperData data;

		public GameObject car;

		public TextMeshProUGUI stepNum;

		public TextMeshProUGUI taskType;

		public TextMeshProUGUI taskDescription;

		public TextMeshProUGUI yardId;

		public Image yardBgColor;

		public TextMeshProUGUI trackId;

		public Image trackBgColor;

		public TextMeshProUGUI stationName;

		public TextMeshProUGUI stationType;

		public Image stationBgColor;

		public Image[] tracks;

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
				Debug.LogWarning("Trying to fill data for task page, but data was not set!", this);
				return;
			}
			stepNum.text = LocalizationAPI.L("job/task_step_no", data.stepNum);
			taskType.text = data.taskType;
			taskDescription.text = data.taskDescription;
			stationName.text = data.stationName;
			stationType.text = data.stationType;
			yardId.text = data.yardId;
			trackId.text = data.trackId;
			if (stationName.text == "")
			{
				yardBgColor.color = data.yardColor;
				trackBgColor.color = data.trackColor;
				stationName.transform.parent.gameObject.SetActive(value: false);
				yardId.transform.parent.gameObject.SetActive(value: true);
			}
			else
			{
				stationBgColor.color = data.stationColor;
				yardId.transform.parent.gameObject.SetActive(value: false);
				stationName.transform.parent.gameObject.SetActive(value: true);
			}
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
			int count = data.cars.Count;
			tracks[0].enabled = true;
			for (int i = 1; i < tracks.Length; i++)
			{
				tracks[i].enabled = count > i * 6;
			}
			bool flag = data.cargoTypePerCar != null;
			if (flag && data.cargoTypePerCar.Count != data.cars.Count)
			{
				flag = false;
				Debug.LogError("Different number of cargoTypePerCar and cars! This shouldn't happen ever! Will treat it like there is no cargo!");
			}
			for (int j = 0; j < count; j++)
			{
				int num = j % 6;
				int num2 = j / 6;
				GameObject gameObject = Object.Instantiate(car, new Vector3(-56f + 166f * (float)num, 40f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(tracks[num2].transform, worldPositionStays: false);
				TrainCarLivery type = data.cars[j].type;
				Sprite icon = type.icon;
				if (icon != null)
				{
					gameObject.GetComponent<Image>().sprite = icon;
				}
				gameObject.GetComponentInChildren<TextMeshProUGUI>().text = data.cars[j].ID;
				if (flag)
				{
					CargoType_v2 cargoType_v = data.cargoTypePerCar[j].ToV2();
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
	}
}
