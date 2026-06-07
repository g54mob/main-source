namespace Assets.Scripts.Craft.Parts
{
	public enum AttachPointConnectionType
	{
		None = 0,
		Normal = 1,
		Wing = 2,
		Missile = 4,
		Decal = 8,
		PowertrainInput = 0x10,
		PowertrainOutput = 0x20,
		PowertrainWheel = 0x40,
		DriveShaft = 0x80,
		Shroud = 0x100,
		Wheel = 0x200
	}
}
