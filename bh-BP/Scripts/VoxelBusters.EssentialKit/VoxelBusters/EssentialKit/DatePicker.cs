using System;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.NativeUICore;

namespace VoxelBusters.EssentialKit
{
	public sealed class DatePicker : NativeFeatureBehaviour
	{
		public delegate void ValueChangeCallback(DateTime? date);

		private INativeDatePickerInterface m_nativeInterface;

		private DateTimeKind m_kind;

		private DateTime? m_minDate;

		private DateTime? m_maxDate;

		private DateTime? m_initialDate;

		private DateTime? m_selectedDate;

		public ValueChangeCallback OnValueChange;

		public Callback<DatePickerResult> OnCloseCallback;

		public DateTime? SelectedDate => null;

		public static DatePicker CreateInstance(DatePickerMode mode = DatePickerMode.DateAndTime)
		{
			return null;
		}

		protected override void AwakeInternal(object[] args)
		{
		}

		protected override void DestroyInternal()
		{
		}

		public override bool IsAvailable()
		{
			return false;
		}

		protected override string GetFeatureName()
		{
			return null;
		}

		public DateTimeKind GetKind()
		{
			return default(DateTimeKind);
		}

		public DatePickerMode GetMode()
		{
			return default(DatePickerMode);
		}

		public DateTime? GetMinimumDate()
		{
			return null;
		}

		public DateTime? GetMaximumDate()
		{
			return null;
		}

		public DateTime? GetInitialDate()
		{
			return null;
		}

		public DatePicker SetKind(DateTimeKind value)
		{
			return null;
		}

		public DatePicker SetMinimumDate(DateTime? value)
		{
			return null;
		}

		public DatePicker SetMaximumDate(DateTime? value)
		{
			return null;
		}

		public DatePicker SetInitialDate(DateTime? value)
		{
			return null;
		}

		private void SetSelectedDate(DateTime? value)
		{
		}

		public DatePicker SetOnValueChange(ValueChangeCallback callback)
		{
			return null;
		}

		public DatePicker SetOnCloseCallback(Callback<DatePickerResult> callback)
		{
			return null;
		}

		public void Show()
		{
		}

		private void RegisterForEvents()
		{
		}

		private void UnregisterFromEvents()
		{
		}

		private DateTime? ChangeDateTimeToSuitableFormat(DateTime? dateTime)
		{
			return null;
		}

		private void HandleCloseInternalCallback(DateTime? selectedDate, Error error)
		{
		}
	}
}
