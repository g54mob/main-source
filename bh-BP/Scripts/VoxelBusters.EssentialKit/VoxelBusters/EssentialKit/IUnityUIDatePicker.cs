using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface IUnityUIDatePicker
	{
		DatePickerMode Mode { get; set; }

		DateTime? MinDate { get; set; }

		DateTime? MaxDate { get; set; }

		DateTime? InitialDate { get; set; }

		DateTimeKind Kind { get; set; }

		DateTime SelectedDate { get; set; }

		void Show();

		void Dismiss();

		void SetCompletionCallback(EventCallback<DateTime?> callback);
	}
}
