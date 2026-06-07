namespace Rewired.Drivers.Interfaces
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IDriver_RailDriver : IControllerDriver
	{
		bool SpeakerEnabled { get; set; }

		void SetLEDDisplay(int digitIndex, byte digitBitValues);

		void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues);
	}
}
