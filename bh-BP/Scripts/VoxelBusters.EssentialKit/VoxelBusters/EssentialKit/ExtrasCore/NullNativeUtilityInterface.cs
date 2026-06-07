namespace VoxelBusters.EssentialKit.ExtrasCore
{
	public class NullNativeUtilityInterface : NativeUtilityInterfaceBase
	{
		public NullNativeUtilityInterface()
			: base(isAvailable: false)
		{
		}

		public override void OpenAppStorePage(string applicationId)
		{
		}

		public override void OpenApplicationSettings()
		{
		}
	}
}
