namespace Jundroo.Services.Ads
{
	public interface IAd
	{
		bool CanShowAd();

		void Destroy();

		void Show();
	}
}
