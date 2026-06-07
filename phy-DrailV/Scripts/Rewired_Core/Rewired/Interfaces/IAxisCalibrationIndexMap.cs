namespace Rewired.Interfaces
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal interface IAxisCalibrationIndexMap
	{
		int GetMappedAxisIndex(int axisIndex);
	}
}
