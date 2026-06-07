using System;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public class NullDatePickerInterface : NativeDatePickerInterfaceBase
	{
		private DateTime? m_minDate;

		private DateTime? m_maxDate;

		private DateTime? m_initialDate;

		private DateTimeKind m_kind;

		public NullDatePickerInterface(DatePickerMode mode)
			: base(default(DatePickerMode))
		{
		}

		~NullDatePickerInterface()
		{
		}

		private static void LogNotSupported()
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
	}
}
