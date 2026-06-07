using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public class UnityUIDatePickerInterface : NativeDatePickerInterfaceBase
	{
		private DateTime? m_minDate;

		private DateTime? m_maxDate;

		private DateTime? m_initialDate;

		private DateTimeKind m_kind;

		private UnityUIDatePicker m_datePicker;

		private RectTransform m_parent;

		private UnityUIDatePicker m_datePickerPrefab;

		public UnityUIDatePickerInterface(DatePickerMode mode, UnityUIDatePicker datePickerPrefab, RectTransform parent)
			: base(default(DatePickerMode))
		{
		}

		~UnityUIDatePickerInterface()
		{
		}

		public override void SetKind(DateTimeKind value)
		{
		}

		public override void SetMinimumDate(DateTime? value)
		{
		}

		public override void SetMaximumDate(DateTime? value)
		{
		}

		public override void SetInitialDate(DateTime? value)
		{
		}

		public override void Show()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void HandleCompletionCallback(DateTime? result, Error error)
		{
		}
	}
}
