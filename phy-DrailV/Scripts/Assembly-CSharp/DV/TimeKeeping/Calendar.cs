using System.Collections.Generic;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.TimeKeeping
{
	public class Calendar : MonoBehaviour
	{
		public GameObject dayIndicator;

		public GameObject dayPrefab;

		public Transform container;

		public ACalendarDataProvider dataProvider;

		public Color regularDayColor = Color.black;

		public Color saturdayColor = Color.gray;

		public Color sundayColor = Color.red;

		[Range(0f, 6f)]
		public int firstDayOfMonthDayOfWeek;

		private List<GameObject> generatedDays = new List<GameObject>();

		private void Start()
		{
			GenerateCalendar();
			if (dataProvider == null)
			{
				SetDataProvider(SingletonBehaviour<ACalendarDataProvider>.Instance);
			}
		}

		private void OnDayOfMonthChanged()
		{
			int num = dataProvider.DayOfMonth - 1;
			if (num < 0 || num >= dataProvider.DaysInMonth)
			{
				dayIndicator.SetActive(value: false);
			}
			else
			{
				Rect rect = dayPrefab.GetComponent<RectTransform>().rect;
				float width = rect.width;
				float height = rect.height;
				dayIndicator.transform.localPosition = container.localPosition + new Vector3((float)((num + firstDayOfMonthDayOfWeek) % 7) * width, (float)(-(num + firstDayOfMonthDayOfWeek) / 7) * height, 0f);
				dayIndicator.SetActive(value: true);
			}
			for (int i = 0; i < generatedDays.Count; i++)
			{
				generatedDays[i].SetActive(i < dataProvider.DaysInMonth);
			}
		}

		private void GenerateCalendar()
		{
			Rect rect = dayPrefab.GetComponent<RectTransform>().rect;
			float width = rect.width;
			float height = rect.height;
			for (int i = 0; i < 31; i++)
			{
				GameObject gameObject = Object.Instantiate(dayPrefab, container);
				int num = (i + firstDayOfMonthDayOfWeek) % 7;
				int num2 = (i + firstDayOfMonthDayOfWeek) / 7;
				gameObject.transform.localPosition = new Vector3((float)num * width, (float)(-num2) * height, 0f);
				TMP_Text componentInChildren = gameObject.GetComponentInChildren<TMP_Text>();
				componentInChildren.text = (i + 1).ToString();
				Color color;
				switch (num)
				{
				default:
					color = regularDayColor;
					break;
				case 5:
					color = saturdayColor;
					break;
				case 6:
					color = sundayColor;
					break;
				}
				componentInChildren.color = color;
				generatedDays.Add(gameObject);
			}
		}

		public void SetDataProvider(ACalendarDataProvider provider)
		{
			if (dataProvider != null)
			{
				dataProvider.DayOfMonthChanged -= OnDayOfMonthChanged;
				dataProvider = null;
			}
			dataProvider = provider;
			if (dataProvider != null)
			{
				dataProvider.DayOfMonthChanged += OnDayOfMonthChanged;
				OnDayOfMonthChanged();
			}
			else
			{
				dayIndicator.SetActive(value: false);
			}
		}
	}
}
