using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public interface INativeUIInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		INativeAlertDialogInterface CreateAlertDialog(AlertDialogStyle style);

		INativeDatePickerInterface CreateDatePicker(DatePickerMode mode);
	}
}
