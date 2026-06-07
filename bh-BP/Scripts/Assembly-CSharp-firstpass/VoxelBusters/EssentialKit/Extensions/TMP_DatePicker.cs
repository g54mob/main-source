using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VoxelBusters.EssentialKit.NativeUICore;

namespace VoxelBusters.EssentialKit.Extensions
{
	public class TMP_DatePicker : UnityUIDatePicker
	{
		[SerializeField]
		private RectTransform m_dateNode;

		[SerializeField]
		private TMP_Dropdown m_dayDropdown;

		[SerializeField]
		private TMP_Dropdown m_monthDropdown;

		[SerializeField]
		private TMP_Dropdown m_yearDropdown;

		[SerializeField]
		private RectTransform m_timeNode;

		[SerializeField]
		private TMP_Dropdown m_hourDropdown;

		[SerializeField]
		private TMP_Dropdown m_minuteDropdown;

		private static int GetDropdownValue(TMP_Dropdown dropdown)
		{
			return 0;
		}

		private static void SelectDropdownValue(TMP_Dropdown dropdown, int value)
		{
		}

		private static List<string> ConvertIntegerToStringNames(int startIndex, int count, string format)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public override void Show()
		{
		}

		private void ConfigureYearDropdown()
		{
		}

		private void ConfigureMonthDropdown()
		{
		}

		private void ConfigureDayDropdown(int month, int year)
		{
		}

		private void ConfigureHourDropdown()
		{
		}

		private void ConfigureMinuteDropdown()
		{
		}

		public void OnSubmit()
		{
		}

		public void OnDismiss()
		{
		}

		public void OnDropdownValueChange(Dropdown dropdown)
		{
		}
	}
}
