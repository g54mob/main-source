namespace VoxelBusters.EssentialKit.NativeUICore
{
	public sealed class UnityUIInterface : NativeUIInterfaceBase
	{
		public UnityUIInterface()
			: base(isAvailable: false)
		{
		}

		public override INativeAlertDialogInterface CreateAlertDialog(AlertDialogStyle style)
		{
			return null;
		}

		public override INativeDatePickerInterface CreateDatePicker(DatePickerMode mode)
		{
			return null;
		}

		private static NativeUIUnitySettings.UnityUICollection GetCustomUICollection()
		{
			return null;
		}

		private static void CreateRenderIfRequired(NativeUIUnitySettings.UnityUICollection uiCollection)
		{
		}
	}
}
