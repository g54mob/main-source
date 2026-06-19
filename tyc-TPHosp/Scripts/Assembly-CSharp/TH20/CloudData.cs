using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class CloudData
	{
		[Key(0)]
		public bool ShowCampusPromotion;

		[Key(1)]
		public bool PrimePromotionAvailableForSignUp;

		[Key(2)]
		public int SteamCampusPreorderID;

		[Key(3)]
		public string MSStoreCampusPreorderID;
	}
}
