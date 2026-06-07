using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public abstract class NativeDatePickerInterfaceBase : NativeObjectBase, INativeDatePickerInterface, INativeObject, IDisposable
	{
		public DatePickerMode Mode { get; private set; }

		public event DatePickerClosedInternalCallback OnClose
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected NativeDatePickerInterfaceBase(DatePickerMode mode)
		{
		}

		public abstract void SetKind(DateTimeKind value);

		public abstract void SetMinimumDate(DateTime? value);

		public abstract void SetMaximumDate(DateTime? value);

		public abstract void SetInitialDate(DateTime? value);

		public abstract void Show();

		protected void SendCloseEvent(DateTime? selectedDate, Error error)
		{
		}
	}
}
