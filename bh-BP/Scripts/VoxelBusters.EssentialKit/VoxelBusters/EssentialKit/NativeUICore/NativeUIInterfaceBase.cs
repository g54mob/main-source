using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public abstract class NativeUIInterfaceBase : NativeFeatureInterfaceBase, INativeUIInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		protected NativeUIInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract INativeAlertDialogInterface CreateAlertDialog(AlertDialogStyle style);

		public abstract INativeDatePickerInterface CreateDatePicker(DatePickerMode mode);
	}
}
