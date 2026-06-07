using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public interface INativeDatePickerInterface : INativeObject, IDisposable
	{
		DatePickerMode Mode { get; }

		event DatePickerClosedInternalCallback OnClose;

		void SetKind(DateTimeKind value);

		void SetMinimumDate(DateTime? value);

		void SetMaximumDate(DateTime? value);

		void SetInitialDate(DateTime? value);

		void Show();
	}
}
